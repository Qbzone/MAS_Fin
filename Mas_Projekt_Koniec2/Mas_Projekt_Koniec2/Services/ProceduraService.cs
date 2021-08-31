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
    class ProceduraService
    {
        private readonly MasDBContext _context = new MasDBContext();

        public void UpdateDbContext()
        {
            _context.SaveChanges();
        }

        //Metoda GetProceduras zwraca ObservableCollection wszystkich procedur w systemie, które nie wymagają zespołu operacyjnego
        //do ich przeprowadzenia.
        public ObservableCollection<Procedura> GetProceduras()
        {
            return new ObservableCollection<Procedura>(
                _context.Procedura
                .Where(zespol => zespol.CzyPotrzebnyZespolOperacyjny == false)
                .OrderBy(n => n.NazwaProcedura)
                    .ThenBy(k => k.KosztProcedura)
                .ToList());
        }

        //Metoda GetProceduras zwraca ObservableCollection wszystkich procedur w systemie, do których ma uprawnienia doktor
        //o przekazanym Id.
        public ObservableCollection<Procedura> GetProceduras(long DoktorId)
        {
            return new ObservableCollection<Procedura>(
                _context.Procedura
                .Include(dp => dp.Doktorzy)
                .Where(e => e.Doktorzy.Any(ee => ee.Id == DoktorId))
                .OrderBy(n => n.NazwaProcedura)
                .ToList());
        }

        //Metoda GetProcedurasByNazwa służy do przefiltrowania procedur względem ich nazwy. Metoda ta przyjmuje jeden atrybut typu string
        //Nazwa, na podstawie podanego atrybutu zwrócone zostaną tylko procedury, których nazwa odpowiada tej przekazanej i nie wymagają
        //zespołu operacyjnego do ich przeprowadzenia.
        public ObservableCollection<Procedura> GetProcedurasByNazwa(string Nazwa)
        {
            return new ObservableCollection<Procedura>(
                _context.Procedura
                .Where(nazwa => nazwa.NazwaProcedura.Contains(Nazwa) && nazwa.CzyPotrzebnyZespolOperacyjny == false)
                .OrderBy(n => n.NazwaProcedura)
                    .ThenBy(k => k.KosztProcedura)
                .ToList());
        }
    }
}