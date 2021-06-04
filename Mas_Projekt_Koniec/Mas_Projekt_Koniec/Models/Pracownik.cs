using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas_Projekt_Koniec.Models
{
    public class Pracownik
    {
        public long Id { get; set; }
        [Required]
        public int Pensja { get; set; }

        public Osoba Osoba { get; set; }

        public Pracownik()
        {

        }

        public Pracownik(Osoba Osoba, int Pensja)
        {
            this.Osoba = Osoba;
            this.Id = Osoba.Id;
            this.Pensja = Pensja;
        }
    }
}
