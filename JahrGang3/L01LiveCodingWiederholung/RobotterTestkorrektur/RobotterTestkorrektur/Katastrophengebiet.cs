public class Katastrophengebiet
{
    // Felder
    private string[,] _weltkarte;

    // Eingeschaften
    public Helikopter[] Helikopter { get; set; }
    public int Groesse { get; set; }

    // Konstruktor
    public Katastrophengebiet(int groesse)
    {
        if ( groesse < 15 )
        {
            Groesse = 15;
        }
        else
        {
            Groesse = groesse;
        }

        _weltkarte = new string[Groesse, Groesse];

        for (int y = 0; y < Groesse; y++)
        {
            for (int x = 0; x < Groesse; x++)
            {
                _weltkarte[y, x] = "🟫";
            }
        }

        Random random = new Random();
        int gesamtFläche = Groesse * Groesse;
        int anzahlLoecher = (int) (gesamtFläche * 0.2);
        int plazierteLoecher = 0;

        while (plazierteLoecher < anzahlLoecher)
        {
            int y = random.Next(0, Groesse);
            int x = random.Next(0, Groesse);

            if (_weltkarte[y,x] == "🟫")
            {
                _weltkarte[y, x] = "🕳️";
                plazierteLoecher++;
            }
        }

        int anzahlWasser = (int)(gesamtFläche * 0.2);
        int plaziertesWasser = 0;

        while (plaziertesWasser < anzahlWasser)
        {
            int y = random.Next(0, Groesse);
            int x = random.Next(0, Groesse);

            if (_weltkarte[y, x] == "🟫")
            {
                _weltkarte[y, x] = "💧";
                plaziertesWasser++;
            }
        }


    }
}
