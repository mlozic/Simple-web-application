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
    public class CategoriesController : ApiController
    {
        private AdventureWorksOBPEntity _context;
        public CategoriesController()
        {
            _context = new AdventureWorksOBPEntity();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IEnumerable<KategorijeDto> GetKategorije()
        {
            return _context.Kategorije.ToList().Select(Mapper.Map<Kategorija, KategorijeDto>);
        }
        [HttpGet]
        public IHttpActionResult GetKategorija(int id)
        {
            Kategorija kategorija = _context.Kategorije.Single(k => k.IDKategorija == id);
            if (kategorija == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Kategorija, KategorijeDto>(kategorija));
        }
        // POST /api/customers
        [HttpPost]
        public IHttpActionResult NoviKategorija(KategorijeDto kategorijaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var kategorija = Mapper.Map<KategorijeDto, Kategorija>(kategorijaDto);
            _context.Kategorije.Add(kategorija);
            _context.SaveChanges();
            kategorijaDto.IDKategorija = kategorija.IDKategorija;
            return Created(new Uri(Request.RequestUri + "/" + kategorija.IDKategorija), kategorijaDto);
        }
        [HttpPut]
        public void IzmjeniKategoriju(int id, KategorijeDto kategorijaDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var kategorijaUbazi = _context.Kategorije.SingleOrDefault(k => k.IDKategorija == id);
            if (kategorijaUbazi == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(kategorijaDto, kategorijaUbazi);

            _context.SaveChanges();
        }
        [HttpDelete]
        public void IzbrisiKategoriju(int id)
        {
            var kategorijaUbazi = _context.Kategorije.SingleOrDefault(k => k.IDKategorija == id);
            if (kategorijaUbazi == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Potkategorije.RemoveRange(_context.Potkategorije.Where(p => p.KategorijaID == id));
            _context.SaveChanges();
            _context.Kategorije.Remove(kategorijaUbazi);
            _context.SaveChanges();
        }
    }
}
