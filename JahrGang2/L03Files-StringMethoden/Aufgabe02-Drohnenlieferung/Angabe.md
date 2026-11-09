Welche ``Konzepte`` der Programmiersprache üben wir hier?
* Files mit ``File.ReadAllLines`` einlesen und mit ``File.WriteAllLines`` schreiben, ``File.Exists``
* ``String-Methoden`` zum Bereinigen, Zerlegen, Prüfen und Formatieren von Text (siehe Tabelle am Ende der Angabe)
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

>🎬 **Animation:** Zu jedem Schritt gibt es eine Animation, die **ohne Code** zeigt, was passieren soll: [Animated-Slides-Drohnenlieferung.html](Animated-Slides-Drohnenlieferung.html) (im Browser öffnen).

## Drohnen-Lieferdienst SkyParcel
Die Firma *SkyParcel* liefert Pakete per Drohne innerhalb der Stadt. Die Aufträge kommen als Textdatei ``auftraege.txt`` aus dem Bestellsystem – leider von verschiedenen Mitarbeiter:innen händisch getippt. Groß-/Kleinschreibung ist chaotisch, es gibt zu viele Leerzeichen, Kommentare, Leerzeilen und fehlerhafte Zeilen.

Dein Programm soll
1. die Aufträge einlesen und bereinigen,
2. für jeden gültigen Auftrag die Flugstrecke und den Preis berechnen,
3. die Route in den Stadtplan (``stadtplan.txt``) einzeichnen und prüfen, ob sie durch eine Sperrzone ``#`` führt,
4. einen Bericht ``bericht.txt`` und ein Fehlerprotokoll ``fehler.txt`` schreiben.

Die ``Funktionen`` sind in ``Program.cs`` bereits *deklariert*. Ersetze *throw new NotImplementedException();* **Schritt für Schritt**. Zu jedem Schritt gibt es in ``Program.cs`` einen auskommentierten Testblock (``/* ---------- Test Schritt N ---------- ... */``). Entferne ``/*`` und ``*/``, starte das Programm und vergleiche mit dem **erwarteten Output**. Die ``[ ]`` in der Ausgabe zeigen dir, wo ein String anfängt und aufhört.

>Kommazahlen werden mit der Spracheinstellung des Computers ausgegeben. Der erwartete Output gilt für Deutsch (``3,2``). Bei Englisch steht ``3.2`` da – das ist auch richtig.

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
nummer=LF-21 ; start=(5|3) ; ziel=(11|6) ; gewicht=800g ; kunde=café   CENTRAL ;
nummer=LF-22 ; start=7|7 ; ziel=7|7 ; gewicht=1kg ; kunde=nirgendwo gmbh
nummer=lf-12 ; start=1|2 ; ziel=3|4 ; gewicht=1kg ; kunde=doppelt kg
nummer=LF-23 ; start=2|2 ; ziel=4|4 ; gewicht=-1kg ; kunde=minus ag
nummer=LF-24 ; start=3|1 ; ziel=8|1 ; gewicht=2,5 kg ; kunde=leer zeichen og
```

>🔧 **Reparieren oder ❌ melden?** Nicht jeder Tippfehler macht einen Auftrag wertlos. Die Regel lautet: **Ist eindeutig, was gemeint war, reparieren wir still.** Beispiele sind ``(5|3)`` mit Klammern, ``800g`` statt kg oder ein ``;`` am Zeilenende. **Könnte es mehreres bedeuten oder ist der Auftrag sinnlos, melden wir einen Fehler** – niemals raten! Ein Beispiel ist eine Nummer, die es schon gibt: Welcher der beiden Aufträge gilt? Überlege dir für jede Zeile der Datei vorher selbst, in welche Gruppe sie gehört.

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

---

### Schritt 1 - level: 🙂 - Dateien finden und einlesen
🎬 [Animation zu Schritt 1](Animated-Slides-Drohnenlieferung.html#schritt1)

Bevor wir etwas berechnen, müssen wir beide Dateien finden und einlesen.
- ``File.Exists(pfad)`` liefert ``true``, wenn es die Datei gibt.
- ``File.ReadAllLines(pfad)`` liefert ein ``string[]`` – jede Zeile ist ein Element, **auch Leerzeilen und Kommentare**.
- Beim Stadtplan ist ``plan[y]`` eine Zeile (``string``) und ``plan[y][x]`` ein Zeichen (``char``).

Es gibt hier nichts zu implementieren: Entferne die Kommentarzeichen beim Test für Schritt 1 und überlege dir, warum die Ausgabe so aussieht.

| Ausdruck | Ergebnis |
|---|---|
| ``File.Exists(auftragsPfad)``, ``File.Exists(kartenPfad)`` | ``true``, ``true`` |
| ``File.ReadAllLines(auftragsPfad).Length`` | ``20`` |
| ``plan.Length`` / ``plan[0].Length`` | ``12`` Zeilen / ``20`` Spalten |
| ``plan[8]`` | ``".........##........."`` |
| ``plan[8][9]`` | ``'#'`` |

Erwarteter Output (Test Schritt 1):
```
--- Schritt 1 ---
True True
20
12 Zeilen x 20 Spalten
.........##.........
#
```

### Schritt 2 - level: 🙂 - Ein Feld lesen
🎬 [Animation zu Schritt 2](Animated-Slides-Drohnenlieferung.html#schritt2)

Implementiere ``bool TryLeseFeld(string teil, string schluessel, out string wert)``.

``teil`` ist z.B. ``" NUMMER=LF-0012 "``. Suche mit ``IndexOf('=')`` das ``=``. Der Teil links davon (``Trim`` + ``ToLower``) muss gleich ``schluessel`` sein. Der Teil rechts davon (``Trim``) ist der ``wert``.
Gib ``false`` zurück, wenn kein ``=`` vorkommt, der Schlüssel nicht passt oder der Wert leer ist. Verwende eine ``Guard-Clause``!

| Aufruf | Rückgabe | ``wert`` |
|---|---|---|
| ``TryLeseFeld(" NUMMER=LF-0012 ", "nummer", out w)`` | ``true`` | ``"LF-0012"`` |
| ``TryLeseFeld("start=2\|9", "ziel", out w)`` | ``false`` | ``""`` |
| ``TryLeseFeld("kunde=   ", "kunde", out w)`` | ``false`` | ``""`` |
| ``TryLeseFeld("kunde huber", "kunde", out w)`` | ``false`` | ``""`` |

Erwarteter Output (Test Schritt 2):
```
--- Schritt 2 ---
True [LF-0012]
False []
False []
False []
```

### Schritt 3 - level: 🙂🤔 - Felder umwandeln
🎬 [Animation zu Schritt 3](Animated-Slides-Drohnenlieferung.html#schritt3)

Implementiere die vier ``Funktionen``. Jede ``Try...``-Funktion arbeitet wie ``int.TryParse``: ``true`` + Ergebnis im ``out``-Parameter, oder ``false``.

1. ``bool TryNormalisiereNummer(string text, out string nummer, int stellen = 4)``
   - Groß schreiben, muss mit ``"LF-"`` beginnen.
   - Danach 1 bis ``stellen`` Zeichen, die **alle** Ziffern sind (``foreach`` + ``char.IsDigit``).
   - Ergebnis immer ``stellen``-stellig: ``"lf-7"`` → ``"LF-0007"``, ``"LF-x15"`` → ``false``.
   - ``stellen`` ist ein **Default-Parameter** (Standard ``4``). Ändert die Firma einmal ihr Nummernformat, muss niemand die Funktion umschreiben.

   >**Default-Parameter:** Ein Parameter mit ``= wert`` in der Signatur darf beim Aufruf **weggelassen** werden – dann gilt der angegebene Standardwert. Default-Parameter stehen immer **am Ende** der Parameterliste. Wir verwenden sie statt fest eingebauter „magischer Zahlen“: Der Normalfall bleibt kurz, Sonderfälle sind trotzdem möglich.
2. ``bool TryParseKoordinate(string text, out (int X, int Y) punkt)``
   - ``"12|3"`` → ``(12, 3)``. Prüfe zuerst mit ``Contains``, dann ``Split('|')`` und ``int.TryParse``.
   - Reparatur 🔧 (ganz am Anfang): Klammern wie in ``"(5|3)"`` mit ``Replace`` entfernen.
3. ``bool TryParseGewicht(string text, out double gewicht)``
   - ``"3,2KG"`` → ``3.2``. Klein schreiben, muss mit ``"kg"`` enden, ``"kg"`` mit ``Substring`` abschneiden, ``,`` durch ``.`` ersetzen, parsen. Gewicht muss ``> 0`` sein.
   - Reparatur 🔧: Endet der Text **nicht** auf ``"kg"``, aber auf ``"g"`` (``"800g"``), ist es eine Gramm-Angabe. Schneide ein Zeichen ab und rechne mal ``0.001``.
     Denk nach: Warum musst du **zuerst** auf ``"kg"`` prüfen und erst danach auf ``"g"``?
   - Guard ❌: Ist das Gewicht nicht ``> 0`` (z.B. ``"-1kg"``), setze ``gewicht = 0`` und liefere ``false``.
4. ``string FormatiereKunde(string text)``
   - Jedes Wort: erster Buchstabe groß, Rest klein. ``"  mÜLLER gmbh"`` → ``"Müller Gmbh"``.
   - Tipp: ``Split`` mit ``RemoveEmptyEntries``, jedes Wort mit ``Substring(0, 1).ToUpper()`` + ``Substring(1).ToLower()``, dann ``string.Join``.

| Aufruf | Rückgabe | ``out`` |
|---|---|---|
| ``TryNormalisiereNummer("lf-7", out n)`` | ``true`` | ``"LF-0007"`` |
| ``TryNormalisiereNummer("LF-x15", out n)`` | ``false`` | ``""`` |
| ``TryNormalisiereNummer("LF-12345", out n)`` | ``false`` | ``""`` (mehr als 4 Ziffern) |
| ``TryNormalisiereNummer("lf-7", out n, 6)`` | ``true`` | ``"LF-000007"`` |
| ``TryNormalisiereNummer("LF-12345", out n, 5)`` | ``true`` | ``"LF-12345"`` |
| ``TryParseKoordinate("12\|3", out p)`` | ``true`` | ``(12, 3)`` |
| ``TryParseKoordinate("12-3", out p)`` | ``false`` | ``(0, 0)`` |
| ``TryParseKoordinate("(5\|3)", out p)`` | ``true`` | ``(5, 3)`` 🔧 |
| ``TryParseGewicht("3,2KG", out g)`` | ``true`` | ``3.2`` |
| ``TryParseGewicht("3,2", out g)`` | ``false`` | ``0`` (keine Einheit) |
| ``TryParseGewicht("0kg", out g)`` | ``false`` | ``0`` (nicht ``> 0``) |
| ``TryParseGewicht("800g", out g)`` | ``true`` | ``0.8`` 🔧 |
| ``TryParseGewicht("-1kg", out g)`` | ``false`` | ``0`` (nicht ``> 0``) |
| ``FormatiereKunde("  mÜLLER gmbh")`` | ``"Müller Gmbh"`` | – |

Erwarteter Output (Test Schritt 3):
```
--- Schritt 3 ---
True [LF-0007]
False []
False []
True [LF-000007]
True [LF-12345]
True (12, 3)
False (0, 0)
True (5, 3)
True 3,2
False 0
False 0
True 0,8
False 0
[Müller Gmbh]
```

### Schritt 4 - level: 🤔 - Ganzen Auftrag zerlegen
🎬 [Animation zu Schritt 4](Animated-Slides-Drohnenlieferung.html#schritt4)

Implementiere ``TryParseAuftrag``. Der Auftrag wird als ``Named Tuple`` zurückgegeben:
```csharp
(string Nummer, (int X, int Y) Start, (int X, int Y) Ziel, double GewichtKg, string Kunde)
```
- Reparatur 🔧: Ein ``;`` am Zeilenende würde ein leeres 6. Feld erzeugen. Schneide es **vor** dem ``Split`` mit ``TrimEnd(' ', ';')`` ab.
- ``Split(';')`` – es müssen genau **5** Teile sein, in der Reihenfolge *nummer, start, ziel, gewicht, kunde*.
- Verwende ``TryLeseFeld`` und die ``Funktionen`` aus Schritt 3.
- Bei jedem Fehler: ``fehlergrund`` setzen (z.B. ``"4 statt 5 Felder"``, ``"ungültige Auftragsnummer 'LF-x15'"``) und ``return false;`` (*early exit*).

| Zeile | Rückgabe | ``auftrag`` / ``fehlergrund`` |
|---|---|---|
| ``"  nummer=LF-7 ; start=1\|1 ; ziel=6\|5 ; gewicht=1,5kg ; kunde=mÜLLER gmbh"`` | ``true`` | ``("LF-0007", (1, 1), (6, 5), 1.5, "Müller Gmbh")`` |
| ``"nummer=LF-18 ; start=2\|5 ; gewicht=1kg ; kunde=vergessen ohg"`` | ``false`` | ``"4 statt 5 Felder"`` |
| ``"nummer=LF-x15 ; start=1\|1 ; ziel=2\|2 ; gewicht=1kg ; kunde=tippfehler ag"`` | ``false`` | ``"ungültige Auftragsnummer 'LF-x15'"`` |
| ``"nummer=LF-21 ; start=(5\|3) ; ziel=(11\|6) ; gewicht=800g ; kunde=café   CENTRAL ;"`` | ``true`` 🔧 | ``("LF-0021", (5, 3), (11, 6), 0.8, "Café Central")`` |

Erwarteter Output (Test Schritt 4):
```
--- Schritt 4 ---
True (LF-0007, (1, 1), (6, 5), 1,5, Müller Gmbh) []
False [4 statt 5 Felder]
False [ungültige Auftragsnummer 'LF-x15']
True (LF-0021, (5, 3), (11, 6), 0,8, Café Central) []
```

### Schritt 5 - level: 🙂 - Strecke und Preis
🎬 [Animation zu Schritt 5](Animated-Slides-Drohnenlieferung.html#schritt5)

1. ``BerechneDistanzFelder`` – die Euklidische Distanz aus dem gemeinsamen Beispiel.
2. ``BerechnePreis(double streckeKm, double gewichtKg)``
   - ``Grundgebuehr`` 3,50 € + ``PreisProKm`` 1,20 € pro km.
   - Jedes kg über ``FreigewichtKg`` (2 kg) kostet ``ZuschlagProKg`` 0,80 € extra.
   - Auf 2 Nachkommastellen runden: ``Math.Round(preis, 2)``.

Kontrolle: ``LF-0007`` hat 6,40 Felder = 3,20 km und kostet **7,34 €**.

| Aufruf | Rückgabe | Rechnung |
|---|---|---|
| ``BerechneDistanzFelder((1, 1), (6, 5))`` | ``6.40`` | √(5² + 4²) |
| ``BerechneDistanzFelder((15, 2), (3, 2))`` | ``12.00`` | waagrecht, 12 Felder |
| ``BerechnePreis(3.2, 1.5)`` | ``7.34`` | 3,50 + 3,2 · 1,20 |
| ``BerechnePreis(6.0, 0.8)`` | ``10.70`` | 3,50 + 6 · 1,20 |
| ``BerechnePreis(1.0, 4.0)`` | ``6.30`` | 3,50 + 1,20 + 2 kg · 0,80 |

Erwarteter Output (Test Schritt 5):
```
--- Schritt 5 ---
6,40
12,00
7,34
10,70
6,30
```

### Schritt 6 - level: 🤔😵‍💫 - Stadtplan und Route
🎬 [Animation zu Schritt 6](Animated-Slides-Drohnenlieferung.html#schritt6)

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

| Aufruf | Rückgabe | Warum? |
|---|---|---|
| ``IstImStadtplan(plan, (19, 11))`` | ``true`` | Ecke rechts unten |
| ``IstImStadtplan(plan, (20, 3))`` | ``false`` | nur Spalten 0–19 |
| ``IstImStadtplan(plan, (3, -1))`` | ``false`` | negative Zeile |
| ``IstAufRoute((1, 1), (6, 5), 2, 2)`` | ``true`` | liegt auf der Geraden |
| ``IstAufRoute((1, 1), (6, 5), 2, 4)`` | ``false`` | zu weit unten |
| ``IstAufRoute((15, 2), (3, 2), 7, 2)`` | ``true`` | Fall a) + c): nach links, waagrecht |
| ``IstAufRoute((4, 10), (6, 1), 5, 6)`` | ``true`` | Fall b): steil |
| ``IstRouteFrei(plan, (1, 1), (6, 5))`` | ``true`` | keine Sperrzone |
| ``IstRouteFrei(plan, (0, 10), (19, 10))`` | ``false`` | quer durch ``##`` |

Erwarteter Output (Test Schritt 6):
```
--- Schritt 6 ---
True False False
True False
True True
True False
. . . . . . . . . . . . . . . . . . . .
. . . . . . Z . . . . . . . . . . . . .
. . . . . . * . . . . . . . . . . . . .
. . . . . . * . . . . . . . . . . . . .
. . . . . * . . . . . . . . . . . . . .
. . . . . * . . . . . . . . . . . . . .
. . . . . * . . . . . . . . . . . . . .
. . . . . * . . . . . . . . . . . . . .
. . . . * . . . . # # . . . . . . . . .
. . . . * . . . . # # . . . . . . . . .
. . . . S . . . . # # . . . . . . . . .
. . . . . . . . . # # . . . . . . . . .
```

### Schritt 7 - level: 🤔 - Alles zusammenbauen, Bericht schreiben
🎬 [Animation zu Schritt 7](Animated-Slides-Drohnenlieferung.html#schritt7)

Schreibe das Hauptprogramm:
1. Prüfe mit ``File.Exists``, ob beide Files existieren (*early exit*).
2. Lies alle Zeilen ein und gehe sie mit einer ``foreach``-Schleife durch. Überspringe mit ``continue`` Leerzeilen (``string.IsNullOrWhiteSpace``) und Kommentare (``StartsWith("#")``).
   >``foreach`` statt ``for``: Wir brauchen keinen Index, um die Zeilen zu lesen. Die Zeilennummer für die Meldung ist **kein** Grund für eine ``for``-Schleife – zähle sie selbst mit (``int zeilenNummer = 0;`` vor der Schleife, ``zeilenNummer++;`` als **erste** Anweisung in der Schleife, also noch vor jedem ``continue``).
3. Für jeden Auftrag in dieser Reihenfolge (``Guard-Clause``!):
   - nicht parsebar → Fehler
   - Auftragsnummer kam schon vor → Fehler ``"{nummer} – doppelte Auftragsnummer"``. Merke dir dafür jede erfolgreich gelesene Nummer in einem ``string[] bekannteNummern`` und prüfe vorher mit einer ``foreach``-Schleife, ob sie schon drinsteht.
     Denk nach: Warum reparieren wir das nicht, indem wir einfach den zweiten Auftrag nehmen?
   - Start oder Ziel außerhalb des Stadtplans → Fehler
   - Start und Ziel sind gleich → Fehler ``"{nummer} – Start und Ziel sind gleich"`` (Tupel kannst du direkt mit ``==`` vergleichen)
   - schwerer als ``MaxGewichtKg`` → Fehler
   - Strecke länger als ``MaxStreckeKm`` → Fehler
   - Route durch Sperrzone → Karte ausgeben, Fehler
   - sonst ✅: Karte ausgeben, Preis berechnen, Zeile für den Bericht merken
4. Merke dir Fehler als ``"Zeile {zeilenNummer}: {grund}"`` – ``zeilenNummer`` ist die Zeilennummer in der Datei (ab 1).
5. Baue die Tabelle mit ``string ErzeugeKopfzeile(int maxKundenLaenge = 18)`` und ``string FormatiereBerichtZeile(string nummer, string kunde, double km, double kg, double preis, int maxKundenLaenge = 18)`` (``PadRight`` / ``PadLeft``).
   - Kundennamen länger als ``maxKundenLaenge`` werden mit ``Substring(0, maxKundenLaenge - 1)`` gekürzt und bekommen ein ``"…"``.
   - Die Kundenspalte ist in **beiden** Funktionen ``maxKundenLaenge + 2`` breit. Beide haben denselben Default-Parameter (``18``), damit Kopfzeile und Zeilen zusammenpassen. Im Hauptprogramm lässt du ihn weg.
6. Unter der Tabelle: Trennlinie (``new string('-', ...)``), Gesamtumsatz und längste Strecke.
7. Da wir am Anfang nicht wissen, wie viele Aufträge gültig sind, legen wir die Arrays mit ``zeilen.Length`` an und zählen mit. ``Kuerze`` schneidet die leeren Plätze vor dem Schreiben ab.
8. Schreibe ``bericht.txt`` und ``fehler.txt`` mit ``File.WriteAllLines``.

Testfälle – welche Zeile aus ``auftraege.txt`` landet wo?

| Zeile | Auftrag | Ergebnis |
|---|---|---|
| 1–4, 8 | Kommentar / Leerzeile | übersprungen (``continue``) |
| 5, 6, 7, 9, 15 | LF-0007, LF-0012, LF-0013, LF-0014, LF-0020 | ✅ Karte + Bericht |
| 10 | ``LF-x15`` | ❌ nicht parsebar |
| 11 | ``ziel=25\|3`` | ❌ außerhalb des Stadtplans |
| 12 | ``7,5kg`` | ❌ zu schwer |
| 13 | ``ziel`` fehlt | ❌ 4 statt 5 Felder |
| 14 | quer durch ``##`` | ❌ Sperrzone (Karte wird trotzdem gezeigt) |
| 16 | Klammern, ``800g``, ``;`` am Ende, viele Leerzeichen | 🔧 repariert → ✅ LF-0021 |
| 17 | Start = Ziel | ❌ Start und Ziel sind gleich |
| 18 | ``lf-12`` wird zu ``LF-0012`` – die gibt es schon in Zeile 6! | ❌ doppelte Auftragsnummer |
| 19 | ``-1kg`` | ❌ ungültiges Gewicht |
| 20 | ``2,5 kg`` mit Leerzeichen | ✅ LF-0024 (``TryParse`` erlaubt Leerzeichen am Rand) |

Erwartete Konsolenausgabe (gekürzt – nach jeder Karte folgt eine Leerzeile, ``...`` = weitere Karten):
```
📦 LF-0007 für Müller Gmbh
. . . . . . . . . . . . . . . . . . . .
. S . . . . . . . . . . . . . . . . . .
. . * . . . . . . . . . . . . . . . . .
. . . * * . . . . . . . . . . . . . . .
. . . . . * . . . . . . . . . . . . . .
. . . . . . Z . . . . . . . . . . . . .
. . . . . . . . . . . . . . . . . . . .
. . . . . . . . . . . . . . . . . . . .
. . . . . . . . . # # . . . . . . . . .
. . . . . . . . . # # . . . . . . . . .
. . . . . . . . . # # . . . . . . . . .
. . . . . . . . . # # . . . . . . . . .
✅ 3,20 km, 7,34 €

...

📦 LF-0019 für Quer Durch Gmbh
...
S * * * * * * * * X X * * * * * * * * Z
. . . . . . . . . # # . . . . . . . . .
⛔ Route führt durch eine Sperrzone (X)!

...

8 fehlerhafte Aufträge -> fehler.txt
```

Erwartetes ``bericht.txt``:
```
NUMMER   KUNDE                  STRECKE   GEWICHT     PREIS
LF-0007  Müller Gmbh            3,20 km   1,50 kg    7,34 €
LF-0012  Bäckerei Huber         8,08 km   3,20 kg   14,15 €
LF-0013  Apotheke Am Platz      6,00 km   0,80 kg   10,70 €
LF-0014  Htl Werkstätte         4,61 km   2,00 kg    9,03 €
LF-0020  Elektro Maier          6,26 km   4,00 kg   12,62 €
LF-0021  Café Central           3,35 km   0,80 kg    7,52 €
LF-0024  Leer Zeichen Og        2,50 km   2,50 kg    6,90 €
-----------------------------------------------------------
Gesamtumsatz: 68,26 €
Längste Strecke: LF-0012 (8,08 km)
```

Erwartetes ``fehler.txt``:
```
Zeile 10: ungültige Auftragsnummer 'LF-x15'
Zeile 11: LF-0016 – Koordinate außerhalb des Stadtplans
Zeile 12: LF-0017 – zu schwer (7,50 kg, max. 5,00 kg)
Zeile 13: 4 statt 5 Felder
Zeile 14: LF-0019 – Route durch Sperrzone
Zeile 17: LF-0022 – Start und Ziel sind gleich
Zeile 18: LF-0012 – doppelte Auftragsnummer
Zeile 19: LF-0023 – ungültiges Gewicht '-1kg'
```

### Bonus - level: 😵‍💫
* Schreibe zusätzlich jede Karte in ein File ``routen.txt``.
* Füge in ``auftraege.txt`` eigene Aufträge hinzu, die deine Sonderfälle aus Schritt 6 testen (senkrecht, nach links oben, ...).
* Die Drohne darf nicht direkt *neben* einer Sperrzone fliegen (Sicherheitsabstand 1 Feld). Erweitere ``IstRouteFrei``.

---

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
