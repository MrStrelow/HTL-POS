using System;

public class Katastrophengebiet
{
    // private Felder
    // Eingschaften

    // Konstruktor
    ...
    {
        // Mindestens 15x15 groß, darf aber größer sein
        // Weltkarte initialisieren

        // 1. Gesamte Weltkarte mit Erdesymbolen 🟫 initialisieren

        // 2. 20% der Fläche mit Löchern (🕳️) befüllen
        
        // 3. 30% der Fläche mit Wasser (💧) befüllen

        // 4. initialisiere helikopter array - hat beziehung
        // Erzeuge 3 helikopter mit Hotspots, wo sich viele Vermisste befinden
        // und weise diese den ersten 3 Positionen des Arrays zu.
        (int y, int x) hotspotEins = (4, 6);
        // TODO: Helikopter 1

        (int y, int x) hotspotZwei = (2, 7);
        // TODO: Helikopter 2

        (int y, int x) hotspotDrei = (6, 9);
        // TODO: Helikopter 3

        // 5. DONE: 10% der Fläche für Roboter & Helikopter:
        for (int i = 0; i < anzahlEinheiten - 3; i++)
        {
            (int y, int x) wunschPos = (random.Next(0, Groesse), random.Next(0, Groesse));

            // Helikopter erstellen
            Helikopter[i] = new Helikopter(this, wunschPos);
        }
    }

    // Ist IstAbladbar wird verwendet um herauszufinden ob wir einen Roboter auf einer Position abladen können oder nicht.
    public ... IstAbladbar(... position)
    {
    // ❌ Frage ab ob wir außerhalb der Kartengrenzen sind. Wenn das der Fall ist, return false;

    // ❌ Loch, Wasser oder bereits ein anderer Roboter an dieser Stelle. Wenn das der Fall ist, return false;
    //      Alternativ wenn es nicht Erde ist, dann return false;

    // ✅ Position ist frei (🟫) -> Roboter in Weltkarte eintragen und true zurückgeben
    }

    // TODO: Print Methode des 2d Arrays schreiben
}