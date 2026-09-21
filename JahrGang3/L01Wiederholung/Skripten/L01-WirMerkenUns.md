>**Wir merken uns von [Arrays](L01.1-Arrays.md):** 
>1) Ein ``Array`` ist eine Ansammlung von ``Werten`` welche logisch zusammengehören. 
>4) Ein einzelner ``Wert`` welcher sich in einem ``Array`` befindet, wird ``Element`` genannt. 
>5) Ein ``Array`` besitzt mehrere ``Indices``, welche uns erlauben auf eine Position zuzugreifen. 
>6) Der ``Index`` ist immer genau um *1* kleiner als die tatsächliche Position des Elements. 
>7) Wenn ein ``Array`` mit einer ``For-Schleife`` durchlaufen wird, ist es einfacher wenn die ``Zählvariable`` bei *0* beginnt.
>8) Weitere ``Dimensionen`` können dem ``Array`` hinzugefügt werden indem wir ein *Komma* zwischen eckigen Klammern *int[,] personendaten;* schreiben.
>9) Wir betrachten bei einem ``2d-Array`` zuerst die y-Achse, dann die x-Achse bei Erstellung, Lese- und Schreibzugriffen.
>10) Die y-Achse zählt von oben nach unten mit positiven Zahlen und die x-Achse mit positiven Zahlen von links nach rechts. 
>11) Um ein ``2d-Array`` abzuarbeiten, benötigen wir für jede ``Dimension`` eine eigene Schleife. Zusammen sind diese ``verschachtelte Schleifen``.
>12) Wir können das ``Array`` mit der ``Methode`` *brett.GetLength(0)* fragen wie viele ``Elemente`` dieses in der ``Dimension`` *0* hat. Gleiches gilt für ``Dimension`` *1* und *brett.GetLength(1)*.

<!-- >6) Wir greifen auf ein ``Element`` des ``Arrays`` zu indem wir eine *eckige Klammer* nach dem *Namen* der ``Variable`` schreiben. -->
<!-- >2) Wir legen ein ``Array`` an indem wir nach dem ``Typ`` eine *eckige Klammer* schreiben. -->
<!-- >3) Wenn wir wissen welche ``Werte`` in ein ``Array`` kommen, schreiben wir nach dem ``Zuweisungsoperator`` *{ "Anna", "Ben" };*.  -->
<!-- >4) Wenn wir *nicht* wissen welche ``Werte`` in ein ``Array`` kommen, aber wie groß es sein soll, schreiben wir nach dem ``Zuweisungsoperator`` z.B. *new int[10];* wenn wir genau Platz für *10* ``Elemente`` haben wollen.  -->
<!-- >15) ``Arrays`` sind ``Verweistypen``. Reichen wir sie an eine ``Methode`` weiter, arbeitet diese stets auf den **originalen Daten**. Änderungen innerhalb der Methode sind sofort überall im Programm darüber wirksam. -->
<!-- >16) Ein ``Seiteneffekt`` beschreibt eine nicht direkt Sichtbare Änderung von ``Variablen``. -->

>**Wir merken uns zu [Klassendiagrammen](L01.2-KlassenUndObjekte-UML.md):**
>1) Eine ``Klasse`` ist ein Bauplan für ein ``Objekt`` und ein ``Objekt`` ist eine ``Instanz`` der ``Klasse``. >2. Ein [``Klassendiagramm``](../../../05_Glossar.md#klassendiagramm) stellt dar welche [``Klassen``](../../../05_Glossar.md#klasse) in unserer [``Domäne``](../../../05_Glossar.md#domäne) existieren und wie diese miteinander in Verbindung stehen. Weiters werden die [``Mitglieder``](../../../05_Glossar.md#mitglied) einer [``Klasse``](../../../05_Glossar.md#klasse) sichtbar gemacht.
>2. Eine [``Klasse``](../../../05_Glossar.md#klasse) ist der Bauplan für ein [``Objekt``](../../../05_Glossar.md#objekt) und beschreibt den [``Zustand``](../../../05_Glossar.md#zustand) und das [``Verhalten``](../../../05_Glossar.md#verhalten) eines [``Objektes``](../../../05_Glossar.md#objekt).
>3. Ein [``Objekt``](../../../05_Glossar.md#objekt) ist ein konkretes *Individuum* und wird als [``Instanz``](../../../05_Glossar.md#instanziierung) einer [``Klasse``](../../../05_Glossar.md#klasse) bezeichnet. 
>4. Ein [``Objekt``](../../../05_Glossar.md#objekt) wird durch [``Instanziierung``](../../../05_Glossar.md#instanziierung) mit dem [``Schlüsselwort``](../../../05_Glossar.md#schlüsselwort) `new` und dem Aufruf eines [``Konstruktors``](../../../05_Glossar.md#konstruktor) aus der [``Klasse``](../../../05_Glossar.md#klasse) physisch im *Arbeitsspeicher* angelegt.
>5. Ein [``Objekt``](../../../05_Glossar.md#objekt) besteht aus [``Eigenschaften``](../../../05_Glossar.md#eigenschaft)/[``Feldern``](../../../05_Glossar.md#feld) für dessen [``Zustand``](../../../05_Glossar.md#zustand) und [``Methoden``](../../../05_Glossar.md#methode) für dessen Verhalten. Wir nennen diese Bestandteile zusammen [``Mitglieder``](../../../05_Glossar.md#mitglied).
>6. Jedes [``Objekt``](../../../05_Glossar.md#objekt) besitzt eine eindeutige [``Identität``](../../../05_Glossar.md#identität). Selbst wenn zwei [``Objekte``](../../../05_Glossar.md#objekt) den exakt gleichen [``Zustand``](../../../05_Glossar.md#zustand) haben, sind es zwei völlig unabhängige *Individuen*.
>7. Eine [``Klasse``](../../../05_Glossar.md#klasse) wird mithilfe eines [``Typen``](../../../05_Glossar.md#typ) in C# umgesetzt und ein [``Objekt``](../../../05_Glossar.md#objekt) mithilfe einer [``Variable``](../../../05_Glossar.md#variable).
>8. Wir nutzen eine [``Assoziation``](../../../05_Glossar.md#assoziation) ([``Hat-Beziehung``](../../../05_Glossar.md#assoziation)) um *Aufgaben* an andere [``Objekte``](../../../05_Glossar.md#objekt) zu *delegieren*. Der Hamster *delegiert* z. B. die Frage "Ist das Feld vor mir leer?" an das Spielfeld.
>9. ``Objekte`` brauchen theoretisch keine ``Klassen``, aber in C# muss jedes ``Objekt`` zwingend aus einer ``Klasse`` instanziiert werden.
>10 Ein ``Objekt`` besteht aus ``Eigenschaften``/``Feldern`` für dessen ``Zustand`` und ``Methoden`` für dessen Verhalten. Wir nennen diese zusammen ``Mitglieder``.
>11. Wir nutzen eine ``Assoziation`` (``Hat-Beziehung``) um *Aufgaben* an andere ``Objekte`` zu *delegieren*.
>12. Ein ``Objekt`` *delegiert* Arbeit an ein anderes ``Objekt`` unter der Verwendung der ``Methoden`` des anderen ``Objektes``. Das Ergebnis bekommen wir, ohne zu wissen, wie es im Detail erledigt wurde.
>13. Wenn nur ein ``Objekt`` das andere kennt, ist die Beziehung ``unidirektional``. Wenn beide sich kennen, ist sie ``bidirektional``.

<!-- >7) Wir schreiben ``Multiplizitäten`` an die Linien im UML-Diagramm, um zu zeigen, wie viele ``Objekte`` beteiligt sind (z.B. *1* oder *0..**).
>8) Eine ``unidirektionale`` Beziehung auf ``Objektebene`` bedeutet ``Objekt`` A kennt ``Objekt`` B, aber ``Objekt`` B kennt dasselbe ``Objekt`` A nicht.
>9) Eine ``unidirektionale`` Beziehung auf ``Klassenebene`` bedeutet ``Klasse`` A kennt ``Klasse`` B, aber ``Klasse`` B kennt ``Klasse`` A nicht.
>10) Eine ``bidirektionale`` Beziehung auf ``Objektebene`` bedeutet ``Objekt`` A kennt ``Objekt`` B, und ``Objekt`` B kennt das Selbe ``Objekt`` A.
>11) Eine ``bidirektionale`` Beziehung auf ``Klassenebene`` bedeutet ``Klasse`` A kennt ``Klasse`` B, und ``Klasse`` B kennt ``Klasse`` A.  -->


>**Wir merken uns zu Klassen und Objekten in C#:** 
>1) Eine ``Assoziation`` wird in C# mit einem ``Feld`` oder einer ``Eigenschaft`` umgesetzt.
>1) Wir nutzen ``Konstruktoren``, um beim Erstellen mit *new* den Startzustand des ``Objekts`` festzulegen.
>2) Wir steuern die Sichtbarkeit mit ``public`` (überall), ``private`` (nur in der eigenen Klasse) und ``protected`` (eigene und abgeleitete Klassen).
>3) Eine ``Eigenschaft`` ist ein *Hybrid* aus ``Feld`` und ``Methode``.
>4) Wir greifen bei ``Eigenschaften`` mit *get* und *set* auf diese *kontrolliert* zu. 
>7) Wir verstecken ``Felder`` mit *private* (``Data Hiding``) und erlauben den Zugriff auf diese nur kontrolliert über ``Methoden`` oder ``Properties`` (``Kapselung``).
>8) ``Data Hiding`` + ``Kapselung`` = ``Datenabstraktion``.
>9) ``Datenabstraktion`` bedeutet wir zeigen nach außen nur *was* man machen kann, aber nicht *wie* es intern funktioniert.
<!-- >2) Ein ``Copy-Konstruktor`` erstellt ein neues ``Objekt`` basierend auf einem bestehenden. Es ist das *Gleiche* aber nicht das *Selbe*. -->
<!-- >5) Bei ``Full Properties`` schreiben wir das ``Backing Field`` selbst, bei ``Auto Properties`` erstellt der Compiler dieses Feld unsichtbar für uns. -->
<!-- >6) Ab .NET 10 greifen wir bei bestimmten Properties mit dem Schlüsselwort ``field`` direkt auf dieses unsichtbare Feld zu und benötigen kein explizit geschriebenes ``Backing Field`` mehr. -->
<!-- >10) Der ``Zusammenhalt`` einer ``Klasse`` beschreibt, wie gut die ``Mitglieder`` innerhalb einer ``Klasse`` "logisch" bei der Erfüllung *einer einzigen Aufgabe* zusammenpassen. ``Zusammenhalt`` hoch: Eine Klasse kümmer sich *nur* um das Bewegugnsverhalten eines *Hamsters*. ``Zusammenhalt`` niedrig: Eine Klasse kümmert sich um Bewegugnsverhalten, UI, Datenbank und Logik eines *Hamsters* gleichzeitig.  -->
<!-- >11) Die ``Kopplung`` eines ``Objektes`` beschreibt, wie stark verschiedene ``Objekte`` voneinander abhängen. Der *Hamser* muss umprogrammiert werden sobald sich der code der ``Plane`` ändert. Z.B. wir verwenden image 2D-Array, statt einem string 2D-Array. Beide sind gekoppelt und sind wartungsintensiver. Eine gute ``Kapselung`` verringert die ``Kopplung``. -->

>**Wir merken uns von [TricksMitParametern](L01.2-TricksMitParameterVonMethoden.md):** 
>1) 