// LiveCoding: Eine Weltkarte aus Emojis einlesen, Baeume pflanzen und speichern.
// Das gemeinsame Ergebnis steht in Loesung.cs - und ist die Vorlage fuer Aufgabe01-WeltenGenerieren.
//
// Ablauf (gemeinsam):
//   1) weltkarte.txt anschauen: 32 Zeilen, je 32 Emojis. 🟦 Wasser, 🟫 Erde, 🗻 Stein
//      Frage: Warum ist "🟦".Length == 2?  -> Ein Emoji besteht aus zwei char.
//   2) LadeKarte:     File.ReadAllLines (1D) -> new string[hoehe, breite] (2D), Substring(x * 2, 2)
//   3) ZeichneKarte:  verschachtelte for-Schleife, aussen y (Zeilen), innen x (Spalten)
//   4) KopiereKarte:  Warum brauchen wir eine Kopie? (Referenztypen, L02)
//   5) PflanzeBaeume: Random mit Seed, while-Schleife, Next(0, GetLength(...)), NextDouble() < 0.1
//   6) SpeichereKarte: 2D -> string[] (1D) -> File.WriteAllLines

using System.Text;

Console.OutputEncoding = Encoding.UTF8; // Fuer Emojis

// ======================= Hauptprogramm =======================
string pfadOhneBaeume = "../../../weltkarte.txt";
string pfadMitBaeumen = "../../../weltkarte_mit_baeumen.txt";


// ======================= Funktionen =======================

// --- Zustaendigkeit der Funktion ---
// Liest das Textfile ein und wandelt es in ein 2D-Array um.
string[,] LadeKarte(string pfad)
{
    throw new NotImplementedException();
}

// --- Zustaendigkeit der Funktion ---
// Zeichne die Karte (2D-Array) auf das Terminal.
void ZeichneKarte(string[,] karte)
{
    throw new NotImplementedException();
}
