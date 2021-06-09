using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas_Projekt_Koniec2.Models
{
    public class PakietMedyczny
    {
        public long Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string Nazwa { get; set; }
        public ICollection<Pacjent> Pacjenci { get; set; }
        public ICollection<PakietMedycznyProcedura> Procedury { get; set; }

        public PakietMedyczny()
        {

        }

        public PakietMedyczny(string nazwaPakietu)
        {
            this.Nazwa = nazwaPakietu;
        }

        /*public void AddPacjent(Pacjent pacjent)
        {
            if (!this.Pacjenci.Contains(pacjent))
            {
                this.Pacjenci.Add(pacjent);
                pacjent.AddPakietMedyczny(this);
            }
        }

        public void AddProcedura(Procedura procedura)
        {
            if (!this.Procedury.Contains(procedura))
            {
                this.Procedury.Add(procedura);
                procedura.AddPakietMedyczny(this);
            }
        }*/
    }
}
