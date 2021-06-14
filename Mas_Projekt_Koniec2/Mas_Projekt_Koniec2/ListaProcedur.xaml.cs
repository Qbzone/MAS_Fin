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
    /// Logika interakcji dla klasy ListaProcedur.xaml
    /// </summary>
    public partial class ListaProcedur : Window
    {
        private readonly ProceduraService _proceduraService;
        private DoktorServices _doktorService;
        private readonly ObservableCollection<Procedura> allProceduras;
        private ObservableCollection<Procedura> filteredProceduras;
        private readonly Pacjent selectedPacjent;

        public ListaProcedur(Pacjent SelectedPacjent)
        {
            InitializeComponent();
            selectedPacjent = SelectedPacjent;
            _proceduraService = new ProceduraService();
            allProceduras = _proceduraService.GetProceduras();
            filteredProceduras = allProceduras;
            ProceduraDataGrid.ItemsSource = filteredProceduras;
        }

        private void NazwaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = (TextBox)sender;
            var text = textBox.Text.Trim();

            filteredProceduras = _proceduraService.GetProcedurasByNazwa(text);

            ProceduraDataGrid.ItemsSource = null;
            ProceduraDataGrid.ItemsSource = filteredProceduras;
        }

        private void ProceduraButton_Click(object sender, RoutedEventArgs e)
        {
            _doktorService = new DoktorServices();
            var selectedProcedura = (Procedura)ProceduraDataGrid.SelectedItem;

            if (ProceduraDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Proszę wybrać procedurę!", Title = "Ostrzeżenie");
                return;
            }
            else if (!_doktorService.GetDoktorsSpecjalizacja(selectedProcedura.WymaganaSpecjalizacja))
            {
                MessageBox.Show("Brak doktora mogącego przeprowadzić daną procedurę!", Title = "Ostrzeżenie");
                return;
            }

            new ListaDoktorow(selectedPacjent, selectedProcedura).Show();
            this.Close();

        }

        private void WrocButton_Click(object sender, RoutedEventArgs e)
        {
            new ListaPacjentow().Show();
            this.Close();
        }
    }
}
