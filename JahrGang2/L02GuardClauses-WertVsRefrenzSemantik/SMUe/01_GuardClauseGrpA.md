**Schriftliche Mitarbeitsüberprüfung - Funktionen und Guard Clause**
PoS - CAMM - 2CHIF - Gruppe A

**Name:** 
_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 
**Datum:** 
05.10.2026

## Aufgabe 1 - **Konzepte**
1. Was ist der Unterschied zwischen der ``Deklaration`` und ``Definition`` einer ``Funktion``? Was ist der ``Aufruf`` einer ``Funktion`` und wie schreiben wir diesen?
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

2. Warum kann eine ``Guard Clause`` übersichtlicher sein als eine ``verchachtelte Verzweigung``?
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
* Stelle ein ``logisches UND`` mit einer ``Kontrollstruktur`` dar. 
Verwende folgene ``logische Formel`` *A && B*
* Kreise das *Console.WriteLine* ein welches mit der ``Belegung`` von *A* und *B* erreicht wird.

```csharp
bool A = true;    // die Belegung für A ist true
bool B = false;   // die Belegung für B ist false

______ (______)
{
    ______ (______)
    {
        Console.WriteLine(______);
    }
    ______
    {
        Console.WriteLine(______);
    }
}
______
{
    Console.WriteLine(______);
}
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
## Aufgabe 3 - **Guard Clause**
Schreibe diesen Code in eine `Guard Clause` um.

```csharp
if (35 <= age && age < 65 || x % 252 == 8)
{
    if (isRegistered)
    {
        Console.WriteLine("✅ User is processed.");
    }
    else
    {
        Console.WriteLine("❌ User is not registered.");
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