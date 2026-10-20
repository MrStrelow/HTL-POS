public class Helikopter
{
    // Eigenschaften
    public Katastrophengebiet Katastrophengebiet { get; set; }
    public Roboter Roboter { get; set; }

    // Konstruktor
    public Helikopter(Katastrophengebiet katastrophengebiet, (int x, int y) zielPosition) 
    {
        Katastrophengebiet = katastrophengebiet;
        Roboter roboter = new Roboter(katastrophengebiet, zielPosition);

        PositioniereRobotter();
    }

    // Methoden
    public void PositioniereRobotter()
    {

    }
}
