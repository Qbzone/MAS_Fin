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
        void PatientRadio_Check(object sender, RoutedEventArgs rEA)
        {
            filteredPatients = allPatients;
            PersonDataGrid.ItemsSource = filteredPatients;
        }

        //Metoda po zaznaczeniu radio button'a wprowadza do data grid'a doktorów
        void DoctorRadio_Check(object sender, RoutedEventArgs rEA)
        {
            filteredDoctors = allDoctors;
            PersonDataGrid.ItemsSource = filteredDoctors;
        }

        //Metoda przenosząca do widoku wszystkich wizyt zarejestrowanych w systemie
        private void AllVisitsButton_Click(object sender, RoutedEventArgs rEA)
        {
            new VisitList().Show();

            this.Close();
        }

        //Metoda przenosząca po podwójnym kliknięciu do widoku szczegółowego pacjenta, bądź lekarza
        //w zależności od zaznaczonego radio button'a
        private void PersonDataGrid_DoubleClick(object sender, RoutedEventArgs rEA)
        {
            if (PatientRadio.IsChecked == true)
            {
                var selectedPatient = (Patient)PersonDataGrid.SelectedItem;
                new PatientDetails(selectedPatient, 2).Show();

                this.Close();
            }
            else if (DoctorRadio.IsChecked == true)
            {
                var selectedDoktor = (Doctor)PersonDataGrid.SelectedItem;
                new DoctorDetails(selectedDoktor).Show();

                this.Close();
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
                var selectedPerson = (Patient)PersonDataGrid.SelectedItem;

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
                this.Close();
            }
            else if (DoctorRadio.IsChecked == true)
            {
                _visitService = new VisitService();
                var selectedPerson = (Doctor)PersonDataGrid.SelectedItem;

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
                this.Close();
            }
        }

        //Metoda aktywawowana po kliknięciu przycisku "Wróć", cofa uzytkownika do widoku strony głównej.
        private void ReturnButton_Click(object sender, RoutedEventArgs rEA)
        {
            new MainPage().Show();

            this.Close();
        }
    }
}