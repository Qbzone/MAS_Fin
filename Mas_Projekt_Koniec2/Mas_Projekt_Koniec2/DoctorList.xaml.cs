using Mas_Final_Project.Models;
using Mas_Final_Project.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Mas_Final_Project
{
    public partial class DoctorList : Window
    {
        private readonly DoctorService _doctorService;
        private readonly ObservableCollection<Doctor> allDoctors;
        private ObservableCollection<Doctor> filteredDoctors;
        private readonly Patient selectedPatient;
        private readonly Procedure selectedProcedure;

        public DoctorList(Patient selectedPatient, Procedure selectedProcedure)
        {
            InitializeComponent();

            this.selectedPatient = selectedPatient;
            this.selectedProcedure = selectedProcedure;

            _doctorService = new DoctorService();
            allDoctors = _doctorService.GetDoctors(selectedProcedure.Id, selectedPatient.Person.PeselNumber);
            filteredDoctors = allDoctors;
            DoctorDataGrid.ItemsSource = filteredDoctors;
        }

        //Metoda aktywowana poprzez wprowadzenie/zmianę tekstu w textboxie, na podstawie zmian następuje filtracja doktorów po nazwisku
        private void LastNameTextBox_TextChanged(object sender, TextChangedEventArgs tCEA)
        {
            TextBox textBox = (TextBox)sender;
            string text = textBox.Text.Trim();

            filteredDoctors = _doctorService.GetDoctorsByLastName(text);
            DoctorDataGrid.ItemsSource = null;
            DoctorDataGrid.ItemsSource = filteredDoctors;
        }

        //Metoda aktywowana poprzez dwukrotne kliknięcię na danego doktora, przenosi do widoku szczegółowego tej osoby
        private void DoctorDataGrid_DoubleClick(object sender, RoutedEventArgs rEA)
        {
            Doctor selectedDoctor = (Doctor)DoctorDataGrid.SelectedItem;
            new DoctorDetails(selectedDoctor, selectedPatient, selectedProcedure).Show();

            Close();
        }

        //Metoda aktywowana po kliknięciu przycisku "Wybierz doktora", przenosi do widoku terminów wybranego doktora.
        //Jeśli doktor nie zostal wybrany, użytkownik nie może przejść dalej.
        private void DoctorButton_Click(object sender, RoutedEventArgs rEA)
        {
            Doctor selectedDoctor = (Doctor)DoctorDataGrid.SelectedItem;

            if (DoctorDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Please choose a doctor!", Title = "Warning");

                return;
            }

            new TermList(selectedPatient, selectedProcedure, selectedDoctor).Show();

            Close();
        }

        //Metoda aktywawowane po kliknięciu przycisku "Wróć", cofa uzytkownika do widoku wyboru procedur.
        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            new ProcedureList(selectedPatient).Show();

            Close();
        }
    }
}