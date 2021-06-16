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
    /// Logika interakcji dla klasy SzczegolyDoktor.xaml
    /// </summary>
    public partial class SzczegolyDoktor : Window
    {
        private readonly DoktorServices _doktorService;
        private readonly ObservableCollection<Doktor> allDoktors;
        private readonly Pacjent selectedPacjent;
        private readonly Procedura selectedProcedura;

        public SzczegolyDoktor(Doktor doktor, Pacjent pacjent, Procedura procedura)
        {
            InitializeComponent();
            selectedPacjent = pacjent;
            selectedProcedura = procedura;
            _doktorService = new DoktorServices();
            allDoktors = new ObservableCollection<Doktor>();
            allDoktors.Add(doktor);
            DoktorDataGrid.ItemsSource = allDoktors;
        }

        private void WrocButton_Click(object sender, RoutedEventArgs e)
        {
            new ListaDoktorow(selectedPacjent, selectedProcedura).Show();
            this.Close();
        }
    }
}