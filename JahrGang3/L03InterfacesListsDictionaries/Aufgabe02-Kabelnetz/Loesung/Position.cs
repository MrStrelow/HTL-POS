// Ein Punkt auf dem Gebäudeplan (in Metern).
// record = Referenztyp mit WERTsemantik und unveränderlich
//  -> zwei Positionen mit gleichem X und Y sind gleich (Equals, GetHashCode und == schreibt der Compiler)
//  -> darum ein guter Key für ein Dictionary
public record Position(int X, int Y);
