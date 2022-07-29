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

        /* The method, which is activated by clicking on the "Save for appointment" button, takes the user to the patient selection view. */
        private void RegisterButton_Click(object sender, RoutedEventArgs rEA)
        {
            new PatientList().Show();

            Close();
        }

        /* The method activated by clicking on the "View visits" button takes the user to the visit selection view. */
        private void VisitButton_Click(object sender, RoutedEventArgs rEA)
        {
            new ChooseVisitList().Show();

            Close();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs rEA)
        {
            Close();
        }
    }
}