using System.Text;

public class User
{
    public string Name { get; set; }
    public int Age { get; set; }
    public bool IsRegistered { get; set; }
    public string Blutgruppe { get; set; }

    public User(string name, int age, bool isRegistered, string blutgruppe)
    {
        Name = name;
        Age = age;
        IsRegistered = isRegistered;
        Blutgruppe = blutgruppe;
    }

    public void ProcessUserNestedIf()
    {
        if (Blutgruppe != "0" || Blutgruppe != "AB" || Blutgruppe.Contains("+"))
        {
            if (IsRegistered)
            {
                if (Age >= 18)
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
            Console.WriteLine("❌User is not behaving in a expected way.");
        }
    }

    public void ProcessUserGuardClause()
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

        User user = new User("Alice", 25, true, "A+");
        user.ProcessUserNestedIf();
        user.ProcessUserGuardClause();
    }
}
