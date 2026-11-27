// Kabelkanal (Manhattan-Distanz): das Kabel läuft nur waagrecht und senkrecht entlang der Wände
public class Kabelkanal : IDistanz
{
    public string Name { get { return "Kabelkanal"; } }

    public double Berechnen(Position a, Position b)
    {
        return Math.Abs(b.X - a.X) + Math.Abs(b.Y - a.Y);
    }
}
