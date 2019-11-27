using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_4
{
    [Serializable]
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalIdentifier { get; set; }
        
        public Person()
        {
            Console.Write("\nPlease, enter the first name: ");
            FirstName = Console.ReadLine();
            Console.Write("\nPlease, enter the last name: ");
            LastName = Console.ReadLine();
            Console.Write("\nPlease, enter the personal ID: ");
            PersonalIdentifier = Console.ReadLine();
        }
    }
}
