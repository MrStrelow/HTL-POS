// Ein Hamster trägt immer einen Seedling herum (hat-Beziehung).
class Hamster
{
    // Felder: der Zustand
    public string _representation;
    public (int x, int y) _position;
    public Seedling _mouth;           // hat-Beziehung
    public int _planeSize = 10;       // fix, wird nicht im Konstruktor gesetzt

    // Konstruktor: der Startzustand
    public Hamster((int x, int y) position, Seedling mouth)
    {
        _representation = "🐹";
        _position = position;
        _mouth = mouth;

        public void Move();
    }

    // Methoden: das Verhalten
    public void Move()
    {
        // der Seedling, den er herumträgt, kommt mit (bleibt dort liegen, falls er gleich getauscht wird)
        _mouth._position = _position;

        // ganz oben angekommen? -> unten wieder hinein
        if (_position.y == 0)
        {
            _position.y = _planeSize;
        }

        _position.y--;
    }
}
