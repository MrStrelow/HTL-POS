using System.Text;

public class User
{
    public bool IsActive { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public DateTime SubscriptionEnd { get; set; }

    public void ProcessUserNestedIf()
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

        //        if (Age < 65)
        //        {
        //            if (!string.IsNullOrEmpty(Email))
        //            {
        //                if (SubscriptionEnd > DateTime.Now)
        //                {
        //                    Console.WriteLine("✅User is active, adult, has a valid email, and an active subscription.");
        //                }
        //                else
        //                {
        //                    Console.WriteLine("❌User's subscription has expired.");
        //                }
        //            }
        //            else
        //            {
        //                Console.WriteLine("❌User email is missing.");
        //            }
        //        }
        //        else
        //        {
        //            if (!string.IsNullOrEmpty(Email))
        //            {
        //                if (SubscriptionEnd > DateTime.Now)
        //                {
        //                    Console.WriteLine("✅User is active, a senior, has a valid email, and an active subscription.");
        //                }
        //                else
        //                {
        //                    Console.WriteLine("❌Senior user's subscription has expired.");
        //                }
        //            }
        //            else
        //            {
        //                Console.WriteLine("❌Senior user email is missing.");
        //            }
        //        }
        //    }
        //}
    }

    public void ProcessUserGuardClause()
    {
        // ❌ Ungewünschte Zustände 
        if (!IsActive)
        {
            Console.WriteLine("❌User is not active.");
            return;
        }

        if (!(Age > 18))
        {
            Console.WriteLine("❌User must be older than 18.");
            return;
        }

        if (!(Age < 65) && string.IsNullOrEmpty(Email))
        {
            Console.WriteLine("❌Senior user email is missing.");
            return;
        }

        if (!(Age < 65) && !string.IsNullOrEmpty(Email) && !(SubscriptionEnd > DateTime.Now))
        {
            Console.WriteLine("❌Senior user's subscription has expired.");
            return;
        }

        if (Age < 65 && string.IsNullOrEmpty(Email))
        {
            Console.WriteLine("❌Senior user email is missing.");
            return;
        }

        if (Age < 65 && !string.IsNullOrEmpty(Email) && !(SubscriptionEnd > DateTime.Now))
        {
            Console.WriteLine("❌User's subscription has expired.");
            return;
        }

        // ✅ Gewünschte Zustände
        if (Age < 65)
        {
            Console.WriteLine("✅User is active, adult, has a valid email, and an active subscription.");
        }
        else
        {
            Console.WriteLine("✅User is active, a senior, has a valid email, and an active subscription.");
        }
    }

    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        User user = new User
        {
            IsActive = true,
            Age = 30,
            Email = "example@domain.com",
            SubscriptionEnd = DateTime.Now.AddMonths(1)
        };

        try
        {
            Console.WriteLine("\n############### 2 ###############");
            Console.WriteLine("--- Testing original nested-if method ---");
            user.ProcessUserNestedIf();
            Console.WriteLine("\n--- Testing new Guard Clause method Variante 1---");
            user.ProcessUserGuardClause();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}