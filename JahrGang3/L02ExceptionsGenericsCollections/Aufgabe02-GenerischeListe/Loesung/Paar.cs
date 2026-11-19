// Teil 2: generische Klasse mit ZWEI Typparametern.
// Links und Rechts duerfen verschiedene Typen haben.
public class Paar<TLinks, TRechts>
{
    public TLinks Links { get; }
    public TRechts Rechts { get; }

    public Paar(TLinks links, TRechts rechts)
    {
        Links = links;
        Rechts = rechts;
    }

    public override string ToString()
    {
        return Links + "|" + Rechts;
    }
}
