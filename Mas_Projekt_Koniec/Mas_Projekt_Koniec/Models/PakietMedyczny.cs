using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas_Projekt_Koniec.Models
{
    public class PakietMedyczny
    {
        public long Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string NazwaPakietu { get; set; }

        ICollection<Pacjent> Pacjenci { get; set; }
        ICollection<Procedura> Procedury { get; set; }

        public PakietMedyczny()
        {

        }

        public PakietMedyczny(string nazwaPakietu, ICollection<Pacjent> pacjenci, ICollection<Procedura> procedury)
        {
            if (procedury != null)
            {
                this.NazwaPakietu = nazwaPakietu;
                this.Pacjenci = pacjenci;
                this.Procedury = procedury;
            }
        }
    }
}
