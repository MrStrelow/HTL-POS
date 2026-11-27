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
        if (anderer == this || _nachbarn.Contains(anderer))
        {
            return false;
        }
        _nachbarn.Add(anderer);
        anderer._nachbarn.Add(this);
        return true;
    }

    public bool Trennen(Switch anderer)
    {
        if (!_nachbarn.Remove(anderer))
        {
            return false;
        }
        anderer._nachbarn.Remove(this);
        return true;
    }

    // natürliche Ordnung: nach Name
    public int CompareTo(Switch? other)
    {
        if (other == null)
        {
            return 1;
        }
        return string.Compare(Name, other.Name);
    }

    public override string ToString()
    {
        return $"{Name,-10} ({Position.X,3}|{Position.Y,3})  {_nachbarn.Count} Kabel";
    }
}
