// Das Netzwerk verwaltet seine Geräte in ZWEI Datenstrukturen:
//  - Warteschlange (List):     Reihenfolge, in der die Geräte angepingt werden
//  - ARP-Tabelle (Dictionary): MAC -> Gerät, zum schnellen Nachschlagen
public class Netzwerk
{
    private List<Geraet> _warteschlange = new List<Geraet>();
    private Dictionary<string, Geraet> _arp = new Dictionary<string, Geraet>();

    // nach außen nur lesend
    public IReadOnlyList<Geraet> Warteschlange => _warteschlange;
    public IReadOnlyDictionary<string, Geraet> Arp => _arp;

    // ---------- C - Create ----------
    public bool Anmelden(Geraet geraet)
    {
        // TODO Teil 2: MAC schon in der ARP-Tabelle -> false.
        //              Sonst in ARP-Tabelle UND Warteschlange eintragen -> true
        return false;
    }

    // ---------- R - Read ----------
    public Geraet? Finde(string mac)
    {
        // TODO Teil 3: über die ARP-Tabelle nachschlagen (TryGetValue), sonst null
        return null;
    }

    public Geraet NaechstesAnpingen()
    {
        // TODO Teil 2: leer -> InvalidOperationException
        //              sonst das erste Gerät vorne entfernen, hinten wieder anhängen, zurückgeben
        return new Geraet("", "TODO", "", 0);
    }

    public List<Geraet> Sortiert(IComparer<Geraet>? vergleicher = null)
    {
        // TODO Teil 4: KOPIE der Warteschlange sortieren und zurückgeben
        return new List<Geraet>();
    }

    public Dictionary<string, List<Geraet>> ProRaum()
    {
        // TODO Teil 5: Raum -> Liste der Geräte in diesem Raum
        return new Dictionary<string, List<Geraet>>();
    }

    // ---------- U - Update ----------
    public bool PingMessen(string mac, int pingMs)
    {
        // TODO Teil 3: Gerät finden, PingMs setzen -> true. Unbekannt -> false
        return false;
    }

    public bool Vordraengen(string mac)
    {
        // TODO Teil 2: Gerät finden, aus der Warteschlange entfernen und vorne einfügen
        return false;
    }

    // ---------- D - Delete ----------
    public bool Abmelden(string mac)
    {
        // TODO Teil 3: aus der ARP-Tabelle UND aus der Warteschlange entfernen
        return false;
    }
}
