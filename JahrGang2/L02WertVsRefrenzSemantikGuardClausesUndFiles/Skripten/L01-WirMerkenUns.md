**Wir merken uns von [Guard Clause](L02.1GuardClauses.md):** 

> 1. Eine [``Guard-Clause``](../../../05_Glossar.md#guard-clause) ist eine Abfolge von *Sicherheitsabfragen* hintereinander.
> 2. Wir erreichen durch [``Guard-Clauses``](../../../05_Glossar.md#guard-clause) eine *Gruppierung* von *ungewünschte Zustände ❌* und *gewünschten Zustände ✅*.
> 3. In der Variante der [``verschachtelten Verzweigungen``](../../../05_Glossar.md#verschachtelte-verzweigung) sind *ungewünschte Zustände ❌* und *gewünschten Zustände ✅* gemischt und die *gewünschten Zustände ✅* im *tiefsten* [``Block``](../../../05_Glossar.md#block) der [``verschachtelten Verzweigung``](../../../05_Glossar.md#verschachtelte-verzweigung) versteckt.
> 4. Ein [``early exit``](../../../05_Glossar.md#early-exit) bricht den Ablauf frühzeitig mit kem ``Keyword`` *return* ab.
> 5. Wenn alle *Sicherheitsabfragen* passiert wurden, erreichen wir sicher den *gewünschten Zustand ✅* des Programms.
> 6. Das [``logische UND``](../../../05_Glossar.md#logische-operatoren) (*&&* bzw. $\land$) ist einer [``verschachtelten Verzweigung``](../../../05_Glossar.md#verschachtelte-verzweigung) gleichzusetzen.
> 7. Das [``logische ODER``](../../../05_Glossar.md#logische-operatoren) (*||* bzw. $\lor$) ist eine untereinander geschriebene [``bedingte Anweisung``](../../../05_Glossar.md#bedingte-anweisung) mit einem [``early exit``](../../../05_Glossar.md#early-exit).
> 8. [``De Morgans Gesetz``](../../../05_Glossar.md#de-morganschen-gesetz) stellt die *logische Gleichheit* zwischen [``verschachtelte Verzweigungen``](../../../05_Glossar.md#verschachtelte-verzweigung) und [``Guards-Clauses``](../../../05_Glossar.md#guard-clause) her. Es kann dadurch jedes Programm von der "[``verschachtelten If-Verzweigungs``](../../../05_Glossar.md#verschachtelte-verzweigung)"-*Welt* in die "[``Gaurd-CLause``](../../../05_Glossar.md#guard-clause)"-*Welt* umgeschrieben werden.
> 9. Um eine *einfache* [``verschachtelte Verzweigung``](../../../05_Glossar.md#verschachtelte-verzweigung) in eine [``Guard-Clause``](../../../05_Glossar.md#guard-clause) umzuwandeln, müssen wir: 
>       1. Die *äußerste* [``Bedingung``](../../../05_Glossar.md#bedingung) *negieren* und in eine [``bedingte Anweisungen``](../../../05_Glossar.md#bedingte-anweisung) mit [``early exit``](../../../05_Glossar.md#early-exit) *untereinander* umschreiben.
>       2. Den Inhalt des *else* [``Blocks``](../../../05_Glossar.md#block) der [``verschachtelte Verzweigung``](../../../05_Glossar.md#verschachtelte-verzweigung) in den [``Block``](../../../05_Glossar.md#block) der [``bedingte Anweisungen``](../../../05_Glossar.md#bedingte-anweisung) geben.
>       3. Wir wiederholen solange bis wir keine *ungewünschten Zuständen ❌* mehr in der [``verschachtelte Verzweigung``](../../../05_Glossar.md#verschachtelte-verzweigung) finden.
>       4. Der *gewünschte Zustände ✅* befindet sich dann unterhalb der [``bedingte Anweisungen``](../../../05_Glossar.md#bedingte-anweisung). 
> 10. Um eine *komplexe* ``verschachtelte Verzweigung`` in eine ``Guard-Clause`` umzuwandeln, müssen wir: 
>       1. Alle ``Blöcke`` mit *ungewünschten Zuständen ❌* in gedanklich *markieren*.
>       2. Uns eine *neue* ``Bedingung`` mit ``logischen UND`` überlegen, welche in einem *ungewünschten Zustand ❌* endet.
>       3. Die *neue* ``Beindungung`` in einer ``bedingte Anweisung`` verwenden und in dessen ``Block`` einen ``early exit`` einbauen.
>       4. Den Inhalt des ``Blocks`` des *ungewünschten Zustands ❌* in den ``Block`` der ``bedingte Anweisung`` schreiben.
>       5. Entferne den ``Block`` des *ungewünschten Zustands ❌* aus der ``verschachtelte Verzweigung``
>       6. Wiederhole die vorherigen Schritte bis keine *ungewünschten Zustände ❌* mehr in der ``verschachtelte Verzweigung`` vorhanden sind.
>       7. Kopiere die ``Kontrollstrukturen`` der *gewünschten Zustände ✅* welche nach dem Entfernen der *ungewünschten Zustände ❌* übrig geblieben sind, unterhalb der ``bedingte Anweisungen``. 