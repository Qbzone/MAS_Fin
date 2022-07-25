using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas_Final_Project.Models
{
    public class Nurse : Employee
    {
        [Required]
        [MaxLength(25)]
        public string NurseSpacialization { get; set; }

        public Nurse() { }
        public Nurse(string specialization)
        {
            NurseSpacialization = specialization;
        }
    }
}
