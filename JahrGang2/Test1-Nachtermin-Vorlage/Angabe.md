### Test 1 - Nachtermin

Sie können maximal 100 Punkte erreichen
Es sind zur Prüfung zugelassen:
    * Transparente Wasserflasche
    * Von mir ausgegebenes Papier und von Ihnen mitgebrachtes Schreibwerkzeug.

***Alles andere ist nicht zugelassen.***

* Viel Erfolg!

Notenschlüssel:
$[0-50\%)$: N5; $[50-62.5\%)$: G4; $[62.5-75\%)$: B3; $[75-87.5\%)$: G2; $[87.5-100\%]$: S1;

---

#### Aufgabe 01 - Eingabevalidierung für Fahnen-Muster - 60%

>🎬 Zu dieser Aufgabe gibt es eine Hilfe zum Durchklicken: ``Aufgabe1/Animated-Slides-Aufgabe1.html`` (im Browser öffnen, funktioniert ohne Internet).

##### 1. Funktionen der Eingabevalidierung

- **LeseLand: 🤔**
  * Nimmt einen Userprompt als ``Eingangsparameter`` entgegen und erlaubt dem *Benutzer*, ein Land als **Wort** einzugeben.
  * ***Gültig bedeutet:*** Fragt den Benutzer in einer ``Schleife`` solange nach einer Eingabe, bis eines der folgenden Wörter eingegeben wurde: **AUT, Austria, Österreich, GER, Germany oder Deutschland**. Groß- und Kleinschreibung spielt dabei keine Rolle – auch `aut`, `AUSTRIA` oder `dEuTsChLaNd` sind gültig. Verwende dafür `ToLower()`.
  * **Bei jeder anderen Eingabe** (z. B. einem Schreibfehler wie `Österrreich`) wird die Konsole mit `Console.Clear()` geleert, die Fehlermeldung `❌ Unbekanntes Land! Erlaubt sind AUT, Austria, Österreich, GER, Germany oder Deutschland.` ausgegeben und der Prompt erneut abgefragt.
  * **Rückgabe:** ein `string[]`-`Array` mit den **drei Farben der Flagge** in dieser Reihenfolge:

    | Land | Index 0 (Farbe 1) | Index 1 (Trennlinie) | Index 2 (Farbe 2) |
    |---|---|---|---|
    | Österreich | 🟥 | ⬛ | ⬜ |
    | Deutschland | 🟨 | ⬛ | 🟥 |

- **LesePositiveZahl: 🤔**
  * Nimmt einen Userprompt als ``Eingangsparameter`` entgegen und erlaubt dem *Benutzer*, eine gültige Zahl einzugeben.
  * ***Gültig bedeutet:*** Verwendet eine ``Schleife`` in Kombination mit `int.TryParse`, um sicherzustellen, dass der Benutzer eine ganze Zahl eingibt, die **größer als 0** ist.
  * **Bei jeder anderen Eingabe** wird die Konsole mit `Console.Clear()` geleert, die Fehlermeldung `❌ Ungültige Eingabe! Bitte eine positive ganze Zahl (> 0) eingeben.` ausgegeben und erneut gefragt.

- **LeseUngeradeBreite: 💀**
  * Nimmt einen Userprompt als ``Eingangsparameter`` entgegen und erlaubt dem *Benutzer*, eine gültige Breite für das Muster einzugeben.
  * ***Gültig bedeutet:*** Liest die Eingabe in einer ``Schleife`` ein und überprüft nacheinander **drei mögliche ungewünschte Zustände (Fehlerfälle)** mit jeweils `Console.Clear()`, einer **eigenen, spezifischen Fehlermeldung** und dem erneuten Prompt:
    1. **Fehlerfall 1 (Keine ganze Zahl):** Wenn die Umwandlung mit `int.TryParse` fehlschlägt, gib aus:
       > `❌ Fehler: Ungültige Eingabe! Bitte geben Sie eine gültige ganze Zahl ein.`
    2. **Fehlerfall 2 (Zahl ist kleiner als 3):** Wenn die eingegebene Zahl kleiner als 3 ist, gib aus:
       > `❌ Fehler: Die Breite ist zu klein! Sie muss mindestens 3 betragen.`
    3. **Fehlerfall 3 (Zahl ist gerade):** Wenn die eingegebene Zahl gerade ist, gib aus:
       > `❌ Fehler: Die Breite muss ungerade sein, damit es genau eine Mitte gibt (z. B. 3, 5, 7).`
  * Erst wenn keiner der drei Fehlerfälle zutrifft (gewünschter Zustand), wird die Zahl (`breite`) mit `return` zurückgegeben.

>Hinweis: Schreibe eine ``Schleife`` mit einer ``Bedingung`` die immer *true* ist. Verwende dann ``Bedingte Anweisungen`` um spezielle Fehler ausgeben zu können. Innerhalb der ``Bedingten Anweisungen`` für ungewünschte Zustände ❌ verwende anstatt *return* das ``Keyword`` ***continue*** um wieder zum Anfang der ``Schleife`` zu springen.
---

##### 2. Funktionen für Muster
* **`ZeichneFahnenMuster` 🤔**:
  * Nimmt die Höhe (**anzahlZeilen**), die Breite (**anzahlSpalten**) und die Flaggenfarben (**farben**, das Array von `LeseLand`) als `Eingangsparameter` entgegen und gibt das Muster direkt in der `Konsole` aus.
  * **Vorgehensweise:**
    * Zu Beginn stellt eine `Guard Clause` sicher, dass die Anzahl der Spalten (**anzahlSpalten**) **ungerade** und größer als 0 ist und die Anzahl der Zeilen (**anzahlZeilen**) größer als 0 ist. Die Anzahl der Zeilen darf beliebig groß sein. Trifft das nicht zu, wird eine Fehlermeldung ausgegeben und die Methode sofort per `return` abgebrochen.
    * Die **mittlere Spalte** bekommt immer die **Trennlinie** (⬛). Sie teilt jede Zeile in eine **linke** und eine **rechte Hälfte**.
    * In Zeilen mit **gerader** Zeilennummer (0, 2, 4, …) steht links **Farbe 1** und rechts **Farbe 2**. In Zeilen mit **ungerader** Zeilennummer ist es genau umgekehrt.

* **`ErstelleStufenMuster` 🤔**:
  * Nimmt die Anzahl der Stufen (**anzahlStufen**) sowie die Flaggenfarben (**farben**) als `Eingangsparameter` entgegen.
  * Die 1. Stufe besteht aus **einem** Feld, die 2. Stufe aus **zwei**, die 3. Stufe aus **drei** Feldern usw.
  * Die Stufen verwenden **alle drei** Flaggenfarben der Reihe nach: Die 1. Stufe bekommt Farbe 1, die 2. Stufe die Trennlinie, die 3. Stufe Farbe 2, die 4. Stufe wieder Farbe 1 usw.
  * Lege ein `string[]`-`Array` (**muster**) an, das **genau so lang** ist, wie alle Stufen zusammen Felder haben, befülle es Stufe für Stufe und gib es zurück.

* **`PrintArray` 🙂**:
  * Nimmt ein eindimensionales `string[]`-`Array` (**items**), ein **startSymbol** und ein **endSymbol** entgegen und gibt alle Elemente mit einer `for`-Schleife im folgenden Format in einer Zeile aus:
    `🚦[ 🟨⬛⬛🟥🟥🟥 ]🏁`

##### 3. Erwarteter Output
```
Bitte Land für die Fahne eingeben (AUT oder GER): GER
Bitte ungerade Breite (mind. 3) eingeben: 7
Bitte Höhe (> 0) eingeben: 5

--- Fahnen-Muster (5 x 7) ---
🟨🟨🟨⬛🟥🟥🟥
🟥🟥🟥⬛🟨🟨🟨
🟨🟨🟨⬛🟥🟥🟥
🟥🟥🟥⬛🟨🟨🟨
🟨🟨🟨⬛🟥🟥🟥

--- 1D Stufen-Muster (1x, 2x, 3x, ... in den Flaggenfarben) ---
Bitte Land für die Stufen eingeben (AUT oder GER): Österreich
Bitte Anzahl der Stufen (> 0) eingeben: 6

Ausgabe des Stufen-Arrays:
🚦[ 🟥⬛⬛⬜⬜⬜🟥🟥🟥🟥⬛⬛⬛⬛⬛⬜⬜⬜⬜⬜⬜ ]🏁
```

---

#### Aufgabe 02 - Verschachtelungen umschreiben für das Leichtathletik-Turnier - 40%

>🎬 Zu dieser Aufgabe gibt es eine Hilfe zum Durchklicken: ``Aufgabe2/Animated-Slides-Aufgabe2.html`` (im Browser öffnen, funktioniert ohne Internet).

Bei einem Leichtathletik-Turnier im Ernst-Happel-Stadion wurde von jedem Lauf die Zeit für **eine Stadionrunde** (400 m) in Sekunden gemessen. Für die Siegerehrung soll pro Bewerb die **schnellste** Runde gefunden werden. Nur bei den **Schnellgehern** wird die **langsamste** Runde gesucht – sie bekommt den Preis für die beste Ausdauer.

##### 1. Ausgangscode
Schreibe die in der ``Funktion`` *SucheBesteRunde* befindliche ``Verschachtelung`` in eine ``Guard Clause`` um.

##### 2. Referenztypen mit Werttypsemantik zuweisen, Guard Clauses und Suchfunktionen
1. **`Arrays` klonen im Hauptprogramm: 🙂**
   * Erstelle im Hauptprogramm vor dem Aufruf von `SucheBesteRunde` Kopien (**bewerbe**, **athleten**, **rundenzeitenSek**) der vorgegebenen Original-`Arrays` (**originalBewerbe**, **originalAthleten**, **originalRundenzeitenSek**), indem du direkt `.Clone()` mit dem passenden `Cast` (`(string[])` bzw. `(int[])`) aufrufst. Schreibe dazu den ``Cast`` vor den ``Namen`` der ``Variable``.

2. **`Guard Clauses` in `SucheBesteRunde`: 🙂**
   * Schreibe die ``Verschachtelung`` in `SucheBesteRunde` zu `Guard Clauses` um. Tu dies innerhalb dieser ``Funktion``.
   * Rufe für **bewerb** `"Schnellgehen"` die Funktion `FindeLangsamsteRunde` auf und gib den ermittelten Athleten aus **athleten** sowie die Rundenzeit aus **rundenzeiten** aus.
   * Rufe für alle anderen Laufbewerbe die Funktion `FindeSchnellsteRunde` auf und gib den ermittelten Athleten aus **athleten** sowie die Rundenzeit aus **rundenzeiten** aus. Verwende dazu ``Interpolated Strings``, welche folgendermaßen zu schreiben sind: ``$"Text {variable}"``.

3. **`FindeSchnellsteRunde` 🤔:**
   * Nimm den gesuchten Bewerb (**bewerb**), das `Array` der Bewerbe (**bewerbe**) und das `Array` der Rundenzeiten (**rundenzeiten**) als `Eingangsparameter` entgegen und gib den `Index` (**besterIndex**) als `int` zurück.
   * Durchsuche das `Array` **bewerbe** mit einer ``Zählschleife`` nach allen Einträgen, die mit **bewerb** übereinstimmen, und ermittle den ``Index`` der **kürzesten Rundenzeit**.

4. **`FindeLangsamsteRunde` 🤔:**
   * Wie `FindeSchnellsteRunde`, nur berechne die **längste Rundenzeit**.

##### 3. Erwarteter Output
```
⚡ Schnellste Runde im Bewerb Sprint:
   Athlet:     Mia Berger (Index 2)
   Rundenzeit: 45 Sekunden

🐢 Langsamste Runde im Bewerb Schnellgehen:
   Athlet:     Simon Egger (Index 27)
   Rundenzeit: 110 Sekunden

⚡ Schnellste Runde im Bewerb Hürden:
   Athlet:     Nora Fuchs (Index 10)
   Rundenzeit: 50 Sekunden

⚡ Schnellste Runde im Bewerb Mittelstrecke:
   Athlet:     Noah Eder (Index 15)
   Rundenzeit: 57 Sekunden

⚡ Schnellste Runde im Bewerb Langstrecke:
   Athlet:     Clara Böhm (Index 22)
   Rundenzeit: 66 Sekunden
❌ Fehler: Unbekannter Bewerb! Erlaubt sind nur Sprint, Hürden, Mittelstrecke, Langstrecke oder Schnellgehen.
❌ Fehler: Das Turnier findet nur im Ernst-Happel-Stadion statt!
```
