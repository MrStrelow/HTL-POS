# SMÜ-config

## Kompetenzen
Die Kompetenzen sind nach Blooms taxonomy: Wissen, Verstehen, Anwenden, Analysieren, Bewerten, Entwickeln.
* Aufgabe 1 hat die Kompetenz Wissen und Verstehen.
* Aufgabe 2 (Lückentext) hat die Kompetenz Anwenden. Die Nebenfrage zu Aufgabe 2 hat die Kompetenz Analysieren.
* Aufgabe 3 (Fehler finden) hat die Kompetenz Analysieren.

## Stoff
Der Stoff für diese SMÜ befindet sich in Jahrgang 2 und Lektion L03 auf HTL-POS in Github bzw. auf C:/Users/Mathias Cammerlander/Documents/GitHub/HTL-POS. Grundlage ist JahrGang2/L03Files-StringMethoden/Skripten/L03-WirMerkenUns.md sowie das Live-Coding JahrGang2/LiveCoding/L03DistanzZeichnen. Bitte alles dort berücksichtigen, was zum Stoff passt. Ignoriere Projektdateien und compilierten Code wie bin, obj, slnx, proj, und ähnliches bei anderen Sprachen als C#.

Für die Linie wird **nur** der Achsenverschub in x und y verwendet und erwartet: ``xVerschoben = x - start.x`` und ``fx = start.y + (int)Math.Round(k * xVerschoben)`` (bei steilen Linien entsprechend mit x und y getauscht). Die Varianten mit einer einzigen Verschiebung – ``k · x + d`` (d ausrechnen) oder ``f(x + s)`` (s ausrechnen) – werden nicht geprüft und nicht erwartet.

Default-Parameter, Named Parameter sowie Try-Methoden mit out werden in dieser SMÜ **nicht** geprüft. Werden sie in einer Antwort verwendet, ist das kein Fehler.

## Nicht abziehen für
* Rechtschreibung, Formulierung und Handschrift, solange die Aussage verständlich ist.
* Fehlende Strichpunkte, Klammern oder Einrückung im Lückentext, wenn der Ausdruck eindeutig richtig gemeint ist.
* Gleichwertige Lösungen, z. B. ``Math.Pow(dx, 2)`` statt ``dx * dx``, ``(double)dy / dx`` mit vorher berechnetem *dy* und *dx*, ``Item1`` statt ``x`` beim Tuple, die Bedingung für ✅ in anderer Reihenfolge (``y == start.y && x == start.x``).
* In Aufgabe 3 eine andere Reihenfolge oder Nummerierung der Fehler. Ein zusätzlich genannter „Fehler“, der keiner ist, ist nur dann ein Fehler, wenn er den Code falsch macht.

## Musterlösung
Die Musterlösungen stehen in ``01_FilesStringsLinienGrpA-loesung.md`` und ``01_FilesStringsLinienGrpB-loesung.md`` im selben Ordner. Aufgabe 2 ist in beiden Gruppen gleich.
