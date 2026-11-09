public class Kaffeeautomat
{
    private const int MaxBezuegeOhneEntkalken = 4;

    public Behaelter Wassertank { get; private set; }
    public Behaelter Bohnenbehaelter { get; private set; }
    public Behaelter Milchtank { get; private set; }

    public Getraenk[] Karte { get; private set; }

    public bool IstEingeschaltet { get; private set; }
    public int BezuegeSeitEntkalken { get; private set; }

    public Kaffeeautomat()
    {
        // 'this' -> jeder Behälter kennt genau DIESEN Automaten (bidirektional auf Objektebene)
        Wassertank = new Behaelter(this, "Wasser", "ml", 1000);
        Bohnenbehaelter = new Behaelter(this, "Bohnen", "g", 50);
        Milchtank = new Behaelter(this, "Milch", "ml", 300);

        // Collection Initializer + Object Initializer
        Karte = new Getraenk[]
        {
            new Getraenk { Name = "Espresso", WasserMl = 40, BohnenG = 9 },
            new Getraenk { Name = "Kaffee", WasserMl = 200, BohnenG = 12 },
            new Getraenk { Name = "Cappuccino", WasserMl = 60, BohnenG = 9, MilchMl = 150 },
            new Getraenk { Name = "Latte", WasserMl = 50, BohnenG = 9, MilchMl = 250 }
        };
    }

    public void Einschalten()
    {
        IstEingeschaltet = true;
        Console.WriteLine("🔌 Automat eingeschaltet.");
    }

    public void Entkalken()
    {
        // Guard: falscher Zustand des Objekts -> InvalidOperationException
        if (!IstEingeschaltet)
        {
            throw new InvalidOperationException("Entkalken geht nur, wenn der Automat eingeschaltet ist.");
        }

        BezuegeSeitEntkalken = 0;
        Console.WriteLine("🧽 Automat entkalkt.");
    }

    // Unbekannter Name ist ein falsches Argument -> ArgumentException
    public Getraenk SucheGetraenk(string name)
    {
        foreach (Getraenk getraenk in Karte)
        {
            if (getraenk.Name.ToLower() == name.ToLower())
            {
                return getraenk;
            }
        }

        throw new ArgumentException($"Unbekanntes Getränk: {name}", nameof(name));
    }

    public void Bruehe(string name)
    {
        if (!IstEingeschaltet)
        {
            throw new InvalidOperationException("Der Automat ist ausgeschaltet.");
        }

        if (BezuegeSeitEntkalken >= MaxBezuegeOhneEntkalken)
        {
            throw new EntkalkenNoetigException(BezuegeSeitEntkalken);
        }

        Getraenk getraenk = SucheGetraenk(name);

        // 1. ZUERST alles prüfen (Delegation an die Behälter) ...
        Wassertank.PruefeMenge(getraenk.WasserMl);
        Bohnenbehaelter.PruefeMenge(getraenk.BohnenG);
        Milchtank.PruefeMenge(getraenk.MilchMl);

        // 2. ... DANN entnehmen. So geht nie Wasser verloren, wenn danach die Milch fehlt.
        Wassertank.Entnehmen(getraenk.WasserMl);
        Bohnenbehaelter.Entnehmen(getraenk.BohnenG);
        Milchtank.Entnehmen(getraenk.MilchMl);

        BezuegeSeitEntkalken++;
        Console.WriteLine($"☕ {getraenk.Name} fertig.");
    }

    public string Status()
    {
        return $"{Wassertank} | {Bohnenbehaelter} | {Milchtank} | Bezüge seit Entkalken: {BezuegeSeitEntkalken}";
    }
}
