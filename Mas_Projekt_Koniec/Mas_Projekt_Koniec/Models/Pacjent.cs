using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas_Projekt_Koniec.Models
{
    public class Pacjent
    {
        public long Id { get; set; }
        public bool UbezpiecznieZdrowotne { get; set; }
        
        public Osoba osoba { get; set; }
        public PakietMedyczny PakietMedyczny { get; set; }
        public ICollection<Wizyta> Wizyty { get; set; }
        public ICollection<Hospitalizacja> Hospitalizacje { get; set; }

        public Pacjent()
        {

        }

        public Pacjent(Osoba osoba, bool ubezpieczenieZdrowotne)
        {
            this.osoba = osoba;
            this.Id = osoba.Id;
            this.UbezpiecznieZdrowotne = ubezpieczenieZdrowotne;
        }

        public Pacjent(Osoba osoba, bool ubezpieczenieZdrowotne, PakietMedyczny pakietMedyczny)
        {
            this.osoba = osoba;
            this.Id = osoba.Id;
            this.UbezpiecznieZdrowotne = ubezpieczenieZdrowotne;
            this.PakietMedyczny = pakietMedyczny;
        }

        public void AddPakietMedyczny(PakietMedyczny pakietMedyczny)
        {
            this.PakietMedyczny = pakietMedyczny;
        }
    }
}
