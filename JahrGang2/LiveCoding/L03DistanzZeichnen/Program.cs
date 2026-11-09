using System.Text;

Console.OutputEncoding = Encoding.UTF8;

((int x, int y) start, (int x, int y) ziel) punkte = ((1,1),(5,6));

void ZeichneDistanzAlsLinie((int x, int y) start, (int x, int y) ziel)
{
    string background = "🟦";
    string zielSymbol = "❌";
    string startSymbol= "✅";
    string linienSymbol = "🔸";
    double k = (ziel.y - start.y) / (ziel.x - start.x);

    // Gib Hintergrund aus.
    for (int y = 0; y < 10; y++)
    {
        for (int x = 0; x < 10; x++)
        {
            // Berechne Punkte welche auf der Linie sind
            int yLinie = (int)Math.Round(k * x);

            // Bedingung für linie
            if (???)
            {
                Console.Write(linienSymbol);
            }
            // Bedingung für startsymbol
            else if ()
            {
                Console.Write(startSymbol);
            }
            // Bedingung für zielymbol
            else if ()
            {
                Console.Write(zielSymbol);
            }
            // Bedingung für hintergrund
            else
            {
                Console.Write(background);
            }
        }
        Console.WriteLine();
    }
}

ZeichneDistanzAlsLinie(punkte.start, punkte.ziel);
