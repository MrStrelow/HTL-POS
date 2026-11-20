// Teil 5d: Ein Interface koennen Klassen UND structs umsetzen.
public interface IEtikett
{
    string Etikett { get; set; }
}

// struct -> Wertsemantik: bei der Uebergabe wird der GANZE Wert kopiert.
public struct Palette : IEtikett
{
    public string Etikett { get; set; }
}
