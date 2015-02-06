using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SaddyKopper
{
    class SaddyKopper
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int counter = number.Length - 1;
            BigInteger result = 0;
            BigInteger newResult = 1;         
            int transforms = 0;


            if (transforms < 10)
            {
                while (counter > 0)
                {
                    number = number.Substring(0, number.Length - 1);

                    for (int i = 0; i < number.Length; i++)
                    {
                        if (i % 2 == 0)
                        {
                            result += int.Parse(number[i].ToString());
                        }
                    }

                    
                    result = result * newResult;
                    newResult = result;
                    result = 0;
                    counter--;


                    if (counter == 0)
                    {
                        transforms++;

                        if (transforms == 10)
                        {
                            Console.WriteLine(newResult);
                            break;
                        }

                        number = newResult.ToString();
                        newResult = 1;

                        if (number.Length == 1)
                        {
                            Console.WriteLine(transforms);
                            Console.WriteLine(number);
                            break;
                        }
                        else
                        {
                            counter = number.Length - 1;
                            continue;
                        }
                    }
                }
            }
        }
    }
}
