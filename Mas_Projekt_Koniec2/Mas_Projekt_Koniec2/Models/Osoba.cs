using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas_Projekt_Koniec2.Models
{
    public class Osoba
    {
        public long Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string Imie { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nazwisko { get; set; }
        [Required]
        public DateTime DataUrodzenia { get; set; }
        [Required]
        [RegularExpression("^[0-9]*$")]
        [MinLength(11)]
        [MaxLength(11)]
        public string NumerPesel { get; set; }
        [Required]
        [MaxLength(75)]
        public string AdresZamieszkania { get; set; }
        [Required]
        [RegularExpression("^[0-9]*$")]
        [MinLength(9)]
        [MaxLength(9)]
        public string NumerTelefonu { get; set; }
        [Required]
        [MaxLength(50)]
        public string AdresEmail { get; set; }
        [NotMapped]
        public int Wiek
        {
            get { return DateTime.Now.Year - DataUrodzenia.Year; }
        }
        //public Pacjent Pacjent { get; set; }
        public Pracownik Pracownik { get; set; }

        public Osoba()
        {

        }

        public Osoba(string imie, string nazwisko, DateTime dataUrodzenia, string pesel, string adresZamieszkania, string numerTelefonu, string adresEmail)
        {
            this.Imie = imie;
            this.Nazwisko = nazwisko;
            this.DataUrodzenia = dataUrodzenia;
            this.NumerPesel = pesel;
            this.AdresZamieszkania = adresZamieszkania;
            this.NumerTelefonu = numerTelefonu;
            this.AdresEmail = adresEmail;
        }

        /*public void AddPacjent(Pacjent pacjent)
        {
            this.Pacjent = pacjent;
        }*/

        public void AddPracownik(Pracownik pracownik)
        {
            this.Pracownik = pracownik;
        }

    }
}