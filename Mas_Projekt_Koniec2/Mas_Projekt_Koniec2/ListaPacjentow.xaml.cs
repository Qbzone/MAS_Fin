﻿using Mas_Projekt_Koniec2.Models;
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
    public partial class ListaPacjentow : Window
    {
        private readonly PacjentService _pacjentService;
        private readonly ObservableCollection<Pacjent> allPacjents;
        private ObservableCollection<Pacjent> filteredPacjents;

        public ListaPacjentow()
        {
            InitializeComponent();
            _pacjentService = new PacjentService();
            allPacjents = _pacjentService.GetPacjents();
            filteredPacjents = allPacjents;
            PacjentDataGrid.ItemsSource = filteredPacjents;
        }

        //Metoda aktywowana poprzez wprowadzenie/zmianę tekstu w textboxie, na podstawie zmian następuje filtracja pacjentów po numerze pesel
        private void PeselTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = (TextBox)sender;
            var text = textBox.Text.Trim();

            filteredPacjents = _pacjentService.GetPacjentsByPesel(text);

            PacjentDataGrid.ItemsSource = null;
            PacjentDataGrid.ItemsSource = filteredPacjents;
        }

        //Metoda aktywowana poprzez dwukrotne kliknięcię na danego pacjenta, przenosi do widoku szczegółowego tej osoby
        private void PacjentDataGrid_DoubleClick(object sender, RoutedEventArgs e)
        {
            var selectedPacjent = (Pacjent)PacjentDataGrid.SelectedItem;
            new SzczegolyPacjent(selectedPacjent, 1).Show();
            this.Close();
        }

        //Metoda aktywowana po kliknięciu przycisku "Wybierz pacjenta", przenosi do widoku wyboru procedury dla wybranego pacjenta.
        //Jeśli pacjent nie zostal wybrany, użytkownik nie może przejść dalej.
        //Jeśli pacjent nie posiada ubezpieczenia zdrowotnego lub pakietu medycznego, użytkownik nie może przejść dalej
        private void PacjentButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedPacjent = (Pacjent)PacjentDataGrid.SelectedItem;
            if (PacjentDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Proszę wybrać pacjenta!", Title = "Ostrzeżenie");
                return;
            }
            else if (selectedPacjent.UbezpiecznieZdrowotne == false && selectedPacjent.PakietMedycznyId == null)
            {
                MessageBox.Show("Wybrany pacjent nie posiada ubezpieczenia zdrowotnego, ani pakietu medycznego! Nie może zostać zapisany na wizytę!", Title = "Ostrzeżenie");
                return;
            }
            new ListaProcedur(selectedPacjent).Show();
            this.Close();
        }

        //Metoda aktywawowane po kliknięciu przycisku "Wróć", cofa uzytkownika do widoku strony głównej.
        private void WrocButton_Click(object sender, RoutedEventArgs e)
        {
            new StronaGlowna().Show();
            this.Close();
        }
    }
}
