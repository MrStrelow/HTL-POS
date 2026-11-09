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

#### Aufgabe 01 - Fahnen und Startsignale für das Länderspiel - 60%

Beim Länderspiel **Österreich gegen Deutschland** sollen in der Konsole **Fahnen** gezeichnet und eine **Startsignal-Leiste** in den Flaggenfarben erzeugt werden. Das Land und die Größen gibt der *Benutzer* ein – und der tippt gerne Unsinn. Dein Programm muss deshalb jede Eingabe prüfen und so lange nachfragen, bis sie passt.

>🎬 Hilfe zum Durchklicken (ohne Internet): ``Aufgabe1/Animated-Slides-Aufgabe1.html``

##### Teil A – Eingaben prüfen

Alle drei ``Funktionen`` bekommen den Text, der dem Benutzer angezeigt wird (**prompt**), als ``Eingangsparameter`` und geben erst dann etwas zurück, wenn die Eingabe gültig ist. Bei jeder ungültigen Eingabe wird die Konsole mit `Console.Clear()` geleert, eine Fehlermeldung angezeigt und erneut gefragt.

| Funktion | Rückgabetyp | gültig ist … | Fehlermeldung |
|---|---|---|---|
| **LeseLand** 🤔 | `string[]` | eines der Wörter AUT, Austria, Österreich, GER, Germany, Deutschland – egal ob groß oder klein geschrieben (`ToLower()`) | `❌ Unbekanntes Land! Erlaubt sind AUT, Austria, Österreich, GER, Germany oder Deutschland.` |
| **LesePositiveZahl** 🤔 | `int` | eine ganze Zahl, die größer als 0 ist (prüfe mit `int.TryParse`) | `❌ Ungültige Eingabe! Bitte eine positive ganze Zahl (> 0) eingeben.` |
| **LeseUngeradeBreite** 💀 | `int` | eine ganze, **ungerade** Zahl, die **mindestens 3** ist | je Fehlerfall eine eigene Meldung, siehe unten |

**LeseLand** gibt die drei Farben der Flagge als ``Array`` zurück:

| Eingabe (Beispiele) | Rückgabe |
|---|---|
| `AUT`, `austria`, `ÖSTERREICH` | `{ "🟥", "⬛", "⬜" }` |
| `ger`, `Germany`, `deutschland` | `{ "🟨", "⬛", "🟥" }` |
| `Österrreich`, `DE`, `Schweiz` | ❌ Fehlermeldung, neu fragen |

Der mittlere Eintrag (⬛) ist immer die **Trennlinie**.

**LeseUngeradeBreite** unterscheidet drei Fehlerfälle. Sie werden in genau dieser Reihenfolge geprüft. Nach jedem Fehler beginnt die Abfrage von vorne (``continue``):

| Eingabe | Fehlerfall | Meldung |
|---|---|---|
| `sieben` | keine ganze Zahl | `❌ Fehler: Ungültige Eingabe! Bitte geben Sie eine gültige ganze Zahl ein.` |
| `1` | zu klein | `❌ Fehler: Die Breite ist zu klein! Sie muss mindestens 3 betragen.` |
| `6` | gerade | `❌ Fehler: Die Breite muss ungerade sein, damit es genau eine Mitte gibt (z. B. 3, 5, 7).` |
| `7` | – | ✅ Rückgabe `7` |

##### Teil B – Die Fahne zeichnen

**ZeichneFahnenMuster** 🤔 bekommt die Anzahl der Zeilen (**anzahlZeilen**), die Anzahl der Spalten (**anzahlSpalten**) und die Flaggenfarben (**farben**). Es zeichnet die Fahne direkt in die ``Konsole`` und gibt nichts zurück.

So sehen die Fahnen mit 5 Zeilen und 7 Spalten aus:

```
Deutschland              Österreich
🟨🟨🟨⬛🟥🟥🟥          🟥🟥🟥⬛⬜⬜⬜
🟥🟥🟥⬛🟨🟨🟨          ⬜⬜⬜⬛🟥🟥🟥
🟨🟨🟨⬛🟥🟥🟥          🟥🟥🟥⬛⬜⬜⬜
🟥🟥🟥⬛🟨🟨🟨          ⬜⬜⬜⬛🟥🟥🟥
🟨🟨🟨⬛🟥🟥🟥          🟥🟥🟥⬛⬜⬜⬜
```

Finde selbst heraus, nach welcher Regel die Felder gefärbt werden. Die Fahne muss für **jede** ungerade Spaltenanzahl und **jede** Zeilenanzahl stimmen.
Ist die Spaltenanzahl gerade oder nicht positiv, oder ist die Zeilenanzahl nicht positiv, wird nichts gezeichnet. Stattdessen erscheint eine Fehlermeldung, und die Funktion endet sofort (``Guard Clause``).

##### Teil C – Die Startsignal-Leiste

**ErstelleStufenMuster** 🤔 bekommt die Anzahl der Stufen (**anzahlStufen**) und die Flaggenfarben (**farben**) und gibt ein `string[]` zurück. Jede Stufe ist um ein Feld länger als die vorige, und die Stufen wechseln der Reihe nach durch **alle drei** Flaggenfarben.

| anzahlStufen | Land | zurückgegebenes Array |
|---|---|---|
| 1 | Deutschland | 🟨 |
| 3 | Deutschland | 🟨⬛⬛🟥🟥🟥 |
| 4 | Deutschland | 🟨⬛⬛🟥🟥🟥🟨🟨🟨🟨 |
| 6 | Österreich | 🟥⬛⬛⬜⬜⬜🟥🟥🟥🟥⬛⬛⬛⬛⬛⬜⬜⬜⬜⬜⬜ |

Das Array darf keine leeren Plätze haben.

**PrintArray** 🙂 bekommt das Array (**items**), ein **startSymbol** und ein **endSymbol** und gibt alles mit einer `for`-Schleife in **einer** Zeile aus, z. B. für 3 Stufen Deutschland mit 🚦 und 🏁:
`🚦[ 🟨⬛⬛🟥🟥🟥 ]🏁`

##### Teil D – Hauptprogramm
In ``Program.cs`` ist das Hauptprogramm vorbereitet. Ersetze die ``TODO``s durch Aufrufe deiner ``Funktionen``.

##### Erwarteter Output
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

#### Aufgabe 02 - Siegerehrung im Ernst-Happel-Stadion - 40%

>🎬 Hilfe zum Durchklicken (ohne Internet): ``Aufgabe2/Animated-Slides-Aufgabe2.html``

Beim Leichtathletik-Turnier wurde in fünf Laufbewerben die Zeit für **eine Stadionrunde** in Sekunden gemessen. Die Daten stehen in drei gleich langen ``Arrays``: An derselben Position stehen jeweils Bewerb, Athlet bzw. Athletin und Rundenzeit.

| Index | originalBewerbe | originalAthleten | originalRundenzeitenSek |
|---|---|---|---|
| 0 | Sprint | Lena Huber | 47 |
| 1 | Sprint | Jonas Gruber | 52 |
| … | … | … | … |
| 29 | Schnellgehen | Moritz Lechner | 95 |

Für die Siegerehrung gilt:
* In **Sprint**, **Hürden**, **Mittelstrecke** und **Langstrecke** gewinnt die **schnellste** Runde (⚡).
* Im **Schnellgehen** gibt es einen Ausdauerpreis für die **langsamste** Runde (🐢).
* Das Turnier findet **nur im Ernst-Happel-Stadion** statt. Wird ein anderes Stadion oder ein anderer Bewerb angefragt, erscheint eine Fehlermeldung.

##### Deine Aufgaben

1. **Kopien statt Originale 🙂**
   Die Original-``Arrays`` dürfen nicht verändert werden. Lege im Hauptprogramm die Kopien **bewerbe**, **athleten** und **rundenzeitenSek** mit `.Clone()` und dem passenden ``Cast`` an und verwende ab dann nur noch die Kopien.

2. **Aufräumen mit Guard Clauses 🙂**
   Die ``Funktion`` *SucheBesteRunde* ist bereits vorhanden, aber dreifach verschachtelt und schwer zu lesen. Schreibe sie so um, dass zuerst alle **ungewünschten Zustände** mit ``return`` abgefangen werden. Die Ausgabe des Programms darf sich dabei nicht ändern.
   Ergänze danach an den ``TODO``-Stellen die Aufrufe der Suchfunktionen und gib den Athleten bzw. die Athletin und die Rundenzeit mit ``Interpolated Strings`` aus (Format siehe erwarteter Output).

3. **Die Suchfunktionen 🤔**
   | Funktion | Eingangsparameter | Rückgabe |
   |---|---|---|
   | **FindeSchnellsteRunde** | bewerb, bewerbe, rundenzeiten | ``Index`` der kürzesten Rundenzeit **dieses** Bewerbs |
   | **FindeLangsamsteRunde** | bewerb, bewerbe, rundenzeiten | ``Index`` der längsten Rundenzeit **dieses** Bewerbs |

   Beide durchsuchen die ``Arrays`` mit einer ``Zählschleife``. Einträge anderer Bewerbe werden ignoriert.

##### Erwarteter Output
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
