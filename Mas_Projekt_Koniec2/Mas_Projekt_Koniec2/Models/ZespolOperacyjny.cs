using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas_Projekt_Koniec2.Models
{
    public class ZespolOperacyjny
    {
        public long Id { get; set; }

        [Required]
        public ICollection<Pracownik> Pracownicy { get; set; }
        public ICollection<Hospitalizacja> Hospitalizacje { get; set; }

        public ZespolOperacyjny()
        {

        }

        public ZespolOperacyjny(ICollection<Pracownik> pracownicy)
        {
            this.Pracownicy = pracownicy;
        }
    }
}
