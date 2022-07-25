using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas_Final_Project.Models
{
    public class Patient
    {
        public long Id { get; set; }
        [Required]
        public bool HealthInsurance { get; set; }
        [Required]
        public Person Person { get; set; }
        public long PersonId { get; set; }
        public MedicalPackage MedicalPackage { get; set; }
        public long? MedicalPackageId { get; set; }
        public ICollection<Visit> Visits { get; set; }
        public ICollection<Hospitalization> Hospitalizations { get; set; }
        [NotMapped]
        public string PatientFirstAndLastName => Person.GetFirstAndLastName();

        public Patient() { }
        public Patient(Person person, bool healthInsurance)
        {
            Person = person;
            PersonId = person.Id;
            HealthInsurance = healthInsurance;
        }
    }
}