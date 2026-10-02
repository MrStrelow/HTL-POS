using System.Text;

public class User
{
    public string Name { get; set; }
    public int Age { get; set; }
    public bool IsRegistered { get; set; }

    public User(string name, int age, bool isRegistered)
    {
        Name = name;
        Age = age;
        IsRegistered = isRegistered;
    }

    public void ProcessUserNestedIf(User user)
    {
        if (user is not null)
        {
            if (user.IsRegistered)
            {
                if (user.Age >= 18)
                {
                    Console.WriteLine("✅ User is processed.");
                }
                else
                {
                    Console.WriteLine("❌User is too young.");
                }
            }
            else
            {
                Console.WriteLine("❌User is not registered.");
            }
        }
        else
        {
            Console.WriteLine("❌User is null.");
        }
    }

    public void ProcessUserGuardClause(User user)
    {
        //TODO: Hier deine Guard Clause Logik einfügen.
        throw new NotImplementedException("TODO: Guard Clause Implementierung der Methode: ProcessUserNestedIf");
    }
}

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        User user = new User("Alice", 25, true);
        user.ProcessUserNestedIf(user);
        user.ProcessUserGuardClause(user);
    }
}
