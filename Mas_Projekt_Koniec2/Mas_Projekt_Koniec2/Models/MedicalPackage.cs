using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas_Final_Project.Models
{
    public class MedicalPackage
    {
        public long Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string PackageName { get; set; }
        public ICollection<Patient> Patients { get; set; }
        public ICollection<MedicalPackageProcedure> Procedures { get; set; }

        public MedicalPackage() { }
        public MedicalPackage(string packageName)
        {
            PackageName = packageName;
        }
    }
}