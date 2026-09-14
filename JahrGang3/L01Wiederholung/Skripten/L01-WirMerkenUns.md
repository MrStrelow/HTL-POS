>**Wir merken uns von [Arrays](L01.1-Arrays.md):** 
>1) Ein ``Array`` ist eine Ansammlung von ``Werten`` welche logisch zusammengehören. 
>2) Wir legen ein ``Array`` an indem wir nach dem ``Typ`` eine *eckige Klammer* schreiben.
>3) Wenn wir wissen welche ``Werte`` in ein ``Array`` kommen, schreiben wir nach dem ``Zuweisungsoperator`` *{ "Anna", "Ben" };*. 
>4) Wenn wir *nicht* wissen welche ``Werte`` in ein ``Array`` kommen, aber wie groß es sein soll, schreiben wir nach dem ``Zuweisungsoperator`` z.B. *new int[10];* wenn wir genau *10* ``Elemente`` haben wollen. 
>5) Ein einzelner ``Wert`` welcher sich in einem ``Array`` befindet, wird ``Element`` genannt. 
>6) Ein ``Array`` besitzt mehrere ``Indices``, welche uns erlauben auf eine Position zuzugreifen. 
>7) Wir greifen auf ein ``Element`` des ``Arrays`` zu indem wir eine *eckige Klammer* nach dem *Namen* der ``Variable`` schreiben.
>8) Der ``Index`` ist immer genau um *1* kleiner als die tatsächliche Position des Elements. 
>9)  Wenn ein ``Array`` mit einer ``For-Schleife`` durchlaufen wird, muss die ``Zählvariable`` bei *0* beginnen.
>10) Weitere ``Dimensionen`` können dem ``Array`` hinzugefügt werden indem wir ein *Komma* zwischen eckigen Klammern *int[,] personendaten;* schreiben.
>11) Wir betrachten bei einem ``2d-Array`` zuerst die y-Achse, dann die x-Achse bei Erstellung, Lese- und Schreibzugriffen.
>12) Die y-Achse zählt von oben nach unten mit positiven Zahlen und die x-Achse mit positiven Zahlen von links nach rechts. 
>13) Um ein ``2d-Array`` abzuarbeiten, benötigen wir für jede ``Dimension`` eine eigene Schleife. Zusammen sind diese ``verschachtelte Schleifen``.
>14) Wir können das ``Array`` mit der ``Methode`` *brett.GetLength(0)* fragen wie viele ``Elemente`` dieses in der ``DImension`` *0* hat. Gleiches gilt für ``Dimension`` *1* und *brett.GetLength(1)*.
>15) ``Arrays`` sind ``Verweistypen``. Reichen wir sie an eine ``Methode`` weiter, arbeitet diese stets auf den **originalen Daten**. Änderungen innerhalb der Methode sind sofort überall im Programm darüber wirksam.
>16) Ein ``Seiteneffekt`` beschreibt eine nicht direkt Sichtbare Änderung von ``Variablen``.

>**Wir merken uns von [TricksMitParametern](L01.2-TricksMitParameterVonMethoden.md):** 
>1) 