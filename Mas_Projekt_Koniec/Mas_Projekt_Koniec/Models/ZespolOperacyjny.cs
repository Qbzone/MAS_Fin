﻿using System;
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
        public ICollection<Hospitalizacja> Hospitalizacje { get; set; }

        public ZespolOperacyjny()
        {

        }

        public ZespolOperacyjny(Doktor lider, ICollection<Doktor> doktorzy, ICollection<Pielegniarz> pielegniarze, ICollection<Salowy> salowi)
        {
            if (doktorzy.Contains(lider))
            {
                foreach (Doktor d in doktorzy)
                {
                    AddDoktorzy(d);
                }
                AddLider(lider);
                foreach (Pielegniarz p in pielegniarze)
                {
                    AddPielegniarze(p);
                }
                foreach (Salowy s in salowi)
                {
                    AddSalowi(s);
                }
            }
        }

        public void AddLider(Doktor doktor)
        {
            if (this.Doktorzy.Contains(doktor) && Lider == null && doktor.GetLider() == null)
            {
                this.Lider = doktor;
                doktor.AddLider(this);
            }
        }

        public Doktor GetLider()
        {
            return this.Lider;
        }

        public void AddDoktorzy(Doktor doktor)
        {
            if (!this.Doktorzy.Contains(doktor))
            {
                this.Doktorzy.Add(doktor);
                doktor.AddCzlonek(this);
            }
        }

        public void AddPielegniarze(Pielegniarz pielegniarz)
        {
            if (!this.Pielegniarze.Contains(pielegniarz))
            {
                this.Pielegniarze.Add(pielegniarz);
                pielegniarz.AddCzlonek(this);
            }
        }

        public void AddSalowi(Salowy salowy)
        {
            if (!this.Salowi.Contains(salowy))
            {
                this.Salowi.Add(salowy);
                salowy.AddCzlonek(this);
            }
        }

        public void AddHospitalizacja(Hospitalizacja hospitalizacja)
        {
            if (!this.Hospitalizacje.Contains(hospitalizacja))
            {
                this.Hospitalizacje.Add(hospitalizacja);
            }
        }
    }
}
