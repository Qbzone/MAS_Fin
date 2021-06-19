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
    /// Logika interakcji dla klasy StronaGlowna.xaml
    /// </summary>
    public partial class StronaGlowna : Window
    {
        private readonly PacjentService _pacjentService;
        private readonly ObservableCollection<Pacjent> allPacjents;

        public StronaGlowna()
        {
            InitializeComponent();
            _pacjentService = new PacjentService();
            allPacjents = _pacjentService.GetPacjents();
        }

        private void ZapiszButton_Click(object sender, RoutedEventArgs e)
        {
            new ListaPacjentow().Show();
            this.Close();
        }

        private void WizytaButton_Click(object sender, RoutedEventArgs e)
        {
            new ListaWizyt().Show();
            this.Close();
        }
    }
}
