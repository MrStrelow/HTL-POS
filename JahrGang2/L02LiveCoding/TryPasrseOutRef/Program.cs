using System.Text;

Console.OutputEncoding = Encoding.UTF8;

void ZahlenEinlesen(string nachricht)
{
    int usereingabe;

    Console.Write(nachricht);
    // ❌
    while (!int.TryParse(Console.ReadLine(), out usereingabe))
    {
        Console.WriteLine($"❌ Ungültige Eingabe! {usereingabe} Bitte eine Zahl eingeben.");
    }

    // ✅
    usereingabe++;
}

ZahlenEinlesen("Wie viele Elektronik-Container sollen vorne gelagert werden?: ");
ZahlenEinlesen("Bitte gib deine Größe ein: ");


