### Test 1 - Nachtermin

Sie können maximal 100 Punkte erreichen
Es sind zur Prüfung zugelassen:
    * Transparente Wasserflasche
    * Von mir ausgegebenes Papier und von Ihnen mitgebrachtes Schreibwerkzeug.

***Alles andere ist nicht zugelassen.***

* Viel Erfolg!

Notenschlüssel:
[0-50): N5; [50-62.5%): G4; [62.5-75%): B3; [75-87.5%): G2; [87.5-100%]: S1., 

---

#### Aufgabe 01 - Bergsteiger am Berg - 45%

>🎬 Zu dieser Aufgabe gibt es eine Hilfe zum Durchklicken: ``Aufgabe1/Animated-Slides-Aufgabe1.html`` (im Browser öffnen, funktioniert ohne Internet).

Ein Hubschrauber setzt Bergsteiger:innen am Gipfel ab. Im dichten Nebel klettern sie zufällig über den verschneiten Berg. Sobald jemand eine **Alm** erreicht, macht er dort **für immer Rast**. Steht ein **Fels** im Weg, kann er mit seinem **Pickel** freigeschlagen werden – aber nur, solange der Pickel hält. Ein Bergsteiger weiß nicht, wie der Berg aussieht – er fragt den Berg, ob er an eine bestimmte Stelle klettern darf.

##### Allgemeine Rahmenbedingungen der Simulation
* **Kartengröße:** Der Berg ist quadratisch und muss **mindestens 12 × 12 Felder** groß sein (falls beim Erstellen ein kleinerer Wert übergeben wird, wird die Größe automatisch auf 12 gesetzt). Er darf aber auch größer sein.
* **Gelände-Aufteilung:**
  * Der **Rand** des Berges (erste und letzte Zeile, erste und letzte Spalte) ist Alm (🟩), das Innere Schnee (⬜).
  * Zusätzlich sind **15 % der Gesamtfläche** Almen (🟩) – nur auf Feldern, die vorher Schnee waren.
  * **10 % der Gesamtfläche** sind Fels (🪨) – ebenfalls nur auf Schnee.
* **Anzahl der Bergsteiger:**
  * Es werden genau **5 % der Gesamtfläche** (abgerundet auf ganze Zahlen, bei 12 × 12 also 7) Bergsteiger abgesetzt.
* **Startpositionen:**
  * Die ersten drei Bergsteiger werden am Gipfel in der Mitte auf die Koordinaten *(y, x)* **(Groesse / 2, Groesse / 2)**, **(Groesse / 2 − 1, Groesse / 2)** und **(Groesse / 2, Groesse / 2 − 1)** abgesetzt. Alle weiteren erhalten eine zufällige Startposition.
* **Symbole:** kletternder Bergsteiger 🧗, rastender Bergsteiger 🏕️.

##### Beschreibung der Klassen

##### 1. Klasse `Pickel`
* **Eigenschaften:**
  * **Haltbarkeit:** Wie oft der Pickel noch verwendet werden kann (nur innerhalb der Klasse setzbar).
  * **IstKaputt:** Nur lesbar. *Wahr*, wenn die **Haltbarkeit** 0 ist.
* **Konstruktor:**
  * Nimmt die **Haltbarkeit** als Default-Parameter entgegen (Standardwert **3**) und speichert sie.
* **Methoden:**
  * **Benutzen:** Ist der Pickel kaputt, liefert die Methode *falsch*. Sonst verringert sie die **Haltbarkeit** um 1 und liefert *wahr*.

##### 2. Klasse `Bergsteiger`
* **Eigenschaften:**
  * **Berg:** Referenz auf den Berg, auf dem der Bergsteiger klettert (nur innerhalb der Klasse setzbar).
  * **Position:** Ein Tupel für Zeile und Spalte *(y, x)* (nur innerhalb der Klasse setzbar).
  * **Rastet:** Wahrheitswert, ob der Bergsteiger auf einer Alm rastet (nur innerhalb der Klasse setzbar, am Anfang *falsch*).
  * **Pickel:** Der eigene Pickel (1-zu-1 Beziehung, nur innerhalb der Klasse setzbar).
* **Konstruktor:**
  * Nimmt die Referenz auf den **Berg** sowie ein Tupel für die **Startposition** entgegen und speichert beide. Erzeugt einen **neuen Pickel** und ruft sofort die eigene Methode **Absetzen** auf.
* **Methoden:**
  * **Absetzen:**
    * Versucht, den Bergsteiger auf der Startposition abzusetzen. Dazu fragt er den Berg mit **IstPlatzierbar**.
    * **Falls das nicht möglich ist** (Fels, Alm, schon ein Bergsteiger oder außerhalb): Der Bergsteiger wählt in einer Schleife solange zufällige neue Koordinaten *(y, x)* innerhalb der Berggröße aus, bis **IstPlatzierbar** eine positive Rückmeldung liefert.
    * Die gefundene Koordinate wird in **Position** gespeichert.
  * **Klettern:**
    * Rastet der Bergsteiger bereits, passiert **nichts** (er bleibt für immer auf der Alm).
    * Sonst versucht der Bergsteiger **höchstens 10-mal** (Default-Parameter), in eine zufällige Richtung zu klettern: *dy* und *dx* sind jeweils zufällig −1, 0 oder 1.
    * ⛏️ Ist das Ziel **Fels** (**IstFels(ziel)**) und kann der **Pickel benutzt** werden, schlägt der Berg das Feld mit **SchlageFrei(ziel)** frei. Danach folgt der nächste Versuch.
    * Ob der Bergsteiger dorthin darf, entscheidet der **Berg** mit **KannKlettern(Position, ziel)**. Wenn nicht, folgt der nächste Versuch.
    * **Sobald ein Versuch klappt:**
      1. Der Bergsteiger fragt den Berg mit **IstAlm(ziel)**, ob das Ziel eine Alm ist, und speichert das Ergebnis in **Rastet**.
      2. Der Berg versetzt den Bergsteiger in seiner Karte mit **VersetzeBergsteiger(Position, ziel, Rastet)**.
      3. Der Bergsteiger speichert das Ziel als neue **Position** und beendet die Methode.

##### 3. Klasse `Berg`
* **Felder & Eigenschaften:**
  * **Karte:** Ein **privates** zweidimensionales Text-Array für Zeilen und Spalten. Es darf von anderen Klassen **nicht** direkt gelesen oder verändert werden!
  * **Groesse:** Öffentlich lesbare Eigenschaft für die Seitenlänge des Berges (nur intern setzbar).
  * **Bergsteiger:** Öffentlich lesbares 1D-Array aller Bergsteiger (1-zu-*n* Beziehung, nur intern setzbar).
* **Konstruktor:**
  * Nimmt die gewünschte Seitenlänge als Parameter entgegen (mindestens 12, als Default-Parameter).
  * Erstellt das 2D-Array **Karte**, befüllt den Rand mit 🟩 und das Innere mit ⬜.
  * Platziert anschließend auf **15 % der Felder** zusätzlich 🟩 und auf **10 % der Felder** 🪨 an zufälligen Feldern mit Schnee.
  * Berechnet die Anzahl der Bergsteiger (**5 % der Gesamtfläche**), legt das 1D-Array **Bergsteiger** an und erzeugt die Bergsteiger-Objekte (die ersten drei am Gipfel in der Mitte, den Rest mit Zufallskoordinaten). Jeder Bergsteiger muss **genau diesen** Berg kennen!
* **Methoden:**
  * **IstPlatzierbar:** Nimmt eine Position als Tupel *(y, x)* entgegen und gibt einen Wahrheitswert zurück. Prüft die Kartengrenzen und ob dort Schnee (⬜) ist. Ist das so, trägt die Methode einen kletternden Bergsteiger (🧗) in die **Karte** ein und gibt *wahr* zurück.
  * **KannKlettern:** Nimmt die aktuelle Position *von* und die Zielposition *ziel* entgegen. Liefert *falsch*, wenn *ziel* gleich *von* ist, außerhalb liegt oder dort Fels (🪨) oder bereits ein Bergsteiger (🧗 oder 🏕️) ist. Sonst *wahr*.
  * **IstAlm:** Liefert *wahr*, wenn die Position auf der Karte liegt und dort eine Alm (🟩) ist.
  * **IstFels:** Liefert *wahr*, wenn die Position auf der Karte liegt und dort Fels (🪨) ist.
  * **SchlageFrei:** Ist an der Position Fels, wird dort Schnee (⬜) eingetragen.
  * **VersetzeBergsteiger:** Nimmt *von*, *ziel* und *rastet* entgegen. Auf *von* wird wieder Schnee (⬜) eingetragen, auf *ziel* ein rastender (🏕️) oder kletternder (🧗) Bergsteiger.
  * **Simuliere:** Nimmt eine Anzahl an Runden entgegen. In jeder Runde klettert **jeder** Bergsteiger einmal.
  * **ZaehleRastende:** Liefert die Anzahl der Bergsteiger, die rasten.
  * **ZaehleKaputtePickel:** Liefert die Anzahl der Bergsteiger, deren Pickel kaputt ist.
  * **Print:** Gibt die gesamte **Karte** zeilenweise in der Konsole aus.

##### 4. Hauptprogramm (`Program`)
* Stellt die Konsolenausgabe auf UTF-8 um, erstellt einen **Berg** (z. B. Größe 12) und gibt ihn mit **Print** aus.
* Simuliert 5 Runden und gibt den Berg, die Anzahl der rastenden Bergsteiger und der kaputten Pickel aus. Danach weitere 50 Runden, wieder mit Ausgabe.

---

##### 5. Erwartete Ausgabe
Durch Zufall nicht 1 zu 1 verwendbar.
```
🟩🟩🟩🟩🟩🟩🟩🟩🟩🟩🟩🟩
🟩⬜🪨⬜🪨⬜🟩🪨⬜🟩🪨🟩
🟩🟩🪨🟩🟩⬜⬜⬜🪨🟩⬜🟩
🟩🪨⬜⬜⬜🟩⬜🏕️⬜🟩⬜🏕️
🟩⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜🟩
🟩⬜🪨⬜⬜⬜⬜⬜🟩⬜⬜🟩
🟩⬜🟩⬜🪨🪨🟩⬜⬜⬜⬜🟩
🟩⬜🏕️⬜⬜⬜⬜⬜⬜🧗⬜🟩
🟩⬜⬜⬜⬜⬜🏕️⬜🟩⬜🟩🟩
🟩⬜⬜⬜🟩⬜🪨⬜⬜⬜🏕️🟩
🟩⬜⬜⬜🟩🟩⬜⬜⬜⬜🟩🟩
🟩🟩🟩🏕️🟩🟩🟩🟩🟩🟩🟩🟩

Rastende Bergsteiger: 6 | kaputte Pickel: 0
```
Weitere Zwischenschritte: siehe HTML-Slide.

---

#### Aufgabe 02 - Doubly Linked List - 45%

>🎬 Zu dieser Aufgabe gibt es eine Hilfe zum Durchklicken: ``Aufgabe2/Animated-Slides-Aufgabe2.html`` (im Browser öffnen, funktioniert ohne Internet).

##### 1. Knoten- und Listen-Struktur
* Erstelle die Klasse **Node** mit den Eigenschaften für den gespeicherten Wert (**Value**), den Nachfolger (**Next**) und den Vorgänger (**Previous**).
* Die Klasse **DoublyLinkedList** verwaltet den ersten Knoten (**Head**), den letzten Knoten (**Tail**) sowie die aktuelle Anzahl der Elemente in der Liste (**Count**).
* In der Klasse **DoublyLinkedList** ist **AddLast** bereits fertig vorgegeben. Die übrigen Methodensignaturen sind mit einer `NotImplementedException` vorbereitet und sollen vollständig implementiert werden. Achte dabei besonders auf alle Spezialfälle sowie die korrekte Pflege von **Next**, **Previous**, **Head**, **Tail** und **Count**!
$\\$
$\\$

##### 2. Private Hilfsmethode
* **GetNodeAt:**
  * Implementiere eine **private** Hilfsmethode, die einen nullbasierten **index** entgegennimmt und den Knoten (**Node**) an dieser Stelle zurückgibt.
  * **Intelligente Richtungswahl:** Nutze die Eigenschaft **Count**, um effizient zu navigieren:
    * Liegt der gesuchte Index in der **ersten Hälfte** der Liste (*index < Count / 2*), startet die Suche bei **Head** und wandert in einer Schleife über **Next** nach vorne bis zum Zielindex.
    * Liegt der gesuchte Index in der **zweiten Hälfte** der Liste (*index >= Count / 2*), startet die Suche bei **Tail** und wandert in einer Schleife über **Previous** rückwärts bis zum Zielindex.
  * Verwende diese Hilfsmethode anschließend überall dort wieder, wo ein Knoten an einem bestimmten Index benötigt wird!

##### 3. Zu implementierende Hauptmethoden
1. **RemoveFirst:**
   * Entfernt den ersten Knoten (**Head**), verringert **Count** um 1 und gibt den **Wert** des entfernten Knotens zurück.
   * **Spezialfälle:** Ist die Liste leer, wird eine `InvalidOperationException` geworfen. Enthält die Liste genau **ein** Element, werden **Head** und **Tail** zu `null`.
2. **RemoveLast:**
   * Entfernt den letzten Knoten (**Tail**), verringert **Count** um 1 und gibt den **Wert** des entfernten Knotens zurück.
   * **Spezialfälle:** wie bei RemoveFirst.
3. **RemoveAt:**
   * Entfernt den Knoten an der angegebenen, nullbasierten Position (**index**) und gibt seinen Wert zurück.
   * **Spezialfälle & Wiederverwendung:**
     * Liegt der Index außerhalb des gültigen Bereichs (*index < 0* oder *index >= Count*), wird eine `ArgumentOutOfRangeException` geworfen.
     * Wird als Index `0` übergeben, rufe direkt **RemoveFirst** auf.
     * Entspricht der Index genau **Count − 1**, rufe direkt **RemoveLast** auf.
   * **Normalfall:** Ermittle den Knoten mithilfe deiner privaten Hilfsmethode **GetNodeAt**, verbinde dessen Vorgänger (**Previous**) und Nachfolger (**Next**) direkt miteinander und verringere **Count** um 1.
4. **HasLoop:**
   * Eine fehlerhaft programmierte Liste kann einen Zyklus enthalten – ein Durchlauf würde nie bei `null` ankommen.
   * **HasLoop** liefert *wahr*, wenn **CheckForwardLoop** oder **CheckBackwardLoop** einen Zyklus findet.
   * **CheckForwardLoop** (privat): Zwei Zeiger starten bei **Head**. Der *langsame* Zeiger geht pro Schleifendurchlauf **einen** Schritt über **Next**, der *schnelle* Zeiger **zwei** Schritte. Treffen sich die beiden auf demselben Knoten, gibt es einen Zyklus. Erreicht der schnelle Zeiger `null`, gibt es keinen.
   * **CheckBackwardLoop** (privat): genauso, aber beginnend bei **Tail** über **Previous**.
5. **Reverse:**
   * Dreht die Reihenfolge der Liste um: Aus *[10] <-> [20] <-> [30]* wird *[30] <-> [20] <-> [10]*.
   * Es werden **keine Werte** kopiert und **keine neuen Knoten** erzeugt – nur Zeiger umgebogen!
   * Gehe mit einem Zeiger *curr* von **Head** aus durch die Liste und **tausche bei jedem Knoten Next und Previous**.
     **Achtung:** Merke dir den alten Nachfolger in einer Hilfsvariable, *bevor* du **Next** überschreibst – sonst findest du den nächsten Knoten nicht mehr.
   * Tausche zum Schluss **Head** und **Tail**.
   * **Spezialfälle:** Eine leere Liste und eine Liste mit einem Element müssen ohne Fehler funktionieren.


---

$\\$
$\\$
$\\$
$\\$
$\\$
$\\$
$\\$
$\\$
$\\$
$\\$
$\\$
$\\$
$\\$
$\\$
$\\$
$\\$

#### Aufgabe 03 - Code Analyse - 10%
PoS - CAMM - 3CHIF

**Name:** 
_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 
**Datum:** 
_ _ _ _ _ _ _ _ _ _
Eine **Seilschaft** ist eine einfach verkettete Liste von Kletterern. Für den Abstieg soll die Methode **Umdrehen** die Reihenfolge umkehren: Wer zuletzt geht, geht nun voran. Erwartet wird ``Cem - Ben - Anna``, das Programm gibt aber nur ``Anna`` aus. Was fällt dir auf? Wo sind Ben und Cem geblieben? Wie beheben wir den Fehler?

```csharp
public class Kletterer
{
    public string Name { get; private set; }
    public Kletterer? Next { get; set; }

    public Kletterer(string name)
    {
        Name = name;
    }
}

public class Seilschaft
{
    public Kletterer? Head { get; private set; }

    // AddLast und Print funktionieren richtig und sind hier ausgelassen.

    public void Umdrehen()
    {
        Kletterer? prev = null;
        Kletterer? curr = Head;
        while (curr != null)
        {
            curr.Next = prev;
            prev = curr;
            curr = curr.Next;
        }
        Head = prev;
    }
}

// Program.cs
Seilschaft seilschaft = new Seilschaft();
seilschaft.AddLast(new Kletterer("Anna"));
seilschaft.AddLast(new Kletterer("Ben"));
seilschaft.AddLast(new Kletterer("Cem"));
seilschaft.Umdrehen();
seilschaft.Print();     // Ausgabe: Anna
```
