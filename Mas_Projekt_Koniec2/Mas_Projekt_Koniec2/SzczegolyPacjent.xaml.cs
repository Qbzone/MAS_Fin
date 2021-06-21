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
    public partial class SzczegolyPacjent : Window
    {
        private readonly PacjentService _pacjentService;
        private readonly ObservableCollection<Pacjent> allPacjents;

        public SzczegolyPacjent(Pacjent pacjent)
        {
            InitializeComponent();
            _pacjentService = new PacjentService();
            allPacjents = new ObservableCollection<Pacjent>();
            allPacjents.Add(pacjent);
            PacjentDataGrid.ItemsSource = allPacjents;
        }

        //Metoda aktywawowana po kliknięciu przycisku "Wróć", cofa uzytkownika do widoku wyboru pacjenta.
        private void WrocButton_Click(object sender, RoutedEventArgs e)
        {
            new ListaPacjentow().Show();
            this.Close();
        }
    }
}
