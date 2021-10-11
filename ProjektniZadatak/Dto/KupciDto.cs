using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjektniZadatak.Dto
{
    public class KupciDto
    {
        public int IDKupac { get; set; }

        [Required(ErrorMessage = "Ime je obavezno!")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Prezime je obavezno!")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "E-mail je obavezan!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Unesite ispravnu E-mail adresu!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Unesite broj telefona!")]
        public string Telefon { get; set; }

        [Required(ErrorMessage = "Polje grad je obavezno!")]
        [Display(Name = "Grad")]
        public Nullable<int> GradID { get; set; }
    }
}