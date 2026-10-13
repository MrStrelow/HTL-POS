public class SinglyLinkedList
{
    public Node? Head { get; private set; }
    public Node? Tail { get; private set; }
    public int Count { get; private set; }

    public void AddFirst(int value)
    {
        Node node = new Node(value);

        // ungewuenschter Zustand ❌
        if (Head == null && Tail == null)
        {
            Head = node;
            Tail = node;
        }
         
        // gewuenschter Zustand ✅
        if (Tail != null && Head != null) 
        {
            node.Next = Head;
            Head = node;
        }

        Count++;
    }

    public void AddLast(int value)
    {
        Node node = new Node(value);

        // ungewuenschter Zustand ❌
        if (Tail == null && Head == null)
        {
            Tail = node;
            Head = node;
        }

        // gewuenschter Zustand ✅
        if (Tail != null && Head != null)
        {
            Tail.Next = node;
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


        // Regulärer gewünschter Zustand ✅
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

        Node prev = GetNodeAt(position - 1);

        Node newNode = new Node(value);
        newNode.Next = prev.Next;
        prev.Next = newNode;

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
        
        if (Head == null) 
        {
            Tail = null; 
        }
        
        Count--;
        return value;
    }

    public int RemoveLast()
    {
        // ungewuenschter Zustand ❌
        if (Head == null || Tail == null) 
        {
            throw new InvalidOperationException("Liste ist leer.");
        }
        
        // gewuenschter Zustand ✅ (Sonderfall: nur ein Element)
        int value = Tail.Value;
        
        if (Head == Tail) 
        {
            Head = null;
            Tail = null;
            Count--;
            return value;
        }

        // Regulärer gewuenschter Zustand ✅
        Node curr = Head;
        while (curr.Next != Tail)
        {
            curr = curr.Next!;
        }
        
        curr.Next = null;
        Tail = curr;
        
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

        // Bei einer SinglyLinkedList brauchen wir für Remove den KNOTEN DAVOR
        Node prev = GetNodeAt(position - 1);

        // ungewuenschter Zustand ❌
        var curr = prev.Next ?? throw new InvalidOperationException("Knoten ist null.");
        
        // gewuenschter Zustand ✅
        int value = curr.Value;
        prev.Next = curr.Next;

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
        Node curr = GetNodeAt(position);
        int oldValue = curr.Value;
        curr.Value = newValue;
        return oldValue;
    }

    public bool HasCycle()
    {
        if (Head == null || Head.Next == null) return false;

        Node? slow = Head;
        Node? fast = Head;

        while (fast != null && fast.Next != null && slow != null && slow.Next != null)
        {
            slow = slow.Next;
            fast = fast.Next.Next;

            if (slow == fast) 
            {
                return true;
            }
        }

        return false;
    }

    // private Hilfsmethoden
    private Node GetNodeAt(int position)
    {
        // Guard: ungewuenschter Zustand ❌
        if (position < 0 || position >= Count) 
        {
            throw new ArgumentOutOfRangeException();
        }

        // gewuenschter Zustand ✅
        Node? curr = Head;
        for (int i = 0; i < position; i++)
        {
            curr = curr?.Next;
        }
        
        return curr ?? throw new InvalidOperationException("Knoten konnte nicht gefunden werden.");
    }

    private bool TryFind(int value, out int index)
    {
        Node? curr = Head;
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