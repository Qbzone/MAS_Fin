using Mas_Final_Project.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;

namespace Mas_Final_Project.Services
{
    internal class ProcedureService
    {
        private readonly MasDBContext _context = new();

        public void UpdateDbContext()
        {
            _context.SaveChanges();
        }

        /* The GetProcedures method returns an ObservableCollection of all procedures in the system 
         * that do not require an operational team to perform them. */
        public ObservableCollection<Procedure> GetProcedures()
        {
            return new ObservableCollection<Procedure>(
                _context.Procedure
                .Where(zespol => zespol.IsOperationalTeamNeeded == false)
                .OrderBy(n => n.ProcedureName)
                    .ThenBy(k => k.ProcedureCost)
                .ToList());
        }

        /* The GetProcedures method returns an ObservableCollection of all procedures in the system 
         * to which the doctor with the passed Id has rights. */
        public ObservableCollection<Procedure> GetProcedures(Doctor doctorId)
        {
            return new ObservableCollection<Procedure>(
                _context.Procedure
                .Include(dp => dp.Doctors)
                .Where(e => e.Doctors.Any(ee => ee == doctorId))
                .OrderBy(n => n.ProcedureName)
                .ToList());
        }

        /* The GetProceduresByName method is used to filter procedures by their name. 
         * This method takes a single attribute of the string type procedureName, based on the given attribute 
         * only procedures whose name corresponds to the one passed in and do not require an operational team to carry them out will be returned. */
        public ObservableCollection<Procedure> GetProceduresByName(string procedureName)
        {
            return new ObservableCollection<Procedure>(
                _context.Procedure
                .Where(nazwa => nazwa.ProcedureName.Contains(procedureName) && nazwa.IsOperationalTeamNeeded == false)
                .OrderBy(n => n.ProcedureName)
                    .ThenBy(k => k.ProcedureCost)
                .ToList());
        }
    }
}