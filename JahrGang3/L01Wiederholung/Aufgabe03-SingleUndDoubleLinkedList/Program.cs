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