using System;
using System.ComponentModel.DataAnnotations;

namespace Mas_Final_Project.Models
{
    public class HospitalizationProcedure
    {
        public long Id { get; set; }
        [Required]
        public Procedure Procedure { get; set; }
        public long ProcedureId { get; set; }
        public Hospitalization Hospitalization { get; set; }
        public long HospitalizationId { get; set; }
        [Required]
        public DateTime ExecutionDate { get; set; }

        public HospitalizationProcedure() { }
        public HospitalizationProcedure(Procedure procedure, Hospitalization hospitalization, DateTime executionDate)
        {
            Procedure = procedure;
            ProcedureId = procedure.Id;
            Hospitalization = hospitalization;
            HospitalizationId = hospitalization.Id;
            ExecutionDate = executionDate;
        }
    }
}