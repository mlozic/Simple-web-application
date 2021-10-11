using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektniZadatak.Views.ViewModels
{
    public class SubcategoriesAndCategoriesDataViewModel
    {
        public Potkategorija Potkategorija { get; set; }
        public Kategorija Kategorija { get; set; }
        public IEnumerable<Kategorija> Kategorije { get; set; }
        public string Naslov { get; set; }
    }
}