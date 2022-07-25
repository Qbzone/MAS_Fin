using Mas_Final_Project.Models.Functional;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas_Final_Project.Models
{
    public class Hospitalization
    {
        public long Id { get; set; }
        [Required]
        public DateTime HospitalizationStart { get; set; }
        public DateTime HospitalizationEnd { get; set; }
        [Required]
        public HospitalizationStatus HospitalizationState { get; set; }
        public Patient Patient { get; set; }
        public long PatientId { get; set; }
        public OperationalTeam OperationalTeam { get; set; }
        public long OperationalTeamId { get; set; }
        public ICollection<HospitalizationProcedure> Procedures { get; set; }
        public enum HospitalizationStatus
        {
            [Display(Name = "Saved")]
            CREATED,
            [Display(Name = "Ongoing")]
            IN_PROGRESS,
            [Display(Name = "Finished")]
            DONE,
            [Display(Name = "Cancelled")]
            CANCELED
        }
        [NotMapped]
        public string StatusString => HospitalizationState.GetOrderStateDisplayName();

        public Hospitalization() { }
        public Hospitalization(DateTime hospitalizationStart, Patient patient, OperationalTeam operationalTeam)
        {
            HospitalizationStart = hospitalizationStart;
            HospitalizationState = HospitalizationStatus.CREATED;
            Patient = patient;
            PatientId = patient.PersonId;
            OperationalTeam = operationalTeam;
            OperationalTeamId = operationalTeam.Id;
        }
    }
}