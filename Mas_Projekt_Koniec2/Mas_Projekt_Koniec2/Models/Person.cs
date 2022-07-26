using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mas_Final_Project.Models
{
    public class Person
    {
        public long Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        [RegularExpression("^[0-9]*$")]
        [MinLength(11)]
        [MaxLength(11)]
        public string PeselNumber { get; set; }
        [Required]
        [MaxLength(75)]
        public string HomeAddress { get; set; }
        [Required]
        [RegularExpression("^[0-9]*$")]
        [MinLength(9)]
        [MaxLength(9)]
        public string PhoneNumber { get; set; }
        [Required]
        [MaxLength(50)]
        public string EmailAddress { get; set; }
        [NotMapped]
        public int Age => DateTime.Now.Year - BirthDate.Year;
        public Patient Patient { get; set; }
        public Employee Employee { get; set; }

        public Person() { }
        public Person(string firstName, string secondName, DateTime birthDate, string peselNumber, string homeAddress, string phoneNumber, string emailAddress)
        {
            FirstName = firstName;
            LastName = secondName;
            BirthDate = birthDate;
            PeselNumber = peselNumber;
            HomeAddress = homeAddress;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
        }
        public void AddPatient(Patient patient)
        {
            Patient = patient;
        }
        public void AddEmployee(Employee employee)
        {
            Employee = employee;
        }
        public string GetFirstAndLastName()
        {
            return $"{FirstName + " " + LastName}";
        }
    }
}