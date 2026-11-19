**Schriftliche Mitarbeitsüberprüfung - Files, Strings und Linien**
PoS - CAMM - 2CHIF - Gruppe B

**Name:** 
_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 
**Datum:** 
_ _ _ _ _ _ _ _ _ _ _ _ 

## Aufgabe 1 - **Konzepte**
1. Wann verwenden wir eine ``foreach-Schleife`` und wann eine ``for-Schleife``?
$\\$
$\\$
$\\$
$\\$

1. Was liefert ``File.ReadAllLines(pfad)`` zurück? Warum müssen wir danach Leerzeilen und Kommentarzeilen selbst überspringen?
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
Der Code soll die Linie von *punkte.start* (rechts unten) nach *punkte.ziel* (links oben) zeichnen. Er enthält Compilerfehler und Logikfehler. Markiere jeden Fehler im Code, nummeriere ihn und schreibe darunter, **was passiert** und **wie es richtig wäre**.

```csharp
((int x, int y) start, (int x, int y) ziel) punkte = ((6, 4), (1, 1));
Console.WriteLine($"Start bei x = {start.x}");
ZeichneLinie(punkte.start, punkte.ziel);

void ZeichneLinie((int x, int y) start, (int x, int y) ziel)
{
    double k = (double)((ziel.y - start.y) / (ziel.x - start.x));

    for (int y = 0; y < 8; y++)
    {
        for (int x = 0; x < 8; x++)
        {
            int xVerschoben = start.x - x;
            int fx = start.y + Math.Round(k * xVerschoben);

            if (y == fx && start.x < x && x < ziel.x) { Console.Write("🔸"); }
            else if (x == start.x && y == start.y) { Console.Write("✅"); }
            else if (x == ziel.x && y == ziel.y) { Console.Write("❌"); }
            else { Console.Write("⬜"); }
        }
        Console.WriteLine();
    }
}
```
$\\$
$\\$
$\\$
$\\$
$\\$
