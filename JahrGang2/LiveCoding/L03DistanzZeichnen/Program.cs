using System.Text;

Console.OutputEncoding = Encoding.UTF8;

((int x, int y) start, (int x, int y) ziel) punkte = ((1,1),(6,5));

void ZeichneDistanzAlsLinie((int x, int y) start, (int x, int y) ziel)
{
    string background = "🟦";
    string zielSymbol = "❌";
    string startSymbol= "✅";
    string linienSymbol = "🔸";
    double k = (double) (ziel.y - start.y) / (ziel.x - start.x);

    // Gib Hintergrund aus.
    for (int y = 0; y < 10; y++)
    {
        for (int x = 0; x < 10; x++)
        {
            int xVerschoben = x - start.x;

            // Berechne Punkte welche auf der Linie sind
            int fx = start.y + (int) Math.Round(k * xVerschoben);

            // Bedingung für linie
            if (y == fx && start.x < x && x < ziel.x)
            {
                Console.Write(linienSymbol);
            }
            // Bedingung für startsymbol
            else if (x == start.x && y == start.y)
            {
                Console.Write(startSymbol);
            }
            // Bedingung für zielymbol
            else if (x == ziel.x && y == ziel.y)
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
