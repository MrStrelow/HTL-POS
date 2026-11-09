**Zettelübung: Zufallszahlen 🎲**

**Name:** 
Musterlösung 
**Datum:** 
_ _ _ _ _ _ _ _ _ _ _ _ 

**Übung 1: Pen(C)il (Sharp)ener – Code am Zettel schreiben**

#### 1. - Generator anlegen
```csharp
Random generator = new Random();
```
```csharp
Random generator = new Random(101);
```
**Frage:** Ohne Seed wird ein anderer Startwert (Seed) gewählt, deshalb gibt es bei jedem Start **andere** Zahlen. Mit Seed *101* liefert der Generator bei **jedem** Start **dieselbe** Zahlenfolge (gut zum Testen und Fehlersuchen).

#### 2. - Kommazahlen in einem Bereich
``NextDouble()`` liefert ``0.0`` (inklusive) bis ``1.0`` (exklusive). Wir **strecken** mit der Breite des Bereichs und **verschieben** um die Untergrenze:
```csharp
double bedingung = generator.NextDouble() * 100 + 15.6;   // Breite: 115.6 - 15.6 = 100
```

#### 3. - Mehrfachverzweigung
```csharp
if (bedingung < 85.6)
{
    Console.WriteLine("common");
}
else if (bedingung < 110.6)
{
    Console.WriteLine("rare");
}
else
{
    Console.WriteLine("epic");
}
```
>Die unteren Grenzen müssen nicht mehr geprüft werden: Jeder ``else``-Zweig weiß schon, dass die vorherige Bedingung falsch war.

**Frage:** Breite von *"epic"* / Gesamtbreite = (115.6 − 110.6) / 100 = **5%**.

#### 4. - Ganze Zahlen in einem Bereich
Bei ``Next(min, max)`` ist ``max`` **exklusive** → für 25 inklusive brauchen wir ``26``.
```csharp
int x = generator.Next(10, 26);
int y = generator.Next(10, 26);
```

**Übung 2: Linearer Kongruenzgenerator (LCG)**

#### 1. - Rechnen
| $i$ | Aktueller Wert ($x_i$) | $k \cdot x_i + d$ | $\text{mod}\; m$ | Neuer Wert ($x_{i+1}$) |
| :--- | :--- | :--- | :--- | :--- |
| **0** | 101 | 5 · 101 + 7 = 512 | 512 mod 16 = 0 | 0 + 10 = **10** |
| **1** | 10  | 5 · 10 + 7 = 57   | 57 mod 16 = 9  | 9 + 10 = **19** |
| **2** | 19  | 5 · 19 + 7 = 102  | 102 mod 16 = 6 | 6 + 10 = **16** |

#### 2. - Bereich verstehen
* ``mod 16`` liefert 0 bis 15, danach ``+ 10``: kleinste **10**, größte **25**.
* Spätestens nach **16** Zahlen: Es gibt nur 16 mögliche Werte. Sobald ein Wert ein zweites Mal vorkommt, wiederholt sich ab dort alles, weil der nächste Wert nur vom aktuellen abhängt (der „Kreis“ ist geschlossen).

#### 3. - Vom LCG zum C#-Code
```csharp
Random generator = new Random(101);
Console.WriteLine(generator.Next(10, 26));   // 10 bis 25
```
>Achtung: Seed und Bereich sind gleich, die **Zahlen** aber nicht – ``Random`` verwendet intern eine andere, viel bessere Formel.

**Übung 3: Finde die Fehler und behebe sie**

#### 1. - Ausgabe mehrerer zufälliger ganzer Zahlen
Der Generator wird in **jedem** Durchlauf mit demselben Seed neu angelegt → er beginnt jedes Mal von vorne → 100-mal **dieselbe** Zahl.
```csharp
Random generator = new Random(101);   // EINMAL vor der Schleife anlegen
for (int x = 0; x < 100; x++)
{
    Console.WriteLine(generator.Next(0, 25));
}
```

#### 2. - Zugriff auf Arrays mit zufälligem Index
``Next(x, zahlen.Length + 1)`` kann ``10`` liefern, der größte Index ist aber ``9`` → ``IndexOutOfRangeException``. Außerdem sollte die Untergrenze ``0`` sein, sonst werden vordere Elemente nie gewählt.
```csharp
int index = generator.Next(0, zahlen.Length);   // 0 bis 9
```

#### 3. - Zufälliges Feld einer 2D-Karte
``Next`` ist zwar exklusive – aber mit der **falschen Dimension**: ``y`` (Zeile) wird mit der **Breite** (``GetLength(1)`` = 30) gezogen → ``y`` ist 0 bis 29, Zeilen gibt es nur 0 bis 19 → bei ``y`` = 20 … 29 ``IndexOutOfRangeException``. Bei einer quadratischen Karte würde der Fehler nicht auffallen.
```csharp
int y = generator.Next(0, karte.GetLength(0));   // Zeilen: 0 bis 19
int x = generator.Next(0, karte.GetLength(1));   // Spalten: 0 bis 29
```
