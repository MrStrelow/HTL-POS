// Vergleicher: die meisten Kabel zuerst (wichtigste Switches), bei Gleichstand nach Name
public class NachAnzahlKabel : IComparer<Switch>
{
    public int Compare(Switch? a, Switch? b)
    {
        if (a == null || b == null)
        {
            return string.Compare(a?.Name, b?.Name);
        }
        // TODO Teil 5: mehr Nachbarn zuerst (absteigend!), bei Gleichstand a.CompareTo(b)
        return 0;
    }
}
