using System.Text;

Console.OutputEncoding = Encoding.UTF8;

// Der Zug kann im Moment nur int (Tonnen) transportieren.
Zug zug = new Zug();
zug.AnhaengenHinten(3);
zug.AnhaengenHinten(7);
zug.AnhaengenVorne(1);
Console.WriteLine(zug);                     // 🚂-[1]-[3]-[7]
Console.WriteLine(zug.Finde(7));            // 2

// TODO Teil 1: Zug<int> und Zug<string> verwenden
// TODO Teil 2: Bahnhof und Paar<TA, TB> testen
// TODO Teil 3: Einschraenkungen mit where testen
// TODO Teil 4: Sortierzug<T> testen
// TODO Teil 5: Kopie der Referenz vs. ref
// TODO Teil 6: IZugQuelle<out T> und IVerlader<in T> testen
