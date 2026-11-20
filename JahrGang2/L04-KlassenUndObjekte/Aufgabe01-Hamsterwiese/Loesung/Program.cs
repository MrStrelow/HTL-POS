using System.Text;

Console.OutputEncoding = Encoding.UTF8;

// ---------- Test Schritt 1 ----------
Console.WriteLine("--- Schritt 1 ---");
Seedling s1 = new Seedling((2, 0));
Seedling s2 = new Seedling((4, 1));
Console.WriteLine(s1.Beschreiben());
Console.WriteLine(s2.Beschreiben());
s2.gefressen = true;
Console.WriteLine(s1.Beschreiben());
Console.WriteLine(s2.Beschreiben());
Seedling blume = new Seedling((0, 3), "🌼");
Console.WriteLine(blume.Beschreiben());

// ---------- Test Schritt 2 ----------
Console.WriteLine("--- Schritt 2 ---");
Seedling[] beet = { new Seedling((2, 0)), new Seedling((4, 1)), new Seedling((1, 2)), new Seedling((5, 3)) };
Wiese testWiese = new Wiese(6, 4, beet);
Console.WriteLine(testWiese.breite + " x " + testWiese.hoehe);
Console.WriteLine(testWiese.IstInnerhalb((5, 3)) + " " + testWiese.IstInnerhalb((6, 3)) + " " + testWiese.IstInnerhalb((0, -1)));
Console.WriteLine(testWiese.SeedlingAuf((1, 2)).Beschreiben());
Console.WriteLine(testWiese.SeedlingAuf((3, 3)) == null);
Console.WriteLine(testWiese.AlleGefressen());
testWiese.Zeichnen(null);

// ---------- Test Schritt 3 ----------
Console.WriteLine("--- Schritt 3 ---");
Seedling[] beet3 = { new Seedling((2, 0)), new Seedling((4, 1)), new Seedling((1, 2)), new Seedling((5, 3)) };
Wiese wiese3 = new Wiese(6, 4, beet3);
Hamster paul = new Hamster((0, 0), wiese3);
Console.WriteLine(paul.Beschreiben());
paul.Bewegen("N");
paul.Bewegen("S");
paul.Bewegen("O");
Console.WriteLine(paul.Beschreiben());
Console.WriteLine(paul.wiese == wiese3);
wiese3.Zeichnen(paul);

// ---------- Test Schritt 4 ----------
Console.WriteLine("--- Schritt 4 ---");
Seedling[] beet4 = { new Seedling((2, 0)), new Seedling((4, 1)), new Seedling((1, 2)), new Seedling((5, 3)) };
Wiese wiese4 = new Wiese(6, 4, beet4);
Hamster willi = new Hamster((0, 0), wiese4, "🐭");
string weg = "OOSOOSSO";
foreach (char schritt in weg)
{
    willi.Bewegen(schritt.ToString());
}
Console.WriteLine(willi.Beschreiben());
Console.WriteLine(beet4[0].Beschreiben());
Console.WriteLine(wiese4.AlleGefressen());
wiese4.Zeichnen(willi);
Hamster gast = new Hamster((2, 0), wiese4);
gast.Fressen();
Console.WriteLine(gast.anzahlGefressen);

// ---------- Test Schritt 5 ----------
Console.WriteLine("--- Schritt 5 --- (Enter startet die Simulation)");
Console.ReadLine();

string[] richtungen = { "N", "O", "S", "W" };
Random generator = new Random();
Seedling[] seedlings = new Seedling[6];
for (int i = 0; i < seedlings.Length; i++)
{
    seedlings[i] = new Seedling((generator.Next(0, 10), generator.Next(0, 6)));
}
Wiese wiese = new Wiese(10, 6, seedlings);
Hamster hamster = new Hamster((0, 0), wiese);

while (!wiese.AlleGefressen())
{
    Console.Clear();
    wiese.Zeichnen(hamster);
    hamster.Bewegen(richtungen[generator.Next(0, richtungen.Length)]);
    Thread.Sleep(200);
}
Console.Clear();
wiese.Zeichnen(hamster);
Console.WriteLine("Alles gefressen! " + hamster.Beschreiben());
