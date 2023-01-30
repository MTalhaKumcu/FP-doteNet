using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectVol2
{
    class main
    { 
        static void Main(string[] args)
        {
            ContactList contacts = new ContactList();
            contacts.Start();
            Boolean quit = false;
            while (quit != true)
            {
                Console.WriteLine("1. Add person");
                Console.WriteLine("2. Update person");
                Console.WriteLine("3. Remove person");
                Console.WriteLine("4. Print person");
                Console.WriteLine("5. Person");
                Console.WriteLine("6. Print who has birthday this week:");
                Console.WriteLine("7. Save and exit");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        contacts.Add();
                        break;
                    case 2:
                        contacts.Update();
                        break;
                    case 3:
                        Console.Write("Enter name: ");
                        string name = Console.ReadLine();
                        contacts.Remove(name);
                        break;
                    case 4:
                        Console.Write("Enter name: ");
                        name = Console.ReadLine();
                        contacts.Print(name);
                        break;
                    case 5:
                        contacts.PrintAll();
                        break;
                    case 6:
                        contacts.PrintThisWeekBirthday();
                        break;
                    case 7:
                        contacts.Save();
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

    }
}
