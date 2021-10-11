using ProjektniZadatak.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjektniZadatak.Controllers
{
    public class SubcategoriesController : Controller
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
        // GET: Subcategories
        public ActionResult New()
        {
            SubcategoriesAndCategoriesDataViewModel naslov = new SubcategoriesAndCategoriesDataViewModel
            {
                Potkategorija = new Potkategorija(),
                Kategorije = _context.Kategorije.ToList(),
                Naslov = "Nova Potkategorija"
            };
            
            return View(naslov);
        }
        public ActionResult Save(Potkategorija potkategorija)
        {
            if (!ModelState.IsValid)
            {
                SubcategoriesAndCategoriesDataViewModel subcategoriesData = new SubcategoriesAndCategoriesDataViewModel
                {
                    Potkategorija = new Potkategorija(),
                    Kategorije = _context.Kategorije.ToList(),
                    Naslov = "Uredi potkategoriju"
                };
                return View("New", subcategoriesData);
            }
            if (potkategorija.IDPotkategorija == 0)
            {
                _context.Potkategorije.Add(potkategorija);
            }
            else
            {
                Potkategorija potkategorijaUBazi = _context.Potkategorije.Single(p => p.IDPotkategorija == potkategorija.IDPotkategorija);
                potkategorijaUBazi.NazivPotkategorije = potkategorija.NazivPotkategorije;
                potkategorijaUBazi.KategorijaID = potkategorija.KategorijaID;
            }
            _context.SaveChanges();

            return RedirectToAction("index", "products");
        }
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            Potkategorija potkategorija = _context.Potkategorije.SingleOrDefault(p => p.IDPotkategorija == id);
            SubcategoriesAndCategoriesDataViewModel subcategoriesData = new SubcategoriesAndCategoriesDataViewModel
            {
                Potkategorija = potkategorija,
                Kategorije = _context.Kategorije.ToList(),
                Naslov = "Uredi potkategoriju"
            };
            return View("New", subcategoriesData);
        }
    }
}