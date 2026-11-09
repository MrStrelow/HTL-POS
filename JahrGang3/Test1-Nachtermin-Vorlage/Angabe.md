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

#### Aufgabe 01 - Herbstblätter im Teich - 45%

>🎬 Zu dieser Aufgabe gibt es eine Hilfe zum Durchklicken: ``Aufgabe1/Animated-Slides-Aufgabe1.html`` (im Browser öffnen, funktioniert ohne Internet).

Im Herbst fallen Blätter von einem Baum in einen Teich. Der Wind treibt sie zufällig über das Wasser. Sobald ein Blatt **seichtes Wasser** erreicht, verfängt es sich im Schilf und **bleibt für immer hängen**. Ein Blatt weiß nicht, wie der Teich aussieht – es fragt den Teich, ob es an eine bestimmte Stelle treiben darf.

##### Allgemeine Rahmenbedingungen der Simulation
* **Kartengröße:** Der Teich ist quadratisch und muss **mindestens 12 × 12 Felder** groß sein (falls beim Erstellen ein kleinerer Wert übergeben wird, wird die Größe automatisch auf 12 gesetzt). Er darf aber auch größer sein.
* **Gelände-Aufteilung:**
  * Der **Rand** des Teichs (erste und letzte Zeile, erste und letzte Spalte) ist seichtes Ufer (🟩), das Innere tiefes Wasser (🟦).
  * Zusätzlich sind **15 % der Gesamtfläche** seichtes Wasser (🟩) – nur auf Feldern, die vorher tiefes Wasser waren.
  * **10 % der Gesamtfläche** sind Steine (🪨) – ebenfalls nur auf tiefem Wasser.
* **Anzahl der Blätter:**
  * Es fallen genau **5 % der Gesamtfläche** (abgerundet auf ganze Zahlen, bei 12 × 12 also 7 Stück) an Blättern in den Teich.
* **Startpositionen:**
  * Die ersten drei Blätter fallen vom Baum in der Mitte des Teichs auf die Koordinaten *(y, x)* **(Groesse / 2, Groesse / 2)**, **(Groesse / 2 − 1, Groesse / 2)** und **(Groesse / 2, Groesse / 2 − 1)**. Alle weiteren Blätter erhalten eine zufällige Startposition.
* **Symbole:** treibendes Blatt 🍂, festhängendes Blatt 🍁.

##### Beschreibung der Klassen

##### 1. Klasse `Blatt`
* **Eigenschaften:**
  * **Teich:** Referenz auf den Teich, in dem das Blatt treibt (nur innerhalb der Klasse setzbar).
  * **Position:** Ein Tupel für Zeile und Spalte *(y, x)* (nur innerhalb der Klasse setzbar).
  * **HaengtFest:** Wahrheitswert, ob das Blatt im seichten Wasser festhängt (nur innerhalb der Klasse setzbar, am Anfang *falsch*).
* **Konstruktor:**
  * Nimmt die Referenz auf den **Teich** sowie ein Tupel für die **Startposition** entgegen, speichert beide und ruft sofort die eigene Methode **PlatziereBlatt** auf.
* **Methoden:**
  * **PlatziereBlatt:**
    * Versucht, das Blatt auf der Startposition ins Wasser fallen zu lassen. Dazu fragt es den Teich mit **IstPlatzierbar**.
    * **Falls das nicht möglich ist** (Stein, seichtes Wasser, schon ein Blatt oder außerhalb): Das Blatt wählt in einer Schleife solange zufällige neue Koordinaten *(y, x)* innerhalb der Teichgröße aus, bis **IstPlatzierbar** eine positive Rückmeldung liefert.
    * Die gefundene Koordinate wird in **Position** gespeichert.
  * **Treiben:**
    * Hängt das Blatt bereits fest, passiert **nichts** (es bleibt für immer hängen).
    * Sonst versucht das Blatt **höchstens 10-mal**, in eine zufällige Richtung zu treiben: *dy* und *dx* sind jeweils zufällig −1, 0 oder 1.
    * Ob es dorthin darf, entscheidet der **Teich** mit **KannTreiben(Position, ziel)**. Wenn nicht, folgt der nächste Versuch.
    * **Sobald ein Versuch klappt:**
      1. Das Blatt fragt den Teich mit **IstSeicht(ziel)**, ob das Ziel seichtes Wasser ist, und speichert das Ergebnis in **HaengtFest**.
      2. Der Teich versetzt das Blatt in seiner Karte mit **VersetzeBlatt(Position, ziel, HaengtFest)**.
      3. Das Blatt speichert das Ziel als neue **Position** und beendet die Methode.

##### 2. Klasse `Teich`
* **Felder & Eigenschaften:**
  * **Karte:** Ein **privates** zweidimensionales Text-Array für Zeilen und Spalten. Es darf von anderen Klassen **nicht** direkt gelesen oder verändert werden!
  * **Groesse:** Öffentlich lesbare Eigenschaft für die Seitenlänge des Teichs (nur intern setzbar).
  * **Blaetter:** Öffentlich lesbares 1D-Array aller Blätter (1-zu-*n* Beziehung, nur intern setzbar).
* **Konstruktor:**
  * Nimmt die gewünschte Seitenlänge als Parameter entgegen (mindestens 12).
  * Erstellt das 2D-Array **Karte**, befüllt den Rand mit 🟩 und das Innere mit 🟦.
  * Platziert anschließend auf **15 % der Felder** zusätzlich 🟩 und auf **10 % der Felder** 🪨 an zufälligen Feldern mit tiefem Wasser.
  * Berechnet die Anzahl der Blätter (**5 % der Gesamtfläche**), legt das 1D-Array **Blaetter** an und erzeugt die Blatt-Objekte (die ersten drei mit den Startpositionen in der Mitte, den Rest mit Zufallskoordinaten). Jedes Blatt muss **genau diesen** Teich kennen!
* **Methoden:**
  * **IstPlatzierbar:** Nimmt eine Position als Tupel *(y, x)* entgegen und gibt einen Wahrheitswert zurück. Prüft die Kartengrenzen und ob dort tiefes Wasser (🟦) ist. Ist das so, trägt die Methode ein treibendes Blatt (🍂) in die **Karte** ein und gibt *wahr* zurück.
  * **KannTreiben:** Nimmt die aktuelle Position *von* und die Zielposition *ziel* entgegen. Liefert *falsch*, wenn *ziel* gleich *von* ist, außerhalb liegt oder dort ein Stein (🪨) oder bereits ein Blatt (🍂 oder 🍁) ist. Sonst *wahr*.
  * **IstSeicht:** Liefert *wahr*, wenn die Position im Teich liegt und dort seichtes Wasser (🟩) ist.
  * **VersetzeBlatt:** Nimmt *von*, *ziel* und *haengtFest* entgegen. Auf *von* wird wieder tiefes Wasser (🟦) eingetragen, auf *ziel* ein festhängendes (🍁) oder treibendes (🍂) Blatt.
  * **Simuliere:** Nimmt eine Anzahl an Runden entgegen. In jeder Runde treibt **jedes** Blatt einmal.
  * **ZaehleHaengendeBlaetter:** Liefert die Anzahl der Blätter, die festhängen.
  * **Print:** Gibt die gesamte **Karte** zeilenweise in der Konsole aus.

##### 3. Hauptprogramm (`Program`)
* Stellt die Konsolenausgabe auf UTF-8 um, erstellt einen **Teich** (z. B. Größe 12) und gibt ihn mit **Print** aus.
* Simuliert 5 Runden und gibt den Teich sowie die Anzahl der festhängenden Blätter aus. Danach weitere 50 Runden, wieder mit Ausgabe.

---

##### 4. Erwartete Ausgabe
Durch Zufall nicht 1 zu 1 verwendbar.
```
Siehe HTML-Slide.
```

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
Analysiere folgenden Code. Die Methode **SetzeKapitaen** soll die Hat-Beziehung zwischen Schiff und Kapitän in **beide Richtungen** herstellen. Das Programm gibt aber `False` aus. Was fällt dir auf? Wie beheben wir den Fehler?

```csharp
public class Kapitaen
{
    public string Name { get; private set; }
    public Schiff Schiff { get; set; }

    public Kapitaen(string name)
    {
        Name = name;
    }
}

public class Schiff
{
    public string Name { get; private set; }
    public Kapitaen Kapitaen { get; private set; }

    public Schiff(string name)
    {
        Name = name;
    }

    public void SetzeKapitaen(Kapitaen kapitaen)
    {
        Kapitaen = kapitaen;
        kapitaen.Schiff = new Schiff(Name);
    }
}

// Program.cs
Schiff schiff = new Schiff("Donauwelle");
schiff.SetzeKapitaen(new Kapitaen("Nemo"));
Console.WriteLine(schiff.Kapitaen.Schiff == schiff);
```
