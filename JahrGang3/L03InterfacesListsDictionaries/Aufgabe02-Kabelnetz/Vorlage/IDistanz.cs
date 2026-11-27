// Vertrag: "Ich kann ausrechnen, wie weit zwei Positionen auseinander sind."
// WIE gerechnet wird, entscheidet die Klasse, die den Vertrag umsetzt.
public interface IDistanz
{
    string Name { get; }
    double Berechnen(Position a, Position b);
}
