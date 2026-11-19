using System.Text;

Console.OutputEncoding = Encoding.UTF8;

// ---------- Teil 1: Zug<T> ----------
Console.WriteLine("--- Teil 1 ---");
Zug<int> tonnen = new Zug<int>();
tonnen.AnhaengenHinten(3);
tonnen.AnhaengenHinten(7);
tonnen.AnhaengenVorne(1);
Console.WriteLine(tonnen);

Zug<string> post = new Zug<string>();
post.AnhaengenHinten("Briefe");
post.AnhaengenHinten("Pakete");
post.Einreihen(1, "Zeitungen");
Console.WriteLine(post);
Console.WriteLine(post.Finde("Pakete"));
Console.WriteLine(post.Enthaelt("Kühe"));
// tonnen.AnhaengenHinten("acht");   // ❌ CS1503: string kann nicht in int konvertiert werden

// ---------- Teil 2: generische Methoden, zwei Typparameter ----------
Console.WriteLine("--- Teil 2 ---");
Zug<char> gleise = Bahnhof.AusArray(new char[] { 'A', 'B', 'C' });
Console.WriteLine(gleise);
Console.WriteLine(Bahnhof.Wenden(post));
Zug<Paar<string, int>> gekuppelt = Bahnhof.Kuppeln(post, tonnen);
Console.WriteLine(gekuppelt);

// ---------- Teil 3: where ----------
Console.WriteLine("--- Teil 3 ---");
Console.WriteLine(Bahnhof.Groesste(tonnen));
Console.WriteLine(Bahnhof.Groesste(post));

Zug<Holz> holzzug = Bahnhof.AusArray(new Holz[] { new Holz(10), new Holz(25), new Holz(5) });
Console.WriteLine(holzzug);
Console.WriteLine(Bahnhof.Gesamtgewicht(holzzug) + " t");
Console.WriteLine(Bahnhof.Groesste(holzzug));         // T = Holz, obwohl Holz nur IComparable<Fracht> ist

Console.WriteLine(Bahnhof.Leerzug<Kohle>(3));
Console.WriteLine(Bahnhof.Leerzug<int>(2));

Zug<string> leer = new Zug<string>();
Console.WriteLine(Bahnhof.ErsteOderNull(post));
Console.WriteLine(Bahnhof.ErsteOderNull(leer) ?? "kein Waggon");
Console.WriteLine(Bahnhof.ErsterWertOderNull(tonnen));
Console.WriteLine(Bahnhof.ErsterWertOderNull(new Zug<int>()) == null);
// Bahnhof.Gesamtgewicht(tonnen);      // ❌ CS0311: int ist keine Fracht
// Bahnhof.ErsteOderNull(tonnen);      // ❌ CS0452: int ist kein Referenztyp
// Bahnhof.ErsterWertOderNull(post);   // ❌ CS0453: string ist kein Werttyp

// ---------- Teil 4: Sortierzug<T> ----------
Console.WriteLine("--- Teil 4 ---");
Sortierzug<int> sortiert = new Sortierzug<int>();
foreach (int t in new int[] { 5, 1, 4, 1 })
{
    sortiert.Einreihen(t);
}
Console.WriteLine(sortiert);
Console.WriteLine(sortiert.Groesste());

Sortierzug<Fracht> nachGewicht = new Sortierzug<Fracht>();
nachGewicht.Einreihen(new Kohle(30));
nachGewicht.Einreihen(new Holz(10));
nachGewicht.Einreihen(new Kohle(20));
Console.WriteLine(nachGewicht);
Console.WriteLine(nachGewicht.Kleinste());

// ---------- Teil 5: Kopie der Referenz vs. ref ----------
Console.WriteLine("--- Teil 5 ---");
Holz stamm = new Holz(8);
Zug<Holz> a = new Zug<Holz>();
a.AnhaengenHinten(stamm);             // der Waggon bekommt eine Kopie der Referenz
stamm.Nachladen(4);                   // Seiteneffekt: dasselbe Objekt
Console.WriteLine(a);

Zug<Holz> b = Bahnhof.AusArray(new Holz[] { new Holz(1), new Holz(2) });
Zug<Holz> c = a;                      // c ist eine Kopie der Referenz von a
Bahnhof.Tauschen(ref a, ref b);
Console.WriteLine("a = " + a);
Console.WriteLine("b = " + b);
Console.WriteLine("c = " + c);

int links = 1;
int rechts = 2;
Bahnhof.Tauschen(ref links, ref rechts);
Console.WriteLine(links + " " + rechts);

// ---------- Teil 6: Ko- und Kontravarianz ----------
Console.WriteLine("--- Teil 6 ---");
Bahnhof.Anzeigen(holzzug);            // Zug<Holz> als IZugQuelle<Fracht>: out
// Zug<Fracht> fracht = holzzug;      // ❌ CS0029: Zug<T> ist invariant

Lager lager = new Lager();
Bahnhof.AllesEntladen(holzzug, lager); // Lager als IVerlader<Holz>: in
Console.WriteLine(lager);
Console.WriteLine(holzzug);
