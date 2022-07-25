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
    class ProcedureService
    {
        private readonly MasDBContext _context = new MasDBContext();

        public void UpdateDbContext()
        {
            _context.SaveChanges();
        }

        //Metoda GetProceduras zwraca ObservableCollection wszystkich procedur w systemie, które nie wymagają zespołu operacyjnego
        //do ich przeprowadzenia.
        public ObservableCollection<Procedure> GetProcedures()
        {
            return new ObservableCollection<Procedure>(
                _context.Procedure
                .Where(zespol => zespol.IsOperationalTeamNeeded == false)
                .OrderBy(n => n.ProcedureName)
                    .ThenBy(k => k.ProcedureCost)
                .ToList());
        }

        //Metoda GetProceduras zwraca ObservableCollection wszystkich procedur w systemie, do których ma uprawnienia doktor
        //o przekazanym Id.
        public ObservableCollection<Procedure> GetProcedures(Doctor doctorId)
        {
            return new ObservableCollection<Procedure>(
                _context.Procedure
                .Include(dp => dp.Doctors)
                .Where(e => e.Doctors.Any(ee => ee == doctorId))
                .OrderBy(n => n.ProcedureName)
                .ToList());
        }

        //Metoda GetProcedurasByNazwa służy do przefiltrowania procedur względem ich nazwy. Metoda ta przyjmuje jeden atrybut typu string
        //Nazwa, na podstawie podanego atrybutu zwrócone zostaną tylko procedury, których nazwa odpowiada tej przekazanej i nie wymagają
        //zespołu operacyjnego do ich przeprowadzenia.
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