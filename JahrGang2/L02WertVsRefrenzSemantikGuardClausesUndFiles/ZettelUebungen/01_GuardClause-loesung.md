**Zettelübung: De Morgans Gesetz & Guard Clauses**

**Name:** 
Musterlösung 
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

if (A)
{
    if (B)
    {
        return true; // ✅ gewünschter Zustand (A und B sind wahr)
    }
    else
    {
        return false; // ❌ ungewünschter Zustand (B ist falsch)
    }
}
else
{
    return false; // ❌ ungewünschter Zustand (A ist falsch)
}
```

**2. Logisches ODER:** 
Schreibe den Code für `bool bedingung = A || B;` in Form von untereinander geschriebenen `bedingten Anweisungen`, um den ``gewünschten Zustand`` ✅ *return true* zu erreichen und die ``ungewünschten Zustände`` ❌ *return false*:

```csharp
// Schreibe deinen Code hier:
bool A = true;
bool B = false;

if (A)
{
    return true; // ✅ gewünschter Zustand (A ist wahr)
}

if (B)
{
    return true; // ✅ gewünschter Zustand (B ist wahr)
}

return false; // ❌ ungewünschter Zustand (weder A noch B ist wahr)
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
if (user is null)
{
    Console.WriteLine("❌ User is null.");
    return;
}

if (!user.IsRegistered)
{
    Console.WriteLine("❌ User is not registered.");
    return;
}

if (user.Age < 18)
{
    Console.WriteLine("❌ User is too young.");
    return;
}

// gewünschter Zustand ✅
Console.WriteLine("✅ User is processed.");
```