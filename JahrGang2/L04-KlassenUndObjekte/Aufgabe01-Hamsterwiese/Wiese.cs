// Die Wiese ist das Spielfeld. Sie HAT einen Seedling (hat-Beziehung).
class Wiese
{
    // Felder: der Zustand
    public int breite;
    public int hoehe;
    public Seedling seedling;         // hat-Beziehung: die Wiese kennt ihren Seedling

    // Konstruktor: der Startzustand
    public Wiese(int breite, int hoehe, Seedling seedling)
    {
        // TODO Schritt 2: alle drei Parameter in die Felder speichern (this.breite = breite; ...)
    }

    // Methoden: das Verhalten
    public bool IstInnerhalb((int x, int y) p)
    {
        // TODO Schritt 2: true, wenn 0 <= p.x < breite und 0 <= p.y < hoehe
        return false;
    }

    public void Zeichnen(Hamster hamster)
    {
        // TODO Schritt 2: Zeile fuer Zeile (y), Feld fuer Feld (x):
        //   feld = "🟫"
        //   steht der (nicht gefressene) seedling auf (x, y)? -> feld = seedling.darstellung
        //   ist hamster nicht null und steht er auf (x, y)?   -> feld = hamster.darstellung
        //   Console.Write(feld); am Ende jeder Zeile Console.WriteLine();
    }
}
