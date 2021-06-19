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
    class DoktorServices
    {
        private readonly MasDBContext _context = new MasDBContext();

        public void UpdateDbContext()
        {
            _context.SaveChanges();
        }

        public ObservableCollection<Doktor> GetDoktors(string Specjalizacja)
        {
            if (Specjalizacja == "Dowolna")
            {
                return new ObservableCollection<Doktor>(
                    _context.Doktor
                    .Include(p => p.Osoba)
                    .OrderBy(n => n.Osoba.Nazwisko)
                        .ThenBy(i => i.Osoba.Imie)
                    .ToList());
            }
            else
            {
                return new ObservableCollection<Doktor>(
                    _context.Doktor
                    .Include(p => p.Osoba)
                    .Where(e => e.SpecjalizacjaDoktor.Equals(Specjalizacja))
                    .OrderBy(n => n.Osoba.Nazwisko)
                        .ThenBy(i => i.Osoba.Imie)
                    .ToList());
            }
        }

        public ObservableCollection<Doktor> GetDoktorsByNazwisko(string Nazwisko)
        {
            return new ObservableCollection<Doktor>(
                _context.Doktor
                .Include(o => o.Osoba)
                .Where(pesel => pesel.Osoba.Nazwisko.Contains(Nazwisko))
                .OrderBy(i => i.Osoba.Nazwisko)
                    .ThenBy(i => i.Osoba.Imie)
                .ToList());
        }

        public bool GetDoktorsSpecjalizacja(string Specjalizacja)
        {
            if (Specjalizacja == "Dowolna")
            {
                return true;
            }

            return _context.Doktor
                .Where(specjalizacja => specjalizacja.SpecjalizacjaDoktor.Equals(Specjalizacja))
                .Count() > 0;
        }
    }
}
