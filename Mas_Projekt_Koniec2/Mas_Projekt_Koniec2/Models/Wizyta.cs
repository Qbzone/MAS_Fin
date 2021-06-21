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
    public class Wizyta
    {
        public long Id { get; set; }
        [Required]
        public DateTime PoczatekWizyty { get; set; }
        public DateTime KoniecWizyty { get; set; }
        [Required]
        public StatusWizyty StatusWizyta { get; set; }
        [Required]
        public Pacjent Pacjent { get; set; }
        public long PacjentId { get; set; }
        [ForeignKey("DoktorId")]
        public Doktor Doktor { get; set; }
        public long? DoktorId { get; set; }
        [Required]
        public Procedura Procedura { get; set; }
        public long ProceduraId { get; set; }
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
            get { return StatusWizyta.GetOrderStateDisplayName(); }
        }

        public Wizyta()
        {

        }

        public Wizyta(DateTime poczatekWizyty, Pacjent pacjent, Doktor doktor, Procedura procedura)
        {
            this.PoczatekWizyty = poczatekWizyty;
            this.StatusWizyta = StatusWizyty.CREATED;
            this.Pacjent = pacjent;
            this.PacjentId = pacjent.Id;
            this.Doktor = doktor;
            this.DoktorId = doktor.Id;
            this.Procedura = procedura;
            this.ProceduraId = procedura.Id;
        }
    }
}
