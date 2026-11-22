// Das Spielfeld: ein 2D-Array zum Zeichnen, Hamster im Array, Seedlings im Dictionary.
class Plane
{
    // Felder
    private string[,] _plane;
    private string _earthRepresentation = "🟫";
    private Hamster[] _hamsters;

    // hat-Beziehung: viele Seedlings, schnell über ihre Position zu finden -> Dictionary
    private Dictionary<(int x, int y), Seedling> _seedlings = new Dictionary<(int x, int y), Seedling>();

    // Properties
    public int Size { get; private set; }

    // Konstruktor: der Startzustand
    public Plane(int size, Hamster[] hamsters, Seedling[] seedlings)
    {
        // TODO Schritt 1:
        //   Size setzen, _plane als 2D-Array size x size anlegen, _hamsters speichern
        //   jeden seedling mit seiner Position als Schlüssel ins Dictionary _seedlings eintragen
    }

    // Methoden: das Verhalten
    public void Simulate(string direction)
    {
        // TODO Schritt 3: jeden Hamster mit Move(direction) bewegen
        // TODO Schritt 4: danach
        //   Guard: liegt auf hamster.Position KEIN Seedling (_seedlings.ContainsKey)? -> continue
        //   hamster.Eat(...) mit dem Seedling aus dem Dictionary aufrufen und ihn aus _seedlings entfernen
    }

    public void Print()
    {
        AssignRepresentations();

        // TODO Schritt 2: das 2D-Array _plane Zeile für Zeile (y), Feld für Feld (x) ausgeben

        // TODO Schritt 4: für jeden Hamster eine Zeile ausgeben, z. B.
        //   "🐹 33826822 auf (1, 2) – im Mund: 🌱🌱"   (alle Seedlings in Mouth aneinanderhängen)
    }

    // Zuerst überall Erde, dann die Seedlings, dann die Hamster ins 2D-Array schreiben
    private void AssignRepresentations()
    {
        // TODO Schritt 2:
        //   jedes Feld von _plane auf _earthRepresentation setzen
        //   jeden Seedling aus _seedlings.Values an _plane[Position.y, Position.x] schreiben
        //   jeden Hamster aus _hamsters an _plane[Position.y, Position.x] schreiben
    }
}
