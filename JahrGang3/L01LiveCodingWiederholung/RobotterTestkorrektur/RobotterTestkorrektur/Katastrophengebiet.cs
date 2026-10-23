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

        int anzahlWasser = (int)(gesamtFläche * 0.3);
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

        Helikopter = new Helikopter[_weltkarte.Length / 10];
        Helikopter[0] = new Helikopter(this, (4, 6));
        Helikopter[1] = new Helikopter(this, (2, 7));
        Helikopter[2] = new Helikopter(this, (6, 9));
        
        for (int i = 3; i < Helikopter.Length; i++)
        {                
            (int x, int y) wunschPos = (random.Next(0, Groesse), random.Next(0, Groesse));
            Helikopter[i] = new Helikopter(this, wunschPos);
        }
    }

    // Methoden
    public bool IstAbladbar((int x, int y) position)
    {
        if (position.y < 0 || position.y >= Groesse || position.x < 0 || position.x >= Groesse)
        {
            return false;
        }

        if (_weltkarte[position.y, position.x] != "🟫")
        {
            return false;
        }

        _weltkarte[position.y, position.x] = "🤖";
        return true;
    }

    public void Print()
    {
        for (int y = 0; y < Groesse; y++)
        {
            for (int x = 0; x < Groesse; x++)
            {
                Console.Write(_weltkarte[y, x]);
            }

            Console.WriteLine();
        }
    }
}
