using System;

public class Blatt
{
    // Eigenschaften

    // Konstruktor
    ...
    {
        // Initialisiere Eigenschaften

        PlatziereBlatt();
    }

    // Methoden
    public void PlatziereBlatt()
    {
    // 1. Die Startposition in einer lokalen Variable speichern

    // 2. Falls das Blatt dort nicht platzierbar ist - Frage ab mit Teich.IstPlatzierbar(position),
    //    wählt das Blatt zufällig eine neue Position.
    //    Wiederhole, solange bis es funktioniert.

    // 3. Gefundene Position in der Eigenschaft Position speichern
    }

    public void Treiben()
    {
    // ❌ Hängt das Blatt schon fest, passiert nichts mehr.

    // Höchstens 10 Versuche:
    // 1. Zufällige Richtung dy und dx (jeweils -1, 0 oder 1) wählen und das Ziel berechnen.

    // 2. ❌ Darf das Blatt nicht dorthin treiben - Frage ab mit Teich.KannTreiben(Position, ziel) -,
    //    nächster Versuch.

    // 3. ✅ Frage mit Teich.IstSeicht(ziel) ab, ob das Blatt ab jetzt festhängt,
    //    lass den Teich das Blatt mit Teich.VersetzeBlatt(...) versetzen, merke dir die neue Position
    //    und beende die Methode.
    }
}
