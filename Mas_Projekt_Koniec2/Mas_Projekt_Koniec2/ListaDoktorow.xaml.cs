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
    public partial class ListaDoktorow : Window
    {
        private readonly DoktorServices _doktorService;
        private readonly ObservableCollection<Doktor> allDoktors;
        private ObservableCollection<Doktor> filteredDoktors;
        private readonly Pacjent selectedPacjent;
        private readonly Procedura selectedProcedura;

        public ListaDoktorow(Pacjent SelectedPacjent, Procedura SelectedProcedura)
        {
            InitializeComponent();
            selectedPacjent = SelectedPacjent;
            selectedProcedura = SelectedProcedura;
            _doktorService = new DoktorServices();
            allDoktors = _doktorService.GetDoktors(SelectedProcedura.Id, SelectedPacjent.Osoba.NumerPesel);
            filteredDoktors = allDoktors;
            DoktorDataGrid.ItemsSource = filteredDoktors;
        }

        //Metoda aktywowana poprzez wprowadzenie/zmianę tekstu w textboxie, na podstawie zmian następuje filtracja doktorów po nazwisku
        private void NazwiskoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = (TextBox)sender;
            var text = textBox.Text.Trim();

            filteredDoktors = _doktorService.GetDoktorsByNazwisko(text);

            DoktorDataGrid.ItemsSource = null;
            DoktorDataGrid.ItemsSource = filteredDoktors;
        }

        //Metoda aktywowana poprzez dwukrotne kliknięcię na danego doktora, przenosi do widoku szczegółowego tej osoby
        private void DoktorDataGrid_DoubleClick(object sender, RoutedEventArgs e)
        {
            var selectedDoktor = (Doktor)DoktorDataGrid.SelectedItem;
            new SzczegolyDoktor(selectedDoktor, selectedPacjent, selectedProcedura).Show();
            this.Close();
        }

        //Metoda aktywowana po kliknięciu przycisku "Wybierz doktora", przenosi do widoku terminów wybranego doktora.
        //Jeśli doktor nie zostal wybrany, użytkownik nie może przejść dalej.
        private void DoktorButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedDoktor = (Doktor)DoktorDataGrid.SelectedItem;
            if (DoktorDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Proszę wybrać doktora!", Title = "Ostrzeżenie");
                return;
            }
            new ListaTerminow(selectedPacjent, selectedProcedura, selectedDoktor).Show();
            this.Close();
        }

        //Metoda aktywawowane po kliknięciu przycisku "Wróć", cofa uzytkownika do widoku wyboru procedur.
        private void WrocButton_Click(object sender, RoutedEventArgs e)
        {
            new ListaProcedur(selectedPacjent).Show();
            this.Close();
        }
    }
}
