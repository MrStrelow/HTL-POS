// LOESUNG - Nur anschauen, wenn du gar nicht weiterkommst!
// Dieser Ordner wird nicht kompiliert (siehe .csproj).

using System.Globalization;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

string auftragsPfad = "../../../auftraege.txt";
string kartenPfad = "../../../stadtplan.txt";
string berichtPfad = "../../../bericht.txt";
string fehlerPfad = "../../../fehler.txt";

// ======================= Schritt 6: Hauptprogramm =======================
// Guard: ohne Dateien können wir nichts tun (early exit)
if (!File.Exists(auftragsPfad) || !File.Exists(kartenPfad))
{
    Console.WriteLine("❌ auftraege.txt oder stadtplan.txt nicht gefunden.");
    return;
}

string[] zeilen = File.ReadAllLines(auftragsPfad);

// Objekte erzeugen: die Drohne bekommt ihren Stadtplan über den Konstruktor (hat-Beziehung)
Stadtplan stadtplan = new Stadtplan(File.ReadAllLines(kartenPfad));
Drohne drohne = new Drohne("Sky-1", stadtplan);

// Wir wissen nicht, wie viele Zeilen gültig sind -> groß genug anlegen und mitzählen
string[] berichtZeilen = new string[zeilen.Length + 3];
string[] fehlerZeilen = new string[zeilen.Length];
string[] bekannteNummern = new string[zeilen.Length];
int anzahlBericht = 0;
int anzahlFehler = 0;
int anzahlBekannt = 0;
double gesamtUmsatz = 0;

berichtZeilen[anzahlBericht] = "NUMMER".PadRight(9) + "KUNDE".PadRight(20) + "STRECKE".PadLeft(10) + "PREIS".PadLeft(10);
anzahlBericht++;

int zeilenNummer = 0;
foreach (string rohZeile in zeilen)
{
    // Zeilennummer selbst mitzählen – vor jedem continue!
    zeilenNummer++;
    string zeile = rohZeile.Trim();

    // Guard: Kommentare und Leerzeilen überspringen
    if (string.IsNullOrWhiteSpace(zeile) || zeile.StartsWith("#"))
    {
        continue;
    }

    // Guard: Zeile lässt sich nicht zerlegen
    if (!TryParseAuftrag(zeile, out Auftrag auftrag, out string fehlergrund))
    {
        fehlerZeilen[anzahlFehler] = $"Zeile {zeilenNummer}: {fehlergrund}";
        anzahlFehler++;
        continue;
    }

    // Guard: dieselbe Nummer gab es schon -> welcher Auftrag gilt? Nicht raten, melden!
    bool doppelt = false;
    foreach (string bekannte in bekannteNummern)
    {
        if (bekannte == auftrag.Nummer)
        {
            doppelt = true;
        }
    }

    if (doppelt)
    {
        fehlerZeilen[anzahlFehler] = $"Zeile {zeilenNummer}: {auftrag.Nummer} – doppelte Auftragsnummer";
        anzahlFehler++;
        continue;
    }

    bekannteNummern[anzahlBekannt] = auftrag.Nummer;
    anzahlBekannt++;

    // Guard: die Drohne prüft selbst, ob sie liefern kann
    if (!drohne.TryLiefern(auftrag, out string grund))
    {
        fehlerZeilen[anzahlFehler] = $"Zeile {zeilenNummer}: {grund}";
        anzahlFehler++;
        continue;
    }

    // gewünschter Zustand: der Auftrag formatiert seine Berichtzeile selbst
    berichtZeilen[anzahlBericht] = auftrag.FormatiereBerichtZeile();
    anzahlBericht++;
    gesamtUmsatz += auftrag.BerechnePreis();
}

berichtZeilen[anzahlBericht] = new string('-', 49);
anzahlBericht++;
berichtZeilen[anzahlBericht] = $"Gesamtumsatz: {gesamtUmsatz:F2} €";
anzahlBericht++;

File.WriteAllLines(berichtPfad, Kuerze(berichtZeilen, anzahlBericht));
File.WriteAllLines(fehlerPfad, Kuerze(fehlerZeilen, anzahlFehler));

Console.WriteLine("\n" + string.Join("\n", Kuerze(berichtZeilen, anzahlBericht)));
Console.WriteLine($"\n{anzahlFehler} fehlerhafte Aufträge -> fehler.txt");
Console.WriteLine(drohne.Statistik());

// ======================= Hilfsfunktionen aus L03 (fertig) =======================

// "lf-7" -> "LF-0007"
bool TryNormalisiereNummer(string text, out string nummer, int stellen = 4)
{
    nummer = "";
    text = text.Trim().ToUpper();

    if (!text.StartsWith("LF-"))
    {
        return false;
    }

    string ziffern = text.Substring(3);
    if (ziffern.Length == 0 || ziffern.Length > stellen)
    {
        return false;
    }

    foreach (char c in ziffern)
    {
        if (!char.IsDigit(c))
        {
            return false;
        }
    }

    nummer = "LF-" + ziffern.PadLeft(stellen, '0');
    return true;
}

// "(5|3)" -> (5, 3)
bool TryParseKoordinate(string text, out (int X, int Y) punkt)
{
    punkt = (0, 0);
    text = text.Replace("(", "").Replace(")", "").Trim();

    if (!text.Contains('|'))
    {
        return false;
    }

    int pos = text.IndexOf('|');
    if (!int.TryParse(text.Substring(0, pos), out int x) ||
        !int.TryParse(text.Substring(pos + 1), out int y))
    {
        return false;
    }

    punkt = (x, y);
    return true;
}

// "3,2KG" -> 3.2, "800g" -> 0.8
bool TryParseGewicht(string text, out double gewicht)
{
    gewicht = 0;
    text = text.Trim().ToLower();

    double faktor = 1;
    string zahl;
    if (text.EndsWith("kg"))
    {
        zahl = text.Substring(0, text.Length - 2);
    }
    else if (text.EndsWith("g"))
    {
        zahl = text.Substring(0, text.Length - 1);
        faktor = 0.001;
    }
    else
    {
        return false;
    }

    zahl = zahl.Replace(',', '.');
    if (!double.TryParse(zahl, NumberStyles.Float, CultureInfo.InvariantCulture, out gewicht))
    {
        return false;
    }

    gewicht = gewicht * faktor;

    if (gewicht <= 0)
    {
        gewicht = 0;
        return false;
    }

    return true;
}

// "  mÜLLER gmbh" -> "Müller Gmbh"
string FormatiereKunde(string text)
{
    string[] woerter = text.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

    for (int i = 0; i < woerter.Length; i++)
    {
        string w = woerter[i];
        woerter[i] = w.Substring(0, 1).ToUpper() + w.Substring(1).ToLower();
    }

    return string.Join(" ", woerter);
}

// ======================= Schritt 3: Auftrag zerlegen und Objekt erzeugen =======================

bool TryParseAuftrag(string zeile, out Auftrag auftrag, out string fehlergrund)
{
    auftrag = null;   // noch kein Objekt
    fehlergrund = "";

    zeile = zeile.TrimEnd(' ', ';');
    string[] teile = zeile.Split(';');

    if (teile.Length != 5)
    {
        fehlergrund = $"{teile.Length} statt 5 Felder";
        return false;
    }

    if (!TryNormalisiereNummer(teile[0], out string nummer))
    {
        fehlergrund = $"ungültige Auftragsnummer '{teile[0].Trim()}'";
        return false;
    }

    if (!TryParseKoordinate(teile[1], out var start) || !TryParseKoordinate(teile[2], out var ziel))
    {
        fehlergrund = $"{nummer} – ungültige Koordinate";
        return false;
    }

    if (!TryParseGewicht(teile[3], out double gewicht))
    {
        fehlergrund = $"{nummer} – ungültiges Gewicht '{teile[3].Trim()}'";
        return false;
    }

    // gewünschter Zustand: aus den Teilen ein Objekt bauen (Instanziierung mit new)
    auftrag = new Auftrag(nummer, start, ziel, gewicht, FormatiereKunde(teile[4]));
    return true;
}

// Liefert ein neues Array mit nur den ersten 'anzahl' Elementen. (fertig)
string[] Kuerze(string[] array, int anzahl)
{
    string[] ergebnis = new string[anzahl];
    for (int i = 0; i < anzahl; i++)
    {
        ergebnis[i] = array[i];
    }
    return ergebnis;
}
