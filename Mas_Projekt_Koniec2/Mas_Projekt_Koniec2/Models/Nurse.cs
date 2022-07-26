using System.ComponentModel.DataAnnotations;

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
