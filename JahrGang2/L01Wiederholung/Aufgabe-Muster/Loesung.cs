namespace Exercise2;
class Program
{
    static void Main()
    {
        // 1) Was sind meine Variablen?
        // x und y jeweils int Variablen - diese sind die Positionen der x und y Achse.
        int x = 0;
        int y = 0;

        // 2) Nur vertikale Streifen (Abhängig von x)
        bool weiß = x % 2 == 0;
        bool schwarz = !weiß;

        // 3) Klassisches Schachbrettmuster (Zeile und Spalte wechseln sich ab)
        weiß = (x % 2 == 0 && y % 2 == 0) || (x % 2 == 1 && y % 2 == 1);
        schwarz = !weiß;

        // 4) Schachbrettmuster mit Dreiecken/Rot-Einschlüssen (Summe ungleich Vielfaches von 3)
        weiß = (x % 2 == 0 && y % 2 == 0 && (x + y) % 3 != 0) || (x % 2 == 1 && y % 2 == 1 && (x + y) % 3 != 0);
        schwarz = (x % 2 == 1 && y % 2 == 0 && (x + y) % 3 != 0) || (x % 2 == 0 && y % 2 == 1 && (x + y) % 3 != 0);
        bool rot = (x + y) % 3 == 0;

        // 5) Die elegante Schachbrett-Formel über die Diagonale (Summe von x und y)
        weiß = (x + y) % 2 == 0;
        schwarz = (x + y) % 2 == 1;

        // 6) Nur der Rand ist schwarz, innen ist alles weiß (angenommenes 6x6 Feld von 0 bis 5)
        schwarz = y == 0 || y == 5 || x == 0 || x == 5;
        weiß = !schwarz;

        // 7) Äußerer Rand schwarz, innen abwechselnde Muster (angepasst auf ein 6x6 Brett von 0 bis 5)
        // Tipp: Wir definieren den Rahmen und nutzen das Negieren für Weiß, um Arbeit zu sparen.
        schwarz = (y == 0 || y == 5 || x == 0 || x == 5) || ((x + y) % 2 == 0 && x > 0 && x < 5 && y > 0 && y < 5);
        weiß = !schwarz;
    }
}