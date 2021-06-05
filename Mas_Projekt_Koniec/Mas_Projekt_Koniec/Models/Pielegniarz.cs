﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas_Projekt_Koniec.Models
{
    public class Pielegniarz : Pracownik
    {
        [Required]
        [MaxLength(25)]
        public string Specjalizacja { get; set; }

        public ICollection<ZespolOperacyjny> Czlonek { get; set; }

        public Pielegniarz()
        {

        }

        public Pielegniarz(string specjalizacja)
        {
            this.Specjalizacja = specjalizacja;
        }

        public void AddCzlonek(ZespolOperacyjny zespol)
        {
            if (!this.Czlonek.Contains(zespol))
            {
                this.Czlonek.Add(zespol);
                zespol.AddPielegniarze(this);
            }
        }
    }
}
