// Ein Switch steht an einer festen Position und HAT Kabel zu anderen Switches (seine Nachbarn).
public class Switch : IHatPosition, IComparable<Switch>
{
    private List<Switch> _nachbarn = new List<Switch>();

    public string Name { get; }
    public Position Position { get; }
    public IReadOnlyList<Switch> Nachbarn { get { return _nachbarn; } }

    public Switch(string name, Position position)
    {
        Name = name;
        Position = position;
    }

    // Ein Kabel verbindet IMMER beide Seiten.
    public bool Verbinden(Switch anderer)
    {
        // TODO Teil 2: mit sich selbst oder schon verbunden -> false
        //              sonst in BEIDE Nachbarlisten eintragen -> true
        return false;
    }

    public bool Trennen(Switch anderer)
    {
        // TODO Teil 2: aus BEIDEN Nachbarlisten entfernen. Nicht verbunden -> false
        return false;
    }

    // natürliche Ordnung: nach Name
    public int CompareTo(Switch? other)
    {
        // TODO Teil 2: other == null -> 1, sonst nach Name
        return 0;
    }

    public override string ToString()
    {
        return $"{Name,-10} ({Position.X,3}|{Position.Y,3})  {_nachbarn.Count} Kabel";
    }
}
