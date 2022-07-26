using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using static Mas_Final_Project.Models.Hospitalization;
using static Mas_Final_Project.Models.Visit;

namespace Mas_Final_Project.Models.Functional
{
    public static class StateExtensions
    {
        public static string GetOrderStateDisplayName(this VisitStatus statusWizyty)
        {
            return statusWizyty
                .GetType()
                .GetMember(statusWizyty.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()
                .Name;
        }

        public static string GetOrderStateDisplayName(this HospitalizationStatus hospitalizationStatus)
        {
            return hospitalizationStatus
                .GetType()
                .GetMember(hospitalizationStatus.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()
                .Name;
        }
    }
}