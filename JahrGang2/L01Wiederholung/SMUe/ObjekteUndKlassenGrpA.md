**Schriftliche Mitarbeitsüberprüfung - Kontrollstrukturen und logische Formeln**
PoS - CAMM - 2CHIF - Gruppe A

**Name:** 
_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 
**Datum:** 
24.09.2026

## Aufgabe 1 - **Konzepte**
1. Was ist der Unterschied zwischen ``logischen Operatoren`` und ``Vergleichsoperatoren``?.
$\\$
$\\$
$\\$
$\\$
$\\$
$\\$
$\\$
$\\$
$\\$
$\\$
$\\$
$\\$

1. Was ist der *konzeptionelle* Unterschied zwischen ``Zählschleifen`` und ``While-Schleifen``?
$\\$
$\\$
$\\$
$\\$
$\\$
$\\$
$\\$
$\\$
$\\$
$\\$
$\\$
$\\$

---

## Aufgabe 2 - **Logische Formeln**
Versuche die logische Formel für folgendes Muster zu finden.
>*Hinweis:* Beginne mit *istHamsterFeld* und verwende diese in den anderen logischen Formeln.
```
             x
    🟦0️⃣1️⃣2️⃣3️⃣4️⃣5️⃣
    0️⃣⬜⬛⬜⬛⬜⬛
    1️⃣⬛⬜⬛⬜⬛⬜
  y 2️⃣⬜⬛⬜⬛⬜⬛
    3️⃣⬛⬜⬛⬜⬛⬜
    4️⃣⬜⬛⬜🐹⬜⬛
    5️⃣⬛⬜⬛⬜⬛⬜
```

```csharp
bool istHamsterFeld     = ________________________________________________;
bool istWeissesFeld     = ________________________________________________;
bool istSchwarzesFeld   = ________________________________________________;
```

## Aufgabe 3 -  **Block und Scope**
Sind wir mit diesem Code im Bezug auf ``in-scoppe`` und ``out-of-scope`` zufrieden? 
1. Wenn ***ja*** begründe warum,
2. Wenn ***nein*** schreibe diesen um?

```csharp
bool isWhiteSymbol = ...; // hier steht die richtige Formel.
if (isWhiteSymbol) 
{
    string whiteSymbol = "⬜";
    Console.Write(whiteSymbol);
} 
else 
{
    string blackSymbol = "⬛";
    Console.Write(blackSymbol);
}
Console.Write("Meine Symbole sind " + whiteSymbol + " und " + blackSymbol);
```

