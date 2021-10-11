using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjektniZadatak.Dto
{
    public class GradoviDto
    {
        public int IDGrad { get; set; }

        [Required(ErrorMessage = "Naziv gada je obavezan!")]
        public string Naziv { get; set; }

        [Required(ErrorMessage = "Odaberite Drzavu!")]
        [Display(Name = "Drzava")]
        public Nullable<int> DrzavaID { get; set; }
    }
}