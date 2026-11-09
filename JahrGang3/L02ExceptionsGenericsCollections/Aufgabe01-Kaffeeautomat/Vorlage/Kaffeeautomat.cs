public class Kaffeeautomat
{
    private const int MaxBezuegeOhneEntkalken = 4;

    // TODO Teil 4: Eigenschaften Wassertank, Bohnenbehaelter, Milchtank (Behaelter), Karte (Getraenk[]),
    //              IstEingeschaltet (bool), BezuegeSeitEntkalken (int) – alle nur intern setzbar

    public Kaffeeautomat()
    {
        // TODO Teil 4: Behälter anlegen – Wasser 1000 ml, Bohnen 50 g, Milch 300 ml.
        //              Jeder Behälter muss GENAU diesen Automaten kennen.

        // TODO Teil 4: Karte mit Collection- und Object Initializer anlegen:
        //   Espresso:   40 ml Wasser,  9 g Bohnen
        //   Kaffee:    200 ml Wasser, 12 g Bohnen
        //   Cappuccino: 60 ml Wasser,  9 g Bohnen, 150 ml Milch
        //   Latte:      50 ml Wasser,  9 g Bohnen, 250 ml Milch
    }

    public void Einschalten()
    {
        throw new NotImplementedException();
    }

    public void Entkalken()
    {
        throw new NotImplementedException();
    }

    public Getraenk SucheGetraenk(string name)
    {
        throw new NotImplementedException();
    }

    public void Bruehe(string name)
    {
        throw new NotImplementedException();
    }

    // z.B. "Wasser 960/1000 ml | Bohnen 41/50 g | Milch 300/300 ml | Bezüge seit Entkalken: 1"
    public string Status()
    {
        throw new NotImplementedException();
    }
}
