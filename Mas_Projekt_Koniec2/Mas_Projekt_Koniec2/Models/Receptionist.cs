using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas_Final_Project.Models
{
    public class Receptionist : Employee
    {
        [Required]
        [MaxLength(25)]
        public string AdditionalLanguage { get; set; }

        public Receptionist() { }
        public Receptionist(string additionalLanguage)
        {
            AdditionalLanguage = additionalLanguage;
        }
    }
}