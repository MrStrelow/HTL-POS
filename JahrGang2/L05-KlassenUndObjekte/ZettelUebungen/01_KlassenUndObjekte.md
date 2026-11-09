**Zettelübung: Klassen und Objekte 🐹**

**Name:** 
_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 
**Datum:** 
_ _ _ _ _ _ _ _ _ _ _ _ 

**Übung 1: Begriffe zuordnen**

Ordne jeden Begriff aus dem Hamster-Programm **einem** Fachbegriff zu: ``Klasse``, ``Objekt``, ``Feld``, ``Konstruktor``, ``Methode``.

| Begriff | Fachbegriff |
| :--- | :--- |
| ``Hamster`` (der Bauplan) | |
| *paul* (ein konkreter Hamster) | |
| ``position`` | |
| ``Bewegen(string richtung)`` | |
| ``Hamster((int x, int y) start)`` | |
| ``freund`` | |
| ``Nachmachen()`` | |

**Frage:** Woran erkennst du im Code einen ``Konstruktor``? Nenne **zwei** Merkmale.
```
___________________________________________________________
___________________________________________________________
```
.
.
.
.
.
.
**Übung 2: Pen(C)il (Sharp)ener – Code am Zettel schreiben**

#### 1. - Klasse mit Feldern
Schreibe eine ``Klasse`` *Hamster* mit drei öffentlichen ``Feldern``:
* *position* vom ``Typ`` *(int x, int y)*
* *richtung* vom ``Typ`` *string*
* *freund* vom ``Typ`` *Hamster*
```csharp
// ___________________________________________
// ___________________________________________
// ___________________________________________
// ___________________________________________
// ___________________________________________
// ___________________________________________
```

#### 2. - Konstruktor
Ergänze einen ``Konstruktor``, der eine Startposition *start* übernimmt und im ``Feld`` *position* speichert.
```csharp
// ___________________________________________
// ___________________________________________
// ___________________________________________
// ___________________________________________
```

#### 3. - Methoden
Ergänze die ``Methode`` *Bewegen*, die eine Richtung als *string* übernimmt und im ``Feld`` *richtung* speichert, und die ``Methode`` *Nachmachen*, die *Bewegen* mit der Richtung des Freundes aufruft.
```csharp
// ___________________________________________
// ___________________________________________
// ___________________________________________
// ___________________________________________
// ___________________________________________
// ___________________________________________
// ___________________________________________
// ___________________________________________
```

#### 4. - Objekte erzeugen
Erzeuge zwei Hamster *paul* bei ``(0, 0)`` und *willi* **direkt rechts daneben**. *willi* soll *paul* als Freund haben. Danach geht *paul* nach ``"S"`` und *willi* macht nach.
```csharp
// ___________________________________________
// ___________________________________________
// ___________________________________________
// ___________________________________________
// ___________________________________________
```
.
.
.
.
.
.
**Übung 3: Objektdiagramm zeichnen**

Zeichne das ``Objektdiagramm`` **nach** dem folgenden Code (Objekte mit ``name : Klasse``, alle ``Felder`` mit ihren ``Werten``, Pfeil für die hat-Beziehung):
```csharp
Hamster paul  = new Hamster((2, 3));
Hamster willi = new Hamster((3, 3));
Hamster gerri = new Hamster((2, 4));
willi.freund = paul;
gerri.freund = paul;
paul.Bewegen("W");
willi.Nachmachen();
```
```
 
 
 
 
 
 
 
 
```
**Frage:** Welchen ``Wert`` hat *gerri.richtung*? Warum?
```
___________________________________________________________
___________________________________________________________
```
.
.
.
.
.
.
**Übung 4: Finde die Fehler und behebe sie**

#### 1. - Methode aufrufen
```csharp
Hamster paul = new Hamster((0, 0));
Hamster.Bewegen("N");
```
**Was passiert?** / **Korrigierter Code:**
```csharp
// ___________________________________________
// ___________________________________________
```

#### 2. - Nachmachen
```csharp
Hamster paul  = new Hamster((0, 0));
Hamster willi = new Hamster((1, 0));
paul.Bewegen("O");
willi.Nachmachen();
```
**Was passiert?** / **Korrigierter Code:**
```csharp
// ___________________________________________
// ___________________________________________
// ___________________________________________
```

#### 3. - Konstruktor
```csharp
class Hamster
{
    public (int x, int y) position;

    public void Hamster((int x, int y) start)
    {
        position = start;
    }
}
```
**Was passiert?** / **Korrigierter Code:**
```csharp
// ___________________________________________
// ___________________________________________
// ___________________________________________
```
