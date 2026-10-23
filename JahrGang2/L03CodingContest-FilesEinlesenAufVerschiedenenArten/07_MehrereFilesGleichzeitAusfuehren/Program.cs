// Alle Dateien eines Levels auf einmal abarbeiten!
string[] alleDateien = {
    @"..\..\..\level1_1",
    @"..\..\..\level1_2"
};

for (int d = 0; d < alleDateien.Length; d++)
{
    string pfad = alleDateien[d] + ".in";
    string outputPath = alleDateien[d] + ".out";

    if (!File.Exists(pfad))
    {
        Console.WriteLine("File nicht vorhanden: " + pfad);
        continue; // Springt zur nächsten Datei, falls eine noch fehlt
    }

    // AB HIER DEINE GEWOHNTE OPTION EINSETZEN (z. B. Option 6: Erste Zeile überspringen)
    string[] alleZeilen = File.ReadAllLines(pfad);
    string[] ergebnisse = new string[alleZeilen.Length - 1];

    for (int i = 1; i < alleZeilen.Length; i++)
    {
        ergebnisse[i - 1] = HierLoeseIchMeineAufgabe(alleZeilen[i]);
    }

    File.WriteAllLines(outputPath, ergebnisse);
    Console.WriteLine("Ergebnis gespeichert: " + outputPath);
}


string HierLoeseIchMeineAufgabe(string zeile)
{
    string ergebnis = "";

    // 🛠️ HIER DEINE LOGIK PLATZIEREN

    return ergebnis;
}