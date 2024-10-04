using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EurostarAviation
{
    internal class Aircraft
    {
        // Properties
        public string Registration { get; set; }
        public string Type { get; set; }
        public string FlightNo { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }
        public string Customer { get; set; }

        public Aircraft() { } // Standardkonstruktor für XML-Serialisierung

        // Constructor
        public Aircraft(string registration, string type, string flightNo, DateTime arrival, DateTime departure, string customer)
        {
            Registration = registration;
            Type = type;
            FlightNo = flightNo;
            Arrival = arrival;
            Departure = departure;
            Customer = customer;
        }

        public void SaveToXml(string filePath, Aircraft aircraft)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Aircraft));
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fs, aircraft);
            }
        }       
        
    }
}
