using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Mas_Projekt_Koniec.Models.Hospitalizacja;

namespace Mas_Projekt_Koniec.Models
{
    public class Hospitalizacja
    {
        public long Id { get; set; }
        public DateTime PoczatekHospitalizacji { get; set; }
        public DateTime KoniecHospitalizacji { get; set; }
        public StatusHospitalizacji Status { get; set; }

        public Pacjent Pacjent { get; set; }
        public ZespolOperacyjny ZespolOperacyjny { get; set; }
        public ICollection<Procedura> Procedury { get; set; }

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
            get { return Status.GetOrderStateDisplayName(); }
        }

        public Hospitalizacja()
        {

        }

        public Hospitalizacja(DateTime poczatekHospitalizacji, Pacjent pacjent, ZespolOperacyjny zespol)
        {
            this.PoczatekHospitalizacji = poczatekHospitalizacji;
            this.Status = StatusHospitalizacji.CREATED;
            this.Pacjent = pacjent;
            this.ZespolOperacyjny = zespol;
        }
    }
}
