using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsToBits
{
    class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());
            string finalString = string.Empty;
            for (int i = 0; i < number; i++)
            {
                int val = int.Parse(Console.ReadLine());
                int remainder;
                string result = string.Empty;

                while (val > 0)
                {
                    remainder = val % 2;
                    val /= 2;
                    result = remainder.ToString() + result;
                }

                if (result.Length < 30)
                {
                    while (result.Length < 30)
	                {
                        result = "0" + result;
	                }                 
                }
                else
                {
                    string partStr = result.Substring((result.Length) - 30);
                    result = partStr;
                }

                finalString += result;
            }

            int counter = 0;
            int maxCounter = 0;

            for (int i = 0; i < finalString.Length; i++)
            {
                if (finalString[i] == '0')
                {
                    counter++;

                    if (counter > maxCounter)
                    {
                        maxCounter = counter;                      
                    }
                }
                else
                {
                    counter = 0;
                }
            }

            int cnt = 0;
            int maxCnt = 0;

            for (int i = 0; i < finalString.Length; i++)
            {
                if (finalString[i] == '1')
                {
                    cnt++;

                    if (cnt > maxCnt)
                    {
                        maxCnt = cnt;
                    }
                }
                else
                {
                    cnt = 0;
                }
            }

            Console.WriteLine(maxCounter);
            Console.WriteLine(maxCnt);
        }
    }
}
