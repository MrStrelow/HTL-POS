// Vergleicher: die meisten Kabel zuerst (wichtigste Switches), bei Gleichstand nach Name
public class NachAnzahlKabel : IComparer<Switch>
{
    public int Compare(Switch? a, Switch? b)
    {
        if (a == null || b == null)
        {
            return string.Compare(a?.Name, b?.Name);
        }
        int vergleich = b.Nachbarn.Count.CompareTo(a.Nachbarn.Count);
        if (vergleich != 0)
        {
            return vergleich;
        }
        return a.CompareTo(b);
    }
}
