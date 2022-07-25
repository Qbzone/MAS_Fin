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
    class DoctorService
    {
        private readonly MasDBContext _context = new MasDBContext();

        public void UpdateDbContext()
        {
            _context.SaveChanges();
        }

        //Metoda GetDoktors zwraca ObservableCollection wszystkich doktorów w systemie.
        public ObservableCollection<Doctor> GetDoctors()
        {
            return new ObservableCollection<Doctor>(
                _context.Doctor
                .Include(p => p.Person)
                    .ThenInclude(e => e.Employee)
                .Include(dp => dp.Entitlements)
                .OrderBy(n => n.Person.LastName)
                    .ThenBy(i => i.Person.FirstName)
                .ToList());
        }

        //Metoda GetDoktors zwraca ObservableCollection doktorów. Metoda przyjmuje dwa atrybuty long ProceduraId i string Pesel. Zwróceni
        //zostaną wszyscy dkotorzy, którzy mają uprawnienia do wykonywania danego badania. Pesel służy do sprawdzenia, czy pacjent sam nie jest
        //doktorem w systemie, jeśli jest nie można go zapisać do niego samego
        public ObservableCollection<Doctor> GetDoctors(long procedureId, string peselNumber)
        {
            return new ObservableCollection<Doctor>(
                _context.Doctor
                .Include(p => p.Person)
                    .ThenInclude(e => e.Employee)
                .Include(dp => dp.Entitlements)
                .Where(e => !e.Person.PeselNumber.Equals(peselNumber) && e.Entitlements.Any(ee => ee.Id == procedureId))
                .OrderBy(n => n.Person.LastName)
                    .ThenBy(i => i.Person.FirstName)
                .ToList());
        }

        //Metoda GetDoktorsByNazwisko służy do przefiltrowania doktorów względem ich nazwiska. Metoda ta przyjmuje jeden atrybut typu string
        //Nazwisko, na podstawie podanego atrybutu zwróceni zostaną tylko doktorzy, których nazwisko odpowiada temu przekazanemu.
        public ObservableCollection<Doctor> GetDoctorsBySecondName(string secondName)
        {
            return new ObservableCollection<Doctor>(
                _context.Doctor
                .Include(o => o.Person)
                .Where(pesel => pesel.Person.LastName.Contains(secondName))
                .OrderBy(i => i.Person.LastName)
                    .ThenBy(i => i.Person.FirstName)
                .ToList());
        }

        //Metoda GetDoktorsSpecjalizacja służy do sprawdzenia czy w systemie istnieją doktorzy, którzy mogą wykonać daną procedurę.
        //Metoda przyjmuje jeden atrybut typu string Specjalizacja, jeśli specjalizacja ma wartość "Dowolna" to każdy doktor może ją wykonać,
        //jeśli wartość jest inna musi istnieć conajmniej jeden doktor o danej specjalizacji, żeby móc przejść do wybory doktora.
        public bool GetDoctorsSpecialization(long procedureId)
        {
            return _context.Doctor
                .Where(e => e.Entitlements.Any(ee => ee.Id == procedureId))
                .Count() > 0;
        }
    }
}