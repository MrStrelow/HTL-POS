// Das Spielfeld kennt alle Hamster und alle Seedlings.
class Plane
{
    // Felder: der Zustand
    public Hamster[] _hamsters;       // hat-Beziehung
    public Seedling[] _seedlings;     // hat-Beziehung

    // Konstruktor: der Startzustand
    public Plane(Hamster[] hamsters, Seedling[] seedlings)
    {
        _hamsters = hamsters;
        _seedlings = seedlings;
    }

    // Methoden: das Verhalten
    public void Simulate()
    {
        foreach (Hamster hamster in _hamsters)
        {
            hamster.Move();

            // steht der Hamster auf einem Seedling? -> tauschen: ab jetzt trägt er diesen herum
            foreach (Seedling seedling in _seedlings)
            {
                if (seedling._position == hamster._position)
                {
                    hamster._mouth = seedling;
                    Console.WriteLine($"{hamster._representation} {hamster.GetHashCode()} trägt jetzt {seedling._representation} {seedling.GetHashCode()} herum");
                }
            }
        }
        Print();
    }

    public void Print()
    {
        foreach (Hamster hamster in _hamsters)
        {
            Seedling seedling = hamster._mouth;
            Console.WriteLine($"{hamster._representation} {hamster.GetHashCode()} auf {hamster._position} trägt {seedling._representation} {seedling.GetHashCode()} herum");
        }
        Console.WriteLine();
    }
}
