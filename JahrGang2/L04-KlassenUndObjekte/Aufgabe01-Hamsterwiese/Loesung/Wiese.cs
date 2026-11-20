// Die Wiese ist das Spielfeld. Sie HAT einen Seedling (hat-Beziehung).
class Wiese
{
    // Felder: der Zustand
    public int breite;
    public int hoehe;
    public Seedling seedling;         // hat-Beziehung: die Wiese kennt ihren Seedling

    // Konstruktor: der Startzustand
    public Wiese(int breite, int hoehe, Seedling seedling)
    {
        this.breite = breite;
        this.hoehe = hoehe;
        this.seedling = seedling;
    }

    // Methoden: das Verhalten
    public bool IstInnerhalb((int x, int y) p)
    {
        return p.x >= 0 && p.x < breite && p.y >= 0 && p.y < hoehe;
    }

    // Zeile fuer Zeile, Feld fuer Feld: Was steht hier?
    public void Zeichnen(Hamster hamster)
    {
        for (int y = 0; y < hoehe; y++)
        {
            for (int x = 0; x < breite; x++)
            {
                string feld = "🟫";

                if (!seedling.gefressen && seedling.position == (x, y))
                {
                    feld = seedling.darstellung;
                }

                // null heisst: kein Hamster
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
