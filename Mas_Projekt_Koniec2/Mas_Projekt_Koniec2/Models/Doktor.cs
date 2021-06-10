using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        //public ZespolOperacyjny Czlonek { get; set; }
        //public long ZespolOperacyjnyId { get; set; }
        public ICollection<Wizyta> Wizyty { get; set; }

        public Doktor()
        {

        }

        public Doktor(string specjalizacja)
        {
            this.SpecjalizacjaDoktor = specjalizacja;
        }

        /*public void AddLider(ZespolOperacyjny zespol)
        {
            if (zespol.Doktorzy.Contains(this) && this.Lider != null && zespol.GetLider() == null)
            {
                this.Lider = zespol;
            }
        }

        public ZespolOperacyjny GetLider()
        {
            return this.Lider;
        }

        public void AddCzlonek(ZespolOperacyjny zespol)
        {
            if (!this.Czlonek.Contains(zespol))
            {
                this.Czlonek.Add(zespol);
                zespol.AddDoktorzy(this);
            }
        }

        public void AddWizyty(Wizyta wizyta)
        {
            if (!this.Wizyty.Contains(wizyta))
            {
                this.Wizyty.Add(wizyta);
            }
        }*/
    }
}
