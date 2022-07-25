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
            var textBox = (TextBox)sender;
            var text = textBox.Text.Trim();

            filteredPatients = _patientService.GetPatientsByPeselNumber(text);

            PatienttDataGrid.ItemsSource = null;
            PatienttDataGrid.ItemsSource = filteredPatients;
        }

        //Metoda aktywowana poprzez dwukrotne kliknięcię na danego pacjenta, przenosi do widoku szczegółowego tej osoby
        private void PatientDataGrid_DoubleClick(object sender, RoutedEventArgs rEA)
        {
            var selectedPacjent = (Patient)PatienttDataGrid.SelectedItem;
            new PatientDetails(selectedPacjent, 1).Show();
            this.Close();
        }

        //Metoda aktywowana po kliknięciu przycisku "Wybierz pacjenta", przenosi do widoku wyboru procedury dla wybranego pacjenta.
        //Jeśli pacjent nie zostal wybrany, użytkownik nie może przejść dalej.
        //Jeśli pacjent nie posiada ubezpieczenia zdrowotnego lub pakietu medycznego, użytkownik nie może przejść dalej
        private void PatientButton_Click(object sender, RoutedEventArgs rEA)
        {
            var selectedPacjent = (Patient)PatienttDataGrid.SelectedItem;
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
            this.Close();
        }

        //Metoda aktywawowane po kliknięciu przycisku "Wróć", cofa uzytkownika do widoku strony głównej.
        private void ReturnButton_Click(object sender, RoutedEventArgs rEA)
        {
            new MainPage().Show();
            this.Close();
        }
    }
}
