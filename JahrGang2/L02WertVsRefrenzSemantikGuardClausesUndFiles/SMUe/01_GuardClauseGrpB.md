**Schriftliche Mitarbeitsüberprüfung - Funktionen und Guard Clause**
PoS - CAMM - 2CHIF - Gruppe B

**Name:** 
_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 
**Datum:** 
05.10.2026

## Aufgabe 1 - **Konzepte**
1. Warum verwenden wir  ``Funktionen``?  Was ist der Unterschied zu ``Operatoren``?
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

2. Warum kann eine ``verchachtelte Verzweigung`` unübersichtlich werden? Welches Konzept könnte dieses Problem beheben?
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

## Aufgabe 2 - **logisches UND**
* Stelle ein ``logisches ODER`` mit einer ``Kontrollstruktur`` dar. 
Verwende folgene ``logische Formel`` *A || B*
* Kreise das *Console.WriteLine* ein welches mit der ``Belegung`` von *A* und *B* erreicht wird.

```csharp
bool A = false;  // die Belegung für A ist false
bool B = true;   // die Belegung für B ist true

______ (______)
{
    Console.WriteLine(______);
    ____________;
}

______ (______)
{
    Console.WriteLine(______);
    ____________;
}

Console.WriteLine(______);
```
---

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

## Aufgabe 3 - **Guard Clause**
Schreibe diesen Code in eine `Guard Clause` um.

```csharp
if (18 <= age && age < 35 || x % 25 == 3)
{
    if (registrationDate <= currentMonth)
    {
        Console.WriteLine("✅ User is processed.");
    }
    else
    {
        Console.WriteLine("❌ Registration is not valid.");
    }
}
else
{
    Console.WriteLine("❌ User is not valid.");
}
```

Schreibe deine Guard Clauses hier:

```csharp
// Ungewünschte Zustände ❌








// gewünschter Zustand ✅


```