Console.OutputEncoding = System.Text.Encoding.UTF8;

// Objekte werden erstellt: paul ist...
// * eine Instanz der Klasse Hamster
// * ein Objekt dessen die Klasse Hamster Zustand und Verhalten vorschreibt.
Hamster paul = new Hamster((0, 0), "🐹", null);
Hamster willi = new Hamster((1, 0), "🐹", paul);
Hamster jan = new Hamster();

while (true)
{
    paul.Bewegen("N");
    willi.Nachmachen();
    Console.WriteLine();
    Thread.Sleep(1000);
}