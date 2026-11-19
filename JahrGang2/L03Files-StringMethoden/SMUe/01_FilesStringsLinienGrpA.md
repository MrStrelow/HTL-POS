**Schriftliche Mitarbeitsüberprüfung - Files, Strings und Linien**
PoS - CAMM - 2CHIF - Gruppe A

**Name:** 
_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 
**Datum:** 
_ _ _ _ _ _ _ _ _ _ _ _ 

## Aufgabe 1 - **Konzepte**
1. ``text.Trim();`` steht alleine in einer Zeile – danach hat *text* immer noch Leerzeichen am Rand. Warum? Wie schreibt man es richtig?
$\\$
$\\$
$\\$
$\\$

1. Was ist ein *relativer* ``Pfad``? Warum schreiben wir ``"../../../daten.txt"``, wenn *daten.txt* neben *Program.cs* liegt?
$\\$
$\\$
$\\$
$\\$

## Aufgabe 2 - **Lückentext: Distanz und Linie**
Ergänze die Lücken. Die ``Funktion`` *ZeichneLinie* zeichnet die Linie zwischen ✅ und ❌ wie im Unterricht: Das Koordinatensystem wird in den Startpunkt **verschoben** – in x mit *xVerschoben*, in y mit *start.y*. Für jede Spalte *x* liefert die *mathematische* ``Funktion`` *f(x)* die Zeile, in der die Linie liegt.

```csharp
((int x, int y) start, (int x, int y) ziel) punkte = ((1, 1), (6, 3));
double distanz = BerechneDistanz(______________, ______________);
ZeichneLinie(punkte.start, punkte.ziel);

double BerechneDistanz((int x, int y) start, (int x, int y) ziel)
{
    int dx = ziel.x - start.x;
    int dy = ziel.y - start.y;
    return Math.______(__________________________);
}

void ZeichneLinie((int x, int y) start, (int x, int y) ziel)
{
    double k = (__________)(ziel.y - start.y) / (ziel.x - start.x);

    for (_____________________________________)
    {
        for (_____________________________________)
        {
            int xVerschoben = x - start.x;
            int fx = ______________________________________________;

            if (y == fx && start.x < x && x < ziel.x) { Console.Write("🔸"); }
            else if (________________________________) { Console.Write("✅"); }
            else if (x == ziel.x && y == ziel.y) { Console.Write("❌"); }
            else { Console.Write("⬜"); }
        }
        ____________________________;
    }
}
```

**Nebenfrage:** Mit *start = (1, 7)* und *ziel = (3, 0)* zeichnet derselbe Code dieses Bild. Warum sind ✅ und ❌ nicht verbunden? Was müsste man im Code ändern, damit die Linie durchgehend ist?
```
⬜⬜⬜❌⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜🔸⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬜⬜
⬜✅⬜⬜⬜⬜⬜⬜
```
$\\$
$\\$
$\\$

## Aufgabe 3 - **Fehler finden**
Der Code soll die Linie zwischen *punkte.start* und *punkte.ziel* **eine Zeile tiefer** zeichnen. Er enthält Compilerfehler und Logikfehler. Markiere jeden Fehler im Code, nummeriere ihn und schreibe darunter, **was passiert** und **wie es richtig wäre**.

```csharp
((int x, int y) start, (int x, int y) ziel) punkte = ((1, 1), (6, 3));
Verschiebe(punkte);                    // Linie um 1 nach unten schieben
Console.WriteLine(punkte.Start.x);
ZeichneLinie(punkte);

void Verschiebe(((int x, int y) start, (int x, int y) ziel) p)
{
    p.start.y++;
    p.ziel.y++;
}

void ZeichneLinie(((int x, int y) start, (int x, int y) ziel) p)
{
    double k = (p.ziel.y - p.start.y) / (p.ziel.x - p.start.x);

    for (int y = 0; y < 8; y++)
    {
        for (int x = 0; x < 8; x++)
        {
            int fx = p.start.y + (int)Math.Round(k * x);

            if (y == fx && p.start.x <= x && x < p.ziel.x) { Console.Write("🔸"); }
            else if (x == p.start.x && y == p.start.y) { Console.Write("✅"); }
            else if (x == p.ziel.x && y == p.ziel.y) { Console.Write("❌"); }
            else { Console.Write("⬜"); }
        }
        Console.WriteLine();
    }
}
```