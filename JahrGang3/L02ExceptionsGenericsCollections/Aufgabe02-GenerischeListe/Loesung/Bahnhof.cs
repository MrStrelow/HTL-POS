using System.Collections;

// Teil 2, 3, 5 und 6: Die Klasse selbst ist NICHT generisch.
// Jede Methode hat ihren eigenen Typparameter.
public static class Bahnhof
{
    // ---------- Teil 2: generische Methoden ----------
    public static Zug<T> AusArray<T>(T[] ladungen)
    {
        Zug<T> zug = new Zug<T>();
        foreach (T ladung in ladungen)
        {
            zug.AnhaengenHinten(ladung);
        }
        return zug;
    }

    public static Zug<T> Wenden<T>(Zug<T> zug)
    {
        Zug<T> gewendet = new Zug<T>();
        Waggon<T>? curr = zug.Tail;
        while (curr != null)
        {
            gewendet.AnhaengenHinten(curr.Ladung);
            curr = curr.Prev;
        }
        return gewendet;
    }

    // zwei Typparameter: die beiden Zuege duerfen verschiedene Ladungen haben
    public static Zug<Paar<TA, TB>> Kuppeln<TA, TB>(Zug<TA> a, Zug<TB> b)
    {
        Zug<Paar<TA, TB>> ergebnis = new Zug<Paar<TA, TB>>();
        Waggon<TA>? currA = a.Head;
        Waggon<TB>? currB = b.Head;
        while (currA != null && currB != null)
        {
            ergebnis.AnhaengenHinten(new Paar<TA, TB>(currA.Ladung, currB.Ladung));
            currA = currA.Next;
            currB = currB.Next;
        }
        return ergebnis;
    }

    // ---------- Teil 3: Einschraenkungen mit where ----------
    public static T Groesste<T>(Zug<T> zug) where T : IComparable<T>
    {
        if (zug.Head == null)
        {
            throw new InvalidOperationException("Der Zug hat keine Waggons.");
        }

        T max = zug.Head.Ladung;
        Waggon<T>? curr = zug.Head.Next;
        while (curr != null)
        {
            if (curr.Ladung.CompareTo(max) > 0)
            {
                max = curr.Ladung;
            }
            curr = curr.Next;
        }
        return max;
    }

    // where T : Fracht -> wir duerfen .Tonnen verwenden
    public static int Gesamtgewicht<T>(Zug<T> zug) where T : Fracht
    {
        int summe = 0;
        Waggon<T>? curr = zug.Head;
        while (curr != null)
        {
            summe += curr.Ladung.Tonnen;
            curr = curr.Next;
        }
        return summe;
    }

    // where T : new() -> wir duerfen new T() schreiben
    public static Zug<T> Leerzug<T>(int anzahl) where T : new()
    {
        Zug<T> zug = new Zug<T>();
        for (int i = 0; i < anzahl; i++)
        {
            zug.AnhaengenHinten(new T());
        }
        return zug;
    }

    // where T : class -> T kann null sein, return null ist erlaubt
    public static T? ErsteOderNull<T>(Zug<T> zug) where T : class
    {
        if (zug.Head == null)
        {
            return null;
        }
        return zug.Head.Ladung;
    }

    // where T : struct -> T ist nie null, T? ist Nullable<T>
    public static T? ErsterWertOderNull<T>(Zug<T> zug) where T : struct
    {
        if (zug.Head == null)
        {
            return null;
        }
        return zug.Head.Ladung;
    }

    // ---------- Teil 5: Wert- und Referenzsemantik ----------
    // 5b: a und b sind KOPIEN -> nach aussen aendert sich nichts
    public static void TauschenOhneRef<T>(T a, T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }

    // 5b: a und b SIND die Variablen des Aufrufers -> Seiteneffekt bei jedem T
    public static void Tauschen<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }

    // 5c: where T : IList -> a[0] ist erlaubt. Kopie der Referenz, aber wir
    // aendern das Objekt, auf das a zeigt -> Seiteneffekt
    public static void ErstesTauschen<T>(T a, T b) where T : IList
    {
        object? temp = a[0];
        a[0] = b[0];
        b[0] = temp;
    }

    // 5d: class -> Kopie der Referenz -> Seiteneffekt
    //     struct -> Kopie des Werts -> KEIN Seiteneffekt
    public static void Etikettieren<T>(T ladung, string etikett) where T : IEtikett
    {
        ladung.Etikett = etikett;
    }

    // 5d: class garantiert: ladung zeigt auf das Original
    public static void EtikettierenSicher<T>(T ladung, string etikett) where T : class, IEtikett
    {
        ladung.Etikett = etikett;
    }

    // ---------- Teil 6: Ko- und Kontravarianz ----------
    // kein Typparameter! Funktioniert dank out fuer Zug<Holz>, Zug<Kohle>, ...
    public static void Anzeigen(IZugQuelle<Fracht> zug)
    {
        for (int i = 0; i < zug.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + zug.Get(i));
        }
    }

    // dank in darf ziel ein IVerlader<Fracht> sein, auch wenn T = Holz ist
    public static void AllesEntladen<T>(Zug<T> zug, IVerlader<T> ziel)
    {
        while (zug.Count > 0)
        {
            ziel.Verlade(zug.AbkuppelnVorne());
        }
    }
}
