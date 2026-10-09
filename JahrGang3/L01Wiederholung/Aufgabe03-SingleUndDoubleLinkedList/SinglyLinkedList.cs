public class SinglyLinkedList
{
    public Node Head { get; private set; }
    public Node Tail { get; private set; }

    public int RemoveFirst()
    {
        if (Head == null) throw new InvalidOperationException("Liste ist leer.");
        
        int value = Head.Value;
        Head = Head.Next;
        
        if (Head == null) Tail = null; // Liste ist nun leer
        
        return value;
    }

    public int RemoveLast()
    {
        if (Head == null) throw new InvalidOperationException("Liste ist leer.");
        
        int value = Tail.Value;
        
        if (Head == Tail) 
        {
            Head = null;
            Tail = null;
            return value;
        }

        Node curr = Head;
        while (curr.Next != Tail)
        {
            curr = curr.Next;
        }
        
        curr.Next = null;
        Tail = curr;
        
        return value;
    }

    public int Remove(int position)
    {
        if (position < 0 || Head == null) throw new ArgumentOutOfRangeException();
        if (position == 0) return RemoveFirst();

        Node curr = Head;
        for (int i = 0; i < position - 1; i++)
        {
            if (curr.Next == null) throw new ArgumentOutOfRangeException();
            curr = curr.Next;
        }

        if (curr.Next == null) throw new ArgumentOutOfRangeException();

        int value = curr.Next.Value;
        curr.Next = curr.Next.Next;

        if (curr.Next == null) Tail = curr; // Tail updaten, falls letztes Element gelöscht wurde

        return value;
    }

    public int Find(int value)
    {
        Node curr = Head;
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
        if (position < 0 || Head == null) throw new ArgumentOutOfRangeException();
        
        Node curr = Head;
        for (int i = 0; i < position; i++)
        {
            curr = curr.Next;
            if (curr == null) throw new ArgumentOutOfRangeException();
        }
        
        return curr.Value;
    }

    public bool Contains(int value)
    {
        return Find(value) != -1;
    }

    // Hinweis: Ein neuer Wert (newValue) muss übergeben werden, um upzudaten.
    public int Update(int position, int newValue)
    {
        if (position < 0 || Head == null) throw new ArgumentOutOfRangeException();
        
        Node curr = Head;
        for (int i = 0; i < position; i++)
        {
            curr = curr.Next;
            if (curr == null) throw new ArgumentOutOfRangeException();
        }
        
        int oldValue = curr.Value;
        curr.Value = newValue;
        return oldValue;
    }

    public bool HasCycle()
    {
        if (Head == null || Head.Next == null) return false;

        Node slow = Head;
        Node fast = Head;

        // Prüft ausschließlich die Vorwärtsrichtung (Next)
        while (fast != null && fast.Next != null)
        {
            slow = slow.Next;
            fast = fast.Next.Next;

            if (slow == fast) return true;
        }

        return false;
    }
}