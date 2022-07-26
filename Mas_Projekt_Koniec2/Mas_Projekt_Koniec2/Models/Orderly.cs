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