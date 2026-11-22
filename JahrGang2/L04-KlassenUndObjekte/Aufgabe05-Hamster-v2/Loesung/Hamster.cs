// Ein Hamster läuft über das Spielfeld und sammelt Seedlings in seinem Mund.
class Hamster
{
    // Properties: der Zustand
    public (int x, int y) Position { get; private set; }
    public string Representation { get; } = "🐹";

    // hat-Beziehung: 1 Hamster hat viele Seedlings im Mund -> Liste
    public List<Seedling> Mouth { get; } = new List<Seedling>();

    // Konstruktor: der Startzustand
    public Hamster((int x, int y) position)
    {
        Position = position;
    }

    // Methoden: das Verhalten
    public void Move(string direction)
    {
        (int x, int y) ziel = Position;

        if (direction == "oben")
        {
            ziel.y--;
        }
        if (direction == "unten")
        {
            ziel.y++;
        }
        if (direction == "links")
        {
            ziel.x--;
        }
        if (direction == "rechts")
        {
            ziel.x++;
        }

        Position = ziel;
    }

    public void Eat(Seedling seedling)
    {
        Mouth.Add(seedling);
    }
}
