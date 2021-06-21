using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas_Projekt_Koniec2.Models
{
    public class PakietMedycznyProcedura
    {
        [Required]
        public DateTime DataPrzypisania { get; set; }
        [Required]
        public PakietMedyczny PakietMedyczny { get; set; }
        public long PakietMedycznyId { get; set; }
        [Required]
        public Procedura Procedura { get; set; }
        public long ProceduraId { get; set; }

        public PakietMedycznyProcedura()
        {

        }

        public PakietMedycznyProcedura(PakietMedyczny pakietMedyczny, Procedura procedura)
        {
            this.PakietMedycznyId = pakietMedyczny.Id;
            this.ProceduraId = procedura.Id;
        }
    }
}
