// Teil 6: out -> T kommt nur HERAUS (Rueckgabe)
public interface IZugQuelle<out T>
{
    int Count { get; }
    T Get(int position);
}

// Teil 6: in -> T geht nur HINEIN (Parameter)
public interface IVerlader<in T>
{
    void Verlade(T ladung);
}

// Das Lager nimmt JEDE Fracht an.
public class Lager : IVerlader<Fracht>
{
    public int Anzahl { get; private set; }
    public int Tonnen { get; private set; }

    public void Verlade(Fracht ladung)
    {
        Anzahl++;
        Tonnen += ladung.Tonnen;
    }

    public override string ToString()
    {
        return "Lager: " + Anzahl + " Frachtstücke, " + Tonnen + " t";
    }
}
