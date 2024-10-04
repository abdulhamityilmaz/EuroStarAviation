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
    /// Interaction logic for PersonnelPage.xaml
    /// </summary>
    public partial class PersonnelPage : Page
    {
        public PersonnelPage()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {

            // Überprüfe, ob alle Felder ausgefüllt wurden
            if (string.IsNullOrWhiteSpace(VornameTextBox.Text) ||
                string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("Please name and surname!", "Wrong", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Erstelle ein Personnel-Objekt mit den eingegebenen Daten
            Personnel newPersonnel = new Personnel
            {
                Vorname = VornameTextBox.Text,
                Name = NameTextBox.Text,
                Position = PositionTextBox.Text,
                Abteilung = AbteilungTextBox.Text,
                Einstellungsdatum = EinstellungsdatumPicker.SelectedDate.HasValue ? EinstellungsdatumPicker.SelectedDate.Value : DateTime.Now,
                Qualifikationen = QualifikationenTextBox.Text,
                Personalnummer = PersonalnummerTextBox.Text,
                Kontakt = KontaktTextBox.Text
            };

            // Speichere die Daten als JSON
            string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "personnel_data.json");
            try
            {
                // Konvertiere das Objekt in JSON
                string jsonData = JsonSerializer.Serialize(newPersonnel);                
                File.AppendAllText(filePath, jsonData + Environment.NewLine);                
                this.NavigationService.Navigate(new AircraftInformation());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Speichern der Daten: {ex.Message}", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
