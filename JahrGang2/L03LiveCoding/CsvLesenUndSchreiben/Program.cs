//Console.WriteLine("Hello, World!");

//string meinText = "Hello, World!";
//foreach (char buchstabe in meinText)
//{
//    Console.WriteLine(buchstabe);
//}

//string buchstabeZwei = meinText[2..7];
//Console.WriteLine(buchstabeZwei);

//string[] daten = { "Hallo=35", "HTL=85" };
//string path = "../../../hallo.txt";
//File.WriteAllLines(path, daten);

string path = "../../../hallo.txt";
string[] gelesenerInhalt = File.ReadAllLines(path);
int halloSpeicher = 0;
int htlSpeicher = 0;

foreach (string zeile in gelesenerInhalt)
{
    string[] komponenten = zeile.Split("="); // unsere einzelteile
    string name = komponenten[0].ToLower().Trim(); // 
    
    // ❌
    if (!int.TryParse(komponenten[1], out int wert))
    {
        continue;
    }

    // ✅
    if (name == "htl")
    {
        htlSpeicher += wert;
    }
    else if (
        name == "hallo" ||
        name == "hello this is" ||
        name == "hello"
    )
    {
        halloSpeicher += wert;
    }
    else
    {
        Console.WriteLine($"Der Text {name} hat keinen Speicher.");
    }
}

Console.WriteLine($"HTL: {htlSpeicher} - Hello: {halloSpeicher}");