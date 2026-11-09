using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

// =====================================================================
// AUFGABE 02: GUARD CLAUSES & STADIONRUNDEN IM LEICHTATHLETIK-TURNIER
// =====================================================================
Console.WriteLine("\n=== AUFGABE 02: STADIONRUNDEN IM TURNIER ===");

// Originale Turnierdaten: je Bewerb 6 Läufe, Zeit für eine Stadionrunde (400 m) in Sekunden
string[] originalBewerbe = {
    "Sprint", "Sprint", "Sprint", "Sprint", "Sprint", "Sprint",
    "Hürden", "Hürden", "Hürden", "Hürden", "Hürden", "Hürden",
    "Mittelstrecke", "Mittelstrecke", "Mittelstrecke", "Mittelstrecke", "Mittelstrecke", "Mittelstrecke",
    "Langstrecke", "Langstrecke", "Langstrecke", "Langstrecke", "Langstrecke", "Langstrecke",
    "Schnellgehen", "Schnellgehen", "Schnellgehen", "Schnellgehen", "Schnellgehen", "Schnellgehen"
};

string[] originalAthleten = {
    "Lena Huber", "Jonas Gruber", "Mia Berger", "Elias Wagner", "Sara Pichler", "Paul Steiner",
    "Anna Moser", "David Hofer", "Lea Bauer", "Felix Mayer", "Nora Fuchs", "Tim Leitner",
    "Emma Wolf", "Luca Schwarz", "Hanna Brunner", "Noah Eder", "Lara Reiter", "Ben Winkler",
    "Sophie Lang", "Max Haas", "Julia Koller", "Leon Graf", "Clara Böhm", "Finn Aigner",
    "Marie Weiss", "Jakob Strasser", "Laura Kern", "Simon Egger", "Eva Holzer", "Moritz Lechner"
};

int[] originalRundenzeitenSek = {
    // Sprint (Min: 45 bei Index 2 | Max: 52 bei Index 1)
    47, 52, 45, 49, 51, 46,
    // Hürden (Min: 50 bei Index 10 | Max: 58 bei Index 8)
    55, 51, 58, 53, 50, 56,
    // Mittelstrecke (Min: 57 bei Index 15 | Max: 64 bei Index 14)
    62, 58, 64, 57, 60, 61,
    // Langstrecke (Min: 66 bei Index 22 | Max: 75 bei Index 20)
    72, 68, 75, 70, 66, 74,
    // Schnellgehen (Min: 92 bei Index 26 | Max: 110 bei Index 27)
    98, 105, 92, 110, 101, 95
};

string[] bewerbe; // TODO: klone originalBewerbe
string[] athleten; // TODO: klone originalAthleten
int[] rundenzeitenSek; // TODO: klone originalRundenzeitenSek

string gesuchterBewerb = "Sprint";
SucheBesteRunde("Ernst-Happel-Stadion", gesuchterBewerb, bewerbe, athleten, rundenzeitenSek);

gesuchterBewerb = "Schnellgehen";
SucheBesteRunde("Ernst-Happel-Stadion", gesuchterBewerb, bewerbe, athleten, rundenzeitenSek);

gesuchterBewerb = "Hürden";
SucheBesteRunde("Ernst-Happel-Stadion", gesuchterBewerb, bewerbe, athleten, rundenzeitenSek);

gesuchterBewerb = "Mittelstrecke";
SucheBesteRunde("Ernst-Happel-Stadion", gesuchterBewerb, bewerbe, athleten, rundenzeitenSek);

gesuchterBewerb = "Langstrecke";
SucheBesteRunde("Ernst-Happel-Stadion", gesuchterBewerb, bewerbe, athleten, rundenzeitenSek);

gesuchterBewerb = "Stabhochsprung";
SucheBesteRunde("Ernst-Happel-Stadion", gesuchterBewerb, bewerbe, athleten, rundenzeitenSek);

gesuchterBewerb = "Sprint";
SucheBesteRunde("Praterstadion", gesuchterBewerb, bewerbe, athleten, rundenzeitenSek);

// -------------------------------------------------------------------------
// Guard Clauses
// -------------------------------------------------------------------------
void SucheBesteRunde(string stadion, string bewerb, string[] bewerbe, string[] athleten, int[] rundenzeiten)
{
    if (stadion == "Ernst-Happel-Stadion")
    {
        if (bewerb == "Sprint" || bewerb == "Hürden" || bewerb == "Mittelstrecke" || bewerb == "Langstrecke" || bewerb == "Schnellgehen")
        {
            if (bewerb == "Schnellgehen")
            {
                //TODO: rufe FindeLangsamsteRunde auf.
            }
            else
            {
                //TODO: rufe FindeSchnellsteRunde auf.
            }
        }
        else
        {
            Console.WriteLine("❌ Fehler: Unbekannter Bewerb! Erlaubt sind nur Sprint, Hürden, Mittelstrecke, Langstrecke oder Schnellgehen.");
        }
    }
    else
    {
        Console.WriteLine("❌ Fehler: Das Turnier findet nur im Ernst-Happel-Stadion statt!");
    }
}

// -------------------------------------------------------------------------
// Aufgabe 2.2: Sucht die KÜRZESTE Rundenzeit (Minimum-Suche)
// -------------------------------------------------------------------------
int FindeSchnellsteRunde(string bewerb, string[] bewerbe, int[] rundenzeiten)
{
    int besterIndex = -1;
    int kuerzesteZeit = int.MaxValue;

    // TODO:

    return besterIndex;
}

// -------------------------------------------------------------------------
// Aufgabe 2.3: Sucht die LÄNGSTE Rundenzeit (Maximum-Suche für Schnellgehen)
// -------------------------------------------------------------------------
int FindeLangsamsteRunde(string bewerb, string[] bewerbe, int[] rundenzeiten)
{
    int besterIndex = -1;
    int laengsteZeit = -1;

    // TODO:

    return besterIndex;
}
