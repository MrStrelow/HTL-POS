// LOESUNG - Nur anschauen, wenn du gar nicht weiterkommst!
// Diese Datei wird nicht kompiliert (siehe .csproj).

using System.Text;

Console.OutputEncoding = Encoding.UTF8;

string eingabePfad = "../../../stempelzeiten.txt";
string ausgabePfad = "../../../arbeitszeiten.txt";

// ======================= Aufgabe 5: Hauptprogramm =======================

// Guard: ungewuenschter Zustand ❌ -> ohne Eingabefile koennen wir nichts tun (early exit)
if (!File.Exists(eingabePfad))
{
    Console.WriteLine("❌ stempelzeiten.txt nicht gefunden.");
    return;
}

string[] zeilen = File.ReadAllLines(eingabePfad);

// Wir wissen nicht, wie viele Zeilen gueltig sind -> gross genug anlegen und mitzaehlen
string[] ausgabe = new string[zeilen.Length + 2];
int anzahlAusgabe = 0;

ausgabe[anzahlAusgabe] = ErzeugeUeberschrift("Arbeitszeiten", '=', '=', 10);
anzahlAusgabe++;

for (int i = 0; i < zeilen.Length; i++)
{
    string zeile = zeilen[i].Trim();

    // Guard ❌: Kommentare und Leerzeilen ueberspringen
    if (string.IsNullOrWhiteSpace(zeile) || zeile.StartsWith("#"))
    {
        continue;
    }

    string[] teile = zeile.Split(';');
    string name = FormatiereName(teile[0]);
    int summe = SummiereZeiten(teile);

    // Guard ❌: ungueltige Zeile melden und ueberspringen
    if (summe < 0)
    {
        Console.WriteLine($"⚠️ Zeile {i + 1}: ungültige Zeiten bei {name}");
        continue;
    }

    // gewuenschter Zustand ✅
    ausgabe[anzahlAusgabe] = name.PadRight(16) + FormatiereDauer(summe).PadLeft(6) + " h";
    anzahlAusgabe++;
}

// Nur die befuellten Zeilen in ein neues Array kopieren
string[] fertig = new string[anzahlAusgabe];
for (int i = 0; i < anzahlAusgabe; i++)
{
    fertig[i] = ausgabe[i];
}

File.WriteAllLines(ausgabePfad, fertig);

Console.WriteLine();
foreach (string z in fertig)
{
    Console.WriteLine(z);
}

// ======================= Aufgabe 1: Ueberschrift =======================

// <n-mal links> + <s in Grossbuchstaben, getrimmt> + <n-mal rechts>
string ErzeugeUeberschrift(string s, char links, char rechts, int n)
{
    // Guard ❌: negative Anzahl
    if (n < 0)
    {
        return "";
    }

    // "".PadLeft(n, c) fuellt einen leeren String mit n Zeichen c auf -> "<<<<<"
    string linkerRand = "".PadLeft(n, links);
    string rechterRand = "".PadLeft(n, rechts);
    string text = s.Trim().ToUpper();

    // Guard ❌: leerer Text -> keine Leerzeichen in der Mitte
    if (text.Length == 0)
    {
        return linkerRand + rechterRand;
    }

    // gewuenschter Zustand ✅
    return linkerRand + " " + text + " " + rechterRand;
}

// ======================= Aufgabe 2: Uhrzeit umrechnen =======================

// "7:30" -> 450 Minuten seit Mitternacht, -1 bei ungueltiger Uhrzeit
int ZeitInMinuten(string text)
{
    text = text.Trim();
    int pos = text.IndexOf(':');

    // Guard ❌: kein Doppelpunkt
    if (pos < 0)
    {
        return -1;
    }

    string stundenText = text.Substring(0, pos);
    string minutenText = text.Substring(pos + 1);

    // Guard ❌: Minuten nicht zweistellig
    if (minutenText.Length != 2)
    {
        return -1;
    }

    // Guard ❌: keine Zahlen
    if (!int.TryParse(stundenText, out int h) || !int.TryParse(minutenText, out int m))
    {
        return -1;
    }

    // Guard ❌: ausserhalb des gueltigen Bereichs
    if (h < 0 || h > 23 || m < 0 || m > 59)
    {
        return -1;
    }

    // gewuenschter Zustand ✅
    return h * 60 + m;
}

// ======================= Aufgabe 3: Zeitbereich =======================

// "7:30-12:00" -> 270, -1 bei ungueltigem Bereich
int DauerInMinuten(string bereich)
{
    string[] zeiten = bereich.Split('-');

    // Guard ❌: nicht genau zwei Zeiten
    if (zeiten.Length != 2)
    {
        return -1;
    }

    int start = ZeitInMinuten(zeiten[0]);
    int ende = ZeitInMinuten(zeiten[1]);

    // Guard ❌: ungueltige Uhrzeit oder Ende vor Start
    if (start < 0 || ende < 0 || ende < start)
    {
        return -1;
    }

    // gewuenschter Zustand ✅
    return ende - start;
}

// teile[0] ist der Name, alle weiteren Teile sind Zeitbereiche. -1 wenn etwas ungueltig ist.
int SummiereZeiten(string[] teile)
{
    // Guard ❌: kein einziger Zeitbereich
    if (teile.Length < 2)
    {
        return -1;
    }

    int summe = 0;
    for (int i = 1; i < teile.Length; i++)
    {
        int dauer = DauerInMinuten(teile[i]);

        // Guard ❌: ein ungueltiger Bereich macht die ganze Zeile ungueltig
        if (dauer < 0)
        {
            return -1;
        }

        summe += dauer;
    }

    // gewuenschter Zustand ✅
    return summe;
}

// ======================= Aufgabe 4: Formatieren =======================

// "  mÜLLER anna " -> "Müller Anna"
string FormatiereName(string text)
{
    string[] woerter = text.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

    for (int i = 0; i < woerter.Length; i++)
    {
        string w = woerter[i];
        woerter[i] = w.Substring(0, 1).ToUpper() + w.Substring(1).ToLower();
    }

    return string.Join(" ", woerter);
}

// 495 -> "8:15"
string FormatiereDauer(int minuten)
{
    int h = minuten / 60;
    int m = minuten % 60;
    return h + ":" + m.ToString().PadLeft(2, '0');
}
