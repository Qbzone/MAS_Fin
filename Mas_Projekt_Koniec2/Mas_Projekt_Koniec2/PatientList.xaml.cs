using Mas_Final_Project.Models;
using Mas_Final_Project.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Mas_Final_Project
{
    public partial class PatientList : Window
    {
        private readonly PatientService _patientService;
        private readonly ObservableCollection<Patient> allPatients;
        private ObservableCollection<Patient> filteredPatients;

        public PatientList()
        {
            InitializeComponent();

            _patientService = new PatientService();
            allPatients = _patientService.GetPatients();
            filteredPatients = allPatients;
            PatienttDataGrid.ItemsSource = filteredPatients;
        }

        /* Method activated by entering/changing text in the textbox, based on the changes the patients are filtered by pesel number. */
        private void PeselTextBox_TextChanged(object sender, TextChangedEventArgs tCEA)
        {
            TextBox textBox = (TextBox)sender;
            string text = textBox.Text.Trim();

            filteredPatients = _patientService.GetPatientsByPeselNumber(text);
            PatienttDataGrid.ItemsSource = null;
            PatienttDataGrid.ItemsSource = filteredPatients;
        }

        /* Activated by double-clicking on a patient, the method takes you to a detailed view of that person. */
        private void PatientDataGrid_DoubleClick(object sender, RoutedEventArgs rEA)
        {
            Patient selectedPacjent = (Patient)PatienttDataGrid.SelectedItem;

            new PatientDetails(selectedPacjent, 1).Show();

            Close();
        }

        /* When activated by clicking the "Select patient" button, the method takes you to the procedure selection view for the selected patient. 
         * If the patient has not been selected, the user cannot proceed further. 
         * If the patient does not have health insurance or a medical package, the user cannot proceed further. */
        private void PatientButton_Click(object sender, RoutedEventArgs rEA)
        {
            Patient selectedPacjent = (Patient)PatienttDataGrid.SelectedItem;

            if (PatienttDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Please select a patient!", Title = "Warning");

                return;
            }
            else if (selectedPacjent.HealthInsurance == false && selectedPacjent.MedicalPackageId == null)
            {
                MessageBox.Show("The selected patient has no health insurance or medical package! He/she cannot be registered for an appointment!", Title = "Warning");

                return;
            }

            new ProcedureList(selectedPacjent).Show();

            Close();
        }

        /* The method, activated when the " Return" button is clicked, takes the user back to the home page view. */
        private void ReturnButton_Click(object sender, RoutedEventArgs rEA)
        {
            new MainPage().Show();

            Close();
        }
    }
}