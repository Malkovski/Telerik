

namespace ElementsInLine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class ElementsInLine
    {
        static void Main(string[] args)
        {
            int len = 1;
            int maxLen = 1;           
            int[] arrayOne = new int[10];

            for (int i =0; i <10; i++)
            {
                arrayOne[i] = int.Parse(Console.ReadLine());
            }
            int number = arrayOne[0];
                for (int i =1; i <10; i++)
                {
                    if (arrayOne[i] != arrayOne[i-1])
                    {
                       
                        if (maxLen < len)
                        {
                            number = arrayOne[i - 1];
                            maxLen = len;
                           
                        }
                        len = 1;
                       
                    }
                    else
                    {
                        len++;
                    }
                }
            if (maxLen < len)
            {
                maxLen = len;
                number = arrayOne[arrayOne.Length - 1];
                len = 1;
            }
            Console.Write("Longest is {0} times {1} =>:", maxLen, number);
            for (int i = 0; i < maxLen; i++)
            {
                Console.Write(number);
            }
               
        }
    }
}
