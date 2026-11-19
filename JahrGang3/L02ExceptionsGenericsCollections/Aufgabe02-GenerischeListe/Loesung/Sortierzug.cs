// Teil 4: generische Klasse mit Einschraenkung.
// Das where steht bei der KLASSE, weil die ganze Klasse vergleichen muss.
public class Sortierzug<T> where T : IComparable<T>
{
    private Zug<T> zug = new Zug<T>();

    public int Count
    {
        get { return zug.Count; }
    }

    public void Einreihen(T ladung)
    {
        int position = 0;
        Waggon<T>? curr = zug.Head;

        // erste Position suchen, an der eine groessere Ladung steht
        while (curr != null && curr.Ladung.CompareTo(ladung) <= 0)
        {
            curr = curr.Next;
            position++;
        }

        zug.Einreihen(position, ladung);
    }

    public T Kleinste()
    {
        return zug.Get(0);
    }

    public T Groesste()
    {
        return zug.Get(zug.Count - 1);
    }

    public override string ToString()
    {
        return zug.ToString();
    }
}
