// Ein Seedling (Keimling) steht auf der Wiese und wartet darauf, gefressen zu werden.
class Seedling
{
    // Felder: der Zustand
    public (int x, int y) position;
    public string darstellung;
    public bool gefressen;

    // Konstruktor: der Startzustand
    public Seedling((int x, int y) start)
    {
        position = start;
        darstellung = "🌱";
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
