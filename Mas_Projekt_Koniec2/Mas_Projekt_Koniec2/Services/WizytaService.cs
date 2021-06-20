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
                .Where(e => e.PoczatekWizyty.Date >= DateTime.Today)
                .OrderBy(kw => kw.KoniecWizyty)
                .ThenBy(d => d.Doktor.Osoba.Nazwisko).ThenBy(p => p.Pacjent.Osoba.Nazwisko)
                .ToList());
        }

        public void AddWizyta(Wizyta wizyta)
        {
            _context.Add(wizyta);
            _context.SaveChanges();
        }

        public bool GetDoktorWizyta(DateTime poczatekWizyty, long Id)
        {
            return _context.Wizyta
                .Where(wizyta => wizyta.PoczatekWizyty == poczatekWizyty && wizyta.DoktorId == Id)
                .Count() > 0;
        }

        public ObservableCollection<Wizyta> GetDayTermins(Doktor selectedDoktor, Pacjent selectedPacjent, Procedura selectedProcedura, DateTime pickedDate)
        {
            ObservableCollection<Wizyta> tmpWizytas = new ObservableCollection<Wizyta>();
            DateTime Start = pickedDate.AddHours(8);
            for (int i = 0; i < 16; i++)
            {
                if (!GetDoktorWizyta(Start, selectedDoktor.Id))
                {
                    DateTime Koniec = Start.AddMinutes(29);
                    Wizyta tmpTermin = new Wizyta() { PoczatekWizyty = Start, KoniecWizyty = Koniec, StatusWizyta = Wizyta.StatusWizyty.CREATED, DoktorId = selectedDoktor.Id, PacjentId = selectedPacjent.Id, ProceduraId = selectedProcedura.Id };
                    tmpWizytas.Add(tmpTermin);
                }
                Start = Start.AddMinutes(30);
            }

            return tmpWizytas;
        }
    }
}
