**Zettelübung: Generics 🧬** (ca. 15 min)

**Name:** 
Musterlösung 
**Datum:** 
_ _ _ _ _ _ _ _ _ _ _ _ 

In allen Übungen gilt: ``class Tier { }``, ``class Hund : Tier { }``, ``class Katze : Tier { }``. *Hamster* setzt **kein** Interface um.

**Übung 1: Dynamische oder statische Polymorphie?**

| Aussage | dynamisch | statisch |
| :--- | :---: | :---: |
| Welche Methode läuft, entscheidet das echte Objekt zur Laufzeit. | ✘ | |
| ``Stapel<int>`` und ``Stapel<string>`` verwenden denselben Code. | | ✘ |
| Beruht auf der **ist-ein**-Beziehung und ``override``. | ✘ | |
| Ein falscher Typ ist ein **Compilerfehler**. | | ✘ |
| ``Form f = new Kreis(1); f.Flaeche();`` | ✘ | |
| Zwei Methoden heißen gleich, haben aber verschiedene Parameter (Überladen). | | ✘ |

Dynamisch = entschieden zur **Laufzeit** (Vererbung, ``override``). Statisch = entschieden beim **Kompilieren** (Generics, Überladen).

**Übung 2: Was ist T?**

| Aufruf | Typparameter | Rückgabetyp |
| :--- | :--- | :--- |
| ``Letztes(new int[] { 3, 7 })`` | ``T = int`` (erkannt) | ``int`` → ``7`` |
| ``Letztes<string>(new string[] { "a", "b" })`` | ``T = string`` | ``string`` → ``"b"`` |
| ``Drehe((true, "Ja"))`` | ``TA = bool``, ``TB = string`` | ``(string, bool)`` → ``("Ja", true)`` |
| ``Letztes<int>(new string[] { "x" })`` | ``T = int`` | ❌ Compilerfehler: ``string[]`` ist kein ``int[]`` |

**Übung 3: Einschränkungen – erlaubt oder Compilerfehler?**

| Code | ✔ | ✘ | Begründung |
| :--- | :---: | :---: | :--- |
| ``Kiste<int> k;`` | ✔ | | ``int`` ist ein Werttyp. |
| ``Kiste<string> k;`` | | ✘ | ``string`` ist ein Referenztyp, verlangt ist ``struct``. |
| ``Zwinger<Hund> z;`` | ✔ | | Hund ist ein Tier und hat einen leeren Konstruktor. |
| ``Zwinger<int> z;`` | | ✘ | ``int`` ist kein ``Tier``. |
| ``Groesser(new Hamster(), new Hamster())`` | | ✘ | Hamster setzt ``IComparable<Hamster>`` nicht um. |

Ohne ``where`` kann ``T`` **jeder** Typ sein – auch einer ohne ``>`` (z. B. Hamster). Der Compiler erlaubt für ``T`` nur, was **jeder** Typ kann. Mit ``where T : IComparable<T>`` dürfen wir ``a.CompareTo(b)`` verwenden.

**Übung 4: Ko- und Kontravarianz**

| Code | ✔ | ✘ | Begründung |
| :--- | :---: | :---: | :--- |
| ``List<Tier> l = new List<Hund>();`` | | ✘ | ``List<T>`` ist **invariant** – sonst könnte man mit ``l.Add`` eine Katze in die Hundeliste legen. |
| ``IEnumerable<Tier> e = new List<Hund>();`` | ✔ | | **kovariant** (``out T``): Man kann nur lesen, und jeder gelesene Hund ist ein Tier. |
| ``IComparer<Hund> c = new NachAlter();`` | ✔ | | **kontravariant** (``in T``): Wer jedes Tier vergleichen kann, kann auch Hunde vergleichen. |
| ``IComparer<Tier> c = new NachName();`` | | ✘ | *NachName* kann nur Hunde vergleichen, man könnte ihm aber eine Katze geben. |
| ``interface IQuelle<out T> { void Lege(T x); }`` | | ✘ | Ein ``out``-T darf nur **heraus** (Rückgabe), nicht als Parameter hinein. |

``t[0] = new Katze();`` übersetzt, wirft aber zur **Laufzeit** eine ``ArrayTypeMismatchException``. Das Objekt ist in Wahrheit ein ``Hund[]``. Arrays sind kovariant, obwohl man in sie auch **schreiben** kann – der Fehler fällt darum erst zur Laufzeit auf.
