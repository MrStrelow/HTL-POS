using System;

public class Bergsteiger
{
    // Eigenschaften

    // Konstruktor
    ...
    {
        // Initialisiere Eigenschaften
        // Jeder Bergsteiger bekommt einen neuen Pickel (hat-Beziehung)

        Absetzen();
    }

    // Methoden
    public void Absetzen()
    {
    // 1. Die Startposition in einer lokalen Variable speichern

    // 2. Falls der Bergsteiger dort nicht abgesetzt werden kann - Frage ab mit Berg.IstPlatzierbar(position),
    //    wählt er zufällig eine neue Position.
    //    Wiederhole, solange bis es funktioniert.

    // 3. Gefundene Position in der Eigenschaft Position speichern
    }

    public void Klettern(...)
    {
    // ❌ Rastet der Bergsteiger schon, passiert nichts mehr.

    // Höchstens 10 Versuche (Default-Parameter):
    // 1. Zufällige Richtung dy und dx (jeweils -1, 0 oder 1) wählen und das Ziel berechnen.

    // 2. ⛏️ Ist das Ziel Fels - Frage ab mit Berg.IstFels(ziel) - und hält der Pickel noch - Pickel.Benutzen() -,
    //    lass den Berg das Feld mit Berg.SchlageFrei(ziel) freischlagen. Nächster Versuch.

    // 3. ❌ Darf der Bergsteiger nicht dorthin klettern - Frage ab mit Berg.KannKlettern(Position, ziel) -,
    //    nächster Versuch.

    // 4. ✅ Frage mit Berg.IstAlm(ziel) ab, ob der Bergsteiger ab jetzt rastet,
    //    lass den Berg den Bergsteiger mit Berg.VersetzeBergsteiger(...) versetzen, merke dir die neue Position
    //    und beende die Methode.
    }
}
