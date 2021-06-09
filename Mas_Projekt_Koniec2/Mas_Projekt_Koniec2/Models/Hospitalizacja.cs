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
        public StatusHospitalizacji Status { get; set; }

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
            this.PacjentId = pacjent.OsobaId;
            this.ZespolOperacyjny = zespol;
            this.ZespolOperacyjnyId = zespol.Id;
        }

        /*public void AddZespol(ZespolOperacyjny zespol)
        {
            if (this.ZespolOperacyjny == null)
            {
                this.ZespolOperacyjny = zespol;
                zespol.AddHospitalizacja(this);
            }
        }

        public void AddPacjent(Pacjent pacjent)
        {
            if (this.Pacjent == null)
            {
                this.Pacjent = pacjent;
                pacjent.AddHospitalizacja(this);
            }
        }

        public void AddProcedura(Procedura procedura)
        {
            this.Procedury.Add(procedura);
            procedura.AddHospitalizacja(this);

        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (PoczatekHospitalizacji > KoniecHospitalizacji)
            {
                errors.Add(new ValidationResult($"Data początku hospitalizacji musi być mniejsza niż data zakończenia hospitalizacji.", new List<string> { nameof(PoczatekHospitalizacji) }));
            }

            return errors;
        }*/
    }
}
