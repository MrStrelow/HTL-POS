// Eine Drohne HAT einen Stadtplan (hat-Beziehung) und merkt sich, was sie schon geliefert hat.
class Drohne
{
    public string Name { get; set; }
    public Stadtplan Plan { get; set; }          // hat-Beziehung
    public double MaxGewichtKg { get; set; }
    public int AnzahlLieferungen { get; set; }
    public double GeflogeneKm { get; set; }

    public Drohne(string name, Stadtplan plan, double maxGewichtKg = 5.0)
    {
        Name = name;
        Plan = plan;
        MaxGewichtKg = maxGewichtKg;
        AnzahlLieferungen = 0;
        GeflogeneKm = 0;
    }

    // Wie int.TryParse: true = geliefert, false = Grund steht in fehlergrund
    public bool TryLiefern(Auftrag auftrag, out string fehlergrund)
    {
        fehlergrund = "";

        // Guard: über die hat-Beziehung fragt die Drohne ihren Stadtplan
        if (!Plan.IstInnerhalb(auftrag.Start) || !Plan.IstInnerhalb(auftrag.Ziel))
        {
            fehlergrund = $"{auftrag.Nummer} – außerhalb des Stadtplans";
            return false;
        }

        // Guard: Tupel kann man direkt mit == vergleichen
        if (auftrag.Start == auftrag.Ziel)
        {
            fehlergrund = $"{auftrag.Nummer} – Start und Ziel sind gleich";
            return false;
        }

        // Guard: zu schwer für DIESE Drohne
        if (auftrag.GewichtKg > MaxGewichtKg)
        {
            fehlergrund = $"{auftrag.Nummer} – zu schwer ({auftrag.GewichtKg:F2} kg)";
            return false;
        }

        Console.WriteLine($"\n📦 {Name} liefert {auftrag.Nummer} für {auftrag.Kunde}");

        // Guard: Route führt durch eine Sperrzone
        if (!Plan.ZeichneRoute(auftrag))
        {
            Console.WriteLine("⛔ Route führt durch eine Sperrzone!");
            fehlergrund = $"{auftrag.Nummer} – Route durch Sperrzone";
            return false;
        }

        // gewünschter Zustand: die Drohne merkt sich die Lieferung
        AnzahlLieferungen++;
        GeflogeneKm += auftrag.BerechneStreckeKm();
        Console.WriteLine($"✅ {auftrag.BerechneStreckeKm():F2} km, {auftrag.BerechnePreis():F2} €");
        return true;
    }

    public string Statistik()
    {
        return $"{Name}: {AnzahlLieferungen} Lieferungen, {GeflogeneKm:F2} km";
    }
}
