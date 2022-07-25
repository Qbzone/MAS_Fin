using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas_Final_Project.Models
{
    public class Orderly : Employee
    {
        public bool DoesSupportFunctions { get; set; }

        public Orderly() { }
        public Orderly(bool doesSupportFunctions)
        {
            DoesSupportFunctions = doesSupportFunctions;
        }
    }
}