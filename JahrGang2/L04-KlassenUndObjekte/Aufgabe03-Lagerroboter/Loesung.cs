using System.Text;

Console.OutputEncoding = Encoding.UTF8;

// ======================= Konstanten =======================
const string Richtungen = "NOSW"; // im Uhrzeigersinn: Nord, Ost, Süd, West
(int X, int Y) startPosition = (1, 1);
const char StartRichtung = 'O';

string befehlePfad = "../../../befehle.txt";
string lagerPfad = "../../../lagerhalle.txt";
string protokollPfad = "../../../protokoll.txt";
string fehlerPfad = "../../../fehler.txt";

// ======================= Schritt 8: Hauptprogramm =======================
string[] zeilen = LeseDatei(befehlePfad);
string[] lager = LeseDatei(lagerPfad);

// Guard ❌
if (zeilen.Length == 0 || lager.Length == 0)
{
    Console.WriteLine("❌ befehle.txt oder lagerhalle.txt fehlt!");
    return;
}

(int X, int Y) position = startPosition;
char richtung = StartRichtung;
bool traegtPaket = false;
int zugestellt = 0;
int gefahreneFelder = 0;

string[] protokoll = new string[zeilen.Length];
int anzahlProtokoll = 0;
string[] fehler = new string[zeilen.Length];
int anzahlFehler = 0;

int nr = 0;
foreach (string zeile in zeilen)
{
    // Zeilennummer selbst mitzaehlen – vor jedem continue!
    nr++;

    if (!TryBereinigeZeile(zeile, out string befehl))
    {
        continue;
    }

    if (!TryParseBefehl(befehl, out (string Name, int Anzahl) b, out string grund))
    {
        fehler[anzahlFehler] = $"Zeile {nr}: {grund}";
        anzahlFehler++;
        continue;
    }

    if (b.Name == "links" || b.Name == "rechts")
    {
        richtung = Drehe(richtung, b.Name);
    }
    else if (b.Name == "vor" || b.Name == "zurueck")
    {
        int schritt = b.Name == "vor" ? 1 : -1;
        int gefahren = 0;
        for (int s = 0; s < b.Anzahl; s++)
        {
            (int X, int Y) naechstes = NaechstesFeld(position, richtung, schritt);
            if (!IstBegehbar(lager, naechstes))
            {
                fehler[anzahlFehler] = $"Zeile {nr}: Wand bei ({naechstes.X}|{naechstes.Y}) – nur {gefahren} von {b.Anzahl} Feldern gefahren";
                anzahlFehler++;
                break;
            }
            position = naechstes;
            gefahren++;
        }
        gefahreneFelder += gefahren;
    }
    else if (b.Name == "nimm")
    {
        if (traegtPaket)
        {
            fehler[anzahlFehler] = $"Zeile {nr}: trägt bereits ein Paket";
            anzahlFehler++;
            continue;
        }
        if (lager[position.Y][position.X] != 'P')
        {
            fehler[anzahlFehler] = $"Zeile {nr}: kein Paket bei ({position.X}|{position.Y})";
            anzahlFehler++;
            continue;
        }
        SetzeZeichen(lager, position, '.');
        traegtPaket = true;
    }
    else if (b.Name == "ablegen")
    {
        if (!traegtPaket)
        {
            fehler[anzahlFehler] = $"Zeile {nr}: kein Paket geladen";
            anzahlFehler++;
            continue;
        }
        if (lager[position.Y][position.X] != 'Z')
        {
            fehler[anzahlFehler] = $"Zeile {nr}: kein Ablageplatz bei ({position.X}|{position.Y})";
            anzahlFehler++;
            continue;
        }
        traegtPaket = false;
        zugestellt++;
    }

    protokoll[anzahlProtokoll] = ErzeugeProtokollZeile(nr, befehl, position, richtung);
    anzahlProtokoll++;
}

protokoll = Kuerze(protokoll, anzahlProtokoll);
fehler = Kuerze(fehler, anzahlFehler);

Console.WriteLine("🤖 Protokoll:");
foreach (string zeile in protokoll)
{
    Console.WriteLine(zeile);
}

Console.WriteLine("\n🗺️ Lagerhalle am Ende:");
foreach (string zeile in ErzeugeKarte(lager, position, richtung))
{
    Console.WriteLine(zeile);
}

Console.WriteLine($"\n📦 Zugestellte Pakete: {zugestellt}");
Console.WriteLine($"🛞 Gefahrene Felder: {gefahreneFelder}");
Console.WriteLine($"⚠️ Fehler: {fehler.Length} (siehe fehler.txt)");

File.WriteAllLines(protokollPfad, protokoll);
File.WriteAllLines(fehlerPfad, fehler);

// ======================= Schritt 1: Datei einlesen =======================
string[] LeseDatei(string pfad)
{
    // Guard ❌
    if (!File.Exists(pfad))
    {
        return new string[0];
    }

    return File.ReadAllLines(pfad);
}

// ======================= Schritt 2: Zeile bereinigen =======================
bool TryBereinigeZeile(string zeile, out string befehl)
{
    befehl = "";

    int kommentarStart = zeile.IndexOf('#');
    if (kommentarStart != -1)
    {
        zeile = zeile.Substring(0, kommentarStart);
    }

    // Reparatur 🔧: ein Tabulator ist auch nur ein Abstand
    zeile = zeile.Replace('\t', ' ');

    string[] woerter = zeile.Split(' ', StringSplitOptions.RemoveEmptyEntries);

    // Guard ❌
    if (woerter.Length == 0)
    {
        return false;
    }

    // Reparatur 🔧: "zurück" ist eindeutig "zurueck" (erst nach ToLower, dann deckt es auch "ZURÜCK" ab)
    befehl = string.Join(" ", woerter).ToLower().Replace("ü", "ue");
    return true;
}

// ======================= Schritt 3: Befehl zerlegen =======================
bool TryParseBefehl(string befehl, out (string Name, int Anzahl) ergebnis, out string fehlergrund)
{
    ergebnis = ("", 0);
    fehlergrund = "";

    string[] teile = befehl.Split(' ');
    string name = teile[0];
    bool mitAnzahl = name == "vor" || name == "zurueck";
    bool ohneAnzahl = name == "links" || name == "rechts" || name == "nimm" || name == "ablegen";

    // Guard ❌
    if (!mitAnzahl && !ohneAnzahl)
    {
        fehlergrund = $"unbekannter Befehl '{name}'";
        return false;
    }

    // Guard ❌
    if (ohneAnzahl && teile.Length != 1)
    {
        fehlergrund = $"'{name}' braucht keine Anzahl";
        return false;
    }

    if (ohneAnzahl)
    {
        ergebnis = (name, 1);
        return true;
    }

    // Guard ❌
    if (teile.Length < 2)
    {
        fehlergrund = $"fehlende Anzahl bei '{name}'";
        return false;
    }

    // Guard ❌: "vor 1 2" – war 1 oder 2 gemeint? Nicht raten, melden!
    if (teile.Length > 2)
    {
        fehlergrund = $"zu viele Angaben bei '{name}'";
        return false;
    }

    // Guard ❌
    if (!int.TryParse(teile[1], out int anzahl) || anzahl < 1)
    {
        fehlergrund = $"ungültige Anzahl '{teile[1]}'";
        return false;
    }

    ergebnis = (name, anzahl);
    return true;
}

// ======================= Schritt 4: Drehen und Bewegen =======================
char Drehe(char richtung, string seite)
{
    int index = Richtungen.IndexOf(richtung);

    if (seite == "rechts")
    {
        return Richtungen[(index + 1) % 4];
    }

    return Richtungen[(index + 3) % 4];
}

// schritt = 1 (vor) oder -1 (zurueck). Default-Parameter: ohne Angabe faehrt der Roboter vor.
(int X, int Y) NaechstesFeld((int X, int Y) pos, char richtung, int schritt = 1)
{
    if (richtung == 'N') return (pos.X, pos.Y - schritt);
    if (richtung == 'S') return (pos.X, pos.Y + schritt);
    if (richtung == 'O') return (pos.X + schritt, pos.Y);
    return (pos.X - schritt, pos.Y);
}

// ======================= Schritt 5: Lagerhalle =======================
bool IstBegehbar(string[] lager, (int X, int Y) p)
{
    // Guard ❌
    if (p.Y < 0 || p.Y >= lager.Length || p.X < 0 || p.X >= lager[p.Y].Length)
    {
        return false;
    }

    return lager[p.Y][p.X] != '#';
}

// ======================= Schritt 6: Pakete und Karte =======================
void SetzeZeichen(string[] lager, (int X, int Y) p, char zeichen)
{
    string zeile = lager[p.Y];
    lager[p.Y] = zeile.Substring(0, p.X) + zeichen + zeile.Substring(p.X + 1);
}

char RoboterSymbol(char richtung)
{
    if (richtung == 'N') return '^';
    if (richtung == 'O') return '>';
    if (richtung == 'S') return 'v';
    return '<';
}

string[] ErzeugeKarte(string[] lager, (int X, int Y) pos, char richtung)
{
    string[] karte = new string[lager.Length];
    for (int y = 0; y < lager.Length; y++)
    {
        string zeile = "";
        for (int x = 0; x < lager[y].Length; x++)
        {
            if (x == pos.X && y == pos.Y)
            {
                zeile += RoboterSymbol(richtung).ToString();
            }
            else
            {
                zeile += lager[y][x].ToString();
            }
        }
        karte[y] = zeile;
    }
    return karte;
}

// ======================= Schritt 7: Protokoll =======================
// Default-Parameter: die Befehlsspalte ist 10 Zeichen breit
string ErzeugeProtokollZeile(int nr, string befehl, (int X, int Y) pos, char richtung, int befehlBreite = 10)
{
    string position = $"({pos.X}|{pos.Y})";
    return $"Zeile {nr.ToString().PadLeft(2, '0')} | {befehl.PadRight(befehlBreite)} | {position.PadLeft(6)} {richtung}";
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
