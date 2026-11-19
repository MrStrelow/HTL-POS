// Teil 1: Zug<T> – jedes int, das eine Ladung war, wird zu T.
// Positionen und Count bleiben int.
// Teil 6: Zug<T> setzt IZugQuelle<T> um (Count und Get gibt es schon).
public class Zug<T> : IZugQuelle<T>
{
    public Waggon<T>? Head { get; private set; }
    public Waggon<T>? Tail { get; private set; }
    public int Count { get; private set; }

    public void AnhaengenVorne(T ladung)
    {
        Waggon<T> waggon = new Waggon<T>(ladung);

        if (Head == null)
        {
            Head = waggon;
            Tail = waggon;
        }
        else
        {
            waggon.Next = Head;
            Head.Prev = waggon;
            Head = waggon;
        }

        Count++;
    }

    public void AnhaengenHinten(T ladung)
    {
        Waggon<T> waggon = new Waggon<T>(ladung);

        if (Tail == null)
        {
            Head = waggon;
            Tail = waggon;
        }
        else
        {
            Tail.Next = waggon;
            waggon.Prev = Tail;
            Tail = waggon;
        }

        Count++;
    }

    public void Einreihen(int position, T ladung)
    {
        // Guard: ungewuenschter Zustand ❌
        if (position < 0 || position > Count)
        {
            throw new ArgumentOutOfRangeException(nameof(position), "Ungültige Position zum Einreihen.");
        }

        // Sonderfaelle delegieren ✅
        if (position == 0)
        {
            AnhaengenVorne(ladung);
            return;
        }

        if (position == Count)
        {
            AnhaengenHinten(ladung);
            return;
        }

        Waggon<T> curr = GetWaggonAt(position);
        Waggon<T> prev = curr.Prev ?? throw new InvalidOperationException("Vorheriger Waggon ist null.");

        Waggon<T> neu = new Waggon<T>(ladung);
        neu.Prev = prev;
        neu.Next = curr;
        prev.Next = neu;
        curr.Prev = neu;

        Count++;
    }

    public T AbkuppelnVorne()
    {
        // ungewuenschter Zustand ❌
        if (Head == null)
        {
            throw new InvalidOperationException("Der Zug hat keine Waggons.");
        }

        // gewuenschter Zustand ✅
        T ladung = Head.Ladung;
        Head = Head.Next;

        if (Head != null)
        {
            Head.Prev = null;
        }
        else
        {
            Tail = null;
        }

        Count--;
        return ladung;
    }

    public T Get(int position)
    {
        return GetWaggonAt(position).Ladung;
    }

    public int Finde(T ladung)
    {
        Waggon<T>? curr = Head;
        int position = 0;

        while (curr != null)
        {
            // == ist nicht fuer jeden Typ T definiert, Equals kann jedes Objekt
            if (Equals(curr.Ladung, ladung))
            {
                return position;
            }
            curr = curr.Next;
            position++;
        }

        return -1;
    }

    public bool Enthaelt(T ladung)
    {
        return Finde(ladung) != -1;
    }

    public T Umladen(int position, T neueLadung)
    {
        Waggon<T> waggon = GetWaggonAt(position);
        T alteLadung = waggon.Ladung;
        waggon.Ladung = neueLadung;
        return alteLadung;
    }

    private Waggon<T> GetWaggonAt(int position)
    {
        // Guard: ungewuenschter Zustand ❌
        if (position < 0 || position >= Count)
        {
            throw new ArgumentOutOfRangeException(nameof(position));
        }

        // gewuenschter Zustand ✅
        Waggon<T>? curr = Head;
        for (int i = 0; i < position; i++)
        {
            curr = curr?.Next;
        }

        return curr ?? throw new InvalidOperationException("Waggon konnte nicht gefunden werden.");
    }

    public override string ToString()
    {
        string text = "🚂";
        Waggon<T>? curr = Head;
        while (curr != null)
        {
            text += "-[" + curr.Ladung + "]";
            curr = curr.Next;
        }
        return text;
    }
}
