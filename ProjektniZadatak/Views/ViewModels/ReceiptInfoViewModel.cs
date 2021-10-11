using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektniZadatak.Views.ViewModels
{
    public class ReceiptInfoViewModel
    {
        public int IDRacuna { get; set; }
        public IEnumerable<Stavka> Stavke { get; set; }
        public IEnumerable<Proizvod> Proizvodi { get; set; }
        public IEnumerable<Potkategorija> Potkategorije { get; set; }
        public IEnumerable<Kategorija> Kategorije { get; set; }
        public IEnumerable<KreditnaKartica> KreditneKartice { get; set; }
        public IEnumerable<Komercijalist> Komercijalisti { get; set; }

    }
}