// Luftlinie (Pythagoras): das Kabel geht schräg quer durch den Raum
public class Luftlinie : IDistanz
{
    public string Name { get { return "Luftlinie"; } }

    public double Berechnen(Position a, Position b)
    {
        // TODO Teil 1: Wurzel aus (dx² + dy²)  ->  Math.Sqrt(...)
        return 0;
    }
}
