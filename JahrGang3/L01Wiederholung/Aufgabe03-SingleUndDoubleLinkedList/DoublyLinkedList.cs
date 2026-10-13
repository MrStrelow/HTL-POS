public class DoublyLinkedList
{
    public DoubleNode? Head { get; private set; }
    public DoubleNode? Tail { get; private set; }
    public int Count { get; private set; }

    public void AddFirst(int value)
    {
        DoubleNode node = new DoubleNode(value);

        if (Head == null)
        {
            Head = Tail = node;
        }

        if (Tail != null && Head != null)
        {
            node.Next = Head;
            Head.Prev = node;
            Head = node;
        }

        Count++;
    }

    // Zustaendigkeit: Fuegt neuen Node am Ende mit Value in die Liste ein.
    public void AddLast(int value)
    {
        DoubleNode node = new DoubleNode(value);

        if (Tail == null)
        {
            Head = Tail = node;
        }

        if (Tail != null && Head != null)
        {
            Tail.Next = node;
            node.Prev = Tail;
            Tail = node;
        }

        Count++;
    }

    public void Insert(int position, int value)
    {
        // Guard: ungewuenschter Zustand ❌
        if (position < 0 || position > Count)
        {
            throw new ArgumentOutOfRangeException(nameof(position), "Ungültige Position zum Einfügen.");
        }

        // Sonderfälle delegieren ✅
        if (position == 0)
        {
            AddFirst(value);
            return;
        }

        if (position == Count)
        {
            AddLast(value);
            return;
        }

        DoubleNode curr = GetNodeAt(position);
        DoubleNode prev = curr.Prev ?? throw new InvalidOperationException("Vorheriger Knoten ist null.");

        DoubleNode newNode = new DoubleNode(value);
        newNode.Prev = prev;
        newNode.Next = curr;

        prev.Next = newNode;
        curr.Prev = newNode;

        Count++;
    }

    public int RemoveFirst()
    {
        // ungewuenschter Zustand ❌
        if (Head == null) 
        {
            throw new InvalidOperationException("Liste ist leer.");
        }

        // gewuenschter Zustand ✅
        int value = Head.Value;
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
        return value;
    }

    public int RemoveLast()
    {
        // ungewuenschter Zustand ❌
        if (Tail == null) 
        {
            throw new InvalidOperationException("Liste ist leer.");
        }

        // gewuenschter Zustand ✅
        int value = Tail.Value;
        Tail = Tail.Prev;
        
        if (Tail != null) 
        { 
            Tail.Next = null;
        }
        else 
        {
            Head = null;
        }
        
        Count--;
        return value;
    }

    public int Remove(int position)
    {
        if (position == 0) 
        {
            return RemoveFirst();
        }

        if (position == Count - 1) 
        {
            return RemoveLast();
        }

        DoubleNode curr = GetNodeAt(position);
        int value = curr.Value;

        // ungewuenschter Zustand ❌
        var next = curr.Next ?? throw new InvalidOperationException("Nächster Knoten ist null.");
        var prev = curr.Prev ?? throw new InvalidOperationException("Vorheriger Knoten ist null.");
        
        // gewuenschter Zustand ✅
        prev.Next = curr.Next;
        next.Prev = curr.Prev;

        Count--;
        return value;
    }

    public int Find(int value)
    {
        if (TryFind(value, out int index))
        {
            return index;
        }
    
        throw new InvalidOperationException("Wert nicht gefunden.");
    }

    public int Get(int position)
    {
        return GetNodeAt(position).Value;
    }

    public bool Contains(int value)
    {
        return TryFind(value, out _);
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
        return CheckForwardCycle() || CheckBackwardCycle();
    }

    // private Hilfsmethoden
    private DoubleNode GetNodeAt(int position)
    {
        // Guard: ungewuenschter Zustand ❌
        if (position < 0 || position >= Count) 
        {
            throw new ArgumentOutOfRangeException();
        }

        // gewuenschter Zustand ✅
        DoubleNode? curr;
        if (position <= Count / 2)
        {
            curr = Head;
            for (int i = 0; i < position; i++)
            {
                curr = curr?.Next;
            }
        }
        else
        {
            curr = Tail;
            for (int i = Count - 1; i > position; i--) 
            {
                curr = curr?.Prev;
            }
        }

        return curr ?? throw new InvalidOperationException("Knoten konnte nicht gefunden werden.");
    }

    private bool CheckForwardCycle()
    {
        DoubleNode? slowForward = Head;
        DoubleNode? fastForward = Head;

        while (fastForward != null && fastForward.Next != null && slowForward != null && slowForward.Next != null)
        {
            slowForward = slowForward.Next;
            fastForward = fastForward.Next.Next;

            if (slowForward == fastForward) 
            {
                return true;
            }
        }

        return false;
    }

    private bool CheckBackwardCycle()
    {
        DoubleNode? slowBackward = Tail;
        DoubleNode? fastBackward = Tail;

        while (fastBackward != null && fastBackward.Prev != null && slowBackward != null && slowBackward.Prev != null)
        {
            slowBackward = slowBackward.Prev;
            fastBackward = fastBackward.Prev.Prev;

            if (slowBackward == fastBackward)
            {
                return true;
            }
        }

        return false;
    }

    private bool TryFind(int value, out int index)
    {
        DoubleNode? curr = Head;
        index = 0;
        
        while (curr != null)
        {
            if (curr.Value == value) 
            {
                return true; 
            }
            curr = curr.Next;
            index++;
        }
        
        index = -1;
        return false;
    }
}