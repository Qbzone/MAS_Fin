﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas_Projekt_Koniec.Models
{
    public class Procedura
    {
        public long Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string NazwaProcedury { get; set; }
        [Required]
        public int KosztWykonania { get; set; }
        [Required]
        public bool CzyPotrzebnyZespolOperacyjny { get; set; }
        [Required]
        public bool CzyProceduraInwazyjna { get; set; }

        public ICollection<PakietMedyczny> PakietyMedyczne { get; set; }
        public ICollection<Wizyta> Wizyty { get; set; }
        public ICollection<Hospitalizacja> Hospitalizacje { get; set; }

        public Procedura()
        {

        }

        public Procedura(string nazwaProcedury, int kosztWykonania, bool czyPotrzebnyZO, bool czyProceduraI)
        {
            this.NazwaProcedury = nazwaProcedury;
            this.KosztWykonania = kosztWykonania;
            this.CzyPotrzebnyZespolOperacyjny = czyPotrzebnyZO;
            this.CzyProceduraInwazyjna = czyProceduraI;
        }
    }
}
