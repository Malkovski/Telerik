

namespace OddNumber
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class OddNumber
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[] number = new long[n];
            for (int i = 0; i < number.Length; i++)
            {
                number[i] = long.Parse(Console.ReadLine());
            }
            Array.Sort(number);
            int counter = 1;
            if (n == 1)
            {
                Console.WriteLine(number[0]);
            }
            else
            {
                for (int j = 1; j < number.Length; j++)
                {
                    if (j == number.Length - 1)
                    {
                        Console.WriteLine(number[number.Length - 1]);
                    }
                    else
                    {
                            if (number[j] == number[j - 1])
                            {
                                counter++;
                            }
                            else
                            {
                                if (counter % 2 != 0)
                                {
                                    Console.WriteLine(number[j - 1]);
                                    break;
                                }
                                else
                                {
                                    counter = 1;
                                }
                            }
                    }
                }
            }
        }
    }
}
