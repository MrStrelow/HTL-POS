// Schritt 1 und 6: kleine Vererbungshierarchie
public class Tier
{
    public string Name { get; set; }
    public int Alter { get; }

    public Tier(string name, int alter)
    {
        Name = name;
        Alter = alter;
    }

    // dynamische Polymorphie: welches Geraeusch? -> entschieden zur LAUFZEIT
    public virtual string Geraeusch()
    {
        return "...";
    }

    public override string ToString()
    {
        return Name + " (" + Alter + ")";
    }
}

public class Hund : Tier
{
    public Hund(string name, int alter) : base(name, alter) { }

    public override string Geraeusch()
    {
        return "Wuff";
    }
}

public class Katze : Tier
{
    public Katze(string name, int alter) : base(name, alter) { }

    public override string Geraeusch()
    {
        return "Miau";
    }
}

// Schritt 6: Kontravarianz - vergleicht JEDES Tier, also auch Hunde
public class NachAlter : IComparer<Tier>
{
    public int Compare(Tier? a, Tier? b)
    {
        if (a == null || b == null)
        {
            return 0;
        }
        return a.Alter - b.Alter;
    }
}
