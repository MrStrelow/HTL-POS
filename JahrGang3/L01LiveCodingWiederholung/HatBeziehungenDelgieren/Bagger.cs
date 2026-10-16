public class Bagger
{
    public Baugrube Baugrube { get; private set; }
    public (int x, int y) Position { get; private set; }

    public Bagger(Baugrube baugrube)
    {
        Baugrube = baugrube;
        Platzieren();
    }

    public void Platzieren() 
    {
        Random random = new Random();
        
        do
        {
            Position = (random.Next(0, Baugrube.Size), random.Next(0, Baugrube.Size));
        } while (!Baugrube.Anfrage(this, Position));
    }
}
