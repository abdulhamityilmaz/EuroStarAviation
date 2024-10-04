using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EurostarAviation
{
    class Personnel
    {
        // Name und Vorname des Personals
        public string Vorname { get; set; }
        public string Name { get; set; }

        // Zusatzfelder
        public string Position { get; set; }           // Die Position des Mitarbeiters, z.B. "Mechaniker", "Techniker"
        public string Abteilung { get; set; }          // Die Abteilung, in der der Mitarbeiter arbeitet, z.B. "Wartung"
        public DateTime Einstellungsdatum { get; set; } // Wann der Mitarbeiter eingestellt wurde
        public string Qualifikationen { get; set; }    // Qualifikationen oder Zertifikate, die der Mitarbeiter besitzt
        public string Personalnummer { get; set; }     // Eine eindeutige Personalnummer für den Mitarbeiter
        public string Kontakt { get; set; }            // Kontaktdaten, z.B. Telefonnummer oder E-Mail-Adresse

        // Standardkonstruktor
        public Personnel() { }

        // Konstruktor mit Parametern
        public Personnel(string vorname, string name, string position, string abteilung, DateTime einstellungsdatum, string qualifikationen, string personalnummer, string kontakt)
        {
            Vorname = vorname;
            Name = name;
            Position = position;
            Abteilung = abteilung;
            Einstellungsdatum = einstellungsdatum;
            Qualifikationen = qualifikationen;
            Personalnummer = personalnummer;
            Kontakt = kontakt;
        }

        public Personnel(string vorname, string name)
        {
            Vorname= vorname;
            Name= name;
        }
    }
}
