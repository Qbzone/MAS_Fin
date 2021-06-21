using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas_Projekt_Koniec2.Models
{
    public class Recepcjonista : Pracownik
    {
        [Required]
        [MaxLength(25)]
        public string JezykDodatkowy { get; set; }

        public Recepcjonista()
        {

        }

        public Recepcjonista(string jezykDodatkowy)
        {
            this.JezykDodatkowy = jezykDodatkowy;
        }
    }
}
