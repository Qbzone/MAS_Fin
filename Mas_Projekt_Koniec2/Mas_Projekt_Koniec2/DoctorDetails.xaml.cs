using Mas_Final_Project.Models;
using Mas_Final_Project.Services;
using System.Collections.ObjectModel;
using System.Windows;

namespace Mas_Final_Project
{
    public partial class DoctorDetails : Window
    {
        private readonly DoctorService _doctorService;
        private readonly ProcedureService _procedureService;
        private readonly Patient selectedPatient;
        private readonly Procedure selectedProcedure;
        private readonly ObservableCollection<Doctor> allDoctors;
        private readonly ObservableCollection<Procedure> allProcedures;
        private ObservableCollection<Procedure> filteredProcedures;

        public DoctorDetails(Doctor doctor, Patient patient, Procedure procedure)
        {
            InitializeComponent();

            selectedPatient = patient;
            selectedProcedure = procedure;
            _doctorService = new DoctorService();
            _procedureService = new ProcedureService();
            allDoctors = new ObservableCollection<Doctor>();
            allDoctors.Add(doctor);
            DoctorDataGrid.ItemsSource = allDoctors;
            allProcedures = new ObservableCollection<Procedure>(doctor.Entitlements);
            filteredProcedures = allProcedures;
            ProcedureDataGrid.ItemsSource = filteredProcedures;
        }

        public DoctorDetails(Doctor doctor)
        {
            InitializeComponent();

            _doctorService = new DoctorService();
            _procedureService = new ProcedureService();
            allDoctors = new ObservableCollection<Doctor>();
            allDoctors.Add(doctor);
            DoctorDataGrid.ItemsSource = allDoctors;
            allProcedures = new ObservableCollection<Procedure>(doctor.Entitlements);
            filteredProcedures = allProcedures;
            ProcedureDataGrid.ItemsSource = filteredProcedures;
        }

        //Metoda aktywawowana po kliknięciu przycisku "Wróć", cofa uzytkownika do widoku wyboru doktora lub wyboru wizyt
        //w zależności od tego skąd użytkownik trafił do tego widoku.
        private void ReturnButton_Click(object sender, RoutedEventArgs rEA)
        {
            if (selectedPatient != null && selectedProcedure != null)
            {
                new DoctorList(selectedPatient, selectedProcedure).Show();

                Close();
            }
            else
            {
                new ChooseVisitList().Show();

                Close();
            }
        }
    }
}