// LiveCoding L05: Erster Kontakt mit Klassen und Objekten 🐹
// paul geht zufaellig, willi startet direkt daneben und macht alles nach.

using System.Text;

Console.OutputEncoding = Encoding.UTF8; // Fuer Emojis

string[] richtungen = { "N", "O", "S", "W" };
Random generator = new Random();

// Objekte erzeugen: alle Infos ueber den Konstruktor
Hamster paul  = new Hamster((0, 0), "🐹", null);   // paul hat keinen Freund
Hamster willi = new Hamster((1, 0), "🐭", paul);   // willi hat paul als Freund

while (true)
{
    paul.Bewegen(richtungen[generator.Next(0, richtungen.Length)]);  // zufaellig gehen
    willi.Nachmachen();                                                // folgen
    Console.WriteLine();
    Thread.Sleep(1000);
}
