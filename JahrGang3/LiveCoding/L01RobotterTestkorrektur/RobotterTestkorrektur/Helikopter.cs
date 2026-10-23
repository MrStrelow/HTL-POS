using System.ComponentModel;

public class Helikopter
{
    // Eigenschaften
    public Katastrophengebiet Katastrophengebiet { get; set; }
    public Roboter Roboter { get; set; }

    // Konstruktor
    public Helikopter(Katastrophengebiet katastrophengebiet, (int x, int y) zielPosition) 
    {
        Katastrophengebiet = katastrophengebiet;
        Roboter = new Roboter(katastrophengebiet, zielPosition);

        PositioniereRobotter();
    }

    // Methoden
    public void PositioniereRobotter()
    {
        Random random = new Random();
        (int x, int y) position = Roboter.GewünschtePosition;

        while (!Katastrophengebiet.IstAbladbar(position))
        {
            position = (random.Next(0, Katastrophengebiet.Groesse), random.Next(0, Katastrophengebiet.Groesse));
        }

        Roboter.AktuellePosition = position;
        Roboter.Suchen();
    }
}
