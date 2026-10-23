string pfad = @"..\..\..\input.txt";
string outputPath = @"..\..\..\output.txt";

if (!File.Exists(pfad))
{
    Console.WriteLine("File nicht vorhanden.");
    return;
}

// OPTION 2: Jede Zeile ist wichtig für Aufgabe!
string[] inputFuerAufgabe = File.ReadAllLines(pfad);
string[] ergebnisse = new string[inputFuerAufgabe.Length];

for (int i = 0; i < inputFuerAufgabe.Length; i++)
{
    ergebnisse[i] = HierLoeseIchMeineAufgabe(inputFuerAufgabe[i]);
}

File.WriteAllLines(outputPath, ergebnisse);
Console.WriteLine("Ergebnis gespeichert.");


string HierLoeseIchMeineAufgabe(string zeile)
{
    string ergebnis = "";

    // 🛠️ HIER DEINE LOGIK PLATZIEREN (z. B. Substring, Berechnungen etc.)

    return ergebnis;
}