using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjektniZadatak.Dto
{
    public class PotkategorijeDto
    {
        public int IDPotkategorija { get; set; }

        [Required(ErrorMessage = "Polje kategorija je obavezno!")]
        [Display(Name = "Kategorija")]
        public int KategorijaID { get; set; }

        [Required(ErrorMessage = "Naziv potkategorije je obavezan!")]
        [Display(Name = "Naziv")]
        public string NazivPotkategorije { get; set; }
    }
}