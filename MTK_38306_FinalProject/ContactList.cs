using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace FinalProjectVol2
{
    class ContactList
    {
        private List<Person> personList = new List<Person>();

        // Gathering previously added contacts from contacts.txt file
        public void Start()
        {
            string[] lines = File.ReadAllLines("contacts.txt");
            foreach (string line in lines)
            {
                string[] personInfo = line.Split(',');
                string name = personInfo[0];
                string surname = personInfo[1];
                string telephone = personInfo[2];
                string birthday = personInfo[3];
                personList.Add(new Person(name, surname, telephone, birthday));
            }
        }
        // Adding new contact to personList
        public void Add()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter surname: ");
            string surname = Console.ReadLine();
            Console.Write("Enter telephone: ");
            string telephone = Console.ReadLine();
            Console.Write("Enter the date of birth: ");
            string dateofbirth = Console.ReadLine();
            personList.Add(new Person(name, surname, telephone, dateofbirth));
        }

        // Editing contact info 
        public void Update()
        {
            Console.Write("Write the name of the person you'd like to edit: ");
            string name = Console.ReadLine();
            var person = personList.Find(x => x.Name == name);
            if (person != null) {
                Console.Write("Enter new name: ");
                person.Name = Console.ReadLine();
                Console.Write("Enter new surname: ");
                person.Surname = Console.ReadLine();
                Console.Write("Enter new telephone: ");
                person.Telephone = Console.ReadLine();
                Console.Write("Enter new date of birth: ");
                string birth = Console.ReadLine();
                person.DateOfBirth = Convert.ToDateTime(birth);
                Console.WriteLine($"Person {name} is updated to: ");
                Print(person.Name);
            }
        }

        // Removing contact on request by calling it with contact name
        public void Remove(string name)
        {
            personList.RemoveAll(x => x.Name == name);
        }

        // Saving personList to contacts.txt file
        public void Save()
        {
            using (StreamWriter writer = new StreamWriter("contacts.txt"))
            {
                foreach (var person in personList) {
                    writer.WriteLine($"{person.Name},{person.Surname},{person.Telephone},{person.DateOfBirth}");
                }
            }
        }

        //Displaying contact info by calling it with the name of the person
        public void Print(string name)
        {
            var person = personList.Find(x => x.Name == name);
            if (person != null)
                Console.WriteLine($"Name: {person.Name}, Surname: {person.Surname}, Telephone: {person.Telephone}, Date of Birth: {person.DateOfBirth}");
            else
                Console.WriteLine("Person not found");
        }
        public void PrintAll()
        {
            foreach (var person in personList)
            {
                Console.WriteLine($"Name: {person.Name}, Surname: {person.Surname}, Telephone: {person.Telephone}, DateOfBirth: {person.DateOfBirth}");
            }
        }

        //Displaying the information of contacts who has born this week
        public void PrintThisWeekBirthday()
        {
            DateTime dt = DateTime.Now;
            int month = dt.Month;
            DayOfWeek day = dt.DayOfWeek;
            int days = day - DayOfWeek.Monday;
            int startDay = DateTime.Now.AddDays(-days).Day;
            int endDay = startDay + 6; 
            var peopleThisWeek = personList.Where(x => x.DateOfBirth.Day >= startDay && x.DateOfBirth.Day <= endDay && x.DateOfBirth.Month == month);
            if (peopleThisWeek.Any())
            {
                Console.WriteLine($"People with birthday this week: ({startDay}.{month} - {endDay}.{month})");
                foreach (var person in peopleThisWeek)
                {
                    Console.WriteLine($"Name: {person.Name}, Surname: {person.Surname}, Telephone: {person.Telephone}, Birthday: {person.DateOfBirth.ToShortDateString()}");
                }
            }
            else
            {
                Console.WriteLine("No people with birthday this week.");
            }
        }
    }
}
