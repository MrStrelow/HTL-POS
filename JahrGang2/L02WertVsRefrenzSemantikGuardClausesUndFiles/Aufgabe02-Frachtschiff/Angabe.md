Welche ``Konzepte`` der Programmiersprache üben wir hier?
* Arrays als **Referenztypen** (Änderungen in einer Methode verändern das Original-Array im Heap)
* **Modularisierung:** Funktionen, die andere Funktionen aufrufen, um komplexe Abläufe zu strukturieren
* **Top-Level Statements & Lokale Funktionen:** Strukturierung von Code ohne umschließende Klassen
* **Benutzereingaben absichern:** Sicheres Einlesen von Zahlen mit ``int.TryParse`` und ``while``-Schleifen

Welche ``Denkweisen`` üben wir hier?
* Wie teile ich ein großes Problem in kleinere Teilprobleme auf?
* Wie gestalte ich ein Programm "idiotensicher" (Robustheit), sodass es bei einer falschen Benutzereingabe nicht abstürzt?

## Die Geschichte: Das Terminal-Interface der "MS Ocean Array"
Du bist der Chef-Entwickler für die Hafenlogistik am Terminal. Das riesige Frachtschiff *MS Ocean Array* hat gerade angelegt. Der Lade-Algorithmus ist ausgefallen und das Schiff muss über ein manuelles Terminal-Interface beladen werden.

Das Problem: Die Hafenarbeiter tippen mit dicken Arbeitshandschuhen auf der Tastatur. Oft tippen sie aus Versehen Buchstaben statt Zahlen ein (z.B. "drei" statt "3"), was dein Programm zum Absturz bringen würde! 
Du musst die Funktionen zum Beladen schreiben und zusätzlich eine sichere Eingabemethode programmieren, die den Nutzer in einer Schleife so lange fragt, bis er wirklich eine gültige Zahl eingegeben hat.

### Aufgabe 1 - level: 🚢 - Logistik-System und sichere Eingaben implementieren
Implementiere die fehlenden lokalen Funktionen am Ende der Datei `Program.cs`. 

```csharp
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
    throw new NotImplementedException();
}

string[] ErstelleBackupPlan(string[] schiff)
{
    throw new NotImplementedException();    
}

void ContainerTauschen(string[] schiff, int positionA, int positionB)
{
    throw new NotImplementedException();
}

void AuffuellenVonVorne(string[] schiff, string ladung, int anzahl)
{
    throw new NotImplementedException();
}

void AuffuellenVonHinten(string[] schiff, string ladung, int anzahl)
{
    throw new NotImplementedException();
}

void BeladeSchiffKomplett(string[] schiff, string prioLadung, int anzahlPrio, string standardLadung, int anzahlStandard, int tauschA, int tauschB)
{
    throw new NotImplementedException();
}
```