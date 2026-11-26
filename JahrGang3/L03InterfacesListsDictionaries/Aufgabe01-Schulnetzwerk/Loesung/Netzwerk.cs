// Das Netzwerk verwaltet seine Geräte in ZWEI Datenstrukturen:
//  - Warteschlange (List):  Reihenfolge, in der die Geräte angepingt werden
//  - ARP-Tabelle (Dictionary): MAC -> Gerät, zum schnellen Nachschlagen
// Beide speichern REFERENZEN auf dieselben Geraet-Objekte.
public class Netzwerk
{
    private List<Geraet> _warteschlange = new List<Geraet>();
    private Dictionary<string, Geraet> _arp = new Dictionary<string, Geraet>();

    // nach außen nur lesend (Interfaces!) -> niemand kann an Netzwerk vorbei einfügen
    public IReadOnlyList<Geraet> Warteschlange => _warteschlange;
    public IReadOnlyDictionary<string, Geraet> Arp => _arp;

    // ---------- C - Create ----------
    public bool Anmelden(Geraet geraet)
    {
        // Guard: MAC schon im Netz
        if (!_arp.TryAdd(geraet.Mac, geraet))
        {
            return false;
        }
        _warteschlange.Add(geraet);
        return true;
    }

    // ---------- R - Read ----------
    public Geraet? Finde(string mac)
    {
        if (_arp.TryGetValue(mac, out Geraet? geraet))
        {
            return geraet;
        }
        return null;
    }

    // Round Robin: das erste Gerät wird angepingt und kommt wieder hinten dran
    public Geraet NaechstesAnpingen()
    {
        if (_warteschlange.Count == 0)
        {
            throw new InvalidOperationException("Keine Geräte im Netz.");
        }
        Geraet erstes = _warteschlange[0];
        _warteschlange.RemoveAt(0);
        _warteschlange.Add(erstes);
        return erstes;
    }

    // eine sortierte KOPIE - die Warteschlange selbst bleibt unverändert
    public List<Geraet> Sortiert(IComparer<Geraet>? vergleicher = null)
    {
        List<Geraet> kopie = new List<Geraet>(_warteschlange);
        kopie.Sort(vergleicher);           // null -> IComparable (CompareTo)
        return kopie;
    }

    // Dictionary mit Listen als Value: Raum -> Geräte in diesem Raum
    public Dictionary<string, List<Geraet>> ProRaum()
    {
        Dictionary<string, List<Geraet>> raeume = new Dictionary<string, List<Geraet>>();
        foreach (Geraet geraet in _warteschlange)
        {
            if (!raeume.TryGetValue(geraet.Raum, out List<Geraet>? liste))
            {
                liste = new List<Geraet>();
                raeume[geraet.Raum] = liste;
            }
            liste.Add(geraet);
        }
        return raeume;
    }

    // ---------- U - Update ----------
    public bool PingMessen(string mac, int pingMs)
    {
        Geraet? geraet = Finde(mac);
        if (geraet == null)
        {
            return false;
        }
        geraet.PingMs = pingMs;       // Referenz -> auch in der Warteschlange geändert
        return true;
    }

    // wichtiges Gerät ganz nach vorne in die Warteschlange
    public bool Vordraengen(string mac)
    {
        Geraet? geraet = Finde(mac);
        if (geraet == null)
        {
            return false;
        }
        _warteschlange.Remove(geraet);
        _warteschlange.Insert(0, geraet);
        return true;
    }

    // ---------- D - Delete ----------
    public bool Abmelden(string mac)
    {
        if (!_arp.Remove(mac, out Geraet? geraet))
        {
            return false;
        }
        _warteschlange.Remove(geraet);   // aus BEIDEN Strukturen entfernen
        return true;
    }
}
