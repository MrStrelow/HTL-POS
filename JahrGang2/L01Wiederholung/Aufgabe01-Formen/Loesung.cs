// =========================================================================
// Vorbereitung
// =========================================================================

using System.Text;

Console.OutputEncoding = Encoding.UTF8;

int size = 5;
string fillForm = "🔷";
string fillBackground = "◽";

// =========================================================================
// Aufrufe
// =========================================================================
Console.WriteLine("--- Basisform (Beide vorwärts) ---");
DrawTriangle(size, fillForm, fillBackground);
Console.WriteLine();

Console.WriteLine("--- Mirror X (Horizontal gespiegelt, Zeilen rückwärts) ---");
DrawMirrorX(size, fillForm, fillBackground);
Console.WriteLine();

Console.WriteLine("--- Mirror Y (Vertikal gespiegelt, Spalten rückwärts) ---");
DrawMirrorY(size, fillForm, fillBackground);
Console.WriteLine();

Console.WriteLine("--- Mirror Y und X (Beide rückwärts) ---");
DrawMirrorXY(size, fillForm, fillBackground);
Console.WriteLine();

// =========================================================================
// BONUSAUFGABE: Diamant
// =========================================================================

Console.WriteLine("--- BONUS: Diamant zusammengesetzt ---");
DrawDiamond(size, fillForm, fillBackground);
Console.WriteLine();

// =========================================================================
// Funktionen
// =========================================================================
static void DrawTriangle(int size, string symbol, string background)
{
    for (int i = 0; i < size; i++)
    {
        for (int j = 0; j < size; j++)
        {
            if (j <= i)
            {
                Console.Write(symbol);
            }
            else
            {
                Console.Write(background);
            }
        }
        Console.WriteLine();
    }
}

static void DrawMirrorX(int size, string symbol, string background)
{
    for (int i = size - 1; i >= 0; i--)
    {
        for (int j = 0; j < size; j++)
        {
            if (j <= i)
            {
                Console.Write(symbol);
            }
            else
            {
                Console.Write(background);
            }
        }
        Console.WriteLine();
    }
}

static void DrawMirrorY(int size, string symbol, string background)
{
    for (int i = 0; i < size; i++)
    {
        for (int j = size - 1; j >= 0; j--)
        {
            if (j <= i)
            {
                Console.Write(symbol);
            }
            else
            {
                Console.Write(background);
            }
        }
        Console.WriteLine();
    }
}

static void DrawMirrorXY(int size, string symbol, string background)
{
    for (int i = size - 1; i >= 0; i--)
    {
        for (int j = size - 1; j >= 0; j--)
        {
            if (j <= i)
            {
                Console.Write(symbol);
            }
            else
            {
                Console.Write(background);
            }
        }
        Console.WriteLine();
    }
}


// =========================================================================
// BONUS-METHODEN (Zusammenfügen & Muster ohne Arrays)
// =========================================================================

static void DrawDiamond(int size, string symbol, string background)
{
    for (int i = 0; i < size; i++)
    {
        for (int j = size - 1; j >= 0; j--)
        {
            if (j <= i)
            {
                Console.Write(symbol);
            }
            else
            {
                Console.Write(background);
            }
        }
        
        for (int j = 0; j < size; j++)
        {
            if (j <= i)
            {
                Console.Write(symbol);
            }
            else
            {
                Console.Write(background);
            }
        }
            
        Console.WriteLine();
    }

    for (int i = size - 1; i >= 0; i--)
    {
        for (int j = size - 1; j >= 0; j--)
        {
            if (j <= i)
            {
                Console.Write(symbol);
            }
            else
            {
                Console.Write(background);
            }
        }
        
        for (int j = 0; j < size; j++)
        {
            if (j <= i)
            {
                Console.Write(symbol);
            }
            else
            {
                Console.Write(background);
            }
        }
            
        Console.WriteLine();
    }
}