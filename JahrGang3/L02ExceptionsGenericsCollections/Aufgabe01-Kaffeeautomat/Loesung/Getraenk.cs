// Nur Daten: werden einmal mit einem Object Initializer gesetzt (init) und ändern sich danach nicht mehr.
public class Getraenk
{
    public string Name { get; init; } = "";
    public int WasserMl { get; init; }
    public int BohnenG { get; init; }
    public int MilchMl { get; init; }
}
