// Schreibt Zeilen in eine Textdatei. Die Datei bleibt offen, bis Dispose() aufgerufen wird.
public class Protokoll : IDisposable
{
    private StreamWriter _writer;

    public int Zeilen { get; private set; }

    public Protokoll(string pfad)
    {
        _writer = new StreamWriter(pfad);
        Console.WriteLine("Protokoll geöffnet");
    }

    public void Schreiben(string zeile)
    {
        _writer.WriteLine(zeile);
        Zeilen++;
    }

    public void Dispose()
    {
        _writer.Dispose();
        Console.WriteLine("Protokoll geschlossen");
    }
}
