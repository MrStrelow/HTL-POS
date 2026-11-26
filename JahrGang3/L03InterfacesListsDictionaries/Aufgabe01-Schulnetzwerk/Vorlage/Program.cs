using System.Text;

Console.OutputEncoding = Encoding.UTF8;

// Dieses Hauptprogramm ist FERTIG. Es testet von Anfang an alle Methoden.
// Je mehr du programmierst, desto mehr stimmt die Ausgabe mit der Angabe überein.

// ---------- Teil 1: Geraet ----------
Console.WriteLine("--- Teil 1: Geraet ---");
Geraet laptop = new Geraet("B2:02", "Laptop", "E12", 95);
Geraet kopie = new Geraet("B2:02", "Laptop", "E12", 300);
Geraet drucker = new Geraet("A1:17", "Drucker", "E12", 120);
Console.WriteLine(laptop);
Console.WriteLine(laptop.CompareTo(drucker) < 0);
Console.WriteLine(drucker.CompareTo(laptop) > 0);
Console.WriteLine(laptop.Equals(kopie));
Console.WriteLine(laptop.GetHashCode() == kopie.GetHashCode());
Console.WriteLine(laptop.Equals(drucker));

// ---------- Teil 2: Anmelden und Warteschlange (List) ----------
Console.WriteLine("--- Teil 2: Warteschlange ---");
Netzwerk netz = new Netzwerk();
Console.WriteLine(netz.Anmelden(drucker));
Console.WriteLine(netz.Anmelden(laptop));
Console.WriteLine(netz.Anmelden(new Geraet("C3:33", "Beamer", "E14", 140)));
Console.WriteLine(netz.Anmelden(new Geraet("00:01", "Router", "Keller", 110)));
Console.WriteLine(netz.Anmelden(new Geraet("D4:08", "Switch", "E14", 95)));
Console.WriteLine(netz.Anmelden(kopie));                  // gleiche MAC -> false
Console.WriteLine(netz.Warteschlange.Count + " Geräte");
Console.WriteLine("angepingt: " + netz.NaechstesAnpingen().Name);
Console.WriteLine("angepingt: " + netz.NaechstesAnpingen().Name);
Console.WriteLine(netz.Vordraengen("00:01"));
Console.WriteLine(netz.Vordraengen("FF:99"));
foreach (Geraet g in netz.Warteschlange)
{
    Console.WriteLine("  " + g);
}

// ---------- Teil 3: ARP-Tabelle (Dictionary) ----------
Console.WriteLine("--- Teil 3: ARP-Tabelle ---");
Console.WriteLine(netz.Finde("C3:33"));
Console.WriteLine(netz.Finde("FF:99") == null);
Console.WriteLine(netz.PingMessen("C3:33", 80));
Console.WriteLine(netz.PingMessen("FF:99", 10));
if (netz.Warteschlange.Count > 1)
{
    Console.WriteLine(netz.Warteschlange[1]);             // dasselbe Objekt -> auch 80 ms
}
Console.WriteLine(netz.Abmelden("A1:17"));
Console.WriteLine(netz.Abmelden("A1:17"));
Console.WriteLine(netz.Arp.Count + " in ARP, " + netz.Warteschlange.Count + " in der Warteschlange");

// ---------- Teil 4: Sortieren mit IComparable und IComparer ----------
Console.WriteLine("--- Teil 4: Sortieren ---");
Console.WriteLine("nach Ping:");
foreach (Geraet g in netz.Sortiert())
{
    Console.WriteLine("  " + g);
}
Console.WriteLine("nach Name:");
foreach (Geraet g in netz.Sortiert(new NachName()))
{
    Console.WriteLine("  " + g);
}
Console.WriteLine("nach Raum:");
foreach (Geraet g in netz.Sortiert(new NachRaum()))
{
    Console.WriteLine("  " + g);
}
if (netz.Warteschlange.Count > 0)
{
    Console.WriteLine("erstes in der Warteschlange: " + netz.Warteschlange[0].Name);
}

// ---------- Teil 5: Dictionary mit Listen ----------
Console.WriteLine("--- Teil 5: pro Raum ---");
foreach ((string raum, List<Geraet> geraete) in netz.ProRaum())
{
    Console.Write(raum + ":");
    foreach (Geraet g in geraete)
    {
        Console.Write(" " + g.Name);
    }
    Console.WriteLine();
}
