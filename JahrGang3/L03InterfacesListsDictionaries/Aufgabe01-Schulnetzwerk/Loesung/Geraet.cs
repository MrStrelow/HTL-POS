// Ein Gerät im Schulnetzwerk.
// IComparable<Geraet>: Geräte können sich vergleichen -> Sort(), Max(), Min() funktionieren.
public class Geraet : IComparable<Geraet>
{
    public string Mac { get; }                  // eindeutig, unveränderlich -> Key
    public string Name { get; }
    public string Raum { get; }
    public int PingMs { get; set; }             // ändert sich -> nie Key, nie in Equals

    public Geraet(string mac, string name, string raum, int pingMs)
    {
        Mac = mac;
        Name = name;
        Raum = raum;
        PingMs = pingMs;
    }

    // schnellstes zuerst, bei gleichem Ping nach Name
    public int CompareTo(Geraet? other)
    {
        if (other == null)
        {
            return 1;
        }

        int vergleich = PingMs.CompareTo(other.PingMs);
        if (vergleich != 0)
        {
            return vergleich;
        }
        return Name.CompareTo(other.Name);
    }

    // gleich = gleiche MAC. Nur die MAC, weil sie sich nie ändert.
    public override bool Equals(object? obj)
    {
        return obj is Geraet other && other.Mac == Mac;
    }

    // muss zu Equals passen: gleiche MAC -> gleicher Hash
    public override int GetHashCode()
    {
        return Mac.GetHashCode();
    }

    public override string ToString()
    {
        return $"{Name,-8} {Mac} {Raum,-6} {PingMs,4} ms";
    }
}
