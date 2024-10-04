using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace EurostarAviation
{
    /// <summary>
    /// Interaction logic for AircraftInformation.xaml
    /// </summary>
    public partial class AircraftInformation : Page
    {
        public AircraftInformation()
        {
            InitializeComponent();           
                    
        }        

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            // Hole die Werte aus den Eingabefeldern
            string registration = RegistrationTextBox.Text;
            string type = TypeTextBox.Text;
            string flightNo = FlightNoTextBox.Text;
            DateTime? arrival = ArrivalDatePicker.SelectedDate;
            DateTime? departure = DepartureDatePicker.SelectedDate;
            string customer = CustomerTextBox.Text;

            // Überprüfe, ob alle Felder ausgefüllt wurden
            if (string.IsNullOrWhiteSpace(registration) ||
                string.IsNullOrWhiteSpace(type) ||
                string.IsNullOrWhiteSpace(flightNo) ||
                arrival == null || departure == null || customer == null)
            {
                MessageBox.Show("Bitte alle Felder ausfüllen!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            // Hier kannst du die Daten weiter verarbeiten, zum Beispiel in einem Aircraft-Objekt speichern
            Aircraft aircraft = new Aircraft(registration, type, flightNo, arrival.GetValueOrDefault(), departure.GetValueOrDefault(), customer);

            // Speichere die Daten als JSON
            string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "aircraft_data.json");
            try
            {
                // Konvertiere das Objekt in JSON
                string jsonData = JsonSerializer.Serialize(aircraft);                
                File.AppendAllText(filePath, jsonData + Environment.NewLine);
                MessageBox.Show("Data successfully saved in JSON!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.NavigationService.Navigate(new SummaryPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error on saving: {ex.Message}", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }        
    }
}
