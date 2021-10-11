using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjektniZadatak.Dto
{
    public class ProizvodiDto
    {
        public int IDProizvod { get; set; }

        [Required(ErrorMessage = "Naziv je obavezan!")]
        public string Naziv { get; set; }

        [Required(ErrorMessage = "Broj proizvoda je obavezan!")]
        public string BrojProizvoda { get; set; }

        [Required(ErrorMessage = "Boja je obavezna!")]
        public string Boja { get; set; }

        [Required(ErrorMessage = "Podatak o minimalnoj količini na skladištu je obavezan!")]
        public short MinimalnaKolicinaNaSkladistu { get; set; }

        [Required(ErrorMessage = "Cijena bez PDV-a je obavezan podatak!")]
        public decimal CijenaBezPDV { get; set; }

        [Required(ErrorMessage = "Potkategorija je obavezan podatak!")]
        [Display(Name = "Potkategorija")]
        public Nullable<int> PotkategorijaID { get; set; }
    }
}