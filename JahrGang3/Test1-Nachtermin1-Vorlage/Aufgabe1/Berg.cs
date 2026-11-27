using System;

public class Berg
{
    // private Felder
    // Eigenschaften

    // Konstruktor
    ...
    {
        // Mindestens 12x12 groß (Default-Parameter), darf aber größer sein
        // Karte initialisieren

        // 1. Rand der Karte mit Alm 🟩, das Innere mit Schnee ⬜ befüllen

        // 2. zusätzlich 15% der Fläche mit Alm (🟩) befüllen (nur auf Schnee)

        // 3. 10% der Fläche mit Fels (🪨) befüllen (nur auf Schnee)

        // 4. initialisiere Bergsteiger array (5% der Fläche) - hat beziehung
        // Die ersten 3 Bergsteiger werden vom Hubschrauber am Gipfel in der Mitte abgesetzt:
        // (Groesse / 2, Groesse / 2), (Groesse / 2 - 1, Groesse / 2) und (Groesse / 2, Groesse / 2 - 1)
        // TODO: Bergsteiger 1
        // TODO: Bergsteiger 2
        // TODO: Bergsteiger 3

        // 5. DONE: restliche Bergsteiger mit zufälliger Startposition:
        for (int i = 3; i < anzahlBergsteiger; i++)
        {
            (int y, int x) start = (random.Next(0, Groesse), random.Next(0, Groesse));
            Bergsteiger[i] = new Bergsteiger(this, start);
        }
    }

    // Darf ein Bergsteiger hier abgesetzt werden?
    public ... IstPlatzierbar(... position)
    {
    // ❌ außerhalb der Karte -> return false;

    // ❌ kein Schnee (Fels, Alm oder schon ein Bergsteiger) -> return false;

    // ✅ kletternden Bergsteiger 🧗 in die Karte eintragen und true zurückgeben
    }

    // Darf ein Bergsteiger von 'von' nach 'ziel' klettern?
    public ... KannKlettern(... von, ... ziel)
    {
    // ❌ ziel ist gleich von (der Bergsteiger hat sich nicht bewegt) -> return false;

    // ❌ außerhalb der Karte -> return false;

    // ❌ Fels oder schon ein Bergsteiger (🧗 oder 🏕️) -> return false;

    // ✅ sonst true
    }

    // TODO: IstAlm(position): true, wenn dort Alm 🟩 ist (und die Position auf der Karte liegt)

    // TODO: IstFels(position): true, wenn dort Fels 🪨 ist (und die Position auf der Karte liegt)

    // TODO: SchlageFrei(position): ist dort Fels, wird Schnee ⬜ eingetragen

    // TODO: VersetzeBergsteiger(von, ziel, rastet):
    //       auf 'von' wieder Schnee eintragen, auf 'ziel' 🏕️ (rastet) oder 🧗 (klettert weiter)

    // TODO: Simuliere(runden): in jeder Runde jeden Bergsteiger einmal klettern lassen

    // TODO: ZaehleRastende(): Anzahl der Bergsteiger, die rasten

    // TODO: ZaehleKaputtePickel(): Anzahl der Bergsteiger, deren Pickel kaputt ist

    // TODO: Print Methode des 2d Arrays schreiben
}
