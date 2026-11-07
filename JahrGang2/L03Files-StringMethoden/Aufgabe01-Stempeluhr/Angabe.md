Welche ``Konzepte`` der Programmiersprache üben wir hier?
* Files mit ``File.ReadAllLines`` einlesen und mit ``File.WriteAllLines`` schreiben, ``File.Exists``
* ``String-Methoden``: ``Trim``, ``Split``, ``IndexOf``, ``Substring``, ``ToUpper``, ``ToLower``, ``StartsWith``, ``PadLeft``, ``PadRight``, ``string.Join``
* ``Guard-Clauses`` mit *early exit*: ungültige Werte melden wir mit dem Rückgabewert ``-1``

Welche ``Denkweisen`` üben wir hier?
* Wie zerlege ich eine Textzeile Schritt für Schritt in ihre Bestandteile?
* Wie teile ich ein Problem in kleine ``Funktionen`` auf, die ich einzeln testen kann?

Aufwand: ca. 1 Stunde. Diese Aufgabe ist die Vorbereitung für Aufgabe 2 (Drohnenlieferung).

>**Guard-Clauses:** In jeder ``Funktion`` prüfen wir zuerst alle *ungewünschten Zustände ❌* und verlassen die ``Funktion`` sofort mit ``return`` (*early exit*). Erst ganz unten steht der *gewünschte Zustand ✅*. Bei jeder Teilaufgabe steht dabei, **welche Guards** gebraucht werden. Kennzeichne sie im Code mit dem Kommentar ``// Guard ❌``.
Eine Lösung findest du in [Loesung.cs](Loesung.cs) – schau sie dir nur an, wenn du gar nicht weiterkommst.

>**Regeln wie beim Test:** Ausgaben mit ``Console.WriteLine`` gibt es **nur im Hauptprogramm**, nicht in den ``Funktionen``. Exceptions (``try/catch``, ``int.Parse``) werden nicht verwendet – wir arbeiten mit ``int.TryParse``.

## Stempeluhr der Werkstatt
In der Schulwerkstatt stempeln alle beim Kommen und Gehen. Die Stempeluhr speichert die Zeiten in ``stempelzeiten.txt``, aber die Namen wurden händisch eingetippt – mit Leerzeichen und chaotischer Groß-/Kleinschreibung. Manche Zeilen sind fehlerhaft.

Dein Programm berechnet die Arbeitszeit pro Person und schreibt sie schön formatiert in ``arbeitszeiten.txt``.

``stempelzeiten.txt``
```
# Stempeluhr der Werkstatt
# Format: name;kommen-gehen;kommen-gehen;...
# Zeiten im Format H:MM oder HH:MM

  mÜLLER anna ; 7:30-12:00 ; 12:30-16:15
HUBER   max;8:00-12:00
  gruber LISA ; 6:45-11:15 ; 11:45-15:00 ; 15:30-17:00

wagner tom ; 8:00-12:x0
berger eva ; 13:00-12:00
kaya ; 
```

Die ``Funktionen`` sind in ``Program.cs`` bereits *deklariert*. Ersetze *throw new NotImplementedException();* **schrittweise** und teste jede ``Funktion`` gleich mit ein paar Aufrufen im Hauptprogramm.

>Die Pfade sind relativ zur ``.exe`` in ``bin/Debug/net10.0``. Deshalb beginnen sie mit ``../../../``.

### Neue String-Methoden
| Signatur | Was macht sie? | Beispiel |
|---|---|---|
| ``string Trim()`` | entfernt Leerzeichen vorne und hinten | ``"  ab  ".Trim()`` → ``"ab"`` |
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

---

### Aufgabe 1 - level: 🙂 - Überschrift erzeugen (~10 min)
Implementiere ``string ErzeugeUeberschrift(string s, char links, char rechts, int n)``.

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

### Aufgabe 2 - level: 🙂 - Uhrzeit in Minuten (~10 min)
Implementiere ``int ZeitInMinuten(string text)``. Sie rechnet eine Uhrzeit in Minuten seit Mitternacht um. Ist die Uhrzeit ungültig, liefert sie ``-1`` (eine echte Uhrzeit kann nie negativ sein).
- ``Trim``, dann mit ``IndexOf(':')`` den Doppelpunkt suchen und mit ``Substring`` Stunden und Minuten trennen.
- Die Minuten sind **immer zweistellig**, die Stunden ein- oder zweistellig.

Guards ❌ (jeweils ``return -1;``):
1. Kein ``:`` gefunden (``IndexOf`` liefert ``-1``).
2. Der Minutenteil ist nicht genau 2 Zeichen lang.
3. Stunden oder Minuten sind keine Zahl (``int.TryParse``).
4. Stunden nicht 0–23 oder Minuten nicht 0–59.

| Aufruf | Rückgabe |
|---|---|
| ``ZeitInMinuten("7:30")`` | ``450`` |
| ``ZeitInMinuten(" 12:00 ")`` | ``720`` |
| ``ZeitInMinuten("12:x0")`` | ``-1`` |
| ``ZeitInMinuten("8:5")`` | ``-1`` |
| ``ZeitInMinuten("25:00")`` | ``-1`` |

### Aufgabe 3 - level: 🤔 - Zeitbereiche (~15 min)
1. ``int DauerInMinuten(string bereich)`` – ``"7:30-12:00"`` → ``270``, ungültig → ``-1``.
   Guards ❌:
   1. ``Split('-')`` liefert nicht genau 2 Teile.
   2. Eine der beiden Zeiten ist ungültig (``ZeitInMinuten`` liefert ``-1``).
   3. Das Ende liegt vor dem Start (``"13:00-12:00"``).
2. ``int SummiereZeiten(string[] teile)`` – ``teile`` ist eine mit ``Split(';')`` zerlegte Zeile. ``teile[0]`` ist der Name, **alle weiteren** Teile sind Zeitbereiche. Liefert die Summe aller Dauern oder ``-1``.
   Guards ❌:
   1. Es gibt keinen einzigen Zeitbereich (``teile.Length < 2``).
   2. **In der Schleife:** Ein Zeitbereich ist ungültig → sofort ``-1``, die ganze Zeile ist ungültig.

### Aufgabe 4 - level: 🙂 - Formatieren (~10 min)
1. ``string FormatiereName(string text)`` – jedes Wort: erster Buchstabe groß, Rest klein.
   ``"  mÜLLER anna "`` → ``"Müller Anna"``, ``"HUBER   max"`` → ``"Huber Max"``.
   Tipp: ``Split`` mit ``RemoveEmptyEntries``, pro Wort ``Substring(0, 1).ToUpper()`` + ``Substring(1).ToLower()``, dann ``string.Join``.
2. ``string FormatiereDauer(int minuten)`` – ``495`` → ``"8:15"``, ``240`` → ``"4:00"``.
   Tipp: ``/`` und ``%`` mit 60, die Minuten mit ``PadLeft(2, '0')`` zweistellig machen.

### Aufgabe 5 - level: 🤔 - Hauptprogramm (~15 min)
1. Guard ❌: Prüfe mit ``File.Exists``, ob ``stempelzeiten.txt`` existiert. Wenn nicht: Meldung und ``return;`` (*early exit*).
2. Lies alle Zeilen mit ``File.ReadAllLines`` ein. Guard ❌ in der Schleife: Überspringe mit ``continue`` Leerzeilen (``string.IsNullOrWhiteSpace``) und Kommentare (``StartsWith("#")``).
3. Zerlege jede Zeile mit ``Split(';')``, formatiere den Namen und summiere die Zeiten.
   Guard ❌ in der Schleife: Liefert ``SummiereZeiten`` ``-1``, gib ``⚠️ Zeile {nr}: ungültige Zeiten bei {name}`` auf der Konsole aus (``nr`` ab 1) und mach mit ``continue`` bei der nächsten Zeile weiter.
4. Sammle die Ausgabezeilen in einem ``string[]``. Die erste Zeile ist ``ErzeugeUeberschrift("Arbeitszeiten", '=', '=', 10)``, danach pro Person ``name.PadRight(16)`` + ``FormatiereDauer(summe).PadLeft(6)`` + ``" h"``.
   Da du am Anfang nicht weißt, wie viele Zeilen gültig sind: Lege das Array mit ``zeilen.Length + 2`` an, zähle mit und kopiere am Ende nur die befüllten Zeilen in ein neues Array.
5. Schreib das Ergebnis mit ``File.WriteAllLines`` in ``arbeitszeiten.txt`` und gib es auch auf der Konsole aus.

Erwartete Konsolenausgabe:
```
⚠️ Zeile 9: ungültige Zeiten bei Wagner Tom
⚠️ Zeile 10: ungültige Zeiten bei Berger Eva
⚠️ Zeile 11: ungültige Zeiten bei Kaya

========== ARBEITSZEITEN ==========
Müller Anna       8:15 h
Huber Max         4:00 h
Gruber Lisa       9:15 h
```

### Bonus - level: 😵‍💫
* Gib unter der Tabelle die Gesamtarbeitszeit aller Personen aus.
* Markiere alle, die mehr als 9 Stunden gearbeitet haben, mit einem ``⚠️`` (Arbeitszeitgesetz!).
