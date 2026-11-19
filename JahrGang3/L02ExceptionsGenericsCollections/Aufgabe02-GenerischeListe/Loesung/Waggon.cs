// Teil 1: Der Waggon traegt eine Ladung vom Typ T.
// Next und Prev zeigen auf einen Waggon<T>: Ein Zug aus Holz-Waggons
// darf keinen Waggon mit Kohle-Ladung als Nachbarn haben.
public class Waggon<T>
{
    public T Ladung { get; set; }
    public Waggon<T>? Next { get; set; }
    public Waggon<T>? Prev { get; set; }

    public Waggon(T ladung)
    {
        Ladung = ladung;
        Next = null;
        Prev = null;
    }
}
