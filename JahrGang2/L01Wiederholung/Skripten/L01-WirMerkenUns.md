>**Wir merken uns von [Operatoren](L02.1Operatoren.md):** 
>1. ``Logische Operatoren`` haben als ``Eingangsparameter`` den ``Typ`` *bool* und als ``Ausgangsparameter`` ebenso. 
>2. ``Vergleichs-Operatoren`` haben als ``Eingangsparameter`` vergleichbare ``Typen`` wie z.B. *int*, *double*, ... und als ``Ausgangsparameter`` den ``Typ`` *bool*.  
>3. Das ``logische UND`` *&&* ergibt *true*, wenn **alle** ``Eingangsparameter`` gleichzeitig zutreffen (*true* sind). 
>4. Das ``logische UND`` *&&* verwenden wir, um alles aufzulisten was zutreffen *muss*.
>5. Das ``logische ODER`` *&&* ergibt *true*, wenn **mindestens ein**  ``Eingangsparameter`` zutrifft (*true* ist). 
>6. Das ``logische ODER`` *||* verwenden wir, um zwei *Teillösungen* zusammenzufassen.
>7. Wenn keine ``logische Formel`` für eine *Problemstellung* gefunden werden kann, versuchen wir einfachere ``Teilprobleme`` zu lösen. Wir fügen diese später zusammen um die *Problemstellung* zu lösen.
>8. Das ``logische NICHT`` *!* ergibt *true*, wenn die vorherige ``Eingangsparameter`` *false* ist. Wir ``negieren`` damit eine ``Aussage`` bzw. ``logische Formel`` bzw. ``boolescher Ausdruck``. 


**Wir merken uns von [Schleifen](L02.2Schleifen.md):**
>1. Bei einer ``Zählschleife`` *wissen wir wie oft* diese sich wiederholt und setzen es mit **for** um. 
>2. Bei einer ``While-Schleife`` *wissen wir **nicht** wie oft* diese sich wiederholt und setzen es mit **while** um.
>3. Die *runden Klammern* bei einer ``Schleife`` nennen wir den ``Schleifenkopf``.
>4. Die ``Schleifen-Bedingung`` ist eine ``logische Formel``, welche steuert wie oft die ``Schleife`` sich wiederholt.
>5. Bei der ``Zählschleife`` gibt es *drei* Bausteine im ``Schleifenkopf``. Diese sind ``Zählvariable``, ``Schleifen-Bedingung`` und ``Inkrement``. 
>6. Bei der ``While-Schleife`` gibt es *einen* Baustein im ``Schleifenkopf``. Dieser ist die ``Schleifen-Bedingung``.

>**Wir merken uns von [Verzweigungen](L02.3Verzweigungen.md):**
>1. Die ``Bedingung`` ist eine ``logische Formel``, welche steuert, ob wir den folgenden ``Block`` ausführen oder nicht.
>2. Eine ``bedingte Anweisung`` **if ohne else** führt einen ``Block`` nur aus, wenn ihre ``Bedingung`` *true* ist.
>3. Eine ``Verzweigung`` **if mit else** besitzt *zwei* ``Blöcke`` und sichert zu, dass *einer* der beiden *immer* ausgeführt wird. 
>4. Die ``Bedingung`` bei einer ``Verzweigung`` steuert, welcher ``Block`` ausgeführt wird.
>5. Eine ``Mehrfachverzweigung`` **if mit else if** oder *switch* besitzt *mehrere* ``Blöcke`` und sichert zu, dass *einer* davon *immer* ausgeführt wird. 
>6. Ein ``Ausdruck`` kann den ``Zuweisungsoperator`` *links* neben sich stehen haben. 
>7. Eine ``Anweisung`` kann *nicht* den ``Zuweisungsoperator`` *links* neben sich stehen haben. 
>8. Eine ``verschachtelte Verzweigung`` entsteht, wenn wir ``bedigte Anweisungen``, ``Verzweigungen`` oder ``Mehrfachverzweigungen`` in den ``Block`` einer anderen ``bedigte >Anweisung``, ``Verzweigung`` oder ``Mehrfachverzweigung`` schreiben. 
<!-- >9. Eine ``verschachtelte Verzweigung`` ist ab einer Tiefe von *drei* zu vermeiden. 
>10. Wir können eine ``verschachtelte Verzweigung`` mit dem ``De Morgan'schen Gesetz`` zu *flachen* ``bedingten Anweisungen`` umformen.
>11. Die ``verchachtelte Verzweigung`` stellt ein ``logisches UND`` dar. 
>12. *Mehrere untereinander* geschriebene ``bedingte Anweisungen`` mit ``early exit`` stellen ein ``logisches ODER`` dar. 
>13. Eine ``Guard Clause`` wird mit ist ein *securtiy check*. Mehrere ``bedingte Anweisungen`` werden *untereinander* geschrieben und fragen in der ``Bedingung`` nach dem *ungewünschten Zustand* ❌ ab.
>14. Bei einer ``Guard Clause`` ist der *gewünschte Zustand* ✅ nach am Ende nach allen erflogreich abschlossenen ``bedingte Anweisungen`` erreicht.
>8. Ein **switch** als ``Anweisung`` ist in neuen Sprachen begrenzt nützlich.
>9. Ein **switch** als ``Ausdruck`` ist in neuen Sprachen nützlich und wird als ``Pattern-Matching`` bezeichnet. -->
