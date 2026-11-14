#### Wir merken uns von [Git als Linked List & Zeitspeicher](L02.0Git-part-1.html):

| Befehl | Was passiert | Wo liegt die Änderung danach? |
|---|---|---|
| ``git clone <adresse>`` | holt das [``Remote Repository``](../../../05_Glossar.md#remote-repository) auf den Rechner | lokales [``Repository``](../../../05_Glossar.md#repository) |
| ``git status`` | zeigt, was geändert (rot) und was gestaged (grün) ist | – |
| ``git add Datei.cs`` / ``git add -A`` | legt eine / alle Dateien auf den Packtisch | [``Staging Area``](../../../05_Glossar.md#staging-area) |
| ``git commit -m "Add ..."`` | macht aus dem Packtisch einen neuen Knoten | lokales [``Repository``](../../../05_Glossar.md#repository) |
| ``git log --oneline`` | zeigt die [``Commits``](../../../05_Glossar.md#commit), neuester zuerst | – |
| ``git push`` | überträgt fehlende [``Commits``](../../../05_Glossar.md#commit) zum Server | [``Remote Repository``](../../../05_Glossar.md#remote-repository) |
| ``git reset Datei.cs`` | nimmt die Datei vom Packtisch, Änderung **bleibt** | [``Working Directory``](../../../05_Glossar.md#working-directory) |
| ``git checkout -- Datei.cs`` | setzt die Datei auf den letzten [``Commit``](../../../05_Glossar.md#commit) zurück, Änderung ist **weg** | nirgends ⚠️ |

>1. [``Git``](../../../05_Glossar.md#git) speichert die Geschichte als Kette von [``Commits``](../../../05_Glossar.md#commit). Jeder [``Commit``](../../../05_Glossar.md#commit) kennt seinen Vorgänger – wie eine *Linked List*. [``HEAD``](../../../05_Glossar.md#head) zeigt auf den [``Commit``](../../../05_Glossar.md#commit), auf dem wir gerade arbeiten.
>2. Eine Änderung wandert vom [``Working Directory``](../../../05_Glossar.md#working-directory) über die [``Staging Area``](../../../05_Glossar.md#staging-area) ins [``Repository``](../../../05_Glossar.md#repository) und mit ``git push`` ins [``Remote Repository``](../../../05_Glossar.md#remote-repository) (``origin``).
>3. Ein neues [``Repository``](../../../05_Glossar.md#repository) legen wir am GitLab-Server der Schule auf **unserer eigenen Seite** an. Unter *Manage → Members* fügen wir die Lehrperson mit der Rolle **Reporter** (nur lesen) hinzu.
>4. Nach ``git clone`` wechseln wir mit ``cd`` in den Ordner und erstellen dort das Projekt mit ``dotnet new console`` und die [``.gitignore``](../../../05_Glossar.md#gitignore) mit ``dotnet new gitignore``. So kommen ``bin`` und ``obj`` nicht ins [``Repository``](../../../05_Glossar.md#repository).
>5. Ein [``Commit``](../../../05_Glossar.md#commit) enthält **eine** sinnvolle Änderung, die sich übersetzen lässt. Die Nachricht beginnt mit einem Verb im Imperativ.
>6. Kaputter Code kommt nie in einen [``Commit``](../../../05_Glossar.md#commit): erst ``git reset``, dann ``git checkout --``.

#### Wir merken uns von [Exceptions vs. Kontrollstrukturen](L02.1Exceptions.html):
>1. Eine [``Exception``](../../../05_Glossar.md#exception) beschreibt einen **echten Ausnahmefall**: Die [``Methode``](../../../05_Glossar.md#methode) kann ihre Aufgabe nicht erfüllen und das Problem nicht selbst lösen. Ein **erwartbarer Fall** (Tippfehler, Spielfeldrand) wird mit einer [``Kontrollstruktur``](../../../05_Glossar.md#kontrollstruktur) oder einem [``Rückgabewert``](../../../05_Glossar.md#rückgabewert) gelöst.
>2. ``throw`` wirft eine [``Exception``](../../../05_Glossar.md#exception). Die [``Methode``](../../../05_Glossar.md#methode) bricht sofort ab, die [``Exception``](../../../05_Glossar.md#exception) wandert zum Aufrufer. Der **Aufrufer** entscheidet, ob er das Problem beheben kann.
>3. [``try-catch-finally``](../../../05_Glossar.md#try-catch-finally): ``try`` umschließt den Code, ``catch`` fängt eine passende [``Exception``](../../../05_Glossar.md#exception), ``finally`` läuft **immer** (Ressourcen freigeben).
>4. Wir werfen die **passendste** [``Exception``](../../../05_Glossar.md#exception): ``ArgumentNullException``, ``ArgumentOutOfRangeException``, ``ArgumentException``, ``InvalidOperationException`` (falscher [``Zustand``](../../../05_Glossar.md#zustand)), ``FileNotFoundException``.
>5. Der **erste passende** ``catch`` gewinnt. Darum steht die speziellste [``Klasse``](../../../05_Glossar.md#klasse) oben, ``catch (Exception)`` höchstens ganz unten.
>6. Ein [``Exception Filter``](../../../05_Glossar.md#exception-filter) (``catch … when (…)``) fängt nur, wenn die Bedingung ``true`` ist.
>7. Eine eigene [``Exception``](../../../05_Glossar.md#exception) erbt von ``Exception``, endet auf ``…Exception`` und gibt den Text mit ``: base(nachricht)`` weiter. Zusätzliche [``Eigenschaften``](../../../05_Glossar.md#eigenschaft) erlauben dem Aufrufer, gezielt zu reagieren.
>8. ``ex.Message`` ist der Text für Benutzer:innen, ``ex.ToString()`` mit [``StackTrace``](../../../05_Glossar.md#stacktrace) gehört ins Log. Weiterreichen mit ``throw;``, nicht ``throw ex;``.
>9. Anti-Patterns: ``throw new Exception(...)`` und ein leerer ``catch (Exception) { }``.
>10. Gibt es eine ``Try…``-[``Methode``](../../../05_Glossar.md#methode) (``int.TryParse``), verwenden wir sie statt ``Parse`` mit ``try-catch``.
>11. Erst **alles prüfen**, dann den [``Zustand``](../../../05_Glossar.md#zustand) ändern – sonst bleibt das [``Objekt``](../../../05_Glossar.md#objekt) nach einer [``Exception``](../../../05_Glossar.md#exception) halb verändert zurück.
