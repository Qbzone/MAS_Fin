using System;
using System.ComponentModel.DataAnnotations;

namespace Mas_Final_Project.Models
{
    public class MedicalPackageProcedure
    {
        [Required]
        public DateTime AssignmentDate { get; set; }
        [Required]
        public MedicalPackage MedicalPackage { get; set; }
        public long MedicalPackageId { get; set; }
        [Required]
        public Procedure Procedure { get; set; }
        public long ProcedureId { get; set; }

        public MedicalPackageProcedure() { }
        public MedicalPackageProcedure(MedicalPackage medicalPackage, Procedure procedure)
        {
            MedicalPackageId = medicalPackage.Id;
            ProcedureId = procedure.Id;
        }
    }
}