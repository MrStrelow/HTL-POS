// LOESUNG des LiveCodings - So sieht Program.cs am Ende der Stunde aus.
// Diese Datei wird nicht kompiliert (siehe .csproj).

using System.Text;

Console.OutputEncoding = Encoding.UTF8; // Fuer Emojis

// ======================= Hauptprogramm =======================
string[] richtungen = { "N", "O", "S", "W" };
Random generator = new Random();

Hamster paul  = new Hamster((0, 0));
Hamster willi = new Hamster((1, 0));   // startet direkt daneben
willi.freund = paul;                   // hat-Beziehung

for (int i = 0; i < 5; i++)
{
    paul.Bewegen(richtungen[generator.Next(0, richtungen.Length)]);  // zufaellig gehen
    willi.Nachmachen();                                                // folgen
    Console.WriteLine($"paul: {paul.richtung}   willi: {willi.richtung}");
}

// ======================= Klassen =======================
class Hamster
{
    // Felder: der Zustand
    public (int x, int y) position;
    public string richtung;
    public Hamster freund;                 // hat-Beziehung

    // Konstruktor: der Startzustand
    public Hamster((int x, int y) start)
    {
        position = start;
    }

    // Methoden: das Verhalten
    public void Bewegen(string richtung)
    {
        this.richtung = richtung;
    }

    public void Nachmachen()
    {
        Bewegen(freund.richtung);          // Richtung des Freundes verwenden
    }
}
