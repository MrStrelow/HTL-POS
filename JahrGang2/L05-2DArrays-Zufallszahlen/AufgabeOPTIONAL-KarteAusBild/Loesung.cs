// LOESUNG - Nur anschauen, wenn du gar nicht weiterkommst!
// Diese Datei wird nicht kompiliert (siehe .csproj).

using System.Text;

Console.OutputEncoding = Encoding.UTF8; // Fuer Emojis

// ======================= Hauptprogramm =======================
string pfadBild = "../../../weltkarte.bmp";
string pfadNeuesBild = "../../../weltkarte_neu.bmp";

// Guard ❌: ohne Bild koennen wir nichts tun (early exit)
if (!File.Exists(pfadBild))
{
    Console.WriteLine("❌ weltkarte.bmp nicht gefunden.");
    return;
}

string[,] karte = LadeKarteAusBild(pfadBild);
Console.WriteLine($"Karte mit {karte.GetLength(0)} Zeilen und {karte.GetLength(1)} Spalten aus dem Bild geladen:");
ZeichneKarte(karte);

// Bonus: ein paar Baeume setzen und als neues Bild speichern
karte[10, 5] = "🌳";
karte[10, 6] = "🌳";
karte[11, 5] = "🌳";
SpeichereKarteAlsBild(karte, pfadNeuesBild);
Console.WriteLine($"Bild in {pfadNeuesBild} gespeichert. Oeffne es mit Paint (stark hineinzoomen!).");

// ======================= Teil 1: Hilfsfunktion (vorgegeben) =======================

// Liest 4 Bytes ab 'position' als ganze Zahl (Little Endian: das niedrigste Byte steht zuerst).
// Beispiel: 32 0 0 0 -> 32,   0 1 0 0 -> 256
int LeseZahl(byte[] daten, int position)
{
    return daten[position]
         + daten[position + 1] * 256
         + daten[position + 2] * 256 * 256
         + daten[position + 3] * 256 * 256 * 256;
}

// ======================= Teil 2: Farbe -> Emoji =======================

string FarbeZuSymbol(int rot, int gruen, int blau)
{
    if (rot == 0 && gruen == 0 && blau == 255)
    {
        return "🟦"; // Wasser
    }
    if (rot == 120 && gruen == 67 && blau == 21)
    {
        return "🟫"; // Erde
    }
    if (rot == 128 && gruen == 128 && blau == 128)
    {
        return "🗻"; // Stein
    }

    return "💀"; // unbekannte Farbe
}

// ======================= Teil 3: Bild einlesen =======================

string[,] LadeKarteAusBild(string pfad)
{
    byte[] daten = File.ReadAllBytes(pfad);

    int start = LeseZahl(daten, 10);
    int breite = LeseZahl(daten, 18);
    int hoehe = LeseZahl(daten, 22);

    // Jede Zeile wird mit 0-Bytes auf ein Vielfaches von 4 aufgefuellt.
    int bytesProZeile = (breite * 3 + 3) / 4 * 4;

    string[,] karte = new string[hoehe, breite];

    for (int y = 0; y < hoehe; y++)
    {
        // BMP speichert die Zeilen von UNTEN nach OBEN!
        int zeileImFile = hoehe - 1 - y;

        for (int x = 0; x < breite; x++)
        {
            int position = start + zeileImFile * bytesProZeile + x * 3;

            // Reihenfolge im File: Blau, Gruen, Rot
            int blau = daten[position];
            int gruen = daten[position + 1];
            int rot = daten[position + 2];

            karte[y, x] = FarbeZuSymbol(rot, gruen, blau);
        }
    }

    return karte;
}

void ZeichneKarte(string[,] karte)
{
    for (int y = 0; y < karte.GetLength(0); y++)
    {
        for (int x = 0; x < karte.GetLength(1); x++)
        {
            Console.Write(karte[y, x]);
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

// ======================= Bonus: Bild speichern =======================

// Schreibt 'wert' in 4 Bytes ab 'position' (Gegenteil von LeseZahl).
void SchreibeZahl(byte[] daten, int position, int wert)
{
    daten[position] = (byte)(wert % 256);
    daten[position + 1] = (byte)(wert / 256 % 256);
    daten[position + 2] = (byte)(wert / (256 * 256) % 256);
    daten[position + 3] = (byte)(wert / (256 * 256 * 256) % 256);
}

// Gibt fuer ein Emoji die Farbe als int[] { rot, gruen, blau } zurueck.
int[] SymbolZuFarbe(string symbol)
{
    if (symbol == "🟦") { return new int[] { 0, 0, 255 }; }
    if (symbol == "🟫") { return new int[] { 120, 67, 21 }; }
    if (symbol == "🗻") { return new int[] { 128, 128, 128 }; }
    if (symbol == "🌳") { return new int[] { 50, 205, 50 }; }
    if (symbol == "🌲") { return new int[] { 0, 100, 0 }; }
    if (symbol == "🟨") { return new int[] { 255, 220, 0 }; }
    if (symbol == "🌴") { return new int[] { 144, 238, 144 }; }

    return new int[] { 255, 0, 255 }; // unbekannt -> pink
}

void SpeichereKarteAlsBild(string[,] karte, string pfad)
{
    int hoehe = karte.GetLength(0);
    int breite = karte.GetLength(1);
    int bytesProZeile = (breite * 3 + 3) / 4 * 4;
    int start = 54;

    byte[] daten = new byte[start + bytesProZeile * hoehe];

    // --- Kopf der Datei (Header) ---
    daten[0] = (byte)'B';
    daten[1] = (byte)'M';
    SchreibeZahl(daten, 2, daten.Length);           // Dateigroesse
    SchreibeZahl(daten, 10, start);                 // wo beginnen die Pixel?
    SchreibeZahl(daten, 14, 40);                    // Groesse des Info-Blocks
    SchreibeZahl(daten, 18, breite);
    SchreibeZahl(daten, 22, hoehe);
    daten[26] = 1;                                  // Anzahl Ebenen
    daten[28] = 24;                                 // Bits pro Pixel (3 Byte)
    SchreibeZahl(daten, 34, bytesProZeile * hoehe); // Groesse der Pixeldaten

    // --- Pixel ---
    for (int y = 0; y < hoehe; y++)
    {
        int zeileImFile = hoehe - 1 - y;
        for (int x = 0; x < breite; x++)
        {
            int position = start + zeileImFile * bytesProZeile + x * 3;
            int[] farbe = SymbolZuFarbe(karte[y, x]);

            daten[position] = (byte)farbe[2];     // Blau
            daten[position + 1] = (byte)farbe[1]; // Gruen
            daten[position + 2] = (byte)farbe[0]; // Rot
        }
    }

    File.WriteAllBytes(pfad, daten);
}
