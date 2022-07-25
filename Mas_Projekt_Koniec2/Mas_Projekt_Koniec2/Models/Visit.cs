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
    public class Visit
    {
        public long Id { get; set; }
        [Required]
        public DateTime VisitStart { get; set; }
        public DateTime VisitEnd { get; set; }
        [Required]
        public VisitStatus VisitState { get; set; }
        [Required]
        public Patient Patient { get; set; }
        public long PatientId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }
        public long? DoctorId { get; set; }
        [Required]
        public Procedure Procedure { get; set; }
        public long ProcedureId { get; set; }
        public enum VisitStatus
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
        public string StatusString => VisitState.GetOrderStateDisplayName();

        public Visit() { }
        public Visit(DateTime visitStart, Patient patient, Doctor doctor, Procedure procedure)
        {
            VisitStart = visitStart;
            VisitState = VisitStatus.CREATED;
            Patient = patient;
            PatientId = patient.Id;
            Doctor = doctor;
            DoctorId = doctor.Id;
            Procedure = procedure;
            ProcedureId = procedure.Id;
        }
    }
}