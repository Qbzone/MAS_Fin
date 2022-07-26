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

        //Metoda aktywowana poprzez wprowadzenie/zmianę tekstu w textboxie, na podstawie zmian następuje filtracja pacjentów po numerze pesel
        private void PeselTextBox_TextChanged(object sender, TextChangedEventArgs tCEA)
        {
            TextBox textBox = (TextBox)sender;
            string text = textBox.Text.Trim();

            filteredPatients = _patientService.GetPatientsByPeselNumber(text);
            PatienttDataGrid.ItemsSource = null;
            PatienttDataGrid.ItemsSource = filteredPatients;
        }

        //Metoda aktywowana poprzez dwukrotne kliknięcię na danego pacjenta, przenosi do widoku szczegółowego tej osoby
        private void PatientDataGrid_DoubleClick(object sender, RoutedEventArgs rEA)
        {
            Patient selectedPacjent = (Patient)PatienttDataGrid.SelectedItem;

            new PatientDetails(selectedPacjent, 1).Show();

            Close();
        }

        //Metoda aktywowana po kliknięciu przycisku "Wybierz pacjenta", przenosi do widoku wyboru procedury dla wybranego pacjenta.
        //Jeśli pacjent nie zostal wybrany, użytkownik nie może przejść dalej.
        //Jeśli pacjent nie posiada ubezpieczenia zdrowotnego lub pakietu medycznego, użytkownik nie może przejść dalej
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

        //Metoda aktywawowane po kliknięciu przycisku "Wróć", cofa uzytkownika do widoku strony głównej.
        private void ReturnButton_Click(object sender, RoutedEventArgs rEA)
        {
            new MainPage().Show();

            Close();
        }
    }
}
