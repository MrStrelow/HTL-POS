using System;

public class Pickel
{
    // Eigenschaften
    // Haltbarkeit (nur intern setzbar)
    // IstKaputt (nur lesen): true, wenn die Haltbarkeit 0 ist

    // Konstruktor
    // Haltbarkeit als Default-Parameter (3)
    ...
    {
    }

    // Methoden
    public ... Benutzen()
    {
    // ❌ Pickel ist kaputt -> return false;

    // ✅ Haltbarkeit um 1 verringern, return true;
    }
}
