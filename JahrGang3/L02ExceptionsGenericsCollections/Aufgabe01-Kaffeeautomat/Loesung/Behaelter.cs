public class Behaelter
{
    public string Zutat { get; private set; }
    public string Einheit { get; private set; }
    public int Kapazitaet { get; private set; }

    // Bidirektionale Hat-Beziehung: der Behälter kennt GENAU den Automaten, in dem er steckt
    public Kaffeeautomat Automat { get; private set; }

    // Der Setter schützt den Zustand: Inhalt kann nie negativ oder größer als die Kapazität werden.
    // Passiert das trotzdem, ist es ein Programmierfehler -> Exception.
    public int Inhalt
    {
        get;
        private set
        {
            if (value < 0 || value > Kapazitaet)
            {
                throw new ArgumentOutOfRangeException(nameof(Inhalt), $"{Zutat}: Inhalt muss zwischen 0 und {Kapazitaet} liegen.");
            }
            field = value;
        }
    }

    public Behaelter(Kaffeeautomat automat, string zutat, string einheit, int kapazitaet)
    {
        Automat = automat;
        Zutat = zutat;
        Einheit = einheit;
        Kapazitaet = kapazitaet;
        Inhalt = kapazitaet; // ein neuer Behälter ist voll
    }

    // Wirft eine Exception, wenn nicht genug da ist – entnimmt aber NICHTS.
    public void PruefeMenge(int menge)
    {
        if (menge > Inhalt)
        {
            throw new ZutatLeerException(Zutat, menge, Inhalt);
        }
    }

    public void Entnehmen(int menge)
    {
        PruefeMenge(menge);
        Inhalt -= menge;
    }

    // Ein Überlauf ist ERWARTBAR (man schüttet einfach zu viel hinein) -> kein throw, sondern Rückgabewert.
    // Eine Menge <= 0 ist ein falscher Aufruf -> Exception.
    public int Auffuellen(int menge)
    {
        if (menge <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(menge), "Die Menge muss positiv sein.");
        }

        int platz = Kapazitaet - Inhalt;

        if (menge > platz)
        {
            Inhalt = Kapazitaet;
            return menge - platz;
        }

        Inhalt += menge;
        return 0;
    }

    public override string ToString()
    {
        return $"{Zutat} {Inhalt}/{Kapazitaet} {Einheit}";
    }
}
