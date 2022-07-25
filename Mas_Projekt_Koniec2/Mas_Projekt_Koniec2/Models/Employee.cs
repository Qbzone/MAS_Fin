using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas_Final_Project.Models
{
    public abstract class Employee
    {
        public long Id { get; set; }
        [Required]
        public int Salary { get; set; }
        [Required]
        public Person Person { get; set; }
        public long PersonId { get; set; }

        public Employee() { }
        public Employee(Person person, int salary)
        {
            Person = person;
            PersonId = person.Id;
            Salary = salary;
        }
    }
}