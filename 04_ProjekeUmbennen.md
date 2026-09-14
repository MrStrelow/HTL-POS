## Visual Studio 2026 - Projektmappen und Projekte richtig umbenennen

#### Welche Begriffe werden hier verwendet?
[``Solution Explorer``](05_Glossar.md#solution-explorer), [``Projekt``](05_Glossar.md#projekt), [``Projektmappe``](05_Glossar.md#projektmappe), [``Solution``](05_Glossar.md#solution), [``csproj``](05_Glossar.md#csproj), [``sln``](05_Glossar.md#sln).

Das reine Umbenennen im Editor ändert den eigentlichen Ordnernamen auf der Festplatte nicht, was besonders bei späteren Abgaben schnell zu Fehlern und unordentlichen Strukturen führt. Hier ist der saubere Weg, um Projekte vollständig umzubenennen:

### Schritt 1: Projekt im Solution Explorer umbenennen
Klicke im ``Solution Explorer`` mit der rechten Maustaste auf das ``Projekt``, das du umbenennen möchtest, und wähle **Rename** *(Umbenennen)* (oder markiere es und drücke die Taste *F2*). Vergib den neuen Namen und drücke Enter.

---
### Schritt 2: Projekt aus der Mappe entfernen
Mache erneut einen Rechtsklick auf das gerade umbenannte ``Projekt`` und wähle diesmal **Remove** *(Entfernen)* (oder markiere es und drücke die Taste *ENTF*).

>**Anmerkung:** Das Projekt wird dadurch nicht von der Festplatte gelöscht. Die ``Projektmappe`` vergisst lediglich, dass dieses existiert.


---
### Schritt 3: Ordner im Windows-Explorer umbenennen
Wechsle in den **Datei-Explorer** von Windows und navigiere zu dem Ordner, in dem deine ``Projektmappe`` liegt. Der Ordner des ``Projekts`` hat noch den **alten** Namen. Benenne nun diesen Projektordner so um, dass er deinem in Schritt 1 gewählten Namen entspricht.

---
### Schritt 4: Projekt wieder hinzufügen
Wechsle zurück zu **Visual Studio**. Mache im ``Solution Explorer`` einen Rechtsklick auf deine ``Projektmappe`` (den obersten Eintrag), wähle **Add** *(Hinzufügen)* und klicke auf **Existing Project...** *(Vorhandenes Projekt...)*.

---
### Schritt 5: Die .csproj Datei auswählen
Navigiere in dem sich öffnenden Dateifenster in den gerade umbenannten Projektordner. Wähle die Projektdatei aus (sie trägt nun deinen neuen Namen und endet auf ``.csproj``) und klicke auf **Open** *(Öffnen)*. Das Projekt ist nun mit dem korrekten Ordnernamen wieder sauber in die Solution integriert.

---
### Schritt 6: Projektmappe (Solution) umbenennen
Um die übergeordnete ``Projektmappe`` selbst umzubenennen, reicht es, im ``Solution Explorer`` auf den obersten Eintrag zu klicken, ``F2`` zu drücken und den neuen Namen einzugeben.

>**Anmerkung:** Wenn du auch den Hauptordner der gesamten ``Projektmappe`` auf der Festplatte umbenennen möchtest, musst du Visual Studio komplett schließen, den Stammordner im Windows-Explorer umbenennen und die ``.sln``-Datei danach per Doppelklick neu öffnen.