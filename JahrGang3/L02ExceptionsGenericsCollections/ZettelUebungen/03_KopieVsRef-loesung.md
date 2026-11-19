**Zettelübung: Kopie der Referenz vs. ref 🏹** (ca. 15 min)

**Name:** 
Musterlösung 
**Datum:** 
_ _ _ _ _ _ _ _ _ _ _ _ 

In allen Übungen gilt:
```csharp
string[] s1 = { "Hund" };    // Array A
string[] s2 = { "Katze" };   // Array B
```

**Übung 1: Ohne ref – Kopie der Referenz**

| nach | s1 → | s2 → | a → | b → | temp → |
| :--- | :---: | :---: | :---: | :---: | :---: |
| ① Aufruf | A | B | A | B | – |
| ② ``T temp = a;`` | A | B | A | B | A |
| ③ ``a = b;`` | A | B | **B** | B | A |
| ④ ``b = temp;`` | A | B | B | **A** | A |
| ⑤ Ende der Methode | A | B | – | – | – |

Pfeile **nach ③**:
```
  Hauptprogramm        Speicher             Tausche

  s1  ---------->   A: "Hund"   <---------  temp

  s2  ---------->   B: "Katze"  <---------  a
                                <---------  b
```
Ausgabe: ``Hund Katze``. Nur die Kopien ``a`` und ``b`` wurden umgehängt, ``s1`` und ``s2`` nie.

**Übung 2: Ohne ref – Inhalt ändern**

| nach | s1 → | a → | Inhalt Array A | Inhalt Array B | temp |
| :--- | :---: | :---: | :---: | :---: | :---: |
| ① Aufruf | A | A | "Hund" | "Katze" | – |
| ② ``T temp = a[0];`` | A | A | "Hund" | "Katze" | "Hund" |
| ③ ``a[0] = b[0];`` | A | A | **"Katze"** | "Katze" | "Hund" |
| ④ ``b[0] = temp;`` | A | A | "Katze" | **"Hund"** | "Hund" |

Ausgabe: ``Katze Hund`` → **Seiteneffekt**.
Kein Pfeil hat sich verändert. ``a[0] = …`` folgt dem Pfeil von ``a`` und ändert das **Array**. Das ist dasselbe Array, auf das ``s1`` zeigt.

**Übung 3: Mit ref – die Variable selbst**

| nach | s1 → | s2 → | a ist … | b ist … | temp → |
| :--- | :---: | :---: | :---: | :---: | :---: |
| ① Aufruf | A | B | s1 | s2 | – |
| ② ``T temp = a;`` | A | B | s1 | s2 | A |
| ③ ``a = b;`` | **B** | B | s1 | s2 | A |
| ④ ``b = temp;`` | B | **A** | s1 | s2 | A |
| ⑤ Ende der Methode | B | A | – | – | – |

Pfeile **nach ③**:
```
  Tausche        Hauptprogramm        Speicher

  ref a  ====>   s1  ------.          A: "Hund"     <-- temp
                            \
                             v
  ref b  ====>   s2  ------> B: "Katze"
```
(``====>`` heißt: ist ein zweiter Name für diese Variable.)
``a`` und ``b`` haben **keinen eigenen** Pfeil auf ein Array, sie **sind** ``s1`` und ``s2``. Deshalb hängt ``a = b`` die Variable ``s1`` um. Die Arrays bleiben unverändert.

**Übung 4: Seiteneffekt – ja oder nein?**

| Aufruf | ja | nein | Was ändert sich? Pfeil, Inhalt oder Zahl? |
| :--- | :---: | :---: | :--- |
| ``Tausche(x, y);`` | | ✘ | nur die Kopien der Zahlen in ``a``, ``b`` |
| ``Tausche(s1, s2);`` | | ✘ | nur die Pfeile der Kopien ``a``, ``b`` |
| ``TauscheInhalt(s1, s2);`` | ✘ | | der **Inhalt** der Arrays |
| ``TauscheRef(ref x, ref y);`` | ✘ | | die **Zahlen** in ``x``, ``y`` |
| ``TauscheRef(ref s1, ref s2);`` | ✘ | | die **Pfeile** von ``s1``, ``s2`` |

Eine Zuweisung ``a = …`` ändert immer nur **die Variable links vom ``=``**. Ohne ``ref`` ist das die Kopie, nie die Variable des Aufrufers.

Ein ``int`` speichert die Zahl direkt, es gibt **keinen Pfeil** und damit keinen Inhalt, den man über eine Kopie erreichen könnte. Ohne ``ref`` kann die Methode nur ihre eigene Kopie ändern.
