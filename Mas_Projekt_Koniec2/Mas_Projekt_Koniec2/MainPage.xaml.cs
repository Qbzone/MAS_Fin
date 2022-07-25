using Mas_Final_Project.Models;
using Mas_Final_Project.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Mas_Final_Project
{
    public partial class MainPage : Window
    {
        private readonly PatientService _patientService;
        private readonly ObservableCollection<Patient> allPatients;

        public MainPage()
        {
            InitializeComponent();
            _patientService = new PatientService();
            allPatients = _patientService.GetPatients();
        }

        //Metoda aktywawowana po kliknięciu przycisku "Zapisz na wizytę", przenosi uzytkownika do widoku wyboru pacjenta.
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            new PatientList().Show();

            Close();
        }

        //Metoda aktywawowana po kliknięciu przycisku "Wyświetl wizyty", przenosi uzytkownika do widoku wyboru wizyt.
        private void VisitButton_Click(object sender, RoutedEventArgs e)
        {
            new ChooseVisitList().Show();

            Close();
        }
    }
}