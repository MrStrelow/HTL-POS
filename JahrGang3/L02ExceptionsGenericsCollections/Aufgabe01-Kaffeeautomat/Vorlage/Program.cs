using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

const int MaxVersuche = 3;

Kaffeeautomat automat = new Kaffeeautomat();

// TODO Teil 4: Prüfe und gib aus, ob der Wassertank genau diesen Automaten kennt.

// ======================= Teil 5a: Bestellungen aus der CSV-Datei =======================
string[] bestellungen = new string[0]; // TODO Teil 5a: mit LeseBestellungen("../../../bestellungen.csv") befüllen

// TODO Teil 5a: static string[] LeseBestellungen(string pfad)
//               Entscheide bei jedem Problemfall (siehe Angabe): Guard/Kontrollstruktur oder Exception?
//               Begründe deine Entscheidungen in einem Kommentar über der Methode.

// ======================= Teil 5b: Bestellungen abarbeiten =======================
// TODO Teil 5b: Arbeite die Bestellungen in einer while-Schleife ab (siehe Angabe).

// ======================= Teil 6: Benutzereingabe =======================
// TODO Teil 6: Lies mit LeseMenge ein, wie viel Gramm Bohnen nachgefüllt werden sollen,
//              fülle auf und gib den Status aus.

// TODO Teil 6: static int LeseMenge(string prompt)
//              Begründe deine Wahl (int.Parse / int.TryParse, try/catch oder nicht) in einem Kommentar.
