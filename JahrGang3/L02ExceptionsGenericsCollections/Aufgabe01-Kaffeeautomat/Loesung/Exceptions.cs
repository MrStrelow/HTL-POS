// Eigene Exceptions: Ausnahmefälle, die eine Methode selbst NICHT lösen kann.

public class ZutatLeerException : Exception
{
    // Zusatzdaten, damit der Aufrufer im catch gezielt reagieren kann
    public string Zutat { get; private set; }
    public int Benoetigt { get; private set; }
    public int Vorhanden { get; private set; }

    public ZutatLeerException(string zutat, int benoetigt, int vorhanden)
        : base($"{zutat} reicht nicht: benötigt {benoetigt}, vorhanden {vorhanden}.")
    {
        Zutat = zutat;
        Benoetigt = benoetigt;
        Vorhanden = vorhanden;
    }
}

public class EntkalkenNoetigException : Exception
{
    public int Bezuege { get; private set; }

    public EntkalkenNoetigException(int bezuege)
        : base($"Entkalken nötig! {bezuege} Bezüge seit dem letzten Entkalken.")
    {
        Bezuege = bezuege;
    }
}
