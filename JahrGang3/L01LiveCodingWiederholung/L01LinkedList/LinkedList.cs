public class MyLinkedList
{
    public Node Head { get; private set; }
    public Node Tail { get; private set; }

    // Zustaendigkeit: Fuegt neuen Node am Beginn mit Value in die Liste ein.
    public void AddFirst(int value)
    {
        Node node = new Node(value);

        // ungewünschter Zustand ❌
        if (Head == null)
        {
            Head = node;
        }
        else 
        // brauchen wir hier keine Schleife?
        // wenn ja warum wenn nein warum nicht?
        {
            node.Next = Head;
            Head = node;
        }
    }

    // Zustaendigkeit: Fuegt neuen Node am Ende mit Value in die Liste ein.
    public void AddLast(int value)
    {

    }
}
