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

        /* Method activated by entering/changing text in the textbox, 
         * based on the changes the procedures are filtered by their names */
        private void ProcedureNameTextBox_TextChanged(object sender, TextChangedEventArgs tCEA)
        {
            TextBox textBox = (TextBox)sender;
            string text = textBox.Text.Trim();

            filteredProcedures = _procedureService.GetProceduresByName(text);
            ProcedureDataGrid.ItemsSource = null;
            ProcedureDataGrid.ItemsSource = filteredProcedures;
        }

        /* The method activated when the 'Select procedure' button is clicked, 
         * takes you to the selection view of the doctor who can carry out this procedure. 
         * If the procedure has not been selected, the user cannot proceed further. 
         * If there is no doctor in the system who can perform a given procedure, the user cannot proceed further. */
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

        /* Activated by clicking on the " Return" button, the method takes the user back to the patient selection view. */
        private void ReturnButton_Click(object sender, RoutedEventArgs rEA)
        {
            new PatientList().Show();

            Close();
        }
    }
}