using AutoMapper;
using ProjektniZadatak.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjektniZadatak.Controllers.API
{
    public class ProductsController : ApiController
    {
        
        private AdventureWorksOBPEntity _context;
        public ProductsController()
        {
            _context = new AdventureWorksOBPEntity();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IEnumerable<ProizvodiDto> GetProizvodi()
        {
            return _context.Proizvodi.ToList().Select(Mapper.Map<Proizvod, ProizvodiDto>);
        }
        [HttpGet]
        public IHttpActionResult GetProizvod(int id)
        {
            Proizvod proizvod = _context.Proizvodi.Single(p => p.IDProizvod == id);
            if (proizvod == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Proizvod, ProizvodiDto>(proizvod));
        }
        // POST /api/customers
        [HttpPost]
        public IHttpActionResult NoviProizvod(ProizvodiDto proizvodDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var proizvod = Mapper.Map<ProizvodiDto, Proizvod>(proizvodDto);
            _context.Proizvodi.Add(proizvod);
            _context.SaveChanges();
            proizvodDto.IDProizvod = proizvod.IDProizvod;
            return Created(new Uri(Request.RequestUri + "/" + proizvod.IDProizvod), proizvodDto);
        }
        [HttpPut]
        public void IzmjeniProizvod(int id, ProizvodiDto proizvodDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var proizvodUbazi = _context.Proizvodi.SingleOrDefault(p => p.IDProizvod == id);
            if (proizvodUbazi == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(proizvodDto, proizvodUbazi);

            _context.SaveChanges();
        }
        [HttpDelete]
        public void IzbrisiProizvod(int id)
        {
            var proizvodUbazi = _context.Proizvodi.SingleOrDefault(p => p.IDProizvod == id);
            if (proizvodUbazi == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            var listaStavki = _context.Stavke.Where(s => s.ProizvodID == id).ToList();
            foreach (var racun in listaStavki)
            {
                _context.Stavke.RemoveRange(_context.Stavke.Where(s => s.ProizvodID == id));
            }
            _context.SaveChanges();
            _context.Proizvodi.Remove(proizvodUbazi);
            _context.SaveChanges();
        }

    }
}
