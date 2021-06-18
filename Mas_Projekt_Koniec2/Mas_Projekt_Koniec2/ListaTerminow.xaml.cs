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
        private readonly Pacjent selectedPacjent;
        private readonly Procedura selectedProcedura;
        private readonly Doktor selectedDoktor;
        private readonly WizytaService _wizytaService;
        private readonly ObservableCollection<Wizyta> tmpWizytas;
        private ObservableCollection<Wizyta> filteredWizytas;

        public ListaTerminow(Pacjent SelectedPacjent, Procedura SelectedProcedura, Doktor SelectedDoktor)
        {
            InitializeComponent();

            selectedPacjent = SelectedPacjent;
            selectedProcedura = SelectedProcedura;
            selectedDoktor = SelectedDoktor;
            _wizytaService = new WizytaService();

            DataDatePicker.SelectedDate = DateTime.Today;
            DataDatePicker.BlackoutDates.Add(new CalendarDateRange(new DateTime(2021, 01, 01), DateTime.Now.AddDays(-1)));

            for (var day = DateTime.Today; day <= new DateTime(2021, 12, 31); day = day.AddDays(1))
            {
                if (day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday)
                {
                    DataDatePicker.BlackoutDates.Add(new CalendarDateRange(day));
                }
            }

            tmpWizytas = _wizytaService.GetDayTermins(selectedDoktor, selectedPacjent, selectedProcedura, Convert.ToDateTime(DataDatePicker.ToString()));

            filteredWizytas = tmpWizytas;
            TerminDataGrid.ItemsSource = filteredWizytas;
        }

        private void DataDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var textBox = (DatePicker)sender;

            filteredWizytas = _wizytaService.GetDayTermins(selectedDoktor, selectedPacjent, selectedProcedura, Convert.ToDateTime(textBox.ToString()));

            TerminDataGrid.ItemsSource = null;
            TerminDataGrid.ItemsSource = filteredWizytas;
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
