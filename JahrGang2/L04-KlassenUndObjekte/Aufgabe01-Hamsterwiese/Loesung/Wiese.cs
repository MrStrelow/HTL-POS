// Die Wiese ist das Spielfeld. Sie HAT Seedlings (hat-Beziehung).
class Wiese
{
    // Felder: der Zustand
    public int breite;
    public int hoehe;
    public Seedling[] seedlings;      // hat-Beziehung: die Wiese kennt ihre Seedlings

    // Konstruktor: der Startzustand
    public Wiese(int breite, int hoehe, Seedling[] seedlings)
    {
        this.breite = breite;
        this.hoehe = hoehe;
        this.seedlings = seedlings;
    }

    // Methoden: das Verhalten
    public bool IstInnerhalb((int x, int y) p)
    {
        return p.x >= 0 && p.x < breite && p.y >= 0 && p.y < hoehe;
    }

    // liefert einen noch nicht gefressenen Seedling auf diesem Feld - oder null
    public Seedling SeedlingAuf((int x, int y) p)
    {
        foreach (Seedling seedling in seedlings)
        {
            if (seedling.position == p && !seedling.gefressen)
            {
                return seedling;
            }
        }
        return null;
    }

    public bool AlleGefressen()
    {
        foreach (Seedling seedling in seedlings)
        {
            if (!seedling.gefressen)
            {
                return false;
            }
        }
        return true;
    }

    // Zeile fuer Zeile, Feld fuer Feld: Was steht hier?
    public void Zeichnen(Hamster hamster, string erde = "🟫")
    {
        for (int y = 0; y < hoehe; y++)
        {
            for (int x = 0; x < breite; x++)
            {
                string feld = erde;

                // ein Seedling, der noch nicht gefressen wurde?
                Seedling seedling = SeedlingAuf((x, y));
                if (seedling != null)
                {
                    feld = seedling.darstellung;
                }

                // der Hamster liegt oben drauf - null heisst: kein Hamster
                if (hamster != null && hamster.position == (x, y))
                {
                    feld = hamster.darstellung;
                }

                Console.Write(feld);
            }
            Console.WriteLine();
        }
    }
}
