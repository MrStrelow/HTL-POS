// LOESUNG - Nur anschauen, wenn du gar nicht weiterkommst!
// Diese Datei wird nicht kompiliert (siehe .csproj).

using System.Text;

Console.OutputEncoding = Encoding.UTF8;

string eingabePfad = "../../../stempelzeiten.txt";
string ausgabePfad = "../../../arbeitszeiten.txt";

// ======================= Schritt 6: Hauptprogramm =======================

// Guard: ungewuenschter Zustand ❌ -> ohne Eingabefile koennen wir nichts tun (early exit)
if (!File.Exists(eingabePfad))
{
    Console.WriteLine("❌ stempelzeiten.txt nicht gefunden.");
    return;
}

string[] zeilen = File.ReadAllLines(eingabePfad);

// Durchgang 1: gueltige Personen sammeln.
// Wir wissen nicht, wie viele Zeilen gueltig sind -> gross genug anlegen und mitzaehlen
string[] namen = new string[zeilen.Length];
int[] summen = new int[zeilen.Length];
int anzahlPersonen = 0;

int zeilenNummer = 0;
foreach (string rohZeile in zeilen)
{
    // Zeilennummer selbst mitzaehlen – vor jedem continue!
    zeilenNummer++;
    string zeile = rohZeile.Trim();

    // Guard ❌: Kommentare und Leerzeilen ueberspringen
    if (string.IsNullOrWhiteSpace(zeile) || zeile.StartsWith("#"))
    {
        continue;
    }

    string[] teile = zeile.Split(';');
    string name = FormatiereName(teile[0]);

    // Guard ❌: ohne Namen wissen wir nicht, wem die Zeiten gehoeren
    if (name.Length == 0)
    {
        Console.WriteLine($"⚠️ Zeile {zeilenNummer}: Name fehlt");
        continue;
    }

    int summe = SummiereZeiten(teile);

    // Guard ❌: ungueltige Zeile melden und ueberspringen
    if (summe < 0)
    {
        Console.WriteLine($"⚠️ Zeile {zeilenNummer}: ungültige Zeiten bei {name}");
        continue;
    }

    // gewuenschter Zustand ✅: noch nicht ausgeben – die Spaltenbreite kennen wir erst am Ende!
    namen[anzahlPersonen] = name;
    summen[anzahlPersonen] = summe;
    anzahlPersonen++;
}

// Nur die befuellten Namen in ein neues Array kopieren (for: zwei Arrays mit demselben Index)
string[] gueltigeNamen = new string[anzahlPersonen];
for (int i = 0; i < anzahlPersonen; i++)
{
    gueltigeNamen[i] = namen[i];
}

// Durchgang 2: erst jetzt kennen wir alle Namen -> Spaltenbreite bestimmen und Zeilen bauen
int breite = BerechneSpaltenbreite(gueltigeNamen);

string[] ausgabe = new string[anzahlPersonen + 1];
// links, rechts und n weggelassen -> Default-Werte '=', '=' und 10
ausgabe[0] = ErzeugeUeberschrift("Arbeitszeiten");
for (int i = 0; i < anzahlPersonen; i++)
{
    ausgabe[i + 1] = FormatiereZeile(namen[i], summen[i], breite);
}

File.WriteAllLines(ausgabePfad, ausgabe);

Console.WriteLine();
foreach (string z in ausgabe)
{
    Console.WriteLine(z);
}

// ======================= Schritt 2: Ueberschrift =======================

// <n-mal links> + <s in Grossbuchstaben, getrimmt> + <n-mal rechts>
// Default-Parameter: ohne Angabe 10-mal '=' links und rechts
string ErzeugeUeberschrift(string s, char links = '=', char rechts = '=', int n = 10)
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

// ======================= Schritt 3: Uhrzeit umrechnen =======================

// "7:30" -> 450 Minuten seit Mitternacht, -1 bei ungueltiger Uhrzeit
int ZeitInMinuten(string text)
{
    // Reparatur 🔧: "7.45" und "12,30" sind eindeutig gemeint -> wie "7:45" behandeln
    text = text.Trim().Replace('.', ':').Replace(',', ':');
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

// ======================= Schritt 4: Zeitbereich =======================

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
    int summe = 0;
    int anzahlBereiche = 0;
    int letztesEnde = -1;

    // for statt foreach: wir starten bei 1, weil teile[0] der Name ist
    for (int i = 1; i < teile.Length; i++)
    {
        // Reparatur 🔧: ein leerer Bereich (z.B. durch ein ';' am Zeilenende) wird einfach uebersprungen
        if (string.IsNullOrWhiteSpace(teile[i]))
        {
            continue;
        }

        int dauer = DauerInMinuten(teile[i]);

        // Guard ❌: ein ungueltiger Bereich macht die ganze Zeile ungueltig
        if (dauer < 0)
        {
            return -1;
        }

        int start = ZeitInMinuten(teile[i].Split('-')[0]);

        // Guard ❌: Bereich beginnt, bevor der vorige zu Ende ist (Ueberlappung)
        if (start < letztesEnde)
        {
            return -1;
        }

        letztesEnde = start + dauer;
        summe += dauer;
        anzahlBereiche++;
    }

    // Guard ❌: kein einziger gueltiger Zeitbereich
    if (anzahlBereiche == 0)
    {
        return -1;
    }

    // gewuenschter Zustand ✅
    return summe;
}

// ======================= Schritt 5: Formatieren =======================

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

// Laenge des laengsten Namens. Ist er laenger als MaxNamenLaenge (Tippfehler, Copy-Paste ...),
// zaehlt stattdessen der zweitlaengste – sonst waere die Tabelle fuer alle unlesbar breit.
// MaxNamenLaenge ist ein Default-Parameter: wer nichts angibt, bekommt 255.
int BerechneSpaltenbreite(string[] namen, int MaxNamenLaenge = 255)
{
    int laengste = 0;
    int zweitLaengste = 0;

    foreach (string name in namen)
    {
        if (name.Length > laengste)
        {
            zweitLaengste = laengste;
            laengste = name.Length;
        }
        else if (name.Length > zweitLaengste)
        {
            zweitLaengste = name.Length;
        }
    }

    // Guard ❌: Ausreisser -> den zweitlaengsten Namen verwenden
    if (laengste > MaxNamenLaenge)
    {
        return zweitLaengste;
    }

    return laengste;
}

// ("Müller Anna", 495, 12) -> "Müller Anna       8:15 h"
// Namen laenger als breite werden abgeschnitten und bekommen "..."
string FormatiereZeile(string name, int minuten, int breite)
{
    // Guard ❌: zu langer Name -> abschneiden und "..." anhaengen (dann ist er genau breite + 3 lang)
    if (name.Length > breite)
    {
        name = name.Substring(0, breite) + "...";
    }

    return name.PadRight(breite + 3) + FormatiereDauer(minuten).PadLeft(6) + " h";
}
