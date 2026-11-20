// Ein Seedling (Keimling) steht an einer Stelle der Wiese und wartet darauf, gefressen zu werden.
class Seedling
{
    // Felder: der Zustand
    public (int x, int y) position;
    public string darstellung;
    public bool gefressen;

    // Konstruktor: der Startzustand
    public Seedling((int x, int y) start, string darstellung = "🌱")
    {
        position = start;
        this.darstellung = darstellung;
        gefressen = false;
    }

    // Methoden: das Verhalten
    public string Beschreiben()
    {
        if (gefressen)
        {
            return $"{darstellung} auf {position} (gefressen)";
        }
        return $"{darstellung} auf {position}";
    }
}
