// Ein Zug ist eine Doubly Linked List aus Waggons.
// Head ist der erste Waggon hinter der Lok, Tail der letzte.
public class Zug
{
    public Waggon? Head { get; private set; }
    public Waggon? Tail { get; private set; }
    public int Count { get; private set; }

    // Zustaendigkeit: haengt einen neuen Waggon direkt hinter der Lok an.
    public void AnhaengenVorne(int ladung)
    {
        Waggon waggon = new Waggon(ladung);

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

    // Zustaendigkeit: haengt einen neuen Waggon am Ende an.
    public void AnhaengenHinten(int ladung)
    {
        Waggon waggon = new Waggon(ladung);

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

    // Zustaendigkeit: reiht einen neuen Waggon an der Position ein.
    public void Einreihen(int position, int ladung)
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

        Waggon curr = GetWaggonAt(position);
        Waggon prev = curr.Prev ?? throw new InvalidOperationException("Vorheriger Waggon ist null.");

        Waggon neu = new Waggon(ladung);
        neu.Prev = prev;
        neu.Next = curr;
        prev.Next = neu;
        curr.Prev = neu;

        Count++;
    }

    // Zustaendigkeit: kuppelt den ersten Waggon ab und liefert seine Ladung.
    public int AbkuppelnVorne()
    {
        // ungewuenschter Zustand ❌
        if (Head == null)
        {
            throw new InvalidOperationException("Der Zug hat keine Waggons.");
        }

        // gewuenschter Zustand ✅
        int ladung = Head.Ladung;
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

    public int Get(int position)
    {
        return GetWaggonAt(position).Ladung;
    }

    public int Finde(int ladung)
    {
        Waggon? curr = Head;
        int position = 0;

        while (curr != null)
        {
            if (curr.Ladung == ladung)
            {
                return position;
            }
            curr = curr.Next;
            position++;
        }

        return -1;
    }

    public bool Enthaelt(int ladung)
    {
        return Finde(ladung) != -1;
    }

    // Zustaendigkeit: tauscht die Ladung eines Waggons und liefert die alte.
    public int Umladen(int position, int neueLadung)
    {
        Waggon waggon = GetWaggonAt(position);
        int alteLadung = waggon.Ladung;
        waggon.Ladung = neueLadung;
        return alteLadung;
    }

    // private Hilfsmethode
    private Waggon GetWaggonAt(int position)
    {
        // Guard: ungewuenschter Zustand ❌
        if (position < 0 || position >= Count)
        {
            throw new ArgumentOutOfRangeException(nameof(position));
        }

        // gewuenschter Zustand ✅
        Waggon? curr = Head;
        for (int i = 0; i < position; i++)
        {
            curr = curr?.Next;
        }

        return curr ?? throw new InvalidOperationException("Waggon konnte nicht gefunden werden.");
    }

    // Ausgabe z. B. 🚂-[3]-[7]
    public override string ToString()
    {
        string text = "🚂";
        Waggon? curr = Head;
        while (curr != null)
        {
            text += "-[" + curr.Ladung + "]";
            curr = curr.Next;
        }
        return text;
    }
}
