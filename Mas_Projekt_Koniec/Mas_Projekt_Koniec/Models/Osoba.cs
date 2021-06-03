using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas_Projekt_Koniec.Models
{
    public class Osoba
    {
        public long Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime DataUrodzenia { get; set; }
        public string NumerPesel { get; set; }
        public string AdresZamieszkania { get; set; }
        public IList<string> NumerTelefonu { get; set; }
        public IList<string> AdresEmail { get; set; }

        public Pacjent Pacjent { get; set; }
        public Pracownik Pracownik { get; set; }

        public Osoba()
        {

        }

        public Osoba(string imie, string nazwisko, DateTime dataUrodzenia, string numerPesel, string adresZamieszkania, List<string> numerTelefonu, List<string> adresEmail)
        {
            this.Imie = imie;
            this.Nazwisko = nazwisko;
            this.DataUrodzenia = dataUrodzenia;
            this.NumerPesel = numerPesel;
            this.AdresZamieszkania = adresZamieszkania;
            this.NumerTelefonu = numerTelefonu;
            this.AdresEmail = adresEmail;
        }

        public void AddPacjent(Pacjent pacjent)
        {
            this.Pacjent = pacjent;
        }

        public void AddPracownik(Pracownik pracownik)
        {
            this.Pracownik = pracownik;
        }
    }
}
