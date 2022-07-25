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
                this.Close();
            }
            else if (selectedDoctors != null)
            {
                new VisitList(selectedDoctors).Show();
                this.Close();
            }
            else
            {
                new VisitList().Show();
                this.Close();
            }
        }
    }
}