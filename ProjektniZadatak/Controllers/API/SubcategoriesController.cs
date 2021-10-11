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
    public class SubcategoriesController : ApiController
    {
        private AdventureWorksOBPEntity _context;
        public SubcategoriesController()
        {
            _context = new AdventureWorksOBPEntity();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IEnumerable<PotkategorijeDto> GetPotkategorije()
        {
            return _context.Potkategorije.ToList().Select(Mapper.Map<Potkategorija, PotkategorijeDto>);
        }
        [HttpGet]
        public IHttpActionResult GetPotkategorija(int id)
        {
            Potkategorija potkategorija = _context.Potkategorije.Single(k => k.IDPotkategorija == id);
            if (potkategorija == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Potkategorija, PotkategorijeDto>(potkategorija));
        }
        // POST /api/customers
        [HttpPost]
        public IHttpActionResult NovaPotkategorija(PotkategorijeDto potkategorijaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var potkategorija = Mapper.Map<PotkategorijeDto, Potkategorija>(potkategorijaDto);
            _context.Potkategorije.Add(potkategorija);
            _context.SaveChanges();
            potkategorijaDto.IDPotkategorija = potkategorija.IDPotkategorija;
            return Created(new Uri(Request.RequestUri + "/" + potkategorija.IDPotkategorija), potkategorijaDto);
        }
        [HttpPut]
        public void IzmjeniPotkategoriju(int id, PotkategorijeDto potkategorijaDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var potkategorijaUbazi = _context.Potkategorije.SingleOrDefault(k => k.IDPotkategorija == id);
            if (potkategorijaUbazi == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(potkategorijaDto, potkategorijaUbazi);

            _context.SaveChanges();
        }
        [HttpDelete]
        public void IzbrisiPotkategoriju(int id)
        {
            var potkategorijaUbazi = _context.Potkategorije.SingleOrDefault(k => k.IDPotkategorija == id);
            if (potkategorijaUbazi == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Potkategorije.Remove(potkategorijaUbazi);
            _context.SaveChanges();
        }
    }
}
