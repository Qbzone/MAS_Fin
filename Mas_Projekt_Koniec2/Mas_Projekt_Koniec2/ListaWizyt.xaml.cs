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
    public partial class ListaWizyt : Window
    {
        private readonly WizytaService _wizytaService;
        private readonly ObservableCollection<Wizyta> allWizytas;
        private ObservableCollection<Wizyta> filteredWizytas;

        public ListaWizyt()
        {
            InitializeComponent();
            _wizytaService = new WizytaService();
            allWizytas = _wizytaService.GetWizytas();
            filteredWizytas = allWizytas;
            WizytaDataGrid.ItemsSource = filteredWizytas;
        }

        //Metoda aktywowana poprzez dwukrotne kliknięcię na danej wizyty, przenosi do widoku szczegółowego tej wizyty
        private void WizytaDataGrid_DoubleClick(object sender, RoutedEventArgs e)
        {
            var selectedWizyta = (Wizyta)WizytaDataGrid.SelectedItem;
            new SzczegolyWizyta(selectedWizyta).Show();
            this.Close();
        }

        //Metoda aktywawowana po kliknięciu przycisku "Wróć", cofa uzytkownika do widoku strony głównej.
        private void WrocButton_Click(object sender, RoutedEventArgs e)
        {
            new StronaGlowna().Show();
            this.Close();
        }
    }
}
