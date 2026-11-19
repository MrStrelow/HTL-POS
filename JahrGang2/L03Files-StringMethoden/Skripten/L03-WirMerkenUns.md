#### Wir merken uns von [Strings](L03.1_string-methoden.html):
>1. Eine [``Methode``](../../../05_Glossar.md#methode) gehört zu einem [``Wert``](../../../05_Glossar.md#wert), einer [``Variable``](../../../05_Glossar.md#variable) oder einem [``Typ``](../../../05_Glossar.md#typ) und wird mit dem **Punkt** aufgerufen: ``text.Trim()``. Sie braucht einen [``Eingangsparameter``](../../../05_Glossar.md#eingangsparameter) weniger als eine [``Funktion``](../../../05_Glossar.md#funktion), denn sie kennt ihre [``Variable``](../../../05_Glossar.md#variable) schon.
>2. [``String-Methoden``](../../../05_Glossar.md#string-methode) verändern den [``String``](../../../05_Glossar.md#string) **nie**. Sie liefern einen **neuen** zurück: ``text = text.Trim();``.
>3. ``Trim`` entfernt Leerzeichen am Rand, ``ToUpper``/``ToLower`` machen uns unabhängig von der Schreibweise, ``Replace`` tauscht Zeichen aus.
>4. ``IndexOf`` findet eine Position (``-1`` = nicht gefunden), ``Substring`` holt einen Teil heraus.
>5. ``Split`` zerlegt eine Zeile in ein [``Array``](../../../05_Glossar.md#array), ``string.Join`` setzt es wieder zusammen.
>6. ``PadLeft``/``PadRight`` füllen auf eine feste Länge auf – so werden Spalten gleich breit.

#### Wir merken uns von [Files einlesen und schreiben](L03.2_filesEinlesenUndSchreiben.html):
>7. Ein [``Pfad``](../../../05_Glossar.md#pfad) ist eine Wegbeschreibung zu einer Datei. Ein [``relativer Pfad``](../../../05_Glossar.md#relativer-pfad) geht vom Ordner der ``.exe`` aus (``bin/Debug/net10.0``), darum erreichen wir Dateien neben ``Program.cs`` mit ``"../../../datei.txt"``.
>8. ``File.Exists`` prüft, ob es die Datei gibt. ``File.ReadAllLines`` liefert jede Zeile als [``Element``](../../../05_Glossar.md#element) eines ``string[]`` – auch Leerzeilen und Kommentare. ``File.WriteAllLines`` schreibt jedes [``Element``](../../../05_Glossar.md#element) als eigene Zeile.
>9. Eine [``foreach-Schleife``](../../../05_Glossar.md#foreach-schleife) geht alle [``Elemente``](../../../05_Glossar.md#element) ohne [``Index``](../../../05_Glossar.md#index) durch. Eine [``for-Schleife``](../../../05_Glossar.md#for-schleife) nehmen wir nur, wenn wir den [``Index``](../../../05_Glossar.md#index) wirklich brauchen.

#### Wir merken uns von [Default- & Named Parameter](L03.4_defaultUndNamedParameter.html):
>10. Ein [``Default-Parameter``](../../../05_Glossar.md#default-parameter) (``int n = 10``) hat einen Standardwert und darf beim [``Aufruf``](../../../05_Glossar.md#aufruf) weggelassen werden. Er ersetzt „magische Zahlen“ im Code.
>11. Default-Parameter stehen **immer am Ende** der Parameterliste, Pflicht-Parameter davor.
>12. Argumente ohne Namen werden **der Reihe nach** auf die [``Parameter``](../../../05_Glossar.md#parameter) verteilt. Was fehlt, kommt aus dem Default.
>13. Mit einem [``Named Parameter``](../../../05_Glossar.md#named-parameter) (``n: 3``) nennen wir den Parameter beim Namen. So können wir Default-Parameter **überspringen**, und die Reihenfolge ist egal.
>14. Benannte Argumente machen Aufrufe lesbarer: ``ErzeugeUeberschrift("Ende", n: 3)`` statt einer Zahl ohne Bedeutung.

#### Wir merken uns von [Tuples](L03.4_defaultUndNamedParameter.html) (Tabs 4–6):
>15. Ein Tuple fasst mehrere Werte zusammen. **Ohne Namen** heißen die Teile ``Item1``, ``Item2``: ``var p = (3, 5); p.Item1``. **Mit Namen** – ein [``Named Tuple``](../../../05_Glossar.md#named-tuple) – schreiben wir ``(int x, int y) p = (3, 5);`` oder ``var p = (x: 3, y: 5);`` und greifen mit ``p.x`` zu.
>16. Die Namen gehören zum [``Typ``](../../../05_Glossar.md#typ) der [``Variable``](../../../05_Glossar.md#variable). Nur wenn ihr Typ Namen hat, gibt es ``p.x`` – ``Item1`` funktioniert immer.
>17. Tuples lassen sich **schachteln**: ``((int x, int y) start, (int x, int y) ziel) punkte``. Zugriff Punkt für Punkt nach innen: ``punkte.start.x``.
>18. ``var (a, b) = p;`` **zerlegt** ein Tuple in Variablen. ``==`` vergleicht **alle** Teile: ``start == ziel``.
>19. Ein Tuple ist ein [``Werttyp``](../../../05_Glossar.md#werttyp): ``=`` kopiert den ganzen Inhalt. Ein [``Array``](../../../05_Glossar.md#array) ist ein [``Referenztyp``](../../../05_Glossar.md#referenztyp): ``=`` kopiert nur die Adresse, beide Variablen zeigen auf dasselbe Array.
>20. Darum ist ein Tuple-[``Parameter``](../../../05_Glossar.md#parameter) eine **Kopie**: Eine [``Funktion``](../../../05_Glossar.md#funktion) kann das Original nicht ändern, sie muss das neue Tuple **zurückgeben** (``start = Verschoben(start);``).
>21. ``int.TryParse(text, out int zahl)`` liefert ``true``/``false``, die Zahl kommt über einen [``Ausgangsparameter``](../../../05_Glossar.md#ausgangsparameter).
>22. **Erwartbar fehlerhaft** → ``bool Try…(…, out …)``: direkt im ``if`` prüfbar und mit ``||`` verkettbar. **Mehrere Ergebnisse, die immer da sind** → Tuple zurückgeben.

#### Wir merken uns von [Distanz](L03.2_schachbrettEuklid.html) und [Distanz als Linie](L03.3_linieZeichnen.html):
>23. Die [``euklidische Distanz``](../../../05_Glossar.md#euklidische-distanz) ist die Luftlinie nach Pythagoras: ``Math.Sqrt(dx * dx + dy * dy)``.
>24. Bei einer [``Ganzzahldivision``](../../../05_Glossar.md#ganzzahldivision) ist ``4 / 5`` gleich ``0``. Mit einem [``Typecast``](../../../05_Glossar.md#typecasting) **vor** der Division gilt ``(double)4 / 5 = 0.8``.
>25. Eine [``mathematische Funktion``](../../../05_Glossar.md#mathematische-funktion) ordnet jedem ``x`` genau ein ``y`` zu: ``f(x) = k · x + d``. Eine [``Funktion``](../../../05_Glossar.md#funktion) im Programm ist ein benannter Codeblock mit [``Parametern``](../../../05_Glossar.md#parameter) und [``Rückgabewert``](../../../05_Glossar.md#rückgabewert). Die mathematische Funktion **berechnen** wir im Code in einer Zeile: ``int fx = …``.
>26. Im Gitter ist ``(0|0)`` oben links, ``x`` wächst nach rechts, ``y`` nach unten. Für jede Spalte ``x`` sagt die [``lineare Funktion``](../../../05_Glossar.md#lineare-funktion), in welcher Zeile die Linie liegt.
>27. ``f(x) = k · x`` startet in ``(0|0)``. Mit ``x − start.x`` schieben wir nach rechts, mit ``+ start.y`` nach unten. Bei einer Geraden reicht auch eine Verschiebung: ``k · x + d``.
>28. Bei steilen Linien gehen wir die **längere** Achse ab, sonst entstehen Lücken.
