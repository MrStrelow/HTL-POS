class Hamster
{
    // Felder: der Zustand
    public (int x, int y) position;
    public string darstellung;
    public string richtung;
    public int anzahlSchritte;
    public Hamster freund;                 // hat-Beziehung

    // Konstruktor: der Startzustand
    public Hamster((int x, int y) start, string darstellung, Hamster freund)
    {
        position = start;
        this.darstellung = darstellung;
        this.freund = freund;
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
        Bewegen(freund.richtung);          // Richtung des Freundes verwenden
    }
}
