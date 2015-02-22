namespace StrangeLandNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;

   public class StrangeLandNumbers
    {
       public static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string num = string.Empty;

            for (int i = text.Length - 1; i >= 0; )
            {
                if (text[i] == 'f')
                {
                    num = 0 + num;
                    i = i - 1;
                }
                else if (text[i] == 'N')
                {
                    num = 1 + num;
                    i = i - 3;
                }
                else if (text[i] == 'C')
                {
                    num = 2 + num;
                    i = i - 5;
                }
                else if (text[i] == 'L')
                {
                    num = 3 + num;
                    i = i - 7;
                }
                else if (text[i] == 'Q')
                {
                    num = 4 + num;
                    i = i - 6;
                }
                else if (text[i] == 'E')
                {
                    num = 5 + num;
                    i = i - 4;
                }
                else
                {
                    num = 6 + num;
                    i = i - 2;
                }
            }

            decimal result = 0;
            int pow = 0;
            for (int j = num.Length - 1; j >= 0; j--)
            {
                result += decimal.Parse(num[j].ToString()) * (decimal)(Math.Pow(7, pow));
                pow++;
            }

            Console.WriteLine(result);
        }
    }
}
