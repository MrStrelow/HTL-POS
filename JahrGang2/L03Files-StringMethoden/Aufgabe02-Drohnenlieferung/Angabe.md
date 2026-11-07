Welche ``Konzepte`` der Programmiersprache üben wir hier?
* Files mit ``File.ReadAllLines`` einlesen und mit ``File.WriteAllLines`` schreiben, ``File.Exists``
* ``String-Methoden`` zum Bereinigen, Zerlegen, Prüfen und Formatieren von Text (siehe Tabelle unten)
* ``char``-Methoden wie ``char.IsDigit`` und ``ToString()``
* ``Named Tuples`` als Eingangs- und Ausgangsparameter
* ``Guard-Clauses`` mit *early exit* und ``out``-Parameter im Stil von ``int.TryParse``
* Arrays als ``Referenztypen`` und Zugriff auf ein Zeichen mit ``plan[y][x]``
* Euklidische Distanz und die lineare Funktion ``y = k·x + d`` im Gitter wie im Unterricht

Welche ``Denkweisen`` üben wir hier?
* Wie mache ich aus "schmutzigem" Text (Leerzeichen, Groß-/Kleinschreibung, Tippfehler) saubere Daten?
* Wie teile ich ein großes Problem in viele kleine ``Funktionen`` auf und teste diese einzeln?
* Wie gehe ich mit fehlerhaften Datensätzen um, ohne dass das ganze Programm abbricht?

Aufwand: ca. 2–3 Stunden. Eine Lösung findest du in [Loesung.cs](Loesung.cs) – schau sie dir nur an, wenn du gar nicht weiterkommst. Voraussetzung ist die gemeinsam programmierte *Länge einer Linie berechnen und einzeichnen* im Unterricht sowie Aufgabe 1 (Stempeluhr).

## Drohnen-Lieferdienst SkyParcel
Die Firma *SkyParcel* liefert Pakete per Drohne innerhalb der Stadt. Die Aufträge kommen als Textdatei ``auftraege.txt`` aus dem Bestellsystem – leider von verschiedenen Mitarbeiter:innen händisch getippt. Groß-/Kleinschreibung ist chaotisch, es gibt zu viele Leerzeichen, Kommentare, Leerzeilen und fehlerhafte Zeilen.

Dein Programm soll
1. die Aufträge einlesen und bereinigen,
2. für jeden gültigen Auftrag die Flugstrecke und den Preis berechnen,
3. die Route in den Stadtplan (``stadtplan.txt``) einzeichnen und prüfen, ob sie durch eine Sperrzone ``#`` führt,
4. einen Bericht ``bericht.txt`` und ein Fehlerprotokoll ``fehler.txt`` schreiben.

Die ``Funktionen`` sind in ``Program.cs`` bereits *deklariert*. Ersetze *throw new NotImplementedException();* **schrittweise** und teste jede ``Funktion`` direkt nach dem Implementieren mit einem Aufruf im Hauptprogramm.

>Die Pfade sind relativ zur ``.exe`` in ``bin/Debug/net10.0``. Deshalb beginnen sie mit ``../../../``, damit die Files neben der ``Program.cs`` gefunden werden.

### Die Dateien

``auftraege.txt``
```
# Drohnen-Lieferauftraege der Firma SkyParcel
# Format: nummer=...;start=x|y;ziel=x|y;gewicht=...kg;kunde=...
# Koordinaten: 0|0 ist oben links. 1 Feld = 0,5 km

  nummer=LF-7 ; start=1|1 ; ziel=6|5 ; gewicht=1,5kg ; kunde=mÜLLER gmbh
NUMMER=LF-0012;START=2|9;ZIEL=17|3;GEWICHT=3,2KG;KUNDE=  bäckerei huber
nummer=LF-13 ; start=15|2 ; ziel=3|2 ; gewicht=0,8kg ; kunde=apotheke am platz

nummer=LF-14 ; start=4|10 ; ziel=6|1 ; gewicht=2kg ; kunde=htl werkstätte
nummer=LF-x15 ; start=1|1 ; ziel=2|2 ; gewicht=1kg ; kunde=tippfehler ag
nummer=LF-16 ; start=1|1 ; ziel=25|3 ; gewicht=1kg ; kunde=weit weg kg
nummer=LF-17 ; start=3|3 ; ziel=8|8 ; gewicht=7,5kg ; kunde=schwer und co
nummer=LF-18 ; start=2|5 ; gewicht=1kg ; kunde=vergessen ohg
nummer=LF-19 ; start=0|10 ; ziel=19|10 ; gewicht=1kg ; kunde=quer durch gmbh
nummer=LF-20 ; start=18|11 ; ziel=12|0 ; gewicht=4kg ; kunde=elektro maier

...
```

``stadtplan.txt`` (20 Spalten × 12 Zeilen, ``#`` ist eine Sperrzone, z.B. ein Spital mit Hubschrauberlandeplatz)
```
....................
....................
....................
....................
....................
....................
....................
....................
.........##.........
.........##.........
.........##.........
.........##.........
```

### String-Methoden
In den Folien haben wir ``[]``, ``Substring``, ``Length``, ``Split``, ``char.Is...`` und ``ToString()`` kennengelernt. Hier kommen weitere ``Methoden`` dazu. Lies die *Signatur* so: **Rückgabetyp** ``Name(Eingangsparameter)``. Alle Methoden *verändern den String nicht* (Strings sind unveränderlich), sondern liefern einen **neuen** String zurück.

| Signatur | Was macht sie? | Beispiel |
|---|---|---|
| ``string Trim()`` | entfernt Leerzeichen/Tabs vorne und hinten | ``"  ab  ".Trim()`` → ``"ab"`` |
| ``string TrimEnd()`` | entfernt Leerzeichen nur hinten | ``"ab  ".TrimEnd()`` → ``"ab"`` |
| ``string ToUpper()`` / ``string ToLower()`` | alles groß / klein | ``"Lf-7".ToUpper()`` → ``"LF-7"`` |
| ``bool StartsWith(string wert)`` | beginnt der String mit ``wert``? | ``"# Info".StartsWith("#")`` → ``true`` |
| ``bool EndsWith(string wert)`` | endet der String mit ``wert``? | ``"3kg".EndsWith("kg")`` → ``true`` |
| ``bool Contains(char wert)`` | kommt das Zeichen irgendwo vor? | ``"2\|3".Contains('\|')`` → ``true`` |
| ``int IndexOf(char wert)`` | Index des **ersten** Vorkommens, sonst ``-1`` | ``"start=2\|3".IndexOf('=')`` → ``5`` |
| ``string Substring(int start)`` | alles ab ``start`` bis zum Ende | ``"start=2\|3".Substring(6)`` → ``"2\|3"`` |
| ``string Substring(int start, int laenge)`` | ``laenge`` Zeichen ab ``start`` | ``"start=2\|3".Substring(0, 5)`` → ``"start"`` |
| ``string Replace(char alt, char neu)`` | ersetzt **jedes** ``alt`` durch ``neu`` | ``"3,2".Replace(',', '.')`` → ``"3.2"`` |
| ``string Replace(string alt, string neu)`` | wie oben, für Teilstrings | ``"3kg".Replace("kg", "")`` → ``"3"`` |
| ``string PadLeft(int breite, char fuell)`` | füllt **links** auf, bis ``breite`` erreicht ist | ``"7".PadLeft(4, '0')`` → ``"0007"`` |
| ``string PadRight(int breite)`` | füllt **rechts** mit Leerzeichen auf (Tabellenspalten) | ``"LF".PadRight(5)`` → ``"LF   "`` |
| ``string[] Split(char trenner)`` | zerlegt an jedem ``trenner`` | ``"a;b;c".Split(';')`` → ``["a","b","c"]`` |
| ``string[] Split(char trenner, StringSplitOptions optionen)`` | mit ``StringSplitOptions.RemoveEmptyEntries`` fallen leere Teile weg | ``"a  b".Split(' ', StringSplitOptions.RemoveEmptyEntries)`` → ``["a","b"]`` |
| ``static bool string.IsNullOrWhiteSpace(string wert)`` | ist der String ``null``, leer oder nur Leerzeichen? | ``string.IsNullOrWhiteSpace("   ")`` → ``true`` |
| ``static string string.Join(string trenner, string[] werte)`` | Gegenteil von ``Split``: fügt ein Array zusammen | ``string.Join(" ", ["a","b"])`` → ``"a b"`` |
| ``new string(char zeichen, int anzahl)`` | erzeugt einen String aus lauter gleichen Zeichen | ``new string('-', 5)`` → ``"-----"`` |
| ``static bool char.IsDigit(char c)`` | ist ``c`` eine Ziffer? | ``char.IsDigit('7')`` → ``true`` |

>**Kommazahlen:** ``double.TryParse`` hängt von der Spracheinstellung des Computers ab (``3,2`` oder ``3.2``?). Wir machen es unabhängig: Zuerst ``Replace(',', '.')``, dann
>``double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out double wert)``. ``InvariantCulture`` bedeutet: Der Punkt ist *immer* das Komma-Zeichen.

---

### Aufgabe 1 - level: 🙂 - Ein Feld lesen
Implementiere ``bool TryLeseFeld(string teil, string schluessel, out string wert)``.

``teil`` ist z.B. ``" NUMMER=LF-0012 "``. Suche mit ``IndexOf('=')`` das ``=``. Der Teil links davon (``Trim`` + ``ToLower``) muss gleich ``schluessel`` sein. Der Teil rechts davon (``Trim``) ist der ``wert``.
Gib ``false`` zurück, wenn kein ``=`` vorkommt, der Schlüssel nicht passt oder der Wert leer ist. Verwende eine ``Guard-Clause``!

| Aufruf | Rückgabe | ``wert`` |
|---|---|---|
| ``TryLeseFeld(" NUMMER=LF-0012 ", "nummer", out w)`` | ``true`` | ``"LF-0012"`` |
| ``TryLeseFeld("start=2\|9", "ziel", out w)`` | ``false`` | ``""`` |
| ``TryLeseFeld("kunde=   ", "kunde", out w)`` | ``false`` | ``""`` |
| ``TryLeseFeld("kunde huber", "kunde", out w)`` | ``false`` | ``""`` |

### Aufgabe 2 - level: 🙂🤔 - Felder umwandeln
Implementiere die vier ``Funktionen``. Jede ``Try...``-Funktion arbeitet wie ``int.TryParse``: ``true`` + Ergebnis im ``out``-Parameter, oder ``false``.

1. ``bool TryNormalisiereNummer(string text, out string nummer)``
   - Groß schreiben, muss mit ``"LF-"`` beginnen.
   - Danach 1–4 Zeichen, die **alle** Ziffern sind (``foreach`` + ``char.IsDigit``).
   - Ergebnis immer 4-stellig: ``"lf-7"`` → ``"LF-0007"``, ``"LF-x15"`` → ``false``.
2. ``bool TryParseKoordinate(string text, out (int X, int Y) punkt)``
   - ``"12|3"`` → ``(12, 3)``. Prüfe zuerst mit ``Contains``, dann ``Split('|')`` und ``int.TryParse``.
3. ``bool TryParseGewicht(string text, out double gewicht)``
   - ``"3,2KG"`` → ``3.2``. Klein schreiben, muss mit ``"kg"`` enden, ``"kg"`` mit ``Substring`` abschneiden, ``,`` durch ``.`` ersetzen, parsen. Gewicht muss ``> 0`` sein.
4. ``string FormatiereKunde(string text)``
   - Jedes Wort: erster Buchstabe groß, Rest klein. ``"  mÜLLER gmbh"`` → ``"Müller Gmbh"``.
   - Tipp: ``Split`` mit ``RemoveEmptyEntries``, jedes Wort mit ``Substring(0, 1).ToUpper()`` + ``Substring(1).ToLower()``, dann ``string.Join``.

### Aufgabe 3 - level: 🤔 - Ganzen Auftrag zerlegen
Implementiere ``TryParseAuftrag``. Der Auftrag wird als ``Named Tuple`` zurückgegeben:
```csharp
(string Nummer, (int X, int Y) Start, (int X, int Y) Ziel, double GewichtKg, string Kunde)
```
- ``Split(';')`` – es müssen genau **5** Teile sein, in der Reihenfolge *nummer, start, ziel, gewicht, kunde*.
- Verwende ``TryLeseFeld`` und die ``Funktionen`` aus Aufgabe 2.
- Bei jedem Fehler: ``fehlergrund`` setzen (z.B. ``"4 statt 5 Felder"``, ``"ungültige Auftragsnummer 'LF-x15'"``) und ``return false;`` (*early exit*).

### Aufgabe 4 - level: 🙂 - Strecke und Preis
1. ``BerechneDistanzFelder`` – die Euklidische Distanz aus dem gemeinsamen Beispiel.
2. ``BerechnePreis(double streckeKm, double gewichtKg)``
   - ``Grundgebuehr`` 3,50 € + ``PreisProKm`` 1,20 € pro km.
   - Jedes kg über ``FreigewichtKg`` (2 kg) kostet ``ZuschlagProKg`` 0,80 € extra.
   - Auf 2 Nachkommastellen runden: ``Math.Round(preis, 2)``.

Kontrolle: ``LF-0007`` hat 6,40 Felder = 3,20 km und kostet **7,34 €**.

### Aufgabe 5 - level: 🤔😵‍💫 - Stadtplan und Route
Den Stadtplan lesen wir mit ``File.ReadAllLines`` in ein ``string[] stadtplan`` ein. ``stadtplan[y]`` ist eine Zeile (ein ``string``), ``stadtplan[y][x]`` ist ein einzelnes Zeichen dieser Zeile (ein ``char``). 0/0 ist oben links!

1. ``IstImStadtplan`` – liegt ein Punkt innerhalb? (``plan.Length`` = Anzahl Zeilen, ``plan[y].Length`` = Anzahl Spalten)
2. ``IstAufRoute`` – liegt das Feld ``(x|y)`` auf der Geraden zwischen Start und Ziel? Erweitere dafür das gemeinsame Beispiel (``y = k·x + d``, Ursprung im Startpunkt):
   - **a)** Ziel liegt **links** vom Start (``dx < 0``): Prüfe mit ``Math.Min`` / ``Math.Max``, ob ``x`` zwischen Start und Ziel liegt.
   - **b)** Die Gerade ist **steil** (``|dy| > |dx|``), z.B. ``LF-0014``: Mit ``x`` als Laufachse entstehen Lücken! Tausche die Rollen: ``y`` wird die Laufachse und ``x = start.X + Round(k' · (y - start.Y))`` mit ``k' = dx / dy``.
   - **c)** Senkrechte (``dx == 0``) und waagrechte (``dy == 0``) Routen dürfen nicht durch 0 dividieren.
3. ``IstRouteFrei`` – durchlaufe den Stadtplan Zeile für Zeile, Zeichen für Zeichen. Liegt ein ``'#'`` auf der Route, ist sie nicht frei.
4. ``ZeichneKarte`` – wie im Unterricht: Für jedes Feld entscheiden, welches Zeichen gedruckt wird: ``'S'``, ``'Z'``, ``'*'`` (Route), ``'X'`` (Route trifft ``'#'``) oder das Zeichen aus dem Stadtplan. Baue jede Zeile mit ``ToString()`` und einem Leerzeichen zusammen und gib sie mit ``TrimEnd()`` aus.

**Frage:** Strings sind unveränderlich – ``stadtplan[y][x] = '*';`` ergibt einen Compilerfehler. Warum ist das hier sogar praktisch? (Tipp: Was würde sonst mit dem Stadtplan für den nächsten Auftrag passieren?)

```
📦 LF-0014 für Htl Werkstätte          📦 LF-0019 für Quer Durch Gmbh
. . . . . . Z . . . .                   . . . . . . . . . # # . . . . .
. . . . . . * . . . .                   S * * * * * * * * X X * * * * * ... Z
. . . . . * . . . . .                   ⛔ Route führt durch eine Sperrzone (X)!
. . . . * . . . . # #
. . . . S . . . . # #
```

### Aufgabe 6 - level: 🤔 - Alles zusammenbauen, Bericht schreiben
Schreibe das Hauptprogramm:
1. Prüfe mit ``File.Exists``, ob beide Files existieren (*early exit*).
2. Lies alle Zeilen ein. Überspringe mit ``continue`` Leerzeilen (``string.IsNullOrWhiteSpace``) und Kommentare (``StartsWith("#")``).
3. Für jeden Auftrag in dieser Reihenfolge (``Guard-Clause``!):
   - nicht parsebar → Fehler
   - Start oder Ziel außerhalb des Stadtplans → Fehler
   - schwerer als ``MaxGewichtKg`` → Fehler
   - Strecke länger als ``MaxStreckeKm`` → Fehler
   - Route durch Sperrzone → Karte ausgeben, Fehler
   - sonst ✅: Karte ausgeben, Preis berechnen, Zeile für den Bericht merken
4. Merke dir Fehler als ``"Zeile {nr}: {grund}"`` – ``nr`` ist die Zeilennummer in der Datei (ab 1).
5. Baue die Tabelle mit ``ErzeugeKopfzeile`` und ``FormatiereBerichtZeile`` (``PadRight`` / ``PadLeft``). Kundennamen länger als 18 Zeichen werden mit ``Substring`` gekürzt und bekommen ein ``"…"``.
6. Unter der Tabelle: Trennlinie (``new string('-', ...)``), Gesamtumsatz und längste Strecke.
7. Da wir am Anfang nicht wissen, wie viele Aufträge gültig sind, legen wir die Arrays mit ``zeilen.Length`` an und zählen mit. ``Kuerze`` schneidet die leeren Plätze vor dem Schreiben ab.
8. Schreibe ``bericht.txt`` und ``fehler.txt`` mit ``File.WriteAllLines``.

Erwartetes ``bericht.txt``:
```
NUMMER   KUNDE                  STRECKE   GEWICHT     PREIS
LF-0007  Müller Gmbh            3,20 km   1,50 kg    7,34 €
LF-0012  Bäckerei Huber         8,08 km   3,20 kg   14,15 €
LF-0013  Apotheke Am Platz      6,00 km   0,80 kg   10,70 €
LF-0014  Htl Werkstätte         4,61 km   2,00 kg    9,03 €
LF-0020  Elektro Maier          6,26 km   4,00 kg   12,62 €
-----------------------------------------------------------
Gesamtumsatz: 53,84 €
Längste Strecke: LF-0012 (8,08 km)
```

Erwartetes ``fehler.txt``:
```
Zeile 10: ungültige Auftragsnummer 'LF-x15'
Zeile 11: LF-0016 – Koordinate außerhalb des Stadtplans
Zeile 12: LF-0017 – zu schwer (7,50 kg, max. 5,00 kg)
Zeile 13: 4 statt 5 Felder
Zeile 14: LF-0019 – Route durch Sperrzone
```

### Bonus - level: 😵‍💫
* Schreibe zusätzlich jede Karte in ein File ``routen.txt``.
* Füge in ``auftraege.txt`` eigene Aufträge hinzu, die deine Sonderfälle aus Aufgabe 5 testen (senkrecht, nach links oben, ...).
* Die Drohne darf nicht direkt *neben* einer Sperrzone fliegen (Sicherheitsabstand 1 Feld). Erweitere ``IstRouteFrei``.
