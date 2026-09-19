# Glossar

### 2D-Array
Ein [``Array``](#array) mit zwei Dimensionen (Zeilen und Spalten), das man sich wie ein Schachbrett, ein Spielfeld oder eine Tabelle vorstellen kann. In C# wird es mit einem Komma in der eckigen Klammer (`[,]`) deklariert.

### Angabe / Lösung
Die textliche Beschreibung (meist als Markdown) einer zu lösenden Programmieraufgabe innerhalb einer [``Lektion``](#lektion). Die dazugehörige Lösung wird oftmals als separates C#-[``Projekt``](#projekt) bereitgestellt.

### Arithmetische Operatoren
Operatoren, die grundlegende mathematische Berechnungen ausführen, wie Addition (`+`), Subtraktion (`-`), Multiplikation (`*`), Division (`/`) und Modulo (`%`).

### Array
Eine Datenstruktur, die eine feste Anzahl von Elementen desselben Datentyps speichert. Man greift auf die einzelnen Elemente über ihren jeweiligen [``Index``](#index) zu.

### Assoziation
Eine Assoziation (oft als "Hat-Beziehung" bezeichnet) ist eine Verbindung zwischen zwei Klassen. Sie drückt aus, dass ein [``Objekt``](#objekt) einer [``Klasse``](#klasse) ein Objekt der anderen Klasse kennt und Aufgaben an dieses delegieren kann.

### Auswertungsreihenfolge
Legt fest, in welcher zeitlichen Reihenfolge Code-Teile (wie z. B. die Bedingung einer [``Schleife``](#schleife) und deren auszuführender Code-Block) vom Programm überprüft und ausgeführt werden (z. B. kopfgesteuert vs. fußgesteuert).

### Backing Field
Ein privates [``Feld``](#feld) in einer [``Klasse``](#klasse), das exklusiv dazu dient, den tatsächlichen [``Wert``](#wert) für eine [``Eigenschaft``](#eigenschaft) (Property) im Hintergrund zu speichern.

### Bedingte Anweisung
Eine Kontrollstruktur (wie `if` ohne `else`), bei der ein Codeblock nur dann ausgeführt wird, wenn eine spezifische Bedingung wahr (`true`) ist. Andernfalls läuft das Programm ohne weitere Aktion weiter.

### Binärer Operator
Ein [``Operator``](#operator), der genau zwei Operanden benötigt, um eine Operation auszuführen (z. B. `a + b` oder `x == y`).

### Bitweise Operatoren
Operatoren, die direkt auf der binären Ebene der [``Typen``](#typ) arbeiten (Bit für Bit), z. B. AND (`&`), OR (`|`), XOR (`^`) und Bit-Shifts (`<<`, `>>`).

### Branch
Ein separater Versionszweig in [``Git``](#git). In unserem Repository repräsentiert ein Branch den spezifischen Lernfortschritt und Materialstand einer einzelnen Schulklasse über alle Jahrgänge hinweg.

### break
Ein [``Schlüsselwort``](#schlüsselwort), das verwendet wird, um eine [``Schleife``](#schleife) oder eine [``Switch-Anweisung``](#switch-anweisung) sofort und endgültig abzubrechen.

### Compiler
Ein Programm, das den von Menschen geschriebenen Quellcode (C#) in eine maschinenlesbare Sprache übersetzt, damit er ausgeführt werden kann.

### Console
Das Textfenster des Betriebssystems. Hier zeigt eine [``Console-App``](#console-app) ihre Ausgaben an und nimmt Tastatureingaben für das [``Programm``](#programm) entgegen.

### Console-App
Ein [``Programm``](#programm) ohne grafische Benutzeroberfläche. Es läuft textbasiert in einer [``Console``](#console) ab – ideal zum Erlernen der Programmiergrundlagen.

### continue
Ein [``Schlüsselwort``](#schlüsselwort), das den aktuellen Durchlauf einer [``Schleife``](#schleife) vorzeitig beendet und sofort mit dem nächsten Durchlauf (bzw. der erneuten Prüfung der Bedingung) fortfährt.

### Copy-Konstruktor
Ein spezieller [``Konstruktor``](#konstruktor), der als einzigen [``Parameter``](#parameter) ein bereits existierendes [``Objekt``](#objekt) derselben [``Klasse``](#klasse) übergeben bekommt. Seine Aufgabe ist es, die Werte dieses Objekts in das neu zu erstellende Objekt zu kopieren.

### csproj
Die Dateiendung (`.csproj`) für ein C#-[``Projekt``](#projekt) (C-Sharp Project). Diese Datei speichert alle wichtigen Einstellungen, Konfigurationen und Verweise, die zu diesem spezifischen Projekt gehören.

### Data Hiding
Das Konzept des "Versteckens" von internen Zuständen (Feldern) einer [``Klasse``](#klasse), typischerweise durch den Modifizierer `private`. Es verhindert, dass andere Klassen unkontrolliert auf die Daten zugreifen.

### Datenabstraktion
Das Resultat aus [``Data Hiding``](#data-hiding) und [``Kapselung``](#kapselung). Nach außen wird nur eine vereinfachte Schnittstelle angeboten (*was* das [``Objekt``](#objekt) kann), während die komplexe interne Implementierung (*wie* es das tut) verborgen bleibt.

### Debug
Der Prozess, Fehler (Bugs) in einem [``Programm``](#programm) zu finden und zu beheben. In der [``IDE``](#ide) lässt sich der Code dafür während der Ausführung anhalten und gezielt überprüfen.

### Dekrement
Die Verringerung eines numerischen Wertes um genau eins, typischerweise durchgeführt mit dem Operator `--`.

### Dimension
Die Ausdehnung eines [``Arrays``](#array). Ein 1D-Array hat eine Dimension (eine simple Liste). Ein [``2D-Array``](#2d-array) hat zwei Dimensionen (Tabelle/Gitter mit X und Y).

### Do-While-Schleife
Eine fußgesteuerte [``Schleife``](#schleife), bei der der Code-Block garantiert mindestens einmal ausgeführt wird, bevor die Bedingung ganz am Ende überprüft wird.

### Eigenschaft
*(Engl.: Property)* Eine Eigenschaft wirkt nach außen wie eine normale [``Variable``](#variable), ist intern aber eine Kombination aus Methoden (`get` für das Lesen, `set` für das Schreiben), um den Zugriff auf Daten zu kontrollieren.

### Element
Ein einzelner Datenpunkt (z. B. eine einzelne Zahl oder ein einzelner Text) innerhalb einer übergeordneten Datenstruktur wie einem [``Array``](#array).

### Entry-Point
Der Einstiegspunkt, an dem die Ausführung eines [``Programms``](#programm) beginnt. In modernen C#-[``Console-Apps``](#console-app) oft durch kompakte [``Top-Level Statements``](#top-level-statement) umgesetzt.

### Feld
Eine [``Variable``](#variable), die direkt in einer [``Klasse``](#klasse) deklariert wird und den inneren [``Zustand``](#zustand) eines Objekts speichert. Felder sollten in der Regel `private` sein.

### field-Keyword
Ein [``Schlüsselwort``](#schlüsselwort) (eingeführt mit C# 13 / .NET 10), das es erlaubt, innerhalb der `get`/`set`-Zugriffsfunktionen einer [``Eigenschaft``](#eigenschaft) direkt auf das automatisch generierte [``Backing Field``](#backing-field) zuzugreifen, ohne dieses vorher manuell als `private`-Feld anlegen zu müssen.

### For-Schleife
Eine sehr kompakte Schleifenart, bei der Initialisierung der [``Zählvariable``](#zählvariable), die Bedingung und das Inkrement übersichtlich im Schleifenkopf gebündelt sind. Ideal für eine vorher bekannte, endliche Anzahl an Wiederholungen.

### Git
Ein Versionskontrollsystem, das Änderungen am Quellcode nachverfolgt. Es speichert den gesamten Verlauf eines [``Projektes``](#projekt) und ermöglicht es, jederzeit zu älteren Versionen zurückzukehren.

### GitHub
Die webbasierte Plattform, auf der unsere [``Git``](#git)-Repositories gehostet werden. Es dient im Unterricht als öffentliches Archiv für alle Skripten, Mitschriften und Code-Beispiele.

### Heap
Der große, flexible Teil des Arbeitsspeichers, in dem komplexe Datenstrukturen wie [``Arrays``](#array) und Objekte ([``Verweistypen``](#verweistypen)) gespeichert werden, da ihre Größe oft variabel ist oder sie viel Platz benötigen.

### Hello-World-Programm
Das traditionell erste [``Programm``](#programm), das man schreibt. Es gibt lediglich Text in der [``Console``](#console) aus und beweist, dass das [``Projekt``](#projekt) fehlerfrei läuft.

### IDE
*(Integrated Development Environment)* Eine integrierte Entwicklungsumgebung wie [``Visual Studio``](#visual-studio) oder [``Rider``](#rider). Sie vereint alle wichtigen Werkzeuge – vom Code-Editor über den [``Compiler``](#compiler) bis hin zur [``Debug``](#debug)-Konsole – in einem Programm.

### Index
Die numerische Position eines Elements innerhalb eines [``Arrays``](#array). In C# (und den meisten anderen Programmiersprachen) gilt die strikte **Nullindizierung**. Das erste Element liegt am Index 0.

### Inkrement
Die Erhöhung eines numerischen Wertes um genau eins, typischerweise durchgeführt mit dem Operator `++`.

### Instanziierung
Der Prozess, bei dem aus einer [``Klasse``](#klasse) (dem Bauplan) ein konkretes [``Objekt``](#objekt) im Arbeitsspeicher (unter Verwendung des [``Schlüsselworts``](#schlüsselwort) `new`) erzeugt wird.

### Jahrgang
Entspricht der Schulstufe (1 bis 5) an der HTL. Er strukturiert die Lerninhalte chronologisch nach dem jeweiligen Ausbildungsjahr.

### Kapselung
*(Engl.: Encapsulation)* Das Bündeln von Daten (Feldern) und den darauf arbeitenden Funktionen (Methoden) in einer Einheit (der [``Klasse``](#klasse)), gepaart mit der strikten Kontrolle, wer über Eigenschaften oder Methoden auf diese Daten zugreifen darf.

### Klasse
Der theoretische Bauplan (die Vorlage) für [``Objekte``](#objekt). Sie definiert, welche Eigenschaften und Methoden die später aus ihr erstellten Objekte haben werden.

### Klassenebene
Bezieht sich auf die theoretische Struktur des Codes (den Bauplan). Eine Beziehung auf Klassenebene bedeutet, dass die [``Klassen``](#klasse) im Code so geschrieben sind, dass sie sich potenziell referenzieren können.

### Konstruktor
Eine spezielle [``Methode``](#methode) einer Klasse, die exakt so heißt wie die [``Klasse``](#klasse) selbst und keinen Rückgabetyp hat. Sie wird bei der [``Instanziierung``](#instanziierung) des Objekts automatisch aufgerufen.

### Kopplung
*(Engl.: Coupling)* Beschreibt den Grad der Abhängigkeit zwischen verschiedenen Modulen oder Klassen. Ein gutes Softwaredesign strebt eine **lose/niedrige Kopplung** an, damit Änderungen nicht alles kaputt machen.

### Lektion
Eine thematische Unterrichtseinheit innerhalb eines [``Jahrgangs``](#jahrgang). Sie umfasst das theoretische Skriptum, die [``Angaben``](#angabe--lösung) für Aufgaben sowie die dazugehörigen C#-[``Projekte``](#projekt).

### Live-Coding
Programmcode und [``Projekte``](#projekt), die wir interaktiv und Schritt für Schritt gemeinsam im Unterricht erarbeiten. Sie dienen dem aktiven Verständnis.

### Logische Operatoren
Operatoren (wie `&&` für UND, `||` für ODER, `!` für NICHT), die Wahrheitswerte (`bool`) verknüpfen und auswerten, typischerweise innerhalb einer [``Verzweigung``](#verzweigung).

### Mehrfachverzweigung
Eine Kontrollstruktur, die mehr als zwei mögliche Ausführungspfade bietet. In C# wird dies typischerweise mit `else if` oder einer [``Switch-Anweisung``](#switch-anweisung) realisiert.

### Methode
Ein benannter, wiederverwendbarer Codeblock, der eine spezifische Aufgabe ausführt. Methoden strukturieren das [``Programm``](#programm) und verhindern, dass Code mehrfach geschrieben werden muss.

### Microsoft-Azure
Microsofts Cloud-Plattform. Über den **Education**-Bereich erhalten Bildungseinrichtungen kostenlosen Zugang zu professioneller Entwicklungssoftware.

### Mitglied
*(Engl.: Member)* Ein Überbegriff für alle Bestandteile, die direkt zu einer [``Klasse``](#klasse) gehören, primär [``Felder``](#feld), [``Eigenschaften``](#eigenschaft), [``Konstruktoren``](#konstruktor) und [``Methoden``](#methode).

### Moodle
Unsere schulische Lernplattform. Dies ist der verbindliche Einstiegspunkt: Hier findest du alle aktuellen Links, die dich zielgenau zu den richtigen Aufgaben auf [``GitHub``](#github) leiten.

### Multiplizität
Gibt im UML-Klassendiagramm an den Enden einer [``Assoziation``](#assoziation) an, wie viele Objekte der Zielklasse mit einem Objekt der Ausgangsklasse in Verbindung stehen dürfen (z.B. `1`, `0..1`, `0..*`).

### Namespace
Eine logische Gruppierung von [``Klassen``](#klasse), [``Schnittstellen``](#schnittstelle) und anderen Typen in C#, um den Code zu strukturieren und Namenskonflikte in größeren Projekten zu vermeiden.

### Navigierbarkeit
Gibt bei einer [``Assoziation``](#assoziation) an, in welche Richtung kommuniziert wird.
* **Unidirektional:** Objekt A kennt Objekt B, aber B kennt A nicht.
* **Bidirektional:** Objekt A und Objekt B haben jeweils eine Referenz aufeinander und können in beide Richtungen kommunizieren.

### Objekt
Die konkrete Ausprägung (Instanz) einer [``Klasse``](#klasse) zur Laufzeit des Programms. Es belegt Platz im Arbeitsspeicher und enthält konkrete Werte in seinen Feldern.

### Objektebene
Bezieht sich auf den tatsächlichen [``Zustand``](#zustand) im Arbeitsspeicher zur Laufzeit des Programms (im Gegensatz zur theoretischen [``Klassenebene``](#klassenebene)).

### Operator
Ein Symbol oder Zeichen (wie `+`, `-`, `==`, `=`), das dem [``Compiler``](#compiler) mitteilt, eine bestimmte mathematische, logische oder relationale Operation durchzuführen.

### Parameter
Die Eingabewerte, die einer [``Methode``](#methode) in den runden Klammern übergeben werden, damit sie mit diesen Daten arbeiten kann.

### PoS
Programmieren und Software-Engineering. Das zentrale Fach, in dem wir die Grundlagen der Softwareentwicklung erlernen.

### Programm
Eine strukturierte Abfolge von Befehlen (z. B. in C#) zur Lösung einer Aufgabe. Ein Programm entsteht in einem [``Projekt``](#projekt) und startet am [``Entry-Point``](#entry-point).

### Projekt
Ein Container in der [``IDE``](#ide), der alle Dateien (Code, Konfigurationen) für ein [``Programm``](#programm) bündelt. Die Grundstruktur wird meist durch ein [``Projekt-Template``](#projekt-template) erstellt.

### Projekt-Template
Eine Vorlage (z. B. für eine [``Console-App``](#console-app)), die automatisch die nötige Ordnerstruktur und den Start-Code für ein neues [``Projekt``](#projekt) generiert.

### Projektmappe
*(Englisch: Solution, `.sln`)* Eine übergreifende Datei, die mehrere zusammengehörige C#-[``Projekte``](#projekt) bündelt. Ein Doppelklick darauf öffnet die gesamte [``Lektion``](#lektion) direkt in der [``IDE``](#ide).

### Property-Arten
* **Full Property:** Die [``Eigenschaft``](#eigenschaft) greift auf ein manuell geschriebenes, privates [``Backing Field``](#backing-field) zu.
* **Auto Property:** Der Code besteht nur aus `{ get; set; }`. Der [``Compiler``](#compiler) generiert das [``Backing Field``](#backing-field) im Hintergrund selbst.

### Referenz
Eine Speicheradresse, die wie ein Wegweiser auf den tatsächlichen Ort der Daten im [``Heap``](#heap) zeigt.

### Rider
Eine sehr leistungsstarke, plattformübergreifende C#-[``IDE``](#ide) von JetBrains, die als professionelle Alternative zu [``Visual Studio``](#visual-studio) genutzt werden kann.

### Runtime
*(Laufzeitumgebung)*. Die notwendige Software im Hintergrund, um ein [``Programm``](#programm) überhaupt auszuführen. Sie agiert als Übersetzer zwischen dem C#-Code und dem Computer.

### Schleife
Eine [``Kontrollstruktur``](#kontrollstruktur), die einen Codeblock wiederholt, solange eine bestimmte Bedingung erfüllt (wahr) ist. Dies verhindert Codeduplizierung.

### Schlüsselwort
*(Keyword)* Ein in C# reserviertes Wort (wie `class`, `public`, `if`), das eine vordefinierte Bedeutung für den [``Compiler``](#compiler) hat und nicht als Variablenname verwendet werden darf.

### Schnittstelle
*(Interface)* Ein reiner Vertragstyp, der definiert, welche [``Methoden``](#methode) oder [``Eigenschaften``](#eigenschaft) eine [``Klasse``](#klasse) implementieren muss, ohne jedoch die Funktionsweise (den Code) dafür vorzugeben.

### Scope
*(Gültigkeitsbereich)* Definiert, in welchem Teil des Codes eine [``Variable``](#variable) sichtbar und nutzbar ist. In C# wird der Scope in der Regel durch Codeblöcke in geschweiften Klammern `{ }` begrenzt.

### Seiteneffekt
*(Side Effect)* Wenn eine Funktion oder [``Methode``](#methode) nicht nur einen [``Wert``](#wert) zurückgibt, sondern "heimlich" den Zustand des Programms verändert (z. B. durch Ausgaben in der [``Console``](#console)).

### Sichtbarkeitsmodifizierer
Schlüsselwörter, die den Zugriff auf Klassen und deren Mitglieder regeln:
* `public`: Von überall im Projekt sichtbar.
* `private`: Nur innerhalb der exakt gleichen Klasse sichtbar.
* `protected`: Sichtbar in der eigenen Klasse und in Klassen, die davon erben.

### sln
Die Dateiendung (`.sln`) für eine [``Solution``](#solution) bzw. [``Projektmappe``](#projektmappe). Diese Datei merkt sich, welche [``Projekte``](#projekt) zu dieser Mappe gehören.

### slnx / sln
Die Dateiendungen für eine [``Projektmappe``](#projektmappe). Das neuere `.slnx`-Format nutzt dabei im Vergleich zur alten `.sln` eine wesentlich simplere und übersichtlichere XML-Struktur.

### Solution
Der englische Begriff für [``Projektmappe``](#projektmappe).

### Solution Explorer
*(Auf Deutsch: Projektmappen-Explorer)*. Ein zentrales Fenster in der [``IDE``](#ide), das die Struktur der [``Projektmappe``](#projektmappe) und aller darin enthaltenen Dateien als Baumstruktur darstellt.

### Stack
Der schnelle, strikt geordnete Teil des Arbeitsspeichers. Hier werden einfache Werte und die [``Referenzen``](#referenz) zu den Daten im [``Heap``](#heap) gespeichert.

### String
Ein Datentyp in C#, der eine Zeichenkette (Text) speichert. Er wird klassisch in doppelten Anführungszeichen geschrieben (z. B. `"Hallo Welt"`).

### Struktur
*(Struct)* Ein Werte-Datentyp in C#, der ähnlich wie eine [``Klasse``](#klasse) funktioniert, dessen Instanzen aber auf dem [``Stack``](#stack) statt auf dem [``Heap``](#heap) gespeichert werden.

### Switch Expression
*(Musterabgleichsausdruck)* Eine moderne, kompakte Schreibweise in C#, um basierend auf einem [``Wert``](#wert) direkt einen neuen Wert zuzuweisen, anstatt klassische Codeblöcke auszuführen.

### Switch-Anweisung
Eine [``Mehrfachverzweigung``](#mehrfachverzweigung), die eine einzige [``Variable``](#variable) auf verschiedene konkrete Werte (`case`) prüft und den entsprechenden Codeblock ausführt.

### Syntax
Die strikten grammatikalischen Regeln und Schreibweisen einer Programmiersprache (z. B. wann Klammern gesetzt oder wo Semikolons platziert werden müssen).

### Tertiärer Operator
Ein [``Operator``](#operator), der drei Operanden benötigt. In C# ist dies der bedingte Operator `?:`, der als Kurzschreibweise für eine einfache `if-else`-[``Verzweigung``](#verzweigung) dient.

### Top-Level Statement
Ein Feature in C#, das es erlaubt, den Code für den Einstiegspunkt der Anwendung direkt in die Datei zu schreiben, ohne explizit eine [``Klasse``](#klasse) `Program` und eine `Main`-[``Methode``](#methode) deklarieren zu müssen.

### Typ
*(Datentyp)* Legt fest, welche Art von Daten eine [``Variable``](#variable) speichern kann (z. B. `int` für Ganzzahlen, `string` für Text).

### Typecasting
Die explizite oder implizite Umwandlung eines Daten-[``Typs``](#typ) in einen anderen (z. B. von `double` in `int`).

### Unärer Operator
Ein [``Operator``](#operator), der nur einen einzigen Operanden benötigt, wie z. B. das [``Inkrement``](#inkrement) (`x++`) oder das logische NICHT (`!x`).

### Variable
Ein benannter Speicherplatz im Arbeitsspeicher, der einen bestimmten [``Typ``](#typ) und einen [``Wert``](#wert) enthält.

### Vergleichsoperatoren
Operatoren (wie `==`, `!=`, `<`, `>`), die zwei Werte miteinander vergleichen und als Ergebnis einen Wahrheitswert (`true` oder `false`) zurückgeben.

### Verschachtelte Schleifen
Schleifen, die sich innerhalb des Codeblocks einer anderen Schleife befinden (ein Loop in einem Loop). Sie sind zwingend notwendig, um mehrdimensionale Strukturen wie ein [``2D-Array``](#2d-array) zu durchlaufen.

### Verweistypen
*(Reference Types)* Datentypen, bei denen die Variable nicht den eigentlichen [``Wert``](#wert) speichert, sondern nur die Speicheradresse ([``Referenz``](#referenz)), wo die Daten im Arbeitsspeicher liegen.

### Verzweigung
Eine Kontrollstruktur (wie `if` mit `else`), die den Programmfluss basierend auf einer bestimmten Bedingung in genau zwei verschiedene Richtungen lenkt (wahr oder falsch). Bei mehr als zwei Wegen spricht man von einer [``Mehrfachverzweigung``](#mehrfachverzweigung).

### Visual Studio
Die umfangreiche, standardmäßige [``IDE``](#ide) von Microsoft für die Entwicklung mit C# und .NET, die wir primär im Unterricht einsetzen.

### Wert
Die konkreten Daten (z. B. die Zahl `15` oder der Text `"Anna"`), die in einer [``Variablen``](#variable) oder einem Array-[``Element``](#element) gespeichert sind.

### While-Schleife
Die allgemeinste (kopfgesteuerte) [``Schleife``](#schleife). Führt einen Codeblock wiederholt aus, solange ihre Bedingung wahr ist. Wird vor allem genutzt, wenn die Anzahl der Wiederholungen vorher unklar ist.

### Zähl-Schleife
*(auch Zählschleife).* Eine Kontrollstruktur, die einen Codeblock so oft wiederholt, wie es durch einen Zähler vorgegeben ist. Die bevorzugte Form in C# hierfür ist die [``For-Schleife``](#for-schleife).

### Zählvariable
Eine [``Variable``](#variable) (oft `i`), die in einer [``Schleife``](#schleife) (meist der [``For-Schleife``](#for-schleife)) verwendet wird, um mitzuzählen, wie oft der Block bereits ausgeführt wurde.

### Zusammenhalt
*(Engl.: Cohesion)* Beschreibt, wie stark die Mitglieder innerhalb *einer einzigen* [``Klasse``](#klasse) funktional zusammengehören. Ein gutes Softwaredesign strebt einen **starken/hohen Zusammenhalt** an.

### Zustand
Die Gesamtheit aller aktuellen Werte, die in den Feldern und Eigenschaften eines konkreten Objekts zu einem bestimmten Zeitpunkt im Arbeitsspeicher gespeichert sind.

### Zuständigkeit eines Blocks
Das Prinzip, dass ein bestimmter Code-Abschnitt (Scope) idealerweise genau eine logische, klar abgegrenzte Aufgabe erfüllen sollte, die mit einem kurzen Kommentar beschrieben werden kann.

### Zuweisung
Der Vorgang, bei dem einer [``Variablen``](#variable) oder einem Speicherplatz in einem [``Array``](#array) ein neuer [``Wert``](#wert) zugewiesen wird. In C# geschieht dies mit dem [``Zuweisungsoperator``](#zuweisungsoperator).

### Zuweisungsoperator
Das Gleichheitszeichen (`=`) in C#. Es nimmt den [``Wert``](#wert) auf der rechten Seite und speichert ihn in der [``Variablen``](#variable) auf der linken Seite.