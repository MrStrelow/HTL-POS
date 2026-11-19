using System.Text;

Console.OutputEncoding = Encoding.UTF8;

((int x, int y) start, (int x, int y) ziel) punkte = ((6,5),(1,1));

void ZeichneDistanzAlsLinie((int x, int y) start, (int x, int y) ziel, int groesse = 10)
{
    string background = "🟦";
    string zielSymbol = "❌";
    string startSymbol = "✅";
    string linienSymbol = "🔸";

    int dx = ziel.x - start.x;
    int dy = ziel.y - start.y;
    // steil: mehr Zeilen als Spalten -> y abgehen
    bool steil = Math.Abs(dy) > Math.Abs(dx);
    double k = (double)dy / dx;   // für f(x)
    double m = (double)dx / dy;   // für g(y)

    // egal ob links -> rechts oder rechts -> links
    int minX = Math.Min(start.x, ziel.x);
    int maxX = Math.Max(start.x, ziel.x);
    int minY = Math.Min(start.y, ziel.y);
    int maxY = Math.Max(start.y, ziel.y);

    for (int y = 0; y < groesse; y++)
    {
        int gy = start.x + (int)Math.Round(m * (y - start.y));
        for (int x = 0; x < groesse; x++)
        {
            int fx = start.y + (int)Math.Round(k * (x - start.x));

            bool aufLinie;
            if (steil)
            {
                aufLinie = x == gy && minY < y && y < maxY;
            }
            else
            {
                aufLinie = y == fx && minX < x && x < maxX;
            }

            if (aufLinie)
            {
                Console.Write(linienSymbol);
            }
            else if (x == start.x && y == start.y)
            {
                Console.Write(startSymbol);
            }
            else if (x == ziel.x && y == ziel.y)
            {
                Console.Write(zielSymbol);
            }
            else
            {
                Console.Write(background);
            }
        }
        Console.WriteLine();
    }
}

ZeichneDistanzAlsLinie(punkte.start, punkte.ziel);
