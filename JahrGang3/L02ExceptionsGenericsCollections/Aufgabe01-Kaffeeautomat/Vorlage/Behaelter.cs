public class Behaelter
{
    // TODO Teil 3: Eigenschaften Zutat, Einheit, Kapazitaet – nur intern setzbar

    // TODO Teil 3: Eigenschaft Automat – der Kaffeeautomat, in dem der Behälter steckt (nur intern setzbar)

    // TODO Teil 3: Eigenschaft Inhalt mit eigenem Setter (Schlüsselwort field):
    //              Wert < 0 oder > Kapazitaet -> ArgumentOutOfRangeException

    public Behaelter(Kaffeeautomat automat, string zutat, string einheit, int kapazitaet)
    {
        // TODO Teil 3: alles speichern, ein neuer Behälter ist voll
    }

    // Wirft eine ZutatLeerException, wenn zu wenig da ist – entnimmt aber nichts.
    public void PruefeMenge(int menge)
    {
        throw new NotImplementedException();
    }

    public void Entnehmen(int menge)
    {
        throw new NotImplementedException();
    }

    // Gibt zurück, wie viel übergelaufen ist.
    public int Auffuellen(int menge)
    {
        throw new NotImplementedException();
    }

    // z.B. "Wasser 960/1000 ml"
    public override string ToString()
    {
        throw new NotImplementedException();
    }
}
