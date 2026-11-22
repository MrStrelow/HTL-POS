// Ein Seedling (Keimling) liegt auf dem Spielfeld, bis ihn ein Hamster frisst.
class Seedling
{
    // Properties: der Zustand
    public (int x, int y) Position { get; private set; }
    public string Representation { get; } = "🌱";

    // Konstruktor: der Startzustand
    public Seedling((int x, int y) position)
    {
        // TODO Schritt 1: Position setzen
    }
}
