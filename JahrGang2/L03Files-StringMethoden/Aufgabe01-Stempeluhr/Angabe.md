Welche ``Konzepte`` der Programmiersprache üben wir hier?
* Files mit ``File.ReadAllLines`` einlesen und mit ``File.WriteAllLines`` schreiben, ``File.Exists``
* ``String-Methoden``: ``Trim``, ``Split``, ``IndexOf``, ``Substring``, ``ToUpper``, ``ToLower``, ``StartsWith``, ``PadLeft``, ``PadRight``, ``string.Join`` (siehe Tabelle am Ende der Angabe)
* ``Guard-Clauses`` mit *early exit*: ungültige Werte melden wir mit dem Rückgabewert ``-1``

Welche ``Denkweisen`` üben wir hier?
* Wie zerlege ich eine Textzeile Schritt für Schritt in ihre Bestandteile?
* Wie teile ich ein Problem in kleine ``Funktionen`` auf, die ich einzeln testen kann?

>**Guard-Clauses:** In jeder ``Funktion`` prüfen wir zuerst alle *ungewünschten Zustände ❌* und verlassen die ``Funktion`` sofort mit ``return`` (*early exit*). Erst ganz unten steht der *gewünschte Zustand ✅*. Bei jedem Schritt steht dabei, **welche Guards** gebraucht werden. Kennzeichne sie im Code mit dem Kommentar ``// Guard ❌``.
Eine Lösung findest du in [Loesung.cs](Loesung.cs) – schau sie dir nur an, wenn du gar nicht weiterkommst.

>🎬 **Animation:** Zu jedem Schritt gibt es eine Animation, die **ohne Code** zeigt, was passieren soll: [Animated-Slides-Stempeluhr.html](Animated-Slides-Stempeluhr.html) (im Browser öffnen).

## Stempeluhr der Werkstatt
In der Schulwerkstatt stempeln alle beim Kommen und Gehen. Die Stempeluhr speichert die Zeiten in ``stempelzeiten.txt``, aber die Namen wurden händisch eingetippt – mit Leerzeichen und chaotischer Groß-/Kleinschreibung. Manche Zeilen sind fehlerhaft.

Dein Programm berechnet die Arbeitszeit pro Person und schreibt sie schön formatiert in ``arbeitszeiten.txt``.

``stempelzeiten.txt`` (die Zeilennummern stehen nicht in der Datei)
```
# Stempeluhr der Werkstatt
# Format: name;kommen-gehen;kommen-gehen;...
# Zeiten im Format H:MM oder HH:MM

  mÜLLER anna ; 7:30-12:00 ; 12:30-16:15
HUBER   max;8:00-12:00
  gruber LISA ; 6:45-11:15 ; 11:45-15:00 ; 15:30-17:00
  steiner PAUL ; 7.45-12:00 ; 12,30-16:00

wagner tom ; 8:00-12:x0
berger eva ; 13:00-12:00
weber jana ; 8:00-12:00 ;
kaya ; 
 ; 8:00-12:00
fuchs leo ; 8:00-12:00 ; 11:30-15:00
moser ida ; 6:00-24:00
bartholomäus der zweite von hohenstein der zweite von hohenstein der zweite von hohenstein der zweite von hohenstein der zweite von hohenstein der zweite von hohenstein der zweite von hohenstein der zweite von hohenstein der zweite von hohenstein der zweite von hohenstein ; 7:00-11:00
```
(In Zeile 17 wiederholt sich „der zweite von hohenstein“ 10-mal – der Name ist **272 Zeichen** lang. Hier ist er gekürzt.)

>🔧 **Reparieren oder ❌ melden?** Nicht jeder Tippfehler macht eine Zeile wertlos. Die Regel lautet: **Ist eindeutig, was gemeint war, reparieren wir still.** Ein Beispiel ist ``7.45`` statt ``7:45``. **Könnte es mehreres bedeuten oder fehlt etwas, melden wir einen Fehler** – niemals raten! Bei jedem Schritt steht, was repariert und was gemeldet wird. Überlege dir für jede Zeile der Datei vorher selbst, in welche Gruppe sie gehört.

Die ``Funktionen`` sind in ``Program.cs`` bereits *deklariert*. Ersetze *throw new NotImplementedException();* **Schritt für Schritt**. Zu jedem Schritt gibt es in ``Program.cs`` einen auskommentierten Testblock (``/* ---------- Test Schritt N ---------- ... */``). Entferne ``/*`` und ``*/``, starte das Programm und vergleiche mit dem **erwarteten Output**. Die ``[ ]`` in der Ausgabe zeigen dir, wo ein String anfängt und aufhört – so siehst du auch Leerzeichen.

>Die Pfade sind relativ zur ``.exe`` in ``bin/Debug/net10.0``. Deshalb beginnen sie mit ``../../../``.

---

### Schritt 1 - level: 🙂 - Datei finden und einlesen (~5 min)
🎬 [Animation zu Schritt 1](Animated-Slides-Stempeluhr.html#schritt1)

Bevor wir etwas berechnen, müssen wir die Datei finden und einlesen.
- ``File.Exists(pfad)`` liefert ``true``, wenn es die Datei gibt.
- ``File.ReadAllLines(pfad)`` liefert ein ``string[]`` – jede Zeile der Datei ist ein Element, **auch Leerzeilen und Kommentare**.

Es gibt hier nichts zu implementieren: Entferne die Kommentarzeichen beim Test für Schritt 1 und überlege dir, warum die Ausgabe so aussieht.

| Ausdruck | Ergebnis |
|---|---|
| ``File.Exists(eingabePfad)`` | ``true`` |
| ``File.Exists("../../../gibtsnicht.txt")`` | ``false`` |
| ``File.ReadAllLines(eingabePfad).Length`` | ``17`` |
| ``File.ReadAllLines(eingabePfad)[5]`` | ``"HUBER   max;8:00-12:00"`` (Index 5 = Zeile 6!) |

Erwarteter Output (Test Schritt 1):
```
--- Schritt 1 ---
True
False
17
[HUBER   max;8:00-12:00]
```

### Schritt 2 - level: 🙂 - Überschrift erzeugen (~10 min)
🎬 [Animation zu Schritt 2](Animated-Slides-Stempeluhr.html#schritt2)

Implementiere ``string ErzeugeUeberschrift(string s, char links = '=', char rechts = '=', int n = 10)``.

>**Default-Parameter:** Ein Parameter mit ``= wert`` in der Signatur darf beim Aufruf **weggelassen** werden – dann gilt der angegebene Standardwert. Default-Parameter stehen immer **am Ende** der Parameterliste. Wir verwenden sie statt fest eingebauter „magischer Zahlen“: Der Normalfall bleibt kurz, Sonderfälle sind trotzdem möglich.

Im Hauptprogramm reicht dann ``ErzeugeUeberschrift("Arbeitszeiten")``. Mit ``ErzeugeUeberschrift("Pause", '*', '*')`` werden nur ``links`` und ``rechts`` geändert, ``n`` bleibt ``10``.

Rückgabe = *n-mal* ``links`` + Leerzeichen + ``s`` getrimmt in Großbuchstaben + Leerzeichen + *n-mal* ``rechts``.
Tipp: ``"".PadLeft(n, links)`` liefert *n-mal* das Zeichen ``links``.

Guards ❌:
1. ``n < 0`` → ``""`` zurückgeben.
2. ``s`` ist nach ``Trim`` leer → nur die beiden Ränder zurückgeben, ohne Leerzeichen in der Mitte.

| ``s`` | ``links`` | ``rechts`` | ``n`` | Rückgabe |
|---|---|---|---|---|
| ``"Menü"`` | ``'<'`` | ``'>'`` | 5 | ``"<<<<< MENÜ >>>>>"`` |
| ``"  Charts "`` | ``'o'`` | ``'o'`` | 3 | ``"ooo CHARTS ooo"`` |
| ``"Tabelle"`` | ``'!'`` | ``'!'`` | 0 | ``" TABELLE "`` |
| ``"Tabelle"`` | ``'!'`` | ``'!'`` | -1 | ``""`` |
| ``"   "`` | ``'-'`` | ``'-'`` | 2 | ``"----"`` |
| ``"Pause"`` | *(weggelassen → ``'='``)* | *(weggelassen → ``'='``)* | *(weggelassen → 10)* | ``"========== PAUSE =========="`` |
| ``"Pause"`` | ``'*'`` | ``'*'`` | *(weggelassen → 10)* | ``"********** PAUSE **********"`` |

Erwarteter Output (Test Schritt 2):
```
--- Schritt 2 ---
[<<<<< MENÜ >>>>>]
[ooo CHARTS ooo]
[ TABELLE ]
[]
[----]
[========== PAUSE ==========]
[********** PAUSE **********]
```

### Schritt 3 - level: 🙂 - Uhrzeit in Minuten (~10 min)
🎬 [Animation zu Schritt 3](Animated-Slides-Stempeluhr.html#schritt3)

Implementiere ``int ZeitInMinuten(string text)``. Sie rechnet eine Uhrzeit in Minuten seit Mitternacht um. Ist die Uhrzeit ungültig, liefert sie ``-1`` (eine echte Uhrzeit kann nie negativ sein).
- ``Trim``, dann mit ``IndexOf(':')`` den Doppelpunkt suchen und mit ``Substring`` Stunden und Minuten trennen.
- Die Minuten sind **immer zweistellig**, die Stunden ein- oder zweistellig.

Reparatur 🔧 (gleich nach dem ``Trim``): Manche haben ``7.45`` oder ``12,30`` getippt. Es ist eindeutig, was gemeint war → ersetze ``.`` und ``,`` durch ``:`` (``Replace``). Erst **danach** wird der Doppelpunkt gesucht.

Guards ❌ (jeweils ``return -1;``):
1. Kein ``:`` gefunden (``IndexOf`` liefert ``-1``).
2. Der Minutenteil ist nicht genau 2 Zeichen lang.
3. Stunden oder Minuten sind keine Zahl (``int.TryParse``).
4. Stunden nicht 0–23 oder Minuten nicht 0–59.

| Aufruf | Rückgabe | Warum? |
|---|---|---|
| ``ZeitInMinuten("7:30")`` | ``450`` | 7 · 60 + 30 |
| ``ZeitInMinuten(" 12:00 ")`` | ``720`` | Leerzeichen werden getrimmt |
| ``ZeitInMinuten("12:x0")`` | ``-1`` | Guard 3: ``x0`` ist keine Zahl |
| ``ZeitInMinuten("8:5")`` | ``-1`` | Guard 2: Minuten nicht zweistellig |
| ``ZeitInMinuten("25:00")`` | ``-1`` | Guard 4: 25 Uhr gibt es nicht |
| ``ZeitInMinuten("1230")`` | ``-1`` | Guard 1: kein ``:`` |
| ``ZeitInMinuten("7.45")`` | ``465`` | 🔧 ``.`` wird zu ``:`` |
| ``ZeitInMinuten("12,30")`` | ``750`` | 🔧 ``,`` wird zu ``:`` |

Erwarteter Output (Test Schritt 3):
```
--- Schritt 3 ---
450
720
-1
-1
-1
-1
465
750
```

### Schritt 4 - level: 🤔 - Zeitbereiche (~15 min)
🎬 [Animation zu Schritt 4](Animated-Slides-Stempeluhr.html#schritt4)

1. ``int DauerInMinuten(string bereich)`` – ``"7:30-12:00"`` → ``270``, ungültig → ``-1``.
   Guards ❌:
   1. ``Split('-')`` liefert nicht genau 2 Teile.
   2. Eine der beiden Zeiten ist ungültig (``ZeitInMinuten`` liefert ``-1``).
   3. Das Ende liegt vor dem Start (``"13:00-12:00"``).
2. ``int SummiereZeiten(string[] teile)`` – ``teile`` ist eine mit ``Split(';')`` zerlegte Zeile. ``teile[0]`` ist der Name, **alle weiteren** Teile sind Zeitbereiche. Liefert die Summe aller Dauern oder ``-1``.
   Hier ist eine ``for``-Schleife ab ``i = 1`` richtig, denn ``teile[0]`` (der Name) soll übersprungen werden.
   Merke dir in der Schleife ``summe``, ``anzahlBereiche`` (gültige Bereiche) und ``letztesEnde`` (Ende des vorigen Bereichs, am Anfang ``-1``).
   - Reparatur 🔧: Ein **leerer** Bereich entsteht durch ein ``;`` am Zeilenende (``"weber jana ; 8:00-12:00 ;"``). Er wird mit ``continue`` übersprungen (``string.IsNullOrWhiteSpace``).
   - Guard ❌ **in der Schleife:** Ein Zeitbereich ist ungültig → sofort ``-1``, die ganze Zeile ist ungültig.
   - Guard ❌ **in der Schleife:** Der Bereich **beginnt vor dem Ende** des vorigen (``11:30`` < ``12:00``), die Bereiche überlappen. Niemand kann gleichzeitig zweimal arbeiten → ``-1``. Die Startzeit bekommst du mit ``ZeitInMinuten(teile[i].Split('-')[0])``.
   - Guard ❌ **nach der Schleife:** Es gab keinen einzigen gültigen Bereich (``anzahlBereiche == 0``, z.B. ``"kaya ; "``) → ``-1``.

   >Denk nach: Warum ist ein leerer Bereich am Ende reparierbar, eine Überlappung aber nicht? Was müsste das Programm bei einer Überlappung „raten“?

| Aufruf | Rückgabe |
|---|---|
| ``DauerInMinuten("7:30-12:00")`` | ``270`` |
| ``DauerInMinuten(" 12:30-16:15 ")`` | ``225`` |
| ``DauerInMinuten("13:00-12:00")`` | ``-1`` |
| ``DauerInMinuten("8:00")`` | ``-1`` |
| ``SummiereZeiten("anna ; 7:30-12:00 ; 12:30-16:15".Split(';'))`` | ``495`` (270 + 225) |
| ``SummiereZeiten("tom ; 8:00-12:x0".Split(';'))`` | ``-1`` |
| ``SummiereZeiten("kaya".Split(';'))`` | ``-1`` (kein Bereich) |
| ``SummiereZeiten("weber ; 8:00-12:00 ;".Split(';'))`` | ``240`` (🔧 leerer Bereich übersprungen) |
| ``SummiereZeiten("fuchs ; 8:00-12:00 ; 11:30-15:00".Split(';'))`` | ``-1`` (❌ Überlappung) |

Erwarteter Output (Test Schritt 4):
```
--- Schritt 4 ---
270
225
-1
-1
495
-1
-1
240
-1
```

### Schritt 5 - level: 🙂 - Formatieren (~10 min)
🎬 [Animation zu Schritt 5](Animated-Slides-Stempeluhr.html#schritt5)

1. ``string FormatiereName(string text)`` – jedes Wort: erster Buchstabe groß, Rest klein.
   ``"  mÜLLER anna "`` → ``"Müller Anna"``, ``"HUBER   max"`` → ``"Huber Max"``.
   Tipp: ``Split`` mit ``RemoveEmptyEntries``, pro Wort ``Substring(0, 1).ToUpper()`` + ``Substring(1).ToLower()``, dann ``string.Join``.
2. ``string FormatiereDauer(int minuten)`` – ``495`` → ``"8:15"``, ``240`` → ``"4:00"``.
   Tipp: ``/`` und ``%`` mit 60, die Minuten mit ``PadLeft(2, '0')`` zweistellig machen.
3. ``int BerechneSpaltenbreite(string[] namen, int MaxNamenLaenge = 255)`` – wie breit muss die Namensspalte sein?
   - ``MaxNamenLaenge`` ist ein **Default-Parameter**: Ruft man die Funktion nur mit ``namen`` auf, ist er automatisch ``255``. Man kann aber auch einen anderen Wert mitgeben, z.B. ``BerechneSpaltenbreite(namen, 10)``.
   - Gehe die Namen mit ``foreach`` durch und merke dir die Länge des **längsten** (``laengste``) und des **zweitlängsten** Namens (``zweitLaengste``).
     Tipp: Ist ein Name länger als ``laengste``, rutscht der bisherige Wert von ``laengste`` nach ``zweitLaengste``. Ist er nur länger als ``zweitLaengste``, ersetzt er nur diesen.
   - Guard ❌: Ist der längste Name länger als ``MaxNamenLaenge``, ist er ein Ausreißer (Copy-Paste-Fehler). Sonst würde die Tabelle für alle unlesbar breit. Gib dann ``zweitLaengste`` zurück.
   - ✅ Sonst gib ``laengste`` zurück.
4. ``string FormatiereZeile(string name, int minuten, int breite)`` – eine Tabellenzeile.
   - Guard ❌: Ist ``name`` länger als ``breite``, schneide ihn mit ``Substring(0, breite)`` ab und hänge ``"..."`` an. Dann ist er genau ``breite + 3`` Zeichen lang.
   - ✅ Rückgabe: ``name.PadRight(breite + 3)`` + ``FormatiereDauer(minuten).PadLeft(6)`` + ``" h"``. Die ``+ 3`` sorgen für Abstand – oder für Platz für die ``...``.

   >Denk nach: Warum ist das Abschneiden hier erlaubt, obwohl wir sonst „nicht raten“? (Tipp: Geht dabei eine Information verloren, die das Programm zum **Rechnen** braucht?)

| Aufruf | Rückgabe |
|---|---|
| ``FormatiereName("  mÜLLER anna ")`` | ``"Müller Anna"`` |
| ``FormatiereName("HUBER   max")`` | ``"Huber Max"`` |
| ``FormatiereDauer(495)`` | ``"8:15"`` |
| ``FormatiereDauer(240)`` | ``"4:00"`` |
| ``FormatiereDauer(5)`` | ``"0:05"`` |
| ``BerechneSpaltenbreite(["Huber Max", "Steiner Paul", "Weber Jana"])`` | ``12`` (Steiner Paul) |
| ``BerechneSpaltenbreite(["Anna", <300 × 'x'>, "Huber Max"])`` | ``9`` (300 > 255 → zweitlängster: Huber Max) |
| ``BerechneSpaltenbreite(["Huber Max", "Steiner Paul", "Weber Jana"], 10)`` | ``10`` (12 > 10 → zweitlängster: Weber Jana) |
| ``FormatiereZeile("Huber Max", 240, 12)`` | ``"Huber Max        4:00 h"`` |
| ``FormatiereZeile("Bartholomäus Der Zweite", 240, 12)`` | ``"Bartholomäus...  4:00 h"`` |

Erwarteter Output (Test Schritt 5):
```
--- Schritt 5 ---
[Müller Anna]
[Huber Max]
8:15
4:00
0:05
12
9
10
[Huber Max        4:00 h]
[Bartholomäus...  4:00 h]
```

### Schritt 6 - level: 🤔 - Hauptprogramm (~15 min)
🎬 [Animation zu Schritt 6](Animated-Slides-Stempeluhr.html#schritt6)

1. Guard ❌: Prüfe mit ``File.Exists``, ob ``stempelzeiten.txt`` existiert. Wenn nicht: Meldung und ``return;`` (*early exit*).
2. Lies alle Zeilen mit ``File.ReadAllLines`` ein und gehe sie mit einer ``foreach``-Schleife durch. Guard ❌ in der Schleife: Überspringe mit ``continue`` Leerzeilen (``string.IsNullOrWhiteSpace``) und Kommentare (``StartsWith("#")``).
   >``foreach`` statt ``for``: Wir brauchen keinen Index, um die Zeilen zu lesen. Die Zeilennummer für die Meldung ist **kein** Grund für eine ``for``-Schleife – zähle sie selbst mit (``int zeilenNummer = 0;`` vor der Schleife, ``zeilenNummer++;`` als **erste** Anweisung in der Schleife, also noch vor jedem ``continue``).
3. Zerlege jede Zeile mit ``Split(';')``, formatiere den Namen und summiere die Zeiten.
   Guard ❌ in der Schleife: Ist der Name leer, gib ``⚠️ Zeile {zeilenNummer}: Name fehlt`` aus und mach mit ``continue`` weiter. Ohne Namen wissen wir nicht, wem die Zeiten gehören.
   Guard ❌ in der Schleife: Liefert ``SummiereZeiten`` ``-1``, gib ``⚠️ Zeile {zeilenNummer}: ungültige Zeiten bei {name}`` auf der Konsole aus (``zeilenNummer`` ab 1) und mach mit ``continue`` bei der nächsten Zeile weiter.
4. **Durchgang 1:** Gültige Personen werden noch **nicht** ausgegeben – die Spaltenbreite hängt ja vom längsten Namen ab, und den kennen wir erst am Ende!
   Merke dir stattdessen Name und Summe in ``string[] namen`` und ``int[] summen``. Du weißt am Anfang nicht, wie viele Zeilen gültig sind: Lege beide mit ``zeilen.Length`` an und zähle mit ``anzahlPersonen`` mit.
5. **Durchgang 2:** Kopiere die befüllten Namen in ein neues Array ``gueltigeNamen`` (Länge ``anzahlPersonen``) und berechne damit ``breite = BerechneSpaltenbreite(gueltigeNamen)``.
   Lege ``string[] ausgabe`` mit ``anzahlPersonen + 1`` Plätzen an. Platz 0 ist ``ErzeugeUeberschrift("Arbeitszeiten")`` (die Default-Parameter liefern ``'='``, ``'='`` und ``10``), danach kommt pro Person ``FormatiereZeile(namen[i], summen[i], breite)``.
   >Hier ist eine ``for``-Schleife richtig: Wir brauchen den Index ``i`` für **zwei** Arrays gleichzeitig (``namen[i]`` und ``summen[i]``).
6. Schreib das Ergebnis mit ``File.WriteAllLines`` in ``arbeitszeiten.txt`` und gib es auch auf der Konsole aus.

Testfälle – welche Zeile landet wo?

| Zeile | Inhalt | Ergebnis |
|---|---|---|
| 1–4, 9 | Kommentar / Leerzeile | übersprungen (``continue``) |
| 5 | ``mÜLLER anna`` mit 2 Bereichen | ``Müller Anna 8:15 h`` |
| 6 | ``HUBER   max`` mit 1 Bereich | ``Huber Max 4:00 h`` |
| 7 | ``gruber LISA`` mit 3 Bereichen | ``Gruber Lisa 9:15 h`` |
| 8 | ``7.45`` und ``12,30`` | 🔧 repariert → ``Steiner Paul 7:45 h`` |
| 10 | ``12:x0`` ist keine Uhrzeit | ⚠️ Warnung |
| 11 | Ende vor Start | ⚠️ Warnung |
| 12 | ``;`` am Zeilenende | 🔧 repariert → ``Weber Jana 4:00 h`` |
| 13 | ``kaya ;`` – kein einziger Zeitbereich | ⚠️ Warnung |
| 14 | kein Name | ⚠️ Name fehlt |
| 15 | ``11:30`` beginnt vor dem Ende ``12:00`` | ⚠️ Warnung (Überlappung) |
| 16 | ``24:00`` | ⚠️ Warnung (Stunde 24 gibt es nicht) |
| 17 | Name mit 272 Zeichen | ✅ aber gekürzt: ``Bartholomäus...  4:00 h``. Die Spaltenbreite richtet sich nach dem zweitlängsten Namen (``Steiner Paul``, 12 Zeichen) |

Erwartete Konsolenausgabe:
```
⚠️ Zeile 10: ungültige Zeiten bei Wagner Tom
⚠️ Zeile 11: ungültige Zeiten bei Berger Eva
⚠️ Zeile 13: ungültige Zeiten bei Kaya
⚠️ Zeile 14: Name fehlt
⚠️ Zeile 15: ungültige Zeiten bei Fuchs Leo
⚠️ Zeile 16: ungültige Zeiten bei Moser Ida

========== ARBEITSZEITEN ==========
Müller Anna      8:15 h
Huber Max        4:00 h
Gruber Lisa      9:15 h
Steiner Paul     7:45 h
Weber Jana       4:00 h
Bartholomäus...  4:00 h
```

Erwartetes ``arbeitszeiten.txt``:
```
========== ARBEITSZEITEN ==========
Müller Anna      8:15 h
Huber Max        4:00 h
Gruber Lisa      9:15 h
Steiner Paul     7:45 h
Weber Jana       4:00 h
Bartholomäus...  4:00 h
```

### Bonus - level: 😵‍💫
* Gib unter der Tabelle die Gesamtarbeitszeit aller Personen aus.
* Markiere alle, die mehr als 9 Stunden gearbeitet haben, mit einem ``⚠️`` (Arbeitszeitgesetz!).

---

### String-Methoden
| Signatur | Was macht sie? | Beispiel |
|---|---|---|
| ``string Trim()`` | entfernt Leerzeichen vorne und hinten | ``"  ab  ".Trim()`` → ``"ab"`` |
| ``string Replace(char alt, char neu)`` | ersetzt **jedes** ``alt`` durch ``neu`` | ``"7.45".Replace('.', ':')`` → ``"7:45"`` |
| ``static bool string.IsNullOrWhiteSpace(string wert)`` | ist der String leer oder nur Leerzeichen? | ``string.IsNullOrWhiteSpace(" ")`` → ``true`` |
| ``string ToUpper()`` / ``string ToLower()`` | alles groß / klein | ``"Menü".ToUpper()`` → ``"MENÜ"`` |
| ``bool StartsWith(string wert)`` | beginnt der String mit ``wert``? | ``"# Info".StartsWith("#")`` → ``true`` |
| ``int IndexOf(char wert)`` | Index des **ersten** Vorkommens, sonst ``-1`` | ``"7:30".IndexOf(':')`` → ``1`` |
| ``string Substring(int start)`` | alles ab ``start`` bis zum Ende | ``"7:30".Substring(2)`` → ``"30"`` |
| ``string Substring(int start, int laenge)`` | ``laenge`` Zeichen ab ``start`` | ``"7:30".Substring(0, 1)`` → ``"7"`` |
| ``string PadLeft(int breite, char fuell)`` | füllt **links** auf, bis ``breite`` erreicht ist | ``"5".PadLeft(2, '0')`` → ``"05"`` |
| ``string PadRight(int breite)`` | füllt **rechts** mit Leerzeichen auf | ``"Max".PadRight(6)`` → ``"Max   "`` |
| ``string[] Split(char trenner, StringSplitOptions optionen)`` | mit ``StringSplitOptions.RemoveEmptyEntries`` fallen leere Teile weg | ``"a  b".Split(' ', StringSplitOptions.RemoveEmptyEntries)`` → ``["a","b"]`` |
| ``static string string.Join(string trenner, string[] werte)`` | Gegenteil von ``Split`` | ``string.Join(" ", ["a","b"])`` → ``"a b"`` |
| ``string PadLeft(int breite, char fuell)`` auf ``""`` | ein leerer String wird mit ``breite`` Zeichen aufgefüllt | ``"".PadLeft(3, '<')`` → ``"<<<"`` |
