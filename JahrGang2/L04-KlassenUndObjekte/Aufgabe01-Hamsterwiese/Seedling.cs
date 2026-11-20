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
        // TODO Schritt 1: position = start, darstellung = "🌱", gefressen = false
    }

    // Methoden: das Verhalten
    public string Beschreiben()
    {
        // TODO Schritt 1: z. B. "🌱 auf (2, 1)" bzw. "🌱 auf (4, 3) (gefressen)"
        return "TODO";
    }
}
