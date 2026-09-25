namespace Hamster;

public class Plane
{
    private string[,] _plane;
    private static string _earthRepresentation = "🟫";

    public int Size { get; }

    private Dictionary<(int x, int y), Seedling> _seedlings = new();

    // Hamster sind nun ein Dictionary
    private Dictionary<(int x, int y), Hamster> _hamsters = new();

    public Plane(int size)
    {
        var random = new Random();
        Size = size;
        _plane = new string[size, size];

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                _plane[i, j] = _earthRepresentation;
            }
        }

        int numberOfSeedlings = random.Next(1, size * size);
        for (int i = 0; i < numberOfSeedlings; i++)
        {
            var Seedling = new Seedling(this);
            _seedlings[Seedling.Position] = Seedling;
        }

        int numberOfHamster = random.Next(1, size * size - numberOfSeedlings + 1);
        for (int i = 0; i < numberOfHamster; i++)
        {
            var hamster = new Hamster(this);
            // Einfügen in das Dictionary über die Position
            _hamsters[hamster.Position] = hamster;
        }
    }

    public void SimulateHamster()
    {
        foreach (var hamster in _hamsters.Values)
        {
            hamster.Move();
        }
    }

    public void Print(int timeToSleep = 500)
    {
        AssignElementsToPlane();
        Console.SetCursorPosition(0, 0);

        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                Console.Write(_plane[i, j]);
            }
            Console.WriteLine();
        }

        Thread.Sleep(timeToSleep);
    }

    public (int x, int y) Position(Hamster hamster, Direction direction)
    {
        var futurePosition = hamster.Position;

        switch (direction)
        {
            case Direction.UP:
                if (futurePosition.y > 0) futurePosition.y--; break;
            case Direction.DOWN:
                if (futurePosition.y < Size - 1) futurePosition.y++; break;
            case Direction.LEFT:
                if (futurePosition.x > 0) futurePosition.x--; break;
            case Direction.RIGHT:
                if (hamster.Position.x < Size - 1) futurePosition.x++; break;
        }

        return futurePosition;
    }

    public void AssignElementsToPlane()
    {
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                _plane[i, j] = _earthRepresentation;
            }
        }

        foreach (var Seedling in _seedlings.Values)
        {
            _plane[Seedling.Position.y, Seedling.Position.x] = Seedling.Representation;
        }

        foreach (var hamster in _hamsters.Values)
        {
            _plane[hamster.Position.y, hamster.Position.x] = hamster.Representation;
        }
    }

    public bool AssignInitialPosition(Hamster hamster, (int x, int y) key)
    {
        if (!_seedlings.ContainsKey(key) && !_hamsters.ContainsKey(key))
        {
            _plane[key.y, key.x] = hamster.Representation;
            return true;
        }
        return false;
    }

    public bool AssignInitialPosition(Seedling Seedling, (int x, int y) key)
    {
        if (!_seedlings.ContainsKey(key) && !_hamsters.ContainsKey(key))
        {
            _plane[key.y, key.x] = Seedling.Representation;
            return true;
        }
        return false;
    }
}