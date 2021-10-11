using AutoMapper;
using ProjektniZadatak.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjektniZadatak.Controllers.API
{
    public class CustomersController : ApiController
    {
        private AdventureWorksOBPEntity _context;
        public CustomersController()
        {
            _context = new AdventureWorksOBPEntity();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IEnumerable<KupciDto> GetKupci() => _context.Kupci.ToList().Select(Mapper.Map<Kupac, KupciDto>);
        [HttpGet]
        public IHttpActionResult GetKupac(int id)
        {
            Kupac kupac  = _context.Kupci.Single(k => k.IDKupac == id);
            if (kupac == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Kupac, KupciDto>(kupac));
        }
        // POST /api/customers
        [HttpPost]
        public IHttpActionResult NoviKupac(KupciDto kupacDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var kupac = Mapper.Map<KupciDto, Kupac>(kupacDto);
            _context.Kupci.Add(kupac);
            _context.SaveChanges();
            kupacDto.IDKupac = kupac.IDKupac;
            return Created(new Uri(Request.RequestUri + "/" + kupac.IDKupac), kupacDto);
        }
        [HttpPut]
        public void IzmjeniKupca (int id, KupciDto kupacDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var kupacUbazi = _context.Kupci.SingleOrDefault(k => k.IDKupac == id);
            if (kupacUbazi == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(kupacDto, kupacUbazi);
            
            _context.SaveChanges();
        }
        [HttpDelete]
        public void IzbrisiKupca(int id)
        {
            var kupacUbazi = _context.Kupci.SingleOrDefault(k => k.IDKupac == id);
            if (kupacUbazi == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            var listaRacuna = _context.Racuni.Where(r => r.KupacID == id).ToList();
            foreach (var racun in listaRacuna)
            {
                _context.Stavke.RemoveRange(_context.Stavke.Where(s => s.RacunID == racun.IDRacun));
            }
            _context.SaveChanges();
            _context.Racuni.RemoveRange(_context.Racuni.Where(r => r.KupacID == id));
            _context.SaveChanges();
            _context.Kupci.Remove(kupacUbazi);
            _context.SaveChanges();
        }

    }
}
