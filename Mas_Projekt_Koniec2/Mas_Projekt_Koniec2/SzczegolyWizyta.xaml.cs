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
    public partial class SzczegolyWizyta : Window
    {
        private readonly WizytaService _wizytaService;
        private readonly ObservableCollection<Wizyta> allWizytas;
        private readonly Pacjent selectedPacjent;
        private readonly Doktor selectedDoktor;

        public SzczegolyWizyta(Wizyta wizyta)
        {
            InitializeComponent();
            _wizytaService = new WizytaService();
            allWizytas = new ObservableCollection<Wizyta>();
            allWizytas.Add(wizyta);
            WizytaDataGrid.ItemsSource = allWizytas;
        }

        public SzczegolyWizyta(Wizyta wizyta, Pacjent SelectedPacjent)
        {
            InitializeComponent();
            selectedPacjent = SelectedPacjent;
            _wizytaService = new WizytaService();
            allWizytas = new ObservableCollection<Wizyta>();
            allWizytas.Add(wizyta);
            WizytaDataGrid.ItemsSource = allWizytas;
        }

        public SzczegolyWizyta(Wizyta wizyta, Doktor SelectedDoktor)
        {
            InitializeComponent();
            selectedDoktor = SelectedDoktor;
            _wizytaService = new WizytaService();
            allWizytas = new ObservableCollection<Wizyta>();
            allWizytas.Add(wizyta);
            WizytaDataGrid.ItemsSource = allWizytas;
        }

        //Metoda aktywawowana po kliknięciu przycisku "Wróć", cofa uzytkownika do widoku wizyt.
        private void WrocButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedPacjent != null)
            {
                new ListaWizyt(selectedPacjent).Show();
                this.Close();
            }
            else if (selectedDoktor != null)
            {
                new ListaWizyt(selectedDoktor).Show();
                this.Close();
            }
            else
            {
                new ListaWizyt().Show();
                this.Close();
            }
        }
    }
}
