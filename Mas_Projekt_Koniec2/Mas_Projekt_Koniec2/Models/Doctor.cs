using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas_Final_Project.Models
{
    public class Doctor : Employee
    {
        [Required]
        [MaxLength(25)]
        public string DoctorSpecialization { get; set; }
        public ICollection<Visit> Visits { get; set; }
        [Required]
        public ICollection<Procedure> Entitlements { get; set; }
        [NotMapped]
        public string DoctorFirstAndLastName => Person.GetFirstAndLastName();

        public Doctor() { }
        public Doctor(string spacialization)
        {
            DoctorSpecialization = spacialization;
            Entitlements = new List<Procedure>();
        }
    }
}