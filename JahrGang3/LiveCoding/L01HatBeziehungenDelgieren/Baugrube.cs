public class Baugrube
{
    public Bagger[] Bagger { get; private set; }
    public string[,] Grube { get; private set; }
    public int Size { get; private set; }

    public Baugrube(int size, int numberOfBagger)
    {
        Size = size;
        Grube = new string[size, size];
        
        // Initialisierung der Grube mit Erde
        for (int y = 0; y < Size; y++)
        {
            for (int x = 0; x < Size; x++)
            {
                Grube[y, x] = "🟫";
            }
        }

        // Bagger platzieren
        Bagger = new Bagger[numberOfBagger];

        for (int i = 0; i < numberOfBagger; i++)
        {
            Bagger[i] = new Bagger(this);
        }

        // Wasser und Steine zufällig platzieren
        Random random = new Random();
        for (int i = 0; i < (Size*Size) / 4; i++)
        {
            int x = random.Next(0, Size);
            int y = random.Next(0, Size);
            Grube[y, x] = "💧"; 

            x = random.Next(0, Size);
            y = random.Next(0, Size);
            Grube[y, x] = "🗿";
        }
    }

    public bool Anfrage(Bagger bagger, (int x, int y) position)
    {
        // ❌ Ungeweunschter Zustand: Position außerhalb der Grube
        if (
            position.x < 0 || position.x >= Grube.GetLength(1) || 
            position.y < 0 || position.y >= Grube.GetLength(0)
        )
        {
            return false;
        }
        
        // ❌ Ungeweunschter Zustand: Position ist mit Wasser besetzt oder ist ein Loch
        if (Grube[position.y, position.x] == "💧" || Grube[position.y, position.x] == "🗿")
        {
            return false;
        }

        // ✅ Gewünschter Zustand: Position ist frei
        Grube[position.y, position.x] = "🏗️";

        return true;
    }

    public void Print()
    {
        for (int y = 0; y < Size; y++)
        {
            for (int x = 0; x < Size; x++)
            {
                Console.Write(Grube[y, x]);
            }
            Console.WriteLine();
        }
    }
}
