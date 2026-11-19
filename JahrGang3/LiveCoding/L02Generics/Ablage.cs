// Schritt 3: generische Klasse mit einem Typparameter.
// Ein Stapel: was zuletzt hineingelegt wurde, kommt zuerst wieder heraus.
public class Ablage<T>
{
    private T[] fach;
    public int Anzahl { get; private set; }

    public Ablage(int groesse = 3)
    {
        fach = new T[groesse];
        Anzahl = 0;
    }

    public void Lege(T wert)
    {
        if (Anzahl == fach.Length)
        {
            throw new InvalidOperationException("Die Ablage ist voll.");
        }
        fach[Anzahl] = wert;
        Anzahl++;
    }

    public T Nimm()
    {
        if (Anzahl == 0)
        {
            throw new InvalidOperationException("Die Ablage ist leer.");
        }
        Anzahl--;
        return fach[Anzahl];
    }
}
