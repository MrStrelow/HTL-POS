# Übung: Git im Solo-Workflow mit Bubble Sort in C#

## Ziel
Du arbeitest allein an einem kleinen C#-Projekt und versionierst es mit Git. Dabei übst du:
- Änderungen gezielt in die **Staging Area** legen und **committen**
- Commits auf GitHub **pushen**
- eine fehlerhafte Änderung mit **Reset** aus der Staging Area nehmen und mit **Checkout** verwerfen

Am Ende hat dein Repository auf GitHub **drei Commits**, die aufeinander aufbauen.

---

## Schritt 1: Repository anlegen und klonen
1. Erstelle auf **GitHub** ein neues Repository, z. B. `GitBubbleSortUebung`. Füge dabei eine `README.md` und eine `.gitignore`-Vorlage für **VisualStudio** hinzu.
2. Klone das Repository auf deinen Computer.
3. Prüfe mit dem Status-Befehl, welche Dateien Git als neu erkennt. Warum tauchen die Ordner `bin` und `obj` nicht auf?

---

## Schritt 2: Erster Commit – Bubble Sort implementieren
1. Erstelle die Datei `BubbleSorter.cs` mit der Methode `public static int[] BubbleSort(int[] array)`. Sie sortiert das Array aufsteigend nach dem Bubble-Sort-Prinzip.
2. Lege **nur** `BubbleSorter.cs` in die Staging Area und kontrolliere das mit dem Status-Befehl.
3. Committe mit einer Nachricht im Imperativ, z. B. *„Implement Bubble Sort“*.

---

## Schritt 3: Zweiter Commit – Aufruf und Absicherung
1. Rufe `BubbleSort` in `Program.cs` mit einem Beispiel-Array auf und gib das Ergebnis aus.
2. Sichere die Methode ab: Ist das Array `null`, soll eine `ArgumentNullException` geworfen werden.
3. Teste das Programm, lege beide Dateien in die Staging Area und committe, z. B. *„Add example call and null check“*.
4. Pushe beide Commits auf GitHub. Kontrolliere im Browser, dass dort **zwei** Commits sichtbar sind.

---

## Schritt 4: Fehler zurücknehmen mit Reset und Checkout
1. Baue absichtlich einen Fehler in `BubbleSorter.cs` ein, z. B. eine falsche Schleifengrenze, die eine `IndexOutOfRangeException` auslöst.
2. Lege die Datei in die Staging Area.
3. Du merkst: Dieser Fehler darf nicht committet werden.
   - Nimm die Datei mit **Reset** wieder aus der Staging Area. Die Änderung bleibt in der Datei erhalten.
   - Verwirf die Änderung mit **Checkout**. Die Datei steht dann wieder auf dem Stand des **letzten Commits**.
4. Prüfe mit dem Status-Befehl, dass nichts mehr geändert ist, und starte das Programm zur Kontrolle.

**Frage:** Was ist der Unterschied zwischen Schritt 3a und 3b? Wo liegt deine Änderung jeweils danach?

---

## Schritt 5: Dritter Commit – sinnvolle Verbesserung
1. Verbessere den Algorithmus: Wenn in einem Durchlauf **keine Vertauschung** mehr nötig war, ist das Array sortiert, und die Schleife soll abbrechen.
2. Teste mit einem bereits sortierten Array. Mit einer Zählvariable für die Durchläufe kannst du zeigen, dass jetzt weniger gerechnet wird.
3. Committe, z. B. *„Stop early when array is already sorted“*, und pushe.
4. Kontrolliere auf GitHub: Es gibt jetzt **drei Commits**, und der fehlerhafte Code aus Schritt 4 taucht in keinem davon auf.
---

## Hilfreiche Befehle
`git clone`, `git status`, `git add`, `git commit -m`, `git push`, `git log --oneline`, `git reset <datei>`, `git checkout -- <datei>`
