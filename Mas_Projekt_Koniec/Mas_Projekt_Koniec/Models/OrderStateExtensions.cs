using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Mas_Projekt_Koniec.Models.Hospitalizacja;
using static Mas_Projekt_Koniec.Models.Wizyta;

namespace Mas_Projekt_Koniec.Models
{
    public static class OrderStateExtensions
    {
        public static string GetOrderStateDisplayName(this StatusWizyty statusWizyty)
        {
            return statusWizyty.GetType().GetMember(statusWizyty.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()
                .Name;
        }

        public static string GetOrderStateDisplayName(this StatusHospitalizacji statusHospitalizacji)
        {
            return statusHospitalizacji.GetType().GetMember(statusHospitalizacji.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()
                .Name;
        }
    }
}