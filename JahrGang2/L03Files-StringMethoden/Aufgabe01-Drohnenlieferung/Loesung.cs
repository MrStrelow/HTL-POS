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
char[,] stadtplan = LeseStadtplan(kartenPfad);

string[] berichtZeilen = new string[zeilen.Length + 4];
string[] fehlerZeilen = new string[zeilen.Length];
int anzahlBericht = 0;
int anzahlFehler = 0;

berichtZeilen[anzahlBericht++] = ErzeugeKopfzeile();

double gesamtUmsatz = 0;
double laengsteStrecke = 0;
string laengsteNummer = "-";

for (int i = 0; i < zeilen.Length; i++)
{
    string zeile = zeilen[i].Trim();

    // Kommentare und Leerzeilen ueberspringen
    if (string.IsNullOrWhiteSpace(zeile) || zeile.StartsWith("#"))
    {
        continue;
    }

    if (!TryParseAuftrag(zeile, out var auftrag, out string fehlergrund))
    {
        fehlerZeilen[anzahlFehler++] = $"Zeile {i + 1}: {fehlergrund}";
        continue;
    }

    if (!IstImStadtplan(stadtplan, auftrag.Start) || !IstImStadtplan(stadtplan, auftrag.Ziel))
    {
        fehlerZeilen[anzahlFehler++] = $"Zeile {i + 1}: {auftrag.Nummer} – Koordinate außerhalb des Stadtplans";
        continue;
    }

    double streckeKm = BerechneDistanzFelder(auftrag.Start, auftrag.Ziel) * KmProFeld;

    if (auftrag.GewichtKg > MaxGewichtKg)
    {
        fehlerZeilen[anzahlFehler++] = $"Zeile {i + 1}: {auftrag.Nummer} – zu schwer ({auftrag.GewichtKg:F2} kg, max. {MaxGewichtKg:F2} kg)";
        continue;
    }

    if (streckeKm > MaxStreckeKm)
    {
        fehlerZeilen[anzahlFehler++] = $"Zeile {i + 1}: {auftrag.Nummer} – Strecke zu lang ({streckeKm:F2} km)";
        continue;
    }

    // Kopie! Sonst wuerden alle Routen in denselben Stadtplan (Referenz) gezeichnet.
    char[,] karte = KopiereStadtplan(stadtplan);
    bool frei = ZeichneRoute(karte, auftrag.Start, auftrag.Ziel);

    Console.WriteLine($"\n📦 {auftrag.Nummer} für {auftrag.Kunde}");
    GibKarteAus(karte);

    if (!frei)
    {
        Console.WriteLine("⛔ Route führt durch eine Sperrzone (X)!");
        fehlerZeilen[anzahlFehler++] = $"Zeile {i + 1}: {auftrag.Nummer} – Route durch Sperrzone";
        continue;
    }

    double preis = BerechnePreis(streckeKm, auftrag.GewichtKg);
    Console.WriteLine($"✅ {streckeKm:F2} km, {preis:F2} €");

    berichtZeilen[anzahlBericht++] = FormatiereBerichtZeile(auftrag.Nummer, auftrag.Kunde, streckeKm, auftrag.GewichtKg, preis);
    gesamtUmsatz += preis;

    if (streckeKm > laengsteStrecke)
    {
        laengsteStrecke = streckeKm;
        laengsteNummer = auftrag.Nummer;
    }
}

berichtZeilen[anzahlBericht++] = new string('-', ErzeugeKopfzeile().Length);
berichtZeilen[anzahlBericht++] = $"Gesamtumsatz: {gesamtUmsatz:F2} €";
berichtZeilen[anzahlBericht++] = $"Längste Strecke: {laengsteNummer} ({laengsteStrecke:F2} km)";

File.WriteAllLines(berichtPfad, Kuerze(berichtZeilen, anzahlBericht));
File.WriteAllLines(fehlerPfad, Kuerze(fehlerZeilen, anzahlFehler));

Console.WriteLine("\n" + string.Join("\n", Kuerze(berichtZeilen, anzahlBericht)));
Console.WriteLine($"\n{anzahlFehler} fehlerhafte Aufträge -> fehler.txt");

// ======================= Aufgabe 1: Auftrag zerlegen =======================

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

// ======================= Aufgabe 2: Felder umwandeln =======================

// "lf-7" -> "LF-0007"
bool TryNormalisiereNummer(string text, out string nummer)
{
    nummer = "";
    text = text.ToUpper();

    if (!text.StartsWith("LF-"))
    {
        return false;
    }

    string ziffern = text.Substring(3);
    if (ziffern.Length == 0 || ziffern.Length > 4)
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

    nummer = "LF-" + ziffern.PadLeft(4, '0');
    return true;
}

// "12|3" -> (12, 3)
bool TryParseKoordinate(string text, out (int X, int Y) punkt)
{
    punkt = (0, 0);

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

    if (!text.EndsWith("kg"))
    {
        return false;
    }

    string zahl = text.Substring(0, text.Length - 2).Replace(',', '.');
    return double.TryParse(zahl, NumberStyles.Float, CultureInfo.InvariantCulture, out gewicht) && gewicht > 0;
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

// ======================= Aufgabe 3: Strecke und Preis =======================

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

// ======================= Aufgabe 4: Stadtplan und Route =======================

char[,] LeseStadtplan(string pfad)
{
    string[] zeilen = File.ReadAllLines(pfad);
    char[,] plan = new char[zeilen.Length, zeilen[0].Length];

    for (int y = 0; y < zeilen.Length; y++)
    {
        for (int x = 0; x < zeilen[y].Length; x++)
        {
            plan[y, x] = zeilen[y][x];
        }
    }

    return plan;
}

bool IstImStadtplan(char[,] plan, (int X, int Y) p)
{
    return p.X >= 0 && p.Y >= 0 && p.Y < plan.GetLength(0) && p.X < plan.GetLength(1);
}

char[,] KopiereStadtplan(char[,] plan)
{
    char[,] kopie = new char[plan.GetLength(0), plan.GetLength(1)];

    for (int y = 0; y < plan.GetLength(0); y++)
    {
        for (int x = 0; x < plan.GetLength(1); x++)
        {
            kopie[y, x] = plan[y, x];
        }
    }

    return kopie;
}

// Zeichnet die Gerade y = k*x + d zwischen Start und Ziel ein.
// Rueckgabe false, wenn ein Punkt der Route auf einer Sperrzone '#' liegt (dort wird 'X' gezeichnet).
bool ZeichneRoute(char[,] plan, (int X, int Y) start, (int X, int Y) ziel)
{
    int dx = ziel.X - start.X;
    int dy = ziel.Y - start.Y;
    bool frei = true;

    if (Math.Abs(dx) >= Math.Abs(dy))
    {
        // flache Gerade: Laufachse x (auch nach links)
        double k = dx == 0 ? 0 : (double)dy / dx;
        int schritt = dx >= 0 ? 1 : -1;

        for (int x = start.X; x != ziel.X + schritt; x += schritt)
        {
            int y = start.Y + (int)Math.Round(k * (x - start.X));
            frei = SetzePunkt(plan, x, y) && frei;
        }
    }
    else
    {
        // steile Gerade: Laufachse y, x = k' * y + d
        double k = (double)dx / dy;
        int schritt = dy >= 0 ? 1 : -1;

        for (int y = start.Y; y != ziel.Y + schritt; y += schritt)
        {
            int x = start.X + (int)Math.Round(k * (y - start.Y));
            frei = SetzePunkt(plan, x, y) && frei;
        }
    }

    plan[start.Y, start.X] = 'S';
    plan[ziel.Y, ziel.X] = 'Z';
    return frei;
}

bool SetzePunkt(char[,] plan, int x, int y)
{
    if (plan[y, x] == '#')
    {
        plan[y, x] = 'X';
        return false;
    }

    plan[y, x] = '*';
    return true;
}

void GibKarteAus(char[,] plan)
{
    for (int y = 0; y < plan.GetLength(0); y++)
    {
        string zeile = "";
        for (int x = 0; x < plan.GetLength(1); x++)
        {
            zeile += plan[y, x].ToString() + " ";
        }
        Console.WriteLine(zeile.TrimEnd());
    }
}

// ======================= Aufgabe 5: Bericht =======================

string ErzeugeKopfzeile()
{
    return "NUMMER".PadRight(9) + "KUNDE".PadRight(20) + "STRECKE".PadLeft(10) + "GEWICHT".PadLeft(10) + "PREIS".PadLeft(10);
}

string FormatiereBerichtZeile(string nummer, string kunde, double km, double kg, double preis)
{
    if (kunde.Length > 18)
    {
        kunde = kunde.Substring(0, 17) + "…";
    }

    return nummer.PadRight(9)
         + kunde.PadRight(20)
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
