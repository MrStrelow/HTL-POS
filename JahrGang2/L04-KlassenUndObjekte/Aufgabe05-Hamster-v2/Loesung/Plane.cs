// Das Spielfeld: ein 2D-Array zum Zeichnen, Hamster im Array, Seedlings im Dictionary.
class Plane
{
    // Felder
    private string[,] _plane;
    private string _earthRepresentation = "🟫";
    private Hamster[] _hamsters;

    // hat-Beziehung: viele Seedlings, schnell über ihre Position zu finden -> Dictionary
    private Dictionary<(int x, int y), Seedling> _seedlings = new Dictionary<(int x, int y), Seedling>();

    // Properties
    public int Size { get; private set; }

    // Konstruktor: der Startzustand
    public Plane(int size, Hamster[] hamsters, Seedling[] seedlings)
    {
        Size = size;
        _plane = new string[size, size];
        _hamsters = hamsters;

        foreach (Seedling seedling in seedlings)
        {
            _seedlings[seedling.Position] = seedling;
        }
    }

    // Methoden: das Verhalten
    public void Simulate(string direction)
    {
        foreach (Hamster hamster in _hamsters)
        {
            hamster.Move(direction);

            // Guard: hier liegt kein Seedling ❌
            if (!_seedlings.ContainsKey(hamster.Position))
            {
                continue;
            }

            // gewünschter Zustand ✅: der Hamster frisst, der Seedling verschwindet vom Spielfeld
            hamster.Eat(_seedlings[hamster.Position]);
            _seedlings.Remove(hamster.Position);
        }
    }

    public void Print()
    {
        AssignRepresentations();

        for (int y = 0; y < Size; y++)
        {
            for (int x = 0; x < Size; x++)
            {
                Console.Write(_plane[y, x]);
            }
            Console.WriteLine();
        }

        foreach (Hamster hamster in _hamsters)
        {
            string mund = "";
            foreach (Seedling seedling in hamster.Mouth)
            {
                mund += seedling.Representation;
            }
            Console.WriteLine($"{hamster.Representation} {hamster.GetHashCode()} auf {hamster.Position} – im Mund: {mund}");
        }
    }

    // Zuerst überall Erde, dann die Seedlings, dann die Hamster ins 2D-Array schreiben
    private void AssignRepresentations()
    {
        for (int y = 0; y < Size; y++)
        {
            for (int x = 0; x < Size; x++)
            {
                _plane[y, x] = _earthRepresentation;
            }
        }

        foreach (Seedling seedling in _seedlings.Values)
        {
            _plane[seedling.Position.y, seedling.Position.x] = seedling.Representation;
        }

        foreach (Hamster hamster in _hamsters)
        {
            _plane[hamster.Position.y, hamster.Position.x] = hamster.Representation;
        }
    }
}
