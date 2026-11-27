// Ein Laptop ist kein Switch – hat aber auch eine Position.
public class Laptop : IHatPosition
{
    public string Name { get; }
    public Position Position { get; }

    public Laptop(string name, Position position)
    {
        Name = name;
        Position = position;
    }
}
