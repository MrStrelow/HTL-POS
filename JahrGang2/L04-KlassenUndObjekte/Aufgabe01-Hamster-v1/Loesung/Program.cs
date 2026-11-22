using System.Text;

Console.OutputEncoding = Encoding.UTF8;

// Seedlings haben keinen Konstruktor -> Felder mit dem Punkt setzen
Seedling s1 = new Seedling();
s1._position = (1, 5);
Seedling s2 = new Seedling();
s2._position = (1, 2);
Seedling s3 = new Seedling();
s3._position = (4, 2);
Seedling s4 = new Seedling();
s4._position = (4, 7);
Seedling s5 = new Seedling();
s5._position = (4, 0);
Seedling s6 = new Seedling();
s6._position = (7, 8);
Seedling s7 = new Seedling();
s7._position = (7, 3);
Seedling s8 = new Seedling();
s8._position = (9, 9);

Seedling[] seedlings = { s1, s2, s3, s4, s5, s6, s7, s8 };

// Jeder Hamster startet auf einem Seedling und hat ihn schon im Mund
Hamster[] hamsters =
{
    new Hamster((1, 5), s1),
    new Hamster((4, 2), s3),
    new Hamster((7, 8), s6)
};

Plane plane = new Plane(hamsters, seedlings);

// Hash-IDs zum Vergleichen
Console.WriteLine($"s2 hat die Hash-ID {s2.GetHashCode()}");
Console.WriteLine($"hamsters hat die Hash-ID {hamsters.GetHashCode()}");
Console.WriteLine($"plane._hamsters hat die Hash-ID {plane._hamsters.GetHashCode()}");
Console.WriteLine();

while (true)
{
    plane.Simulate();
    Thread.Sleep(1000);
}
