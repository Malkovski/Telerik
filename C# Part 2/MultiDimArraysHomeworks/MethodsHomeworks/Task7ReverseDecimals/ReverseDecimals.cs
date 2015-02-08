namespace Task7ReverseDecimals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class ReverseDecimals
    {
       public static void Main(string[] args)
        {
            decimal number = decimal.Parse(Console.ReadLine());

            string reversed = ReversingDecimals(number);

            Console.WriteLine(reversed);
        }

       private static string ReversingDecimals(decimal number)
       {
           string numberStr = number.ToString();
           string reversed = string.Empty;

           for (int i = numberStr.Length - 1; i >= 0; i--)
           {
               reversed = reversed + numberStr[i];
           }

           return reversed;
       }
    }
}
