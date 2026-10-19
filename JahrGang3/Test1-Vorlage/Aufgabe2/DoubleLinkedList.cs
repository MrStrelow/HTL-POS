using System;

public class DoublyLinkedList
{
    // Eigenschaften

    // Private Hilfsmethode: Positioniert intelligent über Head (1. Hälfte) oder Tail (2. Hälfte)
    private Node GetNodeAt(int index)
    {
        throw new NotImplementedException();
    }

    // CRUD - Methoden
    // 1. AddFirst
    public void AddFirst(int value)
    {
        throw new NotImplementedException();
    }

    // 2. AddLast
    public void AddLast(int value)
    {
        throw new NotImplementedException();
    }

    // 3. InsertAt (nutzt AddFirst, AddLast und GetNodeAt)
    public void InsertAt(int index, int value)
    {
        throw new NotImplementedException();
    }

    // 4. SwapNeighbours: Tauscht den Knoten an 'index' mit seinem direkten Nachbarn 'index + 1'
    public void SwapNeighbours(int index)
    {
        throw new NotImplementedException();
    }

    // BONUS: SwapNodes tauscht zwei beliebige Knoten an indexA und indexB
    public void SwapNodes(int indexA, int indexB)
    {
        throw new NotImplementedException();
    }
}