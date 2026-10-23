string pfad = @"..\..\..\input.txt";
string outputPath = @"..\..\..\output.txt";

if (!File.Exists(pfad))
{
    Console.WriteLine("File nicht vorhanden.");
    return;
}

// OPTION 6: Erste Zeile überspringen (z.B. Anzahl N oder Tabellen-Header), Rest zeilenweise lösen!
string[] alleZeilen = File.ReadAllLines(pfad);
string ersteZeileInfo = alleZeilen[0]; // Oft die Anzahl N (falls nötig: int n = int.Parse(ersteZeileInfo);)

// Neues Array ist um 1 kleiner, weil die erste Zeile keine Aufgabe ist
string[] ergebnisse = new string[alleZeilen.Length - 1];

// Schleife startet bei i = 1 (überspringt die erste Zeile!)
for (int i = 1; i < alleZeilen.Length; i++)
{
    ergebnisse[i - 1] = HierLoeseIchMeineAufgabe(alleZeilen[i]);
}

File.WriteAllLines(outputPath, ergebnisse);
Console.WriteLine("Ergebnis gespeichert.");


string HierLoeseIchMeineAufgabe(string zeile)
{
    string ergebnis = "";

    // 🛠️ HIER DEINE LOGIK PLATZIEREN (z. B. zeile.Split(' '), Berechnungen etc.)

    return ergebnis;
}