using Mas_Final_Project.Models;
using Mas_Final_Project.Services;
using System.Collections.ObjectModel;
using System.Windows;

namespace Mas_Final_Project
{
    public partial class ChooseVisitList : Window
    {
        private readonly PatientService _patientService;
        private readonly DoctorService _doctorService;
        private VisitService _visitService;
        private readonly ObservableCollection<Patient> allPatients;
        private readonly ObservableCollection<Doctor> allDoctors;
        private ObservableCollection<Patient> filteredPatients;
        private ObservableCollection<Doctor> filteredDoctors;

        public ChooseVisitList()
        {
            InitializeComponent();

            _patientService = new PatientService();
            _doctorService = new DoctorService();
            allPatients = _patientService.GetPatients();
            allDoctors = _doctorService.GetDoctors();
            filteredPatients = allPatients;
            PersonDataGrid.ItemsSource = filteredPatients;
        }

        /* The method enters patients into the data grid after selecting the radio button. */
        private void PatientRadio_Check(object sender, RoutedEventArgs rEA)
        {
            filteredPatients = allPatients;
            PersonDataGrid.ItemsSource = filteredPatients;
        }

        /* The method enters doctors into the data grid after selecting the radio button. */
        private void DoctorRadio_Check(object sender, RoutedEventArgs rEA)
        {
            filteredDoctors = allDoctors;
            PersonDataGrid.ItemsSource = filteredDoctors;
        }

        /* Method that takes you to a view of all visits registered in the system. */
        private void AllVisitsButton_Click(object sender, RoutedEventArgs rEA)
        {
            new VisitList().Show();

            Close();
        }

        /* A method that takes you, after a double click, to the patient's or doctor's detailed view, 
         * depending on the selected radio button. */
        private void PersonDataGrid_DoubleClick(object sender, RoutedEventArgs rEA)
        {
            if (PatientRadio.IsChecked == true)
            {
                Patient selectedPatient = (Patient)PersonDataGrid.SelectedItem;
                new PatientDetails(selectedPatient, 2).Show();

                Close();
            }
            else if (DoctorRadio.IsChecked == true)
            {
                Doctor selectedDoktor = (Doctor)PersonDataGrid.SelectedItem;
                new DoctorDetails(selectedDoktor).Show();

                Close();
            }
        }

        /* The method, once the selected person is selected and the 'View selected' button is clicked, 
         * takes you to the view of the appointments of the selected patient or doctor depending on the radio button selected. 
         * If no person is selected, or if there are no registered appointments, we cannot display the view of a particular person's visits. */
        private void ChooseVisitButton_Click(object sender, RoutedEventArgs rEA)
        {
            if (PatientRadio.IsChecked == true)
            {
                _visitService = new VisitService();

                Patient selectedPerson = (Patient)PersonDataGrid.SelectedItem;

                if (PersonDataGrid.SelectedItem == null)
                {
                    MessageBox.Show("Please choose a person!", Title = "Warning");

                    return;
                }
                else if (!_visitService.GetVisitsView(selectedPerson))
                {
                    MessageBox.Show("The selected patient has no recorded appointments!", Title = "Warning");

                    return;
                }

                new VisitList(selectedPerson).Show();

                Close();
            }
            else if (DoctorRadio.IsChecked == true)
            {
                _visitService = new VisitService();

                Doctor selectedPerson = (Doctor)PersonDataGrid.SelectedItem;

                if (PersonDataGrid.SelectedItem == null)
                {
                    MessageBox.Show("Please choose a person!", Title = "Warning");

                    return;
                }
                else if (!_visitService.GetVisitsView(selectedPerson))
                {
                    MessageBox.Show("The selected doctor has no recorded appointments!", Title = "Warning");

                    return;
                }

                new VisitList(selectedPerson).Show();

                Close();
            }
        }

        /* The method, activated when the "Back" button is clicked, takes the user back to the home page view. */
        private void ReturnButton_Click(object sender, RoutedEventArgs rEA)
        {
            new MainPage().Show();

            Close();
        }
    }
}