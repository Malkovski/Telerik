

namespace MathExpression
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
   
   

    class Program
    {
        static void Main(string[] args)
        {
            
            double n = double.Parse(Console.ReadLine());
            double m = double.Parse(Console.ReadLine());
            double p = double.Parse(Console.ReadLine());
            

            int mod = (int)(m % 180);
           
            double top = (((n * n) + (1 / (m * p))) + 1337);
            double bot = (n - (128.523123123 * p));
            double left = (top / bot);
            double right = Math.Sin(mod);

            double result = left + right;

            string output = String.Format ("{0:F6}", result);

            Console.WriteLine(output);


        }
    }
}
