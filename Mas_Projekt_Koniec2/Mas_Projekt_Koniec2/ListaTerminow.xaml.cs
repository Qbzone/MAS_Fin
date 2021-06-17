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
    /// Logika interakcji dla klasy ListaTerminow.xaml
    /// </summary>
    public partial class ListaTerminow : Window
    {
        private readonly WizytaService _wizytaService;
        private readonly ObservableCollection<Wizyta> tmpWizytas;
        private ObservableCollection<Wizyta> filteredWizytas;
        private readonly Pacjent selectedPacjent;
        private readonly Procedura selectedProcedura;
        private readonly Doktor selectedDoktor;

        public ListaTerminow(Pacjent SelectedPacjent, Procedura SelectedProcedura, Doktor SelectedDoktor)
        {
            InitializeComponent();

            selectedPacjent = SelectedPacjent;
            selectedProcedura = SelectedProcedura;
            selectedDoktor = SelectedDoktor;

            DataDatePicker.SelectedDate = DateTime.Today;
            DataDatePicker.BlackoutDates.Add(new CalendarDateRange(new DateTime(2021,01,01), DateTime.Now.AddDays(-1)));

            _wizytaService = new WizytaService();
            tmpWizytas = new ObservableCollection<Wizyta>();
            _wizytaService.GetDayTermins(tmpWizytas, selectedDoktor, selectedPacjent, selectedProcedura, Convert.ToDateTime(DataDatePicker.ToString()));
            filteredWizytas = tmpWizytas;
            TerminDataGrid.ItemsSource = filteredWizytas;

            /*_doktorService = new DoktorServices();
              allDoktors = _doktorService.GetDoktors(SelectedProcedura.WymaganaSpecjalizacja);
              filteredDoktors = allDoktors;
              DoktorDataGrid.ItemsSource = filteredDoktors;*/
        }

        private void ZapiszButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedTermin = (Wizyta)TerminDataGrid.SelectedItem;
            if (TerminDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Proszę wybrać termin wizyty!", Title = "Ostrzeżenie");
                return;
            }
            _wizytaService.AddWizyta(selectedTermin);

            MessageBox.Show("Pacjent został zapisany na wizytę", Title = "Sukces");

            new StronaGlowna().Show();
            this.Close();
        }

        private void WrocButton_Click(object sender, RoutedEventArgs e)
        {
            new ListaDoktorow(selectedPacjent, selectedProcedura).Show();
            this.Close();
        }
    }
}
