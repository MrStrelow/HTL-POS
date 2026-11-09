// LOESUNG - Nur anschauen, wenn du gar nicht weiterkommst!
// Diese Datei wird nicht kompiliert (siehe .csproj).

using System.Text;

Console.OutputEncoding = Encoding.UTF8; // Fuer Emojis

// ======================= Hauptprogramm =======================
string pfadOhneBaeume = "../../../weltkarte.txt";
string pfadMitBaeumen = "../../../weltkarte_mit_baeumen.txt";

// Guard ❌: ohne Karte koennen wir nichts tun (early exit)
if (!File.Exists(pfadOhneBaeume))
{
    Console.WriteLine("❌ weltkarte.txt nicht gefunden.");
    return;
}

string[,] karte = LadeKarte(pfadOhneBaeume);
int anzahlFelder = karte.GetLength(0) * karte.GetLength(1);

// Aufgabe 2: Der Wunsch wird auf das Moegliche begrenzt -> keine Endlosschleife mehr
double wunschProzentWald = 0.85;
double prozentWaldAufKarte = SetProzentWaldAufKarte(wunschProzentWald, karte);
if (prozentWaldAufKarte != wunschProzentWald)
{
    Console.WriteLine($"⚠️ {wunschProzentWald * 100}% Wald passen nicht auf die Karte. Verwende {prozentWaldAufKarte * 100:0.0}%.");
}
int anzahlBaeume = (int)(anzahlFelder * prozentWaldAufKarte);

// Aufgabe 3: Inseln vor den Baeumen aufschuetten
double prozentInselnAufKarte = 0.035;
int anzahlInseln = (int)(anzahlFelder * prozentInselnAufKarte);

Console.WriteLine($"1) --- schuette {anzahlInseln} 🟨 Inseln auf einer Karte mit {anzahlFelder} Feldern auf ---");
string[,] karteMitInseln = SchuetteInselnAuf(karte, anzahlInseln);
ZeichneKarte(karteMitInseln);

Console.WriteLine($"2) --- pflanze {anzahlBaeume} 🌳 Baeume auf einer Karte mit {anzahlFelder} Feldern ---");
string[,] karteMitBaeumen = PflanzeBaeume(karteMitInseln, anzahlBaeume);
ZeichneKarte(karteMitBaeumen);

Console.WriteLine("3) --- Speichere neue Karte ---");
SpeichereKarte(karteMitBaeumen, pfadMitBaeumen);
Console.WriteLine($"Karte in {pfadMitBaeumen} gespeichert.");

// Aufgabe 5: Winterkarte - Schnee ⬜ ist nur EIN char, alle anderen Symbole zwei
Console.WriteLine("4) --- Winterkarte laden ---");
string[,] winter = LadeKarteMitSurrogates("../../../weltkarte_winter.txt");
Console.WriteLine($"Winterkarte: {winter.GetLength(0)} Zeilen, {winter.GetLength(1)} Spalten");
ZeichneKarte(winter);

// ======================= Funktionen aus dem LiveCoding =======================

string[,] LadeKarte(string pfad)
{
    string[] zeilen = File.ReadAllLines(pfad);
    int hoehe = zeilen.Length;
    int breite = zeilen[0].Length / 2; // ein Emoji = 2 char

    string[,] karteAlsArray = new string[hoehe, breite];
    for (int y = 0; y < hoehe; y++)
    {
        for (int x = 0; x < breite; x++)
        {
            karteAlsArray[y, x] = zeilen[y].Substring(x * 2, 2);
        }
    }

    return karteAlsArray;
}

void ZeichneKarte(string[,] karte)
{
    for (int y = 0; y < karte.GetLength(0); y++)
    {
        for (int x = 0; x < karte.GetLength(1); x++)
        {
            Console.Write(karte[y, x]);
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

string[,] KopiereKarte(string[,] original)
{
    string[,] kopie = new string[original.GetLength(0), original.GetLength(1)];
    for (int y = 0; y < original.GetLength(0); y++)
    {
        for (int x = 0; x < original.GetLength(1); x++)
        {
            kopie[y, x] = original[y, x];
        }
    }

    return kopie;
}

void SpeichereKarte(string[,] karte, string pfad)
{
    string[] zeilen = new string[karte.GetLength(0)];
    for (int y = 0; y < karte.GetLength(0); y++)
    {
        string zeile = "";
        for (int x = 0; x < karte.GetLength(1); x++)
        {
            zeile += karte[y, x];
        }
        zeilen[y] = zeile;
    }

    File.WriteAllLines(pfad, zeilen);
}

// ======================= Aufgabe 1 + 4: Baeume, Mangroven, Palmen =======================

string[,] PflanzeBaeume(string[,] karteOhneBaeume, int limitAnBaeumen)
{
    string symbolDerErde = "🟫";
    string symbolDerSteine = "🗻";
    string symbolDesWassers = "🟦";
    string symbolDesSandes = "🟨";
    string symbolDerBaeume = "🌳";
    string symbolDerMangroven = "🌲";
    string symbolDerPalmen = "🌴";

    string[,] karteMitBaeumen = KopiereKarte(karteOhneBaeume);
    Random generator = new Random(101);
    int gepflanzteBaeume = 0;

    while (gepflanzteBaeume < limitAnBaeumen)
    {
        int y = generator.Next(0, karteMitBaeumen.GetLength(0));
        int x = generator.Next(0, karteMitBaeumen.GetLength(1));
        string ort = karteMitBaeumen[y, x];

        if (ort == symbolDerErde)
        {
            karteMitBaeumen[y, x] = symbolDerBaeume;
            gepflanzteBaeume++;
        }
        else if (ort == symbolDerSteine)
        {
            if (generator.NextDouble() < 0.1)
            {
                karteMitBaeumen[y, x] = symbolDerBaeume;
                gepflanzteBaeume++;
            }
        }
        // Aufgabe 1: Mangroven im Wasser mit 5% Chance
        else if (ort == symbolDesWassers)
        {
            if (generator.NextDouble() < 0.05)
            {
                karteMitBaeumen[y, x] = symbolDerMangroven;
                gepflanzteBaeume++;
            }
        }
        // Aufgabe 4: Palme auf Sand, rundherum entsteht Strand
        else if (ort == symbolDesSandes)
        {
            karteMitBaeumen[y, x] = symbolDerPalmen;
            ZeichneSandUmBaum(x, y, karteMitBaeumen);
            gepflanzteBaeume++;
        }
    }

    return karteMitBaeumen;
}

// ======================= Aufgabe 2: Endlosschleife verhindern =======================

double SetProzentWaldAufKarte(double wunschProzentBaeume, string[,] karte)
{
    string symbolDerErde = "🟫";
    string symbolDerSteine = "🗻";

    int anzahlSteineOderErde = 0;
    for (int y = 0; y < karte.GetLength(0); y++)
    {
        for (int x = 0; x < karte.GetLength(1); x++)
        {
            if (karte[y, x] == symbolDerErde || karte[y, x] == symbolDerSteine)
            {
                anzahlSteineOderErde++;
            }
        }
    }

    int anzahlOrte = karte.GetLength(0) * karte.GetLength(1);

    // Guard ❌: Wunsch passt nicht auf die Karte -> 80% des nutzbaren Platzes
    if (anzahlOrte * wunschProzentBaeume > anzahlSteineOderErde)
    {
        return 0.8 * anzahlSteineOderErde / anzahlOrte;
    }

    // gewuenschter Zustand ✅
    return wunschProzentBaeume;
}

// ======================= Aufgabe 3: Sandinseln =======================

string[,] SchuetteInselnAuf(string[,] karteOhneInseln, int limitAnInseln)
{
    string symbolDesWassers = "🟦";
    string symbolDesSandes = "🟨";

    string[,] karteMitInseln = KopiereKarte(karteOhneInseln);
    Random generator = new Random(42);
    int entstandeneInseln = 0;

    int hoehe = karteMitInseln.GetLength(0);
    int breite = karteMitInseln.GetLength(1);

    while (entstandeneInseln < limitAnInseln)
    {
        // Variante 1: links-oben (obere Grenze exklusive!)
        // int y = generator.Next(0, hoehe / 2);
        // int x = generator.Next(0, breite / 2);

        // Variante 2: rechts-unten
        // int y = generator.Next(hoehe / 2, hoehe);
        // int x = generator.Next(breite / 2, breite);

        // Variante 3: symmetrisch um den Mittelpunkt
        int y = generator.Next(hoehe / 4, hoehe * 3 / 4);
        int x = generator.Next(breite / 4, breite * 3 / 4);

        if (karteMitInseln[y, x] == symbolDesWassers)
        {
            karteMitInseln[y, x] = symbolDesSandes;
            entstandeneInseln++;
        }
    }

    return karteMitInseln;
}

// ======================= Aufgabe 4: Sand um die Palme =======================

// Liegt die Koordinate innerhalb der Karte?
bool IstAufKarte(int x, int y, string[,] karte)
{
    return 0 <= y && y < karte.GetLength(0) && 0 <= x && x < karte.GetLength(1);
}

// Setzt ein Feld auf Sand - aber nur, wenn es auf der Karte liegt und keine Palme ist.
void ZeichneSand(int x, int y, string[,] karte)
{
    // Guard ❌: ausserhalb der Karte
    if (!IstAufKarte(x, y, karte))
    {
        return;
    }

    // Guard ❌: Palmen werden nicht ueberschuettet
    if (karte[y, x] == "🌴")
    {
        return;
    }

    // gewuenschter Zustand ✅
    karte[y, x] = "🟨";
}

// Arrays sind Referenztypen: wir veraendern die uebergebene Karte direkt (kein return noetig).
void ZeichneSandUmBaum(int xPalme, int yPalme, string[,] karte)
{
    ZeichneSand(xPalme, yPalme - 1, karte); // Norden
    ZeichneSand(xPalme, yPalme + 1, karte); // Sueden
    ZeichneSand(xPalme - 1, yPalme, karte); // Westen
    ZeichneSand(xPalme + 1, yPalme, karte); // Osten
}

// ======================= Aufgabe 5: Symbole mit 1 oder 2 char =======================
// Frage 1: LadeKarte rechnet breite = Length / 2 und schneidet immer 2 char heraus.
//          Ein ⬜ ist aber nur 1 char -> ab dort ist alles um 1 char verschoben:
//          Substring erwischt "⬜ + halbes Emoji" bzw. "halbes + halbes" -> � und falsche Breite.
// Frage 2: ZaehleSymbole("❄️") liefert 2: U+2744 und U+FE0F sind beide normale char (keine Surrogates).
//          Darum verwenden wir in der Karte nur Symbole ohne Variation Selector.

// Zaehlt die Symbole einer Zeile.
// Emojis ueber U+FFFF (🟦 🌳 ...) bestehen aus ZWEI char: High Surrogate + Low Surrogate.
// ⬜ (U+2B1C) passt in 16 Bit und ist nur EIN char.
int ZaehleSymbole(string zeile)
{
    int anzahl = 0;
    int i = 0;
    while (i < zeile.Length)
    {
        if (char.IsHighSurrogate(zeile[i]))
        {
            i = i + 2; // High + Low Surrogate = ein Symbol
        }
        else
        {
            i = i + 1; // normales char
        }
        anzahl++;
    }
    return anzahl;
}

// Zerlegt eine Zeile in ihre Symbole (jedes Symbol als eigener string).
string[] ZerlegeZeile(string zeile)
{
    string[] symbole = new string[ZaehleSymbole(zeile)];
    int i = 0; // Position im string (char)
    for (int x = 0; x < symbole.Length; x++) // Position in der Karte (Symbol)
    {
        int laenge = 1;
        if (char.IsHighSurrogate(zeile[i]))
        {
            laenge = 2;
        }
        symbole[x] = zeile.Substring(i, laenge);
        i = i + laenge;
    }
    return symbole;
}

string[,] LadeKarteMitSurrogates(string pfad)
{
    string[] zeilen = File.ReadAllLines(pfad);
    int hoehe = zeilen.Length;
    int breite = ZaehleSymbole(zeilen[0]); // NICHT zeilen[0].Length / 2

    string[,] karte = new string[hoehe, breite];
    for (int y = 0; y < hoehe; y++)
    {
        string[] symbole = ZerlegeZeile(zeilen[y]);

        // Guard ❌: Zeile ist anders breit als die erste Zeile
        if (symbole.Length != breite)
        {
            Console.WriteLine($"⚠️ Zeile {y} hat {symbole.Length} statt {breite} Symbole.");
        }

        for (int x = 0; x < breite && x < symbole.Length; x++)
        {
            karte[y, x] = symbole[x];
        }
    }
    return karte;
}
