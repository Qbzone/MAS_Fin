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
    /// <summary>
    /// Logika interakcji dla klasy ListaDoktorow.xaml
    /// </summary>
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
            allDoktors = _doktorService.GetDoktors(SelectedProcedura.WymaganaSpecjalizacja);
            filteredDoktors = allDoktors;
            DoktorDataGrid.ItemsSource = filteredDoktors;
        }

        private void NazwiskoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = (TextBox)sender;
            var text = textBox.Text.Trim();

            filteredDoktors = _doktorService.GetDoktorsByNazwisko(text);

            DoktorDataGrid.ItemsSource = null;
            DoktorDataGrid.ItemsSource = filteredDoktors;
        }

        private void DoktorDataGrid_DoubleClick(object sender, RoutedEventArgs e)
        {
            var selectedDoktor = (Doktor)DoktorDataGrid.SelectedItem;
            new SzczegolyDoktor(selectedDoktor, selectedPacjent, selectedProcedura).Show();
            this.Close();
        }

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

        private void WrocButton_Click(object sender, RoutedEventArgs e)
        {
            new ListaProcedur(selectedPacjent).Show();
            this.Close();
        }
    }
}