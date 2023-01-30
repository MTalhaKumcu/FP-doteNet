using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectVol2
{
    class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Telephone { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Person(string name, string surname, string telephone, string dateofbirth) {
            Name = name;
            Surname = surname;
            Telephone = telephone;
            DateTime birth = Convert.ToDateTime(dateofbirth);
            DateOfBirth = birth;
        }

    }
}
