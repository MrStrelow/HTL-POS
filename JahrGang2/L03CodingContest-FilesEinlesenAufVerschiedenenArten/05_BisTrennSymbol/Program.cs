string pfad = @"..\..\..\input.txt";
string outputPath = @"..\..\..\output.txt";

if (!File.Exists(pfad))
{
    Console.WriteLine("File nicht vorhanden.");
    return;
}

// OPTION 3: Text bis zu einem Trennsymbol ist wichtig für die Aufgabe!
string inhalt = File.ReadAllText(pfad);
char[] trennsymbole = { ' ', ',', '\t', '\r', '\n' }; // ⚠️ Symbole für Trennung an Aufgabenstellung anpassen!
string[] inputFuerAufgabe = inhalt.Split(trennsymbole, StringSplitOptions.RemoveEmptyEntries);
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