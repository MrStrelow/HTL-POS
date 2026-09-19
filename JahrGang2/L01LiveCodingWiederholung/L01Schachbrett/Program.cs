using System.Diagnostics.CodeAnalysis;

Console.OutputEncoding = System.Text.Encoding.UTF8;

// Zustaendigkeit: Laeuft die Zeilen unseres Brettes ab.
for (int y = 0; y < 6; y++)
{
    // Zustaendigkeit: Laeuft die Spalten unseres Brettes ab.
    for (int x = 0; x < 6; x++)
    {
        //bool isWhiteSymbol = (y % 2 == 0 && x % 2 == 0) || (y % 2 == 1 && x % 2 == 1);
        bool isRedSymbol    = (x + y) % 3 == 0;
        bool isBlackSymbol  = (x + y) % 3 == 1;
        bool isWhiteSymbol  = (x + y) % 3 == 2;

        if (isWhiteSymbol) 
        {
            Console.Write("⬜");
        } 
        else if (isBlackSymbol)
        {
            Console.Write("⬛");
        }
        else if (isRedSymbol)
        {
            Console.Write("🔺");
        }
        else
        {
            Console.Write("💀");
        }

    }

    Console.WriteLine();
}