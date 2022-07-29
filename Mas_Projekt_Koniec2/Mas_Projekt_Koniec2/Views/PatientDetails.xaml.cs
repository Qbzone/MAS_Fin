using Mas_Final_Project.Models;
using Mas_Final_Project.Services;
using System.Collections.ObjectModel;
using System.Windows;

namespace Mas_Final_Project
{
    public partial class PatientDetails : Window
    {
        private readonly PatientService _patientService;
        private readonly ObservableCollection<Patient> allPatients;
        private readonly int Checker;

        public PatientDetails(Patient patient, int checker)
        {
            InitializeComponent();

            _patientService = new PatientService();
            allPatients = new ObservableCollection<Patient>
            {
                patient
            };
            PatientDataGrid.ItemsSource = allPatients;
            Checker = checker;
        }

        /* The method, which is activated when the "Return" button is clicked, 
         * takes the user back to the patient selection view or the appointment selection view, 
         * depending on where the user got to this view from. */
        private void ReturnButton_Click(object sender, RoutedEventArgs rEA)
        {
            if (Checker == 1)
            {
                new PatientList().Show();

                Close();
            }
            else if (Checker == 2)
            {
                new ChooseVisitList().Show();

                Close();
            }
        }
    }
}