namespace Hamster;

public class Seedling
{
    // Felder
    // Eigenschaften
    public Plane Plane { get; private set; }
    public (int x, int y) Position { get; private set; }
    // Beziehungen
    // Konstruktoren
    public Seedling(____)
    {
        // TODO:
        // 1. Lasse den Seedling entscheiden wo er hin möchte. (wir sagen zufällig)
        // 2. Delegiere die Berechnung ob wir auf einem freien Feld sind, an die Plane
        //      mithilfe der Methode AssignInitialPosition(Seedling seedling, (int x, int y) position).
        // 3. Falls die Plane mit "Nein, gewünschtes Feld war nicht frei." antwortet,
        //      ziehe eine neue zufällige Position und wiederhole die anfrage an AssignInitialPosition.
        // 4. Falls die Plane mit "Ja, gewünschtes Feld ist frei." antwortet, weise der Position des Seedlings diese zu.
    }

    // Methoden
    // private Methoden
}
