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
    class PatientService
    {
        private readonly MasDBContext _context = new MasDBContext();

        public void UpdateDbContext()
        {
            _context.SaveChanges();
        }

        //Metoda GetPacjents zwraca ObservableCollection wszystkich pacjentów w systemie
        public ObservableCollection<Patient> GetPatients()
        {
            return new ObservableCollection<Patient>(
                _context.Patient
                .Include(o => o.Person)
                .Include(pm => pm.MedicalPackage)
                .OrderBy(n => n.Person.LastName)
                    .ThenBy(i => i.Person.FirstName)
                .ToList());
        }

        //Metoda GetPacjentByNazwisko służy do przefiltrowania pacjentów względem ich numeru pesel. Metoda ta przyjmuje jeden atrybut typu string
        //Pesel, na podstawie podanego atrybutu zwróceni zostaną tylko pacjenci, których numer pesel odpowiada temu przekazanemu.
        public ObservableCollection<Patient> GetPatientsByPeselNumber(string peselNumber)
        {
            return new ObservableCollection<Patient>(
                _context.Patient
                .Include(o => o.Person)
                .Include(pm => pm.MedicalPackage)
                .Where(pesel => pesel.Person.PeselNumber.Contains(peselNumber))
                .OrderBy(n => n.Person.LastName)
                    .ThenBy(i => i.Person.FirstName)
                .ToList());
        }
    }
}