// userinput -
// * eingabe,
// * prüfen ob sinnvoll und solange nachfragen bis sinnvoll

using System.Numerics;

int sizeOfPlane;
string promptForUser = "Wie groß soll die Wiese sein?: ";
Console.Write(promptForUser);

while (!int.TryParse(Console.ReadLine(), out sizeOfPlane) || sizeOfPlane <= 0)
//while (!(int.TryParse(Console.ReadLine(), out sizeOfPlane) && sizeOfPlane > 0))
{
    Console.Clear();

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Input is not an integer number. Please try again.");
    Console.ResetColor();

    Console.Write(promptForUser);
}

// Plane objekt erstellen und aufgabe das spiel zu starten
// * eingabe der größe vom user an Konstruktor übergeben.
Plane plane = new Plane(sizeOfPlane);