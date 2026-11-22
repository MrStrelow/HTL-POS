using System.Text;

Console.OutputEncoding = Encoding.UTF8;

// ======================= Konstanten =======================
const string Richtungen = "NOSW"; // im Uhrzeigersinn: Nord, Ost, Süd, West
(int X, int Y) startPosition = (1, 1);
const char StartRichtung = 'O';

string befehlePfad = "../../../befehle.txt";
string lagerPfad = "../../../lagerhalle.txt";
string protokollPfad = "../../../protokoll.txt";
string fehlerPfad = "../../../fehler.txt";

// ======================= Testfälle =======================
// Entferne die Kommentarzeichen /* */ eines Schritts, sobald du ihn implementiert hast.
// Vergleiche die Ausgabe mit dem erwarteten Output in der Angabe.

/* ---------- Test Schritt 1 ----------
Console.WriteLine("--- Schritt 1 ---");
Console.WriteLine(LeseDatei(befehlePfad).Length);
Console.WriteLine(LeseDatei(lagerPfad)[1]);
Console.WriteLine(LeseDatei("../../../gibtsnicht.txt").Length);
*/

/* ---------- Test Schritt 2 ----------
Console.WriteLine("--- Schritt 2 ---");
Console.WriteLine(TryBereinigeZeile("  VOR 4", out string b1) + " '" + b1 + "'");
Console.WriteLine(TryBereinigeZeile("nimm        # Paket bei (5|1)", out string b2) + " '" + b2 + "'");
Console.WriteLine(TryBereinigeZeile("VOR   3  ", out string b3) + " '" + b3 + "'");
Console.WriteLine(TryBereinigeZeile("# Kommentar", out string b4) + " '" + b4 + "'");
Console.WriteLine(TryBereinigeZeile("     ", out string b5) + " '" + b5 + "'");
Console.WriteLine(TryBereinigeZeile("ZURÜCK 1", out string b6) + " '" + b6 + "'");
Console.WriteLine(TryBereinigeZeile("vor	2", out string b7) + " '" + b7 + "'");
*/

/* ---------- Test Schritt 3 ----------
Console.WriteLine("--- Schritt 3 ---");
Console.WriteLine(TryParseBefehl("vor 4", out var p1, out string f1) + $" {p1.Name} {p1.Anzahl} [{f1}]");
Console.WriteLine(TryParseBefehl("links", out var p2, out string f2) + $" {p2.Name} {p2.Anzahl} [{f2}]");
Console.WriteLine(TryParseBefehl("spring 2", out var p3, out string f3) + $" [{f3}]");
Console.WriteLine(TryParseBefehl("vor x", out var p4, out string f4) + $" [{f4}]");
Console.WriteLine(TryParseBefehl("vor", out var p5, out string f5) + $" [{f5}]");
Console.WriteLine(TryParseBefehl("vor 0", out var p6, out string f6) + $" [{f6}]");
Console.WriteLine(TryParseBefehl("nimm 2", out var p7, out string f7) + $" [{f7}]");
Console.WriteLine(TryParseBefehl("vor -2", out var p8, out string f8) + $" [{f8}]");
Console.WriteLine(TryParseBefehl("vor 1 2", out var p9, out string f9) + $" [{f9}]");
*/

/* ---------- Test Schritt 4 ----------
Console.WriteLine("--- Schritt 4 ---");
Console.WriteLine($"{Drehe('O', "rechts")} {Drehe('O', "links")} {Drehe('W', "rechts")} {Drehe('N', "links")}");
Console.WriteLine(NaechstesFeld((5, 1), 'O'));
Console.WriteLine(NaechstesFeld((5, 1), 'S'));
Console.WriteLine(NaechstesFeld((8, 3), 'O', -1));
Console.WriteLine(NaechstesFeld((6, 6), 'N'));
*/

/* ---------- Test Schritt 5 ----------
Console.WriteLine("--- Schritt 5 ---");
string[] testLager = LeseDatei(lagerPfad);
Console.WriteLine(IstBegehbar(testLager, (1, 1)));
Console.WriteLine(IstBegehbar(testLager, (3, 2)));
Console.WriteLine(IstBegehbar(testLager, (6, 7)));
Console.WriteLine(IstBegehbar(testLager, (20, 3)));
Console.WriteLine(IstBegehbar(testLager, (-1, 0)));
*/

/* ---------- Test Schritt 6 ----------
Console.WriteLine("--- Schritt 6 ---");
string[] testLager2 = LeseDatei(lagerPfad);
SetzeZeichen(testLager2, (5, 1), '.');
Console.WriteLine(testLager2[1]);
Console.WriteLine(RoboterSymbol('S'));
foreach (string zeile in ErzeugeKarte(testLager2, (1, 1), 'O'))
{
    Console.WriteLine(zeile);
}
*/

/* ---------- Test Schritt 7 ----------
Console.WriteLine("--- Schritt 7 ---");
Console.WriteLine(ErzeugeProtokollZeile(6, "vor 4", (5, 1), 'O'));
Console.WriteLine(ErzeugeProtokollZeile(25, "zurueck 2", (6, 3), 'O'));
Console.WriteLine(ErzeugeProtokollZeile(6, "vor 4", (5, 1), 'O', 6));
Console.WriteLine(string.Join(",", Kuerze(new string[] { "a", "b", "c", "d" }, 2)));
*/

// ======================= Schritt 8: Hauptprogramm =======================
// TODO Schritt 8: Hier alles zusammenbauen (siehe Angabe).


// ======================= Schritt 1: Datei einlesen =======================

// Liefert alle Zeilen der Datei oder ein leeres Array, wenn es die Datei nicht gibt.
string[] LeseDatei(string pfad)
{
    throw new NotImplementedException();
}

// ======================= Schritt 2: Zeile bereinigen =======================

// "  VOR   3  # Kommentar" -> "vor 3"
bool TryBereinigeZeile(string zeile, out string befehl)
{
    throw new NotImplementedException();
}

// ======================= Schritt 3: Befehl zerlegen =======================

// "vor 4" -> ("vor", 4), "links" -> ("links", 1)
bool TryParseBefehl(string befehl, out (string Name, int Anzahl) ergebnis, out string fehlergrund)
{
    throw new NotImplementedException();
}

// ======================= Schritt 4: Drehen und Bewegen =======================

// 'O' + "rechts" -> 'S'
char Drehe(char richtung, string seite)
{
    throw new NotImplementedException();
}

// schritt = 1 (vor) oder -1 (zurueck)
(int X, int Y) NaechstesFeld((int X, int Y) pos, char richtung, int schritt = 1)
{
    throw new NotImplementedException();
}

// ======================= Schritt 5: Lagerhalle =======================

// false, wenn p außerhalb liegt oder eine Wand '#' ist.
bool IstBegehbar(string[] lager, (int X, int Y) p)
{
    throw new NotImplementedException();
}

// ======================= Schritt 6: Pakete und Karte =======================

// Ersetzt das Zeichen an p in der Zeile lager[p.Y].
void SetzeZeichen(string[] lager, (int X, int Y) p, char zeichen)
{
    throw new NotImplementedException();
}

// 'N' -> '^', 'O' -> '>', 'S' -> 'v', 'W' -> '<'
char RoboterSymbol(char richtung)
{
    throw new NotImplementedException();
}

// Kopie der Lagerhalle mit dem Roboter-Symbol an pos.
string[] ErzeugeKarte(string[] lager, (int X, int Y) pos, char richtung)
{
    throw new NotImplementedException();
}

// ======================= Schritt 7: Protokoll =======================

// "Zeile 06 | vor 4      |  (5|1) O"
string ErzeugeProtokollZeile(int nr, string befehl, (int X, int Y) pos, char richtung, int befehlBreite = 10)
{
    throw new NotImplementedException();
}

// Liefert ein neues Array mit nur den ersten 'anzahl' Elementen.
string[] Kuerze(string[] array, int anzahl)
{
    throw new NotImplementedException();
}
