---
theme: seriph
layout: two-cols
---

::left::

````md magic-move {lines: true}
```csharp
if (requestIsValid) {
    if (isAdmin) {
        if (18 <= age && age < 35) {
            Console.WriteLine("✅ Admin is processed.");
        } else {
            Console.WriteLine("❌ Admin is not valid.");
        }
    } else {
        if (registrationDate <= currentMonth) {
            Console.WriteLine("✅ Users is valid.");
        } else {
            Console.WriteLine("❌ User is not valid.");
        }
    }
} else {
    Console.WriteLine("❌ Request is not valid.");
}
```

```csharp {1,15-17}
if (requestIsValid) {
    if (isAdmin) {
        if (18 <= age && age < 35) {
            Console.WriteLine("✅ Admin is processed.");
        } else {
            Console.WriteLine("❌ Admin is not valid.");
        }
    } else {
        if (registrationDate <= currentMonth) {
            Console.WriteLine("✅ Users is valid.");
        } else {
            Console.WriteLine("❌ User is not valid.");
        }
    }
} else {
    Console.WriteLine("❌ Request is not valid.");
}
```

```csharp
if (requestIsValid) {
    if (isAdmin) {
        if (18 <= age && age < 35) {
            Console.WriteLine("✅ Admin is processed.");
        } else {
            Console.WriteLine("❌ Admin is not valid.");
        }
    } else {
        if (registrationDate <= currentMonth) {
            Console.WriteLine("✅ Users is valid.");
        } else {
            Console.WriteLine("❌ User is not valid.");
        }
    }
} 
```

```csharp
if (requestIsValid) {
    if (isAdmin) {
        if (18 <= age && age < 35) {
            Console.WriteLine("✅ Admin is processed.");
        } else {
            Console.WriteLine("❌ Admin is not valid.");
        }
    } else {
        if (registrationDate <= currentMonth) {
            Console.WriteLine("✅ Users is valid.");
        } else {
            Console.WriteLine("❌ User is not valid.");
        }
    }
} 
```
````

::right::

````md magic-move {lines: true}
```csharp
// Guards
// ❌ ungewünschte Zustände abfangen



// ✅ gewünschte Zustände ausführen



```

```csharp
// Guards
// ❌ ungewünschte Zustände abfangen



// ✅ gewünschte Zustände ausführen



```

```csharp {3-6}
// Guards
// ❌ ungewünschte Zustände abfangen
if () {
    
    return;
}

// ✅ gewünschte Zustände ausführen



```

```csharp {3-7}
// Guards
// ❌ ungewünschte Zustände abfangen
if (!requestIsValid) {
    Console.WriteLine("❌ Request is not valid.");
    return;
}

// ✅ gewünschte Zustände ausführen



```
````

---
layout: two-cols
---

::left::

````md magic-move {lines: true}
```csharp
if (requestIsValid) {
    if (isAdmin) {
        if (18 <= age && age < 35) {
            Console.WriteLine("✅ Admin is processed.");
        } else {
            Console.WriteLine("❌ Admin is not valid.");
        }
    } else {
        if (registrationDate <= currentMonth) {
            Console.WriteLine("✅ Users is valid.");
        } else {
            Console.WriteLine("❌ User is not valid.");
        }
    }
} 
```

```csharp {9,10,12-14}
if (requestIsValid) {
    if (isAdmin) {
        if (18 <= age && age < 35) {
            Console.WriteLine("✅ Admin is processed.");
        } else {
            Console.WriteLine("❌ Admin is not valid.");
        }
    } else {
        if (registrationDate <= currentMonth) {
            Console.WriteLine("✅ Users is valid.");
        } else {
            Console.WriteLine("❌ User is not valid.");
        }
    }
} 
```

```csharp
if (requestIsValid) {
    if (isAdmin) {
        if (18 <= age && age < 35) {
            Console.WriteLine("✅ Admin is processed.");
        } else {
            Console.WriteLine("❌ Admin is not valid.");
        }
    } else {
        if (registrationDate <= currentMonth) {
            Console.WriteLine("✅ Users is valid.");
        } 
    }
} 
```

```csharp
if (requestIsValid) {
    if (isAdmin) {
        if (18 <= age && age < 35) {
            Console.WriteLine("✅ Admin is processed.");
        } else {
            Console.WriteLine("❌ Admin is not valid.");
        }
    } else {
        if (registrationDate <= currentMonth) {
            Console.WriteLine("✅ Users is valid.");
        } 
    }
} 
```
````

::right::

````md magic-move {lines: true}
```csharp
// Guards
// ❌ ungewünschte Zustände abfangen
if (!requestIsValid) {
    Console.WriteLine("❌ Request is not valid.");
    return;
}

// ✅ gewünschte Zustände ausführen



```

```csharp
// Guards
// ❌ ungewünschte Zustände abfangen
if (!requestIsValid) {
    Console.WriteLine("❌ Request is not valid.");
    return;
}

// ✅ gewünschte Zustände ausführen



```

```csharp {8-11}
// Guards
// ❌ ungewünschte Zustände abfangen
if (!requestIsValid) {
    Console.WriteLine("❌ Request is not valid.");
    return;
}

if () {
    
    return;
}

// ✅ gewünschte Zustände ausführen
```

```csharp {8-12}
// Guards
// ❌ ungewünschte Zustände abfangen
if (!requestIsValid) {
    Console.WriteLine("❌ Request is not valid.");
    return;
}

if (!isAdmin && registrationDate > currentMonth) {
    Console.WriteLine("❌ User is not valid.");
    return;
}

// ✅ gewünschte Zustände ausführen
```
````

---
layout: two-cols
---

::left::

````md magic-move {lines: true}
```csharp
if (requestIsValid) {
    if (isAdmin) {
        if (18 <= age && age < 35) {
            Console.WriteLine("✅ Admin is processed.");
        } else {
            Console.WriteLine("❌ Admin is not valid.");
        }
    } else {
        if (registrationDate <= currentMonth) {
            Console.WriteLine("✅ Users is valid.");
        } 
    }
} 
```

```csharp {3,4,6-8}
if (requestIsValid) {
    if (isAdmin) {
        if (18 <= age && age < 35) {
            Console.WriteLine("✅ Admin is processed.");
        } else {
            Console.WriteLine("❌ Admin is not valid.");
        }
    } else {
        if (registrationDate <= currentMonth) {
            Console.WriteLine("✅ Users is valid.");
        } 
    }
} 
```

```csharp
if (requestIsValid) {
    if (isAdmin) {
        if (18 <= age && age < 35) {
            Console.WriteLine("✅ Admin is processed.");
        } 
    } else {
        if (registrationDate <= currentMonth) {
            Console.WriteLine("✅ Users is valid.");
        } 
    }
} 
```

```csharp
if (requestIsValid) {
    if (isAdmin) {
        if (18 <= age && age < 35) {
            Console.WriteLine("✅ Admin is processed.");
        } 
    } else {
        if (registrationDate <= currentMonth) {
            Console.WriteLine("✅ Users is valid.");
        } 
    }
} 
```
````

::right::

````md magic-move {lines: true}
```csharp
// Guards
// ❌ ungewünschte Zustände abfangen
if (!requestIsValid) {
    Console.WriteLine("❌ Request is not valid.");
    return;
}

if (!isAdmin && registrationDate > currentMonth) {
    Console.WriteLine("❌ User is not valid.");
    return;
}

// ✅ gewünschte Zustände ausführen
```

```csharp
// Guards
// ❌ ungewünschte Zustände abfangen
if (!requestIsValid) {
    Console.WriteLine("❌ Request is not valid.");
    return;
}

if (!isAdmin && registrationDate > currentMonth) {
    Console.WriteLine("❌ User is not valid.");
    return;
}

// ✅ gewünschte Zustände ausführen
```

```csharp {14-17}
// Guards
// ❌ ungewünschte Zustände abfangen
if (!requestIsValid) {
    Console.WriteLine("❌ Request is not valid.");
    return;
}

if (!isAdmin && registrationDate > currentMonth) {
    Console.WriteLine("❌ User is not valid.");
    return;
}

if () {
    
    return;
}

// ✅ gewünschte Zustände ausführen
```

```csharp {14-18}
// Guards
// ❌ ungewünschte Zustände abfangen
if (!requestIsValid) {
    Console.WriteLine("❌ Request is not valid.");
    return;
}

if (!isAdmin && registrationDate > currentMonth) {
    Console.WriteLine("❌ User is not valid.");
    return;
}

if (isAdmin && !(18 <= age && age < 35)) {
    Console.WriteLine("❌ Admin is not valid.");
    return;
}

// ✅ gewünschte Zustände ausführen
```
````

---
layout: two-cols
---

::left::

````md magic-move {lines: true}
```csharp
if (requestIsValid) {
    if (isAdmin) {
        if (18 <= age && age < 35) {
            Console.WriteLine("✅ Admin is processed.");
        } 
    } else {
        if (registrationDate <= currentMonth) {
            Console.WriteLine("✅ Users is valid.");
        } 
    }
} 
```

```csharp {1-11}
if (requestIsValid) {
    if (isAdmin) {
        if (18 <= age && age < 35) {
            Console.WriteLine("✅ Admin is processed.");
        } 
    } else {
        if (registrationDate <= currentMonth) {
            Console.WriteLine("✅ Users is valid.");
        } 
    }
} 
```

```csharp
// Block nach rechts verschoben ✅
```

```csharp
// Block nach rechts verschoben ✅
```
````

::right::

````md magic-move {lines: true}
```csharp
// Guards
// ❌ ungewünschte Zustände abfangen
if (!requestIsValid) {
    Console.WriteLine("❌ Request is not valid.");
    return;
}

if (!isAdmin && registrationDate > currentMonth) {
    Console.WriteLine("❌ User is not valid.");
    return;
}

if (isAdmin && !(18 <= age && age < 35)) {
    Console.WriteLine("❌ Admin is not valid.");
    return;
}

// ✅ gewünschte Zustände ausführen
```

```csharp
// Guards
// ❌ ungewünschte Zustände abfangen
if (!requestIsValid) {
    Console.WriteLine("❌ Request is not valid.");
    return;
}

if (!isAdmin && registrationDate > currentMonth) {
    Console.WriteLine("❌ User is not valid.");
    return;
}

if (isAdmin && !(18 <= age && age < 35)) {
    Console.WriteLine("❌ Admin is not valid.");
    return;
}

// ✅ gewünschte Zustände ausführen
```

```csharp {20-30}
// Guards
// ❌ ungewünschte Zustände abfangen
if (!requestIsValid) {
    Console.WriteLine("❌ Request is not valid.");
    return;
}

if (!isAdmin && registrationDate > currentMonth) {
    Console.WriteLine("❌ User is not valid.");
    return;
}

if (isAdmin && !(18 <= age && age < 35)) {
    Console.WriteLine("❌ Admin is not valid.");
    return;
}

// ✅ gewünschte Zustände ausführen
if (requestIsValid) {
    if (isAdmin) {
        if (18 <= age && age < 35) {
            Console.WriteLine("✅ Admin is processed.");
        } 
    } else {
        if (registrationDate <= currentMonth) {
            Console.WriteLine("✅ Users is valid.");
        } 
    }
} 
```

```csharp {20-24}
// Guards
// ❌ ungewünschte Zustände abfangen
if (!requestIsValid) {
    Console.WriteLine("❌ Request is not valid.");
    return;
}

if (!isAdmin && registrationDate > currentMonth) {
    Console.WriteLine("❌ User is not valid.");
    return;
}

if (isAdmin && !(18 <= age && age < 35)) {
    Console.WriteLine("❌ Admin is not valid.");
    return;
}

// ✅ gewünschte Zustände ausführen
if (isAdmin) {
    Console.WriteLine("✅ Admin is processed.");
} else {
    Console.WriteLine("✅ Users is valid.");
}
```
````