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
        [Required]
        public DateTime PoczatekWizyty { get; set; }
        public DateTime KoniecWizyty { get; set; }
        [Required]
        public StatusWizyty Status { get; set; }
        [Required]
        public Pacjent Pacjent { get; set; }
        public long PacjentId { get; set; }
        [Required]
        public Doktor Doktor { get; set; }
        public long DoktorId { get; set; }
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
            get { return Status.GetOrderStateDisplayName(); }
        }

        public Wizyta()
        {

        }

        public Wizyta(DateTime poczatekWizyty, Pacjent pacjent, Doktor doktor, Procedura procedura)
        {
            this.PoczatekWizyty = poczatekWizyty;
            this.Status = StatusWizyty.CREATED;
            this.Pacjent = pacjent;
            this.PacjentId = pacjent.Id;
            this.Doktor = doktor;
            this.DoktorId = doktor.Id;
            this.Procedura = procedura;
            this.ProceduraId = procedura.Id;
        }

        /*public void AddDoktor(Doktor doktor)
        {
            if (this.Doktor == null)
            {
                this.Doktor = doktor;
                doktor.AddWizyty(this);
            }
        }

        public void AddPacjent(Pacjent pacjent)
        {
            if (this.Pacjent == null)
            {
                this.Pacjent = pacjent;
                pacjent.AddWizyty(this);
            }
        }

        public void AddProcedura(Procedura procedura)
        {
            if (this.Procedura == null)
            {
                this.Procedura = procedura;
                procedura.AddWizyta(this);
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (PoczatekWizyty > KoniecWizyty)
            {
                errors.Add(new ValidationResult($"Data początku hospitalizacji musi być mniejsza niż data zakończenia hospitalizacji.", new List<string> { nameof(PoczatekWizyty) }));
            }

            return errors;
        }*/
    }
}
