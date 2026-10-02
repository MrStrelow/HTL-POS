using System.Text;

public class User
{
    public string Name { get; set; }
    public int Age { get; set; }
    public bool IsRegistered { get; set; }
<<<<<<< HEAD
    public string Blutgruppe { get; set; }

    public User(string name, int age, bool isRegistered, string blutgruppe)
=======

    public User(string name, int age, bool isRegistered)
>>>>>>> 744d9106670cd0e39e738336259f54e87fdea8ec
    {
        Name = name;
        Age = age;
        IsRegistered = isRegistered;
<<<<<<< HEAD
        Blutgruppe = blutgruppe;
    }

    public void ProcessUserNestedIf()
    {
        if (Blutgruppe != "0" || Blutgruppe != "AB" || Blutgruppe.Contains("+"))
        {
            if (IsRegistered)
            {
                if (Age >= 18)
=======
    }

    public void ProcessUserNestedIf(User user)
    {
        if (user is not null)
        {
            if (user.IsRegistered)
            {
                if (user.Age >= 18)
>>>>>>> 744d9106670cd0e39e738336259f54e87fdea8ec
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
<<<<<<< HEAD
            Console.WriteLine("❌User is not behaving in a expected way.");
        }
    }

    public void ProcessUserGuardClause()
=======
            Console.WriteLine("❌User is null.");
        }
    }

    public void ProcessUserGuardClause(User user)
>>>>>>> 744d9106670cd0e39e738336259f54e87fdea8ec
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
<<<<<<< HEAD
        user.ProcessUserNestedIf();
        user.ProcessUserGuardClause();
=======
        user.ProcessUserNestedIf(user);
        user.ProcessUserGuardClause(user);
>>>>>>> 744d9106670cd0e39e738336259f54e87fdea8ec
    }
}
