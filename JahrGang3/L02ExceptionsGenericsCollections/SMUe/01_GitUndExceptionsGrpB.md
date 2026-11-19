<style>
html body { font-size: 13px !important; line-height: 1.45 !important; }
html body pre, html body pre code { font-size: 11px !important; line-height: 1.35 !important; padding: .6em .8em !important; }
html body h2 { font-size: 1.3em !important; margin: 14px 0 6px !important; padding-bottom: 2px !important; }
html body p, html body ol, html body pre { margin-top: 4px !important; margin-bottom: 8px !important; }
</style>

**Schriftliche Mitarbeitsüberprüfung - Git und Exceptions**
PoS - CAMM - 3CHIF - Gruppe B

**Name:** 
_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 
**Datum:** 
_ _ _ _ _ _ _ _ _ _ _ _ 

## Aufgabe 1 - **Konzepte**
1. Was ist ein ``Commit``, wie hängen ``Commits`` zusammen und worauf zeigt ``HEAD``? Was gehört in **einen** ``Commit``?
$\\$
$\\$
$\\$

1. Warum steht der speziellste ``catch`` ganz oben? Ist es gut mit ``catch(Exception e){...}`` immer die allgemeinste Exception zu fangen?
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
Ticketautomat automat = new Ticketautomat();
automat.Verkaufe(80);
Console.WriteLine($"Verkauft: {automat.Verkauft}, frei: {automat.FreiePlaetze}");
class Ticketautomat
{
    public int FreiePlaetze { get; private set; } = 50;
    public int Verkauft { get; private set; }
    public void Verkaufe(int anzahl)
    {
        Verkauft += anzahl;
        if (anzahl <= 0 || anzahl > FreiePlaetze) { Console.WriteLine("Fehler!"); return; }
        FreiePlaetze -= anzahl;
    }
}
```