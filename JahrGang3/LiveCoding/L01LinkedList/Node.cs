public class Node
{
    public Node Next { get; set; }
    public int Value { get; private set; }

    public Node(int value)
    {
        Value = value;
    }
}
