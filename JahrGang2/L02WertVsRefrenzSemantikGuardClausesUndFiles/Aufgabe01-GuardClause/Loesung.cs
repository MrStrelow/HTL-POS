using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Aufgabe1 {
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

        public void ProcessUserGuardClause()
        {
            if (Name == "Mathias")
            {
                Console.WriteLine("❌User is Mathias.");
                return;
            }

            if (!IsRegistered)
            {
                Console.WriteLine("❌User is not registered.");
                return;
            }

            if (Age < 18)
            {
                Console.WriteLine("❌User is too young.");
                return;
            }

            Console.WriteLine("✅User is processed.");
        }

        public void ProcessUserNestedIf()
        {
            if (Name != "Mathias")
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
    }

    public class Program
    {

        public static void CallUe1()
        {
            User hans = new User("Hans", 35, false);
            User alice = new User("Alice", 25, true);

            Console.WriteLine("\n############### 1 ###############");
            Console.WriteLine("--- Testing original nested-if method ---");
            hans.ProcessUserGuardClause();
            Console.WriteLine("\n--- Testing new Guard Clause method Variante 1---");
            hans.ProcessUserNestedIf();

            Console.WriteLine("--- Testing original nested-if method ---");
            alice.ProcessUserGuardClause();
            Console.WriteLine("\n--- Testing new Guard Clause method Variante 1---");
            alice.ProcessUserNestedIf();
        }
    }
}

namespace Aufgabe2
{
    public class User
    {
        public bool IsActive { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public DateTime SubscriptionEnd { get; set; }

        // Achtung! Wir haben hier 2 Endpunkte ("User is active,..." und "User is active, a senior,...")
        // welche wir als sinnvoll erachten. 
        // Versuche zerst die 2 Zweige des Programmes mit Endpunkten getrennt zu behandeln und verbinde diese nachher.

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
        }

        public void ProcessUserGuardClause()
        {
            // ❌Ungewünschte Zustände 
            // Guard Clauses für allgemeine Prüfungen
            if (!IsActive)
            {
                Console.WriteLine("❌User is not active.");
                return;
            }

            if (Age <= 18)
            {
                Console.WriteLine("❌User must be older than 18.");
                return;
            }

            // Weitere Bedingungen je nach Altersgruppe: User
            if (Age < 65 && string.IsNullOrEmpty(Email))
            { 
                Console.WriteLine("❌User email is missing.");
                return;
            }

            if (Age >= 65 && string.IsNullOrEmpty(Email))
            {
                Console.WriteLine("❌Senior user email is missing.");
                return;
            }
             
            // Weitere Bedingungen je nach Altersgruppe: Senior
            if (Age < 65 && SubscriptionEnd <= DateTime.Now)
            {
                Console.WriteLine("❌User's subscription has expired.");
                return;
            }

            if (Age >= 65 && SubscriptionEnd <= DateTime.Now)
            {
                Console.WriteLine("❌Senior user's subscription has expired.");
                return;
            }
            
            // ✅ gewünschte Zustände
            // Beide Endpunkte müssen wir in einer IF-Verzweigung trennen. Auch ein switch möglich.
            // Wir werden später Konzepte (ein paar Monate) anschauen welche uns erlauben solche Abfragen potentiell noch
            // eleganter zu gestalten (Pattern matching mit switch und when).
            if (Age < 65)
            {
                Console.WriteLine("✅User is active, adult, has a valid email, and an active subscription.");
            }
            else
            {
                Console.WriteLine("✅User is active, a senior, has a valid email, and an active subscription.");
            }
        }

        public static void CallUe2()
        {
            User user = new User
            {
                IsActive = true,
                Age = 30,
                Email = "example@domain.com",
                SubscriptionEnd = DateTime.Now.AddMonths(1)
            };

            Console.WriteLine("\n############### 2 ###############");
            Console.WriteLine("--- Testing original nested-if method ---");
            user.ProcessUserNestedIf();
            Console.WriteLine("\n--- Testing new Guard Clause method Variante 1---");
            user.ProcessUserGuardClause();
        }
    }
}

namespace Aufgabe3
{
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
            // ❌Ungewünschte Zustände
            if (!IsActive)
            {
                Console.WriteLine("❌ Bergführer ist nicht aktiv.");
                return;
            }

            if (Age < 21)
            {
                Console.WriteLine("❌ Bergführer muss älter als 21 Jahre sein.");
                return;
            }


            if (string.IsNullOrEmpty(MedicalClearanceCertificate))
            {
                Console.WriteLine("❌ Bergführer besitzt kein medizinisches Freigabezertifikat.");
                return;
            }


            if (CertificationExpiry <= DateTime.Now)
            {
                Console.WriteLine("❌ Die Zertifizierung des Bergführers ist abgelaufen.");
                return;
            }


            if (BergRoute.IstGefährlich && TourCount < 50)
            {
                Console.WriteLine("❌ Bergführer hat zu wenig Erfahrung für diese Route.");
                return;
            }


            if (BergRoute.IstGefährlich && TourCount < 50)
            {
                Console.WriteLine("❌ Bergführer hat zu wenig Erfahrung für diese Route.");
                return;
            }

                
            // ✅Gewünschte Zustände
            if (BergRoute.IstGefährlich)
            {
                if (TourCount > 200)
                {
                    Console.WriteLine("✅ Bergführer hat mehr als 200 Touren. Dieser Guide darf die Route alleine führen.");
                }
                else // Covers TourCount between 50 and 200
                {
                    Console.WriteLine("✅ Bergführer hat zwischen 50 und 200 Touren. Ein weiterer erfahrener Guide ist erforderlich, um diese Route zu bewältigen.");
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
        
        public static void CallUe3()
        {
            Bergführer guide = new Bergführer
            {
                IsActive = true,
                Age = 35,
                MedicalClearanceCertificate = "ValidCertificate",
                CertificationExpiry = DateTime.Now.AddMonths(12),
                TourCount = 150,
                BergRoute = new Berg { IstGefährlich = true, höhe = 4000 }
            };

            try
            {
                Console.WriteLine("\n############### 3 ###############");
                Console.WriteLine("--- Testing original nested-if method ---");
                guide.ValidateGuide();
                
                Console.WriteLine("\n--- Testing new Guard Clause method ---");
                guide.ValidateGuideGuardClause();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Fehler: {ex.Message}");
            }
        }
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        Aufgabe1.Program.CallUe1();
        Aufgabe2.User.CallUe2();
        Aufgabe3.Bergführer.CallUe3();
    }
}