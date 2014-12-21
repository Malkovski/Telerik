

namespace BinaryDigitsCount
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class BinaryDigitsCount
    {
        static void Main(string[] args)
        {
            int b = int.Parse(Console.ReadLine());
            int lines = int.Parse(Console.ReadLine());

            int[] counts = new int[lines];

            for (int i = 0; i < lines; i++)
            {
                long number = long.Parse(Console.ReadLine());
                string binary = Convert.ToString(number, 2);
                if (b == 1)
                {
                    string ones = binary.Replace("0","");
                    counts[i] = ones.Length;                   
                }
                else
                {
                    string zeros = binary.Replace("1", "");
                    counts[i] = zeros.Length;                  
                }
                
            }
            for (int j = 0; j < counts.Length; j++)
            {
                Console.WriteLine(counts[j]);
            }
           
        }
    }
}
