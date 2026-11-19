// Vorlage = Ergebnis des LiveCodings. Erweitere sie laut Angabe.md.
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

// 1) Karte einlesen: Textfile (1D: eine Zeile pro Element) -> 2D-Array
string[,] karte = LadeKarte(pfadOhneBaeume);
Console.WriteLine($"1) --- Karte mit {karte.GetLength(0)} Zeilen und {karte.GetLength(1)} Spalten geladen ---");
ZeichneKarte(karte);

// 2) Wie viele Baeume pflanzen wir? 25% aller Felder
double prozentWaldAufKarte = 0.25;
int anzahlFelder = karte.GetLength(0) * karte.GetLength(1);
int anzahlBaeume = (int)(anzahlFelder * prozentWaldAufKarte);

Console.WriteLine($"2) --- pflanze {anzahlBaeume} 🌳 Baeume auf einer Karte mit {anzahlFelder} Feldern ---");
string[,] karteMitBaeumen = PflanzeBaeume(karte, anzahlBaeume);
ZeichneKarte(karteMitBaeumen);

// 3) Speichern
Console.WriteLine("3) --- Speichere neue Karte ---");
SpeichereKarte(karteMitBaeumen, pfadMitBaeumen);
Console.WriteLine($"Karte in {pfadMitBaeumen} gespeichert.");

// ======================= Funktionen =======================

// --- Zustaendigkeit der Funktion ---
// Liest das Textfile ein und wandelt es in ein 2D-Array um.
// Jede Zeile im File ist eine Zeile (y) der Karte, jedes Emoji eine Spalte (x).
string[,] LadeKarte(string pfad)
{
    string[] zeilen = File.ReadAllLines(pfad);

    // Achtung: Ein Emoji wie 🟦 besteht aus ZWEI char! "🟦".Length ist 2.
    // Deshalb ist die Breite der Karte die halbe Laenge der Zeile.
    int hoehe = zeilen.Length;
    int breite = zeilen[0].Length / 2;

    string[,] karteAlsArray = new string[hoehe, breite];

    // --- Zustaendigkeit der Kontrollstruktur ---
    // Wandere die Zeilen (y) ab ...
    for (int y = 0; y < hoehe; y++)
    {
        // ... und in jeder Zeile die Spalten (x).
        for (int x = 0; x < breite; x++)
        {
            // Das x-te Emoji beginnt beim Index x * 2 und ist 2 char lang.
            karteAlsArray[y, x] = zeilen[y].Substring(x * 2, 2);
        }
    }

    return karteAlsArray;
}

// --- Zustaendigkeit der Funktion ---
// Zeichne die Karte (2D-Array) auf das Terminal.
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

// --- Zustaendigkeit der Funktion ---
// Erzeugt ein NEUES 2D-Array mit dem gleichen Inhalt.
// Arrays sind Referenztypen (siehe L02): ohne Kopie wuerden wir die Originalkarte veraendern.
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

// --- Zustaendigkeit der Funktion ---
// Pflanzt zufaellig Baeume: auf Erde immer, auf Stein mit 10% Chance.
string[,] PflanzeBaeume(string[,] karteOhneBaeume, int limitAnBaeumen)
{
    // --- Emojis ---
    string symbolDerErde = "🟫";
    string symbolDerSteine = "🗻";
    string symbolDerBaeume = "🌳";

    string[,] karteMitBaeumen = KopiereKarte(karteOhneBaeume);

    // --- Generator fuer Zufallszahlen: EINMAL anlegen, mit Seed -> immer die gleiche Welt ---
    Random generator = new Random(101);

    int gepflanzteBaeume = 0;

    // --- Zustaendigkeit der Kontrollstruktur ---
    // Wir wissen nicht, wie oft wir ein Feld ziehen muessen (manchmal treffen wir Wasser)
    // -> while-Schleife. Gezaehlt wird nur, wenn wirklich ein Baum waechst.
    while (gepflanzteBaeume < limitAnBaeumen)
    {
        // 1) Zufaellige Koordinate: obere Grenze ist EXKLUSIVE -> passt genau zu GetLength
        int y = generator.Next(0, karteMitBaeumen.GetLength(0));
        int x = generator.Next(0, karteMitBaeumen.GetLength(1));

        string ort = karteMitBaeumen[y, x];

        // 2) Erde -> Baum mit 100% Chance
        if (ort == symbolDerErde)
        {
            karteMitBaeumen[y, x] = symbolDerBaeume;
            gepflanzteBaeume++;
        }
        // 3) Stein -> Baum mit 10% Chance (NextDouble liefert 0.0 bis 0.999...)
        else if (ort == symbolDerSteine)
        {
            if (generator.NextDouble() < 0.1)
            {
                karteMitBaeumen[y, x] = symbolDerBaeume;
                gepflanzteBaeume++;
            }
        }
    }

    return karteMitBaeumen;
}

// --- Zustaendigkeit der Funktion ---
// Wandelt das 2D-Array zurueck in Textzeilen (1D) und speichert sie.
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
