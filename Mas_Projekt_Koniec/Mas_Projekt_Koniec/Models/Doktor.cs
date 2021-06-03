using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas_Projekt_Koniec.Models
{
    public class Doktor : Pracownik
    {
        public string Specjalizacja { get; set; }

        public ZespolOperacyjny Lider { get; set; }
        public ICollection<ZespolOperacyjny> Czlonek { get; set; }
        public ICollection<Wizyta> Wizyty { get; set; }

        public Doktor()
        {

        }

        public Doktor(string specjalizacja)
        {
            this.Specjalizacja = specjalizacja;
        }

        public void AddLider(ZespolOperacyjny zespol)
        {
            this.Lider = zespol;
        }
    }
}
