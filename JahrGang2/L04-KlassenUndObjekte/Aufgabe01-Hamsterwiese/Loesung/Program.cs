using System.Text;

Console.OutputEncoding = Encoding.UTF8;

// Dieses Hauptprogramm ist FERTIG. Es testet von Anfang an alle Methoden.
// Je mehr du in den Klassen programmierst, desto mehr stimmt die Ausgabe
// mit dem erwarteten Output in der Angabe ueberein.

// ---------- Schritt 1: Seedling ----------
Console.WriteLine("--- Schritt 1 ---");
Seedling s1 = new Seedling((2, 1));
Seedling s2 = new Seedling((4, 3));
Console.WriteLine(s1.Beschreiben());
Console.WriteLine(s2.Beschreiben());
s2.gefressen = true;
Console.WriteLine(s1.Beschreiben());
Console.WriteLine(s2.Beschreiben());

// ---------- Schritt 2: Wiese ----------
Console.WriteLine("--- Schritt 2 ---");
Wiese wiese = new Wiese(6, 4, s1);
Console.WriteLine(wiese.breite + " x " + wiese.hoehe);
Console.WriteLine(wiese.IstInnerhalb((5, 3)));
Console.WriteLine(wiese.IstInnerhalb((6, 3)));
Console.WriteLine(wiese.IstInnerhalb((0, -1)));
wiese.Zeichnen(null);

// ---------- Schritt 3 und 4: Hamster ----------
Console.WriteLine("--- Schritt 3 und 4 ---");
Hamster paul = new Hamster((0, 0), wiese, "🐹");
Console.WriteLine(paul.Beschreiben());
string[] weg = { "N", "O", "O", "S", "O", "W" };
foreach (string richtung in weg)
{
    paul.Bewegen(richtung);
}
Console.WriteLine(paul.Beschreiben());
Console.WriteLine(s1.Beschreiben());
wiese.Zeichnen(paul);

// ---------- Schritt 5: Simulation ----------
Console.WriteLine("--- Schritt 5 --- Enter startet die Simulation");
Console.ReadLine();

Random generator = new Random();
string[] richtungen = { "N", "O", "S", "W" };
Seedling futter = new Seedling((generator.Next(0, 10), generator.Next(0, 6)));
Wiese grosseWiese = new Wiese(10, 6, futter);
Hamster willi = new Hamster((0, 0), grosseWiese, "🐭");

int runde = 0;
while (!futter.gefressen && runde < 500)      // hoechstens 500 Runden
{
    runde++;
    Console.Clear();
    grosseWiese.Zeichnen(willi);
    willi.Bewegen(richtungen[generator.Next(0, richtungen.Length)]);
    Thread.Sleep(200);
}
Console.WriteLine(futter.Beschreiben());
Console.WriteLine(willi.Beschreiben());
