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
        if (_nachName.ContainsKey(neu.Name) || _nachPosition.ContainsKey(neu.Position))
        {
            return false;
        }
        _nachName.Add(neu.Name, neu);
        _nachPosition.Add(neu.Position, neu);
        return true;
    }

    public bool Verbinden(string nameA, string nameB)
    {
        Switch? a = Finde(nameA);
        Switch? b = Finde(nameB);
        if (a == null || b == null)
        {
            return false;
        }
        return a.Verbinden(b);
    }

    // ---------- R - Read ----------
    public Switch? Finde(string name)
    {
        if (_nachName.TryGetValue(name, out Switch? gefunden))
        {
            return gefunden;
        }
        return null;
    }

    public Switch? An(Position position)
    {
        if (_nachPosition.TryGetValue(position, out Switch? gefunden))
        {
            return gefunden;
        }
        return null;
    }

    public double Kabellaenge(Switch a, Switch b)
    {
        return _distanz.Berechnen(a.Position, b.Position);
    }

    // jedes Kabel genau EINMAL zählen: nur wenn a vor b kommt
    public double GesamtKabel()
    {
        double summe = 0;
        foreach (Switch a in _nachName.Values)
        {
            foreach (Switch b in a.Nachbarn)
            {
                if (a.CompareTo(b) < 0)
                {
                    summe += Kabellaenge(a, b);
                }
            }
        }
        return summe;
    }

    // Länge entlang einer Route aus Switch-Namen. -1, wenn ein Switch fehlt oder zwei nicht verbunden sind.
    public double Routenlaenge(List<string> route)
    {
        double summe = 0;
        Switch? vorher = null;
        foreach (string name in route)
        {
            Switch? aktuell = Finde(name);
            if (aktuell == null)
            {
                return -1;
            }
            if (vorher != null)
            {
                if (!vorher.Nachbarn.Contains(aktuell))
                {
                    return -1;
                }
                summe += Kabellaenge(vorher, aktuell);
            }
            vorher = aktuell;
        }
        return summe;
    }

    // eine sortierte KOPIE aller Switches
    public List<Switch> Sortiert(IComparer<Switch>? vergleicher = null)
    {
        List<Switch> kopie = new List<Switch>(_nachName.Values);
        kopie.Sort(vergleicher);
        return kopie;
    }

    // der nächste Switch zu IRGENDETWAS mit Position (Laptop, Switch, ...)
    public Switch? Naechster(IHatPosition geraet)
    {
        List<Switch> sortiert = Sortiert(new NachDistanzZu(geraet.Position, _distanz));
        if (sortiert.Count == 0)
        {
            return null;
        }
        return sortiert[0];
    }

    // ---------- D - Delete ----------
    public bool Entfernen(string name)
    {
        if (!_nachName.Remove(name, out Switch? weg))
        {
            return false;
        }
        _nachPosition.Remove(weg.Position);
        // Kopie, weil Trennen die Nachbarliste verändert, während wir sie durchgehen
        List<Switch> nachbarn = new List<Switch>(weg.Nachbarn);
        foreach (Switch nachbar in nachbarn)
        {
            weg.Trennen(nachbar);
        }
        return true;
    }

    // ---------- Export ----------
    public void Exportieren(Protokoll protokoll)
    {
        foreach (Switch s in Sortiert())
        {
            protokoll.Schreiben(s.ToString());
        }
        protokoll.Schreiben($"Gesamt: {GesamtKabel():0.0} m ({Messart})");
    }
}
