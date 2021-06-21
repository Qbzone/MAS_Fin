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

        //Metoda aktywowana poprzez wprowadzenie/zmianę tekstu w textboxie, na podstawie zmian następuje filtracja procedur po ich nazwie
        private void NazwaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = (TextBox)sender;
            var text = textBox.Text.Trim();

            filteredProceduras = _proceduraService.GetProcedurasByNazwa(text);

            ProceduraDataGrid.ItemsSource = null;
            ProceduraDataGrid.ItemsSource = filteredProceduras;
        }

        //Metoda aktywowana po kliknięciu przycisku "Wybierz procedurę", przenosi do widoku wyboru doktora, który może przeprowadzić tą procedurę.
        //Jeśli procedura nie została wybrana, użytkownik nie może przejść dalej.
        //Jeśli w systemie nie ma doktora, który może wykonać danę procedurę, użytkownik nie może przejść dalej.
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

        //Metoda aktywawowane po kliknięciu przycisku "Wróć", cofa uzytkownika do widoku wyboru pacjenta.
        private void WrocButton_Click(object sender, RoutedEventArgs e)
        {
            new ListaPacjentow().Show();
            this.Close();
        }
    }
}
