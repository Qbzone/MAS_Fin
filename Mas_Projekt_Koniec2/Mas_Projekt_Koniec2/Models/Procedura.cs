﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas_Projekt_Koniec2.Models
{
    public class Procedura
    {
        public long Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string NazwaProcedura { get; set; }
        [Required]
        public int KosztProcedura { get; set; }
        [Required]
        public bool CzyPotrzebnyZespolOperacyjny { get; set; }
        [Required]
        public bool CzyProceduraInwazyjna { get; set; }

        public ICollection<PakietMedycznyProcedura> PakietyMedyczne { get; set; }
        public ICollection<Wizyta> Wizyty { get; set; }
        public ICollection<HospitalizacjaProcedura> Hospitalizacje { get; set; }
        public ICollection<Doktor> Doktorzy { get; set; }

        public Procedura()
        {

        }

        public Procedura(string nazwaProcedury, int kosztWykonania, bool czyPotrzebnyZO, bool czyProceduraI)
        {
            this.NazwaProcedura = nazwaProcedury;
            this.KosztProcedura = kosztWykonania;
            this.CzyPotrzebnyZespolOperacyjny = czyPotrzebnyZO;
            this.CzyProceduraInwazyjna = czyProceduraI;
            this.Doktorzy = new List<Doktor>();
        }
    }
}
