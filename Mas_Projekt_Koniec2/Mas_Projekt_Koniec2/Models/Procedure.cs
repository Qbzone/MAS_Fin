using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas_Final_Project.Models
{
    public class Procedure
    {
        public long Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string ProcedureName { get; set; }
        [Required]
        public int ProcedureCost { get; set; }
        [Required]
        public bool IsOperationalTeamNeeded { get; set; }
        [Required]
        public bool IsProcedureInvasive { get; set; }
        public ICollection<MedicalPackageProcedure> MedicalPackages { get; set; }
        public ICollection<Visit> Visits { get; set; }
        public ICollection<HospitalizationProcedure> Hospitalizations { get; set; }
        public ICollection<Doctor> Doctors { get; set; }

        public Procedure() { }
        public Procedure(string procedureName, int procedureCost, bool isOperationalTeamNeeded, bool isInvasive)
        {
            ProcedureName = procedureName;
            ProcedureCost = procedureCost;
            IsOperationalTeamNeeded = isOperationalTeamNeeded;
            IsProcedureInvasive = isInvasive;
            Doctors = new List<Doctor>();
        }
    }
}