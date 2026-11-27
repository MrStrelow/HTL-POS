// Hops: jede Verbindung zählt gleich viel – egal wie lang das Kabel ist.
// Eine Routenlänge zählt dann einfach die Sprünge von Switch zu Switch.
public class Hops : IDistanz
{
    private double _wert;

    public Hops(double wert = 1)
    {
        _wert = wert;
    }

    public string Name { get { return "Hops"; } }

    public double Berechnen(Position a, Position b)
    {
        // TODO Teil 1: immer denselben Wert liefern
        return 0;
    }
}
