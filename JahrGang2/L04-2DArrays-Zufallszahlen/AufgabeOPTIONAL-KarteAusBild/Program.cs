using System.Text;

Console.OutputEncoding = Encoding.UTF8; // Fuer Emojis

// ======================= Hauptprogramm =======================
string pfadBild = "../../../weltkarte.bmp";
string pfadNeuesBild = "../../../weltkarte_neu.bmp";

// TODO Teil 4: Bild laden, Karte zeichnen (siehe Angabe)


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

// (0, 0, 255) -> "🟦", (120, 67, 21) -> "🟫", (128, 128, 128) -> "🗻", sonst "💀"
string FarbeZuSymbol(int rot, int gruen, int blau)
{
    throw new NotImplementedException();
}

// ======================= Teil 3: Bild einlesen =======================

// Liest ein 24-Bit-BMP ein und wandelt jedes Pixel in ein Emoji um.
string[,] LadeKarteAusBild(string pfad)
{
    throw new NotImplementedException();
}

// Zeichne die Karte (2D-Array) auf das Terminal.
void ZeichneKarte(string[,] karte)
{
    throw new NotImplementedException();
}
