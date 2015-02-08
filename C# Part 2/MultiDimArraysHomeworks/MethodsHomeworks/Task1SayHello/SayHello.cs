namespace Task1SayHello
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class SayHello
    {
       public static void Main(string[] args)
        {
            Console.WriteLine("What is your name?");
            string myName = Console.ReadLine();

            string answer = Greeting(myName);
            Console.WriteLine(answer);
        }

       private static string Greeting(string myName)
       {
           string answer = "Hello, " + myName + "!";

           return answer;
       }
    }
}
