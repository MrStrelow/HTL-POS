namespace Hamster;

public class Plane
{
    // Felder
    private string[,] _plane;
    private string _earthRepresentation = "🟫";

    // Eigenschaften
    public int Size { get; private set; }
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

        // Was nun?
    }

    // Methoden
    public void Print()
    {

    }

    // private Methoden
}
