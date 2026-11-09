#### Wir merken uns von [Git als Linked List & Zeitspeicher](L02.0Git-part-1.html):
>1. [``Git``](../../../05_Glossar.md#git) speichert die Geschichte unseres Projekts als Kette von ``Commits``. Jeder ``Commit`` ist ein Knoten, der die Änderungen (*Diff*) und eine [``Referenz``](../../../05_Glossar.md#referenz) auf seinen Vorgänger (*Parent*) speichert – wie eine *Linked List*.
>2. ``HEAD`` ist ein Zeiger auf den ``Commit``, auf dem wir gerade arbeiten. Nach jedem neuen ``Commit`` wandert ``HEAD`` auf diesen neuen Knoten weiter.
>3. Bevor wir Befehle ausführen, wechseln wir im Terminal mit *cd* in den Projektordner. Dort liegt im versteckten Ordner *.git* unser lokales ``Repository``.
>4. Eine Datei durchläuft drei Bereiche: ``Working Directory`` (unsere Dateien auf der Festplatte), ``Staging Area`` (der *Packtisch* für den nächsten ``Commit``) und ``Repository`` (die gespeicherten ``Commits``).
>5. *git status* zeigt uns, in welchem Bereich welche Datei liegt: *rot* bedeutet geändert, aber nicht gestaged, *grün* bedeutet gestaged.
>6. *git add Datei.cs* legt gezielt **eine** Datei auf den Packtisch. *git add -A* legt **alle** geänderten, neuen und gelöschten Dateien auf einmal darauf.
>7. *git commit -m "..."* erzeugt aus dem Inhalt der ``Staging Area`` einen neuen Knoten. Die Nachricht ist ein kurzer Satz, der mit einem Verb im Imperativ beginnt und sagt, *was* der ``Commit`` tut, z. B. *"Fuege AchsbruchException hinzu"*.
>8. *git log --oneline* zeigt die Kette der ``Commits`` vom neuesten zum ältesten.
>9. Neue ``Commits`` existieren zuerst nur **lokal**. Das ``Remote Repository`` am Server heißt *origin*, dessen Stand zeigt der Zeiger *origin/main*.
>10. *git push* vergleicht die lokale Kette mit der am Server, überträgt die fehlenden Knoten und zieht *origin/main* nach.
>11. *git reset Datei.cs* nimmt eine Datei von der ``Staging Area`` zurück ins ``Working Directory`` (*Unstage*). Die Änderung in der Datei bleibt **erhalten**.
>12. *git checkout -- Datei.cs* überschreibt die Datei im ``Working Directory`` mit dem Stand des letzten ``Commits``. Die ungespeicherte Änderung ist danach **unwiderruflich** weg, denn sie war nie in einem ``Commit``.
>13. Erst *git reset*, dann *git checkout*: So entfernen wir eine versehentlich gestagte, kaputte Änderung vollständig.

#### Wir merken uns von [Exceptions vs. Kontrollstrukturen](L02.1Exceptions.html):
>1. Eine ``Exception`` ist ein [``Objekt``](../../../05_Glossar.md#objekt), das einen **echten Ausnahmefall** beschreibt. Sie wird verwendet, wenn eine [``Methode``](../../../05_Glossar.md#methode) ihre Aufgabe nicht erfüllen kann und das Problem **selbst nicht lösen** kann.
>2. Mit dem [``Schlüsselwort``](../../../05_Glossar.md#schlüsselwort) *throw* werfen wir eine ``Exception``, z. B. *throw new InvalidOperationException("...")*. Die [``Methode``](../../../05_Glossar.md#methode) bricht sofort ab, und die ``Exception`` wandert zur aufrufenden [``Methode``](../../../05_Glossar.md#methode) zurück.
>3. Der *try*-Block umschließt Code, in dem eine ``Exception`` auftreten kann. Tritt eine auf, werden alle weiteren Zeilen im *try*-Block **übersprungen**.
>4. Der *catch*-Block fängt eine passende ``Exception`` auf. In der Variable *ex* stecken alle Informationen über den Fehler, z. B. *ex.Message*. Der *catch*-Block wird nur betreten, wenn im *try*-Block tatsächlich ein passender Fehler geworfen wurde.
>5. Der *finally*-Block wird **immer** ausgeführt: egal ob alles gut ging, ein Fehler behandelt wurde oder ein *return* im *try* oder *catch* stand. Wir verwenden ihn, um Ressourcen wie Dateien, Verbindungen oder Ports sicher wieder freizugeben.
>6. Wir werfen immer die **passendste** ``Exception``: *ArgumentNullException* (ein Argument ist *null*), *ArgumentOutOfRangeException* (ein Wert liegt außerhalb des gültigen Bereichs), *ArgumentException* (ein Argument ist falsch), *InvalidOperationException* (das [``Objekt``](../../../05_Glossar.md#objekt) ist im falschen Zustand) oder *FileNotFoundException* (eine Datei fehlt).
>7. C# prüft die *catch*-Blöcke von oben nach unten, und der **erste passende** gewinnt. Deshalb sortieren wir von der speziellsten [``Klasse``](../../../05_Glossar.md#klasse) (oben) zur allgemeinsten [``Basisklasse``](../../../05_Glossar.md#basisklasse) (unten). Ein Beispiel: *ArgumentOutOfRangeException* steht vor *ArgumentException*, und diese steht vor *Exception*.
>8. Mit *when* fangen wir eine ``Exception`` nur dann, wenn zusätzlich eine Bedingung erfüllt ist (*Exception Filter*), z. B. *catch (ZutatLeerException ex) when (ex.Zutat == "Milch")*. Liefert *when* den Wert *false*, wird der nächste passende *catch*-Block geprüft.
>9. *catch (Exception ex)* darf höchstens als **letztes** Fangnetz stehen. Steht er weiter oben, kann kein *catch*-Block darunter je erreicht werden, und der Compiler meldet den Fehler *CS0160*.
>10. Wollen wir einen Fehler nach dem Protokollieren weiterreichen, schreiben wir *throw;*. Mit *throw ex;* geht der ursprüngliche *StackTrace* (wo der Fehler wirklich passiert ist) verloren.
>11. Anti-Patterns vermeiden wir:
>       1. *throw new Exception(...)*: Der Aufrufer kann die Fehler nicht mehr unterscheiden.
>       2. *catch (Exception) { }* („Pokémon-Catch“): Damit werden echte Programmierfehler versteckt.
>       3. *throw ex;*: Der *StackTrace* geht verloren.
>12. Eine eigene ``Exception`` ist eine [``Klasse``](../../../05_Glossar.md#klasse), die von *Exception* erbt (*: Exception*) und deren Name auf *...Exception* endet. Den Fehlertext reichen wir im [``Konstruktor``](../../../05_Glossar.md#konstruktor) mit *: base(nachricht)* an die [``Basisklasse``](../../../05_Glossar.md#basisklasse) weiter.
>13. Eine eigene ``Exception`` kann zusätzliche [``Eigenschaften``](../../../05_Glossar.md#eigenschaft) haben, z. B. *GemesseneGrad*. So bekommt der Aufrufer im *catch* genaue Messwerte und kann **gezielt** reagieren.
>14. *ex.Message* liefert nur den kurzen Fehlertext für Benutzer:innen. *ex.StackTrace* zeigt die Aufrufkette mit Methodennamen und Zeilennummern. *ex.ToString()* kombiniert Typ, Nachricht und *StackTrace* und ist das Standardformat für Logdateien.
>15. Fehlermeldungen heben wir mit *Console.ForegroundColor = ConsoleColor.Red;* hervor. Danach rufen wir **immer** *Console.ResetColor();* auf.
>16. Ein **erwartbarer Fall** wird mit einer [``Kontrollstruktur``](../../../05_Glossar.md#kontrollstruktur) (*if*, *while*, *bool*) gelöst, **nicht** mit einer ``Exception``. Beispiele sind ein Tippfehler bei einer Eingabe, ein Stein am Spielfeld oder der Rand des Spielfelds.
>17. Gibt es eine *Try...*-[``Methode``](../../../05_Glossar.md#methode) (*int.TryParse*, *double.TryParse*), verwenden wir sie statt *Parse* im *try-catch*. Sie liefert *true* oder *false* und schreibt das Ergebnis über *out* in eine Variable. Eine ``Exception`` zu werfen dauert ein Vielfaches länger als eine *if*-Abfrage.
>18. Einen **echten Ausnahmefall** (z. B. einen Achsbruch) behandeln wir im *catch* auf eine von zwei Arten:
>       1. **Nicht behebbar:** Wir protokollieren mit *File.AppendAllText(datei, text)* (Zeitpunkt mit *DateTime.Now* und *ex.ToString()*) und stoppen kontrolliert.
>       2. **Behebbar:** Wir protokollieren und reparieren den Zustand (*Kompensation*), z. B. indem wir das defekte [``Objekt``](../../../05_Glossar.md#objekt) durch ein neues ersetzen.

#### Wir merken uns von [Generics](L02.2Generics.html):
>1. Mit ``Generics`` schreiben wir eine [``Klasse``](../../../05_Glossar.md#klasse) oder [``Methode``](../../../05_Glossar.md#methode) **nur einmal** für beliebige ``Typen``. Der ``Typparameter`` *T* ist ein Platzhalter, der erst bei der Verwendung festgelegt wird, z. B. *DoublyLinkedList&lt;int&gt;* oder *DoublyLinkedList&lt;string&gt;*.
>2. Eine generische [``Collection``](../../../05_Glossar.md#collection) wie *DoublyLinkedList&lt;T&gt;* speichert Knoten mit *Data* vom ``Typ`` *T* und den [``Referenzen``](../../../05_Glossar.md#referenz) *Prev* und *Next*.
>3. Bei ``Werttypen`` wie *int* verhindern ``Generics`` teures *Boxing/Unboxing* (das Ein- und Auspacken in ein *object*).
>4. Ohne Einschränkung weiß der Compiler über *T* nur, was *System.Object* kann. Mit einer ``Typ-Restriktion`` (*where*) legen wir fest, welche ``Typen`` für *T* erlaubt sind. Ein Beispiel: Nach *where T : Waggon* können wir in der [``Klasse``](../../../05_Glossar.md#klasse) sicher auf alle [``Eigenschaften``](../../../05_Glossar.md#eigenschaft) von *Waggon* zugreifen.
>5. ``Typ-Restriktionen`` lassen sich kombinieren:
>       1. *where T : class* erlaubt nur ``Referenztypen``.
>       2. *where T : struct* erlaubt nur ``Werttypen``.
>       3. *where T : IComparable&lt;T&gt;* verlangt, dass *T* das [``Interface``](../../../05_Glossar.md#interface) implementiert.
>       4. *where T : new()* verlangt einen parameterlosen [``Konstruktor``](../../../05_Glossar.md#konstruktor).
>6. Auch in einer nicht generischen [``Klasse``](../../../05_Glossar.md#klasse) kann eine einzelne [``Methode``](../../../05_Glossar.md#methode) einen eigenen ``Typparameter`` haben, z. B. *void Swap&lt;T&gt;(ref T a, ref T b)*.
>7. Werte vom ``Typ`` *T* können nicht direkt mit *&lt;* oder *&gt;* verglichen werden. Mit *where T : IComparable&lt;T&gt;* steht uns *.CompareTo()* zur Verfügung.
>8. Beim Aufruf leitet der Compiler *T* meist selbst aus den Argumenten ab (*Typinferenz*): *Swap(ref a, ref b)* statt *Swap&lt;int&gt;(ref a, ref b)*.
>9. Auch wenn *GueterWaggon* von *Waggon* erbt, darf eine *DoublyLinkedList&lt;GueterWaggon&gt;* **nicht** einer Variable vom ``Typ`` *DoublyLinkedList&lt;Waggon&gt;* zugewiesen werden. Sonst könnte man über die allgemeine [``Referenz``](../../../05_Glossar.md#referenz) einen falschen Waggon einfügen.
>10. *Bonus:* Gibt ein [``Interface``](../../../05_Glossar.md#interface) *T* **nur zurück** (z. B. *IEnumerable&lt;out T&gt;*), ist die Zuweisung von speziell zu allgemein erlaubt (*Kovarianz*, *out*). Nimmt es *T* **nur entgegen** (z. B. *IComparer&lt;in T&gt;*), ist es umgekehrt (*Kontravarianz*, *in*).
