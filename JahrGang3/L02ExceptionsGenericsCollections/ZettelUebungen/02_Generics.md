**Zettelübung: Generics 🧬** (ca. 15 min)
**Name:** _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 
**Datum:** _ _ _ _ _ _ _ _ _ _ _ _ 

In allen Übungen gilt: ``class Tier { }``, ``class Hund : Tier { }``, ``class Katze : Tier { }``. *Hamster* setzt **kein** Interface um.

**Übung 1: Dynamische oder statische Polymorphie?**

Kreuze an.

| Aussage | dynamisch | statisch |
| :--- | :---: | :---: |
| Welche Methode läuft, entscheidet das echte Objekt zur Laufzeit. | | |
| ``Stapel<int>`` und ``Stapel<string>`` verwenden denselben Code. | | |
| Beruht auf der **ist-ein**-Beziehung und ``override``. | | |
| Ein falscher Typ ist ein **Compilerfehler**. | | |
| ``Form f = new Kreis(1); f.Flaeche();`` | | |
| Zwei Methoden heißen gleich, haben aber verschiedene Parameter (Überladen). | | |

**Übung 2: Was ist T?**

```csharp
T Letztes<T>(T[] werte) { return werte[werte.Length - 1]; }
(TB, TA) Drehe<TA, TB>((TA a, TB b) paar) { return (paar.b, paar.a); }
```

| Aufruf | Typparameter | Rückgabetyp |
| :--- | :--- | :--- |
| ``Letztes(new int[] { 3, 7 })`` | | |
| ``Letztes<string>(new string[] { "a", "b" })`` | | |
| ``Drehe((true, "Ja"))`` | | |
| ``Letztes<int>(new string[] { "x" })`` | | |

**Übung 3: Einschränkungen – erlaubt oder Compilerfehler?**

```csharp
class Kiste<T> where T : struct { }
class Zwinger<T> where T : Tier, new() { }
T Groesser<T>(T a, T b) where T : IComparable<T> { ... }
```

| Code | ✔ | ✘ | Begründung |
| :--- | :---: | :---: | :--- |
| ``Kiste<int> k;`` | | | |
| ``Kiste<string> k;`` | | | |
| ``Zwinger<Hund> z;`` | | | |
| ``Zwinger<int> z;`` | | | |
| ``Groesser(new Hamster(), new Hamster())`` | | | |

Warum ist ``if (a > b)`` in ``Groesser`` **ohne** ``where`` ein Compilerfehler?
$\\$
$\\$

**Übung 4: Ko- und Kontravarianz**

*NachAlter* setzt ``IComparer<Tier>`` um, *NachName* setzt ``IComparer<Hund>`` um.

| Code | ✔ | ✘ | Begründung |
| :--- | :---: | :---: | :--- |
| ``List<Tier> l = new List<Hund>();`` | | | |
| ``IEnumerable<Tier> e = new List<Hund>();`` | | | |
| ``IComparer<Hund> c = new NachAlter();`` | | | |
| ``IComparer<Tier> c = new NachName();`` | | | |
| ``interface IQuelle<out T> { void Lege(T x); }`` | | | |

``Tier[] t = new Hund[2];`` lässt sich übersetzen. Was passiert bei ``t[0] = new Katze();``? Warum?
$\\$
$\\$
