using ProjektniZadatak.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjektniZadatak.Controllers
{
    public class CategoriesController : Controller
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
        // GET: Categories
        public ActionResult New()
        {
            SubcategoriesAndCategoriesDataViewModel naslov = new SubcategoriesAndCategoriesDataViewModel
            {
                Kategorija = new Kategorija(),
                Naslov = "Nova Kategorija"
            };

            return View(naslov);
        }
        public ActionResult Save(Kategorija kategorija)
        {
            if (!ModelState.IsValid)
            {
                List<Kategorija> cat = _context.Kategorije.ToList();
                return View("New", cat);
            }
            if (kategorija.IDKategorija == 0)
            {
                _context.Kategorije.Add(kategorija);
            }
            else
            {
                Kategorija kategorijaUBazi = _context.Kategorije.Single(k => k.IDKategorija == kategorija.IDKategorija);
                kategorijaUBazi.NazivKategorije = kategorija.NazivKategorije;
            }
            _context.SaveChanges();

            return RedirectToAction("index", "Products");
        }
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            Kategorija kategorija = _context.Kategorije.SingleOrDefault(k => k.IDKategorija == id);
            SubcategoriesAndCategoriesDataViewModel categoriesData = new SubcategoriesAndCategoriesDataViewModel
            {
                Kategorija = kategorija,
                Naslov = "Uredi kategoriju"
            };
            return View("New", categoriesData);
        }
    }
}