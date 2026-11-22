namespace Hamster;

public class Hamster
{
    // Felder
    public static string _hungryRepresentation = "😡";
    private static string _fedRepresentation = "🐹";

    // Eigenschaften
    public bool IsHungry { get; private set; }
    public string Representation { get; private set; } = _fedRepresentation;
    public (int x, int y) Position { get; private set; }

    // Konstruktoren
    public Hamster(____)
    {
        // TODO:
        // 1. Initialisiere die Felder des Hamsters.
        // 2. Erstelle und rufe im Hamster die private Methode PositionAndManageHamster auf.
    }

    // Methoden
    ____ Move(____)
    {
        // TODO:
        // 1. Lasse den Hamster wählen wo er hin möchte. Das wären die 4 Richtungen im Enum Direction.
        // 2. Erstelle das Enum direction und gib dort UP, DOWN, LEFT, RIGHT als Zustände ein.
        // 3. Frage die Plane mit der Methode Position ob die berechnete Richtung umgesetzt werden kann.
        //      Die Plane antwortet dann mit der Position für den Hamster. 
        // 4. Weise die neue Position dem Hamster zu.
    }

    // private Methoden
    ____ PositionAndManageHamster(____)
    {
        // 1. Lasse den Hamster entscheiden wo er hin möchte. (wir sagen zufällig)
        // 2. Delegiere die Berechnung ob wir auf einem freien Feld sind, an die Plane
        //      mithilfe der Methode AssignInitialPosition(...).
        // 3. Falls die Plane mit "Nein, gewünschtes Feld war nicht frei." antwortet,
        //      ziehe eine neue zufällige Position und wiederhole die anfrage an AssignInitialPosition.
        // 4. Falls die Plane mit "Ja, gewünschtes Feld ist frei." antwortet, weise der Position des Hamsters diese zu.
    }
}
