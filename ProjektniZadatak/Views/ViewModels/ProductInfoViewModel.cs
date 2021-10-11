using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektniZadatak.Views.ViewModels
{
    public class ProductInfoViewModel
    {
        public IEnumerable<Kupac> Kupci { get; set; }
        public Proizvod Proizvod { get; set; }
        public Potkategorija Potkategorija { get; set; }
        public Kategorija Kategorija { get; set; }
    }
}