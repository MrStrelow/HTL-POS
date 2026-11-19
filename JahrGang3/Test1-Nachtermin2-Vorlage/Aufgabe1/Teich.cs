using System;

public class Teich
{
    // private Felder
    // Eigenschaften

    // Konstruktor
    ...
    {
        // Mindestens 12x12 groß, darf aber größer sein
        // Karte initialisieren

        // 1. Rand der Karte mit seichtem Wasser 🟩, das Innere mit tiefem Wasser 🟦 befüllen

        // 2. zusätzlich 15% der Fläche mit seichtem Wasser (🟩) befüllen (nur auf tiefem Wasser)

        // 3. 10% der Fläche mit Steinen (🪨) befüllen (nur auf tiefem Wasser)

        // 4. initialisiere Blaetter array (5% der Fläche) - hat beziehung
        // Die ersten 3 Blätter fallen vom Baum in der Mitte des Teichs:
        // (Groesse / 2, Groesse / 2), (Groesse / 2 - 1, Groesse / 2) und (Groesse / 2, Groesse / 2 - 1)
        // TODO: Blatt 1
        // TODO: Blatt 2
        // TODO: Blatt 3

        // 5. DONE: restliche Blätter mit zufälliger Startposition:
        for (int i = 3; i < anzahlBlaetter; i++)
        {
            (int y, int x) start = (random.Next(0, Groesse), random.Next(0, Groesse));
            Blaetter[i] = new Blatt(this, start);
        }
    }

    // Darf ein Blatt hier ins Wasser fallen?
    public ... IstPlatzierbar(... position)
    {
    // ❌ außerhalb der Karte -> return false;

    // ❌ kein tiefes Wasser (Stein, seicht oder schon ein Blatt) -> return false;

    // ✅ treibendes Blatt 🍂 in die Karte eintragen und true zurückgeben
    }

    // Darf ein Blatt von 'von' nach 'ziel' treiben?
    public ... KannTreiben(... von, ... ziel)
    {
    // ❌ ziel ist gleich von (das Blatt hat sich nicht bewegt) -> return false;

    // ❌ außerhalb der Karte -> return false;

    // ❌ Stein oder schon ein Blatt (🍂 oder 🍁) -> return false;

    // ✅ sonst true
    }

    // TODO: IstSeicht(position): true, wenn dort seichtes Wasser 🟩 ist (und die Position im Teich liegt)

    // TODO: VersetzeBlatt(von, ziel, haengtFest):
    //       auf 'von' wieder tiefes Wasser eintragen, auf 'ziel' 🍁 (hängt fest) oder 🍂 (treibt weiter)

    // TODO: Simuliere(runden): in jeder Runde jedes Blatt einmal treiben lassen

    // TODO: ZaehleHaengendeBlaetter(): Anzahl der Blätter, die festhängen

    // TODO: Print Methode des 2d Arrays schreiben
}
