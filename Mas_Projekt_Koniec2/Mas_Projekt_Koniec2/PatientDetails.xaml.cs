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
    public partial class PatientDetails : Window
    {
        private readonly PatientService _patientService;
        private readonly ObservableCollection<Patient> allPatients;
        private int Checker;

        public PatientDetails(Patient patient, int checker)
        {
            InitializeComponent();
            _patientService = new PatientService();
            allPatients = new ObservableCollection<Patient>();
            allPatients.Add(patient);
            PatientDataGrid.ItemsSource = allPatients;
            Checker = checker;
        }

        //Metoda aktywawowana po kliknięciu przycisku "Wróć", cofa uzytkownika do widoku wyboru pacjentalub wyboru wizyt
        //w zależności od tego skąd użytkownik trafił do tego widoku.
        private void ReturnButton_Click(object sender, RoutedEventArgs rEA)
        {
            if(Checker == 1)
            {
                new PatientList().Show();
                this.Close();
            }
            else if(Checker == 2)
            {
                new ChooseVisitList().Show();
                this.Close();
            }
        }
    }
}