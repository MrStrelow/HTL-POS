// Der Stadtplan: Zeilen[y] ist eine Zeile, Zeilen[y][x] ein einzelnes Feld (char).
class Stadtplan
{
    public string[] Zeilen { get; set; }

    public Stadtplan(string[] zeilen)
    {
        Zeilen = zeilen;
    }

    public bool IstInnerhalb((int X, int Y) p)
    {
        return p.X >= 0 && p.Y >= 0 && p.Y < Zeilen.Length && p.X < Zeilen[p.Y].Length;
    }

    // Liegt das Feld (x|y) auf der Geraden zwischen Start und Ziel?
    public bool IstAufRoute((int X, int Y) start, (int X, int Y) ziel, int x, int y)
    {
        int dx = ziel.X - start.X;
        int dy = ziel.Y - start.Y;

        // flach: für jede Spalte x fragt f(x), in welcher Zeile die Linie liegt
        if (Math.Abs(dx) >= Math.Abs(dy))
        {
            // Min/Max: egal ob die Route nach links oder nach rechts geht
            if (x < Math.Min(start.X, ziel.X) || x > Math.Max(start.X, ziel.X))
            {
                return false;
            }

            double k = (double)dy / dx;
            return y == start.Y + (int)Math.Round(k * (x - start.X));
        }

        // steil: für jede Zeile y fragt g(y), in welcher Spalte die Linie liegt
        if (y < Math.Min(start.Y, ziel.Y) || y > Math.Max(start.Y, ziel.Y))
        {
            return false;
        }

        double m = (double)dx / dy;
        return x == start.X + (int)Math.Round(m * (y - start.Y));
    }

    // Gibt die Karte mit der Route des Auftrags aus.
    // Liefert true, wenn die Route keine Sperrzone ⛔ trifft.
    public bool ZeichneRoute(Auftrag auftrag)
    {
        bool frei = true;

        for (int y = 0; y < Zeilen.Length; y++)
        {
            string zeile = "";

            for (int x = 0; x < Zeilen[y].Length; x++)
            {
                char feld = Zeilen[y][x];

                if (x == auftrag.Start.X && y == auftrag.Start.Y)
                {
                    feld = '✅';
                }
                else if (x == auftrag.Ziel.X && y == auftrag.Ziel.Y)
                {
                    feld = '❌';
                }
                else if (IstAufRoute(auftrag.Start, auftrag.Ziel, x, y))
                {
                    if (Zeilen[y][x] == '⛔')
                    {
                        feld = '⚡';
                        frei = false;
                    }
                    else
                    {
                        feld = '⭐';
                    }
                }

                zeile += feld.ToString();
            }

            Console.WriteLine(zeile);
        }

        return frei;
    }
}
