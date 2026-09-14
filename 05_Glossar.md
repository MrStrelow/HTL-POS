# Glossar

## Programm
Eine strukturierte Abfolge von Befehlen (z. B. in C#) zur Lösung einer Aufgabe. Ein Programm entsteht in einem [Projekt](#projekt) und startet am [Entry-Point](#entry-point).

## Microsoft-Azure
Microsofts Cloud-Plattform. Über den **Education**-Bereich erhalten Bildungseinrichtungen kostenlosen Zugang zu professioneller Entwicklungssoftware wie Visual Studio.

## Projekt
Ein Container in Visual Studio, der alle Dateien (Code, Konfigurationen) für ein [Programm](#programm) bündelt. Die Grundstruktur wird meist durch ein [Projekt-Template](#projekt-template) erstellt.

## Projekt-Template
Eine Vorlage (z. B. für eine [Console-App](#console-app)), die automatisch die nötige Ordnerstruktur und den Start-Code für ein neues [Projekt](#projekt) generiert.

## Console-App
Ein [Programm](#programm) ohne grafische Benutzeroberfläche. Es läuft textbasiert in einer [Console](#console) ab – ideal zum Erlernen der Programmiergrundlagen.

## Entry-Point
Der Einstiegspunkt, an dem die Ausführung eines [Programms](#programm) beginnt. In modernen C#-[Console-Apps](#console-app) oft durch kompakte "Top-Level Statements" umgesetzt.

## Hello-World-Programm
Das traditionell erste [Programm](#programm), das man schreibt. Es gibt lediglich Text in der [Console](#console) aus und beweist, dass das [Projekt](#projekt) fehlerfrei läuft.

## Debug
Der Prozess, Fehler (Bugs) in einem [Programm](#programm) zu finden und zu beheben. In Visual Studio lässt sich der Code dafür während der Ausführung anhalten und gezielt überprüfen.

## Console
Das Textfenster des Betriebssystems. Hier zeigt eine [Console-App](#console-app) ihre Ausgaben an und nimmt Tastatureingaben für das [Programm](#programm) entgegen.

## PoS
Programmieren und Software-Engineering. Das zentrale Fach, in dem wir die Grundlagen der Softwareentwicklung erlernen.

## Git
Ein Versionskontrollsystem, das Änderungen am Quellcode nachverfolgt. Es speichert den gesamten Verlauf eines [Projektes](#projekt) und ermöglicht es, jederzeit zu älteren Versionen zurückzukehren.

## GitHub
Die webbasierte Plattform, auf der unsere Git-Repositories gehostet werden. Später wird eigener Code dort gehostet und von uns als zentrales Tool verwendet. Am Beginn dient es als öffentliches Archiv für alle Skripten, Mitschriften und Code-Beispiele des Unterrichts.

## Branch
Ein separater Versionszweig in Git. In unserem Repository repräsentiert ein Branch den spezifischen Lernfortschritt und Materialstand einer einzelnen Schulklasse über alle Jahrgänge hinweg.

## Moodle
Unsere schulische Lernplattform. Dies ist der verbindliche Einstiegspunkt: Hier findest du alle aktuellen Links, die dich zielgenau zu den richtigen Aufgaben und Lektionen auf GitHub leiten.

## Jahrgang
Entspricht der Schulstufe (1 bis 5) an der HTL. Er strukturiert die Lerninhalte chronologisch nach dem jeweiligen Ausbildungsjahr.

## Lektion
Eine thematische Unterrichtseinheit innerhalb eines [Jahrgangs](#jahrgang). Sie umfasst das theoretische Skriptum, die [Angaben](#angabe--lösung) für Aufgaben sowie die dazugehörigen C#-[Projekte](#projekt).

## Projektmappe
*(Englisch: Solution, `.sln`)* Eine übergreifende Datei, die mehrere zusammengehörige C#-[Projekte](#projekt) bündelt. Ein Doppelklick darauf öffnet die gesamte [Lektion](#lektion) direkt in der [IDE](#ide).

## IDE
*(Integrated Development Environment)* Eine integrierte Entwicklungsumgebung wie [Visual Studio](#visual-studio) oder [Rider](#rider). Sie vereint alle wichtigen Werkzeuge – vom Code-Editor über den Compiler bis hin zur [Debug](#debug)-Konsole – in einem Programm.

## Visual Studio
Die umfangreiche, standardmäßige [IDE](#ide) von Microsoft für die Entwicklung mit C# und .NET, die wir primär im Unterricht einsetzen.

## Rider
Eine sehr leistungsstarke, plattformübergreifende C#-[IDE](#ide) von JetBrains, die als professionelle Alternative zu Visual Studio genutzt werden kann.

## Live-Coding
Programmcode und [Projekte](#projekt), die wir interaktiv und Schritt für Schritt gemeinsam im Unterricht erarbeiten. Sie dienen dem aktiven Verständnis und sind separat von den zu absolvierenden Aufgaben gespeichert.

## Angabe / Lösung
Die textliche Beschreibung (meist als Markdown) einer zu lösenden Programmieraufgabe innerhalb einer [Lektion](#lektion). Die dazugehörige Lösung wird oftmals als separates C#-[Projekt](#projekt) bereitgestellt.

## Solution
Der englische Begriff für [Projektmappe](#projektmappe). In der Benutzeroberfläche von Visual Studio wird dieser Begriff standardmäßig verwendet (z. B. "Blank Solution"), weshalb die dazugehörige Datei auch die Endung [.sln](#sln) trägt.

## Solution Explorer
*(Auf Deutsch: Projektmappen-Explorer)*. Ein zentrales Fenster in Visual Studio, das die Struktur deiner [Projektmappe](#projektmappe) und aller darin enthaltenen [Projekte](#projekt) sowie Dateien übersichtlich als Baumstruktur darstellt.

## csproj
Die Dateiendung (`.csproj`) für ein C#-[Projekt](#projekt) (C-Sharp Project). Diese Datei speichert alle wichtigen Einstellungen, Konfigurationen und Verweise, die zu diesem spezifischen Projekt gehören.

## sln
Die Dateiendung (`.sln`) für eine [Solution](#solution) bzw. [Projektmappe](#projektmappe). Diese Datei merkt sich, welche [Projekte](#projekt) zu dieser Mappe gehören und wo diese auf der Festplatte liegen.

## Runtime
*(Laufzeitumgebung)*. Die notwendige Software im Hintergrund, um ein [Programm](#programm) überhaupt auszuführen. Sie agiert als Übersetzer zwischen deinem C#-Code und dem Computer: Die .NET Runtime wandelt den Code beim Start in Maschinensprache um, verwaltet automatisch den Arbeitsspeicher und kommuniziert mit dem Betriebssystem. Ohne die passend installierte Version (z. B. `.NET 10.0 Runtime`) kann dein Programm nicht gestartet werden.

## slnx / sln
Die Dateiendung (`.slnx` oder älter `.sln`) für eine [Solution](#solution) bzw. [Projektmappe](#projektmappe). Diese Datei merkt sich, welche [Projekte](#projekt) zu dieser Mappe gehören und wo diese auf der Festplatte liegen. Das neuere `.slnx`-Format nutzt dabei eine wesentlich simplere und übersichtlichere XML-Struktur.

## Array
Eine Datenstruktur, die eine feste Anzahl von Elementen desselben Datentyps speichert. Man greift auf die einzelnen Elemente über ihren jeweiligen [``Index``](#index) zu.

## 2D-Array
Ein [``Array``](#array) mit zwei Dimensionen (Zeilen und Spalten), das man sich wie ein Schachbrett, ein Spielfeld oder eine Tabelle vorstellen kann. In C# wird es mit einem Komma in der eckigen Klammer (`[,]`) deklariert.

## Index
Die numerische Position eines Elements innerhalb eines [``Arrays``](#array). In C# (und den meisten anderen Programmiersprachen) gilt die strikte **Nullindizierung**. Das bedeutet, das allererste Element liegt immer am Index 0, das zweite am Index 1, und so weiter. 

## Zuweisung
Der Vorgang, bei dem einer Variablen oder einem bestimmten Speicherplatz in einem [``Array``](#array) ein neuer Wert zugewiesen wird. In C# geschieht dies mit dem Zuweisungsoperator `=`.

## Zählschleife
Eine Kontrollstruktur, die einen Codeblock so oft wiederholt, wie es durch einen Zähler vorgegeben ist. Die häufigste Form in C# ist die [``for-Schleife``](#for-schleife).

## for-Schleife
Eine spezifische, sehr kompakte Form der [``Zählschleife``](#zählschleife). Sie vereint die Initialisierung (z. B. `int i = 0`), die Abbruchbedingung (`i < Size`) und die Erhöhung des Zählers (`i++`) übersichtlich in einer einzigen Zeile.

## Verschachtelte Schleifen
Schleifen, die sich innerhalb des Codeblocks einer anderen Schleife befinden (ein Loop in einem Loop). Sie sind zwingend notwendig, um mehrdimensionale Strukturen wie ein [``2D-Array``](#2d-array) iterativ, also Feld für Feld (Zeile für Zeile, Spalte für Spalte), zu durchlaufen.

## Typ
*(Datentyp)* Legt fest, welche Art von Daten eine [``Variable``](#variable) speichern kann (z. B. `int` für Ganzzahlen, `string` für Text).

## Zuweisungsoperator
Das Gleichheitszeichen (`=`) in C#. Es nimmt den Wert auf der rechten Seite und speichert ihn in der Variable oder dem [``Array``](#array)-Index auf der linken Seite.

## Element
Ein einzelner Datenpunkt (z. B. eine einzelne Zahl oder ein einzelner Text) innerhalb einer übergeordneten Datenstruktur wie einem [``Array``](#array).

## Dimension
Die Ausdehnung eines Arrays. Ein 1D-Array hat eine Dimension (eine simple Liste). Ein 2D-Array hat zwei Dimensionen (Tabelle/Gitter mit X und Y).

## Verweistypen
*(Reference Types)* Datentypen, bei denen die Variable nicht den eigentlichen Wert speichert, sondern nur die Speicheradresse ([``Referenz``](#referenz)), wo die Daten im Arbeitsspeicher liegen. Arrays und Klassen sind Verweistypen.

## Referenz
Eine Speicheradresse, die wie ein Wegweiser auf den tatsächlichen Ort der Daten im [``Heap``](#heap) zeigt.

## Heap
Der große, flexible Teil des Arbeitsspeichers, in dem komplexe Datenstrukturen wie [``Arrays``](#array) und Objekte (Verweistypen) gespeichert werden, da ihre Größe oft variabel ist oder sie viel Platz benötigen.

## Stack
Der schnelle, strikt geordnete Teil des Arbeitsspeichers. Hier werden einfache Wertetypen (wie `int`) und die [``Referenzen``](#referenz) (die Wegweiser) zu den Daten im [``Heap``](#heap) gespeichert.

## Parameter
Die Eingabewerte, die einer [``Methode``](#methode) in den runden Klammern übergeben werden, damit sie mit diesen Daten arbeiten kann.

## Methode
Ein benannter, wiederverwendbarer Codeblock, der eine spezifische Aufgabe ausführt. Methoden strukturieren das Programm und verhindern, dass Code mehrfach geschrieben werden muss.

## Seiteneffekt
*(Side Effect)* Wenn eine Funktion oder [``Methode``](#methode) nicht nur einen Wert zurückgibt, sondern "heimlich" den Zustand des Programms verändert (z. B. indem sie ein übergebenes [``Array``](#array) verändert oder Text in die Console schreibt).

## Variable
Ein benannter Speicherplatz im Arbeitsspeicher, der einen bestimmten Datentyp und einen [``Wert``](#wert) enthält.

## Wert
Die konkreten Daten (z. B. die Zahl `15` oder der Text `"Anna"`), die in einer [``Variablen``](#variable) oder einem Array-[``Element``](#element) gespeichert sind. Wir halten es hier absichtlich "einfach" und gehen nicht direkt auf ``Referenz`` und ``Werte`` ein.