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
    public class CitiesController : ApiController
    {
        private AdventureWorksOBPEntity _context;
        public CitiesController()
        {
            _context = new AdventureWorksOBPEntity();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [HttpGet]
        public IEnumerable<GradoviDto> Getgradovi()
        {
            return _context.Gradovi.ToList().Select(Mapper.Map<Grad, GradoviDto>);
        }
    }
}
