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

        // Befülle mit Seedings 🌱
        Random random = new Random();
        int numberOfSeedings = random.Next(1, Size*Size+1);
        for (int i = 0; i < numberOfSeedings; i++)
        {
            Seedling seedling = new Seedling();
            _seedlings[seedling.Position] = seedling;
        }
    }

    // Methoden
    public void Print()
    {





        while (false)
        {

        }








        for (int zeile = 0; zeile < Size; zeile++)
        {
            for (int spalte = 0; spalte < Size; spalte++)
            {
                Console.Write(_plane[zeile, spalte]);
            }
            Console.WriteLine();
        }
    }

    // private Methoden
}
