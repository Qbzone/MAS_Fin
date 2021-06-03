using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas_Projekt_Koniec.Models
{
    public class ZespolOperacyjny
    {
        public long Id { get; set; }

        public Doktor Lider { get; set; }
        public ICollection<Doktor> Doktorzy { get; set; }
        public ICollection<Pielegniarz> Pielegniarze { get; set; }
        public ICollection<Salowy> Salowi { get; set; }

        public ZespolOperacyjny()
        {

        }

        public ZespolOperacyjny(Doktor lider, ICollection<Doktor> doktorzy, ICollection<Pielegniarz> pielegniarze, ICollection<Salowy> salowi)
        {
            if (doktorzy.Contains(lider))
            {
                this.Lider = lider;
                this.Doktorzy = doktorzy;
                this.Pielegniarze = pielegniarze;
                this.Salowi = salowi;
            }
        }
    }
}
