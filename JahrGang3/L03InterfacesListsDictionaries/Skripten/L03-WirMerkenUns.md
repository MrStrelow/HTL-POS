#### Wir merken uns von [Liste oder Dictionary?](L03.1_ListVsDictionary.html):

| | [``Liste``](../../../05_Glossar.md#liste) ``List<T>`` | ``Dictionary<TKey, TValue>`` |
|---|---|---|
| Zugriff über | **Position** (Index ``0 … Count-1``) | **Schlüssel** (Key) |
| Reihenfolge | ja, bleibt erhalten | keine, auf die man sich verlassen darf |
| Duplikate | erlaubt | Key nur **einmal**, Values dürfen doppelt sein |
| Create | ``Add(x)``, ``Insert(i, x)`` | ``TryAdd(k, v)``, ``Add(k, v)`` (wirft bei doppeltem Key), ``d[k] = v`` (überschreibt) |
| Read | ``l[i]``, ``Contains(x)``, ``IndexOf(x)`` | ``TryGetValue(k, out v)``, ``ContainsKey(k)``, ``d[k]`` (wirft, wenn es k nicht gibt) |
| Update | ``l[i] = x`` | ``d[k] = v`` |
| Delete | ``Remove(x)``, ``RemoveAt(i)`` | ``Remove(k)``, ``Remove(k, out v)`` |
| Suchen nach Inhalt | O(n) – alle durchgehen | O(1) – über den Hash direkt ins Fach |

>1. Eine [``Liste``](../../../05_Glossar.md#liste) nehmen wir, wenn die **Reihenfolge** zählt (Weg, Warteschlange, Verlauf). Ein ``Dictionary`` nehmen wir, wenn wir etwas über einen **eindeutigen Schlüssel nachschlagen** (MAC → Gerät, Name → Switch).
>2. ``List<T>`` ist intern ein **Array**, das bei Bedarf verdoppelt wird: Index und ``Add`` am Ende sind O(1), ``Insert``/``RemoveAt`` vorne sind O(n). Eine ``LinkedList<T>`` ist vorne und hinten O(1), hat aber keinen Index.
>3. Wir verwenden die ``Try…``-Methoden (``TryAdd``, ``TryGetValue``) statt erst zu prüfen und dann zuzugreifen – sie prüfen und handeln in **einem** Schritt.
>4. Liste und Dictionary speichern bei einer [``Klasse``](../../../05_Glossar.md#klasse) nur [``Referenzen``](../../../05_Glossar.md#referenz). Stehen dieselben [``Objekte``](../../../05_Glossar.md#objekt) in zwei Datenstrukturen, sieht man eine Änderung in **beiden**. Beim Löschen müssen wir aber in **beiden** entfernen.
>5. Nach außen geben wir ``IReadOnlyList<T>`` und ``IReadOnlyDictionary<TKey, TValue>`` zurück – so kann niemand an unserer Klasse vorbei einfügen.
>6. Während eines ``foreach`` darf die Liste nicht verändert werden (``InvalidOperationException``). Muss ich dabei entfernen, gehe ich über eine **Kopie**: ``new List<T>(liste)``.

#### Wir merken uns: Was passiert beim Hashen und in den Fächern (Buckets)?

| Schritt | Einfügen ``orte[6020] = "Innsbruck"`` | Suchen ``orte.ContainsKey(6020)`` |
|---|---|---|
| 1. Hash berechnen | ``6020.GetHashCode()`` → ``6020`` | genauso → ``6020`` |
| 2. Fach berechnen | ``6020 % 7`` → Fach ``0`` | genauso → Fach ``0`` |
| 3. im Fach | Key schon da (``Equals``)? → überschreiben, sonst anhängen | **nur** in Fach 0 mit ``Equals`` vergleichen |
| 4. Ergebnis | Hash wird mit dem Eintrag **gespeichert** | gefunden / nicht gefunden – ohne die anderen Fächer anzuschauen |

>1. ``GetHashCode`` macht aus dem Key eine ganze Zahl. Bei ``int`` ist der Hash die Zahl selbst. Der Hash eines ``string`` ist bei jedem Programmstart anders – man darf ihn nicht speichern.
>2. Ein ``Dictionary`` hat **nicht** ein Fach pro möglichem Hash (das wären über 4 Milliarden), sondern ungefähr **so viele Fächer wie Einträge**. Das Fach ist ``hash % anzahlFaecher``.
>3. Landen zwei Keys im selben Fach (**Kollision**, z. B. ``1010 % 7`` und ``8010 % 7`` sind beide 2), stehen beide im Fach. Dann entscheidet ``Equals``, welcher der gesuchte ist. Wenige Kollisionen → O(1).
>4. Das Fach wird **einmal** beim Einfügen berechnet und mit dem Hash gemerkt – das Dictionary rechnet es nie neu, solange es nicht wächst.
>5. **Wachsen:** Sind alle Fächer belegt (Einträge = Fächer), legt das Dictionary beim nächsten Einfügen ein neues Fächer-Array an – eine Primzahl, mindestens doppelt so groß (3 → 7 → 17 → 37 → 89 → …) – und sortiert **alle** Einträge mit dem neuen ``%`` neu ein (Rehashing, einmal O(n)). Im Schnitt bleibt Einfügen O(1).
>6. Weiß ich die Anzahl vorher, gebe ich die **Kapazität** im Konstruktor an: ``new Dictionary<string, Geraet>(1000)`` legt sofort genug Fächer an und muss nie umsortieren.

#### Wir merken uns: Was darf ein Key sein?

| Key-Typ | Zuweisung kopiert … | ``gleich`` heißt … | **immutable?** | als Key |
|---|---|---|---|---|
| [``Werttyp``](../../../05_Glossar.md#werttyp) ``int``, ``enum``, Tupel | den Wert | gleiche Werte | ✅ (eine Kopie kann niemand von außen ändern) | ✅ 1. Wahl |
| ``string`` | die [``Referenz``](../../../05_Glossar.md#referenz) | gleiche Werte | ✅ jede „Änderung“ liefert einen **neuen** string | ✅ 1. Wahl |
| ``record R(int X, int Y)`` (Kurzform) | die [``Referenz``](../../../05_Glossar.md#referenz) | gleiche Werte | ✅ Properties sind ``init``, „ändern“ mit ``with`` = neues Objekt | ✅ eigener Key-Typ |
| ``readonly record struct`` | den Wert | gleiche Werte | ✅ ``readonly`` | ✅ kleiner Key-Typ |
| ``class`` mit ``Equals`` + ``GetHashCode`` | die [``Referenz``](../../../05_Glossar.md#referenz) | gleiche Werte | nur wenn die verglichenen Properties nur ``{ get; }`` haben | ⚠️ aufwändig |
| ``class`` ohne ``Equals`` | die [``Referenz``](../../../05_Glossar.md#referenz) | **dasselbe Objekt** | egal – Hash hängt an der Identität | ⚠️ nur mit genau dieser Referenz auffindbar |
| ``class`` / ``record`` mit ``set`` | die [``Referenz``](../../../05_Glossar.md#referenz) | gleiche Werte | ❌ | ❌ Key verrutscht |

>1. Zwei Fragen auseinanderhalten: [``Werttyp``](../../../05_Glossar.md#werttyp) oder [``Referenztyp``](../../../05_Glossar.md#referenztyp)? (Was wird beim **Zuweisen** kopiert?) [``Wertsemantik``](../../../05_Glossar.md#werttypsemantik) oder [``Referenzsemantik``](../../../05_Glossar.md#referenztypsemantik)? (Was bedeutet **gleich**?)
>2. Ein ``record`` ist ein **Referenztyp mit Wertsemantik**: Zuweisung kopiert die Referenz, ``==`` vergleicht die Werte.
>3. **Immutable** heißt: Ein Objekt wird beim Erzeugen fertig befüllt und ändert sich danach **nie mehr**. Wer „ändern“ will, bekommt ein **neues** Objekt. Beim ``record`` ist ``a.X = 5`` ein Compilerfehler (CS8852), ``a with { X = 5 }`` baut eine Kopie. ``string`` funktioniert genauso: ``s[0] = 'W'`` geht nicht (CS0200), ``s.ToUpper()`` liefert einen neuen string.
>4. Beim **Suchen** fragt das Dictionary genau: *Ist dieser Key gleich?* Mit Wertsemantik findet ein **nachgebauter** Key (``new Position(0, 20)``) den Eintrag, mit Referenzsemantik nur **dieselbe** Referenz.
>5. Das Dictionary sucht in zwei Schritten: ``GetHashCode`` wählt das **Fach**, ``Equals`` vergleicht **nur in diesem Fach**. Darum überschreiben wir **immer beide** – aus **denselben** Properties. Was laut ``Equals`` gleich ist, **muss** denselben Hash haben.
>6. Einen eigenen Hash erfinden wir nicht: ``HashCode.Combine(X, Y)`` bei mehreren Properties, ``Mac.GetHashCode()`` bei einer. Ein ``record`` erzeugt beides automatisch.
>7. ``List.Contains`` und ``List.Remove`` verwenden **nur** ``Equals`` – ``Dictionary`` und ``HashSet`` brauchen ``Equals`` **und** ``GetHashCode``.

#### Wir merken uns: Was passiert, wenn sich ein Key ändert?

>1. Im Dictionary liegt nur eine **Referenz** auf den Key. Ändern wir das Objekt danach (``a.X = 5``), ändert sich auch der Key **im** Dictionary – aber der Eintrag bleibt im **alten** Fach liegen.
>2. Danach ist der Eintrag **unerreichbar**: Suchen mit dem neuen Wert landet im falschen Fach, Suchen mit dem alten Wert im richtigen Fach, aber ``Equals`` sagt nein. Auch ``Remove`` findet ihn nicht.
>3. Er ist aber noch **da**: ``Count`` zählt ihn, ``foreach`` findet ihn. ``karte[a] = …`` legt sogar einen **zweiten** Eintrag mit demselben Objekt an.
>4. Eine **Liste** hat dieses Problem nicht – sie hat keine Fächer, ``Contains`` vergleicht nur mit ``Equals``.
>5. **Grundregel:** Ein Key ist **immutable** – zumindest alles, was ``Equals`` und ``GetHashCode`` verwenden. Was sich ändern muss, gehört in den **Value** (``Geraet.PingMs``), nicht in den Key (``Mac``).
>6. Muss sich ein Key wirklich ändern: **herausnehmen** (solange der alte Hash noch stimmt), ändern, **neu einfügen**.

#### Wir merken uns von [Interfaces: Verträge statt Klassen](L03.2_Interfaces.html):

**Von der Klasse zum Interface**

| Schritt | | was übrig bleibt |
|---|---|---|
| normale Klasse | ``virtual`` Methoden mit Platzhaltern (``return 0;``) | ``new Sensor()`` geht – ergibt aber keinen Sinn |
| [``abstrakte Klasse``](../../../05_Glossar.md#abstrakte-klasse) | nur noch ``abstract`` Methoden und Properties | kein ``new`` mehr (CS0144), Unterklassen schreiben ``override`` |
| [``Interface``](../../../05_Glossar.md#interface) | nur noch die **Köpfe** – ohne ``public`` und ``abstract`` | ein reiner Vertrag, Klassen setzen ihn ohne ``override`` um |

**Interface oder abstrakte Klasse?**

| | abstrakte Klasse | Interface |
|---|---|---|
| Felder / Zustand | ✅ | ❌ CS0525 |
| Konstruktor | ✅ | ❌ CS0526 |
| abstrakte Methoden + Properties | ✅ mit ``abstract`` | ✅ automatisch ``public`` und ``abstract`` |
| fertiger Code für alle | ✅ | ❌ (Default-Methoden seit C# 8 – verwenden wir nicht) |
| in der Unterklasse | ``override`` (sonst CS0534) | einfach ``public`` (sonst CS0535 / CS0737) |
| wie viele? | genau **eine** [``Basisklasse``](../../../05_Glossar.md#basisklasse) (CS1721) | **beliebig viele** |
| für ``struct``? | ❌ CS0527 | ✅ |
| ``new`` | ❌ CS0144 | ❌ CS0144 |
| Beziehung | **ist-ein** | **kann** |

**Interfaces, die wir verwenden**

| [``Interface``](../../../05_Glossar.md#interface) | Methode | wer ruft auf? | wofür |
|---|---|---|---|
| ``IComparable<T>`` | ``CompareTo(other)`` | ``Sort()``, ``Min``, ``Max`` | die **eine** natürliche Ordnung, steht in der Klasse selbst |
| ``IComparer<T>`` | ``Compare(a, b)`` | ``Sort(vergleicher)`` | **beliebig viele** weitere Ordnungen, je eine eigene Klasse |
| ``IDisposable`` | ``Dispose()`` | ``using`` | Ressourcen (Dateien, Verbindungen) sicher freigeben |
| eigenes, z. B. ``ISensor``, ``IDistanz`` | ``Messen()``, ``Berechnen(a, b)`` | die Klasse, der es injiziert wurde | austauschbares Verhalten |

>1. Ein [``Interface``](../../../05_Glossar.md#interface) ist ein **Vertrag**: Es sagt, *was* eine Klasse kann, nicht *wie*. Eine Klasse, die es umsetzt, **muss** alle Methoden und [``Eigenschaften``](../../../05_Glossar.md#eigenschaft) schreiben. Von einem Interface kann man kein Objekt erzeugen, aber es als **Typ** einer Variable verwenden.
>2. Eine abstrakte Klasse, die **nur noch** abstrakte Methoden und Properties hat, ist eigentlich ein Interface. Gemeinsamer Zustand und Code → abstrakte Klasse, nur eine Fähigkeit → Interface.
>3. Eine **hat-Beziehung** ([``Assoziation``](../../../05_Glossar.md#assoziation)) ist in der Klasse immer ein **Feld**. Ein Interface hat **keine Felder** (CS0525), aber eine **Property** ist in Wahrheit ein Paar Methoden (``get_Sensor()``) – darum darf ein Interface sie verlangen.
>4. Ein Interface schreibt **Properties und Methoden gleichzeitig** vor: die Property für das, was ein Objekt **hat** (``ISensor Sensor { get; }``), die Methode für das, was es **tut** (``bool Pruefen();``). Erst mit beiden ist der Vertrag erfüllt. Muss niemand von außen an das Gehabte heran, bleibt die hat-Beziehung ein privates Feld und kommt gar nicht ins Interface.
>5. **Sortieren** ist kein Interface: ``Sort`` ist der Algorithmus und weiß nur, *wie* man sortiert. Die Frage „wer kommt zuerst?“ beantwortet ``IComparable`` (``Sort()``) oder ``IComparer`` (``Sort(new NachName())``). Gibt es keines von beiden → ``InvalidOperationException``.
>    * **Verschiedene Klassen gemischt sortieren** (``List<IGeraet>`` mit Router und Drucker): Das **Interface** erbt den Vertrag – ``interface IGeraet : IComparable<IGeraet>``. Steht ``IComparable<IGeraet>`` nur bei den Klassen, klappt ``router.CompareTo(drucker)``, aber ``Sort()`` wirft eine ``InvalidOperationException``, weil ``IGeraet`` selbst keine Vergleichbarkeit verspricht.
>6. ``CompareTo`` und ``Compare`` liefern: **< 0** vorher · **0** gleich · **> 0** nachher. ``int``, ``string`` und ``double`` haben schon ``CompareTo`` – wir geben es einfach weiter.
>7. Ein ``IComparer`` darf **Zustand** haben, z. B. ``new NachDistanzZu(ziel, distanz)``. Das kann ``CompareTo`` nicht.
>8. ``using`` ist eine Kurzschreibweise für ``try`` / ``finally { x.Dispose(); }``. ``Dispose`` läuft **immer** – auch bei einer [``Exception``](../../../05_Glossar.md#exception).
>9. **Gegen ein Interface programmieren:** Kennt eine Klasse nur ``ISensor`` statt ``Thermometer``, müssen wir sie bei einem neuen Sensor **nicht** umschreiben. Programmiere gegen das *Was*, nicht gegen das *Wie*.
>10. **Dependency Injection:** Eine Klasse erzeugt ihre Abhängigkeiten nicht selbst mit ``new``, sondern bekommt sie über den **Konstruktor** hineingegeben. Dadurch ist sie austauschbar und testbar (``FakeSensor``).
>11. **Inversion of Control** ist das Prinzip dahinter: Nicht die Klasse entscheidet, womit sie arbeitet oder wann ihr Code läuft. Alles wird an **einer** Stelle zusammengesteckt, dem **Composition Root** (``Program.cs``).
>12. IoC ist der **Oberbegriff**, DI ist **eine Technik** dafür. Auch ein **Rückruf** ist IoC: Wir rufen ``Sort()`` auf, aber ``Sort`` ruft **unser** ``CompareTo`` auf – „Don't call us, we call you“.
