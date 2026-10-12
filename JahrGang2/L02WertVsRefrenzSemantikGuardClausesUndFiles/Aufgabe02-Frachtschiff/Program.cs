using System;

Console.OutputEncoding = System.Text.Encoding.UTF8;

// Ein Schiff mit 10 leeren Stellplätzen
string[] frachter = new string[] { "Leer", "Leer", "Leer", "Leer", "Leer", "Leer", "Leer", "Leer", "Leer", "Leer" };

Console.WriteLine("🚢 Willkommen im Ocean Array Terminal 🚢\n");

// Benutzereingaben absichern
int anzahlVorne = LeseZahlSicherEin("Wie viele Elektronik-Container sollen vorne geladen werden? ");
int anzahlHinten = LeseZahlSicherEin("Wie viele Textil-Container sollen hinten geladen werden? ");
int startIndex = LeseZahlSicherEin("A: Welcher Container soll getauscht werden (Index 0-9)? ");
int zielIndex = LeseZahlSicherEin("A: Mit welchem Platz soll er getauscht werden (Index 0-9)? ");
int weitererStartIndex = LeseZahlSicherEin("B: Welcher Container soll getauscht werden (Index 0-9)? ");
int weitererZielIndex = LeseZahlSicherEin("B: Mit welchem Platz soll er getauscht werden (Index 0-9)? ");

Console.WriteLine("\nLadevorgang wird berechnet...\n");

// 1. Kopiere den Frachter, falls wir beim Beladen diesen zerstören.
string[] backup = KopiereFrachter(frachter);

// 2. Belade das Schiff für die angegebenen Gueter.
BeladeSchiff(frachter, "⚡", anzahlVorne, "👕", anzahlHinten);
BehebeFehler(frachter, startIndex, zielIndex, weitererStartIndex, weitererZielIndex);

// 3. Kontroll-Ausgabe
Console.WriteLine("--- AKTUELLER FRACHTER-STATUS ---");
for (int i = 0; i < frachter.Length; i++)
{
    Console.WriteLine($"Stellplatz [{i}]: {frachter[i]}");
}

// 4. Lege Frachter zusammen
Console.WriteLine("\n--- VERBINDE SCHIFFSLADUNG TEST ---");
VerbindeSchiffsladung(frachter, backup);

Console.WriteLine("Zweiter Frachter sieht nun so aus:");
for (int i = 0; i < backup.Length; i++)
{
    Console.WriteLine($"Frachter 2 [{i}]: {backup[i]}");
}

// --- FUNKTIONEN ---

int LeseZahlSicherEin(string nachricht)
{
    int ergebnis;
    Console.Write(nachricht);

    // ungewuenschter Zustand: ❌ Usereingabe ist keine POSITIVE Zahl
    while (!int.TryParse(Console.ReadLine(), out ergebnis) || ergebnis < 0)
    {
        Console.Clear();
        Console.WriteLine("❌ Ungültige Eingabe. Bitte gib eine positive ganze Zahl ein.\n");
        Console.Write(nachricht);
    }

    return ergebnis;
}

string[] KopiereFrachter(string[] schiff)
{
    string[] kopie = new string[schiff.Length];

    for (int i = 0; i < schiff.Length; i++)
    {
        kopie[i] = schiff[i];
    }

    return kopie;
}

void ContainerTauschen(string[] schiff, int positionA, int positionB)
{
    // ungewuenschter Zustand: ❌ Index außerhalb des Arrays
    if (positionA < 0 || positionA >= schiff.Length || positionB < 0 || positionB >= schiff.Length)
    {
        Console.WriteLine("❌ Fehler beim Tauschen: Index außerhalb des Frachters.");
        return;
    }

    // gewuenschter Zustand: ✅
    string temp = schiff[positionA];
    schiff[positionA] = schiff[positionB];
    schiff[positionB] = temp;
}

void AuffuellenVonVorne(string[] schiff, string ladung, int anzahl)
{
    // ungewuenschter Zustand: ❌ Index außerhalb des Arrays
    if (schiff.Length < anzahl)
    {
        Console.WriteLine("❌ Anzahl der Container zu gross.");
        return;
    }

    for (int i = 0; i < anzahl; i++)
    {
        // ungewuenschter Zustand: ❌ Wir überschreiben einen bereits belegten Stellplatz!
        if (schiff[i] != "Leer")
        {
            Console.WriteLine($"❌ Abbruch: Stellplatz [{i}] darf nicht überschrieben werden! Dort befindet sich {schiff[i]}");
            return;
        }
        schiff[i] = ladung;
    }
}

void AuffuellenVonHinten(string[] schiff, string ladung, int anzahl)
{
    // ungewuenschter Zustand: ❌ Index außerhalb des Arrays
    if (schiff.Length < anzahl)
    {
        Console.WriteLine("❌ Anzahl der Container zu gross.");
        return;
    }

    for (int i = schiff.Length - 1; i >= 0; i--)
    {
        // ungewuenschter Zustand: ❌ Wir überschreiben einen bereits belegten Stellplatz!
        if (schiff[i] != "Leer")
        {
            Console.WriteLine($"❌ Abbruch: Stellplatz [{i}] darf nicht überschrieben werden! Dort befindet sich {schiff[i]}");
            return;
        }

        schiff[i] = ladung;
    }
}

void BeladeSchiff(string[] schiff, string ladungVorne, int anzahlVorne, string ladungHinten, int anzahlHinten)
{
    AuffuellenVonVorne(schiff, ladungVorne, anzahlVorne);
    AuffuellenVonHinten(schiff, ladungHinten, anzahlHinten);
}

void BehebeFehler(string[] schiff, int start, int ziel, int zweiterStart, int zweitesZiel)
{
    ContainerTauschen(schiff, start, ziel);
    ContainerTauschen(schiff, zweiterStart, zweitesZiel);
}

(int Belegt, int Frei) BerechnePlaetzeTuple(string[] schiff)
{
    int belegt = 0;
    int frei = 0;

    for (int i = 0; i < schiff.Length; i++)
    {
        if (schiff[i] == "Leer")
        {
            frei++;
        }
        else
        {
            belegt++;
        }
    }

    return (belegt, frei);
}

int BerechnePlaetzeOut(string[] schiff, out int frei)
{
    int belegt = 0;
    frei = 0;

    for (int i = 0; i < schiff.Length; i++)
    {
        if (schiff[i] == "Leer")
        {
            frei++;
        }
        else
        {
            belegt++;
        }
    }

    return belegt;
}

void VerbindeSchiffsladung(string[] ursprungsSchiff, string[] zielSchiff)
{
    //(int belegtUrsprung, int freiUrsprung) = BerechnePlaetzeTuple(ursprungsSchiff);
    //(int belegtZiel, int freiZiel)       = BerechnePlaetzeTuple(zielSchiff);

    int belegtUrsprung = BerechnePlaetzeOut(ursprungsSchiff, out int freiUrsprung);
    int belegtZiel = BerechnePlaetzeOut(zielSchiff, out int freiZiel);

    // ungewuenschter Zustand: ❌ Mehr Container auf dem Ursprünglichen Schiff als im Zielschiff frei sind.
    if (belegtUrsprung > freiZiel)
    {
        Console.WriteLine($"❌ Abbruch: Das Zielschiff hat nur {freiZiel} freie Plätze, " +
                          $"aber es sollen {belegtUrsprung} Container verladen werden.");
        return;
    }

    // gewuenschter Zustand: ✅
    for (int i = 0; i < ursprungsSchiff.Length; i++)
    {
        if (ursprungsSchiff[i] != "Leer")
        {
            for (int j = 0; j < zielSchiff.Length; j++)
            {
                if (zielSchiff[j] == "Leer")
                {
                    zielSchiff[j] = ursprungsSchiff[i];
                    break; 
                }
            }
        }
    }

    Console.WriteLine("✅ Schiffsladung erfolgreich kopiert!");
}