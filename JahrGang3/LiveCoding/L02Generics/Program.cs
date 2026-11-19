// L02 Generics - gemeinsam programmieren
// Ablauf wie im Skriptum: L02.2_Generics.html
// Die ❌-Zeilen kurz einkommentieren, Fehler zeigen, wieder auskommentieren.

using System.Text;

Console.OutputEncoding = Encoding.UTF8;

// =====================================================================
// Schritt 1: Polymorphie - dynamisch vs. statisch
// =====================================================================
Console.WriteLine("--- Schritt 1 ---");

// dynamisch: EIN Code (Geraeusch) fuer viele Typen, entschieden zur LAUFZEIT
Tier[] tiere = { new Hund("Rex", 5), new Katze("Mia", 3) };
foreach (Tier t in tiere)
{
    Console.WriteLine(t.Name + ": " + t.Geraeusch());
}

// Problem: Tauschen fuer int UND string -> zwei fast gleiche Methoden (Ueberladen)
int x = 1, y = 2;
TauscheInt(ref x, ref y);
Console.WriteLine(x + " " + y);

// Idee 1: object - geht fuer alles, aber der Fehler kommt erst zur LAUFZEIT
object o1 = 1, o2 = "zwei";
TauscheObject(ref o1, ref o2);
// int kaputt = (int)o1;                  // 💥 InvalidCastException zur Laufzeit

// Idee 2: Generics - EIN Code, Typ steht beim KOMPILIEREN fest (statische Polymorphie)
string s1 = "🐶", s2 = "🐱";
Tausche(ref s1, ref s2);
Console.WriteLine(s1 + " " + s2);
// Tausche(ref x, ref s1);                // ❌ CS0411: T kann nicht int UND string sein

// =====================================================================
// Schritt 2: generische Methode - Typ wird erkannt
// =====================================================================
Console.WriteLine("--- Schritt 2 ---");
Console.WriteLine(Erstes(new int[] { 4, 9, 2 }));          // T = int (erkannt)
Console.WriteLine(Erstes<string>(new string[] { "Ab" }));  // T = string (angegeben)

// zwei Typparameter: die beiden Arrays duerfen verschiedene Typen haben
ZeigePaare(new string[] { "Ana", "Ben" }, new int[] { 12, 30 });

// =====================================================================
// Schritt 3: generische Klasse
// =====================================================================
Console.WriteLine("--- Schritt 3 ---");
Ablage<string> obst = new Ablage<string>();
obst.Lege("🍎");
obst.Lege("🍌");
Console.WriteLine(obst.Nimm());           // 🍌 - zuletzt hineingelegt
Console.WriteLine(obst.Anzahl);

Ablage<int> zahlen = new Ablage<int>(2);
zahlen.Lege(42);
// zahlen.Lege("43");                     // ❌ CS1503: string ist kein int

// =====================================================================
// Schritt 4: where - was kann T?
// =====================================================================
Console.WriteLine("--- Schritt 4 ---");
Console.WriteLine(Groesser(3, 8));                 // 8
Console.WriteLine(Groesser("Hund", "Affe"));       // Hund
// Groesser(new Tier("A", 1), new Tier("B", 2));    // ❌ CS0311: Tier ist nicht IComparable<Tier>

Rangliste<string, int> rangliste = new Rangliste<string, int>();
rangliste.Eintragen("Ana", 12);
rangliste.Eintragen("Ben", 30);
rangliste.Eintragen("Cem", 21);
Console.WriteLine(rangliste.Bester());             // Ben

Console.WriteLine(ErstesOderNull(new string[0]) ?? "null");   // where T : class
Console.WriteLine(WertOder<int>(null, 7));                    // where T : struct
// ErstesOderNull(new int[] { 1 });                // ❌ CS0452: int ist keine class

// =====================================================================
// Schritt 5: where T : class vs. ref T t
// =====================================================================
Console.WriteLine("--- Schritt 5 ---");
Hund h = new Hund("Rex", 5);
Ablage<Hund> zwinger = new Ablage<Hund>();
zwinger.Lege(h);                          // Kopie der Referenz: beide zeigen auf Rex
h.Name = "Max";                           // Seiteneffekt am OBJEKT
Console.WriteLine(zwinger.Nimm().Name);   // Max

Hund anderer = new Hund("Bello", 2);
Tausche(ref h, ref anderer);              // ref: die VARIABLEN werden getauscht
Console.WriteLine(h.Name + " " + anderer.Name);   // Bello Max

// =====================================================================
// Schritt 6: Ko- und Kontravarianz
// =====================================================================
Console.WriteLine("--- Schritt 6 ---");

// Problem: Arrays sind kovariant - der Fehler kommt erst zur Laufzeit
Hund[] hundeArray = { new Hund("Rex", 5), new Hund("Bello", 2) };
Tier[] tierArray = hundeArray;
// tierArray[1] = new Katze("Mia", 3);    // 💥 ArrayTypeMismatchException

// List<T> ist invariant
List<Hund> hunde = new List<Hund> { new Hund("Rex", 5), new Hund("Bello", 2), new Hund("Luna", 8) };
// List<Tier> tierListe = hunde;          // ❌ CS0029: sonst ginge tierListe.Add(new Katze(...))

// out: IEnumerable<out T> - T kommt nur heraus
AlleRufen(hunde);

// in: IComparer<in T> - T geht nur hinein
IComparer<Hund> vergleicher = new NachAlter();
hunde.Sort(vergleicher);
foreach (Hund hund in hunde)
{
    Console.Write(hund + " ");
}
Console.WriteLine();

// =====================================================================
// Methoden
// =====================================================================
void TauscheInt(ref int a, ref int b)
{
    int temp = a;
    a = b;
    b = temp;
}

void TauscheObject(ref object a, ref object b)
{
    object temp = a;
    a = b;
    b = temp;
}

void Tausche<T>(ref T a, ref T b)
{
    T temp = a;
    a = b;
    b = temp;
}

T Erstes<T>(T[] werte)
{
    return werte[0];
}

void ZeigePaare<TA, TB>(TA[] links, TB[] rechts)
{
    for (int i = 0; i < links.Length && i < rechts.Length; i++)
    {
        Console.WriteLine(links[i] + " - " + rechts[i]);
    }
}

T Groesser<T>(T a, T b) where T : IComparable<T>
{
    // if (a > b)                         // ❌ CS0019: > gibt es nicht fuer jedes T
    if (a.CompareTo(b) > 0)
    {
        return a;
    }
    return b;
}

T? ErstesOderNull<T>(T[] werte) where T : class
{
    if (werte.Length == 0)
    {
        return null;
    }
    return werte[0];
}

T WertOder<T>(T? wert, T ersatz) where T : struct
{
    if (wert.HasValue)
    {
        return wert.Value;
    }
    return ersatz;
}

void AlleRufen(IEnumerable<Tier> alle)
{
    foreach (Tier t in alle)
    {
        Console.WriteLine(t.Name + ": " + t.Geraeusch());
    }
}
