// LOESUNG - Nur anschauen, wenn du gar nicht weiterkommst!
// Diese Datei wird nicht kompiliert (siehe .csproj).

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
if (!File.Exists(auftragsPfad) || !File.Exists(kartenPfad))
{
    Console.WriteLine("❌ auftraege.txt oder stadtplan.txt nicht gefunden.");
    return;
}

string[] zeilen = File.ReadAllLines(auftragsPfad);
// Jede Zeile ist ein string, ein einzelnes Feld erreichen wir mit stadtplan[y][x]
string[] stadtplan = File.ReadAllLines(kartenPfad);

string[] berichtZeilen = new string[zeilen.Length + 4];
string[] fehlerZeilen = new string[zeilen.Length];
int anzahlBericht = 0;
int anzahlFehler = 0;

berichtZeilen[anzahlBericht] = ErzeugeKopfzeile();
anzahlBericht++;

double gesamtUmsatz = 0;
double laengsteStrecke = 0;
string laengsteNummer = "-";

// Alle bisher gelesenen Auftragsnummern, um Doppelte zu erkennen
string[] bekannteNummern = new string[zeilen.Length];
int anzahlBekannt = 0;

int zeilenNummer = 0;
foreach (string rohZeile in zeilen)
{
    // Zeilennummer selbst mitzaehlen – vor jedem continue!
    zeilenNummer++;
    string zeile = rohZeile.Trim();

    // Kommentare und Leerzeilen ueberspringen
    if (string.IsNullOrWhiteSpace(zeile) || zeile.StartsWith("#"))
    {
        continue;
    }

    if (!TryParseAuftrag(zeile, out var auftrag, out string fehlergrund))
    {
        fehlerZeilen[anzahlFehler] = $"Zeile {zeilenNummer}: {fehlergrund}";
        anzahlFehler++;
        continue;
    }

    // Guard ❌: dieselbe Nummer gab es schon -> welcher der beiden Auftraege gilt? Nicht raten, melden!
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

    if (!IstImStadtplan(stadtplan, auftrag.Start) || !IstImStadtplan(stadtplan, auftrag.Ziel))
    {
        fehlerZeilen[anzahlFehler] = $"Zeile {zeilenNummer}: {auftrag.Nummer} – Koordinate außerhalb des Stadtplans";
        anzahlFehler++;
        continue;
    }

    // Guard ❌: Start und Ziel gleich -> es gibt nichts zu liefern
    if (auftrag.Start == auftrag.Ziel)
    {
        fehlerZeilen[anzahlFehler] = $"Zeile {zeilenNummer}: {auftrag.Nummer} – Start und Ziel sind gleich";
        anzahlFehler++;
        continue;
    }

    double streckeKm = BerechneDistanzFelder(auftrag.Start, auftrag.Ziel) * KmProFeld;

    if (auftrag.GewichtKg > MaxGewichtKg)
    {
        fehlerZeilen[anzahlFehler] = $"Zeile {zeilenNummer}: {auftrag.Nummer} – zu schwer ({auftrag.GewichtKg:F2} kg, max. {MaxGewichtKg:F2} kg)";
        anzahlFehler++;
        continue;
    }

    if (streckeKm > MaxStreckeKm)
    {
        fehlerZeilen[anzahlFehler] = $"Zeile {zeilenNummer}: {auftrag.Nummer} – Strecke zu lang ({streckeKm:F2} km)";
        anzahlFehler++;
        continue;
    }

    bool frei = IstRouteFrei(stadtplan, auftrag.Start, auftrag.Ziel);

    Console.WriteLine($"\n📦 {auftrag.Nummer} für {auftrag.Kunde}");
    ZeichneKarte(stadtplan, auftrag.Start, auftrag.Ziel);

    if (!frei)
    {
        Console.WriteLine("⛔ Route führt durch eine Sperrzone (X)!");
        fehlerZeilen[anzahlFehler] = $"Zeile {zeilenNummer}: {auftrag.Nummer} – Route durch Sperrzone";
        anzahlFehler++;
        continue;
    }

    double preis = BerechnePreis(streckeKm, auftrag.GewichtKg);
    Console.WriteLine($"✅ {streckeKm:F2} km, {preis:F2} €");

    berichtZeilen[anzahlBericht] = FormatiereBerichtZeile(auftrag.Nummer, auftrag.Kunde, streckeKm, auftrag.GewichtKg, preis);
    anzahlBericht++;
    gesamtUmsatz += preis;

    if (streckeKm > laengsteStrecke)
    {
        laengsteStrecke = streckeKm;
        laengsteNummer = auftrag.Nummer;
    }
}

berichtZeilen[anzahlBericht] = new string('-', ErzeugeKopfzeile().Length);
anzahlBericht++;
berichtZeilen[anzahlBericht] = $"Gesamtumsatz: {gesamtUmsatz:F2} €";
anzahlBericht++;
berichtZeilen[anzahlBericht] = $"Längste Strecke: {laengsteNummer} ({laengsteStrecke:F2} km)";
anzahlBericht++;

File.WriteAllLines(berichtPfad, Kuerze(berichtZeilen, anzahlBericht));
File.WriteAllLines(fehlerPfad, Kuerze(fehlerZeilen, anzahlFehler));

Console.WriteLine("\n" + string.Join("\n", Kuerze(berichtZeilen, anzahlBericht)));
Console.WriteLine($"\n{anzahlFehler} fehlerhafte Aufträge -> fehler.txt");

// ======================= Schritt 2 + 4: Auftrag zerlegen =======================

// Liest "schluessel=wert" und liefert den getrimmten Wert, wenn der Schluessel passt.
bool TryLeseFeld(string teil, string schluessel, out string wert)
{
    wert = "";
    int pos = teil.IndexOf('=');

    if (pos < 0)
    {
        return false;
    }

    string links = teil.Substring(0, pos).Trim().ToLower();
    if (links != schluessel)
    {
        return false;
    }

    wert = teil.Substring(pos + 1).Trim();
    return wert.Length > 0;
}

bool TryParseAuftrag(string zeile, out (string Nummer, (int X, int Y) Start, (int X, int Y) Ziel, double GewichtKg, string Kunde) auftrag, out string fehlergrund)
{
    auftrag = ("", (0, 0), (0, 0), 0, "");
    fehlergrund = "";

    // Reparatur 🔧: ein ';' am Zeilenende wuerde ein leeres 6. Feld erzeugen -> abschneiden
    zeile = zeile.TrimEnd(' ', ';');

    string[] teile = zeile.Split(';');

    if (teile.Length != 5)
    {
        fehlergrund = $"{teile.Length} statt 5 Felder";
        return false;
    }

    if (!TryLeseFeld(teile[0], "nummer", out string nummerText) ||
        !TryLeseFeld(teile[1], "start", out string startText) ||
        !TryLeseFeld(teile[2], "ziel", out string zielText) ||
        !TryLeseFeld(teile[3], "gewicht", out string gewichtText) ||
        !TryLeseFeld(teile[4], "kunde", out string kundeText))
    {
        fehlergrund = "Feld fehlt oder falscher Schlüssel";
        return false;
    }

    if (!TryNormalisiereNummer(nummerText, out string nummer))
    {
        fehlergrund = $"ungültige Auftragsnummer '{nummerText}'";
        return false;
    }

    if (!TryParseKoordinate(startText, out var start) || !TryParseKoordinate(zielText, out var ziel))
    {
        fehlergrund = $"{nummer} – ungültige Koordinate";
        return false;
    }

    if (!TryParseGewicht(gewichtText, out double gewicht))
    {
        fehlergrund = $"{nummer} – ungültiges Gewicht '{gewichtText}'";
        return false;
    }

    auftrag = (nummer, start, ziel, gewicht, FormatiereKunde(kundeText));
    return true;
}

// ======================= Schritt 3: Felder umwandeln =======================

// "lf-7" -> "LF-0007"
// Default-Parameter: Nummern haben normalerweise 4 Stellen
bool TryNormalisiereNummer(string text, out string nummer, int stellen = 4)
{
    nummer = "";
    text = text.ToUpper();

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

// "12|3" -> (12, 3)
bool TryParseKoordinate(string text, out (int X, int Y) punkt)
{
    punkt = (0, 0);

    // Reparatur 🔧: "(5|3)" ist eindeutig gemeint -> Klammern entfernen
    text = text.Replace("(", "").Replace(")", "");

    if (!text.Contains('|'))
    {
        return false;
    }

    string[] teile = text.Split('|');
    if (teile.Length != 2 ||
        !int.TryParse(teile[0].Trim(), out int x) ||
        !int.TryParse(teile[1].Trim(), out int y))
    {
        return false;
    }

    punkt = (x, y);
    return true;
}

// "3,2KG" -> 3.2
bool TryParseGewicht(string text, out double gewicht)
{
    gewicht = 0;
    text = text.ToLower().Trim();

    // Reparatur 🔧: Angaben in Gramm ("800g") in kg umrechnen.
    // Achtung Reihenfolge: "kg" endet auch mit "g" -> zuerst auf "kg" pruefen!
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

    // Guard ❌: ein Gewicht muss positiv sein
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

// ======================= Schritt 5: Strecke und Preis =======================

double BerechneDistanzFelder((int X, int Y) start, (int X, int Y) ziel)
{
    int dx = ziel.X - start.X;
    int dy = ziel.Y - start.Y;
    return Math.Sqrt(dx * dx + dy * dy);
}

double BerechnePreis(double streckeKm, double gewichtKg)
{
    double preis = Grundgebuehr + streckeKm * PreisProKm;

    if (gewichtKg > FreigewichtKg)
    {
        preis += (gewichtKg - FreigewichtKg) * ZuschlagProKg;
    }

    return Math.Round(preis, 2);
}

// ======================= Schritt 6: Stadtplan und Route =======================

bool IstImStadtplan(string[] plan, (int X, int Y) p)
{
    return p.X >= 0 && p.Y >= 0 && p.Y < plan.Length && p.X < plan[p.Y].Length;
}

// Liegt das Feld (x|y) auf der Geraden zwischen Start und Ziel?
bool IstAufRoute((int X, int Y) start, (int X, int Y) ziel, int x, int y)
{
    int dx = ziel.X - start.X;
    int dy = ziel.Y - start.Y;

    if (Math.Abs(dx) >= Math.Abs(dy))
    {
        // flache Gerade: Laufachse x, y = k*x + d (Ursprung im Start)
        if (x < Math.Min(start.X, ziel.X) || x > Math.Max(start.X, ziel.X))
        {
            return false;
        }

        double k = dx == 0 ? 0 : (double)dy / dx;
        return y == start.Y + (int)Math.Round(k * (x - start.X));
    }

    // steile Gerade: Laufachse y, x = k' * y + d
    if (y < Math.Min(start.Y, ziel.Y) || y > Math.Max(start.Y, ziel.Y))
    {
        return false;
    }

    double kSteil = (double)dx / dy;
    return x == start.X + (int)Math.Round(kSteil * (y - start.Y));
}

// false, wenn ein Feld der Route eine Sperrzone '#' ist.
bool IstRouteFrei(string[] plan, (int X, int Y) start, (int X, int Y) ziel)
{
    for (int y = 0; y < plan.Length; y++)
    {
        for (int x = 0; x < plan[y].Length; x++)
        {
            if (plan[y][x] == '#' && IstAufRoute(start, ziel, x, y))
            {
                return false;
            }
        }
    }

    return true;
}

// Wie im Unterricht: Zeile fuer Zeile, Feld fuer Feld entscheiden, welches Zeichen gedruckt wird.
void ZeichneKarte(string[] plan, (int X, int Y) start, (int X, int Y) ziel)
{
    for (int y = 0; y < plan.Length; y++)
    {
        string zeile = "";

        for (int x = 0; x < plan[y].Length; x++)
        {
            char feld = plan[y][x];

            if (x == start.X && y == start.Y)
            {
                feld = 'S';
            }
            else if (x == ziel.X && y == ziel.Y)
            {
                feld = 'Z';
            }
            else if (IstAufRoute(start, ziel, x, y))
            {
                feld = plan[y][x] == '#' ? 'X' : '*';
            }

            zeile += feld.ToString() + " ";
        }

        Console.WriteLine(zeile.TrimEnd());
    }
}

// ======================= Schritt 7: Bericht =======================

// Default-Parameter: die Kundenspalte ist fuer 18 Zeichen ausgelegt (+2 Abstand)
string ErzeugeKopfzeile(int maxKundenLaenge = 18)
{
    return "NUMMER".PadRight(9) + "KUNDE".PadRight(maxKundenLaenge + 2) + "STRECKE".PadLeft(10) + "GEWICHT".PadLeft(10) + "PREIS".PadLeft(10);
}

// Default-Parameter: wie in ErzeugeKopfzeile – beide muessen zusammenpassen!
string FormatiereBerichtZeile(string nummer, string kunde, double km, double kg, double preis, int maxKundenLaenge = 18)
{
    // Guard ❌: zu langer Kundenname -> kuerzen, das "…" ist das letzte erlaubte Zeichen
    if (kunde.Length > maxKundenLaenge)
    {
        kunde = kunde.Substring(0, maxKundenLaenge - 1) + "…";
    }

    return nummer.PadRight(9)
         + kunde.PadRight(maxKundenLaenge + 2)
         + $"{km:F2} km".PadLeft(10)
         + $"{kg:F2} kg".PadLeft(10)
         + $"{preis:F2} €".PadLeft(10);
}

string[] Kuerze(string[] array, int anzahl)
{
    string[] ergebnis = new string[anzahl];
    for (int i = 0; i < anzahl; i++)
    {
        ergebnis[i] = array[i];
    }
    return ergebnis;
}
