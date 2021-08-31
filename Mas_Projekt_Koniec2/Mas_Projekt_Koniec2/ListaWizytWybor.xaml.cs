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
    public partial class ListaWizytWybor : Window
    {
        private readonly PacjentService _pacjentService;
        private readonly DoktorService _doktorService;
        private WizytaService _wizytaService;
        private readonly ObservableCollection<Pacjent> allPacjents;
        private readonly ObservableCollection<Doktor> allDoktors;
        private ObservableCollection<Pacjent> filteredPacjents;
        private ObservableCollection<Doktor> filteredDoktors;

        public ListaWizytWybor()
        {
            InitializeComponent();
            _pacjentService = new PacjentService();
            _doktorService = new DoktorService();
            allPacjents = _pacjentService.GetPacjents();
            allDoktors = _doktorService.GetDoktors();
            filteredPacjents = allPacjents;
            OsobaDataGrid.ItemsSource = filteredPacjents;
        }

        //Metoda po zaznaczeniu radio button'a wprowadza do data grid'a pacjentów
        void PacjentRadio_Check(object sender, RoutedEventArgs e)
        {
            filteredPacjents = allPacjents;
            OsobaDataGrid.ItemsSource = filteredPacjents;
        }

        //Metoda po zaznaczeniu radio button'a wprowadza do data grid'a doktorów
        void DoktorRadio_Check(object sender, RoutedEventArgs e)
        {
            filteredDoktors = allDoktors;
            OsobaDataGrid.ItemsSource = filteredDoktors;
        }

        //Metoda przenosząca do widoku wszystkich wizyt zarejestrowanych w systemie
        private void WizytaWszystkieButton_Click(object sender, RoutedEventArgs e)
        {
            new ListaWizyt().Show();
            this.Close();
        }

        //Metoda przenosząca po podwójnym kliknięciu do widoku szczegółowego pacjenta, bądź lekarza
        //w zależności od zaznaczonego radio button'a
        private void OsobaDataGrid_DoubleClick(object sender, RoutedEventArgs e)
        {
            if (PacjentRadio.IsChecked == true)
            {
                var selectedPacjent = (Pacjent)OsobaDataGrid.SelectedItem;
                new SzczegolyPacjent(selectedPacjent, 2).Show();
                this.Close();
            }
            else if (DoktorRadio.IsChecked == true)
            {
                var selectedDoktor = (Doktor)OsobaDataGrid.SelectedItem;
                new SzczegolyDoktor(selectedDoktor).Show();
                this.Close();
            }
        }

        //Metoda po zaznaczeniu wybranej osoby i kliknięciu przycisku "Wyświetl wybrane" przenosi do widoku
        //wizyt wybranego pacjenta, bądź doktora w zależności od zaznaczonego radio button'a.
        //Gdyby nie wybrano żadnej osoby, bądź w razie braku zarejestrowanych terminów nie możemy wyświetlić
        //widoku wizyt konkretnej osoby.
        private void WizytaWyborButton_Click(object sender, RoutedEventArgs e)
        {
            if (PacjentRadio.IsChecked == true)
            {
                _wizytaService = new WizytaService();
                var selectedOsoba = (Pacjent)OsobaDataGrid.SelectedItem;

                if (OsobaDataGrid.SelectedItem == null)
                {
                    MessageBox.Show("Proszę wybrać osobę!", Title = "Ostrzeżenie");
                    return;
                }
                else if (!_wizytaService.GetWizytasView(selectedOsoba))
                {
                    MessageBox.Show("Wybrany pacjent nie ma zapisanych wizyt!", Title = "Ostrzeżenie");
                    return;
                }
                new ListaWizyt(selectedOsoba).Show();
                this.Close();
            }
            else if (DoktorRadio.IsChecked == true)
            {
                _wizytaService = new WizytaService();
                var selectedOsoba = (Doktor)OsobaDataGrid.SelectedItem;

                if (OsobaDataGrid.SelectedItem == null)
                {
                    MessageBox.Show("Proszę wybrać osobę!", Title = "Ostrzeżenie");
                    return;
                }
                else if (!_wizytaService.GetWizytasView(selectedOsoba))
                {
                    MessageBox.Show("Wybrany doktor nie ma zapisanych wizyt!", Title = "Ostrzeżenie");
                    return;
                }
                new ListaWizyt(selectedOsoba).Show();
                this.Close();
            }
        }

        //Metoda aktywawowana po kliknięciu przycisku "Wróć", cofa uzytkownika do widoku strony głównej.
        private void WrocButton_Click(object sender, RoutedEventArgs e)
        {
            new StronaGlowna().Show();
            this.Close();
        }
    }
}
