using Mas_Final_Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Mas_Final_Project.Services
{
    internal class VisitService
    {
        private readonly MasDBContext _context = new();

        /* The AddVisit method accepts the created object of the Visit class. 
         * It is used to add a visit to the database. */
        public void AddVisit(Visit visit)
        {
            _context.Add(visit);
            _context.SaveChanges();
        }

        /* The GetVisits method returns an ObservableCollection of all visits in the system 
         * whose due date is greater than or equal to that of today. */
        public ObservableCollection<Visit> GetVisits() => new ObservableCollection<Visit>(
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

        /* The GetVisit method returns an ObservableCollection of all visits in the system 
         * whose appointment date is greater than or equal to today's date, and the patient Id corresponds to the passed Id. */
        public ObservableCollection<Visit> GetVisits(Patient selectedPatient) => new ObservableCollection<Visit>(
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

        /* The GetVisit method returns an ObservableCollection of all visits in the system 
         * whose date of appointment is greater than or equal to that of today, and the Doctor's Id corresponds to the passed Id. */
        public ObservableCollection<Visit> GetVisits(Doctor selectedDoctor) => new ObservableCollection<Visit>(
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

        /* The GetVisitsView method is used to check whether a patient has any appointments registered before displaying their appointment schedule. */
        public bool GetVisitsView(Patient selectedPatient) => _context.Visit
                .Where(e => e.VisitStart.Date >= DateTime.Today && e.PatientId == selectedPatient.Id)
                .Any();

        /* The GetVisitsView method is used to check whether a doctor has any visits registered before displaying his/her appointment book. */
        public bool GetVisitsView(Doctor selectedDoctor) => _context.Visit
                .Where(e => e.VisitStart.Date >= DateTime.Today && e.DoctorId == selectedDoctor.Id)
                .Any();

        /* The GetDayTerms method returns an ObservableCollection of temporary objects of the appointment class, 
         * which are created based on the selected objects and the date for which the patient wants to enrol, 
         * appointments that the selected doctor has busy will not be created. */
        public ObservableCollection<Visit> GetDayTerms(Doctor selectedDoctor,
                                                       Patient selectedPatient,
                                                       Procedure selectedProcedure,
                                                       DateTime pickedDate)
        {
            ObservableCollection<Visit> tmpVisits = new();
            DateTime start = pickedDate.AddHours(8);

            for (int i = 0; i < 16; i++)
            {
                if (!GetDoctorVisit(start, selectedDoctor.Id))
                {
                    DateTime end = start.AddMinutes(29);
                    Visit tmpTerm = new()
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

        /* The GetDoctorVisit method is used to find out whether a doctor already has an appointment scheduled for a given date, 
         * if yes the appointment will not be displayed. */
        public bool GetDoctorVisit(DateTime visitStart, long id) => _context.Visit
                .Where(visit => visit.VisitStart == visitStart && visit.DoctorId == id)
                .Any();
    }
}