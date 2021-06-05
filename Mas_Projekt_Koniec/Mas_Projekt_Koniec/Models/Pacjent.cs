using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas_Projekt_Koniec.Models
{
    public class Pacjent
    {
        public long Id { get; set; }
        [Required]
        public bool UbezpiecznieZdrowotne { get; set; }

        public Osoba osoba { get; set; }
        public PakietMedyczny PakietMedyczny { get; set; }
        public ICollection<Wizyta> Wizyty { get; set; }
        public ICollection<Hospitalizacja> Hospitalizacja { get; set; }

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
            AddPakietMedyczny(pakietMedyczny);
        }

        public void AddPakietMedyczny(PakietMedyczny pakietMedyczny)
        {
            if (this.PakietMedyczny == null)
            {
                this.PakietMedyczny = pakietMedyczny;
                pakietMedyczny.AddPacjent(this);
            }
        }

        public void AddWizyty(Wizyta wizyta)
        {
            if (!this.Wizyty.Contains(wizyta))
            {
                this.Wizyty.Add(wizyta);
            }
        }

        public void AddHospitalizacja(Hospitalizacja hospitalizacja)
        {
            if (!this.Hospitalizacja.Contains(hospitalizacja))
            {
                this.Hospitalizacja.Add(hospitalizacja);
            }
        }
    }
}
