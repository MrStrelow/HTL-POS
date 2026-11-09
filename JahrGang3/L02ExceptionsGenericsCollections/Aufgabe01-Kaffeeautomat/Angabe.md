# Aufgabe: Kaffeeautomat Pro – Exceptions, Hat-Beziehung & Git
Programmierübung am PC · Arbeitszeit ca. 70 Minuten · Lösung im Ordner ``Loesung`` (außer den Git-Befehlen)

Welche ``Konzepte`` üben wir hier?
- **Neu aus L02:**
  - eigene Exceptions mit zusätzlichen Eigenschaften, ``throw``
  - ``ArgumentException``, ``ArgumentOutOfRangeException``, ``InvalidOperationException``
  - ``try / catch / finally``, mehrere ``catch``-Blöcke, Reihenfolge der ``catch``-Blöcke, ``catch … when (…)``
  - ``int.Parse`` gegenüber ``int.TryParse``
  - Dateien lesen mit der Klasse ``File`` (``File.Exists``, ``File.ReadAllLines``) und ``FileNotFoundException``
  - String-Methoden zum Prüfen von Eingabedaten: ``Trim``, ``Split``, ``StartsWith``, ``string.IsNullOrWhiteSpace``
  - Git: ``add``, ``commit``, ``push``, ``reset <datei>``, ``checkout -- <datei>``
- **Wiederholung aus L01:**
  - Hat-Beziehung **bidirektional auf Objektebene** (``this``) und Delegation
  - Properties mit ``private set``, ``init`` und eigenem Setter (``field``)
  - Object- und Collection-Initializer
  - Arrays und Schleifen

Welche ``Denkweise`` üben wir hier?
- **Erwartbarer Fall** → **Kontrollstruktur** oder **Rückgabewert**: z. B. eine falsche Tastatureingabe, oder zu viel Milch, die überläuft.
- **Echter Ausnahmefall**, den die Methode selbst nicht lösen kann (Tank leer, Automat aus, falscher Aufruf) → **Exception**. Der **Aufrufer** entscheidet im ``catch``, ob er das Problem beheben kann (nachfüllen, einschalten, entkalken) oder die Bestellung auslässt.

Die Klassen findest du im Ordner ``Vorlage``. Kopiere die ``.cs``-Dateien in dein neues Projekt (Teil 1) und ersetze die ``TODO``s.

---

### Teil 1 - level: 🙂 - Repository anlegen - ~5 min
1. Lege auf dem **GitLab-Server der Schule** ein neues Repository ``KaffeeautomatPro`` an (*Private*, mit ``README.md``).
   Füge deine Lehrperson unter *Manage → Members → Invite members* mit der Rolle **Reporter** hinzu.
2. Klone es, wechsle mit ``cd`` hinein und erstelle Projekt und ``.gitignore``:
   ```bash
   dotnet new console -n KaffeeautomatPro
   dotnet new gitignore
   ```
3. Kopiere ``Exceptions.cs``, ``Behaelter.cs``, ``Getraenk.cs``, ``Kaffeeautomat.cs``, ``Program.cs`` und ``bestellungen.csv`` aus der ``Vorlage`` in den Projektordner (``bestellungen.csv`` liegt neben ``Program.cs``). Das Projekt muss sich übersetzen lassen.
4. Lege im Repository einen Ordner ``Nachweise`` an. Dort kommen in Teil 7 deine Screenshots hinein.
5. Committe mit ``git commit -m "Create project from template"`` und pushe.

---

### Teil 2 - level: 🙂 - Eigene Exceptions - ~7 min
Ergänze in ``Exceptions.cs`` zwei Klassen, die von ``Exception`` erben:

| Klasse | zusätzliche Eigenschaften (nur intern setzbar) | Nachricht an die Basisklasse |
|---|---|---|
| ``ZutatLeerException`` | ``Zutat`` (string), ``Benoetigt`` (int), ``Vorhanden`` (int) | ``"{zutat} reicht nicht: benötigt {benoetigt}, vorhanden {vorhanden}."`` |
| ``EntkalkenNoetigException`` | ``Bezuege`` (int) | ``"Entkalken nötig! {bezuege} Bezüge seit dem letzten Entkalken."`` |

**Frage** (als Kommentar beantworten): Warum geben wir der ``ZutatLeerException`` eigene Eigenschaften, statt nur einen Text mitzugeben? (Tipp: Teil 5b, ``when``)

Committe: ``"Add custom exceptions"``.

---

### Teil 3 - level: 🤔 - Behaelter - ~11 min
Ein ``Behaelter`` speichert eine Zutat (Wasser, Bohnen oder Milch).

* **Eigenschaften:** ``Zutat``, ``Einheit`` (z. B. ``"ml"`` oder ``"g"``), ``Kapazitaet`` und ``Automat`` (der Kaffeeautomat, in dem der Behälter steckt), alle nur intern setzbar.
* **Inhalt:** Der Setter ist ``private`` und prüft mit dem Schlüsselwort ``field``: Liegt der neue Wert unter 0 oder über der ``Kapazitaet``, wird eine ``ArgumentOutOfRangeException`` geworfen. So kann der Behälter **nie** in einen ungültigen Zustand kommen.
* **Konstruktor:** Er speichert alle Werte. Ein neuer Behälter ist **voll**.
* **Methoden:**

| Methode | Verhalten |
|---|---|
| ``void PruefeMenge(int menge)`` | Ist zu wenig da, wird eine ``ZutatLeerException`` geworfen. Es wird **nichts** entnommen. |
| ``void Entnehmen(int menge)`` | Nutzt ``PruefeMenge`` und verringert dann den Inhalt. |
| ``int Auffuellen(int menge)`` | Ist ``menge`` nicht positiv, wird eine ``ArgumentOutOfRangeException`` geworfen. Passt alles hinein, wird aufgefüllt und ``0`` zurückgegeben. Ist zu wenig Platz, wird der Behälter **voll** gemacht und die **übergelaufene Menge** zurückgegeben. |
| ``string ToString()`` (override) | z. B. ``"Wasser 960/1000 ml"`` |

**Frage:** Warum wirft ``Auffuellen`` bei einem Überlauf **keine** Exception, bei ``menge = 0`` aber schon?

Committe: ``"Add Behaelter"``.

---

### Teil 4 - level: 🤔 - Kaffeeautomat - ~14 min
* **Eigenschaften** (alle nur intern setzbar): ``Wassertank``, ``Bohnenbehaelter``, ``Milchtank`` (je ein ``Behaelter``), ``Karte`` (``Getraenk[]``), ``IstEingeschaltet`` und ``BezuegeSeitEntkalken``.
* **Konstruktor:**
  * Er legt die Behälter an: Wasser 1000 ml, Bohnen 50 g, Milch 300 ml. **Jeder Behälter muss genau diesen Automaten kennen** (bidirektionale Hat-Beziehung auf Objektebene).
  * Er legt die ``Karte`` mit einem **Collection Initializer** an, der vier ``Getraenk``-Objekte mit **Object Initializern** enthält:

    | Name | Wasser | Bohnen | Milch |
    |---|---|---|---|
    | Espresso | 40 ml | 9 g | – |
    | Kaffee | 200 ml | 12 g | – |
    | Cappuccino | 60 ml | 9 g | 150 ml |
    | Latte | 50 ml | 9 g | 250 ml |

* **Methoden:**

| Methode | Verhalten |
|---|---|
| ``Einschalten()`` | schaltet ein, gibt ``🔌 Automat eingeschaltet.`` aus |
| ``Entkalken()`` | Ist der Automat aus, wird eine ``InvalidOperationException`` geworfen. Sonst wird der Zähler auf 0 gesetzt und ``🧽 Automat entkalkt.`` ausgegeben. |
| ``Getraenk SucheGetraenk(string name)`` | sucht in der ``Karte``, **ohne** auf Groß-/Kleinschreibung zu achten. Wird nichts gefunden, folgt eine ``ArgumentException`` mit ``"Unbekanntes Getränk: {name}"``. |
| ``Bruehe(string name)`` | siehe unten |
| ``string Status()`` | z. B. ``Wasser 960/1000 ml \| Bohnen 41/50 g \| Milch 300/300 ml \| Bezüge seit Entkalken: 1`` |

**``Bruehe``** prüft in dieser Reihenfolge:
1. Ist der Automat aus? → ``InvalidOperationException("Der Automat ist ausgeschaltet.")``
2. Gab es bereits 4 oder mehr Bezüge seit dem Entkalken? → ``EntkalkenNoetigException``
3. ``SucheGetraenk``
4. Erst **alle drei** Behälter mit ``PruefeMenge`` prüfen (Delegation!), **danach** aus allen dreien entnehmen.
5. Zähler erhöhen, ``☕ {Name} fertig.`` ausgeben.

**Frage:** Was würde schiefgehen, wenn ``Bruehe`` gleich mit ``Entnehmen`` beginnt, ohne vorher zu prüfen? Spiel es mit einer Latte durch, wenn nur 50 ml Milch da sind.

Gib in ``Program.cs`` aus, ob ``automat.Wassertank.Automat == automat`` gilt. Erwartet: ``True``.

Committe: ``"Add Kaffeeautomat"`` und pushe.

---

### Teil 5a - level: 🤔 - Bestellungen aus einer CSV-Datei - ~8 min
Die Bestellungen kommen nicht mehr aus einem fest programmierten Array, sondern aus der Datei ``bestellungen.csv``. Die Kellner:innen tippen sie von Hand – entsprechend sieht die Datei aus:

```
# Bestellungen fuer den Kaffeeautomaten
# Format: Tisch;Getraenk

1;Espresso
2; Cappuccino
3;Latte
Espresso fuer Tisch 4
4;Tee
5;
5;Kaffee
6;latte;mit Hafermilch
6;latte
7;ESPRESSO
```

Schreibe in ``Program.cs`` die Methode ``static string[] LeseBestellungen(string pfad)``. Sie liest die Datei mit der Klasse ``File`` ein und gibt nur die **Getränkenamen** der brauchbaren Zeilen zurück – ohne Leerzeichen am Rand. Prüfe jede Zeile mit String-Methoden (``Trim``, ``Split``, ``StartsWith``, ``string.IsNullOrWhiteSpace``). Rufe sie im Hauptprogramm mit ``"../../../bestellungen.csv"`` auf und gib aus, wie viele gültige Bestellungen eingelesen wurden.

**Entscheide selbst** – das ist der Kern dieser Teilaufgabe: Welche der folgenden Fälle löst du mit einem **Guard** (Kontrollstruktur, z. B. Zeile überspringen und eine Warnung ausgeben) und welche mit einer **Exception**? Wenn Exception: welche, und wo wird sie gefangen?

| Fall | Beispiel | Guard oder Exception? Warum? |
|---|---|---|
| Die Datei existiert nicht | falscher Pfad | |
| Leerzeile oder Kommentar | ``# Format: …`` | |
| Zeile hat nicht genau 2 Spalten | ``Espresso fuer Tisch 4``, ``6;latte;mit Hafermilch`` | |
| Getränkename ist leer | ``5; `` | |
| Getränk steht nicht auf der Karte | ``4;Tee`` | |

Übertrage die Tabelle als **Kommentar** über die Methode und fülle die letzte Spalte aus.
>Tipp: Frag dich jedes Mal: Ist der Fall bei einer von Hand getippten Datei **erwartbar**? Und kann ``LeseBestellungen`` ihre Aufgabe **trotzdem** erfüllen? Der letzte Fall (``Tee``) ist eine Fangfrage: Wer ist für die Getränkekarte zuständig?

Committe: ``"Read orders from csv file"``.

---

### Teil 5b - level: 💀 - Bestellungen abarbeiten - ~11 min
Arbeite das Array ``bestellungen`` aus Teil 5a in einer ``while``-Schleife mit einem eigenen ``index`` ab. Rufe für jede Bestellung ``Bruehe`` in einem ``try`` auf:

| ``catch`` | Reaktion | Bestellung danach … |
|---|---|---|
| ``InvalidOperationException`` | Meldung, ``Einschalten()`` | **nochmal** versuchen |
| ``EntkalkenNoetigException`` | Meldung, ``Entkalken()`` | **nochmal** versuchen |
| ``ZutatLeerException`` **``when``** die Zutat Milch ist | Meldung, 500 ml Milch auffüllen, Überlauf ausgeben (falls > 0) | **nochmal** versuchen |
| ``ZutatLeerException`` (alle anderen Zutaten) | Meldung | **überspringen** |
| ``ArgumentException`` | Meldung | **überspringen** |

* Im ``finally`` wird nach **jedem** Versuch ``📊`` + ``Status()`` ausgegeben.
* Merke dir in einer ``bool``-Variable, ob die Bestellung erledigt ist. Nur dann geht es mit der nächsten weiter.
* **Schutz vor Endlosschleifen:** Scheitert dieselbe Bestellung ``MaxVersuche``-mal (3), wird sie übersprungen.

**Fragen:**
1. Die erste ``ZutatLeerException`` hat einen ``when``-Filter. Was passiert, wenn der Filter ``false`` liefert?
2. ``ArgumentOutOfRangeException`` erbt von ``ArgumentException``. Warum muss ein ``catch (ArgumentOutOfRangeException)`` **vor** einem ``catch (ArgumentException)`` stehen?
3. Warum braucht es ``MaxVersuche``, obwohl es mit diesen Bestellungen nie greift?

Committe: ``"Process orders with exception handling"``.

---

### Teil 6 - level: 🤔 - Benutzereingabe - ~5 min
Schreibe ``static int LeseMenge(string prompt)``. Sie fragt so lange, bis eine ganze Zahl eingegeben wurde. Fülle danach den Bohnenbehälter mit dieser Menge auf und fange die ``ArgumentOutOfRangeException`` ab, z. B. für ``0`` oder ``-5``.
**Entscheide selbst**, ob du ``int.Parse`` mit ``try/catch`` oder ``int.TryParse`` verwendest, und **begründe** es in einem Kommentar. Beantworte dort auch: Warum prüft ``LeseMenge`` **nicht**, ob die Menge positiv ist?

Committe: ``"Read refill amount"`` und pushe. Kontrolliere am GitLab-Server: Es gibt jetzt **7 Commits**.

---

### Teil 7 - level: 🤔 - Fehler verwerfen mit Git – mit Nachweis - ~9 min
Wir bauen absichtlich Fehler ein und werfen sie mit Git wieder weg. **Diese Fehler werden NICHT committet!**
Damit nachvollziehbar ist, dass du ``checkout`` und ``reset`` wirklich gemacht hast, machst du an den markierten Stellen 📸 einen Screenshot mit dem **Snipping Tool** (``Win`` + ``Shift`` + ``S``). Auf dem Bild müssen der eingegebene Befehl **und** die Ausgabe von ``git status`` zu sehen sein. Speichere jedes Bild unter dem angegebenen Namen im Ordner ``Nachweise``.

#### 7a) Ungestagte Änderung verwerfen: ``git checkout``
1. Ändere in ``Program.cs`` den Wert von ``MaxVersuche`` von ``3`` auf ``300``.
2. ``git status`` → 📸 ``01_geaendert.png`` (``Program.cs`` ist *modified*, rot)
3. ``git checkout -- Program.cs``
4. ``git status`` → 📸 ``02_nach_checkout.png`` (*working tree clean*). Kontrolliere in der IDE, dass wieder ``3`` dasteht.

#### 7b) Gestagte Änderung zurücknehmen: ``git reset``, dann ``git checkout``
1. Lösche in ``Kaffeeautomat.cs`` in ``Bruehe`` die drei ``PruefeMenge``-Zeilen. Starte das Programm: Was passiert jetzt bei der Latte?
2. ``git add Kaffeeautomat.cs`` → ``git status`` → 📸 ``03_gestaged.png`` (grün)
3. Stopp, das darf nicht in den Commit! ``git reset Kaffeeautomat.cs`` → ``git status`` → 📸 ``04_nach_reset.png`` (wieder rot, die Änderung ist **noch in der Datei**)
4. ``git checkout -- Kaffeeautomat.cs`` → ``git status`` → 📸 ``05_nach_checkout.png`` (*clean*)

#### 7c) Nachweis abgeben
1. ``git log --oneline`` → 📸 ``06_log.png``. Es dürfen **keine** Commits mit den Fehlern aus 7a und 7b vorkommen.
2. Committe **nur** den Ordner ``Nachweise``: ``git add Nachweise`` → ``git commit -m "Add Git evidence screenshots"`` → ``git push``
3. Kontrolliere am GitLab-Server: **8 Commits**, im Ordner ``Nachweise`` liegen **6 Bilder**.

**Frage:** Wo liegt die Änderung aus 7b jeweils nach ``git add``, nach ``git reset`` und nach ``git checkout`` (Working Directory, Staging Area oder nirgends)?

>⚠️ ``git checkout -- <datei>`` löscht deine ungespeicherten Änderungen unwiderruflich – sie waren nie in einem Commit.

---

### Erwartete Ausgabe (Teil 4 bis 6)
Die Warnungen beim Einlesen sind ein Beispiel – Wortlaut und deine Entscheidungen aus Teil 5a dürfen abweichen.
```
Kennt der Wassertank genau diesen Automaten? True

⚠️ Zeile 7 übersprungen: 1 statt 2 Spalten – "Espresso fuer Tisch 4"
⚠️ Zeile 9 übersprungen: kein Getränk angegeben
⚠️ Zeile 11 übersprungen: 3 statt 2 Spalten – "6;latte;mit Hafermilch"
📋 7 gültige Bestellungen eingelesen.

▶ Bestellung 1: Espresso
   ⚠️ Der Automat ist ausgeschaltet. → einschalten
🔌 Automat eingeschaltet.
   📊 Wasser 1000/1000 ml | Bohnen 50/50 g | Milch 300/300 ml | Bezüge seit Entkalken: 0
▶ Bestellung 1: Espresso
☕ Espresso fertig.
   📊 Wasser 960/1000 ml | Bohnen 41/50 g | Milch 300/300 ml | Bezüge seit Entkalken: 1
▶ Bestellung 2: Cappuccino
☕ Cappuccino fertig.
   📊 Wasser 900/1000 ml | Bohnen 32/50 g | Milch 150/300 ml | Bezüge seit Entkalken: 2
▶ Bestellung 3: Latte
   ⚠️ Milch reicht nicht: benötigt 250, vorhanden 150. → Milch nachfüllen
   🥛 350 ml Milch sind übergelaufen.
   📊 Wasser 900/1000 ml | Bohnen 32/50 g | Milch 300/300 ml | Bezüge seit Entkalken: 2
▶ Bestellung 3: Latte
☕ Latte fertig.
   📊 Wasser 850/1000 ml | Bohnen 23/50 g | Milch 50/300 ml | Bezüge seit Entkalken: 3
▶ Bestellung 4: Tee
   ❌ Unbekanntes Getränk: Tee (Parameter 'name') → Bestellung wird übersprungen
   📊 Wasser 850/1000 ml | Bohnen 23/50 g | Milch 50/300 ml | Bezüge seit Entkalken: 3
▶ Bestellung 5: Kaffee
☕ Kaffee fertig.
   📊 Wasser 650/1000 ml | Bohnen 11/50 g | Milch 50/300 ml | Bezüge seit Entkalken: 4
▶ Bestellung 6: latte
   ⚠️ Entkalken nötig! 4 Bezüge seit dem letzten Entkalken.
🧽 Automat entkalkt.
   📊 Wasser 650/1000 ml | Bohnen 11/50 g | Milch 50/300 ml | Bezüge seit Entkalken: 0
▶ Bestellung 6: latte
   ⚠️ Milch reicht nicht: benötigt 250, vorhanden 50. → Milch nachfüllen
   🥛 250 ml Milch sind übergelaufen.
   📊 Wasser 650/1000 ml | Bohnen 11/50 g | Milch 300/300 ml | Bezüge seit Entkalken: 0
▶ Bestellung 6: latte
☕ Latte fertig.
   📊 Wasser 600/1000 ml | Bohnen 2/50 g | Milch 50/300 ml | Bezüge seit Entkalken: 1
▶ Bestellung 7: ESPRESSO
   ❌ Bohnen reicht nicht: benötigt 9, vorhanden 2. → Bestellung wird übersprungen
   📊 Wasser 600/1000 ml | Bohnen 2/50 g | Milch 50/300 ml | Bezüge seit Entkalken: 1

Wie viel Gramm Bohnen nachfüllen? viel
Keine ganze Zahl! Wie viel Gramm Bohnen nachfüllen? 30
🫘 Aufgefüllt. Übergelaufen: 0 g
📊 Wasser 600/1000 ml | Bohnen 32/50 g | Milch 50/300 ml | Bezüge seit Entkalken: 1
```
