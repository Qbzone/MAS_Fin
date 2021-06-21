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

        //Metoda GetPacjents zwraca ObservableCollection wszystkich pacjentów w systemie
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

        //Metoda GetPacjentByNazwisko służy do przefiltrowania pacjentów względem ich numeru pesel. Metoda ta przyjmuje jeden atrybut typu string
        //Pesel, na podstawie podanego atrybutu zwróceni zostaną tylko pacjenci, których numer pesel odpowiada temu przekazanemu.
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
    }
}
