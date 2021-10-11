using ProjektniZadatak.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjektniZadatak.Controllers
{
    public class ReceiptsController : Controller
    {
        private AdventureWorksOBPEntity _context;
        public ReceiptsController()
        {
            _context = new AdventureWorksOBPEntity();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Receipts
        public ActionResult ReceiptInfo(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            ReceiptInfoViewModel receiptInfo = new ReceiptInfoViewModel();


            Racun temp = _context.Racuni.SingleOrDefault(r => r.IDRacun == id);
            receiptInfo.IDRacuna = temp.IDRacun;

            foreach (var racun in _context.Racuni.ToList())
            {
                if (racun.IDRacun==id)
                {
                    receiptInfo.Stavke = _context.Stavke.Where(s => s.RacunID == id).ToList();
                    receiptInfo.KreditneKartice = _context.KreditneKartice.Where(k => k.IDKreditnaKartica == racun.KreditnaKarticaID).ToList();
                    receiptInfo.Komercijalisti = _context.Komercijalisti.Where(k => k.IDKomercijalist == racun.KomercijalistID).ToList();
                }
            }
            foreach (var stavka in receiptInfo.Stavke)
            {
                receiptInfo.Proizvodi = _context.Proizvodi.Where(p => p.IDProizvod == stavka.ProizvodID).ToList();
            }
            foreach (var proizvod in receiptInfo.Proizvodi)
            {
                receiptInfo.Potkategorije = _context.Potkategorije.Where(p => p.IDPotkategorija == proizvod.PotkategorijaID).ToList();
            }
            foreach (var potkategorija in receiptInfo.Potkategorije)
            {
                receiptInfo.Kategorije = _context.Kategorije.Where(p => p.IDKategorija == potkategorija.KategorijaID).ToList();
            }
            


            return View(receiptInfo);
        }
    }
}