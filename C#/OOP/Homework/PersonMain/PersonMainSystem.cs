namespace PersonMain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PersonMainSystem
    {
        public static void Main()
        {
            Person firstPerson = new Person("Stefko");
            Person secondPerson = new Person("Venci", 31);
            Console.WriteLine(firstPerson);
            firstPerson.Age = 33;
            Console.WriteLine(firstPerson);
            Console.WriteLine(secondPerson);
        }
    }
}
