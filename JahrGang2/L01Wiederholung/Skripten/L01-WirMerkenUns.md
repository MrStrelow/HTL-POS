>**Wir merken uns von [Operatoren](L02.1Operatoren.md):** 
>1. [``Logische Operatoren``](../../../05_Glossar.md#logische-operatoren) haben als [``Eingangsparameter``](../../../05_Glossar.md#parameter) den [``Typ``](../../../05_Glossar.md#typ) *bool* und als [``Ausgangsparameter``](../../../05_Glossar.md#parameter) ebenso. 
>2. [``Vergleichs-Operatoren``](../../../05_Glossar.md#vergleichsoperatoren) haben als [``Eingangsparameter``](../../../05_Glossar.md#parameter) vergleichbare [``Typen``](../../../05_Glossar.md#typ) wie z.B. *int*, *double*, ... und als [``Ausgangsparameter``](../../../05_Glossar.md#parameter) den [``Typ``](../../../05_Glossar.md#typ) *bool*.  
>3. Das [``logische UND``](../../../05_Glossar.md#logische-operatoren) *&&* ergibt *true*, wenn **alle** [``Eingangsparameter``](../../../05_Glossar.md#parameter) gleichzeitig zutreffen (*true* sind). 
>4. Das [``logische UND``](../../../05_Glossar.md#logische-operatoren) *&&* verwenden wir, um alles aufzulisten was zutreffen *muss*.
>5. Das [``logische ODER``](../../../05_Glossar.md#logische-operatoren) *||* ergibt *true*, wenn **mindestens ein** [``Eingangsparameter``](../../../05_Glossar.md#parameter) zutrifft (*true* ist). 
>6. Das [``logische ODER``](../../../05_Glossar.md#logische-operatoren) *||* verwenden wir, um zwei *Teillösungen* zusammenzufassen.
>7. Wenn keine [``logische Formel``](../../../05_Glossar.md#logische-formel) für eine *Problemstellung* gefunden werden kann, versuchen wir einfachere [``Teilprobleme``](../../../05_Glossar.md#teilprobleme) zu lösen. Wir fügen diese später zusammen um die *Problemstellung* zu lösen.
>8. Das [``logische NICHT``](../../../05_Glossar.md#logische-operatoren) *!* ergibt *true*, wenn der vorherige [``Eingangsparameter``](../../../05_Glossar.md#parameter) *false* ist. Wir [``negieren``](../../../05_Glossar.md#negieren) damit eine [``Aussage``](../../../05_Glossar.md#aussage) bzw. [``logische Formel``](../../../05_Glossar.md#logische-formel) bzw. einen [``booleschen Ausdruck``](../../../05_Glossar.md#ausdruck). 

>**Wir merken uns von [Verzweigungen](L02.3Verzweigungen.md):**
>1. [``Variablen``](../../../05_Glossar.md#variable) befinden sich in einem [``Block``](../../../05_Glossar.md#block), welcher mit *geschwungenen Klammern* ausgezeichnet wird.
>2. [``Variablen``](../../../05_Glossar.md#variable) welche innerhalb eines [``Blocks``](../../../05_Glossar.md#block)[``deklariert``](../../../05_Glossar.md#block) werden sind in *diesem* und allen darin *geschachtelten* [``Blöcke``](../../../05_Glossar.md#block) verwendbar. Diese [``Variablen``](../../../05_Glossar.md#variable) sind *in-[``scope``](../../../05_Glossar.md#block)*.
>3. [``Variablen``](../../../05_Glossar.md#variable) welche innerhalb eines [``Blocks``](../../../05_Glossar.md#block)[``deklariert``](../../../05_Glossar.md#block) werden und in[``Blöcken``](../../../05_Glossar.md#block) außerhalb angesprochen werden. Diese [``Variablen``](../../../05_Glossar.md#variable) sind *out-of-[``scope``](../../../05_Glossar.md#scope)*.
>4. Die [``Bedingung``](../../../05_Glossar.md#bedingung) ist eine [``logische Formel``](../../../05_Glossar.md#logische-formel), welche steuert, ob wir den folgenden [``Block``](../../../05_Glossar.md#block) ausführen oder nicht.
>5. Eine [``bedingte Anweisung``](../../../05_Glossar.md#bedingte-anweisung) **if ohne else** führt einen [``Block``](../../../05_Glossar.md#block) nur aus, wenn ihre [``Bedingung``](../../../05_Glossar.md#bedingung) *true* ist.
>6. Eine [``Verzweigung``](../../../05_Glossar.md#verzweigung) **if mit else** besitzt *zwei* [``Blöcke``](../../../05_Glossar.md#block) und sichert zu, dass *einer* der beiden *immer* ausgeführt wird. 
>7. Die [``Bedingung``](../../../05_Glossar.md#bedingung) bei einer [``Verzweigung``](../../../05_Glossar.md#verzweigung) steuert, welcher [``Block``](../../../05_Glossar.md#block) ausgeführt wird.
>8. Eine [``Mehrfachverzweigung``](../../../05_Glossar.md#mehrfachverzweigung) **if mit else if** oder *switch* besitzt *mehrere* [``Blöcke``](../../../05_Glossar.md#block) und sichert zu, dass *einer* davon *immer* ausgeführt wird. 
>9. Eine [``verschachtelte Verzweigung``](../../../05_Glossar.md#verschachtelte-verzweigung) entsteht, wenn wir [``bedingte Anweisungen``](../../../05_Glossar.md#bedingte-anweisung), [``Verzweigungen``](../../../05_Glossar.md#verzweigung) oder [``Mehrfachverzweigungen``](../../../05_Glossar.md#mehrfachverzweigung) in den [``Block``](../../../05_Glossar.md#block) einer anderen [``bedingten Anweisung``](../../../05_Glossar.md#bedingte-anweisung), [``Verzweigung``](../../../05_Glossar.md#verzweigung) oder [``Mehrfachverzweigung``](../../../05_Glossar.md#mehrfachverzweigung) schreiben. 
<!-- >6. Ein [``Ausdruck``](../../../05_Glossar.md#ausdruck) kann den [``Zuweisungsoperator``](../../../05_Glossar.md#zuweisungsoperator) *links* neben sich stehen haben. 
>7. Eine [``Anweisung``](../../../05_Glossar.md#anweisung) kann *nicht* den [``Zuweisungsoperator``](../../../05_Glossar.md#zuweisungsoperator) *links* neben sich stehen haben.
<!-- >9. Eine [``verschachtelte Verzweigung``](../../../05_Glossar.md#verschachtelte-verzweigung) ist ab einer Tiefe von *drei* zu vermeiden. 
>10. Wir können eine [``verschachtelte Verzweigung``](../../../05_Glossar.md#verschachtelte-verzweigung) mit dem [``De Morgan'schen Gesetz``](../../../05_Glossar.md#de-morganschen-gesetz) zu *flachen* [``bedingten Anweisungen``](../../../05_Glossar.md#bedingte-anweisung) umformen.
>11. Die [``verschachtelte Verzweigung``](../../../05_Glossar.md#verschachtelte-verzweigung) stellt ein [``logisches UND``](../../../05_Glossar.md#logische-operatoren) dar. 
>12. *Mehrere untereinander* geschriebene [``bedingte Anweisungen``](../../../05_Glossar.md#bedingte-anweisung) mit [``early exit``](../../../05_Glossar.md#early-exit) stellen ein [``logisches ODER``](../../../05_Glossar.md#logische-operatoren) dar. 
>13. Eine [``Guard Clause``](../../../05_Glossar.md#guard-clause) ist ein *security check*. Mehrere [``bedingte Anweisungen``](../../../05_Glossar.md#bedingte-anweisung) werden *untereinander* geschrieben und fragen in der [``Bedingung``](../../../05_Glossar.md#bedingung) nach dem *ungewünschten Zustand* ❌ ab.
>14. Bei einer [``Guard Clause``](../../../05_Glossar.md#guard-clause) ist der *gewünschte Zustand* ✅ am Ende nach allen erfolgreich abgeschlossenen [``bedingten Anweisungen``](../../../05_Glossar.md#bedingte-anweisung) erreicht.
>8. Ein **switch** als [``Anweisung``](../../../05_Glossar.md#anweisung) ist in neuen Sprachen begrenzt nützlich.
>9. Ein **switch** als [``Ausdruck``](../../../05_Glossar.md#ausdruck) ist in neuen Sprachen nützlich und wird als [``Pattern-Matching``](../../../05_Glossar.md#pattern-matching) bezeichnet. -->

**Wir merken uns von [Schleifen](L02.2Schleifen.md):**
>1. Bei einer [``Zählschleife``](../../../05_Glossar.md#zählschleife) *wissen wir wie oft* diese sich wiederholt und setzen es mit **for** um. 
>2. Bei einer [``While-Schleife``](../../../05_Glossar.md#while-schleife) *wissen wir **nicht** wie oft* diese sich wiederholt und setzen es mit **while** um.
>3. Die *runden Klammern* bei einer [``Schleife``](../../../05_Glossar.md#schleife) nennen wir den [``Schleifenkopf``](../../../05_Glossar.md#schleifenkopf).
>4. Die [``Schleifen-Bedingung``](../../../05_Glossar.md#bedingung) ist eine [``logische Formel``](../../../05_Glossar.md#logische-formel), welche steuert wie oft die [``Schleife``](../../../05_Glossar.md#schleife) sich wiederholt.
>5. Bei der [``Zählschleife``](../../../05_Glossar.md#zählschleife) gibt es *drei* Bausteine im [``Schleifenkopf``](../../../05_Glossar.md#schleifenkopf). Diese sind [``Zählvariable``](../../../05_Glossar.md#zählvariable), [``Schleifen-Bedingung``](../../../05_Glossar.md#bedingung) und [``Inkrement``](../../../05_Glossar.md#inkrement). 
>6. Bei der [``While-Schleife``](../../../05_Glossar.md#while-schleife) gibt es *einen* Baustein im [``Schleifenkopf``](../../../05_Glossar.md#schleifenkopf). Dieser ist die [``Schleifen-Bedingung``](../../../05_Glossar.md#bedingung).
>7. Eine [``Block``](../../../05_Glossar.md#block) besitzt eine [``Zuständigkeit``](../../../05_Glossar.md#zuständigkeit-eines-blocks) welche wir als [``Kommentar``](../../../05_Glossar.md#kommentar) in *natürlicher Sprache* angeben.
>8. Mit dem [``Befehl``](../../../05_Glossar.md#befehlt) *cd  < projektordner >* (*Change Directory*) welchseln wir im [``Terminal``](../../../05_Glossar.md#console) das *Projektverzeichnis*. Anschließend wird mit dem [``Befehl``](../../../05_Glossar.md#befehlt) *dotnet run* unser [``Projekt``](../../../05_Glossar.md#projekt) [``kompiliert``](../../../05_Glossar.md#compiler) und [``ausgeführt``](../../../05_Glossar.md#ausgeführt).
>9. Dem [``Befehl``](../../../05_Glossar.md#befehl) *dotnet run* können wir in beliebigen den [``Terminals``](../../../05_Glossar.md#console) unabhängig von einer [``IDE``](../../../05_Glossar.md#befehl) eingeben.
>10. Wir verwenden den [``Befehl``](../../../05_Glossar.md#befehl) *dotnet run* um [``Emojis``](../../../05_Glossar.md#emojis) konsistenter in einem [``Terminal``](../../../05_Glossar.md#console) darstellen zu können.

**Wir merken uns von [Funktionen](L01.5Funktionen.md):**
>1. [``Funktionen``](../../../05_Glossar.md#funktion) sind ein Werkzeug, um unseren Code zu *strukturieren*, Aufgaben zu [``delegieren``](../../../05_Glossar.md#delegieren) und Logik *wiederverwendbar* zu machen.
>2. Die [``Deklaration``](../../../05_Glossar.md#deklaration) einer [``Funktion``](../../../05_Glossar.md#funktion) bezeichnen wir als [``Methodenkopf``](../../../05_Glossar.md#methodenkopf). Dieser macht den [``Typ``](../../../05_Glossar.md#typ) des [``Ausgangsparameters``](../../../05_Glossar.md#ausgangsparameter), den *Namen* und die [``Eingangsparameter``](../../../05_Glossar.md#eingangsparameter) dem Compiler bekannt.
>3. Die [``Definition``](../../../05_Glossar.md#definition) einer [``Funktion``](../../../05_Glossar.md#funktion) bezeichnen wir als [``Methodenkörper``](../../../05_Glossar.md#methodenkörper). Dies ist der [``Block``](../../../05_Glossar.md#block) `{...}`, welcher die auszuführende *Logik* und Speicherreservierung enthält.
>4. Wenn wir eine [``Funktion``](../../../05_Glossar.md#funktion) [``deklarieren``](../../../05_Glossar.md#deklaration), sprechen wir von [``Eingangsparametern``](../../../05_Glossar.md#eingangsparameter) und einem [``Ausgangsparameter``](../../../05_Glossar.md#ausgangsparameter).
>5. Wenn wir eine [``Funktion``](../../../05_Glossar.md#funktion) [``aufrufen``](../../../05_Glossar.md#aufruf), übergeben wir [``Ausdrücke``](../../../05_Glossar.md#ausdruck), welche wir [``Argumente``](../../../05_Glossar.md#argument) nennen, und erhalten einen konkreten [``Rückgabewert``](../../../05_Glossar.md#rückgabewert).
>6. Eine [``Funktion``](../../../05_Glossar.md#funktion) hält ausführbaren Code und wird durch das Anhängen von *runden Klammern ()* [``aufgerufen``](../../../05_Glossar.md#aufruf).
>7. Wenn eine [``Funktion``](../../../05_Glossar.md#funktion) einen [``Rückgabeparameters``](../../../05_Glossar.md#ausgangsparameter) besitzt, verhält ihr [``Aufruf``](../../../05_Glossar.md#aufruf) sich wie ein [``Ausdruck``](../../../05_Glossar.md#ausdruck) und generiert einen [``Wert``](../../../05_Glossar.md#wert).
>8. Wenn eine [``Funktion``](../../../05_Glossar.md#funktion) als Rückgabe das Keyword [``void``](../../../05_Glossar.md#void) besitzt, verhält sich ihr [``Aufruf``](../../../05_Glossar.md#aufruf) wie eine reine [``Anweisung``](../../../05_Glossar.md#anweisung) und generiert **keinen** [``Wert``](../../../05_Glossar.md#wert).
>9. Das Keyword [``return``](../../../05_Glossar.md#return) beendet die [``Funktion``](../../../05_Glossar.md#funktion) und liefert das Ergebnis zurück. Bei **void**-Methoden kann ein *nacktes* **return;** genutzt werden, um die Methode vorzeitig abzubrechen.
>10. Die [``Deklaration``](../../../05_Glossar.md#deklaration) einer [``Funktion``](../../../05_Glossar.md#funktion) stellt eine [``Schnittstelle``](../../../05_Glossar.md#schnittstelle) dar, an welche wir komplexe [``Teilprobleme``](../../../05_Glossar.md#teilprobleme) [``delegieren``](../../../05_Glossar.md#delegieren).
>11. Der [``Aufruf``](../../../05_Glossar.md#aufruf) von [``Funktionen``](../../../05_Glossar.md#funktion) kann *geschachtelt* werden, solange der [``Typ``](../../../05_Glossar.md#typ) des [``Rückgabeparameters``](../../../05_Glossar.md#ausgangsparameter) der *inneren* [``Funktion``](../../../05_Glossar.md#funktion) zum [``Eingangsparameter``](../../../05_Glossar.md#eingangsparameter) der *äußeren* Funktion passt.










