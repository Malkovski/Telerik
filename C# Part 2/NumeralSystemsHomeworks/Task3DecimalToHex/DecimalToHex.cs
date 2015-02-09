namespace Task3DecimalToHex
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class DecimalToHex
    {
       public static void Main(string[] args)
       {
           int num = int.Parse(Console.ReadLine());
           string result = Convert.ToString(num, 16);

           Console.WriteLine("Hexa is {0}", result);

           var sb = new StringBuilder();
           while (num > 0)
           {
               var r = num % 16;
               num /= 16;
               sb.Insert(0, ((int)r).ToString("X"));
           }

           Console.WriteLine("Hexa is {0}", result);
       }
    }
}
