using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas_Projekt_Koniec.Models
{
    public class Pielegniarz : Pracownik
    {
        public string Specjalizacja { get; set; }

        public ICollection<ZespolOperacyjny> Czlonek { get; set; }

        public Pielegniarz()
        {

        }

        public Pielegniarz(string specjalizacja)
        {
            this.Specjalizacja = specjalizacja;
        }
    }
}
