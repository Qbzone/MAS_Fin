﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas_Projekt_Koniec2.Models
{
    public class Pielegniarz : Pracownik
    {
        [Required]
        [MaxLength(25)]
        public string SpecjalizacjaPielegniarz { get; set; }

        public Pielegniarz()
        {

        }

        public Pielegniarz(string specjalizacja)
        {
            this.SpecjalizacjaPielegniarz = specjalizacja;
        }
    }
}
