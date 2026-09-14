**Zettelübung: 2D-Arrays**

**Name:** ___________________________ **Klasse:** _________ **Datum:** _________

**Aufgabe 1: Code-Analyse – Was gibt die Konsole aus?**
Gegeben ist der folgende C#-Code mit einem 2D-Array. Betrachte den Code genau und notiere rechts daneben, was auf der Konsole ausgegeben wird.

```csharp
int[,] spielfeld = 
{
    { 10, 20, 30 },
    { 40, 50, 60 },
    { 70, 80, 90 }
};

// 1. Einzelne Zugriffe:
Console.WriteLine(spielfeld[0, 2]);      // Ausgabe: ___________
Console.WriteLine(spielfeld[2, 0]);      // Ausgabe: ___________
Console.WriteLine(spielfeld[1, 1]);      // Ausgabe: ___________

// 2. Verschachtelte Schleife:
for (int y = 0; y < 2; y++)
{
    for (int x = 0; x < 2; x++)
    {
        Console.WriteLine(spielfeld[y, x] + " ");
    }
    Console.Write();
}
// Trage hier die exakte Ausgabe der Schleifen ein (inkl. Zeilenumbrüche):
// ___________________
// ___________________

// 3. Verschachtelte Schleife:
for (int x = 0; x < 2; x++)
{
    for (int y = 0; y < 2; y++)
    {
        Console.Write(spielfeld[x, y] + " ");
    }
    Console.WriteLine();
}
// Trage hier die exakte Ausgabe der Schleifen ein (inkl. Zeilenumbrüche):
// ___________________
// ___________________

// 4. Verschachtelte Schleife:
for (int x = 0; x < 4; x++)
{
    for (int y = 0; y < 2; y++)
    {
        Console.Write(spielfeld[y, x] + " ");
    }
    Console.WriteLine();
}
// Trage hier die exakte Ausgabe der Schleifen ein (inkl. Zeilenumbrüche):
// ___________________
// ___________________
```

**Aufgabe 2: Code ergänzen**
Vervollständige den folgenden Code, indem die fehlenden Zeichen, ``Indizes`` oder ``Methodenaufrufe`` in die Lücken (`___`) einträgst.

```csharp
// 1. Ein neues 2D-Array vom Typ string erstellen (4 Zeilen, 5 Spalten)
string[___] brett = _________ string[_, _];

// 2. Einen Hamster "🐹" in der 3. Zeile und 2. Spalte platzieren
brett[___, ___] = "🐹";

// 3. Das gesamte Array mit einer verschachtelten Schleife durchlaufen
for (int y = 0; y < ____________; y++)
{
    for (int x = 0; x < ____________; x++)
    {
        // 4. Den aktuellen Wert des Arrays soll nur für gerade Indices ausgegeben werden.
        ________
        ________
            Console.Write(________);
        ________
    }
    Console.WriteLine();
}
```
