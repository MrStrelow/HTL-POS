class Hamster
{
    // #################### Zustand ####################
    // Felder -> der Zustand
    public (int x, int y) position;
    public string darstellung;
    public string richtung;
    public int anzahlSchritte;
    public Hamster freund;          // hat-Beziehung

    // #################### Verhalten ####################:
    // Methoden: Konstruktor -> initialisiert den Zustand
    public Hamster((int x, int y) position,
                    string darstellung,
                    Hamster freund)
    {
        this.position = position;
        this.darstellung = darstellung;
        this.freund = freund;
    }

    // Methoden: Standardkonstruktor: keine Parameter, Standardwerte
    public Hamster()
    {
        this.position = (0, 0);
        this.darstellung = "🐹";
        this.freund = null;
    }

    // Methoden: das Verhalten
    public void Bewegen(string richtung)
    {
        this.richtung = richtung;
        anzahlSchritte++;
        Console.WriteLine($"{darstellung} Schritt {anzahlSchritte}: geht nach {richtung}");
    }

    public void Nachmachen()
    {
        Bewegen(freund.richtung);
    }
}
