﻿using Mas_Projekt_Koniec2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas_Projekt_Koniec2.Services
{
    class WizytaService
    {
        private readonly MasDBContext _context = new MasDBContext();

        //Metoda AddWizyta przyjmuje utworzony obiekt klasy Wizyta. Służy ona do dodania wizyty do bazy danych.
        public void AddWizyta(Wizyta wizyta)
        {
            _context.Add(wizyta);
            _context.SaveChanges();
        }

        //Metoda GetWizytas zwraca ObservableCollection wszystkich wizyt w systemie, których date terminu przeprowadzenia
        //jest większa lub równa tej z dnia dzisiejszego.
        public ObservableCollection<Wizyta> GetWizytas()
        {
            return new ObservableCollection<Wizyta>(
                _context.Wizyta
                .Include(p => p.Pacjent)
                    .ThenInclude(o => o.Osoba)
                .Include(d => d.Doktor)
                    .ThenInclude(o => o.Osoba)
                .Include(pr => pr.Procedura)
                .Where(e => e.PoczatekWizyty.Date >= DateTime.Today)
                .OrderBy(pw => pw.PoczatekWizyty)
                    .ThenBy(d => d.Doktor.Osoba.Nazwisko)
                        .ThenBy(p => p.Pacjent.Osoba.Nazwisko)
                .ToList());
        }

        //Metoda GetDayTermins zwraca ObservableCollection tymczasowych obiektów klasy wizyta, ktore są tworzone na podstawie wybranych obiektów
        //i daty, na którą pacjent chce się zapisać, terminu, które wybrany doktor ma zajętę nie zostaną utworzone.
        public ObservableCollection<Wizyta> GetDayTermins(Doktor selectedDoktor, Pacjent selectedPacjent, Procedura selectedProcedura, DateTime pickedDate)
        {
            ObservableCollection<Wizyta> tmpWizytas = new ObservableCollection<Wizyta>();
            DateTime Start = pickedDate.AddHours(8);
            for (int i = 0; i < 16; i++)
            {
                if (!GetDoktorWizyta(Start, selectedDoktor.Id))
                {
                    DateTime Koniec = Start.AddMinutes(29);
                    Wizyta tmpTermin = new Wizyta() { PoczatekWizyty = Start, KoniecWizyty = Koniec, StatusWizyta = Wizyta.StatusWizyty.CREATED, DoktorId = selectedDoktor.Id, PacjentId = selectedPacjent.Id, ProceduraId = selectedProcedura.Id };
                    tmpWizytas.Add(tmpTermin);
                }
                Start = Start.AddMinutes(30);
            }

            return tmpWizytas;
        }

        //Metoda GetDoktorWizyta służy do znalezienia czy dany doktor ma już zaplanowaną wizytę na dany termin, jeśli count > 0
        //dany termin nie zostanie wyświetlony.
        public bool GetDoktorWizyta(DateTime poczatekWizyty, long Id)
        {
            return _context.Wizyta
                .Where(wizyta => wizyta.PoczatekWizyty == poczatekWizyty && wizyta.DoktorId == Id)
                .Count() > 0;
        }
    }
}
