using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas_Projekt_Koniec2.Models
{
    public class Salowy : Pracownik
    {
        public ZespolOperacyjny Czlonek { get; set; }
        public long ZespolOperacyjnyId { get; set; }

        public Salowy()
        {

        }

        /*public void AddCzlonek(ZespolOperacyjny zespol)
        {
            if (!this.Czlonek.Contains(zespol))
            {
                this.Czlonek.Add(zespol);
                zespol.AddSalowi(this);
            }
        }*/
    }
}
