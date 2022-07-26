using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mas_Final_Project.Models
{
    public class OperationalTeam
    {
        public long Id { get; set; }
        [Required]
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Hospitalization> Hospitalizations { get; set; }

        public OperationalTeam() { }
        public OperationalTeam(ICollection<Employee> employees)
        {
            Employees = employees;
        }
    }
}