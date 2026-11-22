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
        // TODO: 
        // 1) rufe AssignRepresentationsToPlane auf, um die Hamster und Seedlings in der _plane zu platzieren.
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
        // TODO:
        // 1) Mehrfachverzweigung welche abfragt in welche Richtung der Hamster möchte.
        //     Die position muss angepasst werden, je nachdem welche Richtung der Hamster gewählt hat.

        return futurePosition;
    }

    public void AssignRepresentationsToPlane()
{
    // TODO:
    // 1. Überschreibe das gesamte 2D-Array (_plane) wieder komplett mit dem Erdsymbol (_earthRepresentation), 
    //    um alte Positionen zu löschen.
    // 2. Gehe durch alle Hamster in der Liste _hamsters und schreibe ihre Representation 
    //    an ihre aktuelle Position (y = Zeile, x = Spalte) in das _plane-Array.
    // 3. Gehe durch alle Seedlings im Dictionary _seedlings (nutze .Values) und schreibe 
    //    ihre Representation an ihre aktuelle Position in das _plane-Array.
}

    // private Methoden
}
