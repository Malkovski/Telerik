namespace BullsAndCows
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class BullsAndCows
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            int bull = int.Parse(Console.ReadLine());
            int cow = int.Parse(Console.ReadLine());
            string[] parts = {"1", "2", "3", "4", "5", "6", "7", "8", "9"};
            string result = null;

            for (int i = 0; i < num.Length; i++)
            {
                for (int j = 0; j < parts.Length; j++)
                {
                    while (bull != 0)
                    {
                        if (parts[j] == num[i])
                        {
                            result[i] = Convert.ToChar(parts[j]);
                        }
                        bull--;
                    }

                }
            }
        }
    }
}
