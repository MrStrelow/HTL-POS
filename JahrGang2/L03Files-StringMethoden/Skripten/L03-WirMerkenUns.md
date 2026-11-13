#### Wir merken uns von [Strings](L03.1_string-methoden.html):
>1. [``Funktionen``](../../../05_Glossar.md#funktion) und [``Methoden``](../../../05_Glossar.md#methode) sind fast das Gleiche. Eine [``Funktion``](../../../05_Glossar.md#funktion) [``rufen``](../../../05_Glossar.md#aufruf) wir nur mit Namen und [``Parametern``](../../../05_Glossar.md#parameter) auf: ``Trim(text)``. Eine [``Methode``](../../../05_Glossar.md#methode) gehört zu einem [``Wert``](../../../05_Glossar.md#wert), einer [``Variable``](../../../05_Glossar.md#variable) oder einem [``Typ``](../../../05_Glossar.md#typ). Wir rufen sie mit dem **Punkt** auf: ``text.Trim()``, ``File.ReadAllLines(pfad)``.
>2. Eine [``Methode``](../../../05_Glossar.md#methode) braucht einen [``Eingangsparameter``](../../../05_Glossar.md#eingangsparameter) weniger: Sie kennt die [``Variable``](../../../05_Glossar.md#variable) schon, für die sie aufgerufen wird.
>3. Ein [``String``](../../../05_Glossar.md#string) wird durch [``String-Methoden``](../../../05_Glossar.md#string-methode) **nie verändert**. Sie liefern einen **neuen** [``String``](../../../05_Glossar.md#string) als [``Rückgabewert``](../../../05_Glossar.md#rückgabewert). Darum schreiben wir ``text = text.Trim();``.
>4. Mit ``Substring(start, länge)`` holen wir einen Teil heraus. Mit ``IndexOf(':')`` finden wir die Position eines Zeichens, ``-1`` heißt „nicht gefunden“.
>5. ``Trim`` entfernt Leerzeichen am Anfang und am Ende. ``ToUpper`` und ``ToLower`` machen uns unabhängig von der Schreibweise. ``Replace('.', ':')`` tauscht Zeichen aus.
>6. ``Split(';')`` zerlegt eine Zeile in ein [``Array``](../../../05_Glossar.md#array) von Teilen. ``string.Join(" ", teile)`` setzt die Teile wieder zusammen.
>7. ``StartsWith("#")`` prüft den Anfang. ``string.IsNullOrWhiteSpace(zeile)`` erkennt leere Zeilen.
>8. ``PadLeft(n)`` und ``PadRight(n)`` füllen einen [``String``](../../../05_Glossar.md#string) auf die Länge ``n`` auf. So werden Spalten gleich breit.

#### Wir merken uns von [Files einlesen und schreiben](L03.2_filesEinlesenUndSchreiben.html):
>9. Ein [``Pfad``](../../../05_Glossar.md#pfad) ist eine Wegbeschreibung zu einer Datei im Dateisystem.
>10. Ein [``absoluter Pfad``](../../../05_Glossar.md#absoluter-pfad) beginnt beim Laufwerk (``C:\...``). Ein [``relativer Pfad``](../../../05_Glossar.md#relativer-pfad) geht von einem Basispunkt aus. Unser Basispunkt ist der Ordner der ``.exe``: ``bin/Debug/net10.0``.
>11. Liegt die Datei neben ``Program.cs``, gehen wir drei Ordner hinauf: ``"../../../stempelzeiten.txt"``.
>12. ``File.Exists(pfad)`` prüft, ob es die Datei gibt. Fehlt sie, beenden wir das Programm sofort mit einer [``Guard Clause``](../../../05_Glossar.md#guard-clause) (``return``).
>13. ``File.ReadAllLines(pfad)`` liefert ein ``string[]``. Jede Zeile der Datei ist ein [``Element``](../../../05_Glossar.md#element), **auch Leerzeilen und Kommentare**.
>14. ``File.WriteAllLines(pfad, zeilen)`` schreibt jedes [``Element``](../../../05_Glossar.md#element) des [``Arrays``](../../../05_Glossar.md#array) als eigene Zeile in die Datei.
>15. Eine [``foreach-Schleife``](../../../05_Glossar.md#foreach-schleife) geht alle [``Elemente``](../../../05_Glossar.md#element) durch, aber **ohne** [``Index``](../../../05_Glossar.md#index). Wir verwenden sie zum Lesen. Brauchen wir die Zeilennummer, zählen wir sie selbst mit, und zwar **vor** jedem ``continue``.
>16. Eine [``for-Schleife``](../../../05_Glossar.md#for-schleife) verwenden wir nur, wenn wir den [``Index``](../../../05_Glossar.md#index) wirklich brauchen. Beispiele: bei ``1`` starten oder zwei [``Arrays``](../../../05_Glossar.md#array) mit demselben [``Index``](../../../05_Glossar.md#index) befüllen.
>17. Ein [``StreamReader``](../../../05_Glossar.md#streamreader) liest **Zeile für Zeile** mit ``ReadLine()``. Das ist für große Dateien gedacht, wenn wir uns nur Ergebnisse merken. ``File.ReadAllLines`` lädt die ganze Datei auf einmal in den Speicher.
>18. In einer [``CSV-Datei``](../../../05_Glossar.md#csv) sind die Werte durch Trennzeichen getrennt: im Englischen mit ``,``, im Deutschen mit ``;``. Jede Zeile zerlegen wir mit ``Split``.

#### Wir merken uns von [Aufgabe01 – Stempeluhr](../Aufgabe01-Stempeluhr/Angabe.md):
>19. Daten aus Dateien sind „schmutzig“. **Ist eindeutig, was gemeint ist, reparieren wir still** 🔧 (``7.45`` → ``7:45``). **Könnte es mehreres bedeuten oder fehlt etwas, melden wir einen Fehler** ❌. Wir raten nie.
>20. Jede [``Funktion``](../../../05_Glossar.md#funktion) prüft zuerst die ungewünschten Zustände ❌ mit [``Guard Clauses``](../../../05_Glossar.md#guard-clause) und verlässt sie mit [``Early Exit``](../../../05_Glossar.md#early-exit). Erst ganz unten steht der gewünschte Zustand ✅.
>21. Einen ungültigen Wert melden wir über einen [``Rückgabewert``](../../../05_Glossar.md#rückgabewert), der sonst nie vorkommt, z. B. ``-1``. Ungültige Zeilen in einer Schleife überspringen wir mit ``continue``.
>22. Einen [``Default-Parameter``](../../../05_Glossar.md#default-parameter) (``int n = 10``) darf man beim [``Aufruf``](../../../05_Glossar.md#aufruf) weglassen. Er steht immer am Ende der Parameterliste und ersetzt „magische Zahlen“ im Code.
>23. Manches wissen wir erst, wenn **alle** Zeilen gelesen sind, z. B. die Spaltenbreite. Dann merken wir uns zuerst alles in [``Arrays``](../../../05_Glossar.md#array) und geben erst in einem zweiten Durchgang aus.

#### Wir merken uns von [Named Tuples & Distanz](L03.2_schachbrettEuklid.html) und [Distanz als Linie](L03.3_linieZeichnen.html):
>24. Ein [``Named Tuple``](../../../05_Glossar.md#named-tuple) fasst mehrere Werte mit Namen zusammen: ``(int x, int y) start``. Wir greifen mit dem Punkt zu: ``start.x``. Tuples lassen sich verschachteln: ``punkte.start.x``.
>25. So kann eine [``Funktion``](../../../05_Glossar.md#funktion) mehrere Werte auf einmal zurückgeben: ``return ((sx, sy), (zx, zy));``.
>26. ``int.TryParse(text, out int zahl)`` liefert ``true`` oder ``false``. Die Zahl gibt es über einen [``Ausgangsparameter``](../../../05_Glossar.md#ausgangsparameter) (``out``) zurück.
>27. Die [``euklidische Distanz``](../../../05_Glossar.md#euklidische-distanz) ist die Luftlinie nach Pythagoras: ``Math.Sqrt(dx * dx + dy * dy)``.
>28. Bei einer [``Ganzzahldivision``](../../../05_Glossar.md#ganzzahldivision) ist ``int / int`` wieder ``int``: ``4 / 5`` ergibt ``0``. Mit einem [``Typecast``](../../../05_Glossar.md#typecasting) **vor** der Division rechnen wir mit Kommazahlen: ``(double)4 / 5`` ergibt ``0.8``.
>29. Im 2D-Gitter ist ``(0|0)`` **oben links**. ``x`` wächst nach rechts, ``y`` nach unten. Die äußere Schleife geht die Zeilen ``y`` durch, die innere die Spalten ``x``: Die Konsole schreibt zeilenweise.
>30. Eine Linie zeichnen wir mit einer [``linearen Funktion``](../../../05_Glossar.md#lineare-funktion): Für jede Spalte ``x`` sagt ``f(x)``, in welcher Zeile ``y`` die Linie liegt. Gezeichnet wird nur zwischen Start und Ziel (``start.x < x && x < ziel.x``).
>31. ``f(x) = k · x`` startet in ``(0|0)``. Nach rechts schieben wir mit ``x − start.x``, nach unten mit ``+ start.y``: ``fx = start.y + (int)Math.Round(k * (x - start.x))``. Weil es nur ganze Kästchen gibt, runden wir.
>32. Für eine Gerade reicht auch **eine** Verschiebung: ``k · x + d`` mit ``d = start.y − k · start.x``.
>33. Bei steilen Linien (``|dy| > |dx|``) entstehen Lücken, wenn wir ``x`` abgehen. Dann gehen wir ``y`` ab. Die Regel: immer die **längere** Achse abgehen.
