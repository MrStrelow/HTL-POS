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
>10. Ein [``Default-Parameter``](../../../05_Glossar.md#default-parameter) (``int n = 10``) darf beim [``Aufruf``](../../../05_Glossar.md#aufruf) weggelassen werden und ersetzt „magische Zahlen“.

#### Wir merken uns von [Named Tuples & Distanz](L03.2_schachbrettEuklid.html) und [Distanz als Linie](L03.3_linieZeichnen.html):
>11. Ein [``Named Tuple``](../../../05_Glossar.md#named-tuple) fasst mehrere Werte mit Namen zusammen: ``(int x, int y) start``, Zugriff mit ``start.x``. So kann eine [``Funktion``](../../../05_Glossar.md#funktion) mehrere Werte zurückgeben.
>12. ``int.TryParse(text, out int zahl)`` liefert ``true``/``false``, die Zahl kommt über einen [``Ausgangsparameter``](../../../05_Glossar.md#ausgangsparameter).
>13. Die [``euklidische Distanz``](../../../05_Glossar.md#euklidische-distanz) ist die Luftlinie nach Pythagoras: ``Math.Sqrt(dx * dx + dy * dy)``.
>14. Bei einer [``Ganzzahldivision``](../../../05_Glossar.md#ganzzahldivision) ist ``4 / 5`` gleich ``0``. Mit einem [``Typecast``](../../../05_Glossar.md#typecasting) **vor** der Division gilt ``(double)4 / 5 = 0.8``.
>15. Im Gitter ist ``(0|0)`` oben links, ``x`` wächst nach rechts, ``y`` nach unten. Für jede Spalte ``x`` sagt eine [``lineare Funktion``](../../../05_Glossar.md#lineare-funktion), in welcher Zeile die Linie liegt.
>16. ``f(x) = k · x`` startet in ``(0|0)``. Mit ``x − start.x`` schieben wir nach rechts, mit ``+ start.y`` nach unten. Bei einer Geraden reicht auch eine Verschiebung: ``k · x + d``.
>17. Bei steilen Linien gehen wir die **längere** Achse ab, sonst entstehen Lücken.
