Welche ``Konzepte`` der Programmiersprache üben wir hier?
* Schleifen
* Verzweigungen
* User-Input
* Operatoren
* Methoden (Arrays als Argument in Methoden)

Welche ``Denkweisen`` üben wir hier?
* Wie löse wir ``kleinere Teile`` eines ``großen Problems`` und ``kombiniere`` diese?

Bei Unklarheiten hier nachlesen:
* [Welche Kontrollstrukturen kann ich verwenden?](../Skripten/L01.5Zusammenfassung-VariablenOperatorenKontrollstrukturen.md)

# Aus Dreiecken 📐 werden Diamanten 💠 - advanced

## Schritt 1: 🙂 - Verschiedene Dreiecke bauen
1. Generiere ``Formen``, welche vom in der *Main* ``Methode`` oder ``Top-Level Statements`` erstellt werden. Die *Formen* sind ``2D-Arrays`` welche **zwei** verschiedene ``Emojis`` benutzen um *rechtwinklige Dreiecke* 📐 in verschiedenen *90°-Orientierungen* darzustellen. 
    ```
    🔷◽◽◽◽◽
    🔷🔷◽◽◽◽
    🔷🔷🔷◽◽◽
    🔷🔷🔷🔷◽◽
    🔷🔷🔷🔷🔷◽
    🔷🔷🔷🔷🔷🔷
    ```
    Verwende dazu folgende ``Methoden``:
      * ``static string[,] DrawTriangle(string[,] field, string symbol)``: zeichnet die [Basisform](#basisform) in ein 2d-Array.
      * ``static string[,] MirrorX(string[,] field)``: spiegle ein 2d-Array um die x-Achse.
      * ``static string[,] MirrorY(string[,] field)``: spiegle ein 2d-Array um die y-Achse. Versuche mit `MirrorY`, `MirrorX` und `DrawTriangle` alle 4 Fälle Teile des [Diamanten](#zusammengesetzte-formen) ***einzeln*** darzustellen. 

2. Hilfsmethoden:
   * ``void Print(string[,] field)``: Gibt ein 2d-Array aus. Es soll die 1. Dimension in der `y Achse` und die 2. Dimension in der `x Achse` der Konsole sichbar sein (also nicht alles in eine Zeile schreiben).

   * ``string[,] FillCanvas(string[,] field, string symbol)``: Befüllt ein 2d-Array komplett mit einem Symbol.
   * ``static string[,] Copy(string[,] field)``: Kopiert den inhalt von einem 2d-Array in ein ***neues*** unter Verwendung von ``verschachtelten Schleifen`` und *elementweisen* Zuweisungen.
  
---

### Basisform
``Dreieck - links-unten``
```
🔷◽◽◽◽◽
🔷🔷◽◽◽◽
🔷🔷🔷◽◽◽
🔷🔷🔷🔷◽◽
🔷🔷🔷🔷🔷◽
🔷🔷🔷🔷🔷🔷
```

### Basisform um 90° gedreht
``Dreieck - links-oben``
```
🔷🔷🔷🔷🔷🔷
🔷🔷🔷🔷🔷◽
🔷🔷🔷🔷◽◽
🔷🔷🔷◽◽◽
🔷🔷◽◽◽◽
🔷◽◽◽◽◽
```

### Basisform um 180° gedreht
``Dreieck - rechts-oben``
```
🔷🔷🔷🔷🔷🔷
◽🔷🔷🔷🔷🔷
◽◽🔷🔷🔷🔷
◽◽◽🔷🔷🔷
◽◽◽◽🔷🔷
◽◽◽◽◽🔷
```

### Basisform um 270° gedreht
``Dreieck - rechts-unten``
```
◽◽◽◽◽🔷
◽◽◽◽🔷🔷
◽◽◽🔷🔷🔷
◽◽🔷🔷🔷🔷
◽🔷🔷🔷🔷🔷
🔷🔷🔷🔷🔷🔷
```
  
## Bonus Aufgaben
### Hilfsmethoden
Für [Muster der Formen](#muster-der-formen) und [Steigung der Formen](#steigung-der-formen) sind folgende ``Methoden`` hilfreich:
   * ``string[,] Transpose(string[,] field)``: hier vertausche zeilen und spalten eines 2d-Arrays.

   * ``string[,] Rotate(string[,] field)``: verwende `Transpose(MirrorX(field));` um das umzusetzten.

   * ``string[,] DrawPattern(string[,] field, int n, string fillForm, string newFillForm)``: Diese Methode zeichnet jede `nte` Zeile ein neues Symbol in die gesamte Zeile. Für spaltenweises zeichnen verwende vorher die Methode `drehen` und führe danach `DrawPattern` aus. Danach drehe es wieder zurück (also so oft, bis es wieder gleich wie am Anfang ist).

   * ``string[,] DrawTriangle(string[,] field, string symbol, double slope)``: hier erzeuge ein neues 2d-Array. Die größe ist durch die Steigung `slope` auszurechnen. Danach zeichne die linie ein welche durch $y=k*x$ gegeben ist. Fülle alles was links von dem symbol der line ist mit diesem aus.

---

## Schritt 2: 😵‍💫 - Zusammengesetzte Formen 
Unser Ziel ist es aus den oben genannten [Dreiecken](#basisform) einen
[Diamanten](#zusammengesetzte-formen) zu bauen. Verwende nun, ``string[,] CombineForm(String[,] container, String[,] part, Position position)`` um die 4 Teile des Diamanten zusammenzufügen. Erstelle dazu ein ``Enum`` (siehe Internet, AI oder fragen Sie mich) mit den *Ausprägungen* *TOP_RIGHT, TOP_LEFT, BOT_RIGHT, BOT_LEFT*.

**Die Methode `CombineForm` im Detail:**
Diese Methode dient als eine Art "Klebstoff" oder "Stempel", um ein kleines 2D-Array (*part*) an einer bestimmten Stelle in ein großes Ziel-Array (*container*) hineinzukopieren. Die Methode `string[,] CombineForm(string[,] container, string[,] part, Position position)` macht im Detail Folgendes:

* **`container`**: Das große Ziel-Array (welches doppelt so groß ist wie unsere Basisform), in das wir einfügen wollen. 
* **`part`**: Das kleinere Array (einer der vier Quadranten, z.B. ein gespiegeltes Dreieck), das eingefügt werden soll.
* **`position`**: Ein Enum (`TOP_LEFT`, `TOP_RIGHT`, `BOT_LEFT`, `BOT_RIGHT`), welches angibt, in welche Ecke der Leinwand das Teil gestempelt wird.

Das Enum kann wie ein *String* abgefragt werden der "TOP_LEFT" als ``Wert`` hat, nur einfacher. Verwende dazu folgende Logik.

```csharp
switch (position)
{
    case Position.TOP_LEFT:  ...; break;
    case Position.BOT_RIGHT: ...; break;
    case Position.BOT_LEFT:  ...; break;
    case Position.TOP_RIGHT: ...; break;
}
```

**Die Logik dahinter (Offsets/Verschiebung):**
Da ein 2D-Array intern immer bei Koordinate *[0,0]* (links-oben) beginnt, können wir das Teil *part* nicht immer einfach an die gleiche Stelle kopieren. Wenn ein Teil nach rechts-unten (*BOT_RIGHT*) soll, müssen wir seine Position "verschieben".
Dafür berechnet die Methode zwei Offsets:
* *iOffset* (Zeilen-Verschiebung): Entspricht der Höhe des kleinen Arrays (*part*).
* *jOffset* (Spalten-Verschiebung): Entspricht der Breite des kleinen Arrays.

**Das Kopieren:**
Eine verschachtelte Schleife geht nun jedes einzelne Symbol des kleinen Arrays (*part*) an den Koordinaten *[i, j]* durch. Das *switch*-Statement entscheidet anhand der *Position*, wohin genau dieses Symbol im großen *container* geschrieben wird:
* Bei *TOP_LEFT*: Keine Verschiebung. Das Symbol landet genau bei *[i, j]*.
* Bei *TOP_RIGHT*: Wird nach rechts verschoben. Die Spalte ändert sich zu *[i, j + jOffset]*.
* Bei *BOT_LEFT*: Wird nach unten verschoben. Die Zeile ändert sich zu *[i + iOffset, j]*.
* Bei *BOT_RIGHT*: Wird nach unten und rechts verschoben. Es landet bei *[i + iOffset, j + jOffset]*.

Verwende nun eine ``Methode`` *static string[,] DrawDiamond(string[,] triangle)* um dort öfter die ``Methode`` *CombineForm* aufzurufen und vorher die *vier*  dreiecke in allen Orientierungen zu generieren. 

```
◽◽◽◽◽🔷🔷◽◽◽◽◽
◽◽◽◽🔷🔷🔷🔷◽◽◽◽
◽◽◽🔷🔷🔷🔷🔷🔷◽◽◽
◽◽🔷🔷🔷🔷🔷🔷🔷🔷◽◽
◽🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷◽
🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷
🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷
◽🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷◽
◽◽🔷🔷🔷🔷🔷🔷🔷🔷◽◽
◽◽◽🔷🔷🔷🔷🔷🔷◽◽◽
◽◽◽◽🔷🔷🔷🔷◽◽◽◽
◽◽◽◽◽🔷🔷◽◽◽◽◽
```

### Schritt 3: 😵‍💫 Muster in den Formen
Es soll dem User möglich sein, ein "Muster" für die Formen angeben zu können. Das bedeutet der User soll, z.B. "jede 2. Zeile" die gezeichneten Symbole mit ``🔸`` ausgetauschen können. Es kann aber auch jede 3., 4. oder sonstige ``Zeile`` oder ``Spalte`` ausgetauscht werden sein. ``Hinweis``: Löse zuerst das Problem für die Zeilen. Danach überlege wie kannst du den Code für das Austauschen der Zeilen für die Spalten verwenden? Welche Methoden haben wir bereits geschrieben?
``` 
Jede 2. Zeile
◽◽◽◽◽🔸🔸◽◽◽◽◽
◽◽◽◽🔷🔷🔷🔷◽◽◽◽
◽◽◽🔸🔸🔸🔸🔸🔸◽◽◽
◽◽🔷🔷🔷🔷🔷🔷🔷🔷◽◽
◽🔸🔸🔸🔸🔸🔸🔸🔸🔸🔸◽
🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷
🔸🔸🔸🔸🔸🔸🔸🔸🔸🔸🔸🔸
◽🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷◽
◽◽🔸🔸🔸🔸🔸🔸🔸🔸◽◽
◽◽◽🔷🔷🔷🔷🔷🔷◽◽◽
◽◽◽◽🔸🔸🔸🔸◽◽◽◽
◽◽◽◽◽🔷🔷◽◽◽◽◽
```

``` 
Jede 4. Zeile
◽◽◽◽◽🔸🔸◽◽◽◽◽
◽◽◽◽🔷🔷🔷🔷◽◽◽◽
◽◽◽🔷🔷🔷🔷🔷🔷◽◽◽
◽◽🔷🔷🔷🔷🔷🔷🔷🔷◽◽
◽🔸🔸🔸🔸🔸🔸🔸🔸🔸🔸◽
🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷
🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷
◽🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷◽
◽◽🔸🔸🔸🔸🔸🔸🔸🔸◽◽
◽◽◽🔷🔷🔷🔷🔷🔷◽◽◽
◽◽◽◽🔷🔷🔷🔷◽◽◽◽
◽◽◽◽◽🔷🔷◽◽◽◽◽
```

``` 
Jede 3. Spalte
◽◽◽◽◽🔷🔸◽◽◽◽◽
◽◽◽◽🔷🔷🔸🔷◽◽◽◽
◽◽◽🔸🔷🔷🔸🔷🔷◽◽◽
◽◽🔷🔸🔷🔷🔸🔷🔷🔸◽◽
◽🔷🔷🔸🔷🔷🔸🔷🔷🔸🔷◽
🔸🔷🔷🔸🔷🔷🔸🔷🔷🔸🔷🔷
🔸🔷🔷🔸🔷🔷🔸🔷🔷🔸🔷🔷
◽🔷🔷🔸🔷🔷🔸🔷🔷🔸🔷◽
◽◽🔷🔸🔷🔷🔸🔷🔷🔸◽◽
◽◽◽🔸🔷🔷🔸🔷🔷◽◽◽
◽◽◽◽🔷🔷🔸🔷◽◽◽◽
◽◽◽◽◽🔷🔸◽◽◽◽◽
```

## Schritt 4 - level: 💀💀 - Steigung der Formen
Hier soll durch die Eingabe der ``Steigung`` gesteuert werden wie "spitz" das generierte Muster ist.

### Ein Beispiel
* Steigung $1$ bedeutet dass $\frac{\Delta y}{\Delta x}=k=1$. ``y`` bedeutet hier die vertikale (Zeilen) und ``x`` die horizontale (Spalten). Lösen Sie zuerst das Problem mit Steigung kleiner als $1$ und danach größer als $1$. 
* ``Achtung!`` Da die Anzahl der Zeilen (y Achse) vom User fixiert ist, müssen solange die Schritte in x gegangen werden, bis diese Anzahl an Zeilen erreicht ist!
* Wählen Sie frei ob sie, wenn die Steigung nicht genau dargestellt werden kann floor, ceiling oder round verwenden. Dies beeinflusst das generierte Muster, sie sind jedoch alle richtig. Es wird ``ceiling`` empfohlen, da hier am wenigsten auf ``Randbedingungen`` aufgepasst werden muss.

Hier ein Beispiel zur Steigung $\frac{\Delta y}{\Delta x}=k=0.67=\frac{2}{3}$ und ein möglicher Lösungsversuch:
* Stellen Sie sich auf die linke Ecke, und gehen Sie einen Schritt nach rechts. Die Koordinate $x=1$. Wir gehen hier nach rechts weiter. Wenn wir wissen wollen welches Feld in $y$ von der Linie berührt wird, wenn wir einen Schritt nach rechts gehen (\Delta x=1), sagt uns $y=k \cdot x$ eben dieses Feld. $\frac{\Delta y}{\Delta x}=k$ wissen wir durch die Eingabe des Users. Dieser sagt uns z.B. ``k=0.67``.

* ``x`` und ``y`` ist die Position eines Arrays. Also $0.67*1=0.67$. Bedeutet gerundet $x=1$ und $y=1$. 
Für $x=2$  $y=0.67*2=1.33$ und gerundet $y=1$. Wenn wir das weiter machen, haben wir

| x◽◽◽| 1◽◽◽ | 2◽◽◽ | 3◽◽◽ | 4◽◽◽ | 5◽◽◽ | 6◽◽◽ | 7◽◽◽ | 8◽◽◽ | 9◽◽◽ |
| --- | ---- | ---- | ---- | ---- | ---- | ---- | ---- | ---- | ---- |
| y◽◽◽| 0.67 | 1.33 | 2◽◽◽ | 2.67 | 3.33 | 4◽◽◽ | 4.67 | 5.33 | 6◽◽◽ |
| runden | 1◽◽◽ | 1◽◽◽ | 2◽◽◽ | 3◽◽◽ | 3◽◽◽ | 4◽◽◽ | 5◽◽◽ | 5◽◽◽ | 6◽◽◽ |

 Wir haben also in der letzten Reihe 9 Symbole und 6 Symbole als höhe, was wieder $\frac{\Delta y}{\Delta x}=k=\frac{6}{9}$ ergibt. Folgendes Muster entsteht dadurch.


```
🔷🔷◽◽◽◽◽◽◽
◽◽🔷◽◽◽◽◽◽
◽◽◽🔷🔷◽◽◽◽
◽◽◽◽◽🔷◽◽◽
◽◽◽◽◽◽🔷🔷◽
◽◽◽◽◽◽◽◽🔷
```

Verwende ein 2d-Array um diese Linie anzulegen. Danach suche das Symbol ‚🔷‘ in jeder Zeile und fülle nach rechts auf.
Verwende ein 2d-Array um diese Linie anzulegen. Danach suche das Symbol ‚🔷‘ in jeder Zeile und fülle nach rechts auf.
```
🔷🔷◽◽◽◽◽◽◽
🔷🔷🔷◽◽◽◽◽◽
🔷🔷🔷🔷🔷◽◽◽◽
🔷🔷🔷🔷🔷🔷◽◽◽
🔷🔷🔷🔷🔷🔷🔷🔷◽
🔷🔷🔷🔷🔷🔷🔷🔷🔷
```

Für kompliziertere Fomren, wie die Raute, teile das Problem in 4 kleinere Probleme (das wir und gerade angeschaut haben ist eines davon) und füge diese danach zusammen. Also
```
◽◽◽◽◽◽◽🔷🔷
◽◽◽◽◽◽🔷🔷🔷
◽◽◽◽🔷🔷🔷🔷🔷
◽◽◽🔷🔷🔷🔷🔷🔷
◽🔷🔷🔷🔷🔷🔷🔷🔷
🔷🔷🔷🔷🔷🔷🔷🔷🔷

🔷🔷🔷🔷🔷🔷🔷🔷🔷
◽🔷🔷🔷🔷🔷🔷🔷🔷
◽◽◽🔷🔷🔷🔷🔷🔷
◽◽◽◽🔷🔷🔷🔷🔷
◽◽◽◽◽◽🔷🔷🔷
◽◽◽◽◽◽◽🔷🔷

🔷🔷◽◽◽◽◽◽◽
🔷🔷🔷◽◽◽◽◽◽
🔷🔷🔷🔷🔷◽◽◽◽
🔷🔷🔷🔷🔷🔷◽◽◽
🔷🔷🔷🔷🔷🔷🔷🔷◽
🔷🔷🔷🔷🔷🔷🔷🔷🔷

🔷🔷🔷🔷🔷🔷🔷🔷🔷
🔷🔷🔷🔷🔷🔷🔷🔷◽
🔷🔷🔷🔷🔷🔷◽◽◽
🔷🔷🔷🔷🔷◽◽◽◽
🔷🔷🔷◽◽◽◽◽◽
🔷🔷◽◽◽◽◽◽◽
```

Ergibt zusammengefügt
```
◽◽◽◽◽◽◽🔷🔷🔷🔷◽◽◽◽◽◽◽
◽◽◽◽◽◽🔷🔷🔷🔷🔷🔷◽◽◽◽◽◽
◽◽◽◽🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷◽◽◽◽
◽◽◽🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷◽◽◽
◽🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷◽
🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷
🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷
◽🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷◽
◽◽◽🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷◽◽◽
◽◽◽◽🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷◽◽◽◽
◽◽◽◽◽◽🔷🔷🔷🔷🔷🔷◽◽◽◽◽◽
◽◽◽◽◽◽◽🔷🔷🔷🔷◽◽◽◽◽◽◽
```