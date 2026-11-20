// Ein Hamster laeuft ueber die Wiese und frisst den Seedling. Er HAT eine Wiese (hat-Beziehung).
class Hamster
{
    // Felder: der Zustand
    public (int x, int y) position;
    public string darstellung;
    public int anzahlSchritte;
    public Wiese wiese;               // hat-Beziehung: der Hamster kennt seine Wiese

    // Konstruktor: der Startzustand
    public Hamster((int x, int y) start, Wiese wiese, string darstellung)
    {
        position = start;
        this.wiese = wiese;
        this.darstellung = darstellung;
    }

    // Methoden: das Verhalten
    public string Beschreiben()
    {
        return $"{darstellung} auf {position}, {anzahlSchritte} Schritte";
    }

    public void Bewegen(string richtung)
    {
        (int x, int y) ziel = position;
        if (richtung == "N") { ziel.y--; }
        if (richtung == "S") { ziel.y++; }
        if (richtung == "O") { ziel.x++; }
        if (richtung == "W") { ziel.x--; }

        // Guard: die Wiese weiss, wo ihr Rand ist ❌
        if (!wiese.IstInnerhalb(ziel))
        {
            Console.WriteLine($"{darstellung} stößt an den Rand");
            return;
        }

        // gewuenschter Zustand ✅
        position = ziel;
        anzahlSchritte++;
        Console.WriteLine($"{darstellung} geht nach {richtung} -> {position}");
        Fressen();
    }

    public void Fressen()
    {
        Seedling seedling = wiese.seedling;   // ueber die Wiese zum Seedling

        // Guard: schon gefressen oder nicht hier ❌
        if (seedling.gefressen || seedling.position != position)
        {
            return;
        }

        // gewuenschter Zustand ✅
        seedling.gefressen = true;
        Console.WriteLine($"{darstellung} frisst {seedling.darstellung}");
    }
}
