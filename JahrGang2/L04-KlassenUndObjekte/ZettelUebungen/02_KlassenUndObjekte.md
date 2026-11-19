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
| ``darstellung`` | |
| ``anzahlSchritte`` | |
| ``Bewegen(string richtung)`` | |
| ``Hamster((int x, int y) start, string darstellung, Hamster freund)`` | |
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
Schreibe eine ``Klasse`` *Hamster* (eigenes File *Hamster.cs*) mit fünf öffentlichen ``Feldern``:
* *position* vom ``Typ`` *(int x, int y)*
* *darstellung* vom ``Typ`` *string*
* *richtung* vom ``Typ`` *string*
* *anzahlSchritte* vom ``Typ`` *int*
* *freund* vom ``Typ`` *Hamster*
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

#### 2. - Konstruktor
Ergänze einen ``Konstruktor``, der eine Startposition *start*, eine *darstellung* und einen *freund* übernimmt und in den passenden ``Feldern`` speichert.
```csharp
// ___________________________________________
// ___________________________________________
// ___________________________________________
// ___________________________________________
// ___________________________________________
// ___________________________________________
```

#### 3. - Methoden
Ergänze die ``Methode`` *Bewegen*, die eine Richtung als *string* übernimmt, im ``Feld`` *richtung* speichert, *anzahlSchritte* um 1 erhöht und z. B. *🐹 Schritt 3: geht nach N* ausgibt, und die ``Methode`` *Nachmachen*, die *Bewegen* mit der Richtung des Freundes aufruft.
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
```

#### 4. - Objekte erzeugen
Erzeuge zwei Hamster *paul* (🐹) bei ``(0, 0)`` und *willi* (🐭) **direkt rechts daneben**. *willi* soll *paul* als Freund haben. Übergib **alles** über den ``Konstruktor`` – setze keine ``Felder`` von außen. Danach geht *paul* nach ``"S"`` und *willi* macht nach.
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
Hamster paul  = new Hamster((2, 3), "🐹", null);
Hamster willi = new Hamster((3, 3), "🐭", paul);
Hamster gerri = new Hamster((2, 4), "🐰", paul);
paul.Bewegen("W");
willi.Nachmachen();
```
```
 
 
 
 
 
 
 
 
```
**Frage:** Welchen ``Wert`` hat *gerri.richtung*? Warum? Was steht in der Konsole?
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
Hamster paul = new Hamster((0, 0), "🐹", null);
Hamster.Bewegen("N");
```
**Was passiert?** / **Korrigierter Code:**
```csharp
// ___________________________________________
// ___________________________________________
```

#### 2. - Nachmachen
```csharp
Hamster paul  = new Hamster((0, 0), "🐹", null);
Hamster willi = new Hamster((1, 0), "🐭", null);
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
    public string darstellung;
    public Hamster freund;

    public void Hamster((int x, int y) start, string darstellung, Hamster freund)
    {
        position = start;
        this.darstellung = darstellung;
        this.freund = freund;
    }
}
```
**Was passiert?** / **Korrigierter Code:**
```csharp
// ___________________________________________
// ___________________________________________
// ___________________________________________
```
