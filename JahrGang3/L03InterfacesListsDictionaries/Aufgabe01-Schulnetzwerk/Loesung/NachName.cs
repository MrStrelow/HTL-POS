// Vergleicher-Klasse: eine weitere Sortierung, ohne Geraet zu ändern (IComparer<Geraet>)
public class NachName : IComparer<Geraet>
{
    public int Compare(Geraet? a, Geraet? b)
    {
        return string.Compare(a?.Name, b?.Name);
    }
}
