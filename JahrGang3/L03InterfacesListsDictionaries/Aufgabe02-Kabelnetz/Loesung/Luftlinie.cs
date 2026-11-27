// Luftlinie (Pythagoras): das Kabel geht schräg quer durch den Raum
public class Luftlinie : IDistanz
{
    public string Name { get { return "Luftlinie"; } }

    public double Berechnen(Position a, Position b)
    {
        int dx = b.X - a.X;
        int dy = b.Y - a.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }
}
