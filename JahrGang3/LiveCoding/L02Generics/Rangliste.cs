// Schritt 4: generische Klasse mit ZWEI Typparametern.
// Nur TPunkte wird eingeschraenkt - mit dem Namen rechnen wir nicht.
public class Rangliste<TName, TPunkte> where TPunkte : IComparable<TPunkte>
{
    private TName? bester;
    private TPunkte? bestePunkte;
    private bool leer = true;

    public void Eintragen(TName name, TPunkte punkte)
    {
        if (leer || punkte.CompareTo(bestePunkte) > 0)
        {
            bester = name;
            bestePunkte = punkte;
            leer = false;
        }
    }

    public TName? Bester()
    {
        return bester;
    }
}
