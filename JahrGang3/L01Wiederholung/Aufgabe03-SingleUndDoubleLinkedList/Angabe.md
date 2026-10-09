Welche ``Konzepte`` der Programmiersprache üben wir hier?
* Referenzdatentypen (Klassen) und Objektreferenzen
* Iteration mit ``while`` und ``for`` Schleifen durch dynamische Datenstrukturen
* Vermeidung von ``NullReferenceExceptions`` durch das Prüfen von Randfällen

Welche ``Denkweisen`` üben wir hier?
* Wie verändere ich Referenzen ("Pointer"), ohne nachfolgende Teile der Liste im Speicher zu verlieren?
* Wie unterscheidet sich das Umbiegen von Pfeilen in einer einfach verketteten von einer doppelt verketteten Liste?

Bei Unklarheiten zum Ablauf der Referenzänderungen unbedingt hier nachlesen bzw. ansehen: 
* [Visualisierung der Basis-Methoden (HTML)](visualisierung_linked_list.html)
* [Visualisierung der Cycle Detection (HTML)](visualisierung_cycle_detection.html)

## Projektstruktur
Erstelle für jede der folgenden ``Aufgaben`` jeweils ein ``Projekt``, welche sich alle in einer ``Solution`` (Projektmappe) befinden.
In einem Projekt kann nur *eine* ausführbare ``Klasse`` sein. Also nur ein ``Main-Methode`` oder ein ``Top-Level Statement``.

>Für VS: Erstelle dazu eine ``Solution``(Projektmappe) und in dieser ``Solution`` (Projektmappe), füge mit *Rechtsclick auf die Solution (![alt text](image.png)) -> Add (Hinzufügen) -> new Project (neues Projekt) mit Namen Aufgabe 1* ein neues ``Projekt`` in der bestehenden ``Solution`` ein. Wiederhole für Aufgabe 2 und 3.

## Implementiere Operationen für verkettete Listen

### Aufgabe 1 - level: 🙂 - Singly Linked List
Erweitere deine bestehende Klasse der einfach verketteten Liste um die folgenden Methoden. Achte dabei besonders auf die Randfälle (Liste ist leer, Element ist am Anfang/Ende). Sieh dir die grafische Darstellung des Ablaufs (ohne Code) im ersten HTML-Dokument an, bevor du programmierst!

```csharp
public class SinglyLinkedList
{
    public Node Head { get; private set; }
    public Node Tail { get; private set; }

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
    public int Update(int position)
    {
        throw new NotImplementedException("TODO: Implementiere Update");
    }
}
```

### Aufgabe 2 - level: 🤔 - Doubly Linked List
Implementiere nun exakt die gleichen Methoden für die `DoublyLinkedList`. Nutze hier zwingend die `Prev` Eigenschaft der Knoten, um Traversierungen zu optimieren. Überlege dir: Wann macht es Sinn, die Liste von hinten nach vorne zu durchlaufen?

```csharp
public class DoublyLinkedList
{
    public DoubleNode Head { get; private set; }
    public DoubleNode Tail { get; private set; }
    public int Count { get; private set; }

    // Zustaendigkeit: Fuegt neuen Node am Beginn mit Value in die Liste ein.
    public void AddFirst(int value)
    {
        Node node = new Node(value);

        // Wenn die Liste leer ist
        if (Head == null)
        {
            Head = node;
            Tail = node;
        }
        else 
        {
            node.Next = Head;
            Head.Prev = node;
            Head = node;
        }
        count++;
    }

    // Zustaendigkeit: Fuegt neuen Node am Ende mit Value in die Liste ein.
    public void AddLast(int value)
    {
        Node node = new Node(value);

        if (Tail == null)
        {
            Tail = node;
            Head = node;
        }
        else
        {
            Tail.Next = node;
            node.Prev = Tail;
            Tail = node;
        }
        count++;
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
    
    public int Update(int position) 
    { 
        throw new NotImplementedException("TODO"); 
    }
}
```

### Aufgabe 3 - level: 😵‍💫 - Cycle Detection (Floyd's Algorithm)
Eine fehlerhaft programmierte verkettete Liste kann versehentlich in einer Endlosschleife enden (einem Zyklus). 
Implementiere die Methode zur Zykluserkennung. Öffne das zweite HTML-Dokument, um den Ablauf des "Tortoise and Hare" Algorithmus grafisch nachzuvollziehen.

```csharp
public class CycleDetectionList
{
    public Node Head { get; private set; }

    // Prüft, ob die Liste einen Zyklus (Endlosschleife) enthält.
    public bool HasCycle()
    {
        // TODO: Implementiere Floyd's Tortoise and Hare Algorithm
        throw new NotImplementedException("TODO: Implementiere HasCycle");
    }
}
```