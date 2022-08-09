using Mas_Final_Project.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;

namespace Mas_Final_Project.Services
{
    internal class DoctorService
    {
        private readonly MasDBContext _context = new();

        public void UpdateDbContext()
        {
            _context.SaveChanges();
        }

        /* Method GetDoctors returns an ObservableCollection of all the Doctors in the system. */
        public ObservableCollection<Doctor> GetDoctors() => new ObservableCollection<Doctor>(
                _context.Doctor
                .Include(p => p.Person)
                .Include(dp => dp.Entitlements)
                .OrderBy(n => n.Person.LastName)
                    .ThenBy(i => i.Person.FirstName)
                .ToList());

        /* The GetDoctors method returns an ObservableCollection of doctors. 
         * The method takes two attributes long procedureId and string peselNumber. 
         * It will return all the Doctors that have permission to perform the given examination. 
         * The pesel is used to check if the patient is not a doctor in the system itself, if it is the patient cannot be enrolled to it. */
        public ObservableCollection<Doctor> GetDoctors(long procedureId, string peselNumber) => new ObservableCollection<Doctor>(
                _context.Doctor
                .Include(p => p.Person)
                .Include(dp => dp.Entitlements)
                .Where(e => !e.Person.PeselNumber.Equals(peselNumber) && e.Entitlements.Any(ee => ee.Id == procedureId))
                .OrderBy(n => n.Person.LastName)
                    .ThenBy(i => i.Person.FirstName)
                .ToList());

        /* The GetDoctorsByLastName method is used to filter doctors by their last name. 
         * This method accepts a single attribute of string type LastName, based on the given attribute 
         * only doctors whose last name matches the one passed in will be returned. */
        public ObservableCollection<Doctor> GetDoctorsByLastName(string secondName) => new ObservableCollection<Doctor>(
                _context.Doctor
                .Include(o => o.Person)
                .Where(pesel => pesel.Person.LastName.Contains(secondName))
                .OrderBy(i => i.Person.LastName)
                    .ThenBy(i => i.Person.FirstName)
                .ToList());

        /* The GetDoctorsSpecialization method is used to check if there are any doctors in the system who can perform the procedure. 
         * The method takes one attribute of type long procedureId, if the specialization has the value "Any" then any doctor can perform it, 
         * if the value is different there must be at least one doctor of the specialization to be able to proceed to the doctor selection. */
        public bool GetDoctorsSpecialization(long procedureId) => _context.Doctor
                .Where(e => e.Entitlements.Any(ee => ee.Id == procedureId))
                .Any();
    }
}