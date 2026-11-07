using System.Globalization;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

// ======================= Konstanten (Firmenregeln) =======================
const double KmProFeld = 0.5;
const double MaxGewichtKg = 5.0;
const double MaxStreckeKm = 10.0;
const double Grundgebuehr = 3.50;
const double PreisProKm = 1.20;
const double FreigewichtKg = 2.0;
const double ZuschlagProKg = 0.80;

string auftragsPfad = "../../../auftraege.txt";
string kartenPfad = "../../../stadtplan.txt";
string berichtPfad = "../../../bericht.txt";
string fehlerPfad = "../../../fehler.txt";

// ======================= Hauptprogramm =======================
// TODO Aufgabe 6: Hier alles zusammenbauen (siehe Angabe).
// Zum Testen der einzelnen Funktionen darfst du hier beliebige Aufrufe schreiben, z.B.:
// Console.WriteLine(FormatiereKunde("  mÜLLER gmbh"));


// ======================= Aufgabe 1: Auftrag zerlegen =======================

// Liest "schluessel=wert" und liefert den getrimmten Wert, wenn der Schluessel passt.
bool TryLeseFeld(string teil, string schluessel, out string wert)
{
    throw new NotImplementedException();
}

bool TryParseAuftrag(string zeile, out (string Nummer, (int X, int Y) Start, (int X, int Y) Ziel, double GewichtKg, string Kunde) auftrag, out string fehlergrund)
{
    throw new NotImplementedException();
}

// ======================= Aufgabe 2: Felder umwandeln =======================

// "lf-7" -> "LF-0007"
bool TryNormalisiereNummer(string text, out string nummer)
{
    throw new NotImplementedException();
}

// "12|3" -> (12, 3)
bool TryParseKoordinate(string text, out (int X, int Y) punkt)
{
    throw new NotImplementedException();
}

// "3,2KG" -> 3.2
bool TryParseGewicht(string text, out double gewicht)
{
    throw new NotImplementedException();
}

// "  mÜLLER gmbh" -> "Müller Gmbh"
string FormatiereKunde(string text)
{
    throw new NotImplementedException();
}

// ======================= Aufgabe 3: Strecke und Preis =======================

double BerechneDistanzFelder((int X, int Y) start, (int X, int Y) ziel)
{
    throw new NotImplementedException();
}

double BerechnePreis(double streckeKm, double gewichtKg)
{
    throw new NotImplementedException();
}

// ======================= Aufgabe 5: Stadtplan und Route =======================
// Der Stadtplan ist ein string[]: plan[y] ist eine Zeile, plan[y][x] ein einzelnes Zeichen.

bool IstImStadtplan(string[] plan, (int X, int Y) p)
{
    throw new NotImplementedException();
}

// Liegt das Feld (x|y) auf der Geraden zwischen Start und Ziel?
bool IstAufRoute((int X, int Y) start, (int X, int Y) ziel, int x, int y)
{
    throw new NotImplementedException();
}

// false, wenn ein Feld der Route eine Sperrzone '#' ist.
bool IstRouteFrei(string[] plan, (int X, int Y) start, (int X, int Y) ziel)
{
    throw new NotImplementedException();
}

// Gibt den Stadtplan mit S, Z, * (Route) und X (Route trifft Sperrzone) aus.
void ZeichneKarte(string[] plan, (int X, int Y) start, (int X, int Y) ziel)
{
    throw new NotImplementedException();
}

// ======================= Aufgabe 6: Bericht =======================

string ErzeugeKopfzeile()
{
    throw new NotImplementedException();
}

string FormatiereBerichtZeile(string nummer, string kunde, double km, double kg, double preis)
{
    throw new NotImplementedException();
}

// Liefert ein neues Array mit nur den ersten 'anzahl' Elementen.
string[] Kuerze(string[] array, int anzahl)
{
    throw new NotImplementedException();
}
