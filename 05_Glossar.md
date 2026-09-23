# Glossar

### 2D-Array
Ein [``Array``](#array) mit zwei Dimensionen (Zeilen und Spalten), das man sich wie ein Schachbrett, ein Spielfeld oder eine Tabelle vorstellen kann. In C# wird es mit einem Komma in der eckigen Klammer (`[,]`) deklariert.

### Abgeleitete Klasse
Eine [``Klasse``](#klasse), die von einer anderen Klasse (der [``Basisklasse``](#basisklasse)) erbt und deren [``Mitglieder``](#mitglied) übernimmt. Sie ist eine spezialisierte Version der Basisklasse.

### Abstrakte Klasse
Eine spezielle [``Basisklasse``](#basisklasse), von der keine [``Objekte``](#objekt) direkt instanziiert werden dürfen. Sie dient ausschließlich als Vorlage für abgeleitete Klassen und kann [``abstrakte Methoden``](#abstrakte-methode) enthalten.

### Abstrakte Methode
Eine [``Methode``](#methode), die in einer abstrakten Klasse oder einem Interface nur [``deklariert``](#deklaration) (ohne Methodenrumpf), aber nicht definiert wird. Die [``abgeleitete Klasse``](#abgeleitete-klasse) wird gezwungen, diese Methode auszuprogrammieren.

### Angabe / Lösung
Die textliche Beschreibung (meist als Markdown) einer zu lösenden Programmieraufgabe innerhalb einer [``Lektion``](#lektion). Die dazugehörige Lösung wird oftmals als separates C#-[``Projekt``](#projekt) bereitgestellt.

### Anweisung
*(Statement)* Ein vollständiger Ausführungsbefehl in C#, der eine Aktion durchführt (z. B. Variablenzuweisung, Methodenaufruf). Eine Anweisung liefert selbst keinen [``Wert``](#wert) zurück und wird stets mit einem Semikolon (`;`) abgeschlossen.

### Arithmetische Operatoren
Operatoren, die grundlegende mathematische Berechnungen ausführen, wie Addition (`+`), Subtraktion (`-`), Multiplikation (`*`), Division (`/`) und Modulo (`%`).

### Array
Eine Datenstruktur, die eine feste Anzahl von Elementen desselben Datentyps speichert. Man greift auf die einzelnen Elemente über ihren jeweiligen [``Index``](#index) zu.

### Assoziation
Eine Assoziation (oft als "Hat-Beziehung" bezeichnet) ist eine [``Beziehung``](#beziehung) zwischen zwei Klassen. Sie drückt aus, dass ein [``Objekt``](#objekt) einer [``Klasse``](#klasse) ein Objekt der anderen Klasse kennt und Aufgaben an dieses delegieren kann.

### Ausdruck
*(Expression)* Ein Code-Fragment in C#, das vom Programm ausgewertet wird und als Ergebnis exakt einen [``Wert``](#wert) zurückgibt (z. B. die Rechnung `5 + 3` oder der Vergleich `alter >= 18`). Ein Ausdruck kann Teil einer [``Anweisung``](#anweisung) sein.

### Aussage
In der Programmierung oft synonym für einen logischen [``Ausdruck``](#ausdruck) verwendet, der als Ergebnis entweder wahr (`true`) oder falsch (`false`) ist.

### Auswertungsreihenfolge
Legt fest, in welcher zeitlichen Reihenfolge Code-Teile (wie z. B. die Bedingung einer [``Schleife``](#schleife) und deren auszuführender Code-Block) vom Programm überprüft und ausgeführt werden (z. B. kopfgesteuert vs. fußgesteuert).

### Backing Field
Ein privates [``Feld``](#feld) in einer [``Klasse``](#klasse), das exklusiv dazu dient, den tatsächlichen [``Wert``](#wert) für eine [``Eigenschaft``](#eigenschaft) (Property) im Hintergrund zu speichern.

### Basisklasse
Die allgemeinere [``Klasse``](#klasse), von der andere Klassen (die [``abgeleiteten Klassen``](#abgeleitete-klasse)) erben.

### Bedingte Anweisung
Eine Kontrollstruktur (wie `if` ohne `else`), bei der ein Codeblock nur dann ausgeführt wird, wenn eine spezifische Bedingung wahr (`true`) ist. Andernfalls läuft das Programm ohne weitere Aktion weiter.

### Bedingung
Ein logischer [``Ausdruck``](#ausdruck), der zu einem booleschen Wert (`true` oder `false`) ausgewertet wird. Er entscheidet in einer [``Kontrollstruktur``](#kontrollstruktur) (wie `if` oder `while`), ob ein bestimmter Code-[``Block``](#block) ausgeführt wird oder nicht.

### Beziehung
Beschreibt, wie [``Klassen``](#klasse) oder [``Objekte``](#objekt) miteinander interagieren. Primäre Formen sind die Hat-Beziehung ([``Assoziation``](#assoziation)) und die Ist-Beziehung (Vererbung).

### Bidirektionalität
Ein Zustand bei einer [``Assoziation``](#assoziation), bei dem sich zwei [``Objekte``](#objekt) zur Laufzeit gegenseitig kennen und referenzieren. Auf [``Klassenebene``](#klassenebene) bedeutet es, dass beide Klassen Verweise aufeinander deklarieren.

### Binärer Operator
Ein [``Operator``](#operator), der genau zwei Operanden benötigt, um eine Operation auszuführen (z. B. `a + b` oder `x == y`).

### Bitweise Operatoren
Operatoren, die direkt auf der binären Ebene der [``Typen``](#typ) arbeiten (Bit für Bit), z. B. AND (`&`), OR (`|`), XOR (`^`) und Bit-Shifts (`<<`, `>>`).

### Block
Ein Code-Abschnitt in C#, der durch **geschweifte Klammern** `{ }` (nicht eckig!) eingeschlossen ist. Er fasst mehrere Anweisungen zusammen und definiert den Gültigkeitsbereich ([``Scope``](#scope)) für darin deklarierte [``Variablen``](#variable).

### Branch
Ein separater Versionszweig in [``Git``](#git). In unserem Repository repräsentiert ein Branch den spezifischen Lernfortschritt und Materialstand einer einzelnen Schulklasse über alle Jahrgänge hinweg.

### break
Ein [``Schlüsselwort``](#schlüsselwort), das verwendet wird, um eine [``Schleife``](#schleife) oder eine [``Switch-Anweisung``](#switch-anweisung) sofort und endgültig abzubrechen.

### Collection
Ein Überbegriff für komplexe Datenstrukturen in C# (wie Listen, Dictionaries), die im Gegensatz zum einfachen [``Array``](#array) eine dynamische Größe haben und Elemente flexibel verwalten können.

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

### De Morgan'sches Gesetz
Zwei Regeln der Aussagenlogik, mit denen sich [``logische Formeln``](#logische-formel) umformen lassen (z. B. wird `!(A && B)` zu `!A || !B`). In der Programmierung hilft dies, komplexe [``Bedingungen``](#bedingung) in Verzweigungen zu vereinfachen und lesbarer zu machen.

### Debug
Der Prozess, Fehler (Bugs) in einem [``Programm``](#programm) zu finden und zu beheben. In der [``IDE``](#ide) lässt sich der Code dafür während der Ausführung anhalten und gezielt überprüfen.

### Definition
Die tatsächliche Bereitstellung von Speicherplatz im Arbeitsspeicher oder die konkrete Implementierung von Code. Bei [``Variablen``](#variable) geschieht die Definition meist mit der [``Deklaration``](#deklaration). Bei einer [``Methode``](#methode) ist die Definition der eigentliche Code-[``Block``](#block) (der Rumpf in `{ }`).

### Deklaration
Das reine Bekanntmachen einer [``Variablen``](#variable), [``Klasse``](#klasse) oder [``Methode``](#methode) beim [``Compiler``](#compiler). Es wird festgelegt, welchen [``Typ``](#typ) und welchen Namen das Konstrukt hat (z. B. `int alter;`). Es wird hierbei noch kein konkreter [``Wert``](#wert) zugewiesen.

### Dekrement
Die Verringerung eines numerischen Wertes um genau eins, typischerweise durchgeführt mit dem Operator `--`.

### Dimension
Die Ausdehnung eines [``Arrays``](#array). Ein 1D-Array hat eine Dimension (eine simple Liste). Ein [``2D-Array``](#2d-array) hat zwei Dimensionen (Tabelle/Gitter mit X und Y).

### Do-While-Schleife
Eine fußgesteuerte [``Schleife``](#schleife), bei der der Code-Block garantiert mindestens einmal ausgeführt wird, bevor die Bedingung ganz am Ende überprüft wird.

### Domäne
Der abzubildende Fachbereich oder Themenbereich (z.B. ein Tiergehege, ein Geschäft) einer Softwareanwendung. Die darin existierenden theoretischen Konzepte werden als [``Klassen``](#klasse) modelliert.

### Early Exit
Ein Programmierstil, bei dem eine Methode (mit `return`) oder eine Schleife (mit `break` oder `continue`) so früh wie möglich verlassen wird, sobald feststeht, dass der restliche Code nicht mehr ausgeführt werden muss. Das verhindert tiefe Verschachtelungen.

### Eigenschaft
*(Engl.: Property)* Eine Eigenschaft wirkt nach außen wie eine normale [``Variable``](#variable), ist intern aber eine Kombination aus Methoden (`get` für das Lesen, `set` für das Schreiben), um den Zugriff auf Daten zu kontrollieren.

### Element
Ein einzelner Datenpunkt (z. B. eine einzelne Zahl oder ein einzelner Text) innerhalb einer übergeordneten Datenstruktur wie einem [``Array``](#array).

### Entry-Point
Der Einstiegspunkt, an dem die Ausführung eines [``Programms``](#programm) beginnt. In modernen C#-[``Console-Apps``](#console-app) oft durch kompakte [``Top-Level Statements``](#top-level-statement) umgesetzt.

### Feld
Eine [``Variable``](#variable), die direkt in einer [``Klasse``](#klasse) deklariert wird und den inneren [``Zustand``](#zustand) eines Objekts speichert. Felder sollten in der Regel `private` sein.

### field-Keyword
Ein [``Schlüsselwort``](#schlüsselwort) (eingeführt mit C# 13 / .NET 10), das es erlaubt, innerhalb der `get`/`set`-Zugriffsfunktionen einer [``Eigenschaft``](#eigenschaft) direkt auf das automatisch generierte [``Backing Field``](#backing-field) zuzugreifen, ohne dieses vorher manuell anlegen zu müssen.

### For-Schleife
Eine sehr kompakte Schleifenart, bei der Initialisierung der [``Zählvariable``](#zählvariable), die Bedingung und das Inkrement übersichtlich im Schleifenkopf gebündelt sind. Ideal für eine vorher bekannte, endliche Anzahl an Wiederholungen.

### Funktion
Ein allgemeiner Begriff für einen ausführbaren Codeblock. In objektorientierten Sprachen wie C# sind Funktionen nahezu immer an [``Klassen``](#klasse) oder [``Objekte``](#objekt) gebunden und werden deshalb streng genommen [``Methoden``](#methode) genannt.

### Git
Ein Versionskontrollsystem, das Änderungen am Quellcode nachverfolgt. Es speichert den gesamten Verlauf eines [``Projektes``](#projekt) und ermöglicht es, jederzeit zu älteren Versionen zurückzukehren.

### GitHub
Die webbasierte Plattform, auf der unsere [``Git``](#git)-Repositories gehostet werden. Es dient im Unterricht als öffentliches Archiv für alle Skripten, Mitschriften und Code-Beispiele.

### Guard Clause
Eine spezielle [``If-Anweisung``](#if-anweisung) ganz am Anfang einer Methode oder Schleife, die als eine Art "Türsteher" auf Fehler oder unerwünschte Zustände (❌) prüft. Trifft der Fehler zu, wird sofort ein [``Early Exit``](#early-exit) ausgeführt. 

### Heap
Der große, flexible Teil des Arbeitsspeichers, in dem komplexe Datenstrukturen wie [``Arrays``](#array) und Objekte ([``Verweistypen``](#verweistypen)) gespeichert werden, da ihre Größe oft variabel ist oder sie viel Platz benötigen.

### Hello-World-Programm
Das traditionell erste [``Programm``](#programm), das man schreibt. Es gibt lediglich Text in der [``Console``](#console) aus und beweist, dass das [``Projekt``](#projekt) fehlerfrei läuft.

### IDE
*(Integrated Development Environment)* Eine integrierte Entwicklungsumgebung wie [``Visual Studio``](#visual-studio) oder [``Rider``](#rider). Sie vereint alle wichtigen Werkzeuge – vom Code-Editor über den [``Compiler``](#compiler) bis hin zur [``Debug``](#debug)-Konsole – in einem Programm.

### Identität
Das wichtigste Konzept der Objektorientierung. Jedes [``Objekt``](#objekt) ist ein eigenständiges Individuum mit einem eindeutigen Platz im Arbeitsspeicher, selbst wenn es exakt denselben [``Zustand``](#zustand) wie ein anderes Objekt aufweist.

### Implementierung
Die tatsächliche Umsetzung oder Programmierung eines Konzepts. Sehr häufig verwendet im Kontext von Interfaces: Eine [``Klasse``](#klasse) implementiert eine [``Schnittstelle``](#schnittstelle), indem sie die vertraglich deklarierten Methoden ausprogrammiert (definiert).

### Index
Die numerische Position eines Elements innerhalb eines [``Arrays``](#array). In C# (und den meisten anderen Programmiersprachen) gilt die strikte **Nullindizierung**. Das erste Element liegt am Index 0.

### Initialisierung
Die allererste Zuweisung eines [``Wertes``](#wert) an eine [``Variable``](#variable), nachdem diese [``deklariert``](#deklaration) wurde. Ohne Initialisierung kann eine lokale Variable in C# nicht verwendet werden.

### Inkrement
Die Erhöhung eines numerischen Wertes um genau eins, typischerweise durchgeführt mit dem Operator `++`.

### Instanz
Ein anderes Wort für ein konkretes [``Objekt``](#objekt), das aus dem Bauplan einer [``Klasse``](#klasse) erzeugt ([``instanziiert``](#instanziierung)) wurde.

### Instanziierung
Der Prozess, bei dem aus einer [``Klasse``](#klasse) (dem Bauplan) ein konkretes [``Objekt``](#objekt) im Arbeitsspeicher (unter Verwendung des [``Schlüsselworts``](#schlüsselwort) `new`) erzeugt wird.

### Interface
Der englische Fachbegriff für [``Schnittstelle``](#schnittstelle). Ein strikter Vertrag, der nur aus Methodendeklarationen (ohne Rumpf) und Eigenschaften besteht.

### Jahrgang
Entspricht der Schulstufe (1 bis 5) an der HTL. Er strukturiert die Lerninhalte chronologisch nach dem jeweiligen Ausbildungsjahr.

### Kapselung
*(Engl.: Encapsulation)* Das Bündeln von Daten (Feldern) und den darauf arbeitenden Funktionen (Methoden) in einer Einheit (der [``Klasse``](#klasse)), gepaart mit der strikten Kontrolle, wer über Eigenschaften oder Methoden auf diese Daten zugreifen darf.

### Klasse
Der theoretische Bauplan (die Vorlage) für [``Objekte``](#objekt). Sie definiert, welche Eigenschaften und Methoden die später aus ihr erstellten Objekte haben werden.

### Klassenebene
Bezieht sich auf die theoretische Struktur des Codes (den Bauplan). Eine Beziehung auf Klassenebene bedeutet, dass die [``Klassen``](#klasse) im Code so geschrieben sind, dass sie sich potenziell referenzieren können.

### Klassendiagramm
Ein strukturierter UML-Bauplan, der zeigt, welche [``Klassen``](#klasse) in einer Software existieren, welche Mitglieder sie haben und wie sie miteinander in Verbindung stehen (statische Struktur).

### Kommentar
Textabschnitte im Quellcode, die vom [``Compiler``](#compiler) komplett ignoriert werden. Sie dienen ausschließlich dazu, den Code für Menschen lesbarer zu machen oder Erklärungen zu hinterlassen (z. B. `//` oder `/* ... */`).

### Konstruktor
Eine spezielle [``Methode``](#methode) einer Klasse, die exakt so heißt wie die [``Klasse``](#klasse) selbst und keinen Rückgabetyp hat. Sie wird bei der [``Instanziierung``](#instanziierung) des Objekts automatisch aufgerufen.

### Kontrollstruktur
Konstrukte einer Programmiersprache (wie Verzweigungen oder Schleifen), die den streng linearen Ablauf eines Programms steuern oder verändern.

### Konvention
Eine nicht durch den Compiler erzwungene, aber von Entwicklern vereinbarte Schreibweise oder Regel (z. B. dass [``Interfaces``](#interface) in C# stets mit einem großen `I` beginnen).

### Kopplung
*(Engl.: Coupling)* Beschreibt den Grad der Abhängigkeit zwischen verschiedenen Modulen oder Klassen. Ein gutes Softwaredesign strebt eine **lose/niedrige Kopplung** an, damit Änderungen nicht alles kaputt machen.

### Lektion
Eine thematische Unterrichtseinheit innerhalb eines [``Jahrgangs``](#jahrgang). Sie umfasst das theoretische Skriptum, die [``Angaben``](#angabe--lösung) für Aufgaben sowie die dazugehörigen C#-[``Projekte``](#projekt).

### Liste
Eine dynamische Datenstruktur (Teil der [``Collections``](#collection)), die ähnlich wie ein [``Array``](#array) funktioniert, aber zur Laufzeit nach Belieben wachsen oder schrumpfen kann (in C# z.B. `List<T>`).

### Live-Coding
Programmcode und [``Projekte``](#projekt), die wir interaktiv und Schritt für Schritt gemeinsam im Unterricht erarbeiten. Sie dienen dem aktiven Verständnis.

### Logische Formel
Eine Kombination aus [``Werten``](#wert), [``Variablen``](#variable) und [``logischen Operatoren``](#logische-operatoren), die mathematisch ausgewertet wird und als Ergebnis strikt `true` oder `false` liefert.

### Logische Operatoren
Operatoren (wie `&&` für UND, `||` für ODER, `!` für NICHT), die Wahrheitswerte (`bool`) verknüpfen und auswerten, typischerweise innerhalb einer [``Verzweigung``](#verzweigung).

### Mehrfachverzweigung
Eine Kontrollstruktur, die mehr als zwei mögliche Ausführungspfade bietet. In C# wird dies typischerweise mit `else if` oder einer [``Switch-Anweisung``](#switch-anweisung) realisiert.

### Methode
Ein benannter, wiederverwendbarer Codeblock, der eine spezifische Aufgabe ausführt. Methoden strukturieren das [``Programm``](#programm) und verhindern, dass Code mehrfach geschrieben werden muss.

### Methodenkopf
Der obere Teil einer Methodendeklaration (die Signatur), der Sichtbarkeit, Rückgabetyp, Name und die [``Parameter``](#parameter) festlegt, bevor der eigentliche Methodenrumpf `{ ... }` beginnt.

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

### Negieren
Das logische Umkehren eines Wahrheitswertes. Aus `true` wird `false` und umgekehrt. In C# wird dies mit dem unären Operator `!` (logisches NICHT) vor einer Variablen oder einem [``Ausdruck``](#ausdruck) durchgeführt.

### Objekt
Die konkrete Ausprägung (Instanz) einer [``Klasse``](#klasse) zur Laufzeit des Programms. Es belegt Platz im Arbeitsspeicher und enthält konkrete Werte in seinen Feldern.

### Objektebene
Bezieht sich auf den tatsächlichen Zustand und die Verkabelungen im Arbeitsspeicher zur Laufzeit des Programms (im Gegensatz zur theoretischen [``Klassenebene``](#klassenebene)).

### Objektdiagramm
Eine UML-Momentaufnahme zur Laufzeit. Es zeigt im Gegensatz zum statischen [``Klassendiagramm``](#klassendiagramm) nicht die abstrakten Klassen, sondern die konkreten, physisch im Arbeitsspeicher existierenden [``Objekte``](#objekt) und deren Links zu einem bestimmten Zeitpunkt.

### Operator
Ein Symbol oder Zeichen (wie `+`, `-`, `==`, `=`), das dem [``Compiler``](#compiler) mitteilt, eine bestimmte mathematische, logische oder relationale Operation durchzuführen.

### Parameter
Die Eingabewerte, die einer [``Methode``](#methode) in den runden Klammern übergeben werden, damit sie mit diesen Daten arbeiten kann.

### Pattern-Matching
Ein fortgeschrittenes C#-Feature (oft in [``Switch-Ausdrücken``](#switch-ausdruck) genutzt), das es erlaubt, den [``Wert``](#wert) oder den [``Typ``](#typ) eines Objekts sehr kompakt gegen komplexe Muster (Patterns) zu prüfen.

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
Eine [``Speicheradresse``](#Speicheradresse), die wie ein Wegweiser auf den tatsächlichen Ort der Daten im [``Heap``](#heap) zeigt.

### Rider
Eine sehr leistungsstarke, plattformübergreifende C#-[``IDE``](#ide) von JetBrains, die als professionelle Alternative zu [``Visual Studio``](#visual-studio) genutzt werden kann.

### Runtime
*(Laufzeitumgebung)*. Die notwendige Software im Hintergrund, um ein [``Programm``](#programm) überhaupt auszuführen. Sie agiert als Übersetzer zwischen dem C#-Code und dem Computer.

### Schleife
Eine [``Kontrollstruktur``](#kontrollstruktur), die einen Codeblock wiederholt, solange eine bestimmte Bedingung erfüllt (wahr) ist. Dies verhindert Codeduplizierung.

### Schleifenkopf
Der Definitionsteil einer [``Schleife``](#schleife) (meist innerhalb der runden Klammern). Bei der `while`-Schleife enthält er nur die [``Bedingung``](#bedingung), bei der `for`-Schleife bündelt er zusätzlich die [``Zählvariable``](#zählvariable) und das [``Inkrement``](#inkrement).

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

### Speicheradresse
Eine eindeutige numerische Kennung (ein exakter Ort) im Arbeitsspeicher des Computers, an dem Daten abgelegt werden. Bei [``Verweistypen``](#verweistypen) wird lediglich eine [``Referenz``](#referenz) gespeichert, die wie ein Wegweiser auf diese Adresse zeigt.

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

### Teilproblem
Ein kleineres, überschaubares und leichter lösbares Problem, in das eine große, komplexe Programmieraufgabe zerlegt wird, um den Code übersichtlicher und besser wartbar zu machen.

### Tertiärer Operator
Ein [``Operator``](#operator), der drei Operanden benötigt. In C# ist dies der bedingte Operator `?:`, der als Kurzschreibweise für eine einfache `if-else`-[``Verzweigung``](#verzweigung) dient.

### Top-Level Statement
Ein Feature in C#, das es erlaubt, den Code für den Einstiegspunkt der Anwendung direkt in die Datei zu schreiben, ohne explizit eine [``Klasse``](#klasse) `Program` und eine `Main`-[``Methode``](#methode) deklarieren zu müssen.

### Typ
*(Datentyp)* Legt fest, welche Art von Daten eine [``Variable``](#variable) speichern kann (z. B. `int` für Ganzzahlen, `string` für Text). Eine [``Klasse``](#klasse) ist ein selbst definierter, komplexer Typ.

### Typecasting
Die explizite oder implizite Umwandlung eines Daten-[``Typs``](#typ) in einen anderen (z. B. von `double` in `int`).

### UML
*(Unified Modeling Language)* Eine standardisierte, grafische Modellierungssprache in der Softwareentwicklung, die dazu dient, Strukturen (wie im [``Klassendiagramm``](#klassendiagramm)) und Abläufe visuell darzustellen.

### Unärer Operator
Ein [``Operator``](#operator), der nur einen einzigen Operanden benötigt, wie z. B. das [``Inkrement``](#inkrement) (`x++`) oder das logische NICHT (`!x`).

### Variable
Ein benannter Speicherplatz im Arbeitsspeicher, der einen bestimmten [``Typ``](#typ) und einen [``Wert``](#wert) (bzw. eine Referenz zu einem [``Objekt``](#objekt)) enthält.

### Vergleichsoperatoren
Operatoren (wie `==`, `!=`, `<`, `>`), die zwei Werte miteinander vergleichen und als Ergebnis einen Wahrheitswert (`true` oder `false`) zurückgeben.

### Verhalten
Beschreibt, was ein [``Objekt``](#objekt) aktiv tun kann. Das Verhalten wird durch die in der [``Klasse``](#klasse) deklarierten und definierten [``Methoden``](#methode) abgebildet.

### Verschachtelte Schleifen
Schleifen, die sich innerhalb des Codeblocks einer anderen Schleife befinden (ein Loop in einem Loop). Sie sind zwingend notwendig, um mehrdimensionale Strukturen wie ein [``2D-Array``](#2d-array) zu durchlaufen.

### Verschachtelte Verzweigung
Eine [``Verzweigung``](#verzweigung) (wie z. B. eine If-Anweisung), die sich innerhalb des Code-[``Blocks``](#block) einer anderen Verzweigung befindet. Dies stellt logisch oft ein zusätzliches UND (`&&`) dar.

### Verweistypen
*(Reference Types)* Datentypen, bei denen die Variable nicht den eigentlichen [``Wert``](#wert) speichert, sondern nur die [``Speicheradresse``](#Speicheradresse) ([``Referenz``](#referenz)), wo die Daten im Arbeitsspeicher liegen.

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