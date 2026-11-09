using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

const int MaxVersuche = 3;

Kaffeeautomat automat = new Kaffeeautomat();

// Teil 4: Hat-Beziehung auf Objektebene prüfen
Console.WriteLine($"Kennt der Wassertank genau diesen Automaten? {automat.Wassertank.Automat == automat}");
Console.WriteLine();

// ======================= Teil 5a: Bestellungen aus der CSV-Datei =======================
string[] bestellungen;
try
{
    bestellungen = LeseBestellungen("../../../bestellungen.csv");
}
catch (FileNotFoundException ex)
{
    // Ohne Datei kann das Programm nichts tun -> Meldung und Ende
    Console.WriteLine($"❌ {ex.Message}");
    return;
}

Console.WriteLine($"📋 {bestellungen.Length} gültige Bestellungen eingelesen.");
Console.WriteLine();

// ======================= Teil 5b: Bestellungen abarbeiten =======================
int index = 0;
int versuche = 0;

while (index < bestellungen.Length)
{
    string bestellung = bestellungen[index];
    bool erledigt = true;

    Console.WriteLine($"▶ Bestellung {index + 1}: {bestellung}");

    try
    {
        automat.Bruehe(bestellung);
    }
    catch (InvalidOperationException ex)
    {
        // behebbar: einschalten und dieselbe Bestellung nochmal
        Console.WriteLine($"   ⚠️ {ex.Message} → einschalten");
        automat.Einschalten();
        erledigt = false;
    }
    catch (EntkalkenNoetigException ex)
    {
        // behebbar: entkalken und nochmal
        Console.WriteLine($"   ⚠️ {ex.Message}");
        automat.Entkalken();
        erledigt = false;
    }
    catch (ZutatLeerException ex) when (ex.Zutat == "Milch")
    {
        // behebbar: Milch nachfüllen. Ein Überlauf ist erwartbar -> Rückgabewert statt Exception
        Console.WriteLine($"   ⚠️ {ex.Message} → Milch nachfüllen");
        int ueberlauf = automat.Milchtank.Auffuellen(500);
        if (ueberlauf > 0)
        {
            Console.WriteLine($"   🥛 {ueberlauf} ml Milch sind übergelaufen.");
        }
        erledigt = false;
    }
    catch (ZutatLeerException ex)
    {
        // nicht sofort behebbar: Bestellung überspringen
        Console.WriteLine($"   ❌ {ex.Message} → Bestellung wird übersprungen");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"   ❌ {ex.Message} → Bestellung wird übersprungen");
    }
    finally
    {
        // läuft IMMER – egal ob Erfolg, behandelter Fehler oder nicht
        Console.WriteLine($"   📊 {automat.Status()}");
    }

    if (erledigt)
    {
        index++;
        versuche = 0;
        continue;
    }

    // Schutz vor Endlosschleife: dieselbe Bestellung höchstens MaxVersuche-mal
    versuche++;
    if (versuche >= MaxVersuche)
    {
        Console.WriteLine($"   ❌ {MaxVersuche} Versuche – Bestellung wird übersprungen");
        index++;
        versuche = 0;
    }
}

// ======================= Teil 6: Benutzereingabe =======================
Console.WriteLine();
int menge = LeseMenge("Wie viel Gramm Bohnen nachfüllen? ");

try
{
    int ueberlauf = automat.Bohnenbehaelter.Auffuellen(menge);
    Console.WriteLine($"🫘 Aufgefüllt. Übergelaufen: {ueberlauf} g");
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"❌ {ex.Message}");
}

Console.WriteLine($"📊 {automat.Status()}");

// Eine falsche Eingabe ist ERWARTBAR -> Kontrollstruktur mit int.TryParse, keine Exception.
// Ob die Menge positiv ist, prüft NICHT diese Methode, sondern der Behälter (er kennt seine Regeln).
static int LeseMenge(string prompt)
{
    Console.Write(prompt);
    int menge;
    while (!int.TryParse(Console.ReadLine(), out menge))
    {
        Console.Write("Keine ganze Zahl! " + prompt);
    }
    return menge;
}

// Liest die Getränkenamen aus der CSV-Datei (Format: Tisch;Getraenk).
// Fehlt die DATEI, ist das ein echter Ausnahmefall: Die Methode kann ihre Aufgabe nicht erfüllen -> Exception.
// Eine kaputte ZEILE ist erwartbar (händisch getippte Datei) -> Guard mit Warnung, die Zeile wird übersprungen.
static string[] LeseBestellungen(string pfad)
{
    if (!File.Exists(pfad))
    {
        throw new FileNotFoundException($"Bestelldatei nicht gefunden: {pfad}", pfad);
    }

    string[] zeilen = File.ReadAllLines(pfad);
    string[] bestellungen = new string[zeilen.Length];
    int anzahl = 0;
    int zeilenNummer = 0;

    foreach (string rohZeile in zeilen)
    {
        zeilenNummer++;
        string zeile = rohZeile.Trim();

        // Guard 1: Leerzeile oder Kommentar -> still überspringen
        if (string.IsNullOrWhiteSpace(zeile) || zeile.StartsWith("#"))
        {
            continue;
        }

        string[] teile = zeile.Split(';');

        // Guard 2: genau zwei Spalten (Tisch;Getraenk)
        if (teile.Length != 2)
        {
            Console.WriteLine($"⚠️ Zeile {zeilenNummer} übersprungen: {teile.Length} statt 2 Spalten – \"{zeile}\"");
            continue;
        }

        string getraenk = teile[1].Trim();

        // Guard 3: Getränkename darf nicht leer sein
        if (getraenk.Length == 0)
        {
            Console.WriteLine($"⚠️ Zeile {zeilenNummer} übersprungen: kein Getränk angegeben");
            continue;
        }

        bestellungen[anzahl] = getraenk;
        anzahl++;
    }

    // Nur die befüllten Plätze zurückgeben
    string[] ergebnis = new string[anzahl];
    for (int i = 0; i < anzahl; i++)
    {
        ergebnis[i] = bestellungen[i];
    }
    return ergebnis;
}
