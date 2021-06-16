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
    /// <summary>
    /// Logika interakcji dla klasy ListaWizyt.xaml
    /// </summary>
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


            /*_doktorService = new DoktorServices();
              allDoktors = _doktorService.GetDoktors(SelectedProcedura.WymaganaSpecjalizacja);
              filteredDoktors = allDoktors;
              DoktorDataGrid.ItemsSource = filteredDoktors;*/
        }

        private void WizytaDataGrid_DoubleClick(object sender, RoutedEventArgs e)
        {
            /*var selectedPacjent = (Pacjent)PacjentDataGrid.SelectedItem;
            new SzczegolyPacjent(selectedPacjent).Show();
            this.Close();*/
        }

        private void WrocButton_Click(object sender, RoutedEventArgs e)
        {
            new StronaGlowna().Show();
            this.Close();
        }
    }
}
