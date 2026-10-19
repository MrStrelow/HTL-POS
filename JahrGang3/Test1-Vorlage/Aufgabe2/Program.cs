using System;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("================================================================================");
Console.WriteLine("        TEST-SUITE: DOUBLY LINKED LIST (VORHER / NACHHER MIT FORWARD & BACKWARD)");
Console.WriteLine("================================================================================\n");

DoublyLinkedList list = new DoublyLinkedList();

// -------------------------------------------------------------------------------------------------
// 1. TEST: AddFirst & AddLast
// -------------------------------------------------------------------------------------------------
Console.WriteLine("\n################################################################################");
Console.WriteLine("  1. TEST: AddFirst & AddLast");
Console.WriteLine("################################################################################");

// 1a) AddFirst bei leerer Liste
PrintVorher(list, "1a) Spezialfall leere Liste (AddFirst)");
Console.WriteLine("  ⚡ AKTION:   list.AddFirst(20);");
list.AddFirst(20);
PrintNachher(list,
    erwartetCount: 1,
    erwartetNext: "[20]",
    erwartetPrev: "[20]");

// 1b) AddFirst bei befüllter Liste
PrintVorher(list, "1b) Vorne einfügen (AddFirst)");
Console.WriteLine("  ⚡ AKTION:   list.AddFirst(10);");
list.AddFirst(10);
PrintNachher(list,
    erwartetCount: 2,
    erwartetNext: "[10] <-> [20]",
    erwartetPrev: "[20] <-> [10]");

// 1c) AddLast
PrintVorher(list, "1c) Hinten anfügen (AddLast)");
Console.WriteLine("  ⚡ AKTION:   list.AddLast(40); list.AddLast(50);");
list.AddLast(40);
list.AddLast(50);
PrintNachher(list,
    erwartetCount: 4,
    erwartetNext: "[10] <-> [20] <-> [40] <-> [50]",
    erwartetPrev: "[50] <-> [40] <-> [20] <-> [10]");


// -------------------------------------------------------------------------------------------------
// 2. TEST: InsertAt (inkl. Spezialfälle Index 0 & Count)
// -------------------------------------------------------------------------------------------------
Console.WriteLine("\n################################################################################");
Console.WriteLine("  2. TEST: InsertAt (Mitte via GetNodeAt, Spezialfall Index 0 & Index Count)");
Console.WriteLine("################################################################################");

// 2a) Mitte über GetNodeAt
PrintVorher(list, "2a) In der Mitte einfügen (InsertAt an Index 2)");
Console.WriteLine("  ⚡ AKTION:   list.InsertAt(2, 30);");
list.InsertAt(2, 30);
PrintNachher(list,
    erwartetCount: 5,
    erwartetNext: "[10] <-> [20] <-> [30] <-> [40] <-> [50]",
    erwartetPrev: "[50] <-> [40] <-> [30] <-> [20] <-> [10]");

// 2b) Spezialfall Index 0 -> Delegiert an AddFirst
PrintVorher(list, "2b) Spezialfall Anfang (InsertAt an Index 0 -> AddFirst)");
Console.WriteLine("  ⚡ AKTION:   list.InsertAt(0, 5);");
list.InsertAt(0, 5);
PrintNachher(list,
    erwartetCount: 6,
    erwartetNext: "[5] <-> [10] <-> [20] <-> [30] <-> [40] <-> [50]",
    erwartetPrev: "[50] <-> [40] <-> [30] <-> [20] <-> [10] <-> [5]");

// 2c) Spezialfall Index == Count -> Delegiert an AddLast
PrintVorher(list, "2c) Spezialfall Ende (InsertAt an Index Count -> AddLast)");
Console.WriteLine($"  ⚡ AKTION:   list.InsertAt({list.Count}, 60);");
list.InsertAt(list.Count, 60);
PrintNachher(list,
    erwartetCount: 7,
    erwartetNext: "[5] <-> [10] <-> [20] <-> [30] <-> [40] <-> [50] <-> [60]",
    erwartetPrev: "[60] <-> [50] <-> [40] <-> [30] <-> [20] <-> [10] <-> [5]");


// -------------------------------------------------------------------------------------------------
// 3. TEST: SwapNeighbours (Mitte, Head-Beteiligung, Tail-Beteiligung)
// -------------------------------------------------------------------------------------------------
Console.WriteLine("\n################################################################################");
Console.WriteLine("  3. TEST: SwapNeighbours (Direkte Nachbarn tauschen)");
Console.WriteLine("################################################################################");

// 3a) Normalfall in der Mitte: Tausche Index 2 ([30]) mit Index 3 ([20])
PrintVorher(list, "3a) Mitte tauschen: Index 2 ([30]) mit Index 3 ([20])");
Console.WriteLine("  ⚡ AKTION:   list.SwapNeighbours(2);");
list.SwapNeighbours(2);
PrintNachher(list,
    erwartetCount: 7,
    erwartetNext: "[5] <-> [10] <-> [20] <-> [30] <-> [40] <-> [50] <-> [60]",
    erwartetPrev: "[60] <-> [50] <-> [40] <-> [30] <-> [20] <-> [10] <-> [5]");

// 3b) Spezialfall Head
PrintVorher(list, "3b) Head tauschen: Index 0 ([5]) mit Index 1 ([10])");
Console.WriteLine("  ⚡ AKTION:   list.SwapNeighbours(0);  // Neuer Head muss [10] werden!");
list.SwapNeighbours(0);
PrintNachher(list,
    erwartetCount: 7,
    erwartetNext: "[10] <-> [5] <-> [20] <-> [30] <-> [40] <-> [50] <-> [60]",
    erwartetPrev: "[60] <-> [50] <-> [40] <-> [30] <-> [20] <-> [5] <-> [10]");

// 3c) Spezialfall Tail
PrintVorher(list, "3c) Tail tauschen: Vorletztes ([50]) mit Tail ([60])");
Console.WriteLine($"  ⚡ AKTION:   list.SwapNeighbours({list.Count - 2});  // Neuer Tail muss [50] werden!");
list.SwapNeighbours(list.Count - 2);
PrintNachher(list,
    erwartetCount: 7,
    erwartetNext: "[10] <-> [5] <-> [20] <-> [30] <-> [40] <-> [60] <-> [50]",
    erwartetPrev: "[50] <-> [60] <-> [40] <-> [30] <-> [20] <-> [5] <-> [10]");


// -------------------------------------------------------------------------------------------------
// 4. TEST (BONUS): SwapNodes (Beliebige Knoten tauschen)
// -------------------------------------------------------------------------------------------------
Console.WriteLine("\n################################################################################");
Console.WriteLine("  4. TEST (BONUS): SwapNodes (Beliebige / getrennte Knoten)");
Console.WriteLine("################################################################################");

try
{
    // 4a) Getrennte Knoten in der Mitte
    PrintVorher(list, "4a) Getrennte Knoten tauschen: Index 1 ([5]) mit Index 4 ([40])");
    Console.WriteLine("  ⚡ AKTION:   list.SwapNodes(1, 4);");
    list.SwapNodes(1, 4);
    PrintNachher(list,
        erwartetCount: 7,
        erwartetNext: "[10] <-> [40] <-> [20] <-> [30] <-> [5] <-> [60] <-> [50]",
        erwartetPrev: "[50] <-> [60] <-> [5] <-> [30] <-> [20] <-> [40] <-> [10]");

    // 4b) Head und Tail tauschen
    PrintVorher(list, "4b) Head & Tail tauschen: Index 0 ([10]) mit Index 6 ([50])");
    Console.WriteLine($"  ⚡ AKTION:   list.SwapNodes(0, {list.Count - 1});");
    list.SwapNodes(0, list.Count - 1);
    PrintNachher(list,
        erwartetCount: 7,
        erwartetNext: "[50] <-> [40] <-> [20] <-> [30] <-> [5] <-> [60] <-> [10]",
        erwartetPrev: "[10] <-> [60] <-> [5] <-> [30] <-> [20] <-> [40] <-> [50]");
}
catch (NotImplementedException)
{
    Console.WriteLine("  ⚠️ Bonus-Methode SwapNodes ist noch nicht implementiert.\n");
}


// -------------------------------------------------------------------------------------------------
// 5. TEST: HasLoop (Vorwärts- und Rückwärtsprüfung)
// -------------------------------------------------------------------------------------------------
Console.WriteLine("\n################################################################################");
Console.WriteLine("  5. TEST: HasLoop (Zykluserkennung in Next- und Previous-Richtung)");
Console.WriteLine("################################################################################\n");

// 5a) Intakte Liste
Console.WriteLine("5a) Intakte Liste:");
Console.WriteLine($"  ⚡ AKTION:   bool hatLoop = list.HasLoop();");
Console.WriteLine($"  👉 ERGEBNIS: {list.HasLoop()} | ERWARTET: False\n");

// 5b) Künstlicher Next-Zyklus
Console.WriteLine("5b) Künstlicher Zyklus im NEXT-Pfad (Tail.Next = Head.Next):");
Node oldTail = list.Tail;
oldTail.Next = list.Head.Next;
Console.WriteLine($"  ⚡ AKTION:   Tail.Next zeigt auf Node({list.Head.Next.Value});");
Console.WriteLine($"  👉 ERGEBNIS: {list.HasLoop()} | ERWARTET: True");
oldTail.Next = null; // reparieren
Console.WriteLine("  🧹 BEREINIGT: Tail.Next = null;\n");

// 5c) Künstlicher Previous-Zyklus
Console.WriteLine("5c) Künstlicher Zyklus im PREVIOUS-Pfad (Head.Next.Previous = Tail.Previous):");
Node secondNode = list.Head.Next;
secondNode.Previous = list.Tail.Previous;
Console.WriteLine($"  ⚡ AKTION:   Head.Next.Previous zeigt auf Node({list.Tail.Previous.Value});");
Console.WriteLine($"  👉 ERGEBNIS: {list.HasLoop()} | ERWARTET: True");
secondNode.Previous = list.Head; // reparieren
Console.WriteLine("  🧹 BEREINIGT: Head.Next.Previous = Head;\n");

Console.WriteLine("================================================================================");
Console.WriteLine("                          TEST-DURCHLAUF BEENDET                                ");
Console.WriteLine("================================================================================");


// =================================================================================================
// HILFSMETHODEN FÜR STRUKTURIERTE VORHER / NACHHER AUSGABEN
// =================================================================================================
static void PrintVorher(DoublyLinkedList list, string titel)
{
    Console.WriteLine($"\n┌─ [TESTFALL: {titel}]");
    Console.WriteLine($"│  🔴 VORHER:   Count={list.Count} | Head={(list.Head != null ? list.Head.Value.ToString() : "null")} | Tail={(list.Tail != null ? list.Tail.Value.ToString() : "null")}");
    Console.WriteLine($"│     Next:     {FormatForward(list)}");
    Console.WriteLine($"│     Previous: {FormatBackward(list)}");
    Console.WriteLine("│");
}

static void PrintNachher(DoublyLinkedList list, int erwartetCount, string erwartetNext, string erwartetPrev)
{
    Console.WriteLine("│");
    Console.WriteLine($"│  🟢 NACHHER:  Count={list.Count} | Head={(list.Head != null ? list.Head.Value.ToString() : "null")} | Tail={(list.Tail != null ? list.Tail.Value.ToString() : "null")}");
    Console.WriteLine($"│     Next:     {FormatForward(list)}");
    Console.WriteLine($"│     Previous: {FormatBackward(list)}");
    Console.WriteLine("│");
    Console.WriteLine($"└─ 🎯 ERWARTET: Count={erwartetCount}");
    Console.WriteLine($"            Next:     HEAD -> {erwartetNext} -> null");
    Console.WriteLine($"            Previous: TAIL -> {erwartetPrev} -> null\n");
}

static string FormatForward(DoublyLinkedList list)
{
    if (list.Head == null) return "HEAD -> null";
    string res = "HEAD -> ";
    Node curr = list.Head;
    int safety = 0;
    while (curr != null && safety < 30)
    {
        res += $"[{curr.Value}] <-> ";
        curr = curr.Next;
        safety++;
    }
    return safety >= 30 ? res + "... (Endlosschleife!)" : res + "null";
}

static string FormatBackward(DoublyLinkedList list)
{
    if (list.Tail == null) return "TAIL -> null";
    string res = "TAIL -> ";
    Node curr = list.Tail;
    int safety = 0;
    while (curr != null && safety < 30)
    {
        res += $"[{curr.Value}] <-> ";
        curr = curr.Previous;
        safety++;
    }
    return safety >= 30 ? res + "... (Endlosschleife!)" : res + "null";
}