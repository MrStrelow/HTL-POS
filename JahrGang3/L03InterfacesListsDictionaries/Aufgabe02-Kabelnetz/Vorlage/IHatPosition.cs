// hat-Beziehung im Vertrag: Wer IHatPosition ist, HAT eine Position.
// Ein Interface kann kein Feld vorschreiben – nur eine Property.
public interface IHatPosition
{
    string Name { get; }
    Position Position { get; }
}
