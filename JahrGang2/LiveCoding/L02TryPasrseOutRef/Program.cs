using System.Text;

Console.OutputEncoding = Encoding.UTF8;

int ZahlenEinlesen(string nachricht)
{
    int usereingabe;

    Console.Write(nachricht);
    // ❌
    while (!int.TryParse(Console.ReadLine(), out usereingabe))
    {
        Console.WriteLine($"❌ Ungültige Eingabe! {usereingabe} Bitte eine Zahl eingeben.");
    }

    // ✅
    return usereingabe;
}

int ZahlenEinlesenMitAusgabeDesFehlersBekannt(string nachricht)
{
    int usereingabe;

    Console.Write(nachricht);

    // ❌
    while (true)
    {
        string usereingabeAlsString = Console.ReadLine();
        
        if (!int.TryParse(usereingabeAlsString, out usereingabe))
        {
            Console.Clear();
            Console.Write(nachricht);
            Console.WriteLine($"❌ Ungültige Eingabe! {usereingabeAlsString} Bitte eine Zahl eingeben.");
        }
        else
        {
            break;
        }
    }

    // ✅
    return usereingabe;
}

int ZahlenEinlesenMitAusgabeDesFehlerKompakt(string nachricht)
{
    int usereingabe;
    string usereingabeAlsString;

    Console.Write(nachricht);

    // ❌
    while (!int.TryParse(usereingabeAlsString = Console.ReadLine(), out usereingabe))
    {
        Console.Clear();
        Console.Write(nachricht);
        Console.WriteLine($"❌ Ungültige Eingabe! {usereingabeAlsString} Bitte eine Zahl eingeben.");
    }

    // ✅
    return usereingabe;
}

// return geht verloren. Kein = neben der Funktion.
ZahlenEinlesenMitAusgabeDesFehlersBekannt("Wie viele Elektronik-Container sollen vorne gelagert werden?: ");
ZahlenEinlesenMitAusgabeDesFehlerKompakt("Wie viele Elektronik-Container sollen vorne gelagert werden?: ");

int containerCount = ZahlenEinlesen("Wie viele Elektronik-Container sollen vorne gelagert werden?: ");
int size = ZahlenEinlesen("Bitte gib deine Größe ein: ");

Console.WriteLine($"Container: {containerCount}, Größe: {size}");
