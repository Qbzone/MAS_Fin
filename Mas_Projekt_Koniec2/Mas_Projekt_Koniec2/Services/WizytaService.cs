using Mas_Projekt_Koniec2.Models;
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

        public ObservableCollection<Wizyta> GetWizytas()
        {
            return new ObservableCollection<Wizyta>(
                _context.Wizyta
                .Include(p => p.Pacjent)
                    .ThenInclude(o => o.Osoba)
                .Include(d => d.Doktor)
                    .ThenInclude(o => o.Osoba)
                .Include(pr => pr.Procedura)
                .ToList());
        }

        public void AddWizyta(Wizyta wizyta)
        {
            _context.Add(wizyta);
            _context.SaveChanges();
        }
    }
}
