// Ein Hamster laeuft ueber die Wiese und frisst Seedlings. Er HAT eine Wiese (hat-Beziehung).
class Hamster
{
    // Felder: der Zustand
    public (int x, int y) position;
    public string darstellung;
    public int anzahlSchritte;
    public int anzahlGefressen;
    public Wiese wiese;               // hat-Beziehung: der Hamster kennt seine Wiese

    // Konstruktor: der Startzustand
    public Hamster((int x, int y) start, Wiese wiese, string darstellung = "🐹")
    {
        position = start;
        this.wiese = wiese;
        this.darstellung = darstellung;
    }

    // Methoden: das Verhalten
    public void Bewegen(string richtung)
    {
        (int x, int y) ziel = position;
        if (richtung == "N") { ziel.y--; }
        if (richtung == "S") { ziel.y++; }
        if (richtung == "O") { ziel.x++; }
        if (richtung == "W") { ziel.x--; }

        // Guard: ungewuenschter Zustand ❌ - die Wiese weiss, wo ihr Rand ist
        if (!wiese.IstInnerhalb(ziel))
        {
            Console.WriteLine($"{darstellung} stößt im {richtung} an den Rand und bleibt auf {position}");
            return;
        }

        // gewuenschter Zustand ✅
        position = ziel;
        anzahlSchritte++;
        Console.WriteLine($"{darstellung} Schritt {anzahlSchritte}: geht nach {richtung} -> {position}");
        Fressen();
    }

    public void Fressen()
    {
        Seedling seedling = wiese.SeedlingAuf(position);   // die Wiese fragen

        // Guard: hier steht nichts (mehr) zum Fressen ❌
        if (seedling == null)
        {
            return;
        }

        // gewuenschter Zustand ✅
        seedling.gefressen = true;
        anzahlGefressen++;
        Console.WriteLine($"{darstellung} frisst {seedling.darstellung} auf {position} - schon {anzahlGefressen} gefressen");
    }

    public string Beschreiben()
    {
        return $"{darstellung} auf {position}, {anzahlSchritte} Schritte, {anzahlGefressen} gefressen";
    }
}
