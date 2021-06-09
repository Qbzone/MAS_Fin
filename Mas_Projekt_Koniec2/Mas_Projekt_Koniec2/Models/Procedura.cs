using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas_Projekt_Koniec2.Models
{
    public class Procedura
    {
        public long Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nazwa { get; set; }
        [Required]
        public int Koszt { get; set; }
        [Required]
        public bool CzyPotrzebnyZespolOperacyjny { get; set; }
        [Required]
        public bool CzyProceduraInwazyjna { get; set; }

        public ICollection<PakietMedycznyProcedura> PakietyMedyczne { get; set; }
        public ICollection<Wizyta> Wizyty { get; set; }
        public ICollection<HospitalizacjaProcedura> Hospitalizacje { get; set; }

        public Procedura()
        {

        }

        public Procedura(string nazwaProcedury, int kosztWykonania, bool czyPotrzebnyZO, bool czyProceduraI)
        {
            this.Nazwa = nazwaProcedury;
            this.Koszt = kosztWykonania;
            this.CzyPotrzebnyZespolOperacyjny = czyPotrzebnyZO;
            this.CzyProceduraInwazyjna = czyProceduraI;
        }

        /*public void AddPakietMedyczny(PakietMedyczny pakietMedyczny)
        {
            if (!PakietyMedyczne.Contains(pakietMedyczny))
            {
                this.PakietyMedyczne.Add(pakietMedyczny);
                pakietMedyczny.AddProcedura(this);
            }
        }

        public void AddWizyta(Wizyta wizyta)
        {
            if (!Wizyty.Contains(wizyta))
            {
                this.Wizyty.Add(wizyta);
                wizyta.AddProcedura(this);
            }
        }

        public void AddHospitalizacja(Hospitalizacja hospitalizacja)
        {
            if (!Hospitalizacje.Contains(hospitalizacja))
            {
                this.Hospitalizacje.Add(hospitalizacja);
                hospitalizacja.AddProcedura(this);
            }
        }*/
    }
}
