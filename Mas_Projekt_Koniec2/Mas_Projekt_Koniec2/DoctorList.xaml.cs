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

        /* Method activated by entering/changing text in the textbox, based on the changes, the doctors are filtered by name. */
        private void LastNameTextBox_TextChanged(object sender, TextChangedEventArgs tCEA)
        {
            TextBox textBox = (TextBox)sender;
            string text = textBox.Text.Trim();

            filteredDoctors = _doctorService.GetDoctorsByLastName(text);
            DoctorDataGrid.ItemsSource = null;
            DoctorDataGrid.ItemsSource = filteredDoctors;
        }

        /* Activated by double-clicking on the doctor in question, the method takes you to a detailed view of that person. */
        private void DoctorDataGrid_DoubleClick(object sender, RoutedEventArgs rEA)
        {
            Doctor selectedDoctor = (Doctor)DoctorDataGrid.SelectedItem;
            new DoctorDetails(selectedDoctor, selectedPatient, selectedProcedure).Show();

            Close();
        }

        /* The method, which is activated by clicking on the "Select doctor" button, takes you to a view of the appointments of the selected doctor. 
         * If the doctor has not been selected, the user cannot proceed further. */
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

        /* The method, activated when the " Return" button is clicked, takes the user back to the procedure selection view. */
        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            new ProcedureList(selectedPatient).Show();

            Close();
        }
    }
}