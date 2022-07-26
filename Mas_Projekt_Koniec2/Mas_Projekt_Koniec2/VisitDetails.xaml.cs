using Mas_Final_Project.Models;
using Mas_Final_Project.Services;
using System.Collections.ObjectModel;
using System.Windows;

namespace Mas_Final_Project
{
    public partial class VisitDetails : Window
    {
        private readonly VisitService _visitService;
        private readonly ObservableCollection<Visit> allVisits;
        private readonly Patient selectedPatients;
        private readonly Doctor selectedDoctors;

        public VisitDetails(Visit visit)
        {
            InitializeComponent();

            _visitService = new VisitService();
            allVisits = new ObservableCollection<Visit>();
            allVisits.Add(visit);
            VisitDataGrid.ItemsSource = allVisits;
        }

        public VisitDetails(Visit visit, Patient selectedPat)
        {
            InitializeComponent();

            selectedPatients = selectedPat;
            _visitService = new VisitService();
            allVisits = new ObservableCollection<Visit>();
            allVisits.Add(visit);
            VisitDataGrid.ItemsSource = allVisits;
        }

        public VisitDetails(Visit visit, Doctor selectedDoc)
        {
            InitializeComponent();

            selectedDoctors = selectedDoc;
            _visitService = new VisitService();
            allVisits = new ObservableCollection<Visit>();
            allVisits.Add(visit);
            VisitDataGrid.ItemsSource = allVisits;
        }

        //Metoda aktywawowana po kliknięciu przycisku "Wróć", cofa uzytkownika do widoku wizyt.
        private void ReturnButton_Click(object sender, RoutedEventArgs rEA)
        {
            if (selectedPatients != null)
            {
                new VisitList(selectedPatients).Show();

                Close();
            }
            else if (selectedDoctors != null)
            {
                new VisitList(selectedDoctors).Show();

                Close();
            }
            else
            {
                new VisitList().Show();

                Close();
            }
        }
    }
}