Welche `Konzepte` der Programmiersprache üben wir hier?
* Schleifen (insbesondere verschachtelte Schleifen und deren Laufrichtungen)
* Verzweigungen (if/else zur Auswahl des richtigen Symbols)
* Operatoren
* Funktionen (Parameterübergabe)

Welche `Denkweisen` üben wir hier?
* Wie lösen wir `kleinere Teile` eines `großen Problems` und `kombinieren` diese?

Bei Unklarheiten hier nachlesen:
* [Welche Kontrollstrukturen kann ich verwenden?](../Skripten/L01.5Zusammenfassung-VariablenOperatorenKontrollstrukturen.md)

# Aus Dreiecken 📐 werden Diamanten 💠 - Part 1

## Level: 🙂 - Verschiedene Dreiecke bauen
0. Schreibe ``Zuständigkeiten`` über alle ``Kontrollstrukturen``.
1. Zeichne `Formen`, welche über ``Methoden`` in einem `Top-Level Statement` aufgerufen werden. Die *Formen* nutzen verschachtelte ``Schleifen``, um **zwei** verschiedene `Emojis` direkt in die Konsole zu schreiben und so *rechtwinklige Dreiecke* 📐 in verschiedenen *90°-Orientierungen* darzustellen. 
    ```text
    🔷◽◽◽◽◽
    🔷🔷◽◽◽◽
    🔷🔷🔷◽◽◽
    🔷🔷🔷🔷◽◽
    🔷🔷🔷🔷🔷◽
    🔷🔷🔷🔷🔷🔷
    ```
    Verwende dazu folgende `Methoden`. Da wir keine Arrays zum Zwischenspeichern nutzen, erzeugen wir die unterschiedlichen Ausrichtungen, indem wir die **Laufrichtung der Schleifen (Zähler vorwärts oder rückwärts)** anpassen:
      * `static void DrawTriangle(int size, string symbol, string background)`: Zeichnet die Basisform direkt in die Konsole.
      * `static void DrawMirrorX(int size, string symbol, string background)`: Zeichnet die Form um die x-Achse gespiegelt.
      * `static void DrawMirrorY(int size, string symbol, string background)`: Zeichnet die Form um die y-Achse gespiegelt.
      * `static void DrawMirrorXY(int size, string symbol, string background)`: Zeichnet die Form um beide Achsen gespiegelt.

---

### Basisform
`Dreieck - links-unten`

**Methode:** `DrawTriangle` (Normale Schleifenrichtung)
```text
🔷◽◽◽◽◽
🔷🔷◽◽◽◽
🔷🔷🔷◽◽◽
🔷🔷🔷🔷◽◽
🔷🔷🔷🔷🔷◽
🔷🔷🔷🔷🔷🔷
```

### Basisform um 90° gedreht (gespiegelt an X-Achse)
`Dreieck - links-oben`

**Methode:** `DrawMirrorX` (Äußere Zeilen-Schleife läuft rückwärts, innere Spalten-Schleife vorwärts)
```text
🔷🔷🔷🔷🔷🔷
🔷🔷🔷🔷🔷◽
🔷🔷🔷🔷◽◽
🔷🔷🔷◽◽◽
🔷🔷◽◽◽◽
🔷◽◽◽◽◽
```

### Basisform um 180° gedreht (gespiegelt an X- und Y-Achse)
`Dreieck - rechts-oben`

**Methode:** `DrawMirrorXY` (Beide Schleifen laufen rückwärts)
```text
🔷🔷🔷🔷🔷🔷
◽🔷🔷🔷🔷🔷
◽◽🔷🔷🔷🔷
◽◽◽🔷🔷🔷
◽◽◽◽🔷🔷
◽◽◽◽◽🔷
```

### Basisform um 270° gedreht (gespiegelt an Y-Achse)
`Dreieck - rechts-unten`

**Methode:** `DrawMirrorY` (Äußere Zeilen-Schleife läuft vorwärts, innere Spalten-Schleife rückwärts)
```text
◽◽◽◽◽🔷
◽◽◽◽🔷🔷
◽◽◽🔷🔷🔷
◽◽🔷🔷🔷🔷
◽🔷🔷🔷🔷🔷
🔷🔷🔷🔷🔷🔷
```

---

## Level: 😵‍💫 Bonusaufgabe 💠

2. **Diamant zeichnen:** 
      * `static void DrawDiamond(int size, string symbol, string background)`: Setzt die 4 Dreiecke zu einem großen Diamanten zusammen. Uns fehlen noch ``Datenstrukturen`` die uns erlauben hier wirklich die Lösung der gezeichneten Dreiecken wiederzuverwenden. Deshalb müssen wir *fast* von vorne beginnen. Die obere Hälfte besteht aus einem an der Y-Achse gespiegelten Dreieck und der Basisform. Versuche in ``geschachtelten Schleifen`` das folgende Muster umzusetzen.

### Bonus: Diamant zusammengesetzt
**Methode:** `DrawDiamond` (Ausgabe in Zeilen verknüpft, `size = 6`)
```text
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