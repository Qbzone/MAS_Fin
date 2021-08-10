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
    public partial class SzczegolyDoktor : Window
    {
        private readonly DoktorService _doktorService;
        private readonly ObservableCollection<Doktor> allDoktors;
        private readonly Pacjent selectedPacjent;
        private readonly Procedura selectedProcedura;

        public SzczegolyDoktor(Doktor doktor, Pacjent pacjent, Procedura procedura)
        {
            InitializeComponent();
            selectedPacjent = pacjent;
            selectedProcedura = procedura;
            _doktorService = new DoktorService();
            allDoktors = new ObservableCollection<Doktor>();
            allDoktors.Add(doktor);
            DoktorDataGrid.ItemsSource = allDoktors;
        }

        //Metoda aktywawowana po kliknięciu przycisku "Wróć", cofa uzytkownika do widoku wyboru doktora.
        private void WrocButton_Click(object sender, RoutedEventArgs e)
        {
            new ListaDoktorow(selectedPacjent, selectedProcedura).Show();
            this.Close();
        }
    }
}
