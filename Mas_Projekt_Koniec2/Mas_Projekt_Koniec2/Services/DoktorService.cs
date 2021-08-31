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
    class DoktorService
    {
        private readonly MasDBContext _context = new MasDBContext();

        public void UpdateDbContext()
        {
            _context.SaveChanges();
        }

        //Metoda GetDoktors zwraca ObservableCollection wszystkich doktorów w systemie.
        public ObservableCollection<Doktor> GetDoktors()
        {
            return new ObservableCollection<Doktor>(
                _context.Doktor
                .Include(p => p.Osoba)
                    .ThenInclude(e => e.Pracownik)
                .Include(dp => dp.Uprawnienia)
                .OrderBy(n => n.Osoba.Nazwisko)
                    .ThenBy(i => i.Osoba.Imie)
                .ToList());
        }

        //Metoda GetDoktors zwraca ObservableCollection doktorów. Metoda przyjmuje dwa atrybuty long ProceduraId i string Pesel. Zwróceni
        //zostaną wszyscy dkotorzy, którzy mają uprawnienia do wykonywania danego badania. Pesel służy do sprawdzenia, czy pacjent sam nie jest
        //doktorem w systemie, jeśli jest nie można go zapisać do niego samego
        public ObservableCollection<Doktor> GetDoktors(long ProceduraId, string Pesel)
        {
            return new ObservableCollection<Doktor>(
                _context.Doktor
                .Include(p => p.Osoba)
                    .ThenInclude(e => e.Pracownik)
                .Include(dp => dp.Uprawnienia)
                .Where(e => !e.Osoba.NumerPesel.Equals(Pesel) && e.Uprawnienia.Any(ee => ee.Id == ProceduraId))
                .OrderBy(n => n.Osoba.Nazwisko)
                    .ThenBy(i => i.Osoba.Imie)
                .ToList());
        }

        //Metoda GetDoktorsByNazwisko służy do przefiltrowania doktorów względem ich nazwiska. Metoda ta przyjmuje jeden atrybut typu string
        //Nazwisko, na podstawie podanego atrybutu zwróceni zostaną tylko doktorzy, których nazwisko odpowiada temu przekazanemu.
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

        //Metoda GetDoktorsSpecjalizacja służy do sprawdzenia czy w systemie istnieją doktorzy, którzy mogą wykonać daną procedurę.
        //Metoda przyjmuje jeden atrybut typu string Specjalizacja, jeśli specjalizacja ma wartość "Dowolna" to każdy doktor może ją wykonać,
        //jeśli wartość jest inna musi istnieć conajmniej jeden doktor o danej specjalizacji, żeby móc przejść do wybory doktora.
        public bool GetDoktorsSpecjalizacja(long ProceduraId)
        {
            return _context.Doktor
                .Where(e => e.Uprawnienia.Any(ee => ee.Id == ProceduraId))
                .Count() > 0;
        }
    }
}
