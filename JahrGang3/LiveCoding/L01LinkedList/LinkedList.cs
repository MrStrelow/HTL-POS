public class MyLinkedList
{
    public Node Head { get; private set; }
    public Node Tail { get; private set; }

    // Zustaendigkeit: Fuegt neuen Node am Beginn mit Value in die Liste ein.
    public void AddFirst(int value)
    {
        Node node = new Node(value);

        // ungewünschter Zustand ❌
        if (Head == null && Tail == null)
        {
            Head = node;
            Tail = node;
        }
         
        // gewünschter Zustand ✅
        // brauchen wir hier keine Schleife?
        // wenn ja warum wenn nein warum nicht?
        if (Tail != null && Head != null) {
            node.Next = Head;
            Head = node;
        }
    }

    // Zustaendigkeit: Fuegt neuen Node am Ende mit Value in die Liste ein.
    public void AddLast(int value)
    {
        Node node = new Node(value);

        // ungewünschter Zustand ❌
        if (Tail == null && Head == null)
        {
            Tail = node;
            Head = node;
        }

        // gewünschter Zustand ✅
        if (Tail != null && Head != null)
        {
            Tail.Next = node;
            Tail = node;
        }
    }
}
