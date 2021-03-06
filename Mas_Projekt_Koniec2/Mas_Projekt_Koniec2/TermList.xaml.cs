using Mas_Final_Project.Models;
using Mas_Final_Project.Services;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Mas_Final_Project
{
    public partial class TermList : Window
    {
        private readonly Patient selectedPatient;
        private readonly Procedure selectedProcedure;
        private readonly Doctor selectedDoctor;
        private readonly VisitService _visitService;
        private readonly ObservableCollection<Visit> tmpVisits;
        private ObservableCollection<Visit> filteredVisits;
        private ObservableCollection<Visit> doctorsAsPatients;

        public TermList(Patient selectedPat, Procedure selectedPro, Doctor selectedDoc)
        {
            InitializeComponent();

            selectedPatient = selectedPat;
            selectedProcedure = selectedPro;
            selectedDoctor = selectedDoc;
            _visitService = new VisitService();

            DateSetup();

            tmpVisits = _visitService.GetDayTerms(selectedDoctor, selectedPatient, selectedProcedure, Convert.ToDateTime(DatePicker.ToString()));
            filteredVisits = tmpVisits;
            TermDataGrid.ItemsSource = filteredVisits;
        }

        //Metoda aktywowana poprzez daty w datepicker'rze, na podstawie zmian następuje filtracja terminów w oparciu o wybraną dateę
        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs sCEA)
        {
            DatePicker datePicker = (DatePicker)sender;

            filteredVisits = _visitService.GetDayTerms(selectedDoctor, selectedPatient, selectedProcedure, Convert.ToDateTime(datePicker.ToString()));
            TermDataGrid.ItemsSource = null;
            TermDataGrid.ItemsSource = filteredVisits;
        }

        //Metoda aktywowana poprzez naciśnięcie przycisku "Wybierz termin", po jej aktywacji do bazy danych zostaje wprowadzona wizyta,
        //a użytkownik zostaje przeniesiony do strony głównej
        //Jeśli termin nie został wybrany, użytkownik nie może dodać wizyty.
        private void RegisterButton_Click(object sender, RoutedEventArgs rEA)
        {
            Visit selectedTermin = (Visit)TermDataGrid.SelectedItem;

            if (TermDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Please select your appointment!", Title = "Warning");

                return;
            }

            _visitService.AddVisit(selectedTermin);

            MessageBox.Show("The patient has been registered for an appointment", Title = "Success");

            new MainPage().Show();

            Close();
        }

        //Metoda aktywawowana po kliknięciu przycisku "Wróć", cofa uzytkownika do widoku wyboru doktora.
        private void ReturnButton_Click(object sender, RoutedEventArgs rEA)
        {
            new DoctorList(selectedPatient, selectedProcedure).Show();

            Close();
        }

        //Metoda służąca do blokowania nie chcianych dat w datepicker'rze
        //Blokowane do wyboru są date ubiegłe oraz dni weekendowe
        //Dodatkowo jeśli zapis jest przeprowadzany w dzień weekendowy domyślna data zapisu jest przesuwana na następny poniedziałek.
        private void DateSetup()
        {
            DatePicker.SelectedDate = DateTime.Today.DayOfWeek == DayOfWeek.Saturday
                ? DateTime.Today.AddDays(2)
                : DateTime.Today.DayOfWeek == DayOfWeek.Sunday ? DateTime.Today.AddDays(1) : DateTime.Today;

            DatePicker.BlackoutDates.Add(new CalendarDateRange(new DateTime(2021, 01, 01), DateTime.Now.AddDays(-1)));

            for (DateTime day = DateTime.Today; day <= new DateTime(2021, 12, 31); day = day.AddDays(1))
            {
                if (day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday)
                {
                    DatePicker.BlackoutDates.Add(new CalendarDateRange(day));
                }

            }
        }
    }
}