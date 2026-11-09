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
| ``Bewegen(string richtung)`` | ``Methode`` |
| ``Hamster((int x, int y) start)`` | ``Konstruktor`` |
| ``freund`` | ``Feld`` (umgesetzte hat-Beziehung) |
| ``Nachmachen()`` | ``Methode`` |

**Frage:** Ein ``Konstruktor`` heißt **genau wie die Klasse** und hat **keinen Rückgabetyp** (auch kein ``void``). Er wird bei ``new`` automatisch aufgerufen.

**Übung 2: Pen(C)il (Sharp)ener – Code am Zettel schreiben**

#### 1. bis 3. - Klasse mit Feldern, Konstruktor und Methoden
```csharp
class Hamster
{
    public (int x, int y) position;
    public string richtung;
    public Hamster freund;

    public Hamster((int x, int y) start)
    {
        position = start;
    }

    public void Bewegen(string richtung)
    {
        this.richtung = richtung;
    }

    public void Nachmachen()
    {
        Bewegen(freund.richtung);
    }
}
```
>``this.richtung`` ist das ``Feld``, ``richtung`` allein der ``Parameter``. Ohne ``this`` würde der Parameter sich selbst zugewiesen.

#### 4. - Objekte erzeugen
```csharp
Hamster paul  = new Hamster((0, 0));
Hamster willi = new Hamster((1, 0));   // rechts daneben: x + 1
willi.freund = paul;
paul.Bewegen("S");
willi.Nachmachen();
```

**Übung 3: Objektdiagramm zeichnen**
```
+---------------------+   freund   +---------------------+   freund   +---------------------+
| willi : Hamster     |----------->| paul : Hamster      |<-----------| gerri : Hamster     |
| position = (3, 3)   |            | position = (2, 3)   |            | position = (2, 4)   |
| richtung = "W"      |            | richtung = "W"      |            | richtung = null     |
+---------------------+            | freund = null       |            +---------------------+
                                   +---------------------+
```
**Frage:** *gerri.richtung* ist ``null``. *gerri* kennt *paul* zwar, hat aber **nie** ``Nachmachen()`` aufgerufen. Eine hat-Beziehung allein ändert keinen ``Zustand`` – erst ein ``Methoden``-Aufruf tut das.
>Die ``position`` ändert sich nicht, weil ``Bewegen`` nur die Richtung speichert.

**Übung 4: Finde die Fehler und behebe sie**

#### 1. - Methode aufrufen
``Hamster`` ist die ``Klasse`` (der Bauplan) – der Bauplan kann nicht laufen. Wir müssen sagen, **welcher** Hamster sich bewegt → Compilerfehler.
```csharp
paul.Bewegen("N");
```

#### 2. - Nachmachen
*willi* hat keinen Freund: ``freund`` ist ``null`` → ``freund.richtung`` wirft eine ``NullReferenceException``.
```csharp
willi.freund = paul;   // vor willi.Nachmachen()
willi.Nachmachen();
```

#### 3. - Konstruktor
Mit ``void`` ist ``Hamster(...)`` kein ``Konstruktor``, sondern eine ``Methode`` – und eine ``Methode`` darf nicht wie die ``Klasse`` heißen → Compilerfehler. Außerdem würde ``new Hamster((0, 0))`` keinen passenden ``Konstruktor`` finden.
```csharp
public Hamster((int x, int y) start)
{
    position = start;
}
```
