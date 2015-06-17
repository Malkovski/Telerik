namespace Task1DecimalToBinary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class DecimalToBinary
    {
       public static void Main(string[] args)
        {
            decimal num = int.Parse(Console.ReadLine());
            int remainder = 0;
            string result = string.Empty;

            while ((int)num > 0)
            {
                remainder = (int)num % 2;
                num /= 2;
                result = remainder.ToString() + result;
            }

            Console.WriteLine("Binary: {0}", result);
        }
    }
}
