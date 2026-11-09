# Antworten zu den Fragen

**Teil 2 – Warum eigene Eigenschaften in der ZutatLeerException?**
Mit ``Zutat``, ``Benoetigt`` und ``Vorhanden`` kann der Aufrufer im ``catch`` **gezielt** reagieren, z. B. mit ``when (ex.Zutat == "Milch")``, oder gezielt genau so viel nachfüllen, wie fehlt. Den Text der ``Message`` zu zerlegen wäre fehleranfällig. Der Text ist für Menschen gedacht, die Eigenschaften sind für das Programm.

**Teil 3 – Warum keine Exception beim Überlauf, aber bei menge = 0?**
Dass man zu viel nachschüttet, ist **erwartbar** und hat eine klare Lösung: Der Behälter wird voll, der Rest läuft über. Das ist ein normales Ergebnis und wird deshalb als Rückgabewert gemeldet. Eine Menge ≤ 0 ist dagegen ein **falscher Aufruf**: Der Aufrufer hat einen Fehler gemacht, den ``Auffuellen`` nicht sinnvoll beheben kann. Darum folgt eine ``ArgumentOutOfRangeException``.

**Teil 4 – Was passiert ohne vorheriges Prüfen?**
Bei einer Latte mit nur 50 ml Milch würden zuerst 50 ml Wasser und 9 g Bohnen **entnommen**. Erst danach würde die ``ZutatLeerException`` für die Milch geworfen. Wasser und Bohnen wären dann verbraucht, ohne dass ein Getränk entsteht. Deshalb wird zuerst alles geprüft und erst danach entnommen („alles oder nichts“).

**Teil 5a – Guard oder Exception?**
| Fall | Entscheidung | Begründung |
|---|---|---|
| Die Datei existiert nicht | **Exception** (``FileNotFoundException``), gefangen im Hauptprogramm, das danach mit ``return`` endet | Ohne Datei kann ``LeseBestellungen`` ihre Aufgabe gar nicht erfüllen und das Problem auch nicht selbst lösen. Das ist ein echter Ausnahmefall. Was dann passieren soll, entscheidet der Aufrufer. |
| Leerzeile oder Kommentar | **Guard**, still überspringen | Gehört zum Dateiformat, ist also der Normalfall und kein Fehler. |
| nicht genau 2 Spalten | **Guard**, Warnung und überspringen | In einer von Hand getippten Datei **erwartbar**. Die Methode kann ihre Aufgabe trotzdem erfüllen, denn die übrigen Zeilen sind brauchbar. |
| leerer Getränkename | **Guard**, Warnung und überspringen | ebenso erwartbar |
| Getränk nicht auf der Karte (``Tee``) | **gar nicht in ``LeseBestellungen`` prüfen** | Die Datei ist formal in Ordnung. Ob es ein Getränk gibt, weiß nur der **Kaffeeautomat** (seine ``Karte``). Er meldet es in ``SucheGetraenk`` mit einer ``ArgumentException``, die in Teil 5b gefangen wird. Würde ``LeseBestellungen`` die Karte prüfen, müsste sie den Automaten kennen, und die Kopplung wäre höher. |

Auch vertretbar: Eine kaputte Zeile als Exception zu melden, wenn die Datei z. B. von einem anderen Programm erzeugt wird und **nie** fehlerhaft sein dürfte. Entscheidend ist die Begründung: Ist der Fall erwartbar, und kann die Methode trotzdem weiterarbeiten?

**Teil 5b – Fragen**
1. Liefert der ``when``-Filter ``false``, gilt dieser ``catch``-Block als **nicht passend**. Die Exception wird an den **nächsten** passenden ``catch`` weitergereicht, hier an ``catch (ZutatLeerException)`` ohne Filter.
2. Die ``catch``-Blöcke werden von oben nach unten geprüft, und der **erste passende** gewinnt. Steht ``catch (ArgumentException)`` oben, fängt er auch jede ``ArgumentOutOfRangeException`` ab, weil sie davon erbt. Der speziellere Block darunter wäre nie erreichbar. Der Compiler meldet dafür sogar einen Fehler (CS0160).
3. Kann ein Problem durch das Beheben **nicht** gelöst werden, würde die Schleife dieselbe Bestellung endlos wiederholen. Ein Beispiel: Ein Getränk braucht mehr Milch, als der Tank fasst (Kapazität 300 ml, Bedarf 400 ml). ``MaxVersuche`` ist eine Sicherung gegen Fehler, die wir heute noch nicht kennen.

**Teil 6 – Parse oder TryParse? Warum prüft LeseMenge nicht auf positiv?**
Eine falsche Tastatureingabe ist **erwartbar**. Deshalb verwenden wir eine Kontrollstruktur mit ``int.TryParse`` in einer ``while``-Schleife und keine Exception. ``int.Parse`` mit ``try/catch`` würde funktionieren, nutzt aber Exceptions für den Normalfall. Ob eine Menge erlaubt ist, weiß nur der **Behälter**, denn er kennt seine Regeln. ``LeseMenge`` ist nur für das Einlesen zuständig. Diese Aufteilung bedeutet hohen Zusammenhalt und lose Kopplung.

**Teil 7b – Was passiert ohne PruefeMenge bei der Latte?**
``Entnehmen`` ruft selbst ``PruefeMenge`` auf, deshalb wird die ``ZutatLeerException`` trotzdem geworfen. Wasser und Bohnen sind dann aber **schon entnommen**, siehe die Antwort zu Teil 4. Der Status zeigt danach weniger Wasser und Bohnen, obwohl keine Latte entstanden ist.

**Teil 7 – Wo liegt die Änderung?**
| nach … | Working Directory | Staging Area |
|---|---|---|
| ``git add`` | ✔ | ✔ |
| ``git reset <datei>`` | ✔ (Datei noch geändert) | ✘ |
| ``git checkout -- <datei>`` | ✘ (Stand des letzten Commits) | ✘ |
