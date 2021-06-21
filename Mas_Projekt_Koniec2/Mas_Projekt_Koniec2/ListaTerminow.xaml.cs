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
    public partial class ListaTerminow : Window
    {
        private readonly Pacjent selectedPacjent;
        private readonly Procedura selectedProcedura;
        private readonly Doktor selectedDoktor;
        private readonly WizytaService _wizytaService;
        private readonly ObservableCollection<Wizyta> tmpWizytas;
        private ObservableCollection<Wizyta> filteredWizytas;
        private ObservableCollection<Wizyta> doktorsAsPacjents;

        public ListaTerminow(Pacjent SelectedPacjent, Procedura SelectedProcedura, Doktor SelectedDoktor)
        {
            InitializeComponent();

            selectedPacjent = SelectedPacjent;
            selectedProcedura = SelectedProcedura;
            selectedDoktor = SelectedDoktor;
            _wizytaService = new WizytaService();

            DateSetup();
            tmpWizytas = _wizytaService.GetDayTermins(selectedDoktor, selectedPacjent, selectedProcedura, Convert.ToDateTime(DataDatePicker.ToString()));

            filteredWizytas = tmpWizytas;
            TerminDataGrid.ItemsSource = filteredWizytas;
        }

        //Metoda aktywowana poprzez daty w datepicker'rze, na podstawie zmian następuje filtracja terminów w oparciu o wybraną dateę
        private void DataDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var datePicker = (DatePicker)sender;

            filteredWizytas = _wizytaService.GetDayTermins(selectedDoktor, selectedPacjent, selectedProcedura, Convert.ToDateTime(datePicker.ToString()));

            TerminDataGrid.ItemsSource = null;
            TerminDataGrid.ItemsSource = filteredWizytas;
        }

        //Metoda aktywowana poprzez naciśnięcie przycisku "Wybierz termin", po jej aktywacji do bazy danych zostaje wprowadzona wizyta,
        //a użytkownik zostaje przeniesiony do strony głównej
        //Jeśli termin nie został wybrany, użytkownik nie może dodać wizyty.
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

        //Metoda aktywawowana po kliknięciu przycisku "Wróć", cofa uzytkownika do widoku wyboru doktora.
        private void WrocButton_Click(object sender, RoutedEventArgs e)
        {
            new ListaDoktorow(selectedPacjent, selectedProcedura).Show();
            this.Close();
        }

        //Metoda służąca do blokowania nie chcianych dat w datepicker'rze
        //Blokowane do wyboru są date ubiegłe oraz dni weekendowe
        //Dodatkowo jeśli zapis jest przeprowadzany w dzień weekendowy domyślna data zapisu jest przesuwana na następny poniedziałek.
        private void DateSetup()
        {
            if (DateTime.Today.DayOfWeek == DayOfWeek.Saturday)
            {
                DataDatePicker.SelectedDate = DateTime.Today.AddDays(2);
            }
            else if (DateTime.Today.DayOfWeek == DayOfWeek.Sunday)
            {
                DataDatePicker.SelectedDate = DateTime.Today.AddDays(1);
            }
            else
            {
                DataDatePicker.SelectedDate = DateTime.Today;
            }

            DataDatePicker.BlackoutDates.Add(new CalendarDateRange(new DateTime(2021, 01, 01), DateTime.Now.AddDays(-1)));

            for (var day = DateTime.Today; day <= new DateTime(2021, 12, 31); day = day.AddDays(1))
            {
                if (day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday)
                {
                    DataDatePicker.BlackoutDates.Add(new CalendarDateRange(day));
                }

            }
        }
    }
}
