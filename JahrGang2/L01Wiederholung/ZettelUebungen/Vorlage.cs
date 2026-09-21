using System.Text;

string blackSymbol = "⬛";
string whiteSymbol = "⬜";
string redSymbol = "🔺";
string errorSymbol = "💀";
//int dimension = 6;
int dimension = 7;
int mitte = (dimension - 1) / 2;

Console.OutputEncoding = Encoding.UTF8;

// Ue 1: 
for (int y = 0; y < dimension; y++)
{
    for (int x = 0; x < dimension; x++)
    {
        // ue0:
        //bool isRedSymbol = false;
        //bool isWhiteSymol = (x + y) % 2 == 0;
        //bool isWhiteSymol = (x % 2 == 0 && y % 2 == 0) || (x % 2 == 1 && y % 2 == 1);
        //bool isBlackSymbol = !isWhiteSymol;

        // ue1:
        //bool isRedSymbol   = (x + y) % 3 == 0;
        //bool isBlackSymbol  = (x + y) % 3 == 1;
        //bool isWhiteSymbol    = (x + y) % 3 == 2;

        // ue1-v2
        //bool isRedSymbol    = (x % 3 == 0 && y % 3 == 0) || (x % 3 == 2 && y % 3 == 1) || (x % 3 == 1 && y % 3 == 2);
        //bool isBlackSymbol  = (x % 3 == 1 && y % 3 == 0) || (x % 3 == 0 && y % 3 == 1) || (x % 3 == 2 && y % 3 == 2);
        //bool isWhiteSymbol  = (x % 3 == 2 && y % 3 == 0) || (x % 3 == 1 && y % 3 == 1) || (x % 3 == 0 && y % 3 == 2);


        // ue2:
        //bool isRedSymbol = (x + y) % 3 == 0;
        //bool isWhiteSymbol = (x + y) % 2 == 0 && !isRedSymbol;
        //bool isBlackSymbol = (x + y) % 2 == 1 && !isRedSymbol;

        // ue2-v2:
        //bool isRedSymbol = (x % 3 == 0 && y % 3 == 0) || (x % 3 == 2 && y % 3 == 1) || (x % 3 == 1 && y % 3 == 2);
        //bool isWhiteSymbol = ((x % 2 == 0 && y % 2 == 0) || (x % 2 == 1 && y % 2 == 1)) && !isRedSymbol;
        //bool isBlackSymbol = ((x % 2 == 1 && y % 2 == 0) || (x % 2 == 0 && y % 2 == 1)) && !isRedSymbol;

        // ue3:
        //bool isWhiteSymbol = 
        //    (x > 0 && x < 6 && y >= 1 && y < 6) 
        //        && 
        //    !(x > 1 && x < 5 && y > 1 && y < 5);

        //bool isBlackSymbol = !isWhiteSymbol && !(x == 3 && y == 3);
        //bool isRedSymbol = x == 3 && y == 3;

        // ue3-v2:
        // 1. Distanz zum dynamischen Mittelpunkt berechnen
        int distanzX = Math.Abs(x - mitte);
        int distanzY = Math.Abs(y - mitte);

        // 2. Die Ringebene ist das Maximum der beiden Distanzen
        int ringEbene = Math.Max(distanzX, distanzY);

        // 3. Logik zuweisen (Mitte = Ebene 0 = schwarz)
        bool isRedSymobl = x == mitte && y == mitte;
        bool isWhiteSymbol = ringEbene % 2 != 0 && !isRedSymobl;
        bool isBlackSymbol = ringEbene % 2 == 0 && !isRedSymobl;

        if (isWhiteSymbol)
        {
            Console.Write(whiteSymbol);
        }
        else if (isBlackSymbol)
        {
            Console.Write(blackSymbol);
        }
        else if (isRedSymobl)
        {
            Console.Write(redSymbol);
        }
    }

    Console.WriteLine();
}