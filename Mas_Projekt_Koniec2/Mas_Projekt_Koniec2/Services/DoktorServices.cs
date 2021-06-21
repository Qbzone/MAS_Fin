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

        //Metoda GetDoktors zwraca ObservableCollection doktorów. Metoda przyjmuje dwa atrybuty typu string Specjalizacja i Pesel. Jeśli Specjalizacja
        //ma wartość "Dowolna" zwróceni będą wszyscy lekarze, jeśli tylko ci z dobrą specjalizacją. Pesel służy do sprawdzenia, czy pacjent sam nie jest
        //doktorem w systemie, jeśli jest nie można go zapisać do niego samego
        public ObservableCollection<Doktor> GetDoktors(string Specjalizacja, string Pesel)
        {
            if (Specjalizacja == "Dowolna")
            {
                return new ObservableCollection<Doktor>(
                    _context.Doktor
                    .Include(p => p.Osoba)
                    .OrderBy(n => n.Osoba.Nazwisko)
                        .ThenBy(i => i.Osoba.Imie)
                    .Where(pesel => !pesel.Osoba.NumerPesel.Equals(Pesel))
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
                    .Where(pesel => !pesel.Osoba.NumerPesel.Equals(Pesel))
                    .ToList());
            }
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
