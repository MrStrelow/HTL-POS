string pfad = "coords.txt";
((int x, int y) start, (int x, int y) ziel) = LeseKoordinaten(pfad);
Console.WriteLine(start.x);


// Funktionen
((int x, int y) start, (int x, int y) ziel) LeseKoordinaten(string pfadDerKoordinaten)
{
    return ((1,5),(3, 9));
}

int[] LeseKoordinatenAlt(string pfadDerKoordinaten)
{
    return new int[]{ 1, 5};
}

