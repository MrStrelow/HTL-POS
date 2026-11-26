// Vergleicher-Klasse: zuerst nach Raum, im selben Raum nach Name (IComparer<Geraet>)
public class NachRaum : IComparer<Geraet>
{
    public int Compare(Geraet? a, Geraet? b)
    {
        int vergleich = string.Compare(a?.Raum, b?.Raum);
        if (vergleich != 0)
        {
            return vergleich;
        }
        return string.Compare(a?.Name, b?.Name);
    }
}
