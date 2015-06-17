namespace GagNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;

   public class GagNumbers
    {
       public static void Main(string[] args)
        {
            string line = Console.ReadLine();
            string result = string.Empty;

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '!')
                {
                    if (line[i + 1] == '!' && line[i + 2] == '*' && line[i + 3] == '*' && line[i + 4] == '!' && line[i + 5] == '-')
                    {
                        result += 8;
                        i = i + 5;
                    }
                    else if (line[i + 1] == '!' && line[i + 2] == '!')
                    {
            
                        result += 2;
                        i = i + 2;            
                    }
                    else if (line[i + 1] == '-')
                    {
                        result += 5;
                        i = i + 1;
                    }
                }
                else if (line[i] == '&')
                {
                    if (line[i + 1] == '*' && line[i + 2] == '!')
                    {
                        result += 7;
                        i = i + 2;
                    }
                    else if (line[i + 1] == '&')
                    {
            
                        result += 3;
                        i = i + 1;            
                    }
                    else if (line[i + 1] == '-')
                    {
                        result += 4;
                        i = i + 1;
                    }
                }
                else if (line[i] == '*')
                {
                    if (line[i + 1] == '!' && line[i + 2] == '!' && line[i + 3] == '!')
                    {
                        result += 6;
                        i = i + 3;
                    }
                    else if (line[i + 1] == '*')
                    {
                        result += 1;
                        i = i + 1;
                    }
                }
                else if (line[i] == '-')
                {
                    if (line[i + 1] == '!')
                    {
                        result += 0;
                        i = i + 1;
                    }
                }               
            }

            BigInteger answer = 0;
            int pow = 0;

            for (int i = result.Length - 1; i >= 0; i--)
            {
                if (i < result.Length - 1)
                {
                    BigInteger temp = 1;
                    for (int j = 0; j < pow; j++)
                    {
                        temp *= 9;
                    }

                    answer += int.Parse(result[i].ToString()) * temp;
                    pow++;
                }
                else
                {
                    answer = int.Parse(result[result.Length - 1].ToString()) * 1;
                    pow++;
                }
            }

            Console.WriteLine(answer);
        }
    }
}
