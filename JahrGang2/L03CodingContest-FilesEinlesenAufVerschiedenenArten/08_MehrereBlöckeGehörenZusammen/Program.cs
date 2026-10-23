string pfad = @"..\..\..\input.txt";
string outputPath = @"..\..\..\output.txt";

if (!File.Exists(pfad))
{
    Console.WriteLine("File nicht vorhanden.");
    return;
}

// OPTION 7: Zusammenhängende Blöcke (getrennt durch eine Leerzeile) sind je eine Aufgabe!
string inhalt = File.ReadAllText(pfad);
string[] blockTrenner = { "\r\n\r\n", "\n\n" }; // Trennt überall dort, wo eine Leerzeile ist
string[] inputFuerAufgabe = inhalt.Split(blockTrenner, StringSplitOptions.RemoveEmptyEntries);

// Aufgabe für lösen: Neues Array in exakt derselben Größe wie die Anzahl der Blöcke
string[] ergebnisse = new string[inputFuerAufgabe.Length];

for (int i = 0; i < inputFuerAufgabe.Length; i++)
{
    ergebnisse[i] = HierLoeseIchMeineAufgabeMitBlock(inputFuerAufgabe[i]);
}

File.WriteAllLines(outputPath, ergebnisse);
Console.WriteLine("Ergebnis gespeichert.");


string HierLoeseIchMeineAufgabeMitBlock(string ganzerBlock)
{
    string ergebnis = "";

    // Den Block wieder in seine einzelnen Zeilen zerlegen:
    char[] zeilenTrenner = { '\r', '\n' };
    string[] zeilenDesBlocks = ganzerBlock.Split(zeilenTrenner, StringSplitOptions.RemoveEmptyEntries);

    // 🛠️ HIER DEINE LOGIK PLATZIEREN (z. B. mit Schleife über zeilenDesBlocks gehen)

    return ergebnis;
}