using Mas_Final_Project.Models;
using Mas_Final_Project.Services;
using System.Collections.ObjectModel;
using System.Windows;

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