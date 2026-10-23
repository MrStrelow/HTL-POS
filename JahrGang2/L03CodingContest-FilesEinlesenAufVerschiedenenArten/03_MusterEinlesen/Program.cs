string pfad = @"..\..\..\input.txt";
string outputPath = @"..\..\..\output.txt";

if (!File.Exists(pfad))
{
    Console.WriteLine("File nicht vorhanden.");
    return;
}

// OPTION 9: 2D-Spielfeld (Grid) einlesen (Zeile 0 hat die Größe, ab Zeile 1 kommt die Karte)
string[] alleZeilen = File.ReadAllLines(pfad);
string groessenInfo = alleZeilen[0]; // z.B. "5 5" für Höhe und Breite

// Das Spielfeld ohne die erste Zeile kopieren
string[] spielfeld = new string[alleZeilen.Length - 1];
for (int i = 1; i < alleZeilen.Length; i++)
{
    spielfeld[i - 1] = alleZeilen[i];
}

string ergebnis = HierLoeseIchMeineAufgabeMitSpielfeld(spielfeld);

File.WriteAllText(outputPath, ergebnis);
Console.WriteLine("Ergebnis gespeichert.");


string HierLoeseIchMeineAufgabeMitSpielfeld(string[] spielfeld)
{
    string ergebnis = "";

    int hoehe = spielfeld.Length;
    int breite = spielfeld[0].Length;

    // 🛠️ HIER DEINE LOGIK PLATZIEREN: Jeden Punkt im 2D-Gitter durchgehen
    for (int zeile = 0; zeile < hoehe; zeile++)
    {
        for (int spalte = 0; spalte < breite; spalte++)
        {
            char symbol = spielfeld[zeile][spalte];

            // Beispiel: Zähle alle Münzen 'C' oder suche den Startpunkt 'S'
            if (symbol == 'S')
            {
                ergebnis = zeile + " " + spalte;
            }
        }
    }

    return ergebnis;
}