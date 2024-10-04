using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace EurostarAviation
{
    /// <summary>
    /// Interaction logic for SummaryPage.xaml
    /// </summary>
    public partial class SummaryPage : Page
    {
        public SummaryPage()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            string aircraftFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "aircraft_data.json");
            string personnelFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "personnel_data.json");

            // Load Aircraft Data
            if (File.Exists(aircraftFilePath))
            {
                var aircrafts = new List<Aircraft>();
                var aircraftJsonLines = File.ReadAllLines(aircraftFilePath);

                foreach (var line in aircraftJsonLines)
                {
                    var aircraft = JsonConvert.DeserializeObject<Aircraft>(line);
                    if (aircraft != null)
                    {
                        aircrafts.Add(aircraft);
                    }
                }

                AircraftListView.ItemsSource = aircrafts;
            }

            // Load Personnel Data (assuming it is in a similar format)
            if (File.Exists(personnelFilePath))
            {
                var personnels = new List<Personnel>();
                var personnelJsonLines = File.ReadAllLines(personnelFilePath);

                foreach (var line in personnelJsonLines)
                {
                    var personnel = JsonConvert.DeserializeObject<Personnel>(line);
                    if (personnel != null)
                    {
                        personnels.Add(personnel);
                    }
                }

                PersonnelListView.ItemsSource = personnels;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new HomePage());
        }
    }
}
