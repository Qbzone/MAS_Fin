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

        /* Method activated via dates in the datepicker, based on the changes, the dates are filtered based on the selected date. */
        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs sCEA)
        {
            DatePicker datePicker = (DatePicker)sender;

            filteredVisits = _visitService.GetDayTerms(selectedDoctor, selectedPatient, selectedProcedure, Convert.ToDateTime(datePicker.ToString()));
            TermDataGrid.ItemsSource = null;
            TermDataGrid.ItemsSource = filteredVisits;
        }

        /* Activated by pressing the "Select appointment" button, once activated, the appointment is entered into the database and the user is taken to the home page. 
         * If an appointment has not been selected, the user cannot add a visit. */
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

        /* The method, which is activated when the " Return" button is clicked, takes the user back to the doctor selection view. */
        private void ReturnButton_Click(object sender, RoutedEventArgs rEA)
        {
            new DoctorList(selectedPatient, selectedProcedure).Show();

            Close();
        }

        /* Method for blocking unwanted dates in the datepicker. 
         * Previous dates and weekend days are blocked. 
         * In addition, if a save is made on a weekend day, the default save date is moved to the following Monday. */
        private void DateSetup()
        {
            DatePicker.SelectedDate = DateTime.Today.DayOfWeek == DayOfWeek.Saturday
                ? DateTime.Today.AddDays(2)
                : DateTime.Today.DayOfWeek == DayOfWeek.Sunday ? DateTime.Today.AddDays(1) : DateTime.Today;

            DatePicker.BlackoutDates.Add(new CalendarDateRange(new DateTime(2021, 01, 01), DateTime.Now.AddDays(-1)));

            for (DateTime day = DateTime.Today; day <= new DateTime(2021, 12, 31); day = day.AddDays(1))
            {
                if (day.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
                {
                    DatePicker.BlackoutDates.Add(new CalendarDateRange(day));
                }

            }
        }
    }
}