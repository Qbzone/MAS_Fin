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
        private readonly Pacjent selectedPacjent;
        private readonly Procedura selectedProcedura;
        private readonly Doktor selectedDoktor;

        public ListaTerminow(Pacjent SelectedPacjent, Procedura SelectedProcedura, Doktor SelectedDoktor)
        {
            InitializeComponent();
            selectedPacjent = SelectedPacjent;
            selectedProcedura = SelectedProcedura;
            selectedDoktor = SelectedDoktor;
            _wizytaService = new WizytaService();
            tmpWizytas = new ObservableCollection<Wizyta>();
            DateTime Start = new DateTime(2021, 06, 16, 08, 00, 00);
            for (int i = 0; i < 16; i++)
            {
                DateTime Koniec = Start.AddMinutes(29);
                Wizyta tmpTermin = new Wizyta() { PoczatekWizyty = Start, KoniecWizyty = Koniec, StatusWizyta = Wizyta.StatusWizyty.CREATED, DoktorId = selectedDoktor.Id, PacjentId = selectedPacjent.Id, ProceduraId = selectedProcedura.Id };
                tmpWizytas.Add(tmpTermin);
                Start = Start.AddMinutes(30);
            }
            TerminDataGrid.ItemsSource = tmpWizytas;

            /*_doktorService = new DoktorServices();
              allDoktors = _doktorService.GetDoktors(SelectedProcedura.WymaganaSpecjalizacja);
              filteredDoktors = allDoktors;
              DoktorDataGrid.ItemsSource = filteredDoktors;*/
        }

        private void DataTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            /*var textBox = (TextBox)sender;
            var text = textBox.Text.Trim();

            filteredDoktors = _doktorService.GetDoktorsByNazwisko(text);

            DoktorDataGrid.ItemsSource = null;
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
            new ListaProcedur(selectedPacjent).Show();
            this.Close();
        }
    }
}
