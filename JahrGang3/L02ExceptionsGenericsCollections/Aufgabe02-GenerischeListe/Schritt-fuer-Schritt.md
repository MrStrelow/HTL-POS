# Schritt für Schritt: Der generische Güterbahnhof

Diese Anleitung führt dich durch die [Angabe](Angabe.md). Arbeite die Schritte **der Reihe nach** ab und hake jeden ab. Nach jedem Teil: **kompilieren, testen, Fragen beantworten**, erst dann weiter.

Hilfe: [Animation Generics](../Skripten/L02.2_Generics.html) · [Zettelübung Kopie vs. ref](../ZettelUebungen/03_KopieVsRef.md)

---

## Teil 0 – Vorbereitung

- [ ] Neues Konsolenprojekt ``Gueterbahnhof`` anlegen.
- [ ] ``Waggon.cs``, ``Zug.cs`` und ``Program.cs`` aus ``Vorlage`` hineinkopieren.
- [ ] Starten. Ausgabe muss ``🚂-[1]-[3]-[7]`` und ``2`` sein. **Erst wenn das läuft, weiter.**

---

## Teil 1 – Waggon&lt;T&gt; und Zug&lt;T&gt;

**Ziel:** Jede Ladung wird ``T``, alles andere bleibt ``int``.

1. [ ] **Waggon**
   - [ ] ``class Waggon`` → ``class Waggon<T>``
   - [ ] ``int Ladung`` → ``T Ladung``, Konstruktor-Parameter ebenso
   - [ ] ``Waggon? Next/Prev`` → ``Waggon<T>? Next/Prev``
2. [ ] **Zug** – zuerst nur die Klasse
   - [ ] ``class Zug`` → ``class Zug<T>``
   - [ ] ``Head``, ``Tail`` → ``Waggon<T>?``
   - [ ] Kompilieren: Jetzt zeigt der Compiler dir **jede** Stelle, an der noch ``Waggon`` ohne ``<T>`` steht. Arbeite die Fehlerliste von oben nach unten ab.
3. [ ] **Jedes ``int`` prüfen.** Stelle dir bei jedem ``int`` die Frage: *Ist das eine Ladung oder eine Position/Anzahl?*

   | Stelle | Ladung → ``T`` | Position/Anzahl → ``int`` |
   |---|:---:|:---:|
   | Parameter ``ladung``, ``neueLadung`` | ✔ | |
   | Rückgabe von ``AbkuppelnVorne``, ``Get``, ``Umladen`` | ✔ | |
   | lokale Variablen ``ladung``, ``alteLadung`` | ✔ | |
   | ``position``, ``Count``, ``i`` | | ✔ |
   | Rückgabe von ``Finde`` | | ✔ (Position!) |

4. [ ] In ``Finde``: ``curr.Ladung == ladung`` → ``Equals(curr.Ladung, ladung)``.
5. [ ] ``Program.cs``: ``Zug`` → ``Zug<int>``, dann den Test aus der Angabe einfügen.
6. [ ] Ausgabe mit der Angabe vergleichen.
7. [ ] Fragen 1–3 als Kommentar beantworten (Frage 2: Fehlernummer ``CS1503`` notieren).

> **Stolperfalle:** ``Finde`` gibt eine **Position** zurück → bleibt ``int``, auch wenn der Parameter ``T`` wird.

---

## Teil 2 – Bahnhof und Paar&lt;TLinks, TRechts&gt;

**Ziel:** Generische Methoden in einer **nicht** generischen Klasse.

1. [ ] **Paar.cs** anlegen
   - [ ] ``class Paar<TLinks, TRechts>``
   - [ ] Eigenschaften ``Links`` (``TLinks``) und ``Rechts`` (``TRechts``), nur ``get``
   - [ ] Konstruktor mit beiden Werten
   - [ ] ``ToString`` → ``Links + "|" + Rechts``
2. [ ] **Bahnhof.cs** anlegen: ``public static class Bahnhof`` – **ohne** ``<T>`` hinter dem Klassennamen!
3. [ ] ``AusArray<T>(T[] ladungen)``
   - [ ] neuen ``Zug<T>`` anlegen
   - [ ] ``foreach`` über die Ladungen → ``AnhaengenHinten``
4. [ ] ``Wenden<T>(Zug<T> zug)``
   - [ ] neuen Zug anlegen
   - [ ] ``Waggon<T>? curr = zug.Tail;``
   - [ ] solange ``curr != null``: hinten anhängen, ``curr = curr.Prev``
5. [ ] ``Kuppeln<TA, TB>(Zug<TA> a, Zug<TB> b)``
   - [ ] Ergebnistyp: ``Zug<Paar<TA, TB>>``
   - [ ] **zwei** Läufer ``currA``, ``currB``
   - [ ] Schleife läuft, solange **beide** nicht ``null`` sind
   - [ ] pro Durchlauf ein ``new Paar<TA, TB>(…)`` anhängen, beide Läufer weiter
6. [ ] Test aus der Angabe einfügen, Ausgabe vergleichen.
7. [ ] Fragen 1–2 beantworten.

> **Tipp:** Zeichne für ``Kuppeln`` die zwei Züge untereinander und gehe mit zwei Fingern gleichzeitig durch.

---

## Teil 3 – Einschränkungen mit where

**Ziel:** Für jede Methode selbst herausfinden, welches ``where`` sie braucht.
**Vorgehen bei jeder Methode:** ① ohne ``where`` schreiben → ② kompilieren → ③ Fehler lesen → ④ passendes ``where`` ergänzen.

1. [ ] **Fracht.cs** anlegen
   - [ ] ``public abstract class Fracht : IComparable<Fracht>``
   - [ ] ``int Tonnen { get; private set; }``
   - [ ] ``protected`` Konstruktor mit Tonnen
   - [ ] ``public abstract string Symbol { get; }``
   - [ ] ``Nachladen(int tonnen)`` erhöht ``Tonnen``
   - [ ] ``CompareTo(Fracht? other)``: ``null`` → ``1``, sonst ``Tonnen - other.Tonnen``
   - [ ] ``ToString`` → ``Symbol + " " + Tonnen + " t"``
2. [ ] ``Holz`` und ``Kohle`` anlegen
   - [ ] Konstruktor mit Tonnen → ``: base(tonnen)``
   - [ ] leerer Konstruktor → ``: this(0)``
   - [ ] ``Symbol`` überschreiben (🪵 bzw. 🪨)
3. [ ] Methoden in ``Bahnhof`` – trage nach Schritt ④ die Einschränkung ein:

   | Methode | Fehler ohne ``where`` | dein ``where`` |
   |---|---|---|
   | ``Groesste<T>`` | ``CompareTo`` unbekannt | |
   | ``Gesamtgewicht<T>`` | ``Tonnen`` unbekannt | |
   | ``Leerzug<T>`` | ``new T()`` nicht erlaubt | |
   | ``ErsteOderNull<T>`` | ``return null`` nicht erlaubt | |
   | ``ErsterWertOderNull<T>`` | ``T?`` ist nicht ``Nullable<T>`` | |

4. [ ] ``Groesste``: leerer Zug → ``InvalidOperationException``. Sonst ``max = Head.Ladung``, ab ``Head.Next`` mit ``CompareTo(max) > 0`` vergleichen.
5. [ ] Test aus der Angabe einfügen, Ausgabe vergleichen.
6. [ ] Die drei auskommentierten Zeilen **einzeln** einkommentieren, Fehlernummer notieren, wieder auskommentieren.
7. [ ] Fragen 1–4 beantworten.

> **Merke:** Je mehr du einschränkst, desto mehr darfst du mit ``T`` machen – aber desto weniger Typen passen.

---

## Teil 4 – Sortierzug&lt;T&gt;

**Ziel:** Das ``where`` steht diesmal bei der **Klasse**.

1. [ ] ``class Sortierzug<T> where T : …`` (welche Einschränkung braucht ``Einreihen``?)
2. [ ] privates Feld ``Zug<T> zug = new Zug<T>();`` – der Sortierzug **hat** einen Zug (kein Erben).
3. [ ] ``Count`` → gibt ``zug.Count`` weiter.
4. [ ] ``Einreihen(T ladung)``
   - [ ] ``position = 0``, ``curr = zug.Head``
   - [ ] weiter, solange ``curr != null`` **und** ``curr.Ladung`` **kleiner oder gleich** ``ladung`` ist
   - [ ] dann ``zug.Einreihen(position, ladung)``
5. [ ] ``Kleinste`` → ``zug.Get(0)``, ``Groesste`` → ``zug.Get(zug.Count - 1)``
6. [ ] ``ToString`` → ``zug.ToString()``
7. [ ] Test, Ausgabe vergleichen (``[1]-[1]-[4]-[5]``: gleiche Werte **hinten** dran!).
8. [ ] Fragen 1–2 beantworten.

> **Stolperfalle:** Mit ``< 0`` statt ``<= 0`` kommen gleiche Ladungen **vor** die vorhandenen.

---

## Teil 5 – Kopie der Referenz vs. ref

**Ziel:** Verstehen, **welcher Pfeil** sich bei einer Zuweisung ändert.

1. [ ] **Zuerst auf Papier!** Zeichne für den Testcode Variablen und Objekte als Kästchen mit Pfeilen (wie in der Zettelübung):
   - [ ] nach ``a.AnhaengenHinten(stamm)``: Wohin zeigen ``stamm`` und ``Ladung`` des Waggons?
   - [ ] nach ``stamm.Nachladen(4)``: Was ändert sich – ein Pfeil oder das Objekt?
   - [ ] nach ``Zug<Holz> c = a;``: Wohin zeigt ``c``?
   - [ ] nach ``Tauschen(ref a, ref b)``: Welche Pfeile haben sich geändert? Welcher **nicht**?
2. [ ] Ausgabe vorhersagen und aufschreiben.
3. [ ] ``Tauschen<T>(ref T a, ref T b)`` in ``Bahnhof`` schreiben (3 Zeilen mit ``temp``).
4. [ ] Test ausführen und mit deiner Vorhersage vergleichen.
5. [ ] **Experiment:** Entferne bei ``Tauschen`` die beiden ``ref`` (auch beim Aufruf). Was ändert sich an der Ausgabe? Warum? Danach wieder zurück.
6. [ ] Fragen 1–4 beantworten.

> **Merke:** ``a = …`` ändert nur die Variable links vom ``=``. Ohne ``ref`` ist das eine Kopie, mit ``ref`` die Variable des Aufrufers.

---

## Teil 6 – Ko- und Kontravarianz

**Ziel:** Für jedes Interface entscheiden: Fließt ``T`` nur **heraus** (``out``) oder nur **hinein** (``in``)?

1. [ ] **Varianz.cs** anlegen
   - [ ] ``interface IZugQuelle<out T>`` mit ``int Count { get; }`` und ``T Get(int position)``
   - [ ] ``interface IVerlader<in T>`` mit ``void Verlade(T ladung)``
2. [ ] ``Zug<T>`` setzt ``IZugQuelle<T>`` um: nur ``: IZugQuelle<T>`` ergänzen, die Mitglieder gibt es schon.
3. [ ] ``class Lager : IVerlader<Fracht>``
   - [ ] ``Anzahl`` und ``Tonnen`` (nur lesen)
   - [ ] ``Verlade`` zählt beides hoch
   - [ ] ``ToString`` → ``Lager: 3 Frachtstücke, 40 t``
4. [ ] ``Anzeigen(IZugQuelle<Fracht> zug)`` – **ohne** ``<T>``! ``for``-Schleife mit ``Get(i)``, Nummer ``i + 1`` davor.
5. [ ] ``AllesEntladen<T>(Zug<T> zug, IVerlader<T> ziel)`` – solange ``Count > 0``: ``ziel.Verlade(zug.AbkuppelnVorne())``.
6. [ ] Test, Ausgabe vergleichen.
7. [ ] **Experimente:**
   - [ ] ``out`` bei ``IZugQuelle`` entfernen → Fehler bei ``Anzeigen(holzzug)``?
   - [ ] ``in`` bei ``IVerlader`` entfernen → Fehler bei ``AllesEntladen``?
   - [ ] ``Zug<Fracht> fracht = holzzug;`` einkommentieren → Fehlernummer?
8. [ ] Fragen 1–5 beantworten.

> **Merke:** Hund darf **heraus**, wo ein Tier erwartet wird (``out``). Wer **jedes** Tier nimmt, nimmt auch Hunde (``in``). Geht ``T`` in beide Richtungen → invariant.

---

## Abschluss

- [ ] Alle Teile laufen in **einem** ``Program.cs`` hintereinander.
- [ ] Alle Fragen sind als Kommentar beantwortet.
- [ ] Keine Warnungen beim Kompilieren (``null``-Warnungen ernst nehmen!).
- [ ] Mit der Lösung im Ordner ``Loesung`` vergleichen – **erst am Ende**.
