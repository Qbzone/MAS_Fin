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
    /// Logika interakcji dla klasy SzczegolyWizyta.xaml
    /// </summary>
    public partial class SzczegolyWizyta : Window
    {
        private readonly WizytaService _wizytaService;
        private readonly ObservableCollection<Wizyta> allWizytas;

        public SzczegolyWizyta(Wizyta wizyta)
        {
            InitializeComponent();
            _wizytaService = new WizytaService();
            allWizytas = new ObservableCollection<Wizyta>();
            allWizytas.Add(wizyta);
            PacjentDataGrid.ItemsSource = allWizytas;
        }

        private void WrocButton_Click(object sender, RoutedEventArgs e)
        {
            new ListaPacjentow().Show();
            this.Close();
        }
    }
}
