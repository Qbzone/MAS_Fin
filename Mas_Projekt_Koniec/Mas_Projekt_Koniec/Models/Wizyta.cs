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
        [Required]
        public DateTime PoczatekWizyty { get; set; }
        [Required]
        public DateTime KoniecWizyty { get; set; }
        [Required]
        public StatusWizyty Status { get; set; }
        public Pacjent Pacjent { get; set; }
        public Doktor Doktor { get; set; }
        public Procedura Procedura { get; set; }

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
            AddPacjent(pacjent);
            AddDoktor(doktor);
            AddProcedura(procedura);
        }

        public void AddDoktor(Doktor doktor)
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
        }
    }
}
