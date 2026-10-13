Welche ``Konzepte`` der Programmiersprache üben wir hier?
- Referenzdatentypen (Klassen) und Objektreferenzen
- Iteration mit ``while`` und ``for`` Schleifen durch dynamische Datenstrukturen
- *Optional:* Vermeidung von ``NullReferenceExceptions`` durch das Prüfen von Randfällen und moderne C#-Operatoren (``?``, ``??``, ``??=``, ``is null``)

Welche ``Denkweisen`` üben wir hier?
- Wie verändere ich Referenzen ("Pointer"), ohne nachfolgende Teile der Liste im Speicher zu verlieren?
- Wie unterscheidet sich das Umbiegen von Pfeilen in einer einfach verketteten von einer doppelt verketteten Liste?

Bei Unklarheiten zum Ablauf der Referenzänderungen unbedingt hier nachlesen bzw. ansehen: 
- [Visualisierung der Basis-Methoden (HTML)](visualisierung_linked_list.html)
- [Visualisierung der Cycle Detection (HTML)](visualisierung_cycle_detection.html)

## Projektstruktur
Erstelle für jede der folgenden ``Aufgaben`` jeweils ein ``Projekt``, welche sich alle in einer ``Solution`` (Projektmappe) befinden.
In einem Projekt kann nur *eine* ausführbare ``Klasse`` sein. Also nur ein ``Main-Methode`` oder ein ``Top-Level Statement``.

>Für VS: Erstelle dazu eine ``Solution``(Projektmappe) und in dieser ``Solution`` (Projektmappe), füge mit *Rechtsclick auf die Solution -> Add (Hinzufügen) -> new Project (neues Projekt) mit Namen Aufgabe 1* ein neues ``Projekt`` in der bestehenden ``Solution`` ein. Wiederhole für Aufgabe 2 und 3.

## Implementiere Operationen für verkettete Listen

### Aufgabe 1 - level: 🙂 - Singly Linked List
Erweitere deine bestehende Klasse der einfach verketteten Liste um die folgenden Methoden. Achte dabei besonders auf die Randfälle (Liste ist leer, Element ist am Anfang/Ende). Sieh dir die grafische Darstellung des Ablaufs (ohne Code) im ersten HTML-Dokument an, bevor du programmierst!

```csharp
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

    // Löscht das erste Element und gibt dessen Wert zurück.
    public int RemoveFirst()
    {
        throw new NotImplementedException("TODO: Implementiere RemoveFirst");
    }

    // Löscht das letzte Element und gibt dessen Wert zurück.
    public int RemoveLast()
    {
        throw new NotImplementedException("TODO: Implementiere RemoveLast");
    }

    // Löscht das Element an der angegebenen Position und gibt den Wert zurück.
    public int Remove(int position)
    {
        throw new NotImplementedException("TODO: Implementiere Remove");
    }

    // Gibt den Index des ersten Vorkommens des Wertes zurück, sonst -1.
    public int Find(int value)
    {
        throw new NotImplementedException("TODO: Implementiere Find");
    }

    // Gibt den Wert des Elements an der angegebenen Position zurück.
    public int Get(int position)
    {
        throw new NotImplementedException("TODO: Implementiere Get");
    }

    // Prüft, ob der Wert in der Liste existiert.
    public bool Contains(int value)
    {
        throw new NotImplementedException("TODO: Implementiere Contains");
    }

    // Aktualisiert den Wert an der angegebenen Position und gibt den alten Wert zurück.
    public int Update(int position, int newValue)
    {
        throw new NotImplementedException("TODO: Implementiere Update");
    }

    // private Hilfsmethoden
    private Node GetNodeAt(int position)
    {
        throw new NotImplementedException("TODO"); 
    }

    private bool TryFind(int value, out int index)
    {
        throw new NotImplementedException("TODO"); 
    }
}
```

### Aufgabe 2 - level: 🤔 - Doubly Linked List
Implementiere nun exakt die gleichen Methoden für die `DoublyLinkedList`. Nutze hier zwingend die `Prev` Eigenschaft der Knoten, um Traversierungen zu optimieren. Überlege dir: Wann macht es Sinn, die Liste von hinten nach vorne zu durchlaufen?

```csharp
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
        throw new NotImplementedException("TODO"); 
    }
    
    public int RemoveLast() 
    { 
        throw new NotImplementedException("TODO");
    }
    
    public int Remove(int position) 
    { 
        throw new NotImplementedException("TODO"); 
    }
    
    public int Find(int value) 
    { 
        throw new NotImplementedException("TODO"); 
    }
    
    public int Get(int position) 
    { 
        throw new NotImplementedException("TODO"); 
    }
    
    public bool Contains(int value) 
    { 
        throw new NotImplementedException("TODO"); 
    }
    
    public int Update(int position, int newValue) 
    { 
        throw new NotImplementedException("TODO"); 
    }

    // private Hilfsmethoden
    private DoubleNode GetNodeAt(int position)
    {   
        throw new NotImplementedException("TODO"); 
    }

    private bool TryFind(int value, out int index)
    {
        throw new NotImplementedException("TODO"); 
    }
}
```

### Aufgabe 3 - level: 😵‍💫 - Cycle Detection (Floyd's Algorithm)
Eine fehlerhaft programmierte verkettete Liste kann versehentlich in einer Endlosschleife enden (einem Zyklus). 
Implementiere die Methode zur Zykluserkennung. Öffne das zweite HTML-Dokument, um den Ablauf des "Tortoise and Hare" Algorithmus grafisch nachzuvollziehen.
```csharp
public class SinglyLinkedList
{
    public bool HasCycle()
    {
        throw new NotImplementedException("TODO: Implementiere HasCycle");
    }
}
```

```csharp
public class DoublyLinkedList
{
    public bool HasCycle()
    {
        throw new NotImplementedException("TODO: Implementiere HasCycle");
    }

    private bool CheckForwardCycle()
    {
        throw new NotImplementedException("TODO"); 
    }

    private bool CheckBackwardCycle()
    {
        throw new NotImplementedException("TODO"); 
    }
}
```


### Main
Führe deine Implementierungen über dieses Top-Level Statement in der `Program.cs` aus, um die grundlegende Funktionalität (und das Nullable-Verhalten) zu testen:

```csharp
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.WriteLine("\n\n=========================================");
Console.WriteLine("    TEST: Singly Linked List");
Console.WriteLine("=========================================\n");

SinglyLinkedList sList = new();

Console.WriteLine("1. Teste AddFirst & AddLast...");
sList.AddFirst(10); // [10]
sList.AddLast(20);  // [10, 20]
sList.AddFirst(5);  // [5, 10, 20]
Check("Head", sList.Head?.Value, 5);
Check("Tail", sList.Tail?.Value, 20);

Console.WriteLine("\n2. Teste Get, Find & Contains...");
Check("Get(1)", sList.Get(1), 10);
Check("Find(20)", sList.Find(20), 2);
Check("Contains(10)", sList.Contains(10), true);
Check("Contains(99)", sList.Contains(99), false);

Console.WriteLine("\n3. Teste Update...");
Check("Update an Index 1. Alter Wert", sList.Update(1, 15), 10);
Check("Neuer Wert Get(1)", sList.Get(1), 15);

Console.WriteLine("\n4. Teste RemoveFirst & RemoveLast...");
Check("RemoveFirst()", sList.RemoveFirst(), 5);
Check("RemoveLast()", sList.RemoveLast(), 20);

Console.WriteLine("\n5. Teste Remove(position)...");
sList.AddLast(30); // [15, 30]
sList.AddLast(40); // [15, 30, 40]
Check("Remove(1)", sList.Remove(1), 30);
Check("Head nach Remove", sList.Head?.Value, 15);
Check("Tail nach Remove", sList.Tail?.Value, 40);

Console.WriteLine("\n6. Teste Insert(position, value)...");
// Aktueller Zustand: [15, 40]
sList.Insert(1, 25); // Einfügen in der Mitte -> [15, 25, 40]
Check("Get(1) nach Insert(1, 25)", sList.Get(1), 25);
sList.Insert(0, 5);  // Einfügen am Anfang -> [5, 15, 25, 40]
Check("Head nach Insert(0, 5)", sList.Head?.Value, 5);
sList.Insert(4, 50); // Einfügen am Ende -> [5, 15, 25, 40, 50]
Check("Tail nach Insert(4, 50)", sList.Tail?.Value, 50);

Console.WriteLine("\n7. Teste HasCycle...");
Check("HasCycle()", sList.HasCycle(), false);

Console.WriteLine("\n\n=========================================");
Console.WriteLine("    TEST: Doubly Linked List");
Console.WriteLine("=========================================\n");

DoublyLinkedList dList = new();

Console.WriteLine("1. Teste AddFirst & AddLast...");
dList.AddFirst(100); // [100]
dList.AddLast(200);  // [100, 200]
dList.AddFirst(50);  // [50, 100, 200]
Check("Head", dList.Head?.Value, 50);
Check("Tail", dList.Tail?.Value, 200);
Check("Count", dList.Count, 3);

Console.WriteLine("\n2. Teste Get, Find & Contains...");
Check("Get(1)", dList.Get(1), 100);
Check("Find(200)", dList.Find(200), 2);
Check("Contains(100)", dList.Contains(100), true);
Check("Contains(999)", dList.Contains(999), false);

Console.WriteLine("\n3. Teste Update...");
Check("Update an Index 1. Alter Wert", dList.Update(1, 150), 100);
Check("Neuer Wert Get(1)", dList.Get(1), 150);

Console.WriteLine("\n4. Teste RemoveFirst & RemoveLast...");
Check("RemoveFirst()", dList.RemoveFirst(), 50);
Check("RemoveLast()", dList.RemoveLast(), 200);
Check("Count nach Removes", dList.Count, 1);

Console.WriteLine("\n5. Teste Remove(position)...");
dList.AddLast(300); // [150, 300]
dList.AddLast(400); // [150, 300, 400]
Check("Remove(1)", dList.Remove(1), 300);
Check("Head nach Remove", dList.Head?.Value, 150);
Check("Tail nach Remove", dList.Tail?.Value, 400);
Check("Count final", dList.Count, 2);

Console.WriteLine("\n6. Teste Insert(position, value)...");
// Aktueller Zustand: [150, 400], Count: 2
dList.Insert(1, 250); // Einfügen in der Mitte -> [150, 250, 400]
Check("Get(1) nach Insert(1, 250)", dList.Get(1), 250);
dList.Insert(0, 50);  // Einfügen am Anfang -> [50, 150, 250, 400]
Check("Head nach Insert(0, 50)", dList.Head?.Value, 50);
dList.Insert(4, 500); // Einfügen am Ende -> [50, 150, 250, 400, 500]
Check("Tail nach Insert(4, 500)", dList.Tail?.Value, 500);
Check("Count nach Inserts", dList.Count, 5);

Console.WriteLine("\n7. Teste HasCycle...");
Check("HasCycle()", dList.HasCycle(), false);

Console.WriteLine("\n=========================================");
Console.WriteLine("    ALLE TESTS BEENDET");
Console.WriteLine("=========================================");

void Check(string testName, object? actual, object? expected)
{
    string mark = object.Equals(actual, expected) ? "✅" : "❌";
    // Falls ein Wert null ist, geben wir "null" als Text aus, sonst den Wert
    Console.WriteLine($"{testName}: {actual ?? "null"} (Erwartet: {expected ?? "null"}) {mark}");
}
```