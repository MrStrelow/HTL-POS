**Zettelübung: Kopie der Referenz vs. ref 🏹** (ca. 15 min)
**Name:** _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 
**Datum:** _ _ _ _ _ _ _ _ _ _ _ _ 

In allen Übungen gilt:
```csharp
string[] s1 = { "Hund" };    // Array A
string[] s2 = { "Katze" };   // Array B
```
Eine Variable mit einem Array speichert nur einen **Pfeil** (Referenz) auf das Array. Schreibe in die Tabellen, worauf jede Variable **nach** der Zeile zeigt: ``A``, ``B``, ``s1``, ``s2`` oder ``–`` (gibt es nicht mehr).

**Übung 1: Ohne ref – Kopie der Referenz**

```csharp
void Tausche<T>(T a, T b)
{
    T temp = a;    // ②
    a = b;         // ③
    b = temp;      // ④
}                  // ⑤
Tausche(s1, s2);   // ①
```

| nach | s1 → | s2 → | a → | b → | temp → |
| :--- | :---: | :---: | :---: | :---: | :---: |
| ① Aufruf | | | | | |
| ② ``T temp = a;`` | | | | | |
| ③ ``a = b;`` | | | | | |
| ④ ``b = temp;`` | | | | | |
| ⑤ Ende der Methode | | | | | |

Zeichne die Pfeile **nach ③** ein:
```
  Hauptprogramm          Speicher                Tausche
  +-----------+        +-----------+          +-----------+
  |  s1       |        | A: "Hund" |          |  a        |
  +-----------+        +-----------+          +-----------+

  +-----------+        +-----------+          +-----------+
  |  s2       |        | B: "Katze"|          |  b        |
  +-----------+        +-----------+          +-----------+
                                              +-----------+
                                              |  temp     |
                                              +-----------+
```
Was gibt ``Console.WriteLine(s1[0] + " " + s2[0]);`` danach aus? _ _ _ _ _ _ _ _ _ _ _ _

**Übung 2: Ohne ref – Inhalt ändern**

```csharp
void TauscheInhalt<T>(T[] a, T[] b)
{
    T temp = a[0];   // ②
    a[0] = b[0];     // ③
    b[0] = temp;     // ④
}
TauscheInhalt(s1, s2);   // ①
```

| nach | s1 → | a → | Inhalt Array A | Inhalt Array B | temp |
| :--- | :---: | :---: | :---: | :---: | :---: |
| ① Aufruf | | | | | |
| ② ``T temp = a[0];`` | | | | | |
| ③ ``a[0] = b[0];`` | | | | | |
| ④ ``b[0] = temp;`` | | | | | |

Was gibt ``Console.WriteLine(s1[0] + " " + s2[0]);`` danach aus? _ _ _ _ _ _ _ _ _ _ _ _
Hat sich in Übung 2 ein **Pfeil** verändert? _ _ _ _ _ _ _ _ _ _ _ _

**Übung 3: Mit ref – die Variable selbst**

```csharp
void TauscheRef<T>(ref T a, ref T b)
{
    T temp = a;    // ②
    a = b;         // ③
    b = temp;      // ④
}                  // ⑤
TauscheRef(ref s1, ref s2);   // ①
```

| nach | s1 → | s2 → | a ist … | b ist … | temp → |
| :--- | :---: | :---: | :---: | :---: | :---: |
| ① Aufruf | | | | | |
| ② ``T temp = a;`` | | | | | |
| ③ ``a = b;`` | | | | | |
| ④ ``b = temp;`` | | | | | |
| ⑤ Ende der Methode | | | | | |

Zeichne die Pfeile **nach ③** ein:
```
  Tausche              Hauptprogramm          Speicher
  +-----------+        +-----------+        +-----------+
  |  ref a    |        |  s1       |        | A: "Hund" |
  +-----------+        +-----------+        +-----------+

  +-----------+        +-----------+        +-----------+
  |  ref b    |        |  s2       |        | B: "Katze"|
  +-----------+        +-----------+        +-----------+
```

**Übung 4: Seiteneffekt – ja oder nein?**

``int x = 1, y = 2;`` Kreuze an, ob sich im Hauptprogramm etwas ändert.

| Aufruf | ja | nein | Was ändert sich? Pfeil, Inhalt oder Zahl? |
| :--- | :---: | :---: | :--- |
| ``Tausche(x, y);`` | | | |
| ``Tausche(s1, s2);`` | | | |
| ``TauscheInhalt(s1, s2);`` | | | |
| ``TauscheRef(ref x, ref y);`` | | | |
| ``TauscheRef(ref s1, ref s2);`` | | | |

Vervollständige: Eine Zuweisung ``a = …`` ändert immer nur _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _.
$\\$
Warum kann ``Tausche`` **ohne** ``ref`` bei einem ``int`` nie einen Seiteneffekt haben?
$\\$
$\\$
