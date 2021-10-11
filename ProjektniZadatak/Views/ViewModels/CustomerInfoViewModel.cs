using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektniZadatak.Views.ViewModels
{
    public class CustomerInfoViewModel
    {
        public IEnumerable<Racun> Racuni { get; set; }
        public Kupac Kupac { get; set; }
    }
}