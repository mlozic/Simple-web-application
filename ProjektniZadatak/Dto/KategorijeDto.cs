using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjektniZadatak.Dto
{
    public class KategorijeDto
    {
        public int IDKategorija { get; set; }

        [Required(ErrorMessage = "Naziv kategorije je obavezan!")]
        [Display(Name = "Naziv")]
        public string NazivKategorije { get; set; }
    }
}