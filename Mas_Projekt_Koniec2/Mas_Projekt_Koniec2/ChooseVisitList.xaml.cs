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

        //Metoda po zaznaczeniu radio button'a wprowadza do data grid'a pacjentów
        private void PatientRadio_Check(object sender, RoutedEventArgs rEA)
        {
            filteredPatients = allPatients;
            PersonDataGrid.ItemsSource = filteredPatients;
        }

        //Metoda po zaznaczeniu radio button'a wprowadza do data grid'a doktorów
        private void DoctorRadio_Check(object sender, RoutedEventArgs rEA)
        {
            filteredDoctors = allDoctors;
            PersonDataGrid.ItemsSource = filteredDoctors;
        }

        //Metoda przenosząca do widoku wszystkich wizyt zarejestrowanych w systemie
        private void AllVisitsButton_Click(object sender, RoutedEventArgs rEA)
        {
            new VisitList().Show();

            Close();
        }

        //Metoda przenosząca po podwójnym kliknięciu do widoku szczegółowego pacjenta, bądź lekarza
        //w zależności od zaznaczonego radio button'a
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

        //Metoda po zaznaczeniu wybranej osoby i kliknięciu przycisku "Wyświetl wybrane" przenosi do widoku
        //wizyt wybranego pacjenta, bądź doktora w zależności od zaznaczonego radio button'a.
        //Gdyby nie wybrano żadnej osoby, bądź w razie braku zarejestrowanych terminów nie możemy wyświetlić
        //widoku wizyt konkretnej osoby.
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

        //Metoda aktywawowana po kliknięciu przycisku "Wróć", cofa uzytkownika do widoku strony głównej.
        private void ReturnButton_Click(object sender, RoutedEventArgs rEA)
        {
            new MainPage().Show();

            Close();
        }
    }
}