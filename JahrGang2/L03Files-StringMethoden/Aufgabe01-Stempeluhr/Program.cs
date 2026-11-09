using System.Text;

Console.OutputEncoding = Encoding.UTF8;

string eingabePfad = "../../../stempelzeiten.txt";
string ausgabePfad = "../../../arbeitszeiten.txt";

// ======================= Testfälle =======================
// Entferne die Kommentarzeichen /* */ eines Schritts, sobald du ihn implementiert hast.
// Vergleiche die Ausgabe mit dem erwarteten Output in der Angabe.

/* ---------- Test Schritt 1 ----------
Console.WriteLine("--- Schritt 1 ---");
Console.WriteLine(File.Exists(eingabePfad));
Console.WriteLine(File.Exists("../../../gibtsnicht.txt"));
string[] testZeilen = File.ReadAllLines(eingabePfad);
Console.WriteLine(testZeilen.Length);
Console.WriteLine($"[{testZeilen[5]}]");
*/

/* ---------- Test Schritt 2 ----------
Console.WriteLine("--- Schritt 2 ---");
Console.WriteLine($"[{ErzeugeUeberschrift("Menü", '<', '>', 5)}]");
Console.WriteLine($"[{ErzeugeUeberschrift("  Charts ", 'o', 'o', 3)}]");
Console.WriteLine($"[{ErzeugeUeberschrift("Tabelle", '!', '!', 0)}]");
Console.WriteLine($"[{ErzeugeUeberschrift("Tabelle", '!', '!', -1)}]");
Console.WriteLine($"[{ErzeugeUeberschrift("   ", '-', '-', 2)}]");
Console.WriteLine($"[{ErzeugeUeberschrift("Pause")}]");
Console.WriteLine($"[{ErzeugeUeberschrift("Pause", '*', '*')}]");
*/

/* ---------- Test Schritt 3 ----------
Console.WriteLine("--- Schritt 3 ---");
Console.WriteLine(ZeitInMinuten("7:30"));
Console.WriteLine(ZeitInMinuten(" 12:00 "));
Console.WriteLine(ZeitInMinuten("12:x0"));
Console.WriteLine(ZeitInMinuten("8:5"));
Console.WriteLine(ZeitInMinuten("25:00"));
Console.WriteLine(ZeitInMinuten("1230"));
Console.WriteLine(ZeitInMinuten("7.45"));
Console.WriteLine(ZeitInMinuten("12,30"));
*/

/* ---------- Test Schritt 4 ----------
Console.WriteLine("--- Schritt 4 ---");
Console.WriteLine(DauerInMinuten("7:30-12:00"));
Console.WriteLine(DauerInMinuten(" 12:30-16:15 "));
Console.WriteLine(DauerInMinuten("13:00-12:00"));
Console.WriteLine(DauerInMinuten("8:00"));
Console.WriteLine(SummiereZeiten("anna ; 7:30-12:00 ; 12:30-16:15".Split(';')));
Console.WriteLine(SummiereZeiten("tom ; 8:00-12:x0".Split(';')));
Console.WriteLine(SummiereZeiten("kaya".Split(';')));
Console.WriteLine(SummiereZeiten("weber ; 8:00-12:00 ;".Split(';')));
Console.WriteLine(SummiereZeiten("fuchs ; 8:00-12:00 ; 11:30-15:00".Split(';')));
*/

/* ---------- Test Schritt 5 ----------
Console.WriteLine("--- Schritt 5 ---");
Console.WriteLine($"[{FormatiereName("  mÜLLER anna ")}]");
Console.WriteLine($"[{FormatiereName("HUBER   max")}]");
Console.WriteLine(FormatiereDauer(495));
Console.WriteLine(FormatiereDauer(240));
Console.WriteLine(FormatiereDauer(5));
Console.WriteLine(BerechneSpaltenbreite(new string[] { "Huber Max", "Steiner Paul", "Weber Jana" }));
Console.WriteLine(BerechneSpaltenbreite(new string[] { "Anna", new string('x', 300), "Huber Max" }));
Console.WriteLine(BerechneSpaltenbreite(new string[] { "Huber Max", "Steiner Paul", "Weber Jana" }, 10));
Console.WriteLine($"[{FormatiereZeile("Huber Max", 240, 12)}]");
Console.WriteLine($"[{FormatiereZeile("Bartholomäus Der Zweite", 240, 12)}]");
*/


// ======================= Schritt 6: Hauptprogramm =======================
// TODO: Siehe Angabe. Zum Testen der einzelnen Funktionen darfst du hier beliebige Aufrufe schreiben, z.B.:
// Console.WriteLine(ErzeugeUeberschrift("Menü", '<', '>', 5));


// ======================= Schritt 2: Ueberschrift =======================

// <n-mal links> + <s in Grossbuchstaben, getrimmt> + <n-mal rechts>
// Default-Parameter: ohne Angabe 10-mal '=' links und rechts
string ErzeugeUeberschrift(string s, char links = '=', char rechts = '=', int n = 10)
{
    throw new NotImplementedException();
}

// ======================= Schritt 3: Uhrzeit umrechnen =======================

// "7:30" -> 450 Minuten seit Mitternacht, -1 bei ungueltiger Uhrzeit
int ZeitInMinuten(string text)
{
    throw new NotImplementedException();
}

// ======================= Schritt 4: Zeitbereich =======================

// "7:30-12:00" -> 270, -1 bei ungueltigem Bereich
int DauerInMinuten(string bereich)
{
    throw new NotImplementedException();
}

// teile[0] ist der Name, alle weiteren Teile sind Zeitbereiche. -1 wenn etwas ungueltig ist.
int SummiereZeiten(string[] teile)
{
    throw new NotImplementedException();
}

// ======================= Schritt 5: Formatieren =======================

// "  mÜLLER anna " -> "Müller Anna"
string FormatiereName(string text)
{
    throw new NotImplementedException();
}

// 495 -> "8:15"
string FormatiereDauer(int minuten)
{
    throw new NotImplementedException();
}

// Laenge des laengsten Namens; ist er laenger als MaxNamenLaenge (Standard: 255), die des zweitlaengsten
int BerechneSpaltenbreite(string[] namen, int MaxNamenLaenge = 255)
{
    throw new NotImplementedException();
}

// ("Huber Max", 240, 12) -> "Huber Max         4:00 h"; zu lange Namen werden mit "..." gekuerzt
string FormatiereZeile(string name, int minuten, int breite)
{
    throw new NotImplementedException();
}
