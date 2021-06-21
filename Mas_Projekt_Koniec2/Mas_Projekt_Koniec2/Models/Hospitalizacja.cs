using Mas_Projekt_Koniec2.Models.Functional;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas_Projekt_Koniec2.Models
{
    public class Hospitalizacja
    {
        public long Id { get; set; }
        [Required]
        public DateTime PoczatekHospitalizacji { get; set; }
        public DateTime KoniecHospitalizacji { get; set; }
        [Required]
        public StatusHospitalizacji StatusHospitalizacja { get; set; }

        public Pacjent Pacjent { get; set; }
        public long PacjentId { get; set; }
        public ZespolOperacyjny ZespolOperacyjny { get; set; }
        public long ZespolOperacyjnyId { get; set; }
        public ICollection<HospitalizacjaProcedura> Procedury { get; set; }

        public enum StatusHospitalizacji
        {
            [Display(Name = "Zapisana")]
            CREATED,
            [Display(Name = "Trwa")]
            IN_PROGRESS,
            [Display(Name = "Zakonczona")]
            DONE,
            [Display(Name = "Anulowana")]
            CANCELED
        }

        [NotMapped]
        public string StatusString
        {
            get { return StatusHospitalizacja.GetOrderStateDisplayName(); }
        }

        public Hospitalizacja()
        {

        }

        public Hospitalizacja(DateTime poczatekHospitalizacji, Pacjent pacjent, ZespolOperacyjny zespol)
        {
            this.PoczatekHospitalizacji = poczatekHospitalizacji;
            this.StatusHospitalizacja = StatusHospitalizacji.CREATED;
            this.Pacjent = pacjent;
            this.PacjentId = pacjent.OsobaId;
            this.ZespolOperacyjny = zespol;
            this.ZespolOperacyjnyId = zespol.Id;
        }
    }
}
