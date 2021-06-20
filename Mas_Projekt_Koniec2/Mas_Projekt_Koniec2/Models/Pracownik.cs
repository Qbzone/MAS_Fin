using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas_Projekt_Koniec2.Models
{
    public abstract class Pracownik
    {
        public long Id { get; set; }
        [Required]
        public int Pensja { get; set; }
        [Required]
        public Osoba Osoba { get; set; }
        public long OsobaId { get; set; }

        public Pracownik()
        {

        }

        public Pracownik(Osoba Osoba, int Pensja)
        {
            this.Osoba = Osoba;
            this.OsobaId = Osoba.Id;
            this.Pensja = Pensja;
        }
    }
}
