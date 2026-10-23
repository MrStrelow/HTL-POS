string pfad = @"..\..\..\input.txt";
string outputPath = @"..\..\..\output.txt";

if (!File.Exists(pfad))
{
    Console.WriteLine("File nicht vorhanden.");
    return;
}

// OPTION 4: csv, tsv, etc. einlesen - jede Spalten einzeln ist wichtig für die Aufgabe.
string[][] spaltenArrays = LeseCsvSpaltenweise(pfad, ',');
string[] ergebnisseSpalten = new string[spaltenArrays.Length];

for (int i = 0; i < spaltenArrays.Length; i++)
{
    ergebnisseSpalten[i] = HierLoeseIchMeineAufgabeMitArrayAlsInput(spaltenArrays[i]);
}

File.WriteAllLines(outputPath, ergebnisseSpalten);
Console.WriteLine("Ergebnis gespeichert.");


string HierLoeseIchMeineAufgabeMitArrayAlsInput(string[] spalte)
{
    string ergebnis = "";

    // ganze spalte verwenden um z.B. was zu berechnen mit schleife oder min max zu finden.

    return ergebnis;
}

// CSV Funktion: Zeilenweise einlesen und in Spalten-Arrays aufteilen
string[][] LeseCsvSpaltenweise(string dateipfad, char trenner)
{
    string[] zeilen = File.ReadAllLines(dateipfad);
    if (zeilen.Length == 0) return new string[0][];

    string[] ersteZeileZellen = zeilen[0].Split(trenner);
    int anzahlSpalten = ersteZeileZellen.Length;
    int anzahlZeilen = zeilen.Length;

    string[][] spaltenArrays = new string[anzahlSpalten][];
    for (int c = 0; c < anzahlSpalten; c++)
    {
        spaltenArrays[c] = new string[anzahlZeilen];
    }

    for (int r = 0; r < anzahlZeilen; r++)
    {
        string[] zellen = zeilen[r].Split(trenner);
        for (int c = 0; c < anzahlSpalten && c < zellen.Length; c++)
        {
            spaltenArrays[c][r] = zellen[c];
        }
    }

    return spaltenArrays;
}