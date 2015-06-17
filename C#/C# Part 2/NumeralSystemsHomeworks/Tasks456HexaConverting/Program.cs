namespace Tasks456HexaConverting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class Program
    {
       public static void Main(string[] args)
        {
            Console.WriteLine("Enter hexadecimal number");
            string hexa = Console.ReadLine();
            Console.WriteLine("Enter binary number");
            string binar = Console.ReadLine();

            long decNum = Convert.ToInt64(hexa, 16);
            Console.WriteLine("Decimal: {0}", decNum);

           StringBuilder sb = new StringBuilder();
            foreach( char c in hexa.ToCharArray())
            {
              sb.Append( Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2));
            }

            Console.WriteLine("Binary: {0}", sb);
            string result = String.Format("{0:X2}",  Convert.ToInt64(binar, 2));
            Console.WriteLine("Hex from binary is: {0}", result);
        }
    }
}
