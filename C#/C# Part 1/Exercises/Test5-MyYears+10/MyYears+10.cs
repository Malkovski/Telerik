using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test5_MyYears_10
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10;
            Console.WriteLine("Enter your age here! :");  
            int my = int.Parse(Console.ReadLine());           
            Console.WriteLine(" My age will be " + (n+my));

        }
    }
}
