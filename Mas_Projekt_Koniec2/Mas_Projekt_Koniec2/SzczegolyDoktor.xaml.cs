using Mas_Projekt_Koniec2.Models;
using Mas_Projekt_Koniec2.Services;
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

namespace Mas_Projekt_Koniec2
{
    public partial class SzczegolyDoktor : Window
    {
        private readonly DoktorService _doktorService;
        private readonly ObservableCollection<Doktor> allDoktors;
        private readonly Pacjent selectedPacjent;
        private readonly Procedura selectedProcedura;
        private readonly ProceduraService _proceduraService;
        private readonly ObservableCollection<Procedura> allProceduras;
        private ObservableCollection<Procedura> filteredProceduras;

        public SzczegolyDoktor(Doktor doktor, Pacjent pacjent, Procedura procedura)
        {
            InitializeComponent();
            selectedPacjent = pacjent;
            selectedProcedura = procedura;

            _doktorService = new DoktorService();
            _proceduraService = new ProceduraService();

            allDoktors = new ObservableCollection<Doktor>();
            allDoktors.Add(doktor);
            DoktorDataGrid.ItemsSource = allDoktors;

            allProceduras = new ObservableCollection<Procedura>(doktor.Uprawnienia);
            filteredProceduras = allProceduras;
            ProceduraDataGrid.ItemsSource = filteredProceduras;
        }

        public SzczegolyDoktor(Doktor doktor)
        {
            InitializeComponent();

            _doktorService = new DoktorService();
            _proceduraService = new ProceduraService();

            allDoktors = new ObservableCollection<Doktor>();
            allDoktors.Add(doktor);
            DoktorDataGrid.ItemsSource = allDoktors;

            allProceduras = new ObservableCollection<Procedura>(doktor.Uprawnienia);
            filteredProceduras = allProceduras;
            ProceduraDataGrid.ItemsSource = filteredProceduras;
        }

        //Metoda aktywawowana po kliknięciu przycisku "Wróć", cofa uzytkownika do widoku wyboru doktora lub wyboru wizyt
        //w zależności od tego skąd użytkownik trafił do tego widoku.
        private void WrocButton_Click(object sender, RoutedEventArgs e)
        {
            if(selectedPacjent != null && selectedProcedura != null)
            {
                new ListaDoktorow(selectedPacjent, selectedProcedura).Show();
                this.Close();
            }
            else
            {
                new ListaWizytWybor().Show();
                this.Close();
            }
        }
    }
}
