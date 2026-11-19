**Zettelübung: 2D-Arrays**

**Name:** 
Musterlösung 
**Datum:** 
_ _ _ _ _ _ _ _ _ _ _ _ 

**Übung 1: Code-Analyse – Was gibt die Konsole aus?**

```csharp
int[,] spielfeld = 
{
    { 10, 20, 30 },   // Zeile y = 0
    { 40, 50, 60 },   // Zeile y = 1
    { 70, 80, 90 }    // Zeile y = 2
};
```
#### 1. - Zugriff mit Indices
```csharp
Console.WriteLine(spielfeld[0, 2]);      // Ausgabe: 30  (Zeile 0, Spalte 2)
Console.WriteLine(spielfeld[2, 0]);      // Ausgabe: 70  (Zeile 2, Spalte 0)
Console.WriteLine(spielfeld[1, 1]);      // Ausgabe: 50  (Mitte)
```

#### 2. - Verschachtelte Schleife
``Console.WriteLine`` macht nach **jedem** Wert einen Zeilenumbruch, ``Console.Write("")`` gibt nichts aus.
```
10 
20 
40 
50 
```

#### 3. - Verschachtelte Schleife
Die Namen ``x`` und ``y`` sind vertauscht – für das Array zählt aber nur die **Position** im Index: ``spielfeld[x, y]`` → ``x`` ist hier die Zeile.
```
10 20 
40 50 
```

#### 4. - Verschachtelte Schleife
``spielfeld[y, x]`` mit ``x`` bis 3: Es wird spaltenweise gelesen. Bei ``x = 3`` gibt es keine Spalte mehr (``GetLength(1)`` ist 3).
```
10 40 
20 50 
30 60 
💥 IndexOutOfRangeException
```

**Übung 2: Code ergänzen**

```csharp
// 1. Ein neues 2D-Array vom Typ string erstellen (4 Zeilen, 5 Spalten)
string[,] brett = new string[4, 5];

// 2. Einen Hamster "🐹" in der 3. Zeile und 2. Spalte platzieren
brett[2, 1] = "🐹";

// 3. Das gesamte Array mit einer verschachtelten Schleife durchlaufen
for (int y = 0; y < brett.GetLength(0); y++)
{
    for (int x = 0; x < brett.GetLength(1); x++)
    {
        // 4. Den aktuellen Wert des Arrays nur für gerade Indices ausgeben.
        if (y % 2 == 0 && x % 2 == 0)
        {
            Console.Write(brett[y, x]);
        }
    }
    Console.WriteLine();
}
```
