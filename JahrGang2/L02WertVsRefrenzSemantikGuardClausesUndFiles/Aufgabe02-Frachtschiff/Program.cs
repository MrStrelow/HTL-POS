using System;

Console.OutputEncoding = System.Text.Encoding.UTF8;

// Ein Schiff mit 10 leeren Stellplätzen
string[] everGiven = new string[] { "Leer", "Leer", "Leer", "Leer", "Leer", "Leer", "Leer", "Leer", "Leer", "Leer" };

Console.WriteLine("🚢 Willkommen im Ocean Array Terminal 🚢\n");

// Benutzereingaben absichern
int anzahlVorne = LeseZahlSicherEin("Wie viele Elektronik-Container sollen vorne geladen werden? ");
int anzahlHinten = LeseZahlSicherEin("Wie viele Textil-Container sollen hinten geladen werden? ");
int tauschA = LeseZahlSicherEin("Sicherheits-Check: Welchen Index möchtest du tauschen (A)? ");
int tauschB = LeseZahlSicherEin("Sicherheits-Check: Welchen Index möchtest du tauschen (B)? ");

Console.WriteLine("\nLadevorgang wird berechnet...\n");

// 1. Backup erstellen
string[] backup = ErstelleBackupPlan(everGiven);

// 2. Logistik-Prozess starten (Delegiert die Arbeit)
BeladeSchiffKomplett(everGiven, "Elektronik ⚡", anzahlVorne, "Textilien 👕", anzahlHinten, tauschA, tauschB);

// 3. Kontroll-Ausgabe
Console.WriteLine("Aktueller Ladeplan:");
for (int i = 0; i < everGiven.Length; i++)
{
    Console.WriteLine($"Platz {i}: {everGiven[i]}");
}


// --- LOKALE FUNKTIONEN ---

int LeseZahlSicherEin(string nachricht)
{
    int zahl;
    Console.Write(nachricht);

    // Die Bedingung liest die Eingabe, versucht zu parsen und negiert das Ergebnis (!).
    // Wenn TryParse 'false' liefert (also keine gültige Zahl), läuft die Schleife.
    while (!int.TryParse(Console.ReadLine(), out zahl))
    {
        Console.Clear();
        Console.WriteLine("❌ Ungültige Eingabe! Bitte tippe eine ganze Zahl ein.\n");
        Console.Write(nachricht);
    }

    return zahl;
}

string[] ErstelleBackupPlan(string[] schiff)
{
    string[] kopie = new string[schiff.Length];
    for (int i = 0; i < schiff.Length; i++)
    {
        kopie[i] = schiff[i];
    }
    return kopie;

    // Alternativ in einer Zeile: 
    // return (string[])schiff.Clone();
}

void ContainerTauschen(string[] schiff, int positionA, int positionB)
{
    string temp = schiff[positionA];
    schiff[positionA] = schiff[positionB];
    schiff[positionB] = temp;
}

void AuffuellenVonVorne(string[] schiff, string ladung, int anzahl)
{
    for (int i = 0; i < anzahl; i++)
    {
        if (i < schiff.Length) // Sicherheitscheck, damit wir nicht aus dem Array fallen
        {
            schiff[i] = ladung;
        }
    }
}

void AuffuellenVonHinten(string[] schiff, string ladung, int anzahl)
{
    for (int i = 0; i < anzahl; i++)
    {
        int index = schiff.Length - 1 - i;
        if (index >= 0) // Sicherheitscheck
        {
            schiff[index] = ladung;
        }
    }
}

void BeladeSchiffKomplett(string[] schiff, string prioLadung, int anzahlPrio, string standardLadung, int anzahlStandard, int tauschA, int tauschB)
{
    // Die Methoden werden aufgerufen und das Original-Array 'schiff' wird jeweils übergeben und manipuliert.
    AuffuellenVonVorne(schiff, prioLadung, anzahlPrio);
    AuffuellenVonHinten(schiff, standardLadung, anzahlStandard);

    // Sicherheitscheck vor dem Tauschen
    if (tauschA >= 0 && tauschA < schiff.Length && tauschB >= 0 && tauschB < schiff.Length)
    {
        ContainerTauschen(schiff, tauschA, tauschB);
    }
}