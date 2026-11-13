# Übung: Git im Solo-Workflow mit Bubble Sort in C#

>📖 Alle Befehle dieser Übung werden im Skriptum erklärt und animiert: [Git als Linked List & Zeitspeicher](../../Skripten/L02.0Git-part-1.html)

## Ziel
Du arbeitest allein an einem kleinen C#-Projekt und versionierst es mit Git. Dabei übst du:
- Änderungen gezielt in die **Staging Area** legen (``git add``) und **committen** (``git commit``)
- Commits auf den GitLab-Server der Schule **pushen** (``git push``)
- eine fehlerhafte Änderung mit ``git reset`` aus der Staging Area nehmen und mit ``git checkout`` verwerfen

Am Ende hat dein Repository am GitLab-Server **drei Commits**, die aufeinander aufbauen.

>Alle Befehle gibst du im **Terminal** ein (in Visual Studio: *Ansicht → Terminal*). Nach jedem Schritt mit ``git`` lohnt sich ein ``git status`` – so siehst du, was passiert ist.

---

## Schritt 1: Repository anlegen und klonen
1. Erstelle auf dem **GitLab-Server der Schule** ein neues REpository - sie heißen Projekt auf gitlab, z. B. ``BubbleSort``. 
2. Füge deine Lehrperson als Mitglied hinzu, damit dein Repository eingesehen und bewertet werden kann:
   - Links im Projekt-Menü: *Manage → Members* und rechts oben *Invite members*.
   - Bei *Username, name or email* den Benutzernamen deiner Lehrperson eingeben und auswählen.
   - Bei *Select a role* die Rolle **Reporter** wählen (nur lesen, keine Änderungen), dann *Invite*.
   - Kontrolle: Deine Lehrperson steht jetzt in der Liste der *Members*.
3. Kopiere am GitLab-Server die Adresse unter *Code → Clone with HTTPS* und klone das Repository. Wechsle danach in den neuen Ordner:
   ```bash
   git clone <kopierte-Adresse>
   cd GitBubbleSortUebung
   ```
4. Erstelle im Repository-Ordner ein Konsolenprojekt und eine ``.gitignore``. GitLab bietet beim Erstellen keine passende Vorlage an, daher:
   ```bash
   dotnet new console
   dotnet new gitignore
   ```
5. Schau nach, welche Dateien Git als neu erkennt:
   ```bash
   git status
   ```
   **Frage:** Warum tauchen die Ordner ``bin`` und ``obj`` nicht auf?

---

## Schritt 2: Erster Commit – Bubble Sort implementieren
1. Erstelle die Datei ``BubbleSorter.cs`` mit der Methode ``public static int[] BubbleSort(int[] array)``. Sie sortiert das Array aufsteigend nach dem Bubble-Sort-Prinzip.

   ![Bubble Sort Ablauf](Bubble-sort-example-300px.gif)

   Benachbarte Elemente werden verglichen und vertauscht, wenn sie in falscher Reihenfolge sind. Nach jedem Durchlauf steht das größte unsortierte Element ganz rechts.

2. Lege **nur** ``BubbleSorter.cs`` in die Staging Area und kontrolliere: ``BubbleSorter.cs`` ist grün, alles andere rot.
   ```bash
   git add BubbleSorter.cs
   git status
   ```
3. Committe mit einer Nachricht im Imperativ:
   ```bash
   git commit -m "Implement Bubble Sort"
   ```

---

## Schritt 3: Zweiter Commit – Aufruf und Absicherung
1. Rufe ``BubbleSort`` in ``Program.cs`` mit einem Beispiel-Array auf und gib das Ergebnis aus.
2. Sichere die Methode ab: Ist das Array ``null``, soll eine ``ArgumentNullException`` geworfen werden.
3. Teste das Programm. Lege dann **alle** geänderten und neuen Dateien in die Staging Area und committe:
   ```bash
   git add -A
   git status
   git commit -m "Add example call and null check"
   ```
4. Pushe beide Commits auf den Server und kontrolliere die Commit-Liste lokal:
   ```bash
   git push
   git log --oneline
   ```
   Kontrolliere auch im Browser am GitLab-Server, dass dort deine **zwei** Commits sichtbar sind.

---

## Schritt 4: Fehler zurücknehmen mit Reset und Checkout
1. Baue absichtlich einen Fehler in ``BubbleSorter.cs`` ein, z. B. eine falsche Schleifengrenze, die eine ``IndexOutOfRangeException`` auslöst. Speichere die Datei.
2. Lege die Datei in die Staging Area – ``git status`` zeigt sie jetzt **grün**:
   ```bash
   git add BubbleSorter.cs
   git status
   ```
3. Du merkst: Dieser Fehler darf nicht committet werden.
   - a) Nimm die Datei aus der Staging Area. Die Änderung bleibt **in der Datei** erhalten, ``git status`` zeigt sie wieder **rot**:
     ```bash
     git reset BubbleSorter.cs
     git status
     ```
   - b) Verwirf die Änderung. Die Datei steht danach wieder auf dem Stand des **letzten Commits**:
     ```bash
     git checkout -- BubbleSorter.cs
     git status
     ```
4. ``git status`` meldet *nothing to commit, working tree clean*. Starte das Programm zur Kontrolle – der Fehler ist weg.

>⚠️ ``git checkout -- <datei>`` löscht deine ungespeicherten Änderungen unwiderruflich – sie waren nie in einem Commit.

**Frage:** Was ist der Unterschied zwischen 3a und 3b? Wo liegt deine Änderung jeweils danach (Working Directory, Staging Area oder nirgends)?

---

## Schritt 5: Dritter Commit – sinnvolle Verbesserung
1. Verbessere den Algorithmus: Wenn in einem Durchlauf **keine Vertauschung** mehr nötig war, ist das Array sortiert, und die Schleife soll abbrechen.
2. Teste mit einem bereits sortierten Array. Mit einer Zählvariable für die Durchläufe kannst du zeigen, dass jetzt weniger gerechnet wird.
3. Committe und pushe:
   ```bash
   git add BubbleSorter.cs
   git commit -m "Stop early when array is already sorted"
   git push
   git log --oneline
   ```
4. Kontrolliere am GitLab-Server: Es gibt jetzt **drei Commits**, und der fehlerhafte Code aus Schritt 4 taucht in keinem davon auf.

---

## Befehlssammlung

| Befehl | Was er macht | Schritt |
|---|---|---|
| ``git clone <adresse>`` | lädt ein Repository vom Server und legt einen Ordner dafür an | 1 |
| ``cd <ordner>`` | wechselt im Terminal in den Ordner (nötig, damit Git dein Repository findet) | 1 |
| ``dotnet new console`` | erstellt ein C#-Konsolenprojekt im aktuellen Ordner | 1 |
| ``dotnet new gitignore`` | erstellt eine ``.gitignore``, damit ``bin`` und ``obj`` nicht ins Repository kommen | 1 |
| ``git status`` | zeigt, welche Dateien geändert (rot) oder in der Staging Area (grün) sind | alle |
| ``git add <datei>`` | legt **eine** Datei in die Staging Area | 2, 4, 5 |
| ``git add -A`` | legt **alle** geänderten, neuen und gelöschten Dateien in die Staging Area | 3 |
| ``git commit -m "<nachricht>"`` | speichert den Inhalt der Staging Area als neuen Commit (Nachricht im Imperativ) | 2, 3, 5 |
| ``git push`` | überträgt deine lokalen Commits auf den GitLab-Server | 3, 5 |
| ``git log --oneline`` | zeigt alle Commits kurz, den neuesten zuerst | 3, 5 |
| ``git reset <datei>`` | nimmt eine Datei aus der Staging Area – **die Änderung bleibt in der Datei** | 4 |
| ``git checkout -- <datei>`` | setzt eine Datei auf den Stand des letzten Commits zurück – **die Änderung ist weg** | 4 |
