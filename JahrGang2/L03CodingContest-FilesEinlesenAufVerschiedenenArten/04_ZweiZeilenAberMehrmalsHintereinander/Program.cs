string pfad = @"..\..\..\input.txt";
string outputPath = @"..\..\..\output.txt";

if (!File.Exists(pfad))
{
    Console.WriteLine("File nicht vorhanden.");
    return;
}

// OPTION 8: Erste Zeile ist Anzahl N, danach gehören immer 2 Zeilen zusammen zu einer Aufgabe!
string[] alleZeilen = File.ReadAllLines(pfad);
int anzahlAufgaben = (alleZeilen.Length - 1) / 2;

string[] ergebnisse = new string[anzahlAufgaben];

int ergebnisIndex = 0;
// Startet bei Zeile 1 und springt immer um 2 Zeilen weiter (i += 2)
for (int i = 1; i < alleZeilen.Length; i += 2)
{
    string zeileA = alleZeilen[i];
    string zeileB = alleZeilen[i + 1];

    ergebnisse[ergebnisIndex] = HierLoeseIchMeineAufgabeMitZweiZeilen(zeileA, zeileB);
    ergebnisIndex++;
}

File.WriteAllLines(outputPath, ergebnisse);
Console.WriteLine("Ergebnis gespeichert.");


string HierLoeseIchMeineAufgabeMitZweiZeilen(string zeileA, string zeileB)
{
    string ergebnis = "";

    // 🛠️ HIER DEINE LOGIK PLATZIEREN

    return ergebnis;
}