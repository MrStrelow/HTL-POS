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
        // TODO Schritt 1: Position setzen
    }

    // Methoden: das Verhalten
    public void Move(string direction)
    {
        // TODO Schritt 3:
        //   ziel = Position; je nach direction ("oben", "unten", "links", "rechts") ziel.y bzw. ziel.x ändern
        //   Position = ziel;
    }

    public void Eat(Seedling seedling)
    {
        // TODO Schritt 4: den seedling in die Liste Mouth hinzufügen
    }
}
