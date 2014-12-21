namespace AstrologicalDigits
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;   

    public class AstrologicalDigits
    {
       public static void Main(string[] args)
        {
            string n = Console.ReadLine();

            string reN = n.Replace(".", "");
            string newN = reN.Replace("-", "");
            
            BigInteger digit = BigInteger.Parse(newN);

            BigInteger sum = 0;
            BigInteger final = 0;
            BigInteger astro = 0;

                for (int i = 0; digit > 9; i++)
                {
                    for (int j = 0; digit > 9; j++)
                    {
                        sum = digit % 10;
                        digit = (digit - sum) / 10;
                        final += sum;                   
                    }

                    digit = digit + final;
                    final = 0;
                }

            astro = digit;
            Console.WriteLine(digit);
        }
    }
}
