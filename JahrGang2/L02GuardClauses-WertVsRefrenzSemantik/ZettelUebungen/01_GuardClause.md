**Zettelübung: De Morgans Gesetz & Guard Clauses**

**Name:** 
_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 
**Datum:** 
_ _ _ _ _ _ _ _ _ _ _ _ 

---

**Übung 1: ``Logische Operatoren`` und ``Verzweigungen`` und ``Bedingte Anweisungen``**
Wir haben gelernt, dass logische Verknüpfungen direkt in die Struktur von `Verzweigungen` übersetzt werden können. 
Ergänze den Code so, dass er das `logische UND` sowie das `logische ODER` darstellt. 

**1. Logisches UND:** 
Schreibe den Code für `bool bedingung = A && B;` in Form von ``verschachtelten Verzweigungen``, um den ``gewünschten Zustand`` ✅ *return true* zu erreichen und die ``ungewünschten Zustände`` ❌ *return false*:

```csharp
// Schreibe deinen Code hier:
bool A = true;
bool B = false;












```

**2. Logisches ODER:** 
Schreibe den Code für `bool bedingung = A || B;` in Form von untereinander geschriebenen `bedingten Anweisungen`, um den ``gewünschten Zustand`` ✅ *return true* zu erreichen und die ``ungewünschten Zustände`` ❌ *return false*:

```csharp
// Schreibe deinen Code hier:
bool A = true;
bool B = false;














```

---

**Übung 2: Guard Clauses anwenden**
Gegeben ist der folgende, schwerer lesbare Code mit ``Verschachtelung``. 

```csharp
if (user is not null)
{
    if (user.IsRegistered)
    {
        if (user.Age >= 18)
        {
            Console.WriteLine("✅ User is processed.");
        }
        else
        {
            Console.WriteLine("❌ User is too young.");
        }
    }
    else
    {
        Console.WriteLine("❌ User is not registered.");
    }
}
else
{
    Console.WriteLine("❌ User is null.");
}
```

**Aufgabe:** Schreibe diesen Code in sauber lesbare `Guard Clauses` um. Negiere dafür die Bedingungen aus den If-Verzweigungen, nutze den *Early Exit* (`return`) für die ❌ unerwünschten Zustände, um das Verschachteln zu vermeiden, und behalte den ✅ gewünschten Zustand am Ende.

```csharp
// Schreibe deine Guard Clauses hier:
// Ungewünschte Zustände ❌


















// gewünschter Zustand ✅


```