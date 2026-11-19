<style>
html body { font-size: 13px !important; line-height: 1.45 !important; }
html body pre, html body pre code { font-size: 11px !important; line-height: 1.35 !important; padding: .6em .8em !important; }
html body h2 { font-size: 1.3em !important; margin: 14px 0 6px !important; padding-bottom: 2px !important; }
html body p, html body ol, html body pre { margin-top: 4px !important; margin-bottom: 8px !important; }
</style>

**Schriftliche Mitarbeitsüberprüfung - Git und Exceptions**
PoS - CAMM - 3CHIF - Gruppe A

**Name:** 
_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 
**Datum:** 
_ _ _ _ _ _ _ _ _ _ _ _ 

## Aufgabe 1 - **Konzepte**
1. Beschreibe den Weg einer Änderung vom ``Working Directory`` bis ins ``Remote Repository``. Nenne bei jedem Schritt den passenden ``git``-Befehl.
$\\$
$\\$
$\\$

1. Wann verwenden wir eine ``Exception`` und wann eine ``Kontrollstruktur`` mit ``Rückgabewert``? Nenne zu beidem ein Beispiel.
$\\$
$\\$
$\\$

## Aufgabe 2 - **Lückentext: Git und Exceptions**
Ergänze die Lücken: Repository klonen, Projekt anlegen, *Konto* schreiben, hochladen – und später eine kaputte, schon gestagte *Konto.cs* auf den letzten ``Commit`` zurücksetzen.

```
> git ________ https://gitlab.if.htl-donaustadt.at/website/bank.git
> cd bank
... // erstelle eine C# Solution+Projekt im Terminal oder mit der GUI
> git ________________
> git commit -m "________ Abheben mit Exceptions"
> git ________
```

```csharp
Konto konto = new Konto(100);
Console.Write("Betrag: ");
if (!decimal.____________(Console.ReadLine(), out decimal betrag))
{
    Console.WriteLine("Keine Zahl.");
    return;
}

try { konto.Abheben(betrag); }
catch (________________________________ ex) { Console.WriteLine($"Ungültiger Betrag: {ex.Message}"); }
catch (________________________________ ex) { Console.WriteLine($"Nicht möglich: {ex.Message}"); }
__________ { Console.WriteLine($"Guthaben: {konto.Guthaben}"); }
class Konto
{
    public decimal Guthaben { get; private set; }
    public Konto(decimal guthaben) { Guthaben = guthaben; }
    public void Abheben(decimal betrag)
    {
        if (betrag <= 0) { ______ new ArgumentOutOfRangeException(nameof(betrag), "Muss positiv sein."); }
        if (______________________) { throw new InvalidOperationException("Zu wenig Guthaben."); }
        Guthaben -= betrag;
    }
}
```
$\\$

## Aufgabe 3 - **Code analysieren**
Analysiere den Code: Werden ``Exceptions`` hier richtig eingesetzt? Markiere die betroffene(n) Stelle(n) im Code, beschreibe **was passiert** und **wie es richtig wäre**.

```csharp
Spielfigur figur = new Spielfigur();
while (true)
{
    string? taste = Console.ReadLine();
    try
    {
        if (taste == "d") { figur.NachRechts(); }
        else if (taste == "a") { figur.NachLinks(); }
    }
    catch (ArgumentOutOfRangeException ex) { Console.WriteLine(ex.Message); }
}

class Spielfigur
{
    public int X { get; private set; }   // Spielfeld geht von 0 bis 9
    public void NachRechts()
    {
        if (X == 9) { throw new ArgumentOutOfRangeException(nameof(X), "Rand erreicht."); }
        X++;
    }
    public void NachLinks()
    {
        if (X == 0) { throw new ArgumentOutOfRangeException(nameof(X), "Rand erreicht."); }
        X--;
    }
}
```