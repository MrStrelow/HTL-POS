Welche ``Konzepte`` der Programmiersprache üben wir hier?
* Arrays als ``Referenztypen``
* Delegieren von Arbeit an ``Funktionen``.
* Änderung der Werttypsemantik von ``int.TryParse`` durch *out*.

Welche ``Denkweisen`` üben wir hier?
* Wie teile ich ein großes Problem in kleinere Teilprobleme auf?
* Umgang mit falschen Benutzereingabe.

## Frachschiff-Terminal
Der automatische Lade-Algorithmus für die Beladung der Container ist ausgefallen. Unsere Frachschiffe müssen nun über ein manuelles Terminal-Interface beladen werden.
Die Funktionen zum Beladen müssen implementiert werden. Zusätzlich ist eine flexible Usereingaben notwenidg. Frage die Anwender des Programmes in einer Schleife so lange, bis wirklich eine gültige Zahl eingegeben wird.

### Aufgabe 1 - level: 🙂 - Logistik-System und sichere Eingaben implementieren
Implementiere die fehlenden lokalen Funktionen am Ende der Datei `Program.cs`. 
Arbeite zuerst [diese](animation.html) *Animation* durch um die Funktionen besser zu verstehen. Um diese zu sehen lade diese herunter und öffne diese mit einem Web-browser.

```csharp
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

// Ein Schiff mit 10 leeren Stellplätzen
string[] frachter = new string[] { "Leer", "Leer", "Leer", "Leer", "Leer", "Leer", "Leer", "Leer", "Leer", "Leer" };

Console.WriteLine("🚢 Willkommen im Ocean Array Terminal 🚢\n");

// Benutzereingaben absichern
int anzahlVorne = 0;   // Frage wie viele Elektronik-Container vorne geladen werden sollen
int anzahlHinten = 0;   // Frage wie viele Textil-Container hinten geladen werden sollen
int startIndex = 0;   // Erster Fehler: Frage nach welche Container getauscht werden sollen: hier ist der erste Index. 
int zielIndex = 0;   // Erster Fehler: Frage nach welche Container getauscht werden sollen: hier ist der zweite Index. 
int weitererStartIndex = //Zweiter Fehler: Frage nach welche Container getauscht werden sollen: hier ist der erste Index. 
int weitererZielIndex = // Zweiter Fehler: Frage nach welche Container getauscht werden sollen: hier ist der zweite Index. 

Console.WriteLine("\nLadevorgang wird berechnet...\n");

// 1. Kopiere den Frachter, falls wir was beim Beladen diesen zerstören.
string[] backup = { "?" }; // kopiere einen bestehenden Frachter mit einer Funktion.

// 2. Belade das Schiff für die angegebenen Gueter.
BeladeSchiff(frachter, "⚡", anzahlVorne, "👕", anzahlHinten);
BehebeFehler(frachter, startIndex, zielIndex, weitererStartIndex, weitererZielIndex);

// 3. Kontroll-Ausgabe
// Gib den Inhalt des gesamten Frachters aus. 
// Verwende interpolated Strings und eine Zählschleife oder ForEach Schleife.


// --- FUNKTIONEN ---
int LeseZahlSicherEin(string nachricht)
{
    throw new NotImplementedException();
}

string[] KopiereFrachter(string[] schiff)
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

void BeladeSchiff(string[] schiff, string prioLadung, int anzahlPrio, string standardLadung, int anzahlStandard)
{
    throw new NotImplementedException();
}

void BehebeFehler(string[] schiff, int start, int ziel)
{
    throw new NotImplementedException();
}
```

### Aufgabe 2 - level: 🤔 - Frachter zusammenlegen.
Verwende die Kopie des Frachters und lege diese zusammen in das ursprüngliche Schiff. 
Schreibe dazu folgende Funktionen. Die Funktion *BerechnePlaetze* ist eine Hilfsfunktion welche für eine ``Guard Clause``
in *VerbindeSchiffsladung* verwendet werden soll. In *BerechnePlaetze* sollen die freien und bereits belegten Plätze berechnet werden.

```csharp
void VerbindeSchiffsladung(string[] ursprungsSchiff, string[] zielSchiff)
{
    throw new NotImplementedException();
}

int BerechnePlaetzeOut(string[] schiff, out int frei)
{
    throw new NotImplementedException();
}

(int Belegt, int Frei) BerechnePlaetzeTuple(string[] schiff)
{
    throw new NotImplementedException();
}
```

### Teste folgende Eingaben
#### Alles Funktioniert

Gib ganz normale, realistische Werte ein, die ins Schiff passen.

- Vorne: `3`

- Hinten: `2`

- Tausch A: `0` (mit `9`)

- Tausch B: `1` (mit `8`)

- Erwartetes Ergebnis: Stellplatz 0 und 1 haben nun Textilien, Stellplatz 8 und 9 haben Elektronik. Es gibt keine Fehlermeldungen.

#### Falsche Typen

Die `LeseZahlSicherEin`-Methode muss Endlosschleifen bei Quatsch-Eingaben verhindern.

- Eingabe: Gib statt einer Zahl Buchstaben wie `Hallo` oder Sonderzeichen wie `!?` ein. Drücke auch mal nur die `Enter`-Taste ohne Text.

- Erwartetes Ergebnis: Die Konsole wird geleert und die Fehlermeldung `"❌ Ungültige Eingabe..."` erscheint, gefolgt von der erneuten Frage. Das Programm darf nicht abstürzen!

#### negative Indices

Negative Indices existieren nicht. Wir müssen deshalb noch folgendes Teste.

- Vorne: `-5`

- Tausch A: `-1` (mit `5`)

- Erwartetes Ergebnis: `"❌ Ungültige Eingabe. Bitte gib eine positive ganze Zahl ein."`

#### Zu viele Container

Was passiert, wenn mehr Container geladen werden, als das Schiff Plätze hat?

- Vorne: `15`

- Erwartetes Ergebnis: Die Warnung `"❌ Anzahl der Container zu gross."` muss erscheinen. Die vorderen Container werden gar nicht geladen.

#### Überschreiben von Plätzen

Was passiert, wenn die vorderen und hinteren Container zusammen mehr als 10 ergeben?

- Vorne: `6`

- Hinten: `6`

- Erwartetes Ergebnis: Die hintere Ladefunktion muss merken, dass Platz 4 schon belegt ist. Die Fehlermeldung `"❌ Abbruch: Stellplatz [4] darf nicht überschrieben werden! Dort befindet sich Elektronik ⚡"` muss erscheinen.

#### Indizes außerhalb des Arrays

Was passiert, wenn man Container tauschen will, die nicht auf dem Schiff sind?

- Tausch-Index eingeben: `10` oder `99`

- Erwartetes Ergebnis: Die Methode `ContainerTauschen` muss eingreifen und `"❌ Fehler beim Tauschen: Index außerhalb des Frachters."` ausgeben.

#### Verbinde Schiffsladung

Hier kannst du prüfen, ob das Umladen auf einen anderen Frachter funktioniert.

- **Normaler Kopiervorgang (Genug Platz):**
  - `quell1`: `[ "Elektronik ⚡", "Textilien 👕", "Leer", "Leer" ]`
  - `ziel1`: `[ "Leer", "Textilien 👕", "Leer", "Leer" ]`
  - **Erwartetes Ergebnis:** `ziel1` hat nun `[ "Elektronik ⚡", "Textilien 👕", "Textilien 👕", "Leer" ]`

- **Zielschiff hat zu wenig Platz:**
  - `quell2`: `[ "Elektronik ⚡", "Elektronik ⚡", "Textilien 👕", "Leer" ]`
  - `ziel2`: `[ "Textilien 👕", "Textilien 👕", "Leer", "Leer" ]`
  - **Erwartetes Ergebnis:** Eine Abbruch-Meldung in der Konsole. Das Zielschiff darf NICHT verändert werden!

- **Quellschiff ist komplett leer:**
  - `quell3`: `[ "Leer", "Leer" ]`
  - `ziel3`: `[ "Elektronik ⚡", "Leer" ]`
  - **Erwartetes Ergebnis:** `ziel3` bleibt unberührt bei `[ "Elektronik ⚡", "Leer" ]`.