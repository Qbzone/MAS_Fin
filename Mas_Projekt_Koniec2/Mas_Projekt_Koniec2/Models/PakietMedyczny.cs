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
        public string NazwaPakiet { get; set; }
        public ICollection<Pacjent> Pacjenci { get; set; }
        public ICollection<PakietMedycznyProcedura> Procedury { get; set; }

        public PakietMedyczny()
        {

        }

        public PakietMedyczny(string nazwaPakietu)
        {
            this.NazwaPakiet = nazwaPakietu;
        }
    }
}
