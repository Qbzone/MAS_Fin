using Mas_Projekt_Koniec2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas_Projekt_Koniec2.Services
{
    class ProceduraService
    {
        private readonly MasDBContext _context = new MasDBContext();

        public void UpdateDbContext()
        {
            _context.SaveChanges();
        }

        public ObservableCollection<Procedura> GetProceduras()
        {
            return new ObservableCollection<Procedura>(
                _context.Procedura
                .Where(zespol => zespol.CzyPotrzebnyZespolOperacyjny == false)
                .ToList());
        }

        public ObservableCollection<Procedura> GetProcedurasByNazwa(string Nazwa)
        {
            return new ObservableCollection<Procedura>(
                _context.Procedura
                .Where(nazwa => nazwa.NazwaProcedura.Contains(Nazwa) && nazwa.CzyPotrzebnyZespolOperacyjny == false)
                .ToList());
        }
    }
}