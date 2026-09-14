# Glossar

### Programm
Eine strukturierte Abfolge von Befehlen (z. B. in C#) zur Lösung einer Aufgabe. Ein Programm entsteht in einem [Projekt](#projekt) und startet am [Entry-Point](#entry-point).

### Microsoft-Azure
Microsofts Cloud-Plattform. Über den **Education**-Bereich erhalten Bildungseinrichtungen kostenlosen Zugang zu professioneller Entwicklungssoftware wie Visual Studio.

### Projekt
Ein Container in Visual Studio, der alle Dateien (Code, Konfigurationen) für ein [Programm](#programm) bündelt. Die Grundstruktur wird meist durch ein [Projekt-Template](#projekt-template) erstellt.

### Projekt-Template
Eine Vorlage (z. B. für eine [Console-App](#console-app)), die automatisch die nötige Ordnerstruktur und den Start-Code für ein neues [Projekt](#projekt) generiert.

### Console-App
Ein [Programm](#programm) ohne grafische Benutzeroberfläche. Es läuft textbasiert in einer [Console](#console) ab – ideal zum Erlernen der Programmiergrundlagen.

### Entry-Point
Der Einstiegspunkt, an dem die Ausführung eines [Programms](#programm) beginnt. In modernen C#-[Console-Apps](#console-app) oft durch kompakte "Top-Level Statements" umgesetzt.

### Hello-World-Programm
Das traditionell erste [Programm](#programm), das man schreibt. Es gibt lediglich Text in der [Console](#console) aus und beweist, dass das [Projekt](#projekt) fehlerfrei läuft.

### Debug
Der Prozess, Fehler (Bugs) in einem [Programm](#programm) zu finden und zu beheben. In Visual Studio lässt sich der Code dafür während der Ausführung anhalten und gezielt überprüfen.

### Console
Das Textfenster des Betriebssystems. Hier zeigt eine [Console-App](#console-app) ihre Ausgaben an und nimmt Tastatureingaben für das [Programm](#programm) entgegen.

### PoS
Programmieren und Software-Engineering. Das zentrale Fach, in dem wir die Grundlagen der Softwareentwicklung erlernen.

### Git
Ein Versionskontrollsystem, das Änderungen am Quellcode nachverfolgt. Es speichert den gesamten Verlauf eines [Projektes](#projekt) und ermöglicht es, jederzeit zu älteren Versionen zurückzukehren.

### GitHub
Die webbasierte Plattform, auf der unsere Git-Repositories gehostet werden. Später wird eigener Code dort gehostet und von uns als zentrales Tool verwendet. Am Beginn dient es als öffentliches Archiv für alle Skripten, Mitschriften und Code-Beispiele des Unterrichts.

### Branch
Ein separater Versionszweig in Git. In unserem Repository repräsentiert ein Branch den spezifischen Lernfortschritt und Materialstand einer einzelnen Schulklasse über alle Jahrgänge hinweg.

### Moodle
Unsere schulische Lernplattform. Dies ist der verbindliche Einstiegspunkt: Hier findest du alle aktuellen Links, die dich zielgenau zu den richtigen Aufgaben und Lektionen auf GitHub leiten.

### Jahrgang
Entspricht der Schulstufe (1 bis 5) an der HTL. Er strukturiert die Lerninhalte chronologisch nach dem jeweiligen Ausbildungsjahr.

### Lektion
Eine thematische Unterrichtseinheit innerhalb eines [Jahrgangs](#jahrgang). Sie umfasst das theoretische Skriptum, die [Angaben](#angabe--lösung) für Aufgaben sowie die dazugehörigen C#-[Projekte](#projekt).

### Projektmappe
*(Englisch: Solution, `.sln`)* Eine übergreifende Datei, die mehrere zusammengehörige C#-[Projekte](#projekt) bündelt. Ein Doppelklick darauf öffnet die gesamte [Lektion](#lektion) direkt in der [IDE](#ide).

### IDE
*(Integrated Development Environment)* Eine integrierte Entwicklungsumgebung wie [Visual Studio](#visual-studio) oder [Rider](#rider). Sie vereint alle wichtigen Werkzeuge – vom Code-Editor über den Compiler bis hin zur [Debug](#debug)-Konsole – in einem Programm.

### Visual Studio
Die umfangreiche, standardmäßige [IDE](#ide) von Microsoft für die Entwicklung mit C# und .NET, die wir primär im Unterricht einsetzen.

### Rider
Eine sehr leistungsstarke, plattformübergreifende C#-[IDE](#ide) von JetBrains, die als professionelle Alternative zu Visual Studio genutzt werden kann.

### Live-Coding
Programmcode und [Projekte](#projekt), die wir interaktiv und Schritt für Schritt gemeinsam im Unterricht erarbeiten. Sie dienen dem aktiven Verständnis und sind separat von den zu absolvierenden Aufgaben gespeichert.

### Angabe / Lösung
Die textliche Beschreibung (meist als Markdown) einer zu lösenden Programmieraufgabe innerhalb einer [Lektion](#lektion). Die dazugehörige Lösung wird oftmals als separates C#-[Projekt](#projekt) bereitgestellt.

### Solution
Der englische Begriff für [Projektmappe](#projektmappe). In der Benutzeroberfläche von Visual Studio wird dieser Begriff standardmäßig verwendet (z. B. "Blank Solution"), weshalb die dazugehörige Datei auch die Endung [.sln](#sln) trägt.

### Solution Explorer
*(Auf Deutsch: Projektmappen-Explorer)*. Ein zentrales Fenster in Visual Studio, das die Struktur deiner [Projektmappe](#projektmappe) und aller darin enthaltenen [Projekte](#projekt) sowie Dateien übersichtlich als Baumstruktur darstellt.

### csproj
Die Dateiendung (`.csproj`) für ein C#-[Projekt](#projekt) (C-Sharp Project). Diese Datei speichert alle wichtigen Einstellungen, Konfigurationen und Verweise, die zu diesem spezifischen Projekt gehören.

### sln
Die Dateiendung (`.sln`) für eine [Solution](#solution) bzw. [Projektmappe](#projektmappe). Diese Datei merkt sich, welche [Projekte](#projekt) zu dieser Mappe gehören und wo diese auf der Festplatte liegen.

### Runtime
*(Laufzeitumgebung)*. Die notwendige Software im Hintergrund, um ein [Programm](#programm) überhaupt auszuführen. Sie agiert als Übersetzer zwischen deinem C#-Code und dem Computer: Die .NET Runtime wandelt den Code beim Start in Maschinensprache um, verwaltet automatisch den Arbeitsspeicher und kommuniziert mit dem Betriebssystem. Ohne die passend installierte Version (z. B. `.NET 10.0 Runtime`) kann dein Programm nicht gestartet werden.

### slnx / sln
Die Dateiendung (`.slnx` oder älter `.sln`) für eine [Solution](#solution) bzw. [Projektmappe](#projektmappe). Diese Datei merkt sich, welche [Projekte](#projekt) zu dieser Mappe gehören und wo diese auf der Festplatte liegen. Das neuere `.slnx`-Format nutzt dabei eine wesentlich simplere und übersichtlichere XML-Struktur.

### Array
Eine Datenstruktur, die eine feste Anzahl von Elementen desselben Datentyps speichert. Man greift auf die einzelnen Elemente über ihren jeweiligen [``Index``](#index) zu.

### 2D-Array
Ein [``Array``](#array) mit zwei Dimensionen (Zeilen und Spalten), das man sich wie ein Schachbrett, ein Spielfeld oder eine Tabelle vorstellen kann. In C# wird es mit einem Komma in der eckigen Klammer (`[,]`) deklariert.

### Index
Die numerische Position eines Elements innerhalb eines [``Arrays``](#array). In C# (und den meisten anderen Programmiersprachen) gilt die strikte **Nullindizierung**. Das bedeutet, das allererste Element liegt immer am Index 0, das zweite am Index 1, und so weiter. 

### Zuweisung
Der Vorgang, bei dem einer Variablen oder einem bestimmten Speicherplatz in einem [``Array``](#array) ein neuer Wert zugewiesen wird. In C# geschieht dies mit dem Zuweisungsoperator `=`.

### Zählschleife
Eine Kontrollstruktur, die einen Codeblock so oft wiederholt, wie es durch einen Zähler vorgegeben ist. Die häufigste Form in C# ist die [``for-Schleife``](#for-schleife).

### for-Schleife
Eine spezifische, sehr kompakte Form der [``Zählschleife``](#zählschleife). Sie vereint die Initialisierung (z. B. `int i = 0`), die Abbruchbedingung (`i < Size`) und die Erhöhung des Zählers (`i++`) übersichtlich in einer einzigen Zeile.

### Verschachtelte Schleifen
Schleifen, die sich innerhalb des Codeblocks einer anderen Schleife befinden (ein Loop in einem Loop). Sie sind zwingend notwendig, um mehrdimensionale Strukturen wie ein [``2D-Array``](#2d-array) iterativ, also Feld für Feld (Zeile für Zeile, Spalte für Spalte), zu durchlaufen.

### Typ
*(Datentyp)* Legt fest, welche Art von Daten eine [``Variable``](#variable) speichern kann (z. B. `int` für Ganzzahlen, `string` für Text).

### Zuweisungsoperator
Das Gleichheitszeichen (`=`) in C#. Es nimmt den Wert auf der rechten Seite und speichert ihn in der Variable oder dem [``Array``](#array)-Index auf der linken Seite.

### Element
Ein einzelner Datenpunkt (z. B. eine einzelne Zahl oder ein einzelner Text) innerhalb einer übergeordneten Datenstruktur wie einem [``Array``](#array).

### Dimension
Die Ausdehnung eines Arrays. Ein 1D-Array hat eine Dimension (eine simple Liste). Ein 2D-Array hat zwei Dimensionen (Tabelle/Gitter mit X und Y).

### Verweistypen
*(Reference Types)* Datentypen, bei denen die Variable nicht den eigentlichen Wert speichert, sondern nur die Speicheradresse ([``Referenz``](#referenz)), wo die Daten im Arbeitsspeicher liegen. Arrays und Klassen sind Verweistypen.

### Referenz
Eine Speicheradresse, die wie ein Wegweiser auf den tatsächlichen Ort der Daten im [``Heap``](#heap) zeigt.

### Heap
Der große, flexible Teil des Arbeitsspeichers, in dem komplexe Datenstrukturen wie [``Arrays``](#array) und Objekte (Verweistypen) gespeichert werden, da ihre Größe oft variabel ist oder sie viel Platz benötigen.

### Stack
Der schnelle, strikt geordnete Teil des Arbeitsspeichers. Hier werden einfache Wertetypen (wie `int`) und die [``Referenzen``](#referenz) (die Wegweiser) zu den Daten im [``Heap``](#heap) gespeichert.

### Parameter
Die Eingabewerte, die einer [``Methode``](#methode) in den runden Klammern übergeben werden, damit sie mit diesen Daten arbeiten kann.

### Methode
Ein benannter, wiederverwendbarer Codeblock, der eine spezifische Aufgabe ausführt. Methoden strukturieren das Programm und verhindern, dass Code mehrfach geschrieben werden muss.

### Seiteneffekt
*(Side Effect)* Wenn eine Funktion oder [``Methode``](#methode) nicht nur einen Wert zurückgibt, sondern "heimlich" den Zustand des Programms verändert (z. B. indem sie ein übergebenes [``Array``](#array) verändert oder Text in die Console schreibt).

### Variable
Ein benannter Speicherplatz im Arbeitsspeicher, der einen bestimmten Datentyp und einen [``Wert``](#wert) enthält.

### Wert
Die konkreten Daten (z. B. die Zahl `15` oder der Text `"Anna"`), die in einer [``Variablen``](#variable) oder einem Array-[``Element``](#element) gespeichert sind. Wir halten es hier absichtlich "einfach" und gehen nicht direkt auf ``Referenz`` und ``Werte`` ein.

### Assoziation
Eine Assoziation (oft als "Hat-Beziehung" bezeichnet) ist eine Verbindung zwischen zwei Klassen. Sie drückt aus, dass ein Objekt einer Klasse ein Objekt der anderen Klasse kennt und Aufgaben an dieses delegieren kann.

### Backing Field
Ein privates Feld in einer Klasse, das exklusiv dazu dient, den tatsächlichen Wert für eine `Property` (Eigenschaft) im Hintergrund zu speichern.

### Copy-Konstruktor
Ein spezieller Konstruktor, der als einzigen Parameter ein bereits existierendes Objekt derselben Klasse übergeben bekommt. Seine Aufgabe ist es, die Werte dieses Objekts in das neu zu erstellende Objekt zu kopieren.

### Data Hiding
Das Konzept des "Versteckens" von internen Zuständen (Feldern) einer Klasse, typischerweise durch den Modifizierer `private`. Es verhindert, dass andere Klassen unkontrolliert auf die Daten zugreifen.

### Datenabstraktion
Das Resultat aus Data Hiding und Kapselung. Nach außen wird nur eine vereinfachte Schnittstelle angeboten (*was* das Objekt kann), während die komplexe interne Implementierung (*wie* es das tut) verborgen bleibt.

### Eigenschaft
*(Engl.: Property)* Eine Eigenschaft wirkt nach außen wie eine normale Variable, ist intern aber eine Kombination aus Methoden (`get` für das Lesen, `set` für das Schreiben), um den Zugriff auf Daten zu kontrollieren.

### Feld
Eine Variable, die direkt in einer Klasse deklariert wird und den inneren Zustand eines Objekts speichert. Felder sollten in der Regel `private` sein.

### field-Keyword
Ein Schlüsselwort (eingeführt mit C# 13 / .NET 10), das es erlaubt, innerhalb der `get`/`set`-Zugriffsfunktionen einer Eigenschaft direkt auf das vom Compiler automatisch generierte Backing Field zuzugreifen, ohne dieses vorher manuell als `private`-Feld anlegen zu müssen.

### Kapselung
*(Engl.: Encapsulation)* Das Bündeln von Daten (Feldern) und den darauf arbeitenden Funktionen (Methoden) in einer Einheit (der Klasse), gepaart mit der strikten Kontrolle, wer über Properties oder Methoden auf diese Daten zugreifen darf.

### Klasse
Der theoretische Bauplan (die Vorlage) für Objekte. Sie definiert, welche Eigenschaften und Methoden die später aus ihr erstellten Objekte haben werden.

### Klassenebene
Bezieht sich auf die theoretische Struktur des Codes (den Bauplan). Eine Beziehung auf Klassenebene bedeutet, dass die Klassen im Code so geschrieben sind, dass sie sich potenziell referenzieren können (z.B. durch ein Feld des jeweils anderen Typs).

### Kopplung
*(Engl.: Coupling)* Beschreibt den Grad der Abhängigkeit zwischen verschiedenen Modulen oder Klassen. Ein gutes Softwaredesign strebt eine **lose/niedrige Kopplung** an, damit Änderungen in einer Klasse nicht unzählige andere Klassen kaputt machen.

### Mitglied
*(Engl.: Member)* Ein Überbegriff für alle Bestandteile, die direkt zu einer Klasse gehören, primär Felder, Eigenschaften, Konstruktoren und Methoden.

### Konstruktor
Eine spezielle Methode einer Klasse, die exakt so heißt wie die Klasse selbst und keinen Rückgabetyp hat. Sie wird beim Erstellen des Objekts mit dem `new`-Operator automatisch aufgerufen, um den Startzustand einzurichten.

### Multiplizität
Gibt im UML-Klassendiagramm an den Enden einer Assoziation an, wie viele Objekte der Zielklasse mit einem Objekt der Ausgangsklasse in Verbindung stehen dürfen (z.B. `1`, `0..1`, `0..*`).

### Navigierbarkeit
Gibt bei einer Assoziation an, in welche Richtung kommuniziert wird.
* **Unidirektional:** Objekt A kennt Objekt B, aber B kennt A nicht.
* **Bidirektional:** Objekt A und Objekt B haben jeweils eine Referenz aufeinander und können in beide Richtungen kommunizieren.

### Objekt
Die konkrete Ausprägung (Instanz) einer Klasse zur Laufzeit des Programms. Es belegt Platz im Arbeitsspeicher und enthält konkrete Werte in seinen Feldern.

### Objektebene
Bezieht sich auf den tatsächlichen Zustand im Arbeitsspeicher zur Laufzeit des Programms (im Gegensatz zur theoretischen Klassenebene).

### Property-Arten
* **Full Property:** Die Eigenschaft greift auf ein manuell geschriebenes, privates Backing Field zu.
* **Auto Property:** Der Code besteht nur aus `{ get; set; }`. Der Compiler generiert das Backing Field im Hintergrund selbst.

### Sichtbarkeitsmodifizierer
Schlüsselwörter, die den Zugriff auf Klassen und deren Mitglieder regeln:
* `public`: Von überall im Projekt sichtbar.
* `private`: Nur innerhalb der exakt gleichen Klasse sichtbar.
* `protected`: Sichtbar in der eigenen Klasse und in allen Klassen, die von dieser erben.

### Zusammenhalt
*(Engl.: Cohesion)* Beschreibt, wie stark die Mitglieder innerhalb *einer einzigen* Klasse funktional zusammengehören. Ein gutes Softwaredesign strebt einen **starken/hohen Zusammenhalt** an, bei dem eine Klasse genau eine klar definierte Aufgabe erfüllt (Single Responsibility).

### Zustand
Die Gesamtheit aller aktuellen Werte, die in den Feldern und Eigenschaften eines konkreten Objekts zu einem bestimmten Zeitpunkt im Arbeitsspeicher gespeichert sind.