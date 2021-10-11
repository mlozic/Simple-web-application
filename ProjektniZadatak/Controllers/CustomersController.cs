using ProjektniZadatak.Models;
using ProjektniZadatak.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjektniZadatak.Controllers
{
    public class CustomersController : Controller
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
        // GET: Customers
        public ActionResult Index()
        {

            List<Grad> cmd = _context.Gradovi.ToList();

            return View(cmd);
        }

        public ActionResult CustomerInfo(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            CustomerInfoViewModel customerInfo = new CustomerInfoViewModel
            {
                Racuni = _context.Racuni.Where(r => r.KupacID == id).ToList(),
                Kupac = _context.Kupci.SingleOrDefault(k => k.IDKupac == id)
            };
            string idkupac = customerInfo.Kupac.IDKupac.ToString();
            Session["kupacId"] = idkupac;
            return View(customerInfo);
        }
    }
}