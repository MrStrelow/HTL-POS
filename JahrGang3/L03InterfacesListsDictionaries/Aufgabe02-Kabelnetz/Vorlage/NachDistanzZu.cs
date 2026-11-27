// Vergleicher MIT Zustand: Er merkt sich, zu welchem Ziel und wie gemessen wird.
// Wer näher am Ziel ist, kommt zuerst. Bei gleicher Distanz entscheidet der Name.
public class NachDistanzZu : IComparer<Switch>
{
    private Position _ziel;
    private IDistanz _distanz;

    public NachDistanzZu(Position ziel, IDistanz distanz)
    {
        _ziel = ziel;
        _distanz = distanz;
    }

    public int Compare(Switch? a, Switch? b)
    {
        if (a == null || b == null)
        {
            return string.Compare(a?.Name, b?.Name);
        }
        // TODO Teil 5: Distanz von a und von b zum Ziel berechnen und vergleichen.
        //              Gleich weit -> a.CompareTo(b)
        return 0;
    }
}
