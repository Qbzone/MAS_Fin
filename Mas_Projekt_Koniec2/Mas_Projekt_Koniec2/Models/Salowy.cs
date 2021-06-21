using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas_Projekt_Koniec2.Models
{
    public class Salowy : Pracownik
    {
        public bool CzyPelniFunkcjePomocnicza { get; set; }

        public Salowy()
        {

        }

        public Salowy(bool czyPelniFukcjePomocnicza)
        {
            this.CzyPelniFunkcjePomocnicza = czyPelniFukcjePomocnicza;
        }
    }
}
