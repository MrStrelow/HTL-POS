// Ein Hamster laeuft ueber die Wiese und frisst den Seedling. Er HAT eine Wiese (hat-Beziehung).
class Hamster
{
    // Felder: der Zustand
    public (int x, int y) position;
    public string darstellung;
    public int anzahlSchritte;
    public Wiese wiese;               // hat-Beziehung: der Hamster kennt seine Wiese

    // Konstruktor: der Startzustand
    public Hamster((int x, int y) start, Wiese wiese, string darstellung)
    {
        // TODO Schritt 3: alle drei Parameter in die Felder speichern
    }

    // Methoden: das Verhalten
    public string Beschreiben()
    {
        // TODO Schritt 3: z. B. "🐹 auf (0, 0), 0 Schritte"
        return "TODO";
    }

    public void Bewegen(string richtung)
    {
        // TODO Schritt 3:
        //   ziel = position; je nach richtung ("N", "S", "O", "W") ziel.y bzw. ziel.x aendern
        //   Guard: liegt ziel NICHT auf der Wiese? (wiese.IstInnerhalb) -> "🐹 stößt an den Rand", return
        //   position = ziel; anzahlSchritte++; "🐹 geht nach O -> (1, 0)" ausgeben
        // TODO Schritt 4: danach Fressen() aufrufen
    }

    public void Fressen()
    {
        // TODO Schritt 4:
        //   den Seedling ueber die Wiese holen: wiese.seedling
        //   Guard: schon gefressen oder nicht auf meiner position? -> return
        //   gefressen = true setzen und "🐹 frisst 🌱" ausgeben
    }
}
