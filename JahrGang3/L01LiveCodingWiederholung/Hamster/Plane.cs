namespace Hamster;

public class Plane
{
    // Felder
    private string[,] _plane;
    private string _earthRepresentation = "🟫";

    // Eigenschaften
    public int Size { get; private set; }

    // Beziehungen
    // 1 zu N hat-Beziehung: umgesetzt mit einem Dictionary (könnte auch Liste oder Array oder... sein)
    private Dictionary<(int x, int y), Seedling> _seedlings = new ();

    // Konstruktoren
    public Plane(int sizeOfPlane)
    {
        Size = sizeOfPlane;
        _plane = new string[Size, Size];

        // Befülle die _plane mit einem Erdesymbol 🟫
        for (int zeile = 0; zeile < Size; zeile++)
        {
            for (int spalte = 0; spalte < Size; spalte++)
            {
                _plane[zeile, spalte] = _earthRepresentation;
            }
        }

        // Befülle Dictionary mit Seedings 🌱
        Random random = new Random();
        int numberOfSeedings = random.Next(1, Size*Size+1);

        for (int i = 0; i < numberOfSeedings; i++)
        {
            Seedling seedling = new Seedling();
            _seedlings[seedling.Position] = seedling;
        }

        // Befülle Liste mit Hamster 🐹
        // TODO:
        // 1) Wie bei den Seedlings erstelle eine zufällige Anzahl an Hamster
        //      und weise diese dem Dictionary _hamster zu.
    }

    // Methoden
    public void Print()
    {
        for (int zeile = 0; zeile < Size; zeile++)
        {
            for (int spalte = 0; spalte < Size; spalte++)
            {
                Console.Write(_plane[zeile, spalte]);
            }
            Console.WriteLine();
        }
    }

    public ____ AssignInitialPosition(____)
    {
        // TODO:
        // 1. Prüfe im Dictionary ob der Parameter key im Feld _seedlings vorkommt.
        // 2. Wenn ein solcher Key existiert bedeutet es, dort lebt ein Seedling. 
        //      Es kann die vom Seedling gewünschte Position nicht umgesetzt werden.
        // 3. Ansonsten ist frei und wir können die vom Seedling gewünschte Position umgesetzen.
        //      Wir setzen in unserer _plane die Representation des Seedlings auf die gewünschte Position.
    }

    public ____ AssignInitialPosition(____)
    {
        // TODO:
        // 1. Prüfe im Dictionary ob der Parameter key im Feld _hamster vorkommt.
        // 2. Wenn ein solcher Key existiert bedeutet es, dort lebt ein Hamster. 
        //      Es kann die vom Hamster gewünschte Position nicht umgesetzt werden.
        // 3. Ansonsten ist frei und wir können die vom Hamster gewünschte Position umgesetzen.
        //      Wir setzen in unserer _plane die Representation des Hamsters auf die gewünschte Position.
    }

    ____ SimulateHamster(____)
    {
        // TODO:
        // 1) nimm alle Hamster in _hamster und führe für jeden von diesen die Methode Move aus.
    }

    public (int x, int y) Position(Hamster hamster, Direction direction)
    {

        var (x, y) = hamster.Position;

        var futurePosition = direction switch
        {
            Direction.UP when y > 0 => (x, y - 1),
            Direction.DOWN when y < Size - 1 => (x, y + 1),
            Direction.LEFT when x > 0 => (x - 1, y),
            Direction.RIGHT when x < Size - 1 => (x + 1, y),
            _ => (x, y)
        };

        //var futurePosition = hamster.Position;
        //switch (direction)
        //{
        //    case Direction.UP:
        //        if (futurePosition.y > 0)
        //            futurePosition.y--;
        //        break;

        //    case Direction.DOWN:
        //        if (futurePosition.y < Size - 1)
        //            futurePosition.y++;
        //        break;

        //    case Direction.LEFT:
        //        if (futurePosition.x > 0)
        //            futurePosition.x--;
        //        break;

        //    case Direction.RIGHT:
        //        if (hamster.Position.x < Size - 1)
        //            futurePosition.x++;
        //        break;
        //}

        return futurePosition;
    }

    // private Methoden
}
