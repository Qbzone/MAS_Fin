using Mas_Final_Project.Models;
using Mas_Final_Project.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Mas_Final_Project
{
    public partial class ProcedureList : Window
    {
        private readonly ProcedureService _procedureService;
        private DoctorService _doctorService;
        private readonly ObservableCollection<Procedure> allProcedures;
        private ObservableCollection<Procedure> filteredProcedures;
        private readonly Patient selectedPatient;

        public ProcedureList(Patient selected)
        {
            InitializeComponent();

            selectedPatient = selected;
            _procedureService = new ProcedureService();
            allProcedures = _procedureService.GetProcedures();
            filteredProcedures = allProcedures;
            ProcedureDataGrid.ItemsSource = filteredProcedures;
        }

        //Metoda aktywowana poprzez wprowadzenie/zmianę tekstu w textboxie, na podstawie zmian następuje filtracja procedur po ich nazwie
        private void ProcedureNameTextBox_TextChanged(object sender, TextChangedEventArgs tCEA)
        {
            TextBox textBox = (TextBox)sender;
            string text = textBox.Text.Trim();

            filteredProcedures = _procedureService.GetProceduresByName(text);
            ProcedureDataGrid.ItemsSource = null;
            ProcedureDataGrid.ItemsSource = filteredProcedures;
        }

        //Metoda aktywowana po kliknięciu przycisku "Wybierz procedurę", przenosi do widoku wyboru doktora, który może przeprowadzić tą procedurę.
        //Jeśli procedura nie została wybrana, użytkownik nie może przejść dalej.
        //Jeśli w systemie nie ma doktora, który może wykonać danę procedurę, użytkownik nie może przejść dalej.
        private void ProcedureButton_Click(object sender, RoutedEventArgs rEA)
        {
            _doctorService = new DoctorService();

            Procedure selectedProcedura = (Procedure)ProcedureDataGrid.SelectedItem;

            if (ProcedureDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Please select a procedure!", Title = "Warning");

                return;
            }
            else if (!_doctorService.GetDoctorsSpecialization(selectedProcedura.Id))
            {
                MessageBox.Show("No doctor able to carry out the procedure!", Title = "Warning");

                return;
            }

            new DoctorList(selectedPatient, selectedProcedura).Show();

            Close();
        }

        //Metoda aktywawowane po kliknięciu przycisku "Wróć", cofa uzytkownika do widoku wyboru pacjenta.
        private void ReturnButton_Click(object sender, RoutedEventArgs rEA)
        {
            new PatientList().Show();

            Close();
        }
    }
}