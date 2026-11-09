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

// ======================= Testfälle =======================
// Entferne die Kommentarzeichen /* */ eines Schritts, sobald du ihn implementiert hast.
// Vergleiche die Ausgabe mit dem erwarteten Output in der Angabe.

/* ---------- Test Schritt 1 ----------
Console.WriteLine("--- Schritt 1 ---");
Console.WriteLine(File.Exists(auftragsPfad) + " " + File.Exists(kartenPfad));
string[] testAuftraege = File.ReadAllLines(auftragsPfad);
string[] testPlan = File.ReadAllLines(kartenPfad);
Console.WriteLine(testAuftraege.Length);
Console.WriteLine(testPlan.Length + " Zeilen x " + testPlan[0].Length + " Spalten");
Console.WriteLine(testPlan[8]);
Console.WriteLine(testPlan[8][9]);
*/

/* ---------- Test Schritt 2 ----------
Console.WriteLine("--- Schritt 2 ---");
Console.WriteLine(TryLeseFeld(" NUMMER=LF-0012 ", "nummer", out string w1) + $" [{w1}]");
Console.WriteLine(TryLeseFeld("start=2|9", "ziel", out string w2) + $" [{w2}]");
Console.WriteLine(TryLeseFeld("kunde=   ", "kunde", out string w3) + $" [{w3}]");
Console.WriteLine(TryLeseFeld("kunde huber", "kunde", out string w4) + $" [{w4}]");
*/

/* ---------- Test Schritt 3 ----------
Console.WriteLine("--- Schritt 3 ---");
Console.WriteLine(TryNormalisiereNummer("lf-7", out string n1) + $" [{n1}]");
Console.WriteLine(TryNormalisiereNummer("LF-x15", out string n2) + $" [{n2}]");
Console.WriteLine(TryNormalisiereNummer("LF-12345", out string n3) + $" [{n3}]");
Console.WriteLine(TryNormalisiereNummer("lf-7", out string n4, 6) + $" [{n4}]");
Console.WriteLine(TryNormalisiereNummer("LF-12345", out string n5, 5) + $" [{n5}]");
Console.WriteLine(TryParseKoordinate("12|3", out var k1) + $" {k1}");
Console.WriteLine(TryParseKoordinate("12-3", out var k2) + $" {k2}");
Console.WriteLine(TryParseKoordinate("(5|3)", out var k3) + $" {k3}");
Console.WriteLine(TryParseGewicht("3,2KG", out double g1) + $" {g1}");
Console.WriteLine(TryParseGewicht("3,2", out double g2) + $" {g2}");
Console.WriteLine(TryParseGewicht("0kg", out double g3) + $" {g3}");
Console.WriteLine(TryParseGewicht("800g", out double g4) + $" {g4}");
Console.WriteLine(TryParseGewicht("-1kg", out double g5) + $" {g5}");
Console.WriteLine($"[{FormatiereKunde("  mÜLLER gmbh")}]");
*/

/* ---------- Test Schritt 4 ----------
Console.WriteLine("--- Schritt 4 ---");
Console.WriteLine(TryParseAuftrag("  nummer=LF-7 ; start=1|1 ; ziel=6|5 ; gewicht=1,5kg ; kunde=mÜLLER gmbh", out var a1, out string f1) + $" {a1} [{f1}]");
Console.WriteLine(TryParseAuftrag("nummer=LF-18 ; start=2|5 ; gewicht=1kg ; kunde=vergessen ohg", out var a2, out string f2) + $" [{f2}]");
Console.WriteLine(TryParseAuftrag("nummer=LF-x15 ; start=1|1 ; ziel=2|2 ; gewicht=1kg ; kunde=tippfehler ag", out var a3, out string f3) + $" [{f3}]");
Console.WriteLine(TryParseAuftrag("nummer=LF-21 ; start=(5|3) ; ziel=(11|6) ; gewicht=800g ; kunde=café   CENTRAL ;", out var a4, out string f4) + $" {a4} [{f4}]");
*/

/* ---------- Test Schritt 5 ----------
Console.WriteLine("--- Schritt 5 ---");
Console.WriteLine(BerechneDistanzFelder((1, 1), (6, 5)).ToString("0.00"));
Console.WriteLine(BerechneDistanzFelder((15, 2), (3, 2)).ToString("0.00"));
Console.WriteLine(BerechnePreis(3.2, 1.5).ToString("0.00"));
Console.WriteLine(BerechnePreis(6.0, 0.8).ToString("0.00"));
Console.WriteLine(BerechnePreis(1.0, 4.0).ToString("0.00"));
*/

/* ---------- Test Schritt 6 ----------
Console.WriteLine("--- Schritt 6 ---");
string[] testPlan2 = File.ReadAllLines(kartenPfad);
Console.WriteLine(IstImStadtplan(testPlan2, (19, 11)) + " " + IstImStadtplan(testPlan2, (20, 3)) + " " + IstImStadtplan(testPlan2, (3, -1)));
Console.WriteLine(IstAufRoute((1, 1), (6, 5), 2, 2) + " " + IstAufRoute((1, 1), (6, 5), 2, 4));
Console.WriteLine(IstAufRoute((15, 2), (3, 2), 7, 2) + " " + IstAufRoute((4, 10), (6, 1), 5, 6));
Console.WriteLine(IstRouteFrei(testPlan2, (1, 1), (6, 5)) + " " + IstRouteFrei(testPlan2, (0, 10), (19, 10)));
ZeichneKarte(testPlan2, (4, 10), (6, 1));
*/


// ======================= Hauptprogramm =======================
// TODO Schritt 7: Hier alles zusammenbauen (siehe Angabe).
// Zum Testen der einzelnen Funktionen darfst du hier beliebige Aufrufe schreiben, z.B.:
// Console.WriteLine(FormatiereKunde("  mÜLLER gmbh"));


// ======================= Schritt 2 + 4: Auftrag zerlegen =======================

// Liest "schluessel=wert" und liefert den getrimmten Wert, wenn der Schluessel passt.
bool TryLeseFeld(string teil, string schluessel, out string wert)
{
    throw new NotImplementedException();
}

bool TryParseAuftrag(string zeile, out (string Nummer, (int X, int Y) Start, (int X, int Y) Ziel, double GewichtKg, string Kunde) auftrag, out string fehlergrund)
{
    throw new NotImplementedException();
}

// ======================= Schritt 3: Felder umwandeln =======================

// "lf-7" -> "LF-0007"
bool TryNormalisiereNummer(string text, out string nummer, int stellen = 4)
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

// ======================= Schritt 5: Strecke und Preis =======================

double BerechneDistanzFelder((int X, int Y) start, (int X, int Y) ziel)
{
    throw new NotImplementedException();
}

double BerechnePreis(double streckeKm, double gewichtKg)
{
    throw new NotImplementedException();
}

// ======================= Schritt 6: Stadtplan und Route =======================
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

// ======================= Schritt 7: Bericht =======================

string ErzeugeKopfzeile(int maxKundenLaenge = 18)
{
    throw new NotImplementedException();
}

string FormatiereBerichtZeile(string nummer, string kunde, double km, double kg, double preis, int maxKundenLaenge = 18)
{
    throw new NotImplementedException();
}

// Liefert ein neues Array mit nur den ersten 'anzahl' Elementen.
string[] Kuerze(string[] array, int anzahl)
{
    throw new NotImplementedException();
}
