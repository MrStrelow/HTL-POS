using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.CursorVisible = false;

// Dieses Hauptprogramm ist FERTIG.

Hamster[] hamsters =
{
    new Hamster((0, 0)),
    new Hamster((2, 3)),
    new Hamster((3, 0))
};

Seedling[] seedlings =
{
    new Seedling((2, 0)),
    new Seedling((4, 4)),
    new Seedling((5, 1)),
    new Seedling((1, 2)),
    new Seedling((0, 5))
};

Plane plane = new Plane(6, hamsters, seedlings);

// Alle Hamster gehen denselben festen Weg – ohne Zufall
string[] weg = { "rechts", "rechts", "unten", "unten", "links", "oben" };

Console.Clear();
plane.Print();
Thread.Sleep(1000);

foreach (string direction in weg)
{
    plane.Simulate(direction);

    Console.Clear();
    Console.WriteLine($"alle gehen nach {direction}");
    plane.Print();
    Thread.Sleep(1000);
}
