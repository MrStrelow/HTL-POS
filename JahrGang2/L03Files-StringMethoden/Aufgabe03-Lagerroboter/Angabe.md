Welche ``Konzepte`` der Programmiersprache üben wir hier?
* Files mit ``File.ReadAllLines`` einlesen und mit ``File.WriteAllLines`` schreiben, ``File.Exists``
* ``String-Methoden`` zum Bereinigen, Zerlegen und Formatieren von Text (siehe Tabelle am Ende der Angabe)
* Ein ``string`` als "Liste von Zeichen": ``text[i]``, ``IndexOf`` mit ``char``, ``ToString()``
* ``Named Tuples`` als Eingangs- und Ausgangsparameter
* ``Guard-Clauses`` mit *early exit* und ``out``-Parameter im Stil von ``int.TryParse``
* Arrays als ``Referenztypen``: eine ``Funktion`` verändert das übergebene ``string[]``

Welche ``Denkweisen`` üben wir hier?
* Wie mache ich aus "schmutzigem" Text saubere Befehle?
* Wie teile ich ein großes Problem in kleine ``Funktionen`` auf und teste diese einzeln?
* Wie gehe ich mit fehlerhaften Befehlen um, ohne dass das ganze Programm abbricht?

>**Guard-Clauses:** In jeder ``Funktion`` prüfen wir zuerst alle *ungewünschten Zustände ❌* und verlassen die ``Funktion`` sofort mit ``return`` (*early exit*). Erst ganz unten steht der *gewünschte Zustand ✅*. Kennzeichne sie im Code mit dem Kommentar ``// Guard ❌``.

Aufwand: ca. 2 Stunden. Eine Lösung findest du in [Loesung.cs](Loesung.cs) – schau sie dir nur an, wenn du gar nicht weiterkommst.

>🎬 **Animation:** Zu jedem Schritt gibt es eine Animation, die **ohne Code** zeigt, was passieren soll: [Animated-Slides-Lagerroboter.html](Animated-Slides-Lagerroboter.html) (im Browser öffnen).

## Lagerroboter R2-L4G
Im Lager der Firma *BoxBot* fährt ein Roboter Pakete von ihrem Regalplatz ``P`` zur Ablage ``Z``. Die Befehle für den Roboter werden händisch in ``befehle.txt`` getippt – mit zu vielen Leerzeichen, chaotischer Groß-/Kleinschreibung, Kommentaren und Tippfehlern.

Dein Programm soll
1. die Befehle einlesen und bereinigen,
2. jeden gültigen Befehl ausführen (drehen, fahren, Paket nehmen, Paket ablegen),
3. dabei prüfen, dass der Roboter nicht gegen eine Wand ``#`` fährt,
4. ein Protokoll ``protokoll.txt`` und ein Fehlerprotokoll ``fehler.txt`` schreiben.

Die ``Funktionen`` sind in ``Program.cs`` bereits *deklariert*. Ersetze *throw new NotImplementedException();* **Schritt für Schritt**. Zu jedem Schritt gibt es in ``Program.cs`` einen auskommentierten Testblock (``/* ---------- Test Schritt N ---------- ... */``). Entferne ``/*`` und ``*/``, starte das Programm und vergleiche mit dem **erwarteten Output**.

>Die Pfade sind relativ zur ``.exe`` in ``bin/Debug/net10.0``. Deshalb beginnen sie mit ``../../../``, damit die Files neben der ``Program.cs`` gefunden werden.

### Die Dateien

``befehle.txt`` (die Zeilennummern stehen nicht in der Datei, sie helfen dir beim Lesen der Fehlermeldungen)
```
 1  # Befehle fuer den Lagerroboter R2-L4G
 2  # Format: befehl [anzahl]
 3  # Befehle: vor, zurueck, links, rechts, nimm, ablegen
 4  # Start: (1|1), Blick nach Osten (O)
 5
 6    VOR 4
 7  nimm        # Paket bei (5|1)
 8  Rechts
 9  vor   2
10  ablegen
11  vor 3
12  LINKS
13  spring 2
14  vor 1
15  ablegen
16
17  vor x
18  vor
19  Links
20  VOR   3
21  rechts
22  vor 2
23  nimm
24  NIMM
25  zurueck 2
26  rechts
27  vor 5
28  ablegen
29
30  # Nachtschicht
31  ZURÜCK 1
32  ablegen
33  nimm
34  vor→2          (→ ist ein Tabulator)
35  vor -2
36  links 2
37  vor 1 2
```

>🔧 **Reparieren oder ❌ melden?** Nicht jeder Tippfehler macht einen Befehl wertlos. Die Regel lautet: **Ist eindeutig, was gemeint war, reparieren wir still.** Beispiele sind ``ZURÜCK`` statt ``zurueck`` oder ein Tabulator statt eines Leerzeichens. **Könnte es mehreres bedeuten, melden wir einen Fehler** – niemals raten! Bei ``vor 1 2`` weiß niemand, ob 1 oder 2 Felder gemeint waren. Ein falsch gesteuerter Roboter ist gefährlicher als einer, der stehen bleibt. Überlege dir für jede Zeile der Datei vorher selbst, in welche Gruppe sie gehört.

``lagerhalle.txt`` (12 Spalten × 8 Zeilen, ``#`` Wand, ``P`` Paket, ``Z`` Ablage, ``.`` frei). ``(0|0)`` ist oben links, ``x`` geht nach rechts, ``y`` nach unten.
```
############
#....P.....#
#..##......#
#..##...P..#
#..........#
#.###..##..#
#.....Z....#
############
```

Der Roboter startet auf ``(1|1)`` und schaut nach **Osten** (``O``). Die Richtungen sind ``N`` (oben, ``y - 1``), ``O`` (rechts, ``x + 1``), ``S`` (unten, ``y + 1``) und ``W`` (links, ``x - 1``).

---

### Schritt 1 - level: 🙂 - Datei einlesen
🎬 [Animation zu Schritt 1](Animated-Slides-Lagerroboter.html#schritt1)

Implementiere ``string[] LeseDatei(string pfad)``.
- **Guard ❌:** Existiert die Datei nicht (``File.Exists``), gib ein leeres Array ``new string[0]`` zurück.
- **✅:** Sonst gib alle Zeilen mit ``File.ReadAllLines`` zurück.

| Aufruf | Rückgabe |
|---|---|
| ``LeseDatei("../../../befehle.txt").Length`` | ``37`` |
| ``LeseDatei("../../../lagerhalle.txt")[1]`` | ``"#....P.....#"`` |
| ``LeseDatei("../../../gibtsnicht.txt").Length`` | ``0`` |

Erwarteter Output (Test Schritt 1):
```
--- Schritt 1 ---
37
#....P.....#
0
```

### Schritt 2 - level: 🙂 - Zeile bereinigen
🎬 [Animation zu Schritt 2](Animated-Slides-Lagerroboter.html#schritt2)

Implementiere ``bool TryBereinigeZeile(string zeile, out string befehl)``.
1. Suche mit ``IndexOf('#')`` einen Kommentar. Gibt es einen, schneide ihn mit ``Substring(0, ...)`` ab.
2. **Reparatur 🔧:** Ersetze jeden Tabulator ``'\t'`` durch ein Leerzeichen (``Replace``). Sonst würde ``Split(' ')`` ihn nicht als Trenner erkennen.
3. Zerlege den Rest mit ``Split(' ', StringSplitOptions.RemoveEmptyEntries)`` in Wörter – so verschwinden alle überflüssigen Leerzeichen.
4. **Guard ❌:** Bleibt kein Wort übrig (Leerzeile oder reine Kommentarzeile), gib ``false`` zurück, ``befehl`` ist ``""``.
5. **✅:** Füge die Wörter mit ``string.Join(" ", ...)`` wieder zusammen und schreibe alles klein (``ToLower``).
   **Reparatur 🔧:** Ersetze danach ``"ü"`` durch ``"ue"`` – aus ``ZURÜCK`` wird ``zurueck``. Denk nach: Warum erst **nach** ``ToLower``?

| Aufruf | Rückgabe | ``befehl`` |
|---|---|---|
| ``TryBereinigeZeile("  VOR 4", out b)`` | ``true`` | ``"vor 4"`` |
| ``TryBereinigeZeile("nimm        # Paket bei (5\|1)", out b)`` | ``true`` | ``"nimm"`` |
| ``TryBereinigeZeile("VOR   3  ", out b)`` | ``true`` | ``"vor 3"`` |
| ``TryBereinigeZeile("# Kommentar", out b)`` | ``false`` | ``""`` |
| ``TryBereinigeZeile("     ", out b)`` | ``false`` | ``""`` |
| ``TryBereinigeZeile("ZURÜCK 1", out b)`` | ``true`` | ``"zurueck 1"`` 🔧 |
| ``TryBereinigeZeile("vor\t2", out b)`` | ``true`` | ``"vor 2"`` 🔧 |

Erwarteter Output (Test Schritt 2):
```
--- Schritt 2 ---
True 'vor 4'
True 'nimm'
True 'vor 3'
False ''
False ''
True 'zurueck 1'
True 'vor 2'
```

### Schritt 3 - level: 🙂🤔 - Befehl zerlegen
🎬 [Animation zu Schritt 3](Animated-Slides-Lagerroboter.html#schritt3)

Implementiere ``bool TryParseBefehl(string befehl, out (string Name, int Anzahl) ergebnis, out string fehlergrund)``.
Der ``befehl`` ist bereits bereinigt (Schritt 2). Zerlege ihn mit ``Split(' ')``. Das erste Teil ist der **Name**.
- ``vor`` und ``zurueck`` brauchen **genau eine** Anzahl (ganze Zahl ``>= 1``).
- ``links``, ``rechts``, ``nimm`` und ``ablegen`` haben **keine** Anzahl. Die ``Anzahl`` ist dann ``1``.

Guards ❌ in dieser Reihenfolge (``ergebnis`` ist dann ``("", 0)``):

| Guard ❌ | ``fehlergrund`` |
|---|---|
| Name ist keiner der 6 Befehle | ``unbekannter Befehl 'spring'`` |
| ``links/rechts/nimm/ablegen`` mit Anzahl | ``'nimm' braucht keine Anzahl`` |
| ``vor/zurueck`` ohne Anzahl (weniger als 2 Teile) | ``fehlende Anzahl bei 'vor'`` |
| ``vor/zurueck`` mit mehr als 2 Teilen (``vor 1 2``) | ``zu viele Angaben bei 'vor'`` |
| Anzahl ist keine Zahl (``int.TryParse``) oder ``< 1`` | ``ungültige Anzahl 'x'`` |

>Denk nach: ``vor -2`` könnte „2 zurück“ heißen. Warum reparieren wir das trotzdem **nicht**?

| Aufruf | Rückgabe | ``ergebnis`` | ``fehlergrund`` |
|---|---|---|---|
| ``TryParseBefehl("vor 4", ...)`` | ``true`` | ``("vor", 4)`` | ``""`` |
| ``TryParseBefehl("links", ...)`` | ``true`` | ``("links", 1)`` | ``""`` |
| ``TryParseBefehl("spring 2", ...)`` | ``false`` | ``("", 0)`` | ``unbekannter Befehl 'spring'`` |
| ``TryParseBefehl("vor x", ...)`` | ``false`` | ``("", 0)`` | ``ungültige Anzahl 'x'`` |
| ``TryParseBefehl("vor", ...)`` | ``false`` | ``("", 0)`` | ``fehlende Anzahl bei 'vor'`` |
| ``TryParseBefehl("vor 0", ...)`` | ``false`` | ``("", 0)`` | ``ungültige Anzahl '0'`` |
| ``TryParseBefehl("nimm 2", ...)`` | ``false`` | ``("", 0)`` | ``'nimm' braucht keine Anzahl`` |
| ``TryParseBefehl("vor -2", ...)`` | ``false`` | ``("", 0)`` | ``ungültige Anzahl '-2'`` |
| ``TryParseBefehl("vor 1 2", ...)`` | ``false`` | ``("", 0)`` | ``zu viele Angaben bei 'vor'`` |

Erwarteter Output (Test Schritt 3):
```
--- Schritt 3 ---
True vor 4 []
True links 1 []
False [unbekannter Befehl 'spring']
False [ungültige Anzahl 'x']
False [fehlende Anzahl bei 'vor']
False [ungültige Anzahl '0']
False ['nimm' braucht keine Anzahl]
False [ungültige Anzahl '-2']
False [zu viele Angaben bei 'vor']
```

### Schritt 4 - level: 🤔 - Drehen und Bewegen
🎬 [Animation zu Schritt 4](Animated-Slides-Lagerroboter.html#schritt4)

1. ``char Drehe(char richtung, string seite)``
   - Die Konstante ``Richtungen = "NOSW"`` enthält die Richtungen **im Uhrzeigersinn**. Suche mit ``Richtungen.IndexOf(richtung)`` den Index der aktuellen Richtung.
   - ``"rechts"``: einen Index weiter, ``"links"``: einen Index zurück. Mit ``% 4`` kommst du von ``W`` wieder zu ``N``. *Tipp:* Statt ``- 1`` rechne ``+ 3``, dann wird der Index nie negativ.
   - Das Ergebnis ist ``Richtungen[neuerIndex]`` – ein ``char``.
2. ``(int X, int Y) NaechstesFeld((int X, int Y) pos, char richtung, int schritt = 1)``
   - Liefert das Nachbarfeld in Blickrichtung. ``schritt`` ist ``1`` für ``vor`` und ``-1`` für ``zurueck`` (der Roboter fährt rückwärts, dreht sich aber nicht um).
   - ``schritt`` ist ein **Default-Parameter**: Der Normalfall „vor“ braucht ihn nicht, nur für ``zurueck`` gibst du ``-1`` an.

   >**Default-Parameter:** Ein Parameter mit ``= wert`` in der Signatur darf beim Aufruf **weggelassen** werden – dann gilt der angegebene Standardwert. Default-Parameter stehen immer **am Ende** der Parameterliste. Wir verwenden sie statt fest eingebauter „magischer Zahlen“: Der Normalfall bleibt kurz, Sonderfälle sind trotzdem möglich.

| Aufruf | Rückgabe |
|---|---|
| ``Drehe('O', "rechts")`` | ``'S'`` |
| ``Drehe('O', "links")`` | ``'N'`` |
| ``Drehe('W', "rechts")`` | ``'N'`` |
| ``Drehe('N', "links")`` | ``'W'`` |
| ``NaechstesFeld((5, 1), 'O')`` | ``(6, 1)`` (``schritt`` = 1) |
| ``NaechstesFeld((5, 1), 'S')`` | ``(5, 2)`` |
| ``NaechstesFeld((8, 3), 'O', -1)`` | ``(7, 3)`` |
| ``NaechstesFeld((6, 6), 'N')`` | ``(6, 5)`` |

Erwarteter Output (Test Schritt 4):
```
--- Schritt 4 ---
S N N W
(6, 1)
(5, 2)
(7, 3)
(6, 5)
```

### Schritt 5 - level: 🙂 - Lagerhalle prüfen
🎬 [Animation zu Schritt 5](Animated-Slides-Lagerroboter.html#schritt5)

Die Lagerhalle lesen wir mit ``LeseDatei`` in ein ``string[] lager`` ein. ``lager[y]`` ist eine Zeile (ein ``string``), ``lager[y][x]`` ist ein einzelnes Zeichen (ein ``char``).

Implementiere ``bool IstBegehbar(string[] lager, (int X, int Y) p)``.
- **Guard ❌:** ``p`` liegt außerhalb (``lager.Length`` = Anzahl Zeilen, ``lager[p.Y].Length`` = Anzahl Spalten) → ``false``. Achtung: zuerst ``Y`` prüfen, sonst gibt es bei ``lager[p.Y]`` einen Absturz!
- **✅:** ``true``, wenn das Zeichen **keine** Wand ``'#'`` ist.

| Aufruf | Rückgabe | Warum? |
|---|---|---|
| ``IstBegehbar(lager, (1, 1))`` | ``true`` | ``'.'`` |
| ``IstBegehbar(lager, (3, 2))`` | ``false`` | Wand im Regalblock |
| ``IstBegehbar(lager, (6, 7))`` | ``false`` | Außenwand unten |
| ``IstBegehbar(lager, (20, 3))`` | ``false`` | außerhalb rechts |
| ``IstBegehbar(lager, (-1, 0))`` | ``false`` | außerhalb links |

Erwarteter Output (Test Schritt 5):
```
--- Schritt 5 ---
True
False
False
False
False
```

### Schritt 6 - level: 🤔😵‍💫 - Pakete und Karte
🎬 [Animation zu Schritt 6](Animated-Slides-Lagerroboter.html#schritt6)

1. ``void SetzeZeichen(string[] lager, (int X, int Y) p, char zeichen)``
   - Nimmt der Roboter ein Paket, wird aus dem ``'P'`` ein ``'.'``. Aber: Strings sind unveränderlich – ``lager[y][x] = '.';`` ergibt einen **Compilerfehler**!
   - Baue deshalb die Zeile **neu** zusammen: alles **vor** ``x`` (``Substring(0, p.X)``) + ``zeichen`` + alles **nach** ``x`` (``Substring(p.X + 1)``) und speichere sie in ``lager[p.Y]``.
   - Die ``Funktion`` hat keinen Rückgabewert. Warum sieht das Hauptprogramm die Änderung trotzdem? (Tipp: ``Referenztyp``)
2. ``char RoboterSymbol(char richtung)``: ``'N'`` → ``'^'``, ``'O'`` → ``'>'``, ``'S'`` → ``'v'``, ``'W'`` → ``'<'``.
3. ``string[] ErzeugeKarte(string[] lager, (int X, int Y) pos, char richtung)``
   - Erzeugt ein **neues** Array mit gleich vielen Zeilen. Durchlaufe jede Zeile Zeichen für Zeichen: An ``pos`` kommt ``RoboterSymbol(richtung)``, sonst das Zeichen aus ``lager``. Hänge die Zeichen mit ``ToString()`` an.
   - ``lager`` selbst wird **nicht** verändert.

| Aufruf | Ergebnis |
|---|---|
| ``SetzeZeichen(lager, (5, 1), '.')`` → ``lager[1]`` | ``"#..........#"`` |
| ``RoboterSymbol('S')`` | ``'v'`` |
| ``ErzeugeKarte(lager, (1, 1), 'O')[1]`` | ``"#>.........#"`` |

Erwarteter Output (Test Schritt 6):
```
--- Schritt 6 ---
#..........#
v
############
#>.........#
#..##......#
#..##...P..#
#..........#
#.###..##..#
#.....Z....#
############
```

### Schritt 7 - level: 🙂 - Protokollzeile formatieren
🎬 [Animation zu Schritt 7](Animated-Slides-Lagerroboter.html#schritt7)

1. ``string ErzeugeProtokollZeile(int nr, string befehl, (int X, int Y) pos, char richtung, int befehlBreite = 10)``
   - Format: ``Zeile {nr} | {befehl} | {position} {richtung}``
   - ``nr`` immer 2-stellig: ``nr.ToString().PadLeft(2, '0')``
   - ``befehl`` mit ``PadRight(befehlBreite)`` auffüllen. ``befehlBreite`` ist ein **Default-Parameter** (Standard ``10``).
   - ``position`` ist ``"(x|y)"`` und wird mit ``PadLeft(6)`` rechtsbündig gemacht.
2. ``string[] Kuerze(string[] array, int anzahl)`` – liefert ein neues Array mit nur den ersten ``anzahl`` Elementen (wie in der Drohnenlieferung).

| Aufruf | Rückgabe |
|---|---|
| ``ErzeugeProtokollZeile(6, "vor 4", (5, 1), 'O')`` | ``"Zeile 06 \| vor 4      \|  (5\|1) O"`` |
| ``ErzeugeProtokollZeile(25, "zurueck 2", (6, 3), 'O')`` | ``"Zeile 25 \| zurueck 2  \|  (6\|3) O"`` |
| ``ErzeugeProtokollZeile(6, "vor 4", (5, 1), 'O', 6)`` | ``"Zeile 06 \| vor 4  \|  (5\|1) O"`` (nur 6 breit) |
| ``Kuerze(["a", "b", "c", "d"], 2)`` | ``["a", "b"]`` |

Erwarteter Output (Test Schritt 7):
```
--- Schritt 7 ---
Zeile 06 | vor 4      |  (5|1) O
Zeile 25 | zurueck 2  |  (6|3) O
Zeile 06 | vor 4  |  (5|1) O
a,b
```

### Schritt 8 - level: 🤔😵‍💫 - Alles zusammenbauen
🎬 [Animation zu Schritt 8](Animated-Slides-Lagerroboter.html#schritt8)

Schreibe das Hauptprogramm:
1. Lies ``befehle.txt`` und ``lagerhalle.txt`` mit ``LeseDatei`` ein. **Guard ❌:** Ist eines der Arrays leer, gib ``❌ befehle.txt oder lagerhalle.txt fehlt!`` aus und beende mit ``return``.
2. Merke dir ``position`` (Start ``(1|1)``), ``richtung`` (``'O'``), ob der Roboter ein Paket trägt, wie viele Pakete zugestellt wurden und wie viele Felder er gefahren ist.
3. Gehe alle Zeilen mit einer ``foreach``-Schleife durch (``nr`` = Zeilennummer ab 1, selbst mitgezählt):
   >``foreach`` statt ``for``: Wir brauchen keinen Index, um die Zeilen zu lesen. Die Zeilennummer für die Meldung ist **kein** Grund für eine ``for``-Schleife – zähle sie selbst mit (``int nr = 0;`` vor der Schleife, ``nr++;`` als **erste** Anweisung in der Schleife, also noch vor jedem ``continue``).
   - ``TryBereinigeZeile`` liefert ``false`` → mit ``continue`` überspringen.
   - ``TryParseBefehl`` liefert ``false`` → Fehler ``"Zeile {nr}: {fehlergrund}"`` merken, ``continue``.
   - ``links`` / ``rechts`` → ``Drehe``.
   - ``vor`` / ``zurueck`` → ``Anzahl`` mal ``NaechstesFeld`` berechnen. Ist das Feld nicht ``IstBegehbar``, bleibt der Roboter stehen: Fehler ``"Zeile {nr}: Wand bei (x|y) – nur {gefahren} von {Anzahl} Feldern gefahren"`` merken und mit ``break`` die Schleife verlassen. Der Befehl kommt trotzdem ins Protokoll.
   - ``nimm`` → Guards ❌: trägt schon ein Paket (``"trägt bereits ein Paket"``), kein ``'P'`` unter dem Roboter (``"kein Paket bei (x|y)"``). ✅: ``SetzeZeichen(lager, position, '.')``, Paket tragen.
   - ``ablegen`` → Guards ❌: trägt kein Paket (``"kein Paket geladen"``), kein ``'Z'`` unter dem Roboter (``"kein Ablageplatz bei (x|y)"``). ✅: Paket abgeben, zugestellt + 1.
   - Bei einem ❌ in ``nimm`` / ``ablegen`` kommt der Befehl **nicht** ins Protokoll (``continue``). Sonst ``ErzeugeProtokollZeile`` merken.
4. Gib das Protokoll, die Karte am Ende (``ErzeugeKarte``) und die Zusammenfassung aus.
5. Schreibe ``protokoll.txt`` und ``fehler.txt`` mit ``File.WriteAllLines`` (vorher ``Kuerze``!).

Erwarteter Output (Konsole):
```
🤖 Protokoll:
Zeile 06 | vor 4      |  (5|1) O
Zeile 07 | nimm       |  (5|1) O
Zeile 08 | rechts     |  (5|1) S
Zeile 09 | vor 2      |  (5|3) S
Zeile 11 | vor 3      |  (5|6) S
Zeile 12 | links      |  (5|6) O
Zeile 14 | vor 1      |  (6|6) O
Zeile 15 | ablegen    |  (6|6) O
Zeile 19 | links      |  (6|6) N
Zeile 20 | vor 3      |  (6|3) N
Zeile 21 | rechts     |  (6|3) O
Zeile 22 | vor 2      |  (8|3) O
Zeile 23 | nimm       |  (8|3) O
Zeile 25 | zurueck 2  |  (6|3) O
Zeile 26 | rechts     |  (6|3) S
Zeile 27 | vor 5      |  (6|6) S
Zeile 28 | ablegen    |  (6|6) S
Zeile 31 | zurueck 1  |  (6|5) S
Zeile 34 | vor 2      |  (6|6) S

🗺️ Lagerhalle am Ende:
############
#..........#
#..##......#
#..##......#
#..........#
#.###..##..#
#.....v....#
############

📦 Zugestellte Pakete: 2
🛞 Gefahrene Felder: 22
⚠️ Fehler: 12 (siehe fehler.txt)
```

Erwartetes ``protokoll.txt``: dieselben 19 Zeilen wie unter *🤖 Protokoll*.

Erwartetes ``fehler.txt``:
```
Zeile 10: kein Ablageplatz bei (5|3)
Zeile 13: unbekannter Befehl 'spring'
Zeile 17: ungültige Anzahl 'x'
Zeile 18: fehlende Anzahl bei 'vor'
Zeile 24: trägt bereits ein Paket
Zeile 27: Wand bei (6|7) – nur 3 von 5 Feldern gefahren
Zeile 32: kein Paket geladen
Zeile 33: kein Paket bei (6|5)
Zeile 34: Wand bei (6|7) – nur 1 von 2 Feldern gefahren
Zeile 35: ungültige Anzahl '-2'
Zeile 36: 'links' braucht keine Anzahl
Zeile 37: zu viele Angaben bei 'vor'
```

Was passiert mit den neuen Zeilen 30–37?

| Zeile | Inhalt | Ergebnis |
|---|---|---|
| 30 | Kommentar | übersprungen |
| 31 | ``ZURÜCK 1`` | 🔧 → ``zurueck 1``, fährt rückwärts auf (6\|5) |
| 32 | ``ablegen`` ohne Paket | ❌ kein Paket geladen |
| 33 | ``nimm`` auf leerem Feld | ❌ kein Paket bei (6\|5) |
| 34 | ``vor`` + Tabulator + ``2`` | 🔧 → ``vor 2``; nach 1 Feld kommt die Wand ❌ |
| 35 | ``vor -2`` | ❌ ungültige Anzahl |
| 36 | ``links 2`` | ❌ braucht keine Anzahl |
| 37 | ``vor 1 2`` | ❌ zu viele Angaben |

### Bonus - level: 😵‍💫
* Zeichne die Karte nach **jedem** Befehl in ein File ``fahrt.txt`` (mit einer Leerzeile dazwischen).
* Markiere jedes Feld, über das der Roboter gefahren ist, mit ``'o'`` (Tipp: ``SetzeZeichen`` auf einer Kopie des Lagers).
* Neuer Befehl ``fahrzu x|y``: Der Roboter dreht sich selbst und fährt erst waagrecht, dann senkrecht zum Ziel.

---

### String-Methoden
In den Folien haben wir ``[]``, ``Substring``, ``Length``, ``Split``, ``char.Is...`` und ``ToString()`` kennengelernt. Lies die *Signatur* so: **Rückgabetyp** ``Name(Eingangsparameter)``. Alle Methoden *verändern den String nicht* (Strings sind unveränderlich), sondern liefern einen **neuen** String zurück.

| Signatur | Was macht sie? | Beispiel |
|---|---|---|
| ``string Trim()`` | entfernt Leerzeichen/Tabs vorne und hinten | ``"  vor 4 ".Trim()`` → ``"vor 4"`` |
| ``string ToUpper()`` / ``string ToLower()`` | alles groß / klein | ``"VOR".ToLower()`` → ``"vor"`` |
| ``bool StartsWith(string wert)`` | beginnt der String mit ``wert``? | ``"# Info".StartsWith("#")`` → ``true`` |
| ``int IndexOf(char wert)`` | Index des **ersten** Vorkommens, sonst ``-1`` | ``"nimm # x".IndexOf('#')`` → ``5`` |
| ``string Substring(int start)`` | alles ab ``start`` bis zum Ende | ``"#..P.".Substring(4)`` → ``"."`` |
| ``string Substring(int start, int laenge)`` | ``laenge`` Zeichen ab ``start`` | ``"nimm # x".Substring(0, 5)`` → ``"nimm "`` |
| ``char this[int index]`` | einzelnes Zeichen lesen (nicht schreiben!) | ``"NOSW"[2]`` → ``'S'`` |
| ``string PadLeft(int breite, char fuell)`` | füllt **links** auf, bis ``breite`` erreicht ist | ``"6".PadLeft(2, '0')`` → ``"06"`` |
| ``string PadLeft(int breite)`` | füllt **links** mit Leerzeichen auf (rechtsbündig) | ``"(5\|1)".PadLeft(6)`` → ``" (5\|1)"`` |
| ``string PadRight(int breite)`` | füllt **rechts** mit Leerzeichen auf (Tabellenspalten) | ``"vor 4".PadRight(7)`` → ``"vor 4  "`` |
| ``string[] Split(char trenner)`` | zerlegt an jedem ``trenner`` | ``"vor 4".Split(' ')`` → ``["vor","4"]`` |
| ``string[] Split(char trenner, StringSplitOptions optionen)`` | mit ``StringSplitOptions.RemoveEmptyEntries`` fallen leere Teile weg | ``"vor   2".Split(' ', StringSplitOptions.RemoveEmptyEntries)`` → ``["vor","2"]`` |
| ``static bool string.IsNullOrWhiteSpace(string wert)`` | ist der String ``null``, leer oder nur Leerzeichen? | ``string.IsNullOrWhiteSpace("   ")`` → ``true`` |
| ``static string string.Join(string trenner, string[] werte)`` | Gegenteil von ``Split``: fügt ein Array zusammen | ``string.Join(" ", ["vor","2"])`` → ``"vor 2"`` |
| ``string Replace(char alt, char neu)`` | ersetzt **jedes** Zeichen ``alt`` durch ``neu`` | ``"vor\t2".Replace('\t', ' ')`` → ``"vor 2"`` |
| ``string Replace(string alt, string neu)`` | wie oben, für Teilstrings | ``"zurück".Replace("ü", "ue")`` → ``"zurueck"`` |
| ``string ToString()`` | macht aus einem ``char`` / ``int`` einen ``string`` | ``'>'.ToString()`` → ``">"`` |
