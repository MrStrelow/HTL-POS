// Ein Lieferauftrag: was er HAT (Properties) und was er KANN (Methoden).
class Auftrag
{
    // Zustand
    public string Nummer { get; set; }
    public (int X, int Y) Start { get; set; }
    public (int X, int Y) Ziel { get; set; }
    public double GewichtKg { get; set; }
    public string Kunde { get; set; }

    // Startzustand: alle Infos kommen über den Konstruktor
    public Auftrag(string nummer, (int X, int Y) start, (int X, int Y) ziel, double gewichtKg, string kunde)
    {
        Nummer = nummer;
        Start = start;
        Ziel = ziel;
        GewichtKg = gewichtKg;
        Kunde = kunde;
    }

    // Verhalten
    // Euklidische Distanz von Start bis Ziel, umgerechnet in km
    public double BerechneStreckeKm(double kmProFeld = 0.5)
    {
        int dx = Ziel.X - Start.X;
        int dy = Ziel.Y - Start.Y;
        return Math.Sqrt(dx * dx + dy * dy) * kmProFeld;
    }

    // Preisregeln als Default-Parameter: Sondertarife ändern gezielt einen Wert per Named Parameter
    public double BerechnePreis(double grundgebuehr = 3.50, double preisProKm = 1.20, double freigewichtKg = 2.0, double zuschlagProKg = 0.80)
    {
        // eigene Methode verwenden: der Auftrag kennt seine Strecke selbst
        double preis = grundgebuehr + BerechneStreckeKm() * preisProKm;

        if (GewichtKg > freigewichtKg)
        {
            preis += (GewichtKg - freigewichtKg) * zuschlagProKg;
        }

        return Math.Round(preis, 2);
    }

    // "LF-0007  Müller Gmbh           2,69 km    6,73 €"
    public string FormatiereBerichtZeile(int maxKundenLaenge = 18)
    {
        string kunde = Kunde;

        // Guard: zu langer Kundenname -> kürzen, das "…" ist das letzte erlaubte Zeichen
        if (kunde.Length > maxKundenLaenge)
        {
            kunde = kunde.Substring(0, maxKundenLaenge - 1) + "…";
        }

        return Nummer.PadRight(9)
             + kunde.PadRight(maxKundenLaenge + 2)
             + $"{BerechneStreckeKm():F2} km".PadLeft(10)
             + $"{BerechnePreis():F2} €".PadLeft(10);
    }
}
