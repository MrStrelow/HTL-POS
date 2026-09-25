## Hamster
Öffne das im Zip-File angegebene ``Projekt`` (oder arbeite bei deinem eigenen weiter) in einer ``Solution`` (deine Mitschrift).
1. Behebe alle TODOs in den angegebenen Klassen.
2. Erstelle das Klassendiagramm (ClassDiagramm.cd) nachdem du im Visual studio Installer die entsprechende extension installiert hast (siehe google/AI).

### Empfohlene Reihenfolge der Implementierung

1. **Initialisierung im Konstruktor der `Plane` (Der Anfangszustand)**
   *   **Seedlings platzieren:** Beginne im Konstruktor der `Plane`. Erstelle in einer Schleife die `Seedlings` und übergib die `Plane` (`this`) an deren Konstruktor. Der `Seedling` wählt eine zufällige Position und fragt die `Plane` über `AssignInitialPosition`, ob das Feld frei ist. Die `Plane` prüft im Dictionary `_seedlings`, ob die Koordinate vergeben ist. Ist sie frei, speichert sie die Position.
   *   **Hamster platzieren:** Gehe analog für die Hamster vor. Erstelle sie im `Plane`-Konstruktor und übergebe die `Plane`. In `Hamster.PositionAndManageHamster` zieht der Hamster Koordinaten und fragt via `AssignInitialPosition` an. 
   *   **Achtung - Überschneidung:** Was passiert, wenn ein Hamster auf dem gleichen Feld spawnen will wie ein Seedling? Passe die ``Bedingung`` in `AssignInitialPosition` an. 
   *   **Erster Testlauf:** Der Konstruktor der `Plane` ist nun abgeschlossen und der Initialzustand hergestellt. Kommentiere alle noch nicht implementierten Methodenaufrufe (wie `SimulateHamster`) in deiner `Main`-Methode aus. Führe das Programm aus und überprüfe durch den Aufruf von `Print`, ob die Wiese mit Hamstern und Seedlings korrekt gezeichnet wird.

    **Bisher implementierte Methoden:**
    *   `Plane`: Konstruktor, `AssignInitialPosition` (beide Überladungen), `TileTakenByHamster`
    *   `Seedling`: Konstruktor
    *   `Hamster`: Konstruktor, `PositionAndManageHamster`

---

2. **Simulation und Bewegung**
   *   **Die Endlosschleife (Main):** Erstelle in der `Main` eine `while (true)`-Schleife. Darin rufst du fortlaufend `SimulateHamster()` und `Print()` der `Plane` auf.
   *   **Hamster bewegen (`SimulateHamster` & `Move`):** In `Plane.SimulateHamster` iterierst du durch alle Hamster und rufst deren `Move`-Methode auf. In `Move` zieht der Hamster eine zufällige Richtung (`Direction`) und fragt die Plane über `Position(this, direction)`, ob und wie er sich dorthin bewegen kann. Die `Plane` berechnet die Zielkoordinate (unter Beachtung der Spielfeldränder) und gibt sie zurück. Der Hamster speichert diese neue Position.
   *   **Das Spielfeld aktualisieren (`Print` & `AssignRepresentationsToPlane`):** Weil sich die Hamster nun bewegen, müssen wir das Spielfeld in jedem Frame neu zeichnen, sonst hinterlassen sie visuelle "Spuren". 
       *   Erstelle `AssignRepresentationsToPlane()`. Diese Methode überschreibt zuerst das gesamte 2D-Array (`_plane`) mit dem Erdsymbol. Danach legt sie die Hamster und Seedlings anhand ihrer aktuellen `Position` wieder ins Array.
       *   Passe `Print()` an: Rufe zuerst `AssignRepresentationsToPlane()` auf, setze den Cursor auf `(0,0)`, zeichne das Array und nutze `Thread.Sleep(500)` (oder eine andere Zeit), um die Ausgabe zu verlangsamen.