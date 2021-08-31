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
        private int Checker;

        public SzczegolyPacjent(Pacjent pacjent, int checker)
        {
            InitializeComponent();
            _pacjentService = new PacjentService();
            allPacjents = new ObservableCollection<Pacjent>();
            allPacjents.Add(pacjent);
            PacjentDataGrid.ItemsSource = allPacjents;
            Checker = checker;
        }

        //Metoda aktywawowana po kliknięciu przycisku "Wróć", cofa uzytkownika do widoku wyboru pacjentalub wyboru wizyt
        //w zależności od tego skąd użytkownik trafił do tego widoku.
        private void WrocButton_Click(object sender, RoutedEventArgs e)
        {
            if(Checker == 1)
            {
                new ListaPacjentow().Show();
                this.Close();
            }
            else if(Checker == 2)
            {
                new ListaWizytWybor().Show();
                this.Close();
            }
        }
    }
}
