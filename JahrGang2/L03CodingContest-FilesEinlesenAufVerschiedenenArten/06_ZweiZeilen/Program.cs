string pfad = @"..\..\..\input.txt";
string outputPath = @"..\..\..\output.txt";

if (!File.Exists(pfad))
{
    Console.WriteLine("File nicht vorhanden.");
    return;
}

// OPTION 1: Erste und zweite Zeile sind wichtig für Aufgabe.
string[] alleZeilen = File.ReadAllLines(pfad);
string ersteZeile = alleZeilen[0];
string zweiteZeile = alleZeilen[1];
string ergebnis = HierLoeseIchMeineAufgabeMitInfosAusZweiZeilen(ersteZeile, zweiteZeile);

File.WriteAllText(outputPath, ergebnis);
Console.WriteLine("Ergebnis gespeichert.");

string HierLoeseIchMeineAufgabeMitInfosAusZweiZeilen(string ersteZeile, string zweiteZeile)
{
    string ergebnis = "";

    // z.B. splitte nach symbolen auf - oder substring.

    return ergebnis;
}