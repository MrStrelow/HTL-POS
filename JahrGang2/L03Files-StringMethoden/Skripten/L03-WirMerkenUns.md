1. Funktionen und methoden sind fast das gleiche. Funktionen können immer aufgerufen werden. Lebt eine funktin nur bei bestimmte werte, variablen bzw. typen nenne wir diese methode. Immer aufruben bedeutet wir brauchen nur name und parameter. Lebt bei variablen bedeutet wir brauchen einen wert, vraiable oder typ und den aufrufeoperator welcher der *.* ist. Danach kommt der name der Methode. 
2. Wir sparen uns eingangsparameter bei methoden, denn diese wissen bereits etwas über die variable für diese sie aufgerufen wird.
3. Ein pfad zu einem file ist eine wegbeschreibung dorthin am filesystem.
4. pfade könne absolut sein oder relativ. Relative haben einen basispunkt auf dem sie sich beziehen. Unserer ist der ort der ausführbaren datei mit exe unseres compilierten programmes. dieses ist in "bin/... etc todo ergänze".
5. Relative pfade welche files neben dem program.cs sind, müssen wir mit "../../../name.txt" angeben.
6. File.WriteAllLines("hallo.txt", daten); hat als eingangsparameter den pfad und ein string array. jede zeile ist ein element des arrays.
7. File.ReadAllLines("hallo.txt"); hat ein string array als rückgabe des gesamten files. jede zeile ist ein element des arrays.
8. Wir verwenden nun string methoden wie split um texte aus einer zeile zu trennen, Trim um leerzeichen zu entfernen, substring um teile zu extrahieren, tolower case um nicht von der schreibweise abhängig zu sein.
9. TODO mehr manipulationen und sonstige methoden welche nützlich für die strings nach den fileauslesen sind.
10. eine for each schleife ist eine vereinfachte zählschleife welche keinen index besitzt. wir verwenden diese wenn einfache leseoperationen durchzuführen sind.
11. StreamReader verwenden wir wenn große files eingelesen werden und nur zeilenweise uns die ergebnisse merken. File verwenden wir 
12. CSV Datein sind datei welche ihre values mit commas seperated. wir verwenden beim einlesen ein split mit , für jede zeile im englischen und im deutschen mit ;.
13. 