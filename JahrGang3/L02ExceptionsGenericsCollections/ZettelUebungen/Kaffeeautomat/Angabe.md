# Übung: Kaffeeautomat – Exceptions vs. Kontrollstrukturen & Git
Programmierübung am PC · Arbeitszeit ca. 25 Minuten · Lösung im separaten Projekt

Welche ``Konzepte`` üben wir hier?
- ``throw``, ``try / catch / finally``, mehrere ``catch``-Blöcke
- eigene Exception, ``ArgumentOutOfRangeException``
- ``int.Parse`` und ``int.TryParse``
- Git: ``git add``, ``git commit -m``, ``git push``, ``git reset <datei>``, ``git checkout -- <datei>``

Welche ``Denkweise`` üben wir hier?
- **Erwartbarer Fall** → **Kontrollstruktur** (``if``, ``while``, ...)
- **Echter Ausnahmefall**, den die Methode selbst nicht lösen kann (Tank leer, falscher Aufruf) → **Exception** (``throw``), die der Aufrufer mit ``try/catch`` behandelt

---

### Teil 1 - Warmup (gemeinsam) - ~5 min
1. Lege auf dem **GitLab-Server der Schule** ein neues Repository ``Kaffeeautomat`` an (mit ``README.md``).
   Füge deine Lehrperson unter *Manage → Members → Invite members* mit der Rolle **Reporter** hinzu.
2. Klone es und wechsle mit ``cd`` in den Ordner.
3. Erstelle ein Konsolenprojekt und eine ``.gitignore``:
   ```bash
   dotnet new console -n Kaffeeautomat
   dotnet new gitignore
   ```
4. Prüfe mit ``git status``, was Git sieht. Warum tauchen ``bin`` und ``obj`` nicht auf?
5. Erster Commit und Push:
   ```bash
   git add -A
   git commit -m "Create console project"
   git push
   ```

>Hinweis: In den Folien steht „GitHub“ – wir verwenden den GitLab-Server der Schule. Die Befehle sind identisch.

---

### Teil 2 - level: 🙂 - Eigene Exception & throw - ~6 min
Erstelle die Datei ``WassertankLeerException.cs`` mit einer eigenen Exception, die von ``Exception`` erbt und eine Nachricht an die Basisklasse weiterreicht.

Erstelle dann die Klasse ``Kaffeeautomat``:

```csharp
public class Kaffeeautomat
{
    public int WasserMl { get; private set; } = 500;

    // Bereitet eine Tasse mit 'ml' Milliliter zu.
    public void BrueheKaffee(int ml)
    {
        // TODO 1: ml nicht zwischen 50 und 300?  -> ArgumentOutOfRangeException
        // TODO 2: zu wenig Wasser im Tank?       -> WassertankLeerException
        // TODO 3: sonst WasserMl verringern und "Kaffee mit ... ml fertig." ausgeben
    }

    public void Spuelen()
    {
        Console.WriteLine("Maschine wird gespült.");
    }
}
```

Committe mit ``git commit -m "Add Kaffeeautomat with exceptions"``.

---

### Teil 3 - level: 🤔 - Benutzereingabe einlesen - ~4 min
Schreibe in ``Program.cs`` eine Methode ``static int LeseBechergroesse()``. Sie fragt so lange nach der Bechergröße, bis eine gültige Zahl eingegeben wurde.

Für das Umwandeln des Textes in eine Zahl hast du mehrere Möglichkeiten (z.B. ``int.Parse`` oder ``int.TryParse``, mit oder ohne ``try/catch``). **Entscheide selbst**, welche du verwendest.

Begründe deine Entscheidung in einem **Kommentar** direkt über deinem Code:
- Ist eine falsche Benutzereingabe ein erwartbarer Fall oder ein Ausnahmefall?
- Warum passt dein gewähltes Werkzeug (Kontrollstruktur oder ``try/catch``) dazu?

**Frage** (ebenfalls als Kommentar beantworten): Warum prüft ``LeseBechergroesse`` *nicht* den Bereich 50–300? Wer ist dafür zuständig?

---

### Teil 4 - level: 🤔 - try / catch / finally - ~4 min
Lies im Hauptprogramm in einer Schleife **4-mal** eine Bechergröße ein und rufe ``BrueheKaffee`` auf.
- Fange ``ArgumentOutOfRangeException`` → „Ungültige Bechergröße“ ausgeben, weitermachen.
- Fange ``WassertankLeerException`` → Nachricht ausgeben und die Schleife mit ``break`` beenden.
- Im ``finally`` wird nach jedem Versuch ``Spuelen()`` aufgerufen.

**Frage:** Warum darf ``catch (Exception)`` – wenn überhaupt – nur *als letzter* catch-Block stehen?

Beispiel-Konsolenausgabe:
```
Bechergröße in ml: abc
Keine Zahl! Bechergröße in ml: 200
Kaffee mit 200 ml fertig. Restwasser: 300 ml
Maschine wird gespült.
Bechergröße in ml: 1000
Ungültige Bechergröße: 1000 ml (erlaubt 50-300)
Maschine wird gespült.
Bechergröße in ml: 250
Kaffee mit 250 ml fertig. Restwasser: 50 ml
Maschine wird gespült.
Bechergröße in ml: 100
Wassertank leer! Benötigt 100 ml, vorhanden 50 ml.
Maschine wird gespült.
```

Committe (``"Read cup size and handle exceptions"``) und **pushe**. Kontrolliere am GitLab-Server: Es gibt jetzt **3 Commits**.

---

### Teil 5 - level: 🤔 - Änderungen verwerfen (Git) - ~6 min
Wir bauen absichtlich Fehler ein – und werfen sie mit Git wieder weg. **Diese Änderungen werden NICHT committet!**

#### 5a) Ungestagte Änderung verwerfen: ``git checkout``
1. Ändere in ``Program.cs`` die Schleife von 4 auf 400 Durchläufe:
   ```diff
   - for (int i = 0; i < 4; i++)
   + for (int i = 0; i < 400; i++)
   ```
2. ``git status`` → ``Program.cs`` ist **modified** (rot, nicht gestaged).
3. Verwerfen: ``git checkout -- Program.cs``
4. Kontrolliere in der IDE: Die Schleife steht wieder auf ``4``. ``git status`` → sauber.

#### 5b) Gestagte Änderung zurücknehmen: ``git reset``, dann ``git checkout``
1. Lösche in ``Kaffeeautomat.cs`` die komplette Tank-Prüfung (das ``if`` mit ``throw new WassertankLeerException(...)``). Der Tank kann jetzt negativ werden!
2. Stage die Datei: ``git add Kaffeeautomat.cs`` → ``git status`` zeigt sie grün.
3. Stopp, das darf nicht in den Commit! Aus der Staging Area nehmen: ``git reset Kaffeeautomat.cs``
4. ``git status`` → Datei ist wieder rot. Die Änderung ist **noch in der Datei** – ``reset`` hat nur das Staging aufgehoben.
5. Jetzt endgültig verwerfen: ``git checkout -- Kaffeeautomat.cs``
6. Kontrolliere: Die Tank-Prüfung ist zurück, ``git status`` ist sauber, das Programm verhält sich wie in Teil 4.

>⚠️ ``git checkout -- <datei>`` löscht deine ungespeicherten Änderungen unwiderruflich – sie waren nie in einem Commit.

**Frage:** Wo liegt die Änderung nach ``git add``, nach ``git reset`` und nach ``git checkout``?

Abschluss: ``git log --oneline`` zeigt weiterhin genau 3 Commits – keiner enthält die Fehler aus Teil 5.
