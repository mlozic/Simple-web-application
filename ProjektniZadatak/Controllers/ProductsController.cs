using ProjektniZadatak.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjektniZadatak.Controllers
{
    public class ProductsController : Controller
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
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProductInfo(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }

            List<Stavka> stavke = _context.Stavke.Where(s => s.ProizvodID == id).ToList();
            List<Racun> racuni = new List<Racun>();

            foreach (var stavka in stavke)
            {
                racuni.Add(_context.Racuni.SingleOrDefault(r => r.IDRacun == stavka.RacunID));
            }

            IList<Kupac> kupci = new List<Kupac>();

            foreach (var racun in racuni)
            {
                kupci.Add(_context.Kupci.SingleOrDefault(k => k.IDKupac == racun.KupacID));
            }

            ProductInfoViewModel proizvodInfo = new ProductInfoViewModel
            {
                Kupci = kupci.Distinct(),
                Proizvod = _context.Proizvodi.SingleOrDefault(p => p.IDProizvod == id),
            };

            return View(proizvodInfo);
        }
        public ActionResult New()
        {
            ProductDataViewModel productData = new ProductDataViewModel
            {
                Potkategorije = _context.Potkategorije.ToList(),
                Kategorije = _context.Kategorije.ToList(),
                Proizvod = new Proizvod(),
                Naslov = "Novi Proizvod"
            };
            return View(productData);
        }
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            Proizvod proizvod = _context.Proizvodi.SingleOrDefault(p => p.IDProizvod == id);
            ProductDataViewModel productData = new ProductDataViewModel
            {
                Potkategorije = _context.Potkategorije.ToList(),
                Kategorije = _context.Kategorije.ToList(),
                Proizvod = proizvod,
                Naslov =  "Uredi postojeći proizvod"
            };
            return View("New", productData);
        }
        public ActionResult Save(Proizvod proizvod)
        {
            if (!ModelState.IsValid)
            {
                ProductDataViewModel productData = new ProductDataViewModel
                {
                    Proizvod = proizvod,
                    Potkategorije = _context.Potkategorije.ToList()
                };
                return View("New", productData);
            }
            if (proizvod.IDProizvod == 0)
            {
                _context.Proizvodi.Add(proizvod);
            }
            else
            {
                Proizvod proizvodUBazi = _context.Proizvodi.Single(p=> p.IDProizvod == proizvod.IDProizvod);
                proizvodUBazi.Naziv = proizvod.Naziv;
                proizvodUBazi.BrojProizvoda = proizvod.BrojProizvoda;
                proizvodUBazi.Boja = proizvod.Boja;
                proizvodUBazi.MinimalnaKolicinaNaSkladistu = proizvod.MinimalnaKolicinaNaSkladistu;
                proizvodUBazi.CijenaBezPDV = proizvod.CijenaBezPDV;
                proizvodUBazi.PotkategorijaID = proizvod.PotkategorijaID;
            }
            _context.SaveChanges();

            return RedirectToAction("index", "Products");
        }
    }
}