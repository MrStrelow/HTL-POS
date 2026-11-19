Welche ``Konzepte`` der Programmiersprache üben wir hier?
* Eigene ``Klassen`` schreiben: jede ``Klasse`` in einem eigenen File
* ``Properties`` mit ``{ get; set; }`` für den ``Zustand``
* ``Konstruktoren``, die den Startzustand festlegen
* ``Methoden`` für das ``Verhalten`` – auch mit ``Default-Parametern`` und ``Named Parametern``
* ``Objekte`` mit ``new`` erzeugen und mit dem **Punkt** ihre ``Mitglieder`` verwenden
* Die **hat-Beziehung**: ein ``Objekt`` kennt ein anderes ``Objekt`` über eine ``Property``
* Wiederholung aus L03: Files lesen und schreiben, ``Guard-Clauses``, ``out``-Parameter im Stil von ``int.TryParse``

Welche ``Denkweisen`` üben wir hier?
* Welche Daten und welches Verhalten gehören **zusammen** in eine ``Klasse``?
* Wer ist **zuständig**? Ein ``Auftrag`` kennt seinen Preis, ein ``Stadtplan`` weiß, was in ihm liegt, eine ``Drohne`` entscheidet, ob sie liefern kann.
* Wie wird aus vielen kleinen ``Funktionen`` ein Programm aus ``Objekten``, die miteinander reden?

Aufwand: ca. 2 Stunden. Eine Lösung findest du im Ordner [Loesung](Loesung/) – schau sie dir nur an, wenn du gar nicht weiterkommst. Grundlage ist das Skriptum [Klassen und Objekte](../Skripten/L04.1_KlassenUndObjekte.md).

>🎬 **Animation:** Zu jedem Schritt gibt es eine Animation, die die Musterlösung an den echten Daten durchspielt – mit Objekten, Properties und Ablauf: [Animated-Slides-Drohnenlieferung.html](Animated-Slides-Drohnenlieferung.html) (im Browser öffnen).

## Drohnen-Lieferdienst SkyParcel
Die Firma *SkyParcel* liefert Pakete per Drohne. Die Aufträge in ``auftraege.txt`` wurden händisch getippt: chaotische Groß-/Kleinschreibung, zu viele Leerzeichen, Kommentare, Leerzeilen und fehlerhafte Zeilen.

Diesmal bauen wir das Programm aus **Objekten**. Jedes ``Objekt`` erledigt den Teil, für den es zuständig ist:

| ``Klasse`` | hat (``Zustand``) | kann (``Verhalten``) |
|---|---|---|
| ``Auftrag`` | Nummer, Start, Ziel, Gewicht, Kunde | seine Strecke und seinen Preis berechnen, seine Berichtzeile bauen |
| ``Stadtplan`` | die Zeilen der Karte | sagen, ob ein Punkt innerhalb liegt, eine Route einzeichnen |
| ``Drohne`` | Name, **einen Stadtplan**, Höchstgewicht, Anzahl Lieferungen, geflogene km | prüfen, ob sie einen Auftrag liefern kann, und ihn liefern |

Die Hilfsfunktionen zum Bereinigen der Texte kennst du aus L03. Sie sind in ``Program.cs`` **fertig**: ``TryNormalisiereNummer``, ``TryParseKoordinate``, ``TryParseGewicht``, ``FormatiereKunde`` und ``Kuerze``.

Die Files ``Auftrag.cs``, ``Stadtplan.cs`` und ``Drohne.cs`` enthalten nur eine leere ``Klasse``. Fülle sie **Schritt für Schritt**. Zu jedem Schritt gibt es in ``Program.cs`` einen auskommentierten Testblock (``/* ---------- Test Schritt N ---------- ... */``). Entferne ``/*`` und ``*/``, starte das Programm und vergleiche mit dem **erwarteten Output**. Die ``[ ]`` in der Ausgabe zeigen dir, wo ein String anfängt und aufhört.

>Kommazahlen werden mit der Spracheinstellung des Computers ausgegeben. Der erwartete Output gilt für Deutsch (``3,2``). Bei Englisch steht ``3.2`` da – das ist auch richtig.

>Die Pfade sind relativ zur ``.exe`` in ``bin/Debug/net10.0``. Deshalb beginnen sie mit ``../../../``.

### Klassendiagramm
```
┌──────────────────────────────────────────────┐
│ Auftrag                                      │
├──────────────────────────────────────────────┤
│ + Nummer : string                            │
│ + Start : (int X, int Y)                     │
│ + Ziel : (int X, int Y)                      │
│ + GewichtKg : double                         │
│ + Kunde : string                             │
├──────────────────────────────────────────────┤
│ + Auftrag(nummer, start, ziel, gewichtKg,    │
│           kunde)                             │
│ + BerechneStreckeKm(kmProFeld = 0.5) : double│
│ + BerechnePreis(grundgebuehr = 3.50,         │
│     preisProKm = 1.20, freigewichtKg = 2.0,  │
│     zuschlagProKg = 0.80) : double           │
│ + FormatiereBerichtZeile(                    │
│     maxKundenLaenge = 18) : string           │
└──────────────────────────────────────────────┘
                      ▲ verwendet
                      │
┌─────────────────────┴────────────────────────┐        ┌──────────────────────────────────────────┐
│ Drohne                                       │  hat   │ Stadtplan                                │
├──────────────────────────────────────────────┤ ─────▶ ├──────────────────────────────────────────┤
│ + Name : string                              │  1     │ + Zeilen : string[]                      │
│ + Plan : Stadtplan                           │        ├──────────────────────────────────────────┤
│ + MaxGewichtKg : double                      │        │ + Stadtplan(zeilen)                      │
│ + AnzahlLieferungen : int                    │        │ + IstInnerhalb(p) : bool                 │
│ + GeflogeneKm : double                       │        │ + IstAufRoute(start, ziel, x, y) : bool  │
├──────────────────────────────────────────────┤        │ + ZeichneRoute(auftrag : Auftrag) : bool │
│ + Drohne(name, plan, maxGewichtKg = 5.0)     │        └──────────────────────────────────────────┘
│ + TryLiefern(auftrag, out fehlergrund) : bool│
│ + Statistik() : string                       │
└──────────────────────────────────────────────┘
```

### Die Dateien

``auftraege.txt`` (die Zeilennummern stehen nicht in der Datei)
```
 1  # Drohnen-Lieferauftraege der Firma SkyParcel
 2  # Format: nummer;start;ziel;gewicht;kunde
 3  # Koordinaten x|y: 0|0 ist oben links. 1 Feld = 0,5 km
 4
 5    LF-7 ; 1|1 ; 6|3 ; 1,5kg ; mÜLLER gmbh
 6  LF-0012;10|3;1|0;3,2KG;  bäckerei huber
 7  lf-13 ; 3|7 ; 4|0 ; 2kg ; htl werkstätte
 8
 9  LF-x15 ; 1|1 ; 2|2 ; 1kg ; tippfehler ag
10  LF-16 ; 1|1 ; 15|3 ; 1kg ; weit weg kg
11  LF-17 ; 3|3 ; 8|1 ; 7,5kg ; schwer und co
12  LF-18 ; 2|5 ; 1kg ; vergessen ohg
13  LF-19 ; 0|6 ; 11|6 ; 1kg ; quer durch gmbh
14  LF-21 ; (5|3) ; (11|1) ; 800g ; café   CENTRAL ;
15  LF-22 ; 7|2 ; 7|2 ; 1kg ; nirgendwo gmbh
16  lf-12 ; 1|2 ; 3|2 ; 1kg ; doppelt kg
```

``stadtplan.txt`` (12 Spalten × 8 Zeilen, ``⛔`` ist eine Sperrzone, z.B. ein Spital mit Hubschrauberlandeplatz)
```
⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⛔⛔⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⛔⛔⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⛔⛔⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⛔⛔⬜⬜⬜⬜
```
>``⬜ ⛔ ✅ ❌ ⭐ ⚡`` sind jeweils **ein** ``char``. Darum ist ``Zeilen[y][x]`` genau ein Feld.

---

### Schritt 1 - level: 🙂 - Klasse ``Auftrag``: Zustand und Konstruktor
🎬 [Animation zu Schritt 1](Animated-Slides-Drohnenlieferung.html#schritt1)

Schreibe in ``Auftrag.cs``:
1. Fünf ``Properties`` mit ``{ get; set; }``: ``Nummer``, ``Start``, ``Ziel``, ``GewichtKg``, ``Kunde`` (Typen siehe Klassendiagramm).
2. Einen ``Konstruktor``, der **alle** fünf Werte bekommt und den ``Properties`` zuweist.

**Denk nach:** Nach ``a2.GewichtKg = 2.5;`` hat ``a1`` immer noch ``1,5`` kg. Warum?

Erwarteter Output (Test Schritt 1):
```
--- Schritt 1 ---
LF-0007 Müller Gmbh (1, 1) -> (6, 3) 1,5 kg
LF-0013 Htl Werkstätte (3, 7) -> (4, 0) 2 kg
1,5 2,5
```

### Schritt 2 - level: 🤔 - Klasse ``Auftrag``: Verhalten
🎬 [Animation zu Schritt 2](Animated-Slides-Drohnenlieferung.html#schritt2)

Ein Auftrag kennt seinen Start und sein Ziel. Darum braucht er keine Parameter dafür – er verwendet seine **eigenen** ``Properties``.

1. ``double BerechneStreckeKm(double kmProFeld = 0.5)`` – Euklidische Distanz von ``Start`` bis ``Ziel`` mal ``kmProFeld``.
2. ``double BerechnePreis(double grundgebuehr = 3.50, double preisProKm = 1.20, double freigewichtKg = 2.0, double zuschlagProKg = 0.80)``
   - ``grundgebuehr`` + ``preisProKm`` pro km. Jedes kg über ``freigewichtKg`` kostet ``zuschlagProKg`` extra. Mit ``Math.Round(preis, 2)`` runden.
   - Die Strecke holst du mit der **eigenen** ``Methode`` ``BerechneStreckeKm()``.
   - Ein Sondertarif ändert per **Named Parameter** genau einen Wert: ``b1.BerechnePreis(preisProKm: 1.50)``.
3. ``string FormatiereBerichtZeile(int maxKundenLaenge = 18)`` baut eine Tabellenzeile mit ``PadRight`` / ``PadLeft``:
   - ``Nummer.PadRight(9)`` + Kunde ``.PadRight(maxKundenLaenge + 2)`` + ``$"{km:F2} km".PadLeft(10)`` + ``$"{preis:F2} €".PadLeft(10)``
   - Zu lange Kundennamen werden mit ``Substring(0, maxKundenLaenge - 1) + "…"`` gekürzt. **Achtung:** Ändere dabei nicht die ``Property`` ``Kunde``!

| Aufruf | Rückgabe | Rechnung |
|---|---|---|
| ``b1.BerechneStreckeKm()`` | ``2.69`` | √(5² + 2²) · 0,5 |
| ``b2.BerechneStreckeKm()`` | ``2.50`` | √(4² + 3²) · 0,5 |
| ``b1.BerechneStreckeKm(kmProFeld: 1.0)`` | ``5.39`` | √(5² + 2²) · **1,0** |
| ``b1.BerechnePreis()`` | ``6.73`` | 3,50 + 2,69 · 1,20 |
| ``b2.BerechnePreis()`` | ``8.10`` | 3,50 + 2,50 · 1,20 + 2 kg · 0,80 |
| ``b1.BerechnePreis(preisProKm: 1.50)`` | ``7.54`` | 3,50 + 2,69 · **1,50** |
| ``b2.BerechnePreis(freigewichtKg: 5)`` | ``6.50`` | unter **5 kg** kein Zuschlag |

Erwarteter Output (Test Schritt 2):
```
--- Schritt 2 ---
2,69
2,50
5,39
6,73
8,10
7,54
6,50
[LF-0007  Müller Gmbh            2,69 km    6,73 €]
[LF-0099  Sehr Lange Kunden…     2,50 km    8,10 €]
```

### Schritt 3 - level: 🙂 - Objekte aus Text erzeugen
🎬 [Animation zu Schritt 3](Animated-Slides-Drohnenlieferung.html#schritt3)

``TryParseAuftrag`` in ``Program.cs`` ist fast fertig: Die Zeile wird zerlegt und jedes Feld geprüft. Es fehlt nur das Ende.

- Erzeuge mit ``new`` ein ``Auftrag``-``Objekt`` aus ``nummer``, ``start``, ``ziel``, ``gewicht`` und dem formatierten Kunden (``FormatiereKunde(teile[4])``). Weise es dem ``out``-Parameter ``auftrag`` zu und liefere ``true``.
- Bei einem Fehler bleibt ``auftrag`` auf ``null`` – es wurde **kein** ``Objekt`` erzeugt.

Erwarteter Output (Test Schritt 3):
```
--- Schritt 3 ---
True LF-0007 Müller Gmbh (1, 1) (6, 3) 1,5 []
False [4 statt 5 Felder]
False [ungültige Auftragsnummer 'LF-x15']
True LF-0021 Café Central (5, 3) (11, 1) 0,8 []
True
```

### Schritt 4 - level: 😵‍💫 - Klasse ``Stadtplan``
🎬 [Animation zu Schritt 4](Animated-Slides-Drohnenlieferung.html#schritt4)

Schreibe in ``Stadtplan.cs``:
1. ``Property`` ``string[] Zeilen`` und einen ``Konstruktor``, der die Zeilen bekommt.
2. ``bool IstInnerhalb((int X, int Y) p)`` – liegt ein Punkt im Plan? (``Zeilen.Length`` = Zeilen, ``Zeilen[y].Length`` = Spalten)
3. ``bool IstAufRoute((int X, int Y) start, (int X, int Y) ziel, int x, int y)`` – liegt das Feld ``(x|y)`` auf der Geraden zwischen Start und Ziel? Wie im [Skriptum L03](../../L03Files-StringMethoden/Skripten/L03.3_linieZeichnen.html), Tab *Erweiterungen*:
   - **flach** (``|dx| >= |dy|``): für jede Spalte ``x`` liefert ``f(x) = start.Y + Round(k · (x − start.X))`` die Zeile, ``k = dy / dx``.
   - **steil**: für jede Zeile ``y`` liefert ``g(y) = start.X + Round(m · (y − start.Y))`` die Spalte, ``m = dx / dy``.
   - Mit ``Math.Min`` / ``Math.Max`` prüfst du, ob das Feld zwischen Start und Ziel liegt – egal in welche Richtung die Route geht.
4. ``bool ZeichneRoute(Auftrag auftrag)`` – Zeile für Zeile, Feld für Feld: ``'✅'`` Start, ``'❌'`` Ziel, ``'⭐'`` Route, ``'⚡'`` Route trifft ``'⛔'``, sonst das Feld aus dem Plan. Start und Ziel holst du mit dem **Punkt** aus dem ``Auftrag``: ``auftrag.Start``. Liefere ``false``, sobald ein ``'⚡'`` gezeichnet wurde.

**Frage:** ``ZeichneRoute`` verändert ``Zeilen`` nicht. Warum ist das wichtig, wenn **dasselbe** ``Stadtplan``-``Objekt`` für viele Aufträge verwendet wird?

Erwarteter Output (Test Schritt 4): steil von unten nach oben, dann quer durch die Sperrzone
```
--- Schritt 4 ---
8 Zeilen x 12 Spalten
True False False
True False
True True
⬜⬜⬜⬜❌⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⭐⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⭐⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⭐⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⭐⬜⬜⛔⛔⬜⬜⬜⬜
⬜⬜⬜⭐⬜⬜⛔⛔⬜⬜⬜⬜
⬜⬜⬜⭐⬜⬜⛔⛔⬜⬜⬜⬜
⬜⬜⬜✅⬜⬜⛔⛔⬜⬜⬜⬜
True
⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⛔⛔⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⛔⛔⬜⬜⬜⬜
✅⭐⭐⭐⭐⭐⚡⚡⭐⭐⭐❌
⬜⬜⬜⬜⬜⬜⛔⛔⬜⬜⬜⬜
False
```

### Schritt 5 - level: 🤔 - Klasse ``Drohne`` mit hat-Beziehung
🎬 [Animation zu Schritt 5](Animated-Slides-Drohnenlieferung.html#schritt5)

Eine ``Drohne`` **hat** einen ``Stadtplan``. Sie bekommt ihn über den ``Konstruktor`` und fragt ihn später über die ``Property`` ``Plan``.

1. ``Properties``: ``Name``, ``Plan`` (Typ ``Stadtplan``), ``MaxGewichtKg``, ``AnzahlLieferungen``, ``GeflogeneKm``.
2. ``Konstruktor`` ``Drohne(string name, Stadtplan plan, double maxGewichtKg = 5.0)`` – am Anfang hat die Drohne 0 Lieferungen und 0 km.
3. ``bool TryLiefern(Auftrag auftrag, out string fehlergrund)`` mit diesen ``Guard-Clauses`` der Reihe nach:
   - Start oder Ziel nicht im Plan → ``"{Nummer} – außerhalb des Stadtplans"`` (frage ``Plan.IstInnerhalb(...)``)
   - Start und Ziel gleich → ``"{Nummer} – Start und Ziel sind gleich"`` (Tupel kann man mit ``==`` vergleichen)
   - schwerer als **ihr** ``MaxGewichtKg`` → ``"{Nummer} – zu schwer (7,50 kg)"``
   - Ausgabe ``"\n📦 {Name} liefert {Nummer} für {Kunde}"``, dann ``Plan.ZeichneRoute(auftrag)``. Bei ``false``: ``"⛔ Route führt durch eine Sperrzone!"`` ausgeben, Grund ``"{Nummer} – Route durch Sperrzone"``.
   - sonst ✅: ``AnzahlLieferungen`` und ``GeflogeneKm`` erhöhen, ``"✅ {km:F2} km, {preis:F2} €"`` ausgeben, ``true`` liefern.
4. ``string Statistik()`` → ``"Sky-1: 4 Lieferungen, 14,13 km"``

**Denk nach:**
* ``sky1`` und ``sky2`` bekommen den Auftrag ``schwer`` – warum liefert nur ``sky2``?
* ``sky1.Plan == sky2.Plan`` ist ``True``. Wie viele ``Stadtplan``-``Objekte`` gibt es? Zeichne ein ``Objektdiagramm``.

Erwarteter Output (Test Schritt 5):
```
--- Schritt 5 ---
False [LF-0017 – zu schwer (7,50 kg)]

📦 Sky-2 liefert LF-0017 für Schwer Und Co
⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬜⭐❌⬜⬜⬜
⬜⬜⬜⬜⬜⭐⭐⬜⬜⬜⬜⬜
⬜⬜⬜✅⭐⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⛔⛔⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⛔⛔⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⛔⛔⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⛔⛔⬜⬜⬜⬜
✅ 2,69 km, 11,13 €
True []
Sky-1: 0 Lieferungen, 0,00 km
Sky-2: 1 Lieferungen, 2,69 km
True
```

### Schritt 6 - level: 🤔 - Alles zusammenbauen, Bericht schreiben
🎬 [Animation zu Schritt 6](Animated-Slides-Drohnenlieferung.html#schritt6)

1. Prüfe mit ``File.Exists``, ob beide Files existieren (*early exit*).
2. Erzeuge **ein** ``Stadtplan``-``Objekt`` aus ``stadtplan.txt`` und **eine** ``Drohne`` ``"Sky-1"`` mit diesem Plan.
3. Gehe alle Zeilen von ``auftraege.txt`` mit ``foreach`` durch. Zähle die Zeilennummer selbst mit (``zeilenNummer++;`` als **erste** Anweisung, noch vor jedem ``continue``). Überspringe Leerzeilen und Kommentare.
4. Für jede Zeile diese ``Guard-Clauses`` – jeder Fehler wird als ``"Zeile {zeilenNummer}: {grund}"`` gemerkt und mit ``continue`` übersprungen:
   - nicht zerlegbar → ``fehlergrund`` aus ``TryParseAuftrag``
   - Auftragsnummer kam schon vor → ``"{Nummer} – doppelte Auftragsnummer"``. Merke jede gültige Nummer in ``string[] bekannteNummern`` und prüfe vorher mit ``foreach``.
   - ``drohne.TryLiefern(...)`` liefert ``false`` → ``fehlergrund`` der Drohne
   - sonst ✅: ``auftrag.FormatiereBerichtZeile()`` für den Bericht merken, ``auftrag.BerechnePreis()`` zum Umsatz addieren.
5. Die Arrays legst du mit ``zeilen.Length`` an und zählst mit. ``Kuerze`` schneidet die leeren Plätze ab. Schreibe ``bericht.txt`` und ``fehler.txt`` mit ``File.WriteAllLines``. Gib am Ende ``drohne.Statistik()`` aus.

Erwartete Konsolenausgabe (gekürzt, ``...`` = weitere Karten):
```
📦 Sky-1 liefert LF-0007 für Müller Gmbh
⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜✅⭐⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⭐⭐⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⭐❌⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⛔⛔⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⛔⛔⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⛔⛔⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⛔⛔⬜⬜⬜⬜
✅ 2,69 km, 6,73 €
...
📦 Sky-1 liefert LF-0019 für Quer Durch Gmbh
...
✅⭐⭐⭐⭐⭐⚡⚡⭐⭐⭐❌
⬜⬜⬜⬜⬜⬜⛔⛔⬜⬜⬜⬜
⛔ Route führt durch eine Sperrzone!
...
7 fehlerhafte Aufträge -> fehler.txt
Sky-1: 4 Lieferungen, 14,13 km
```

Erwartetes ``bericht.txt``:
```
NUMMER   KUNDE                  STRECKE     PREIS
LF-0007  Müller Gmbh            2,69 km    6,73 €
LF-0012  Bäckerei Huber         4,74 km   10,15 €
LF-0013  Htl Werkstätte         3,54 km    7,74 €
LF-0021  Café Central           3,16 km    7,29 €
-------------------------------------------------
Gesamtumsatz: 31,91 €
```

Erwartetes ``fehler.txt``:
```
Zeile 9: ungültige Auftragsnummer 'LF-x15'
Zeile 10: LF-0016 – außerhalb des Stadtplans
Zeile 11: LF-0017 – zu schwer (7,50 kg)
Zeile 12: 4 statt 5 Felder
Zeile 13: LF-0019 – Route durch Sperrzone
Zeile 15: LF-0022 – Start und Ziel sind gleich
Zeile 16: LF-0012 – doppelte Auftragsnummer
```

### Bonus - level: 😵‍💫
* Erzeuge eine zweite ``Drohne`` ``"Sky-2"`` mit ``maxGewichtKg: 8.0`` und **demselben** Stadtplan. Ist ein Auftrag für ``Sky-1`` zu schwer, versucht es ``Sky-2``. Gib am Ende beide Statistiken aus.
* Die Drohne darf nicht direkt *neben* einer Sperrzone fliegen (Sicherheitsabstand 1 Feld). Erweitere ``ZeichneRoute``.
