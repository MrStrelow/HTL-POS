using System;

public class DoublyLinkedList
{
    // Eigenschaften

    // ======================= VORGEGEBEN =======================

    public void AddLast(int value)
    {
        Node newNode = new Node(value);

        if (Tail == null)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            Tail.Next = newNode;
            newNode.Previous = Tail;
            Tail = newNode;
        }

        Count++;
    }

    // ======================= ZU IMPLEMENTIEREN =======================

    // Private Hilfsmethode: Positioniert intelligent über Head (1. Hälfte) oder Tail (2. Hälfte)
    private Node GetNodeAt(int index)
    {
        throw new NotImplementedException();
    }

    // 1. RemoveFirst: entfernt den Head und gibt seinen Wert zurück
    public int RemoveFirst()
    {
        throw new NotImplementedException();
    }

    // 2. RemoveLast: entfernt den Tail und gibt seinen Wert zurück
    public int RemoveLast()
    {
        throw new NotImplementedException();
    }

    // 3. RemoveAt (nutzt RemoveFirst, RemoveLast und GetNodeAt)
    public int RemoveAt(int index)
    {
        throw new NotImplementedException();
    }

    // 4. HasLoop: Zykluserkennung in Next- UND Previous-Richtung
    public bool HasLoop()
    {
        throw new NotImplementedException();
    }

    private bool CheckForwardLoop()
    {
        throw new NotImplementedException();
    }

    private bool CheckBackwardLoop()
    {
        throw new NotImplementedException();
    }

    // 5. Reverse: dreht die Liste um (Next und Previous jedes Knotens tauschen, dann Head und Tail)
    public void Reverse()
    {
        throw new NotImplementedException();
    }

}
