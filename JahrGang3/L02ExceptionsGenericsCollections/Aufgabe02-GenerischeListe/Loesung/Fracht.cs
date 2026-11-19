// Teil 3: Basisklasse fuer alle Frachtstuecke.
// Symbol ist abstract -> dynamische Polymorphie (entschieden zur LAUFZEIT).
public abstract class Fracht : IComparable<Fracht>
{
    public int Tonnen { get; private set; }

    protected Fracht(int tonnen)
    {
        Tonnen = tonnen;
    }

    public abstract string Symbol { get; }

    // Teil 5: veraendert das OBJEKT
    public void Nachladen(int tonnen)
    {
        Tonnen += tonnen;
    }

    // vergleicht nach dem Gewicht
    public int CompareTo(Fracht? other)
    {
        if (other == null)
        {
            return 1;
        }
        return Tonnen - other.Tonnen;
    }

    public override string ToString()
    {
        return Symbol + " " + Tonnen + " t";
    }
}

public class Holz : Fracht
{
    // leerer Konstruktor fuer where T : new()
    public Holz() : this(0) { }
    public Holz(int tonnen) : base(tonnen) { }

    public override string Symbol
    {
        get { return "🪵"; }
    }
}

public class Kohle : Fracht
{
    public Kohle() : this(0) { }
    public Kohle(int tonnen) : base(tonnen) { }

    public override string Symbol
    {
        get { return "🪨"; }
    }
}
