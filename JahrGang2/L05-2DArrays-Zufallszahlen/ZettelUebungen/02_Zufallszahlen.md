**Zettelübung: Zufallszahlen 🎲**

**Name:** 
_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 
**Datum:** 
_ _ _ _ _ _ _ _ _ _ _ _ 

**Übung 1: Pen(C)il (Sharp)ener – Code am Zettel schreiben**

#### 1. - Generator anlegen
Lege einen *Zufallszahlengenerator* ``generator`` vom ``Typ`` *Random* an.
```csharp
// ___________________________________________
```
Lege einen *Zufallszahlengenerator* ``generator`` vom ``Typ`` *Random* mit dem ``Seed`` *101* an.
```csharp
// ___________________________________________
```
**Frage:** Was ist der Unterschied zwischen den beiden Generatoren, wenn du das Programm zweimal startest?
```
___________________________________________________________
___________________________________________________________
```

#### 2. - Kommazahlen in einem Bereich
Ziehe mit dem *Zufallszahlengenerator* eine Kommazahl vom ``Typ`` *double* und weise sie der ``Variable`` *bedingung* zu. Sie soll Zahlen zwischen 15.6 (inklusive) und 115.6 (exklusive) halten.
```csharp
// ___________________________________________
```

#### 3. - Mehrfachverzweigung
Frage mit einer ``Mehrfachverzweigung`` ab, ob die ``Variable`` *bedingung* zwischen
* 15.6 (inklusive) und 85.6 (exklusive) → *Console.WriteLine("common");*
* 85.6 (inklusive) und 110.6 (exklusive) → *Console.WriteLine("rare");*
* 110.6 (inklusive) und 115.6 (exklusive) → *Console.WriteLine("epic");*

liegt.
```csharp
// ___________________________________________
// ___________________________________________
// ___________________________________________
// ___________________________________________
// ___________________________________________
// ___________________________________________
// ___________________________________________
// ___________________________________________
// ___________________________________________
// ___________________________________________
// ___________________________________________
// ___________________________________________
```
**Frage:** Mit welcher Wahrscheinlichkeit (in %) wird *"epic"* ausgegeben?
```
___________________________________________________________
```

#### 4. - Ganze Zahlen in einem Bereich
Ziehe zwei ganze Zahlen vom ``Typ`` *int* und weise sie den ``Variablen`` *x* und *y* zu. Sie sollen Zahlen zwischen 10 (inklusive) und 25 (**inklusive**) halten.
```csharp
// ___________________________________________
// ___________________________________________
```
.
.
.
.
.
.
.
.
.
.
.
.
.
**Übung 2: Linearer Kongruenzgenerator (LCG)**

Gegeben ist der LCG $x_{i+1} = [(k \cdot x_i + d) \;\; \text{mod}\;\; m] + n$ mit $k = 5$, $d = 7$, $m = 16$, $n = 10$ und dem Seed $x_0=101$.

#### 1. - Rechnen
Berechne die ersten 3 Pseudozufallszahlen.

| $i$ | Aktueller Wert ($x_i$) | $k \cdot x_i + d$ | $\text{mod}\; m$ | Neuer Wert ($x_{i+1}$) |
| :--- | :--- | :--- | :--- | :--- |
| **0** | 101 |       |       |       |
| **1** |       |       |       |       |
| **2** |       |       |       |       |

#### 2. - Bereich verstehen
* Welche ist die **kleinste** und welche die **größte** Zahl, die dieser LCG liefern kann?
    ```
    kleinste: ________     größte: ________
    ```
* Nach wie vielen Zahlen wiederholt sich die Folge **spätestens**? Warum?
    ```
    ___________________________________________________________
    ```

#### 3. - Vom LCG zum C#-Code
Ergänze den C#-Code so, dass ``generator`` den gleichen ``Seed`` und den gleichen **Bereich** wie der LCG oben verwendet.
```csharp
Random generator = new Random(_____);
Console.WriteLine(generator.Next(_____, _____));
```
.
.
.
.
.
.
.
.
.
.
**Übung 3: Finde die Fehler und behebe sie**

#### 1. - Ausgabe mehrerer zufälliger ganzer Zahlen
```csharp
for (int x = 0; x < 100; x++)
{
    Random generator = new Random(101);
    Console.WriteLine(generator.Next(0, 25));
}
```
**Was passiert?** / **Korrigierter Code:**
```csharp
// ___________________________________________
// ___________________________________________
// ___________________________________________
// ___________________________________________
// ___________________________________________
```

#### 2. - Zugriff auf Arrays mit zufälligem Index
```csharp
int[] zahlen = new int[10];
Random generator = new Random(101);

for (int x = 0; x < 3; x++)
{
    int index = generator.Next(x, zahlen.Length + 1);
    Console.WriteLine(zahlen[index]);
}
```
**Was passiert?** / **Korrigierter Code:**
```csharp
// ___________________________________________
// ___________________________________________
// ___________________________________________
// ___________________________________________
// ___________________________________________
```

#### 3. - Zufälliges Feld einer 2D-Karte
```csharp
string[,] karte = new string[20, 30]; // 20 Zeilen, 30 Spalten
Random generator = new Random();

int y = generator.Next(0, karte.GetLength(1));
int x = generator.Next(0, karte.GetLength(0));
karte[y, x] = "🌳";
```
**Was passiert?** / **Korrigierter Code:**
```csharp
// ___________________________________________
// ___________________________________________
// ___________________________________________
```
