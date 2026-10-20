public class Roboter
{
    // Eigenschaften
    public Katastrophengebiet Katastrophengebiet { get; set; }
    public (int x, int y) AktuellePosition { get; set; }
    public (int x, int y) GewünschtePosition { get; set; }

    // Konstruktor
    public Roboter(
        Katastrophengebiet katastrophengebiet, 
        (int x, int y) gewünschtePosition
    )
    {
        Katastrophengebiet = katastrophengebiet;
        GewünschtePosition = gewünschtePosition;
    }

    // Methoden
    public void Suchen()
    {
        Console.WriteLine($"Beginne suche auf position {AktuellePosition} und bewege mich auf position {GewünschtePosition}");
    }
}
