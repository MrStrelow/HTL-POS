# Übung: Git im Solo-Workflow mit Bubble Sort in C#

## Ziel
Du arbeitest allein an einem kleinen C#-Projekt und versionierst es mit Git. Dabei übst du:
- Änderungen gezielt in die **Staging Area** legen und **committen**
- Commits auf den GitLab-Server der Schule **pushen**
- eine fehlerhafte Änderung mit **Reset** aus der Staging Area nehmen und mit **Checkout** verwerfen

Am Ende hat dein Repository am GitLab-Server **drei Commits**, die aufeinander aufbauen.

---

## Schritt 1: Repository anlegen und klonen
1. Erstelle auf dem **GitLab-Server der Schule** ein neues Projekt (*New project → Create blank project*), z. B. `GitBubbleSortUebung`. Sichtbarkeit: **Private**. Hake *Initialize repository with a README* an.
2. Füge deine Lehrperson als Mitglied hinzu, damit dein Repository eingesehen und bewertet werden kann:
   - Links im Projekt-Menü: *Manage → Members* und rechts oben *Invite members*.
   - Bei *Username, name or email* den Benutzernamen deiner Lehrperson eingeben und auswählen.
   - Bei *Select a role* die Rolle **Reporter** wählen (nur lesen, keine Änderungen), dann *Invite*.
   - Kontrolle: Deine Lehrperson steht jetzt in der Liste der *Members*.
3. Klone das Repository auf deinen Computer (Button *Code → Clone with HTTPS*).
4. Lege im Repository-Ordner eine `.gitignore` für **VisualStudio** an. GitLab bietet beim Erstellen keine passende Vorlage an, daher: `dotnet new gitignore`.
5. Prüfe mit dem Status-Befehl, welche Dateien Git als neu erkennt. Warum tauchen die Ordner `bin` und `obj` nicht auf?

---

## Schritt 2: Erster Commit – Bubble Sort implementieren
1. Erstelle die Datei `BubbleSorter.cs` mit der Methode `public static int[] BubbleSort(int[] array)`. Sie sortiert das Array aufsteigend nach dem Bubble-Sort-Prinzip.

   ![Bubble Sort Ablauf](Bubble-sort-example-300px.gif)

   Benachbarte Elemente werden verglichen und vertauscht, wenn sie in falscher Reihenfolge sind. Nach jedem Durchlauf steht das größte unsortierte Element ganz rechts.

2. Lege **nur** `BubbleSorter.cs` in die Staging Area und kontrolliere das mit dem Status-Befehl.
3. Committe mit einer Nachricht im Imperativ, z. B. *„Implement Bubble Sort“*.

---

## Schritt 3: Zweiter Commit – Aufruf und Absicherung
1. Rufe `BubbleSort` in `Program.cs` mit einem Beispiel-Array auf und gib das Ergebnis aus.
2. Sichere die Methode ab: Ist das Array `null`, soll eine `ArgumentNullException` geworfen werden.
3. Teste das Programm, lege beide Dateien in die Staging Area und committe, z. B. *„Add example call and null check“*.
4. Pushe beide Commits auf GitLab. Kontrolliere im Browser, dass dort **zwei** Commits sichtbar sind.

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
4. Kontrolliere auf GitLab: Es gibt jetzt **drei Commits**, und der fehlerhafte Code aus Schritt 4 taucht in keinem davon auf.
---

## Hilfreiche Befehle
`git clone`, `git status`, `git add`, `git commit -m`, `git push`, `git log --oneline`, `git reset <datei>`, `git checkout -- <datei>`
