**Zettelübung: Logische Operatoren, Schleifen und Verzweigungen**

**Name:** 
_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 
**Datum:** 
_ _ _ _ _ _ _ _ _ _ _ _ 

### Logische Operatoren

**Übung 1: Schachbrettartig 🙂**
Versuche die logische Formel für folgendes Muster zu finden.
```
             x
    🟦0️⃣1️⃣2️⃣3️⃣4️⃣5️⃣
    0️⃣🔺⬛⬜🔺⬛⬜
    1️⃣⬛⬜🔺⬛⬜🔺
  y 2️⃣⬜🔺⬛⬜🔺⬛
    3️⃣🔺⬛⬜🔺⬛⬜
    4️⃣⬛⬜🔺⬛⬜🔺
    5️⃣⬜🔺⬛⬜🔺⬛
```

```csharp
bool istWeissesFeld     = ________________________________________________;
bool istSchwarzesFeld   = ________________________________________________;
bool istRotesFeld       = ________________________________________________;
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
.
.
.
**Übung 2: Schachbrettartig, ähnlich aber anders 🤔**
Versuche die logische Formel für folgendes Muster zu finden.
>Hinweis: Schau dir das Schachbrett mit zwei abwechselnden Farben an.
```
             x
    🟦0️⃣1️⃣2️⃣3️⃣4️⃣5️⃣
    0️⃣🔺⬛⬜🔺⬜⬛
    1️⃣⬛⬜🔺⬜⬛🔺
  y 2️⃣⬜🔺⬜⬛🔺⬛
    3️⃣🔺⬜⬛🔺⬛⬜
    4️⃣⬜⬛🔺⬛⬜🔺
    5️⃣⬛🔺⬛⬜🔺⬜
```

```csharp
bool istWeissesFeld     = ________________________________________________;
bool istSchwarzesFeld   = ________________________________________________;
bool istRotesFeld       = ________________________________________________;
```

**Übung 3: Ringe 💀**
Versuche die logische Formel für folgendes Muster zu finden.
>Hinweis: Schau dir das Schachbrett mit zwei abwechselnden Farben an.
```
             x
    🟦0️⃣1️⃣2️⃣3️⃣4️⃣5️⃣6️⃣
    0️⃣⬛⬛⬛⬛⬛⬛⬛
    1️⃣⬛⬜⬜⬜⬜⬜⬛
    2️⃣⬛⬜⬛⬛⬛⬜⬛
  y 3️⃣⬛⬜⬛🔺⬛⬜⬛
    4️⃣⬛⬜⬛⬛⬛⬜⬛
    5️⃣⬛⬜⬜⬜⬜⬜⬛
    6️⃣⬛⬛⬛⬛⬛⬛⬛
```

```csharp
bool istWeissesFeld     = ________________________________________________;
bool istSchwarzesFeld   = ________________________________________________;
```
.
.
.
.
.
.
.
### Schleifen

**Übung 4: Ausgabe einer blauen Fläche**
```
🟦🟦🟦🟦🟦
🟦🟦🟦🟦🟦
🟦🟦🟦🟦🟦
🟦🟦🟦🟦🟦
🟦🟦🟦🟦🟦
```

```csharp
for (int i = 0; i < 5 * 5; i++)
{
    Console.Write("🟦");
}
```
Erzeugt dieser Code das angegebene Muster? Erkläre wieso oder wieso nicht.


**Übung 4: Ausgabe einer blauen Fläche - Teil 2**
Befülle die Lücken um folgendes Muster zu erzeugen.
```
🟦🟦🟦🟦🟦
🟦🟦🟦🟦🟦
🟦🟦🟦🟦🟦
🟦🟦🟦🟦🟦
🟦🟦🟦🟦🟦
```

```csharp
for (________; ________; ________)
{
    for (________; ________; ________)
    {
        Console.Write("🟦");
    }

    ________________________;
}
```
.
.
.
.
.
.
.
### Schleifen mit Verzweigungen
**Übung 5: Alles zusammen**
Vervollständige den folgenden Code, indem die fehlenden Variablen, ``Operatoren`` oder ``Methodenaufrufe`` in die Lücken (`___`) einträgst. Das Muster aus *Übung 1* ist abzubilden. 
```
int groesse = 5;
// Zustaendigkeit: Gehe jede Zeile des Musters ab
for (________; ________; ________)
{
    // Zustaendigkeit: Gehe jede Spalte des Musters ab
    for (________; ________; ________)
    {
        // Zusztaendigkeit: Entscheide ob ein Feld weiß, schwarz oder rot ist.
        bool ist________Feld = ________________________________________________;
        bool ist________Feld = ________________________________________________;
        bool ist________Feld = ________________________________________________;
        // Zustaendigkeit: 
        // Wenn das Feld weiß ist, ...
        ______ (_________________________)
        {
            // dann schreibe es auf die Console, 
            Console.Write("⬜");
        }
        // ansonsten, Wenn das Feld schwarz ist, ...
        ______ (_________________________)
        {
            // dann schreibe es auf die Console, 
            Console.Write("⬛");
        }
        // ansonsten, Wenn das Feld rot ist, ...
        ______ (_________________________)
        {
            // dann schreibe es auf die Console, 
            Console.Write("🔺");
        }
        // ansonsten, wenn wir einen Fehler gemacht haben...
        ______
        {
            // schreibe das Fehler-Symbol auf die Console, 
            Console.Write("💀");
        }
    }
    ________________________;
}
```