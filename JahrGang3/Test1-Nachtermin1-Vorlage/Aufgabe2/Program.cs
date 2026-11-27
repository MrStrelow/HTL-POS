using System;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("================================================================================");
Console.WriteLine("        TEST-SUITE: DOUBLY LINKED LIST (VORHER / NACHHER MIT FORWARD & BACKWARD)");
Console.WriteLine("================================================================================\n");

DoublyLinkedList list = new DoublyLinkedList();
list.AddLast(40);
list.AddLast(10);
list.AddLast(50);
list.AddLast(30);
list.AddLast(20);
list.AddLast(60);

// -------------------------------------------------------------------------------------------------
// 1. TEST: RemoveFirst & RemoveLast
// -------------------------------------------------------------------------------------------------
Console.WriteLine("\n################################################################################");
Console.WriteLine("  1. TEST: RemoveFirst & RemoveLast");
Console.WriteLine("################################################################################");

// 1a) RemoveFirst
PrintVorher(list, "1a) Vorne entfernen (RemoveFirst)");
Console.WriteLine("  ⚡ AKTION:   int wert = list.RemoveFirst();");
int wert = list.RemoveFirst();
Console.WriteLine($"  👉 RÜCKGABE: {wert} | ERWARTET: 40");
PrintNachher(list,
    erwartetCount: 5,
    erwartetNext: "[10] <-> [50] <-> [30] <-> [20] <-> [60]",
    erwartetPrev: "[60] <-> [20] <-> [30] <-> [50] <-> [10]");

// 1b) RemoveLast
PrintVorher(list, "1b) Hinten entfernen (RemoveLast)");
Console.WriteLine("  ⚡ AKTION:   wert = list.RemoveLast();");
wert = list.RemoveLast();
Console.WriteLine($"  👉 RÜCKGABE: {wert} | ERWARTET: 60");
PrintNachher(list,
    erwartetCount: 4,
    erwartetNext: "[10] <-> [50] <-> [30] <-> [20]",
    erwartetPrev: "[20] <-> [30] <-> [50] <-> [10]");

// 1c) Spezialfall: genau ein Element
DoublyLinkedList einzeln = new DoublyLinkedList();
einzeln.AddLast(99);
PrintVorher(einzeln, "1c) Spezialfall ein Element (RemoveLast -> Head UND Tail werden null)");
Console.WriteLine("  ⚡ AKTION:   wert = einzeln.RemoveLast();");
wert = einzeln.RemoveLast();
Console.WriteLine($"  👉 RÜCKGABE: {wert} | ERWARTET: 99");
PrintNachher(einzeln,
    erwartetCount: 0,
    erwartetNext: "",
    erwartetPrev: "");


// -------------------------------------------------------------------------------------------------
// 2. TEST: RemoveAt (Mitte via GetNodeAt, Spezialfall Index 0 & Index Count - 1)
// -------------------------------------------------------------------------------------------------
Console.WriteLine("\n################################################################################");
Console.WriteLine("  2. TEST: RemoveAt (Mitte via GetNodeAt, Spezialfall Index 0 & Index Count - 1)");
Console.WriteLine("################################################################################");

list.AddLast(70);
list.AddLast(15);
list.AddLast(35);

// 2a) Mitte
PrintVorher(list, "2a) In der Mitte entfernen (RemoveAt an Index 3)");
Console.WriteLine("  ⚡ AKTION:   wert = list.RemoveAt(3);");
wert = list.RemoveAt(3);
Console.WriteLine($"  👉 RÜCKGABE: {wert} | ERWARTET: 20");
PrintNachher(list,
    erwartetCount: 6,
    erwartetNext: "[10] <-> [50] <-> [30] <-> [70] <-> [15] <-> [35]",
    erwartetPrev: "[35] <-> [15] <-> [70] <-> [30] <-> [50] <-> [10]");

// 2b) Index 0 -> RemoveFirst
PrintVorher(list, "2b) Spezialfall Anfang (RemoveAt an Index 0 -> RemoveFirst)");
Console.WriteLine("  ⚡ AKTION:   wert = list.RemoveAt(0);");
wert = list.RemoveAt(0);
Console.WriteLine($"  👉 RÜCKGABE: {wert} | ERWARTET: 10");
PrintNachher(list,
    erwartetCount: 5,
    erwartetNext: "[50] <-> [30] <-> [70] <-> [15] <-> [35]",
    erwartetPrev: "[35] <-> [15] <-> [70] <-> [30] <-> [50]");

// 2c) Index Count - 1 -> RemoveLast
PrintVorher(list, "2c) Spezialfall Ende (RemoveAt an Index Count - 1 -> RemoveLast)");
Console.WriteLine($"  ⚡ AKTION:   wert = list.RemoveAt({list.Count - 1});");
wert = list.RemoveAt(list.Count - 1);
Console.WriteLine($"  👉 RÜCKGABE: {wert} | ERWARTET: 35");
PrintNachher(list,
    erwartetCount: 4,
    erwartetNext: "[50] <-> [30] <-> [70] <-> [15]",
    erwartetPrev: "[15] <-> [70] <-> [30] <-> [50]");


// -------------------------------------------------------------------------------------------------
// 3. TEST: Reverse (Liste umdrehen)
// -------------------------------------------------------------------------------------------------
Console.WriteLine("\n################################################################################");
Console.WriteLine("  3. TEST: Reverse (Next und Previous jedes Knotens tauschen, Head und Tail tauschen)");
Console.WriteLine("################################################################################");

list.AddLast(30);
list.AddLast(5);
list.AddLast(50);

PrintVorher(list, "3a) Liste umdrehen");
Console.WriteLine("  ⚡ AKTION:   list.Reverse();");
list.Reverse();
PrintNachher(list,
    erwartetCount: 7,
    erwartetNext: "[50] <-> [5] <-> [30] <-> [15] <-> [70] <-> [30] <-> [50]",
    erwartetPrev: "[50] <-> [30] <-> [70] <-> [15] <-> [30] <-> [5] <-> [50]");

PrintVorher(list, "3b) Zweimal umdrehen ergibt wieder die ursprüngliche Reihenfolge");
Console.WriteLine("  ⚡ AKTION:   list.Reverse();");
list.Reverse();
PrintNachher(list,
    erwartetCount: 7,
    erwartetNext: "[50] <-> [30] <-> [70] <-> [15] <-> [30] <-> [5] <-> [50]",
    erwartetPrev: "[50] <-> [5] <-> [30] <-> [15] <-> [70] <-> [30] <-> [50]");

DoublyLinkedList eins = new DoublyLinkedList();
eins.AddLast(7);
PrintVorher(eins, "3c) Spezialfall ein Element");
Console.WriteLine("  ⚡ AKTION:   eins.Reverse();");
eins.Reverse();
PrintNachher(eins,
    erwartetCount: 1,
    erwartetNext: "[7]",
    erwartetPrev: "[7]");


// -------------------------------------------------------------------------------------------------
// 4. TEST: HasLoop (Vorwärts- und Rückwärtsprüfung)
// -------------------------------------------------------------------------------------------------
Console.WriteLine("\n################################################################################");
Console.WriteLine("  4. TEST: HasLoop (Zykluserkennung in Next- und Previous-Richtung)");
Console.WriteLine("################################################################################\n");

Console.WriteLine("4a) Intakte Liste:");
Console.WriteLine("  ⚡ AKTION:   bool hatLoop = list.HasLoop();");
Console.WriteLine($"  👉 ERGEBNIS: {list.HasLoop()} | ERWARTET: False\n");

Console.WriteLine("4b) Künstlicher Zyklus im NEXT-Pfad (Tail.Next = Head.Next):");
Node alterTail = list.Tail;
alterTail.Next = list.Head.Next;
Console.WriteLine($"  ⚡ AKTION:   Tail.Next zeigt auf Node({list.Head.Next.Value});");
Console.WriteLine($"  👉 ERGEBNIS: {list.HasLoop()} | ERWARTET: True");
alterTail.Next = null;
Console.WriteLine("  🧹 BEREINIGT: Tail.Next = null;\n");

Console.WriteLine("4c) Künstlicher Zyklus im PREVIOUS-Pfad (Head.Next.Previous = Tail.Previous):");
Node zweiter = list.Head.Next;
zweiter.Previous = list.Tail.Previous;
Console.WriteLine($"  ⚡ AKTION:   Head.Next.Previous zeigt auf Node({list.Tail.Previous.Value});");
Console.WriteLine($"  👉 ERGEBNIS: {list.HasLoop()} | ERWARTET: True");
zweiter.Previous = list.Head;
Console.WriteLine("  🧹 BEREINIGT: Head.Next.Previous = Head;\n");

Console.WriteLine("4d) Leere Liste:");
Console.WriteLine($"  👉 ERGEBNIS: {einzeln.HasLoop()} | ERWARTET: False\n");

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
    if (erwartetCount == 0)
    {
        Console.WriteLine("            Next:     HEAD -> null");
        Console.WriteLine("            Previous: TAIL -> null\n");
        return;
    }
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