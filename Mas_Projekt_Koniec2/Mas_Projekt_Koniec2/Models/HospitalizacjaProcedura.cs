using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas_Projekt_Koniec2.Models
{
    public class HospitalizacjaProcedura
    {
        public long Id { get; set; }
        [Required]
        public Procedura Procedura { get; set; }
        public long ProceduraId { get; set; }
        public Hospitalizacja Hospitalizacja { get; set; }
        public long HospitalizacjaId { get; set; }
        public DateTime DataWykonania { get; set; }

        public HospitalizacjaProcedura()
        {

        }
        public HospitalizacjaProcedura(Procedura procedura, Hospitalizacja hospitalizacja, DateTime dataWykonania)
        {
            this.Procedura = procedura;
            this.ProceduraId = procedura.Id;
            this.Hospitalizacja = hospitalizacja;
            this.HospitalizacjaId = hospitalizacja.Id;
            this.DataWykonania = dataWykonania;
        }
    }
}
