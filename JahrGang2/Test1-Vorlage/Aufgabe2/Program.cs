using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

// =====================================================================
// AUFGABE 02: GUARD CLAUSES & ZUGSUCHE AB WIEN
// =====================================================================
Console.WriteLine("\n=== AUFGABE 02: ZUGSUCHE AB WIEN ===");

// Originale Fahrplandaten
string[] originalZiele = {
    "Salzburg", "Salzburg", "Salzburg", "Salzburg", "Salzburg", "Salzburg",
    "Linz", "Linz", "Linz", "Linz", "Linz", "Linz",
    "Graz", "Graz", "Graz", "Graz", "Graz", "Graz",
    "Innsbruck", "Innsbruck", "Innsbruck", "Innsbruck", "Innsbruck", "Innsbruck",
    "Stadlau", "Stadlau", "Stadlau", "Stadlau", "Stadlau", "Stadlau"
};

string[] originalZuege = {
    "RJX 760", "RJ 540", "WB 910", "ICE 228", "D 1012", "NJ 466",
    "ICE 28", "WEST 908", "RJX 62", "RJ 642", "CJX 5", "R 2040",
    "RJ 533", "RJ 651", "EC 151", "D 753", "REX 9", "R 4010",
    "RJX 162", "RJX 662", "NJ 420", "ICE 1204", "EC 164", "D 1016",
    "REX 8", "S80", "R 2514", "CJX 9", "S80 B", "R 2520"
};

int[] originalFahrtzeitenMin = {
    // Salzburg (Max: 215 bei Index 2 | Min: 142 bei Index 4)
    172, 150, 215, 168, 142, 195,
    // Linz (Max: 128 bei Index 7 | Min: 74 bei Index 9)
    85, 128, 77, 74, 98, 88,
    // Graz (Max: 220 bei Index 12 | Min: 153 bei Index 16)
    220, 156, 185, 160, 153, 198,
    // Innsbruck (Max: 345 bei Index 21 | Min: 254 bei Index 19)
    310, 254, 290, 345, 258, 275,
    // Stadlau (Max: 26 bei Index 25 | Min: 9 bei Index 28)
    14, 26, 11, 22, 9, 16
};

string[] ziele; // TODO: klone originalZiele
string[] zuege; // TODO: klone originalZuege
int[] fahrtzeitenMin; // TODO: klone originalFahrtzeitenMin

string benutzerZiel = "Salzburg";
SuchePassendeVerbindung("Wien", benutzerZiel, ziele, zuege, fahrtzeitenMin);

benutzerZiel = "Stadlau";
SuchePassendeVerbindung("Wien", benutzerZiel, ziele, zuege, fahrtzeitenMin);

benutzerZiel = "Linz";
SuchePassendeVerbindung("Wien", benutzerZiel, ziele, zuege, fahrtzeitenMin);

benutzerZiel = "Graz";
SuchePassendeVerbindung("Wien", benutzerZiel, ziele, zuege, fahrtzeitenMin);

benutzerZiel = "Innsbruck";
SuchePassendeVerbindung("Wien", benutzerZiel, ziele, zuege, fahrtzeitenMin);

benutzerZiel = "Berlin";
SuchePassendeVerbindung("Wien", benutzerZiel, ziele, zuege, fahrtzeitenMin);

benutzerZiel = "Stadlau";
SuchePassendeVerbindung("Salzburg", benutzerZiel, ziele, zuege, fahrtzeitenMin);

// -------------------------------------------------------------------------
// Guard Clauses
// -------------------------------------------------------------------------
void SuchePassendeVerbindung(string start, string ziel, string[] ziele, string[] zuege, int[] fahrtzeiten)
{
    if (start == "Wien")
    {
        if (ziel == "Linz" || ziel == "Salzburg" || ziel == "Graz" || ziel == "Innsbruck" || ziel == "Stadlau")
        {
            if (ziel == "Stadlau")
            {
                //TODO: rufe FindeSchnellsteVerbindung auf.
            }
            else
            {
                //TODO: rufe FindeGemuetlichsteVerbindung auf.
            }
        }
        else
        {
            Console.WriteLine("❌ Fehler: Unbekanntes Ziel! Erlaubt sind nur Linz, Salzburg, Graz, Innsbruck oder Stadlau.");
        }
    }
    else
    {
        Console.WriteLine("❌ Fehler: Der Startbahnhof muss immer 'Wien' sein!");
    }
}

// -------------------------------------------------------------------------
// Aufgabe 2.2: Sucht die KÜRZESTE Fahrtzeit (Minimum-Suche für Stadlau)
// -------------------------------------------------------------------------
int FindeSchnellsteVerbindung(string ziel, string[] ziele, int[] fahrtzeiten)
{
    int besterIndex = -1;
    int kuerzesteZeit = int.MaxValue;

    // TODO:

    return besterIndex;
}

// -------------------------------------------------------------------------
// Aufgabe 2.3: Sucht die LÄNGSTE Fahrtzeit (Maximum-Suche für Hauptstädte)
// -------------------------------------------------------------------------
int FindeGemuetlichsteVerbindung(string ziel, string[] ziele, int[] fahrtzeiten)
{
    int besterIndex = -1;
    int laengsteZeit = -1;

    // TODO:

    return besterIndex;
}