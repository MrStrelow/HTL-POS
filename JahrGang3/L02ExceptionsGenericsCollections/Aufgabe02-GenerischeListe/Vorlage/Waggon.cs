// Ein Waggon ist ein Knoten der Doubly Linked List.
// Im Moment kann er nur eine Ladung vom Typ int (Tonnen) tragen.
public class Waggon
{
    public int Ladung { get; set; }
    public Waggon? Next { get; set; }
    public Waggon? Prev { get; set; }

    public Waggon(int ladung)
    {
        Ladung = ladung;
        Next = null;
        Prev = null;
    }
}
