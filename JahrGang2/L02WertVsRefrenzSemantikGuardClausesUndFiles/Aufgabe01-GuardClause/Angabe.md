Welche ``Konzepte`` der Programmiersprache üben wir hier?
* verschachtelte IF-Verzweigungen
* *Console.WriteLine* für Ausgabe und ``early-exit`` mit *return*;
* Boolesche Algebra

Welche ``Denkweisen`` üben wir hier?
* Wie forme ich ``If-Verzweigungen`` um, ohne deren ``Logik`` zu verändern?

Bei Unklarheiten hier nachlesen: 
* [Was sind gaurd clauses und de morgan's law?](../Skripten/L01.1GuardClauses.md)

## Projektstruktur
Erstelle für jede der folgenden ``Aufgaben`` jeweils ein ``Projekt``, welche sich alle in einer ``Solution`` (Projektmappe) befinden.
In einem Projekt kann nur *eine* ausfürhbare ``Klasse`` sein. Also nur ein ``Main-Methode`` oder ein ``Top-Level Statement``.

>Für VS: Erstelle dazu eine ``Solution``(Projektmappe) und in dieser ``Solution`` (Projektmappe), füge mit *Rechtsclick auf die Solution (![alt text](image.png)) -> Add (Hinzufügen) -> new Project (neues Projekt) mit Namen Aufgabe 1* ein neues ``Projekt`` in der bestehenden ``Solution`` ein. Wiederhole für Aufgabe 2 und 3.

## Schreibe verschachtelte Ifs in eine Guard Clause um.

### Aufgabe 1 - level: 🙂 - Ein gewünschter Zustand
Implementiere eine 2. ``Methode`` *ProcessUserGuardClause* und teste ob diese gleich der *ProcessUserNestedIf* ist.

```csharp
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

<<<<<<< HEAD
    public void ProcessUserNestedIf()
    {
        if (Name != "Mathias")
=======
    public void ProcessUserNestedIf(User user)
    {
        if (user is not null)
>>>>>>> 744d9106670cd0e39e738336259f54e87fdea8ec
        {
            if (IsRegistered)
            {
                if (Age >= 18)
                {
                    Console.WriteLine("✅User is processed.");
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

    public void ProcessUserGuardClause(User user) {
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
```

### Aufgabe 2 - level: 🤔 - Mehrere gwünschte Zustände
Hier eine kompliziertere Abfrage. Diese hat *mehrere* ``gewünschte Zustände``.
Verwende hier die gleichen Exceptions wie unten im Code.

```csharp
public class User
{
    public bool IsActive { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public DateTime SubscriptionEnd { get; set; }

    public void ProcessUser()
    {
        if (IsActive)
        {
            if (Age > 18)
            {
                if (Age < 65)
                {
                    if (!string.IsNullOrEmpty(Email))
                    {
                        if (SubscriptionEnd > DateTime.Now)
                        {
                            Console.WriteLine("✅User is active, adult, has a valid email, and an active subscription.");
                        }
                        else
                        {
                            Console.WriteLine("❌User's subscription has expired.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("❌User email is missing.");
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(Email))
                    {
                        if (SubscriptionEnd > DateTime.Now)
                        {
                            Console.WriteLine("✅User is active, a senior, has a valid email, and an active subscription.");
                        }
                        else
                        {
                            Console.WriteLine("❌Senior user's subscription has expired.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("❌Senior user email is missing.");
                    }
                }
            }
            else
            {
                Console.WriteLine("❌User must be older than 18.");
            }
        }
        else
        {
            Console.WriteLine("❌User is not active.");
        }
    }

    public static void ProcessUserGuardClause() {
        //TODO: Hier deine Guard Clause Logik einfügen.
        Console.WriteLine("TODO: Guard Clause Implementierung der Methode: ProcessUser");
    }
}

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        User user1 = new User
        {
            IsActive = true,
            Age = 30,
            Email = "example@domain.com",
            SubscriptionEnd = DateTime.Now.AddMonths(1)
        };

        user1.ProcessUser();
        user1.ProcessUserGuardClause();
    }
}
```

### Aufgabe 3 - level: 😵‍💫 - Mehrere komplexere gewünschte Zustände
```csharp
using System.Text;

public class Berg
{
    public bool IstGefährlich { get; set; }
    public int höhe { get; set; }
}


public class Bergführer
{
    // Eigenschaften / Felder
    public bool IsActive { get; set; }
    public int Age { get; set; }
    public string MedicalClearanceCertificate { get; set; }
    public DateTime CertificationExpiry { get; set; }
    public int TourCount { get; set; }

    // Hat-Beziehungen
    public Berg BergRoute { get; set; }

    public void ValidateGuide()
    {
        if (IsActive)
        {
            if (Age >= 21)
            {
                if (!string.IsNullOrEmpty(MedicalClearanceCertificate))
                {
                    if (CertificationExpiry > DateTime.Now)
                    {
                        if (BergRoute.IstGefährlich)
                        {
                            if (TourCount >= 50 && TourCount <= 200)
                            {
                                Console.WriteLine("✅ Bergführer hat zwischen 50 und 200 Touren. Ein weiterer erfahrener Guide ist erforderlich, um diese Route zu bewältigen.");
                            }
                            else if (TourCount > 200)
                            {
                                Console.WriteLine("✅ Bergführer hat mehr als 200 Touren. Dieser Guide darf die Route alleine führen.");
                            }
                            else
                            {
                                Console.WriteLine("❌ Bergführer hat zu wenig Erfahrung für diese Route.");
                            }
                        }
                        else
                        {
                            if (BergRoute.höhe > 5000) 
                            {
                                Console.WriteLine("✅ Berg ist zu hoch. Ein weiterer erfahrener Guide ist erforderlich, um diese Route zu bewältigen.");
                            } 
                            else 
                            {
                                Console.WriteLine("✅ Bergführer darf die Tour durchführen.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("❌ Die Zertifizierung des Bergführers ist abgelaufen.");
                    }
                }
                else
                {
                    Console.WriteLine("❌ Bergführer besitzt kein medizinisches Freigabezertifikat.");
                }
            }
            else
            {
                Console.WriteLine("❌ Bergführer muss älter als 21 Jahre sein.");
            }
        }
        else
        {
            Console.WriteLine("❌ Bergführer ist nicht aktiv.");
        }
    }

    public void ValidateGuideGuardClause()
    {
        // TODO: Schreibe hier das in ValidateGuide verschachtelte IF in eine Guard Clause um.
        throw new NotImplementedException("This method is not yet implemented: Schreibe hier das in ValidateGuide verschachtelte IF in eine Guard Clause um.");
    }
}


public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Bergführer guide = new Bergführer
        {
            IsActive = true,
            Age = 35,
            MedicalClearanceCertificate = "ValidCertificate",
            CertificationExpiry = DateTime.Now.AddMonths(12),
            TourCount = 150,
            BergRoute = new Berg { IstGefährlich = true, höhe = 4000 }
        };

        guide.ValidateGuide();
        guide.ValidateGuideGuardClause();
    }
}
```