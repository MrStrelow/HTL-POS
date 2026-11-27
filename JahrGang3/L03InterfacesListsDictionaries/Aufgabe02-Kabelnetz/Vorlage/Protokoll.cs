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
        // TODO Teil 6: Zeile mit _writer schreiben und Zeilen um 1 erhöhen
    }

    public void Dispose()
    {
        // TODO Teil 6: _writer freigeben und "Protokoll geschlossen" ausgeben
    }
}
