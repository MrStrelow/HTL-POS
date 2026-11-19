Welche ``Konzepte`` der Programmiersprache üben wir hier?
* ``2D-Arrays`` (``string[,]``): anlegen, lesen, schreiben, ``GetLength(0)`` und ``GetLength(1)``
* ``verschachtelte for-Schleifen`` über alle Felder einer Karte
* ``Zufallszahlen`` mit ``Random``: ``Next(min, max)`` und ``NextDouble()``
* ``while-Schleife``, wenn wir nicht wissen, wie oft wiederholt werden muss
* ``Guard-Clauses``: nicht über den Rand des Arrays hinauslesen

Welche ``Denkweisen`` üben wir hier?
* Wie übersetze ich „links-oben“, „rechts-unten“ oder „Mitte“ in Grenzen für Zufallszahlen?
* Wie erkenne ich eine *Endlosschleife*, bevor sie passiert?

Verwende als Vorlage die [Program.cs](Program.cs). Sie ist das Ergebnis aus dem gemeinsamen Programmieren (LiveCoding) und liest die Karte [weltkarte.txt](weltkarte.txt) ein.
Eine Lösung findest du in [Loesung.cs](Loesung.cs) – schau sie dir nur an, wenn du gar nicht weiterkommst.

| Symbol | Bedeutung |
|---|---|
| 🟦 | Wasser |
| 🟫 | Erde |
| 🗻 | Stein |
| 🌳 | Baum |
| 🌲 | Mangrove (neu) |
| 🟨 | Sand (neu) |
| 🌴 | Palme (neu) |

>Die Pfade sind relativ zur ``.exe`` in ``bin/Debug/net10.0``. Deshalb beginnen sie mit ``../../../``. Deine fertige Karte findest du danach in ``weltkarte_mit_baeumen.txt`` neben der ``Program.cs``.

---

### 🙂 Aufgabe 1: Mangroven im Wasser 🌲
Aktuell können Bäume nur auf Erde (100% Chance) oder Stein (10% Chance) wachsen. Die Anzahl der gepflanzten Bäume wird durch ``limitAnBaeumen`` begrenzt.

Erweitere die ``while``-Schleife in der ``Funktion`` *PflanzeBaeume*. Wenn das zufällig ausgewählte Feld Wasser (``🟦``) ist, soll dort mit einer **Chance von 5%** eine Mangrove (``🌲``) entstehen.

---

### 🙂 Aufgabe 2: Endlosschleifen
Ändere im Hauptprogramm den Wert bei ``double prozentWaldAufKarte = 0.25;`` auf ``0.85`` (also 85%). Das Programm wird nie aufhören. **Warum?** Schreib deine Antwort als Kommentar in den Code.

Das Problem wird folgendermaßen behoben:
1) Erstelle eine ``Funktion`` ``double SetProzentWaldAufKarte(double wunschProzentBaeume, string[,] karte)``.
2) Zähle mithilfe von zwei verschachtelten ``for``-Schleifen, wie viele Felder auf der Karte aus Erde (``🟫``) oder Stein (``🗻``) bestehen. Speichere das Ergebnis in ``anzahlSteineOderErde``.
3) Berechne die Gesamtanzahl der Felder (``anzahlOrte = breite * hoehe``).
4) Guard ❌: Ist die gewünschte Anzahl an Bäumen (``anzahlOrte * wunschProzentBaeume``) größer als der zur Verfügung stehende Platz (``anzahlSteineOderErde``)? Dann gib den Prozentwert ``0.8 * anzahlSteineOderErde / anzahlOrte`` zurück (das reserviert 80% des nutzbaren Platzes).
5) Gewünschter Zustand ✅: Gib einfach ``wunschProzentBaeume`` unverändert zurück.
6) Rufe die ``Funktion`` im Hauptprogramm auf. Ist der zurückgegebene Wert anders als dein Wunsch, gib **im Hauptprogramm** eine Warnung mit ``Console.WriteLine`` aus.

>**Frage:** Warum funktioniert die Begrenzung nicht mehr ganz sicher, sobald Aufgabe 1 (Mangroven) dazukommt? Ist das schlimm?

---

### 🤔 Aufgabe 3: Sandinseln aufschütten 🟨
Das Hauptprogramm soll vor dem Pflanzen der Bäume Sandinseln im Wasser entstehen lassen.
1) Erstelle eine ``Funktion``
    ```csharp
    string[,] SchuetteInselnAuf(string[,] karteOhneInseln, int limitAnInseln)
    ```
    Arbeite – wie bei *PflanzeBaeume* – auf einer Kopie (``KopiereKarte``).
2) Verwende eine ``while``-Schleife, die so lange läuft, bis ``limitAnInseln`` erreicht ist.
3) Wähle darin zufällige Koordinaten aus. Wenn an diesen Koordinaten Wasser (``🟦``) ist, überschreibe es mit Sand (``🟨``) und erhöhe den Zähler der fertigen Inseln. Implementiere zuerst eine der folgenden Varianten. Danach kommentiere sie aus und probiere die nächste.
    >Tipp: Bei ``generator.Next(min, max)`` ist ``min`` **inklusive** und ``max`` **exklusive**. Verwende ``GetLength(0)`` (Höhe) und ``GetLength(1)`` (Breite) statt fixer Zahlen.

    1) Sandinseln sollen nur im **linken-oberen** Viertel der Karte entstehen können.
        ```
        ❌0️⃣1️⃣2️⃣3️⃣4️⃣5️⃣6️⃣7️⃣
        0️⃣🟨🟨🟨🟨🟦🟦🟦🟦
        1️⃣🟨🟨🟨🟨🟦🟦🟦🟦
        2️⃣🟨🟨🟨🟨🟦🟦🟦🟦
        3️⃣🟨🟨🟨🟨🟦🟦🟦🟦
        4️⃣🟦🟦🟦🟦🟦🟦🟦🟦
        5️⃣🟦🟦🟦🟦🟦🟦🟦🟦
        6️⃣🟦🟦🟦🟦🟦🟦🟦🟦
        7️⃣🟦🟦🟦🟦🟦🟦🟦🟦
        ```
    2) Sandinseln sollen nur im **rechten-unteren** Viertel der Karte entstehen können.
        ```
        ❌0️⃣1️⃣2️⃣3️⃣4️⃣5️⃣6️⃣7️⃣
        0️⃣🟦🟦🟦🟦🟦🟦🟦🟦
        1️⃣🟦🟦🟦🟦🟦🟦🟦🟦
        2️⃣🟦🟦🟦🟦🟦🟦🟦🟦
        3️⃣🟦🟦🟦🟦🟦🟦🟦🟦
        4️⃣🟦🟦🟦🟦🟨🟨🟨🟨
        5️⃣🟦🟦🟦🟦🟨🟨🟨🟨
        6️⃣🟦🟦🟦🟦🟨🟨🟨🟨
        7️⃣🟦🟦🟦🟦🟨🟨🟨🟨
        ```
    3) Sandinseln sollen nur in einem **Viertel symmetrisch um den Mittelpunkt** der Karte entstehen können.
        ```
        ❌0️⃣1️⃣2️⃣3️⃣4️⃣5️⃣6️⃣7️⃣
        0️⃣🟦🟦🟦🟦🟦🟦🟦🟦
        1️⃣🟦🟦🟦🟦🟦🟦🟦🟦
        2️⃣🟦🟦🟨🟨🟨🟨🟦🟦
        3️⃣🟦🟦🟨🟨🟨🟨🟦🟦
        4️⃣🟦🟦🟨🟨🟨🟨🟦🟦
        5️⃣🟦🟦🟨🟨🟨🟨🟦🟦
        6️⃣🟦🟦🟦🟦🟦🟦🟦🟦
        7️⃣🟦🟦🟦🟦🟦🟦🟦🟦
        ```
4) Rufe die ``Funktion`` im Hauptprogramm auf, **bevor** *PflanzeBaeume* ausgeführt wird. Berechne ``anzahlInseln`` mit 3,5% aller Felder und verwende die zurückgegebene Karte mit den Inseln für das anschließende Pflanzen der Bäume.

>**Frage:** Was passiert, wenn du ``limitAnInseln`` größer machst, als es Wasserfelder im gewählten Viertel gibt?

---

### 😕 Aufgabe 4: 🌴 Palmen und Sandstrände 🏖️
Wenn in *PflanzeBaeume* das zufällige Feld aus **Sand** (``🟨``) besteht, soll dort ab sofort eine Palme (``🌴``) wachsen (erhöhe auch hier die Zählvariable). Zusätzlich werden alle **direkt angrenzenden Felder** (Norden, Süden, Westen, Osten) ebenfalls zu Sand – sofern sie noch innerhalb der Karte liegen. Benachbarte Palmen dürfen dabei **nicht** von Sand überschrieben werden.

1) Erstelle eine ``Funktion`` ``void ZeichneSandUmBaum(int xPalme, int yPalme, string[,] karte)``.
   >Sie braucht kein ``return``: Arrays sind ``Referenztypen`` (siehe L02) – Änderungen an ``karte`` sieht auch der Aufrufer.
2) Rufe sie in *PflanzeBaeume* im ``Zweig`` für den Sand auf: ``ZeichneSandUmBaum(x, y, karteMitBaeumen);``
3) Prüfe die 4 Nachbarfelder. Tipp: Schreib dir eine ``Funktion`` ``void ZeichneSand(int x, int y, string[,] karte)``, die du 4-mal aufrufst:
    ```
       ⬜🟨⬜          (x, y-1)
       🟨🌴🟨   (x-1, y)  (x, y)  (x+1, y)
       ⬜🟨⬜          (x, y+1)
    ```
   Guards ❌ (jeweils ``return;``):
   1. Die Koordinate liegt außerhalb der Karte (``x < 0``, ``x >= GetLength(1)``, ``y < 0``, ``y >= GetLength(0)``).
   2. Auf dem Feld steht bereits eine Palme (``🌴``).

   Gewünschter Zustand ✅: Das Feld wird zu Sand (``🟨``).

---

### 😕 Aufgabe 5: ❄️ Winterkarte – Schnee ``⬜`` hat nur ein ``char``
In [weltkarte_winter.txt](weltkarte_winter.txt) liegt auf den Bergen und im Norden Schnee (``⬜``). Lade diese Karte zuerst mit dem bisherigen *LadeKarte* und zeichne sie.

>**Frage:** Warum ist die Karte kaputt (falsche Breite, zerschnittene Symbole ``�``)? Tipp: Exkurs *UTF-16 & UTF-8* in den Slides – ``"🟦".Length`` ist ``2``, ``"⬜".Length`` ist ``1``.

Ein Emoji über ``U+FFFF`` (``🟦``, ``🌳``, …) besteht aus **zwei** ``char``: einem *High Surrogate* und einem *Low Surrogate*. Ob ein ``char`` der **erste Teil** eines solchen Paares ist, verrät ``char.IsHighSurrogate(zeichen)``.

1) Erstelle eine ``Funktion`` ``int ZaehleSymbole(string zeile)``. Gehe mit einer ``while``-Schleife und einem Index ``i`` durch die ``char``s der Zeile:
   * ``char.IsHighSurrogate(zeile[i])`` ist ``true`` → das Symbol ist 2 ``char`` lang → ``i`` um **2** erhöhen.
   * sonst → das Symbol ist 1 ``char`` lang → ``i`` um **1** erhöhen.
   * In beiden Fällen: ein Symbol mehr gezählt.
   ```
   "🟦⬜🌳"   char:  [0] D83D  [1] DFE6  [2] 2B1C  [3] D83C  [4] DF33
                     \__ 🟦 ________/   \_ ⬜ _/   \__ 🌳 ________/
   Length = 5, aber nur 3 Symbole
   ```
2) Erstelle eine ``Funktion`` ``string[] ZerlegeZeile(string zeile)``, die ein Array mit ``ZaehleSymbole(zeile)`` Plätzen anlegt und jedes Symbol mit ``Substring(i, 1)`` oder ``Substring(i, 2)`` hineinlegt.
   >Achtung: Es gibt jetzt **zwei** Positionen: ``x`` im Array (Symbol) und ``i`` im ``string`` (``char``). Sie laufen nicht mehr im Gleichschritt.
3) Erstelle ``string[,] LadeKarteMitSurrogates(string pfad)``: wie *LadeKarte*, aber ``breite = ZaehleSymbole(zeilen[0])`` und die Felder kommen aus ``ZerlegeZeile``.
4) Guard ⚠️: Hat eine Zeile eine andere Anzahl an Symbolen als die erste Zeile, gib eine Warnung mit der Zeilennummer aus.
5) Lade und zeichne die Winterkarte im Hauptprogramm.

>**Frage:** ``❄️`` sieht aus wie ein Zeichen, ist aber ``U+2744`` **plus** ``U+FE0F`` (ein unsichtbarer *Variation Selector*). Was würde ``ZaehleSymbole("❄️")`` liefern?

---

### 😵‍💫 Bonus
* Gib am Ende eine Statistik aus: Wie viele 🌳, 🌲, 🌴 und 🟨 gibt es auf der fertigen Karte? (verschachtelte ``for``-Schleife + Zählvariablen)
* Lass den Benutzer den ``Seed`` eingeben. Gleicher Seed → gleiche Welt!
* Lust auf echte Bilder? Mach die [AufgabeOPTIONAL-KarteAusBild](../AufgabeOPTIONAL-KarteAusBild/Angabe.md).
