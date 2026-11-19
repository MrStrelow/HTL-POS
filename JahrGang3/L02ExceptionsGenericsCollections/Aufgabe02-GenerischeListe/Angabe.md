# Aufgabe: Der generische Güterbahnhof
Programmierübung am PC · Arbeitszeit ca. 100 Minuten · Lösung im Ordner ``Loesung``

Ein Güterzug ist eine **Doubly Linked List**: Hinter der Lok 🚂 hängen Waggons, jeder kennt seinen Vorgänger (``Prev``) und seinen Nachfolger (``Next``). Bis jetzt kann unser Zug nur Tonnen als ``int`` transportieren. Ab heute soll er **alles** transportieren können – Post, Holz, Kohle – und der Compiler soll aufpassen, dass keine Kohle im Postzug landet.

Welche ``Konzepte`` üben wir hier?
- **Neu aus L02** (alle Kapitel des Skriptums):
  - dynamische vs. statische Polymorphie
  - generische ``Klassen`` mit einem und mit zwei Typparametern (``Waggon<T>``, ``Zug<T>``, ``Paar<TLinks, TRechts>``)
  - generische ``Methoden`` mit einem und mit zwei Typparametern in einer **nicht** generischen ``Klasse``
  - Einschränkungen mit ``where``: ``IComparable<T>``, Basisklasse, ``new()``, ``class``, ``struct``
  - Kopie der Referenz vs. ``ref``
  - Kovarianz (``out T``), Kontravarianz (``in T``) und warum ``Zug<T>`` invariant ist
- **Wiederholung aus L01:**
  - Doubly Linked List: ``Head``, ``Tail``, ``Next``, ``Prev``
  - Vererbung, ``abstract``, ``override``, Interfaces

Welche ``Denkweise`` üben wir hier?
- Welcher Typ im Code ist die **Ladung** (wird zu ``T``), und welcher hat nichts damit zu tun (Positionen und ``Count`` bleiben ``int``)?
- Was darf ich mit einem ``T`` machen, über das ich nichts weiß? Und was muss ich mit ``where`` versprechen, damit ich mehr darf?
- Fließt ``T`` nur **heraus**, nur **hinein** oder in **beide** Richtungen?

Hilfe: [Animation Generics](../Skripten/L02.2_Generics.html)

Im Ordner ``Vorlage`` liegt der Zug, so wie wir die Doubly Linked List in L01 programmiert haben: ``Waggon`` ist der Knoten, ``Zug`` die Liste. Kopiere die ``.cs``-Dateien in ein neues Projekt ``Gueterbahnhof``.

---

### Teil 1 - level: 🙂 - Waggon&lt;T&gt; und Zug&lt;T&gt; - ~15 min
1. Mache ``Waggon`` generisch: ``Waggon<T>``. Die ``Ladung`` hat den Typ ``T``, ``Next`` und ``Prev`` zeigen auf ``Waggon<T>``.
2. Mache ``Zug`` generisch: ``Zug<T>``. Gehe **jede** Methode durch und entscheide bei jedem ``int``: Ist das eine **Ladung** (→ ``T``) oder eine **Position** bzw. Anzahl (→ bleibt ``int``)?

| Methode vorher | Methode nachher |
|---|---|
| ``void AnhaengenHinten(int ladung)`` | ``void AnhaengenHinten(T ladung)`` |
| ``void Einreihen(int position, int ladung)`` | ? |
| ``int AbkuppelnVorne()`` | ? |
| ``int Get(int position)`` | ? |
| ``int Finde(int ladung)`` | ? |
| ``int Umladen(int position, int neueLadung)`` | ? |

In ``Finde`` meldet der Compiler einen Fehler bei ``curr.Ladung == ladung``. Der Operator ``==`` ist nicht für jeden Typ ``T`` definiert. Verwende ``Equals(curr.Ladung, ladung)`` – das kann **jedes** Objekt.

Teste im Hauptprogramm:
```csharp
Zug<int> tonnen = new Zug<int>();
tonnen.AnhaengenHinten(3);
tonnen.AnhaengenHinten(7);
tonnen.AnhaengenVorne(1);
Console.WriteLine(tonnen);

Zug<string> post = new Zug<string>();
post.AnhaengenHinten("Briefe");
post.AnhaengenHinten("Pakete");
post.Einreihen(1, "Zeitungen");
Console.WriteLine(post);
Console.WriteLine(post.Finde("Pakete"));
Console.WriteLine(post.Enthaelt("Kühe"));
// tonnen.AnhaengenHinten("acht");
```
Erwartete Ausgabe:
```
🚂-[1]-[3]-[7]
🚂-[Briefe]-[Zeitungen]-[Pakete]
2
False
```
**Fragen** (als Kommentar beantworten):
1. Warum ist ``Next`` vom Typ ``Waggon<T>?`` und nicht ``Waggon<int>?`` oder einfach ``Waggon?``
2. Entferne das ``//`` vor der letzten Zeile. Welchen Fehler meldet der Compiler? Kommentiere die Zeile danach wieder aus.
3. Man könnte die Ladung auch als ``object`` speichern – dann passt ebenfalls alles hinein. Wann würde ``"acht"`` in einem ``object``-Zug als Fehler auffallen? Welche Art von Polymorphie ist ``object`` (Vererbung), welche ist ``Zug<T>``, und **wann** steht jeweils der Typ fest?

---

### Teil 2 - level: 🙂 - Der Bahnhof: generische Methoden - ~15 min
Eine generische Methode braucht **keine** generische Klasse. Lege die ``static class Bahnhof`` an – sie selbst hat **keinen** Typparameter, aber jede ihrer Methoden hat einen eigenen.

Lege außerdem die generische Klasse ``Paar<TLinks, TRechts>`` mit **zwei** Typparametern an: zwei Eigenschaften ``Links`` und ``Rechts`` (nur lesen), ein Konstruktor und ``ToString`` im Format ``Links|Rechts``.

| Methode | Verhalten |
|---|---|
| ``Zug<T> AusArray<T>(T[] ladungen)`` | erstellt einen neuen Zug mit allen Ladungen in derselben Reihenfolge |
| ``Zug<T> Wenden<T>(Zug<T> zug)`` | erstellt einen neuen Zug in umgekehrter Reihenfolge. Gehe dazu **von ``Tail`` über ``Prev``** nach vorne. |
| ``Zug<Paar<TA, TB>> Kuppeln<TA, TB>(Zug<TA> a, Zug<TB> b)`` | geht beide Züge gleichzeitig durch und macht aus je zwei Ladungen ein ``Paar``. Ist ein Zug kürzer, endet das Ergebnis dort. |

Teste:
```csharp
Zug<char> gleise = Bahnhof.AusArray(new char[] { 'A', 'B', 'C' });
Console.WriteLine(gleise);
Console.WriteLine(Bahnhof.Wenden(post));
Zug<Paar<string, int>> gekuppelt = Bahnhof.Kuppeln(post, tonnen);
Console.WriteLine(gekuppelt);
```
Erwartete Ausgabe:
```
🚂-[A]-[B]-[C]
🚂-[Pakete]-[Zeitungen]-[Briefe]
🚂-[Briefe|1]-[Zeitungen|3]-[Pakete|7]
```
**Fragen:**
1. Beim Aufruf steht nirgends ``<char>`` oder ``<string>``. Woher weiß der Compiler, was ``T`` ist?
2. Warum hat ``Kuppeln`` **zwei** Typparameter und nicht nur einen?

---

### Teil 3 - level: 🤔 - Einschränkungen mit where - ~25 min
Ohne Einschränkung darf ``T`` **jeder** Typ sein – darum darfst du mit ``T`` nur das machen, was **jeder** Typ kann. Jede der folgenden Methoden braucht eine andere Einschränkung. Finde sie selbst heraus: Schreibe die Methode zuerst **ohne** ``where``, lies den Compilerfehler und ergänze dann die passende Einschränkung.

1. Lege die **abstrakte** Klasse ``Fracht`` an:
   - ``int Tonnen`` (nur innerhalb der Klasse setzbar), ein ``protected`` Konstruktor mit den Tonnen
   - ``abstract string Symbol { get; }``
   - ``void Nachladen(int tonnen)`` erhöht die Tonnen
   - ``Fracht`` setzt ``IComparable<Fracht>`` um und vergleicht nach den **Tonnen**
   - ``ToString`` liefert z. B. ``🪵 10 t``
2. Lege ``Holz : Fracht`` (Symbol 🪵) und ``Kohle : Fracht`` (Symbol 🪨) an – jeweils mit einem Konstruktor mit Tonnen **und** einem leeren Konstruktor (0 Tonnen).
3. Ergänze in ``Bahnhof``:

| Methode | Verhalten | Tipp |
|---|---|---|
| ``T Groesste<T>(Zug<T> zug)`` | größte Ladung, bei leerem Zug ``InvalidOperationException`` | ``>`` geht nicht, ``CompareTo`` schon |
| ``int Gesamtgewicht<T>(Zug<T> zug)`` | Summe aller ``Tonnen`` | woher weiß der Compiler, dass ``T`` ``Tonnen`` hat? |
| ``Zug<T> Leerzug<T>(int anzahl)`` | Zug mit ``anzahl`` Waggons, jeder mit ``new T()`` | |
| ``T? ErsteOderNull<T>(Zug<T> zug)`` | erste Ladung oder ``null``, wenn der Zug leer ist | nur für Referenztypen |
| ``T? ErsterWertOderNull<T>(Zug<T> zug)`` | erste Ladung oder ``null``, wenn der Zug leer ist | nur für Werttypen, ``T?`` ist ``Nullable<T>`` |

Teste:
```csharp
Console.WriteLine(Bahnhof.Groesste(tonnen));
Console.WriteLine(Bahnhof.Groesste(post));

Zug<Holz> holzzug = Bahnhof.AusArray(new Holz[] { new Holz(10), new Holz(25), new Holz(5) });
Console.WriteLine(holzzug);
Console.WriteLine(Bahnhof.Gesamtgewicht(holzzug) + " t");
Console.WriteLine(Bahnhof.Groesste(holzzug));

Console.WriteLine(Bahnhof.Leerzug<Kohle>(3));
Console.WriteLine(Bahnhof.Leerzug<int>(2));

Zug<string> leer = new Zug<string>();
Console.WriteLine(Bahnhof.ErsteOderNull(post));
Console.WriteLine(Bahnhof.ErsteOderNull(leer) ?? "kein Waggon");
Console.WriteLine(Bahnhof.ErsterWertOderNull(tonnen));
Console.WriteLine(Bahnhof.ErsterWertOderNull(new Zug<int>()) == null);
// Bahnhof.Gesamtgewicht(tonnen);
// Bahnhof.ErsteOderNull(tonnen);
// Bahnhof.ErsterWertOderNull(post);
```
Erwartete Ausgabe:
```
7
Zeitungen
🚂-[🪵 10 t]-[🪵 25 t]-[🪵 5 t]
40 t
🪵 25 t
🚂-[🪨 0 t]-[🪨 0 t]-[🪨 0 t]
🚂-[0]-[0]
Briefe
kein Waggon
1
True
```
**Fragen:**
1. Nimm nacheinander das ``//`` vor den letzten drei Zeilen weg. Welche Einschränkung verletzt jede Zeile? Schreibe die Fehlernummer dazu.
2. ``ToString`` von ``Holz`` ruft ``Symbol`` auf. Wird zur Laufzeit oder beim Kompilieren entschieden, welches ``Symbol`` verwendet wird? Und bei ``Groesste<T>``: Wann steht fest, was ``T`` ist?
3. Warum klappt ``Leerzug<int>`` – ``int`` hat doch gar keinen Konstruktor, den wir geschrieben haben?
4. Warum braucht ``ErsteOderNull`` die Einschränkung ``class``? Was wäre ``null`` für einen ``Zug<int>``?

---

### Teil 4 - level: 🤔 - Sortierzug&lt;T&gt;: Klasse mit Einschränkung - ~15 min
Schreibe die generische Klasse ``Sortierzug<T>``. Sie **hat** einen ``Zug<T>`` (private) und hält die Ladungen immer aufsteigend sortiert. Weil die **ganze** Klasse vergleichen muss, steht das ``where`` diesmal **bei der Klasse**.

| Mitglied | Verhalten |
|---|---|
| ``int Count`` | Anzahl der Waggons (nur lesen) |
| ``void Einreihen(T ladung)`` | sucht von ``Head`` aus die **erste** Position, an der eine größere Ladung steht, und reiht dort mit ``Einreihen`` des Zuges ein. Gleiche Ladungen kommen **hinter** die vorhandenen. |
| ``T Kleinste()`` / ``T Groesste()`` | erste bzw. letzte Ladung |
| ``string ToString()`` (override) | wie beim Zug |

Teste:
```csharp
Sortierzug<int> sortiert = new Sortierzug<int>();
foreach (int t in new int[] { 5, 1, 4, 1 })
{
    sortiert.Einreihen(t);
}
Console.WriteLine(sortiert);
Console.WriteLine(sortiert.Groesste());

Sortierzug<Fracht> nachGewicht = new Sortierzug<Fracht>();
nachGewicht.Einreihen(new Kohle(30));
nachGewicht.Einreihen(new Holz(10));
nachGewicht.Einreihen(new Kohle(20));
Console.WriteLine(nachGewicht);
Console.WriteLine(nachGewicht.Kleinste());
```
Erwartete Ausgabe:
```
🚂-[1]-[1]-[4]-[5]
5
🚂-[🪵 10 t]-[🪨 20 t]-[🪨 30 t]
🪵 10 t
```
**Fragen:**
1. Warum ist ``Sortierzug<Paar<string, int>>`` ein Compilerfehler, ``Zug<Paar<string, int>>`` aber nicht?
2. In ``nachGewicht`` stehen Holz und Kohle gemischt. Warum geht das bei ``Sortierzug<Fracht>``? Was passiert, wenn du in einen ``Sortierzug<Holz>`` eine ``Kohle`` einreihen willst?

---

### Teil 5 - level: 🤔 - Kopie der Referenz vs. ref - ~10 min
1. Ergänze in ``Bahnhof`` die Methode ``void Tauschen<T>(ref T a, ref T b)``, die die Inhalte der beiden **Variablen** vertauscht.
2. **Überlege zuerst** auf Papier, was ausgegeben wird. Prüfe danach mit dem Programm.

```csharp
Holz stamm = new Holz(8);
Zug<Holz> a = new Zug<Holz>();
a.AnhaengenHinten(stamm);
stamm.Nachladen(4);
Console.WriteLine(a);

Zug<Holz> b = Bahnhof.AusArray(new Holz[] { new Holz(1), new Holz(2) });
Zug<Holz> c = a;
Bahnhof.Tauschen(ref a, ref b);
Console.WriteLine("a = " + a);
Console.WriteLine("b = " + b);
Console.WriteLine("c = " + c);

int links = 1;
int rechts = 2;
Bahnhof.Tauschen(ref links, ref rechts);
Console.WriteLine(links + " " + rechts);
```
Erwartete Ausgabe:
```
🚂-[🪵 12 t]
a = 🚂-[🪵 1 t]-[🪵 2 t]
b = 🚂-[🪵 12 t]
c = 🚂-[🪵 12 t]
2 1
```
**Fragen:**
1. Warum zeigt der Waggon 12 t, obwohl wir ``Nachladen`` erst **nach** ``AnhaengenHinten`` aufgerufen haben?
2. ``a`` und ``b`` wurden getauscht, ``c`` aber nicht. Warum?
3. ``Holz`` ist ein Referenztyp. Warum braucht ``Tauschen`` trotzdem ``ref``? Was würde ohne ``ref`` passieren?
4. Warum funktioniert ``Tauschen`` auch mit ``int`` – obwohl dort **keine** Einschränkung ``where T : class`` steht?

---

### Teil 6 - level: 💀 - Ko- und Kontravarianz - ~20 min
Wir wollen **eine** Methode, die **jeden** Frachtzug anzeigt – egal ob ``Zug<Holz>`` oder ``Zug<Kohle>``. Und wir wollen **ein** Lager, das **jede** Fracht annimmt.

1. Lege das Interface ``IZugQuelle<out T>`` mit ``int Count { get; }`` und ``T Get(int position)`` an. ``Zug<T>`` setzt es um (die Mitglieder gibt es schon).
2. Lege das Interface ``IVerlader<in T>`` mit ``void Verlade(T ladung)`` an.
3. Lege die Klasse ``Lager : IVerlader<Fracht>`` an. Sie zählt die ``Anzahl`` der Frachtstücke und die ``Tonnen`` (beide nur lesen). ``ToString`` liefert z. B. ``Lager: 3 Frachtstücke, 40 t``.
4. Ergänze in ``Bahnhof``:

| Methode | Verhalten |
|---|---|
| ``void Anzeigen(IZugQuelle<Fracht> zug)`` | **kein** Typparameter! Gibt alle Ladungen nummeriert aus. |
| ``void AllesEntladen<T>(Zug<T> zug, IVerlader<T> ziel)`` | kuppelt so lange vorne ab, bis der Zug leer ist, und übergibt jede Ladung an ``ziel`` |

Teste:
```csharp
Bahnhof.Anzeigen(holzzug);
// Zug<Fracht> fracht = holzzug;

Lager lager = new Lager();
Bahnhof.AllesEntladen(holzzug, lager);
Console.WriteLine(lager);
Console.WriteLine(holzzug);
```
Erwartete Ausgabe:
```
1. 🪵 10 t
2. 🪵 25 t
3. 🪵 5 t
Lager: 3 Frachtstücke, 40 t
🚂
```
**Fragen:**
1. ``Anzeigen`` erwartet ``IZugQuelle<Fracht>``, bekommt aber einen ``Zug<Holz>``. Warum ist das sicher? Was passiert, wenn du das ``out`` im Interface weglässt?
2. ``AllesEntladen`` mit ``T = Holz`` erwartet einen ``IVerlader<Holz>``, bekommt aber ein ``Lager`` (``IVerlader<Fracht>``). Warum ist das sicher? In welche Richtung geht hier die Umwandlung?
3. Warum ist ``Zug<Fracht> fracht = holzzug;`` trotzdem ein Compilerfehler? Erkläre es mit einem Beispiel: Was könnte man über ``fracht`` mit ``AnhaengenHinten`` in den **Holz**zug hängen?
4. Könnte man ``IZugQuelle<out T>`` um ``void AnhaengenHinten(T ladung)`` erweitern? Begründe.
5. In Teil 3 hat ``Groesste(holzzug)`` mit ``T = Holz`` funktioniert, obwohl ``Holz`` nur ``IComparable<Fracht>`` umsetzt und nicht ``IComparable<Holz>``. Warum? (Tipp: ``IComparable<in T>``)
