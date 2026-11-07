string pfad = "../../../coords.txt";
((int x, int y) start, (int x, int y) ziel) punkte = LeseKoordinaten(pfad);
//Console.WriteLine(start);
//Console.WriteLine(ziel);
//Console.WriteLine(start.x);
Console.WriteLine(punkte);
Console.WriteLine(BerechneDistanzEuklid(punkte.start, punkte.ziel));


// Funktionen
((int x, int y) start, (int x, int y) ziel) LeseKoordinaten(string pfadDerKoordinaten)
{
    string[] lines = File.ReadAllLines(pfadDerKoordinaten);

    string[] ersterPunkt  = lines[0].Split(";");
    string[] zweiterPunkt = lines[1].Split(";");

    // Was wenn ein Blödsinn im txt-File steht?
    // Wenn die Umwandlung zu einer Zahl nicht funktioniert,
    //  dann gib ((-1,-1),(-1,-1)) zurück.
    if( 
        !int.TryParse(ersterPunkt[0], out int startX) ||
        !int.TryParse(ersterPunkt[1], out int startY) ||
        !int.TryParse(zweiterPunkt[0], out int endX)  ||
        !int.TryParse(zweiterPunkt[1], out int endY)  
    )
    {
        return ((-1, -1), (-1, -1));
    }

    return ((startX,startY),(endX, endY));
}

//int[] LeseKoordinatenAlt(string pfadDerKoordinaten)
//{
//    return new int[]{ 1, 5};
//}

double BerechneDistanzEuklid((int x, int y) start, (int x, int y) end)
{
    // 
    return Math.Sqrt(Math.Pow(Math.Abs(start.x - end.x),2) + Math.Pow(Math.Abs(start.y - end.y),2));
}

