using System.Text;

Console.OutputEncoding = Encoding.UTF8;

string eingabePfad = "../../../stempelzeiten.txt";
string ausgabePfad = "../../../arbeitszeiten.txt";

// ======================= Aufgabe 5: Hauptprogramm =======================
// TODO: Siehe Angabe. Zum Testen der einzelnen Funktionen darfst du hier beliebige Aufrufe schreiben, z.B.:
// Console.WriteLine(ErzeugeUeberschrift("Menü", '<', '>', 5));


// ======================= Aufgabe 1: Ueberschrift =======================

// <n-mal links> + <s in Grossbuchstaben, getrimmt> + <n-mal rechts>
string ErzeugeUeberschrift(string s, char links, char rechts, int n)
{
    throw new NotImplementedException();
}

// ======================= Aufgabe 2: Uhrzeit umrechnen =======================

// "7:30" -> 450 Minuten seit Mitternacht, -1 bei ungueltiger Uhrzeit
int ZeitInMinuten(string text)
{
    throw new NotImplementedException();
}

// ======================= Aufgabe 3: Zeitbereich =======================

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

// ======================= Aufgabe 4: Formatieren =======================

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
