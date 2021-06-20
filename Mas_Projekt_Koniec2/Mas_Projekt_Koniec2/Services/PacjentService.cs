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
    class PacjentService
    {
        private readonly MasDBContext _context = new MasDBContext();

        public void UpdateDbContext()
        {
            _context.SaveChanges();
        }

        public ObservableCollection<Pacjent> GetPacjents()
        {
            return new ObservableCollection<Pacjent>(
                _context.Pacjent
                .Include(o => o.Osoba)
                .Include(pm => pm.PakietMedyczny)
                .OrderBy(n => n.Osoba.Nazwisko)
                    .ThenBy(i => i.Osoba.Imie)
                .ToList());
        }
        
        public ObservableCollection<Pacjent> GetPacjentsByPesel(string Pesel)
        {
            return new ObservableCollection<Pacjent>(
                _context.Pacjent
                .Include(o => o.Osoba)
                .Include(pm => pm.PakietMedyczny)
                .Where(pesel => pesel.Osoba.NumerPesel.Contains(Pesel))
                .OrderBy(n => n.Osoba.Nazwisko)
                    .ThenBy(i => i.Osoba.Imie)
                .ToList());
        }

        /*public Pacjent GetPacjentByID(long id)
        {
            return _context.Pacjent
                .Include(o => o.Osoba)
                .FirstOrDefault(o => o.Id == id);
        }*/
    }
}
