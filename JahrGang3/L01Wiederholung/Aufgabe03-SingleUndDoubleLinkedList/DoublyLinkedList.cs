public class DoublyLinkedList
{
    public DoubleNode Head { get; private set; }
    public DoubleNode Tail { get; private set; }
    public int Count { get; private set; }

    // Hilfsmethode zur Optimierung der Wegstrecke
    private DoubleNode GetNodeAt(int position)
    {
        if (position < 0 || position >= Count) throw new ArgumentOutOfRangeException();

        DoubleNode curr;
        if (position <= Count / 2)
        {
            curr = Head;
            for (int i = 0; i < position; i++) curr = curr.Next;
        }
        else
        {
            curr = Tail;
            for (int i = Count - 1; i > position; i--) curr = curr.Prev;
        }
        return curr;
    }

    public int RemoveFirst()
    {
        if (Head == null) throw new InvalidOperationException("Liste ist leer.");
        
        int value = Head.Value;
        Head = Head.Next;
        
        if (Head != null) Head.Prev = null;
        else Tail = null;
        
        Count--;
        return value;
    }

    public int RemoveLast()
    {
        if (Tail == null) throw new InvalidOperationException("Liste ist leer.");
        
        int value = Tail.Value;
        Tail = Tail.Prev;
        
        if (Tail != null) Tail.Next = null;
        else Head = null;
        
        Count--;
        return value;
    }

    public int Remove(int position)
    {
        if (position == 0) return RemoveFirst();
        if (position == Count - 1) return RemoveLast();

        DoubleNode curr = GetNodeAt(position);
        
        int value = curr.Value;
        curr.Prev.Next = curr.Next;
        curr.Next.Prev = curr.Prev;
        
        Count--;
        return value;
    }

    public int Find(int value)
    {
        DoubleNode curr = Head;
        int index = 0;
        
        while (curr != null)
        {
            if (curr.Value == value) return index;
            curr = curr.Next;
            index++;
        }
        
        return -1;
    }

    public int Get(int position)
    {
        return GetNodeAt(position).Value;
    }

    public bool Contains(int value)
    {
        return Find(value) != -1;
    }

    public int Update(int position, int newValue)
    {
        DoubleNode curr = GetNodeAt(position);
        int oldValue = curr.Value;
        curr.Value = newValue;
        return oldValue;
    }

    public bool HasCycle()
    {
        // 1. Phase: Prüfung der Vorwärtsrichtung (Next-Pfeile)
        bool hasForwardCycle = false;
        DoubleNode slowForward = Head;
        DoubleNode fastForward = Head;

        while (fastForward != null && fastForward.Next != null)
        {
            slowForward = slowForward.Next;
            fastForward = fastForward.Next.Next;

            if (slowForward == fastForward) 
            {
                hasForwardCycle = true;
                break;
            }
        }

        // 2. Phase: Prüfung der Rückwärtsrichtung (Prev-Pfeile)
        bool hasBackwardCycle = false;
        DoubleNode slowBackward = Tail;
        DoubleNode fastBackward = Tail;

        while (fastBackward != null && fastBackward.Prev != null)
        {
            slowBackward = slowBackward.Prev;
            fastBackward = fastBackward.Prev.Prev;

            if (slowBackward == fastBackward)
            {
                hasBackwardCycle = true;
                break;
            }
        }

        // Liefert true, sobald in mindestens einer der beiden Richtungen ein Zyklus existiert
        return hasForwardCycle || hasBackwardCycle;
    }
}