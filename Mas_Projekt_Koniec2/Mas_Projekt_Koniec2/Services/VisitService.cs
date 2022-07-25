using Mas_Final_Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas_Final_Project.Services
{
    class VisitService
    {
        private readonly MasDBContext _context = new MasDBContext();

        //Metoda AddWizyta przyjmuje utworzony obiekt klasy Wizyta. Służy ona do dodania wizyty do bazy danych.
        public void AddVisit(Visit visit)
        {
            _context.Add(visit);
            _context.SaveChanges();
        }

        //Metoda GetWizytas zwraca ObservableCollection wszystkich wizyt w systemie, których data terminu przeprowadzenia
        //jest większa lub równa tej z dnia dzisiejszego.
        public ObservableCollection<Visit> GetVisits()
        {
            return new ObservableCollection<Visit>(
                _context.Visit
                .Include(p => p.Patient)
                    .ThenInclude(o => o.Person)
                .Include(d => d.Doctor)
                    .ThenInclude(o => o.Person)
                .Include(pr => pr.Procedure)
                .Where(e => e.VisitStart.Date >= DateTime.Today)
                .OrderBy(pw => pw.VisitStart)
                    .ThenBy(d => d.Doctor.Person.LastName)
                        .ThenBy(p => p.Patient.Person.LastName)
                .ToList());
        }

        //Metoda GetWizyta zwraca ObservableCollection wszystkich wizyt w systemie, których data terminu przeprowadzenia
        //jest większa lub równa tej z dnia dzisiejszego, oraz Id pacjenta odpowiada przekazanemu Id
        public ObservableCollection<Visit> GetVisits(Patient selectedPatient)
        {
            return new ObservableCollection<Visit>(
                _context.Visit
                .Include(p => p.Patient)
                    .ThenInclude(o => o.Person)
                .Include(d => d.Doctor)
                    .ThenInclude(o => o.Person)
                .Include(pr => pr.Procedure)
                .Where(e => e.VisitStart.Date >= DateTime.Today && e.PatientId == selectedPatient.Id)
                .OrderBy(pw => pw.VisitStart)
                    .ThenBy(d => d.Doctor.Person.LastName)
                        .ThenBy(p => p.Patient.Person.LastName)
                .ToList());
        }

        //Metoda GetWizyta zwraca ObservableCollection wszystkich wizyt w systemie, których data terminu przeprowadzenia
        //jest większa lub równa tej z dnia dzisiejszego, oraz Id doktora odpowiada przekazanemu Id
        public ObservableCollection<Visit> GetVisits(Doctor selectedDoctor)
        {
            return new ObservableCollection<Visit>(
                _context.Visit
                .Include(p => p.Patient)
                    .ThenInclude(o => o.Person)
                .Include(d => d.Doctor)
                    .ThenInclude(o => o.Person)
                .Include(pr => pr.Procedure)
                .Where(e => e.VisitStart.Date >= DateTime.Today && e.DoctorId == selectedDoctor.Id)
                .OrderBy(pw => pw.VisitStart)
                    .ThenBy(d => d.Doctor.Person.LastName)
                        .ThenBy(p => p.Patient.Person.LastName)
                .ToList());
        }

        //Metoda GetWizytasView służy do sprawdzenia, czy dany pacjent ma zarejestrowane jakieś wizyty
        //przed wyświetleniem jego harmonogramu wizyt
        public bool GetVisitsView(Patient selectedPatient)
        {
            return _context.Visit
                .Where(e => e.VisitStart.Date >= DateTime.Today && e.PatientId == selectedPatient.Id)
                .Count() > 0;
        }

        //Metoda GetWizytasView służy do sprawdzenia, czy dany doktor ma zarejestrowane jakieś wiyty 
        //przed wyświetleniem jego harmonogramu wizyt
        public bool GetVisitsView(Doctor selectedDoctor)
        {
            return _context.Visit
                .Where(e => e.VisitStart.Date >= DateTime.Today && e.DoctorId == selectedDoctor.Id)
                .Count() > 0;
        }

        //Metoda GetDayTermins zwraca ObservableCollection tymczasowych obiektów klasy wizyta, ktore są tworzone na podstawie wybranych obiektów
        //i daty, na którą pacjent chce się zapisać, terminu, które wybrany doktor ma zajętę nie zostaną utworzone.
        public ObservableCollection<Visit> GetDayTerms(Doctor selectedDoctor, Patient selectedPatient, Procedure selectedProcedure, DateTime pickedDate)
        {
            ObservableCollection<Visit> tmpVisits = new ObservableCollection<Visit>();
            DateTime start = pickedDate.AddHours(8);

            for (int i = 0; i < 16; i++)
            {
                if (!GetDoctorVisit(start, selectedDoctor.Id))
                {
                    DateTime end = start.AddMinutes(29);
                    Visit tmpTerm = new Visit()
                    {
                        VisitStart = start,
                        VisitEnd = end,
                        VisitState = Visit.VisitStatus.CREATED,
                        DoctorId = selectedDoctor.Id,
                        PatientId = selectedPatient.Id,
                        ProcedureId = selectedProcedure.Id
                    };

                    tmpVisits.Add(tmpTerm);
                }

                start = start.AddMinutes(30);
            }

            return tmpVisits;
        }

        //Metoda GetDoktorWizyta służy do znalezienia czy dany doktor ma już zaplanowaną wizytę na dany termin, jeśli count > 0
        //dany termin nie zostanie wyświetlony.
        public bool GetDoctorVisit(DateTime visitStart, long id)
        {
            return _context.Visit
                .Where(visit => visit.VisitStart == visitStart && visit.DoctorId == id)
                .Count() > 0;
        }
    }
}