using System.Text;

Console.OutputEncoding = Encoding.UTF8;

// Dieses Hauptprogramm ist FERTIG. Es testet von Anfang an alle Methoden.
// Je mehr du programmierst, desto mehr stimmt die Ausgabe mit der Angabe überein.

// ---------- Teil 1: Position und Distanzen ----------
Console.WriteLine("--- Teil 1: Distanzen ---");
Position server = new Position(0, 0);
Position ost = new Position(30, 40);
IDistanz luft = new Luftlinie();
IDistanz kanal = new Kabelkanal();
IDistanz hops = new Hops();
Console.WriteLine($"{luft.Name}: {luft.Berechnen(server, ost):0.0} m");
Console.WriteLine($"{kanal.Name}: {kanal.Berechnen(server, ost):0.0} m");
Console.WriteLine($"{hops.Name}: {hops.Berechnen(server, ost):0.0}");
Console.WriteLine(ost == new Position(30, 40));            // record: gleiche Werte -> gleich

// ---------- Teil 2: Switch und Kabel (List) ----------
Console.WriteLine("--- Teil 2: Kabel ---");
Switch s1 = new Switch("Server", server);
Switch s2 = new Switch("Ost", ost);
Switch s3 = new Switch("Labor", new Position(30, 0));
Console.WriteLine(s1.Verbinden(s2));
Console.WriteLine(s1.Verbinden(s2));                       // schon verbunden -> false
Console.WriteLine(s1.Verbinden(s1));                       // mit sich selbst -> false
Console.WriteLine(s2.Nachbarn.Count);                      // das Kabel hat ZWEI Enden
Console.WriteLine(s1.CompareTo(s2) > 0);                   // "Server" kommt nach "Ost"
Console.WriteLine(s1.Trennen(s2));
Console.WriteLine(s1.Trennen(s3));
Console.WriteLine(s1);

// ---------- Teil 3: Kabelnetz (Dictionary) ----------
Console.WriteLine("--- Teil 3: Kabelnetz ---");
Kabelnetz netz = Aufbauen(new Luftlinie());
Console.WriteLine(netz.Switches.Count + " Switches");
Console.WriteLine(netz.Hinzufuegen(new Switch("Ost", new Position(99, 99))));   // Name vergeben
Console.WriteLine(netz.Hinzufuegen(new Switch("Neu", new Position(30, 40))));   // Platz belegt
Console.WriteLine(netz.Finde("Labor"));
Console.WriteLine(netz.Finde("Keller") == null);
Console.WriteLine(netz.An(new Position(0, 20)));            // NEUES Position-Objekt als Key
Console.WriteLine(netz.Verbinden("Labor", "Keller"));
Console.WriteLine(netz.Finde("Ost") == netz.An(new Position(30, 40)));   // dasselbe Objekt

// ---------- Teil 4: Kabellängen mit austauschbarer Distanz (DI) ----------
Console.WriteLine("--- Teil 4: Kabellängen ---");
List<string> direkt = new List<string> { "Server", "Ost" };
List<string> umweg = new List<string> { "Server", "Labor", "Ost" };
List<string> kaputt = new List<string> { "West", "Ost" };
foreach (IDistanz distanz in new List<IDistanz> { new Luftlinie(), new Kabelkanal(), new Hops() })
{
    Kabelnetz n = Aufbauen(distanz);
    Console.WriteLine($"{n.Messart,-10} gesamt {n.GesamtKabel(),5:0.0} · direkt {n.Routenlaenge(direkt),4:0.0} · Umweg {n.Routenlaenge(umweg),4:0.0} · kaputt {n.Routenlaenge(kaputt)}");
}

// ---------- Teil 5: Sortieren und der nächste Switch ----------
Console.WriteLine("--- Teil 5: Sortieren ---");
Console.WriteLine("nach Name:");
foreach (Switch s in netz.Sortiert())
{
    Console.WriteLine("  " + s);
}
Console.WriteLine("nach Anzahl Kabel:");
foreach (Switch s in netz.Sortiert(new NachAnzahlKabel()))
{
    Console.WriteLine("  " + s);
}
Laptop laptop = new Laptop("Laptop Anna", new Position(25, 35));
Console.WriteLine("nach Distanz zu " + laptop.Name + ":");
foreach (Switch s in netz.Sortiert(new NachDistanzZu(laptop.Position, new Luftlinie())))
{
    Console.WriteLine("  " + s);
}
Console.WriteLine("nächster zu " + laptop.Name + ": " + netz.Naechster(laptop)?.Name);
Console.WriteLine("nächster zu Labor: " + netz.Naechster(netz.Finde("Labor")!)?.Name);

// ---------- Teil 6: Entfernen und Protokoll (IDisposable) ----------
Console.WriteLine("--- Teil 6: Entfernen und Protokoll ---");
Console.WriteLine(netz.Entfernen("Ost"));
Console.WriteLine(netz.Entfernen("Ost"));
Console.WriteLine(netz.An(new Position(30, 40)) == null);
Console.WriteLine(netz.Finde("Labor"));                    // ein Kabel weniger
using (Protokoll protokoll = new Protokoll("kabelnetz.txt"))
{
    netz.Exportieren(protokoll);
    Console.WriteLine(protokoll.Zeilen + " Zeilen geschrieben");
}
try
{
    foreach (string zeile in File.ReadAllLines("kabelnetz.txt"))
    {
        Console.WriteLine("  " + zeile);
    }
}
catch (IOException)
{
    Console.WriteLine("Datei ist noch gesperrt – schließt Dispose() den StreamWriter?");
}

// Composition Root: HIER wird entschieden, wie gemessen wird – nicht im Kabelnetz
static Kabelnetz Aufbauen(IDistanz distanz)
{
    Kabelnetz netz = new Kabelnetz(distanz);
    netz.Hinzufuegen(new Switch("Server", new Position(0, 0)));
    netz.Hinzufuegen(new Switch("Ost", new Position(30, 40)));
    netz.Hinzufuegen(new Switch("West", new Position(0, 20)));
    netz.Hinzufuegen(new Switch("Labor", new Position(30, 0)));
    netz.Hinzufuegen(new Switch("Bibliothek", new Position(60, 40)));
    netz.Verbinden("Server", "Ost");
    netz.Verbinden("Server", "West");
    netz.Verbinden("Server", "Labor");
    netz.Verbinden("Labor", "Ost");
    netz.Verbinden("Ost", "Bibliothek");
    return netz;
}
