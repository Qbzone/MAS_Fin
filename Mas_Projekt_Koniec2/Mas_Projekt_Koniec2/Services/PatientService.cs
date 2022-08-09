using Mas_Final_Project.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;

namespace Mas_Final_Project.Services
{
    internal class PatientService
    {
        private readonly MasDBContext _context = new();

        public void UpdateDbContext()
        {
            _context.SaveChanges();
        }

        /* The GetPatients method returns an ObservableCollection of all patients in the system. */
        public ObservableCollection<Patient> GetPatients() => new ObservableCollection<Patient>(
                _context.Patient
                .Include(o => o.Person)
                .Include(pm => pm.MedicalPackage)
                .OrderBy(n => n.Person.LastName)
                    .ThenBy(i => i.Person.FirstName)
                .ToList());

        /* The GetPatientsByPeselNumber method is used to filter patients by their pesel number. 
         * This method takes one attribute of the string type peselNumber, based on the given attribute only patients whose 
         * pesel number corresponds to the one passed in will be returned. */
        public ObservableCollection<Patient> GetPatientsByPeselNumber(string peselNumber) => new ObservableCollection<Patient>(
                _context.Patient
                .Include(o => o.Person)
                .Include(pm => pm.MedicalPackage)
                .Where(pesel => pesel.Person.PeselNumber.Contains(peselNumber))
                .OrderBy(n => n.Person.LastName)
                    .ThenBy(i => i.Person.FirstName)
                .ToList());
    }
}