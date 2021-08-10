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

        void PacjentRadio_Check(object sender, RoutedEventArgs e)
        {
            filteredPacjents = allPacjents;
            OsobaDataGrid.ItemsSource = filteredPacjents;
        }

        void DoktorRadio_Check(object sender, RoutedEventArgs e)
        {
            filteredDoktors = allDoktors;
            OsobaDataGrid.ItemsSource = filteredDoktors;
        }

        private void WizytaWszystkieButton_Click(object sender, RoutedEventArgs e)
        {
            new ListaWizyt().Show();
            this.Close();
        }

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

        //Metoda aktywawowane po kliknięciu przycisku "Wróć", cofa uzytkownika do widoku strony głównej.
        private void WrocButton_Click(object sender, RoutedEventArgs e)
        {
            new StronaGlowna().Show();
            this.Close();
        }
    }
}
