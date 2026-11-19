using System.Globalization;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

string auftragsPfad = "../../../auftraege.txt";
string kartenPfad = "../../../stadtplan.txt";
string berichtPfad = "../../../bericht.txt";
string fehlerPfad = "../../../fehler.txt";

// ======================= Testfälle =======================
// Entferne die Kommentarzeichen /* */ eines Schritts, sobald du ihn implementiert hast.
// Vergleiche die Ausgabe mit dem erwarteten Output in der Angabe.

/* ---------- Test Schritt 1 ----------
Console.WriteLine("--- Schritt 1 ---");
Auftrag a1 = new Auftrag("LF-0007", (1, 1), (6, 3), 1.5, "Müller Gmbh");
Auftrag a2 = new Auftrag("LF-0013", (3, 7), (4, 0), 2.0, "Htl Werkstätte");
Console.WriteLine(a1.Nummer + " " + a1.Kunde + " " + a1.Start + " -> " + a1.Ziel + " " + a1.GewichtKg + " kg");
Console.WriteLine(a2.Nummer + " " + a2.Kunde + " " + a2.Start + " -> " + a2.Ziel + " " + a2.GewichtKg + " kg");
a2.GewichtKg = 2.5;
Console.WriteLine(a1.GewichtKg + " " + a2.GewichtKg);
*/

/* ---------- Test Schritt 2 ----------
Console.WriteLine("--- Schritt 2 ---");
Auftrag b1 = new Auftrag("LF-0007", (1, 1), (6, 3), 1.5, "Müller Gmbh");
Auftrag b2 = new Auftrag("LF-0099", (0, 0), (4, 3), 4.0, "Sehr Lange Kundenfirma Gmbh");
Console.WriteLine(b1.BerechneStreckeKm().ToString("0.00"));
Console.WriteLine(b2.BerechneStreckeKm().ToString("0.00"));
Console.WriteLine(b1.BerechneStreckeKm(kmProFeld: 1.0).ToString("0.00"));
Console.WriteLine(b1.BerechnePreis().ToString("0.00"));
Console.WriteLine(b2.BerechnePreis().ToString("0.00"));
Console.WriteLine(b1.BerechnePreis(preisProKm: 1.50).ToString("0.00"));
Console.WriteLine(b2.BerechnePreis(freigewichtKg: 5).ToString("0.00"));
Console.WriteLine($"[{b1.FormatiereBerichtZeile()}]");
Console.WriteLine($"[{b2.FormatiereBerichtZeile()}]");
*/

/* ---------- Test Schritt 3 ----------
Console.WriteLine("--- Schritt 3 ---");
Console.WriteLine(TryParseAuftrag("LF-7 ; 1|1 ; 6|3 ; 1,5kg ; mÜLLER gmbh", out Auftrag c1, out string f1) + $" {c1.Nummer} {c1.Kunde} {c1.Start} {c1.Ziel} {c1.GewichtKg} [{f1}]");
Console.WriteLine(TryParseAuftrag("LF-18 ; 2|5 ; 1kg ; vergessen ohg", out Auftrag c2, out string f2) + $" [{f2}]");
Console.WriteLine(TryParseAuftrag("LF-x15 ; 1|1 ; 2|2 ; 1kg ; tippfehler ag", out Auftrag c3, out string f3) + $" [{f3}]");
Console.WriteLine(TryParseAuftrag("LF-21 ; (5|3) ; (11|1) ; 800g ; café   CENTRAL ;", out Auftrag c4, out string f4) + $" {c4.Nummer} {c4.Kunde} {c4.Start} {c4.Ziel} {c4.GewichtKg} [{f4}]");
Console.WriteLine(c2 == null);
*/

/* ---------- Test Schritt 4 ----------
Console.WriteLine("--- Schritt 4 ---");
Stadtplan testPlan = new Stadtplan(File.ReadAllLines(kartenPfad));
Console.WriteLine(testPlan.Zeilen.Length + " Zeilen x " + testPlan.Zeilen[0].Length + " Spalten");
Console.WriteLine(testPlan.IstInnerhalb((11, 7)) + " " + testPlan.IstInnerhalb((12, 3)) + " " + testPlan.IstInnerhalb((3, -1)));
Console.WriteLine(testPlan.IstAufRoute((1, 1), (6, 3), 3, 2) + " " + testPlan.IstAufRoute((1, 1), (6, 3), 3, 3));
Console.WriteLine(testPlan.IstAufRoute((10, 3), (1, 0), 4, 1) + " " + testPlan.IstAufRoute((3, 7), (4, 0), 4, 2));
Console.WriteLine(testPlan.ZeichneRoute(new Auftrag("LF-0013", (3, 7), (4, 0), 2.0, "Htl Werkstätte")));
Console.WriteLine(testPlan.ZeichneRoute(new Auftrag("LF-0019", (0, 6), (11, 6), 1.0, "Quer Durch Gmbh")));
*/

/* ---------- Test Schritt 5 ----------
Console.WriteLine("--- Schritt 5 ---");
Stadtplan wien = new Stadtplan(File.ReadAllLines(kartenPfad));
Drohne sky1 = new Drohne("Sky-1", wien);
Drohne sky2 = new Drohne("Sky-2", wien, maxGewichtKg: 8.0);
Auftrag schwer = new Auftrag("LF-0017", (3, 3), (8, 1), 7.5, "Schwer Und Co");
Console.WriteLine(sky1.TryLiefern(schwer, out string g1) + $" [{g1}]");
Console.WriteLine(sky2.TryLiefern(schwer, out string g2) + $" [{g2}]");
Console.WriteLine(sky1.Statistik());
Console.WriteLine(sky2.Statistik());
Console.WriteLine(sky1.Plan == sky2.Plan);
*/

// ======================= Hauptprogramm =======================
// TODO Schritt 6: Hier alles zusammenbauen (siehe Angabe).


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

    // TODO Schritt 3: Aus den Teilen ein Auftrag-Objekt erzeugen und true liefern.
    throw new NotImplementedException();
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
