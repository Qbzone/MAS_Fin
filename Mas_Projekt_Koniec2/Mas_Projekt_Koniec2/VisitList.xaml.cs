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
    public partial class VisitList : Window
    {
        private readonly VisitService _visitService;
        private readonly ObservableCollection<Visit> allVisits;
        private ObservableCollection<Visit> filteredVisits;
        private readonly Patient selectedPatient;
        private readonly Doctor selectedDoctor;

        public VisitList()
        {
            InitializeComponent();
            _visitService = new VisitService();
            allVisits = _visitService.GetVisits();
            filteredVisits = allVisits;
            VisitsDataGrid.ItemsSource = filteredVisits;
        }

        public VisitList(Patient selectedPat)
        {
            InitializeComponent();
            selectedPatient = selectedPat;
            _visitService = new VisitService();
            allVisits = _visitService.GetVisits(selectedPatient);
            filteredVisits = allVisits;
            VisitsDataGrid.ItemsSource = filteredVisits;
        }

        public VisitList(Doctor selectedDoc)
        {
            InitializeComponent();
            selectedDoctor = selectedDoc;
            _visitService = new VisitService();
            allVisits = _visitService.GetVisits(selectedDoctor);
            filteredVisits = allVisits;
            VisitsDataGrid.ItemsSource = filteredVisits;
        }

        //Metoda aktywowana poprzez dwukrotne kliknięcię na danej wizyty, przenosi do widoku szczegółowego tej wizyty
        private void VisitsDataGrid_DoubleClick(object sender, RoutedEventArgs rEA)
        {
            if (selectedPatient != null)
            {
                var selectedWizyta = (Visit)VisitsDataGrid.SelectedItem;
                new VisitDetails(selectedWizyta, selectedPatient).Show();
                this.Close();
            }
            else if (selectedDoctor != null)
            {
                var selectedWizyta = (Visit)VisitsDataGrid.SelectedItem;
                new VisitDetails(selectedWizyta, selectedDoctor).Show();
                this.Close();
            }
            else
            {
                var selectedWizyta = (Visit)VisitsDataGrid.SelectedItem;
                new VisitDetails(selectedWizyta).Show();
                this.Close();
            }
        }

        //Metoda aktywawowana po kliknięciu przycisku "Wróć", cofa uzytkownika do widoku wyboru wizyt.
        private void ReturnButton_Click(object sender, RoutedEventArgs rEA)
        {
            new ChooseVisitList().Show();
            this.Close();
        }
    }
}