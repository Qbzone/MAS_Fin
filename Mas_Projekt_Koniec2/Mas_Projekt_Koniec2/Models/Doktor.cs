using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas_Projekt_Koniec2.Models
{
    public class Doktor : Pracownik
    {
        [Required]
        [MaxLength(25)]
        public string SpecjalizacjaDoktor { get; set; }
        public ICollection<Wizyta> Wizyty { get; set; }

        public Doktor()
        {

        }

        public Doktor(string specjalizacja)
        {
            this.SpecjalizacjaDoktor = specjalizacja;
        }

        [NotMapped]
        public string DoktorImieNazwisko
        {
            get { return Osoba.GetImieNazwisko(); }
        }
    }
}
