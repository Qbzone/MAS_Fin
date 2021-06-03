using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mas_Projekt_Koniec.Models
{
    public class Wizyta
    {
        public long Id { get; set; }
        public DateTime PoczatekWizyty { get; set; }
        public DateTime KoniecWizyty { get; set; }

        public StatusWizyty Status { get; set; }
        public Pacjent Pacjent { get; set; }
        public Doktor Doktor { get; set; }

        public enum StatusWizyty
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

        public Wizyta()
        {
            
        }

        public Wizyta(DateTime poczatekWizyty, Pacjent pacjent, Doktor doktor)
        {
            this.PoczatekWizyty = poczatekWizyty;
            this.Status = StatusWizyty.CREATED;
            this.Pacjent = pacjent;
            this.Doktor = doktor;
        }
    }
}
