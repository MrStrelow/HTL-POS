int[,] spielfeld =
{
    { 10, 20, 30 },
    { 40, 50, 60 },
    { 70, 80, 90 }
};

// 1.
Console.WriteLine("----------- 1. -----------");

Console.WriteLine(spielfeld[0, 2]);  // 30
Console.WriteLine(spielfeld[2, 0]);  // 70
Console.WriteLine(spielfeld[1, 1]);  // 50

Console.WriteLine();

// 2.
Console.WriteLine("----------- 2. -----------");

for (int y = 0; y < 2; y++)
{
    for (int x = 0; x < 2; x++)
    {
        Console.WriteLine(spielfeld[y, x] + " ");
    }
    //Console.Write(); // Compiler Fehler! Ein Argument muss übergeben werden.
    Console.Write(""); // Kein Compiler-Fehler.
}

Console.WriteLine();

// 10
// 20
// 40
// 50

// 3.
Console.WriteLine("----------- 3. -----------");

for (int x = 0; x < 2; x++)
{
    for (int y = 0; y < 2; y++)
    {
        Console.Write(spielfeld[x, y] + " ");
    }
    Console.WriteLine();
}

Console.WriteLine();

// 10 20
// 40 50

// 4.
Console.WriteLine("----------- 4. -----------");

for (int x = 0; x < 4; x++)
{
    for (int y = 0; y < 2; y++)
    {
        Console.Write(spielfeld[y, x] + " ");
    }
    Console.WriteLine();
}

Console.WriteLine();

// IndexOutOfRangeException.
// Die Größe der x-Achse im Array ist 3.
// Der Index geht von der Schleife aus von 0 bis 3, also 4 Spalten.

// 5.
Console.WriteLine("----------- 4. -----------");

// 1. Ein neues 2D-Array vom Typ string erstellen (4 Zeilen, 5 Spalten)
//string[___] brett = _________ string[_, _] ;

//// 2. Einen Hamster "🐹" in der 3. Zeile und 2. Spalte platzieren
//brett[___, ___] = "🐹";

//// 3. Das gesamte Array mit einer verschachtelten Schleife durchlaufen
//for (int y = 0; y < ____________; y++)
//{
//    for (int x = 0; x < ____________; x++)
//    {
//        // 4. Den aktuellen Wert des Arrays soll nur für gerade Indices ausgegeben werden.
//        ________
//        ________
//            Console.Write(________);
//        ________
//    }
//    Console.WriteLine();
//}