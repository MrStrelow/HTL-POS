**Zettelübung: Klassen und Objekte 🐹**

**Name:** 
Musterlösung 
**Datum:** 
_ _ _ _ _ _ _ _ _ _ _ _ 

**Übung 1: Begriffe zuordnen**

| Begriff | Fachbegriff |
| :--- | :--- |
| ``Hamster`` (der Bauplan) | ``Klasse`` |
| *paul* (ein konkreter Hamster) | ``Objekt`` (``Instanz``) |
| ``position`` | ``Feld`` |
| ``darstellung`` | ``Feld`` |
| ``anzahlSchritte`` | ``Feld`` |
| ``Bewegen(string richtung)`` | ``Methode`` |
| ``Hamster((int x, int y) start, string darstellung, Hamster freund)`` | ``Konstruktor`` |
| ``freund`` | ``Feld`` (umgesetzte hat-Beziehung) |
| ``Nachmachen()`` | ``Methode`` |

**Frage:** Ein ``Konstruktor`` heißt **genau wie die Klasse** und hat **keinen Rückgabetyp** (auch kein ``void``). Er wird bei ``new`` automatisch aufgerufen.

**Übung 2: Pen(C)il (Sharp)ener – Code am Zettel schreiben**

#### 1. bis 3. - Klasse mit Feldern, Konstruktor und Methoden
```csharp
class Hamster
{
    public (int x, int y) position;
    public string darstellung;
    public string richtung;
    public int anzahlSchritte;
    public Hamster freund;

    public Hamster((int x, int y) start, string darstellung, Hamster freund)
    {
        position = start;
        this.darstellung = darstellung;
        this.freund = freund;
    }

    public void Bewegen(string richtung)
    {
        this.richtung = richtung;
        anzahlSchritte++;
        Console.WriteLine($"{darstellung} Schritt {anzahlSchritte}: geht nach {richtung}");
    }

    public void Nachmachen()
    {
        Bewegen(freund.richtung);
    }
}
```
>``this.richtung`` ist das ``Feld``, ``richtung`` allein der ``Parameter``. Ohne ``this`` würde der Parameter sich selbst zugewiesen. Gleiches gilt für ``this.darstellung`` und ``this.freund``.

#### 4. - Objekte erzeugen
```csharp
Hamster paul  = new Hamster((0, 0), "🐹", null);   // paul hat keinen Freund
Hamster willi = new Hamster((1, 0), "🐭", paul);   // rechts daneben: x + 1
paul.Bewegen("S");
willi.Nachmachen();
```
Ausgabe:
```
🐹 Schritt 1: geht nach S
🐭 Schritt 1: geht nach S
```

**Übung 3: Objektdiagramm zeichnen**
```
+---------------------+   freund   +---------------------+   freund   +---------------------+
| willi : Hamster     |----------->| paul : Hamster      |<-----------| gerri : Hamster     |
| position = (3, 3)   |            | position = (2, 3)   |            | position = (2, 4)   |
| darstellung = "🐭"  |            | darstellung = "🐹"  |            | darstellung = "🐰"  |
| richtung = "W"      |            | richtung = "W"      |            | richtung = null     |
| anzahlSchritte = 1  |            | anzahlSchritte = 1  |            | anzahlSchritte = 0  |
+---------------------+            | freund = null       |            +---------------------+
                                   +---------------------+
```
**Frage:** *gerri.richtung* ist ``null``. *gerri* kennt *paul* zwar, hat aber **nie** ``Nachmachen()`` aufgerufen. Eine hat-Beziehung allein ändert keinen ``Zustand`` – erst ein ``Methoden``-Aufruf tut das.

Konsole:
```
🐹 Schritt 1: geht nach W
🐭 Schritt 1: geht nach W
```
>Die ``position`` ändert sich nicht, weil ``Bewegen`` nur die Richtung speichert.

**Übung 4: Finde die Fehler und behebe sie**

#### 1. - Methode aufrufen
``Hamster`` ist die ``Klasse`` (der Bauplan) – der Bauplan kann nicht laufen. Wir müssen sagen, **welcher** Hamster sich bewegt → Compilerfehler.
```csharp
paul.Bewegen("N");
```

#### 2. - Nachmachen
*willi* hat beim Erzeugen ``null`` als Freund bekommen → ``freund.richtung`` wirft eine ``NullReferenceException``. Den Freund geben wir über den ``Konstruktor`` mit:
```csharp
Hamster willi = new Hamster((1, 0), "🐭", paul);
willi.Nachmachen();
```

#### 3. - Konstruktor
Mit ``void`` ist ``Hamster(...)`` kein ``Konstruktor``, sondern eine ``Methode`` – und eine ``Methode`` darf nicht wie die ``Klasse`` heißen → Compilerfehler. Außerdem würde ``new Hamster((0, 0), "🐹", null)`` keinen passenden ``Konstruktor`` finden.
```csharp
public Hamster((int x, int y) start, string darstellung, Hamster freund)
{
    position = start;
    this.darstellung = darstellung;
    this.freund = freund;
}
```
