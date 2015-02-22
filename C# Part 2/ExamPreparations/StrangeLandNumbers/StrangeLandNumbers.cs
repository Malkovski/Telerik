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

            for (int i = text.Length - 1; i >= 0;)
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

            BigInteger result = 0;
            result = int.Parse(num[num.Length - 1].ToString()) * 1;

            if (num.Length > 2)
            {
                int pow = 1;
                for (int j = num.Length - 2; j >= 0; j--)
                {
                    BigInteger temp = 1;
                    for (int i = 0; i < pow; i++)
                    {
                        temp *= 7;
                    }

                    result += int.Parse(num[j].ToString()) * temp;
                    pow++;
                }
            } 

            Console.WriteLine(result);
        }
    }
}
