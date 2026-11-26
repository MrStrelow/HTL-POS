// Ein Gerät im Schulnetzwerk.
public class Geraet : IComparable<Geraet>
{
    public string Mac { get; }                  // eindeutig, unveränderlich -> Key
    public string Name { get; }
    public string Raum { get; }
    public int PingMs { get; set; }             // ändert sich -> nie Key, nie in Equals

    public Geraet(string mac, string name, string raum, int pingMs)
    {
        // TODO Teil 1: alle Properties setzen
        Mac = "";
        Name = "";
        Raum = "";
    }

    public int CompareTo(Geraet? other)
    {
        // TODO Teil 1: schnellstes zuerst (PingMs), bei gleichem Ping nach Name. null -> 1
        return 0;
    }

    public override bool Equals(object? obj)
    {
        // TODO Teil 1: gleich, wenn obj ein Geraet mit derselben Mac ist
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        // TODO Teil 1: muss zu Equals passen
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return $"{Name,-8} {Mac} {Raum,-6} {PingMs,4} ms";
    }
}
