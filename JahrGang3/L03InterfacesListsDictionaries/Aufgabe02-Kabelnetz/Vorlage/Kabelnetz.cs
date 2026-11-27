// Das Kabelnetz verwaltet seine Switches in ZWEI Dictionaries:
//  - nach Name:     string   -> Switch
//  - nach Position: Position -> Switch  (record als Key: Wertsemantik!)
// Wie Distanzen gerechnet werden, bekommt es von AUSSEN (Dependency Injection).
public class Kabelnetz
{
    private IDistanz _distanz;
    private Dictionary<string, Switch> _nachName;
    private Dictionary<Position, Switch> _nachPosition;

    public IReadOnlyDictionary<string, Switch> Switches { get { return _nachName; } }
    public string Messart { get { return _distanz.Name; } }

    public Kabelnetz(IDistanz distanz, int kapazitaet = 16)
    {
        _distanz = distanz;
        _nachName = new Dictionary<string, Switch>(kapazitaet);
        _nachPosition = new Dictionary<Position, Switch>(kapazitaet);
    }

    // ---------- C - Create ----------
    public bool Hinzufuegen(Switch neu)
    {
        // TODO Teil 3: Name ODER Position schon vergeben -> false
        //              sonst in BEIDE Dictionaries eintragen -> true
        return false;
    }

    public bool Verbinden(string nameA, string nameB)
    {
        // TODO Teil 3: beide Switches finden (unbekannt -> false), dann a.Verbinden(b)
        return false;
    }

    // ---------- R - Read ----------
    public Switch? Finde(string name)
    {
        // TODO Teil 3: TryGetValue
        return null;
    }

    public Switch? An(Position position)
    {
        // TODO Teil 3: TryGetValue im zweiten Dictionary
        return null;
    }

    public double Kabellaenge(Switch a, Switch b)
    {
        // TODO Teil 4: _distanz rechnen lassen
        return 0;
    }

    // jedes Kabel genau EINMAL zählen: nur wenn a vor b kommt
    public double GesamtKabel()
    {
        // TODO Teil 4: alle Switches, alle Nachbarn – nur wenn a.CompareTo(b) < 0
        return 0;
    }

    // Länge entlang einer Route aus Switch-Namen. -1, wenn ein Switch fehlt oder zwei nicht verbunden sind.
    public double Routenlaenge(List<string> route)
    {
        // TODO Teil 4: foreach über die Namen, den vorherigen Switch mitmerken
        return 0;
    }

    // eine sortierte KOPIE aller Switches
    public List<Switch> Sortiert(IComparer<Switch>? vergleicher = null)
    {
        List<Switch> kopie = new List<Switch>(_nachName.Values);
        // TODO Teil 5: kopie sortieren
        return kopie;
    }

    // der nächste Switch zu IRGENDETWAS mit Position (Laptop, Switch, ...)
    public Switch? Naechster(IHatPosition geraet)
    {
        // TODO Teil 5: Sortiert(new NachDistanzZu(...)) – das erste Element, leer -> null
        return null;
    }

    // ---------- D - Delete ----------
    public bool Entfernen(string name)
    {
        // TODO Teil 6: aus BEIDEN Dictionaries entfernen und alle Kabel trennen.
        //              Achtung: nicht über weg.Nachbarn laufen, während Trennen sie verändert -> Kopie!
        return false;
    }

    // ---------- Export ----------
    public void Exportieren(Protokoll protokoll)
    {
        // TODO Teil 6: jeden Switch (nach Name sortiert) als Zeile schreiben,
        //              danach "Gesamt: 50,0 m (Luftlinie)"
    }
}
