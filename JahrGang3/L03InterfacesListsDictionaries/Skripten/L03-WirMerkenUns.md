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
>3. Ein ``Dictionary`` rechnet aus dem Key einen **Hash** und daraus das **Fach**: ``fach = hash % anzahlFaecher``. Landen zwei Keys im selben Fach (Kollision), entscheidet ``Equals``.
>4. Ein ``Dictionary`` hat ungefähr **so viele Fächer wie Einträge**. Ist es voll, wächst es auf eine Primzahl ≥ doppelt so groß (3 → 7 → 17 → 37 → …) und sortiert **alle** Einträge neu ein. Weiß ich die Anzahl vorher, gebe ich die **Kapazität** im Konstruktor an: ``new Dictionary<string, Geraet>(1000)``.
>5. Wir verwenden die ``Try…``-Methoden (``TryAdd``, ``TryGetValue``) statt erst zu prüfen und dann zuzugreifen – sie prüfen und handeln in **einem** Schritt.
>6. Liste und Dictionary speichern bei einer [``Klasse``](../../../05_Glossar.md#klasse) nur [``Referenzen``](../../../05_Glossar.md#referenz). Stehen dieselben [``Objekte``](../../../05_Glossar.md#objekt) in zwei Datenstrukturen, sieht man eine Änderung in **beiden**. Beim Löschen müssen wir aber in **beiden** entfernen.
>7. Nach außen geben wir ``IReadOnlyList<T>`` und ``IReadOnlyDictionary<TKey, TValue>`` zurück – so kann niemand an unserer Klasse vorbei einfügen.
>8. Während eines ``foreach`` darf die Liste nicht verändert werden (``InvalidOperationException``). Muss ich dabei entfernen, gehe ich über eine **Kopie**: ``new List<T>(liste)``.

#### Wir merken uns: Was darf ein Key sein?

| | Zuweisung kopiert … | ``gleich`` heißt … | als Key |
|---|---|---|---|
| [``Werttyp``](../../../05_Glossar.md#werttyp) ``int``, ``enum``, Tupel, ``readonly struct`` | den Wert | gleiche Werte | ✅ 1. Wahl |
| ``string`` | die [``Referenz``](../../../05_Glossar.md#referenz) | gleiche Werte | ✅ 1. Wahl |
| ``record R(int X, int Y)`` | die [``Referenz``](../../../05_Glossar.md#referenz) | gleiche Werte | ✅ eigener Key-Typ |
| ``class`` mit ``Equals`` + ``GetHashCode`` über unveränderliche Properties | die [``Referenz``](../../../05_Glossar.md#referenz) | gleiche Werte | ⚠️ aufwändig |
| ``class`` ohne ``Equals`` | die [``Referenz``](../../../05_Glossar.md#referenz) | **dasselbe Objekt** | ⚠️ nur mit genau dieser Referenz auffindbar |
| alles mit ``set`` | – | – | ❌ Key verrutscht |

>1. Zwei Fragen auseinanderhalten: [``Werttyp``](../../../05_Glossar.md#werttyp) oder [``Referenztyp``](../../../05_Glossar.md#referenztyp)? (Was wird beim **Zuweisen** kopiert?) [``Wertsemantik``](../../../05_Glossar.md#werttypsemantik) oder [``Referenzsemantik``](../../../05_Glossar.md#referenztypsemantik)? (Was bedeutet **gleich**?)
>2. Ein ``record`` ist ein **Referenztyp mit Wertsemantik**: Zuweisung kopiert die Referenz, ``==`` vergleicht die Werte. Er ist unveränderlich, „ändern“ erzeugt mit ``with`` ein neues Objekt.
>3. Beim **Suchen** fragt das Dictionary genau: *Ist dieser Key gleich?* Mit Wertsemantik findet ein **nachgebauter** Key (``new Position(0, 20)``) den Eintrag, mit Referenzsemantik nur **dieselbe** Referenz.
>4. Das Dictionary sucht in zwei Schritten: ``GetHashCode`` wählt das **Fach**, ``Equals`` vergleicht **nur in diesem Fach**. Darum überschreiben wir **immer beide** – aus **denselben** Properties. Was laut ``Equals`` gleich ist, **muss** denselben Hash haben.
>5. Einen eigenen Hash erfinden wir nicht: ``HashCode.Combine(X, Y)`` bei mehreren Properties, ``Mac.GetHashCode()`` bei einer. Ein ``record`` erzeugt beides automatisch.
>6. Ein Key darf sich **nie** ändern. Ändert er sich nach dem Einfügen, liegt er im falschen Fach und wird nicht mehr gefunden.
>7. ``List.Contains`` und ``List.Remove`` verwenden **nur** ``Equals`` – ``Dictionary`` und ``HashSet`` brauchen ``Equals`` **und** ``GetHashCode``.

#### Wir merken uns von [Interfaces: Verträge statt Klassen](L03.2_Interfaces.html):

| [``Interface``](../../../05_Glossar.md#interface) | Methode | wer ruft auf? | wofür |
|---|---|---|---|
| ``IComparable<T>`` | ``CompareTo(other)`` | ``Sort()``, ``Min``, ``Max`` | die **eine** natürliche Ordnung, steht in der Klasse selbst |
| ``IComparer<T>`` | ``Compare(a, b)`` | ``Sort(vergleicher)`` | **beliebig viele** weitere Ordnungen, je eine eigene Klasse |
| ``IDisposable`` | ``Dispose()`` | ``using`` | Ressourcen (Dateien, Verbindungen) sicher freigeben |
| eigenes, z. B. ``ISensor``, ``IDistanz`` | ``Messen()``, ``Berechnen(a, b)`` | die Klasse, der es injiziert wurde | austauschbares Verhalten |

>1. Ein [``Interface``](../../../05_Glossar.md#interface) ist ein **Vertrag**: Es sagt, *was* eine Klasse kann, nicht *wie*. Eine Klasse, die es umsetzt, **muss** alle Methoden und [``Eigenschaften``](../../../05_Glossar.md#eigenschaft) schreiben. Von einem Interface kann man kein Objekt erzeugen, aber es als **Typ** einer Variable verwenden.
>2. Eine Klasse hat genau **eine** [``Basisklasse``](../../../05_Glossar.md#basisklasse) (**ist-ein**), aber **beliebig viele** Interfaces (**kann**). Gemeinsamer Zustand und Code → [``abstrakte Klasse``](../../../05_Glossar.md#abstrakte-klasse), nur eine Fähigkeit → Interface.
>3. Eine **hat-Beziehung** ([``Assoziation``](../../../05_Glossar.md#assoziation)) ist in der Klasse immer ein **Feld**. Ein Interface hat **keine Felder** (CS0525). Es kann eine hat-Beziehung nur über eine **Property** (``Position Position { get; }``) oder eine Methode verlangen. Muss niemand von außen darauf zugreifen, gehört die hat-Beziehung gar nicht ins Interface.
>4. **Sortieren** ist kein Interface: ``Sort`` ist der Algorithmus und weiß nur, *wie* man sortiert. Die Frage „wer kommt zuerst?“ beantwortet ``IComparable`` (``Sort()``) oder ``IComparer`` (``Sort(new NachName())``). Gibt es keines von beiden → ``InvalidOperationException``.
>5. ``CompareTo`` und ``Compare`` liefern: **< 0** vorher · **0** gleich · **> 0** nachher. ``int``, ``string`` und ``double`` haben schon ``CompareTo`` – wir geben es einfach weiter.
>6. Ein ``IComparer`` darf **Zustand** haben, z. B. ``new NachDistanzZu(ziel, distanz)``. Das kann ``CompareTo`` nicht.
>7. ``using`` ist eine Kurzschreibweise für ``try`` / ``finally { x.Dispose(); }``. ``Dispose`` läuft **immer** – auch bei einer [``Exception``](../../../05_Glossar.md#exception).
>8. **Gegen ein Interface programmieren:** Kennt eine Klasse nur ``ISensor`` statt ``Thermometer``, müssen wir sie bei einem neuen Sensor **nicht** umschreiben. Programmiere gegen das *Was*, nicht gegen das *Wie*.
>9. **Dependency Injection:** Eine Klasse erzeugt ihre Abhängigkeiten nicht selbst mit ``new``, sondern bekommt sie über den **Konstruktor** hineingegeben. Dadurch ist sie austauschbar und testbar (``FakeSensor``).
>10. **Inversion of Control** ist das Prinzip dahinter: Nicht die Klasse entscheidet, womit sie arbeitet oder wann ihr Code läuft. Alles wird an **einer** Stelle zusammengesteckt, dem **Composition Root** (``Program.cs``).
>11. IoC ist der **Oberbegriff**, DI ist **eine Technik** dafür. Auch ein **Rückruf** ist IoC: Wir rufen ``Sort()`` auf, aber ``Sort`` ruft **unser** ``CompareTo`` auf – „Don't call us, we call you“.
