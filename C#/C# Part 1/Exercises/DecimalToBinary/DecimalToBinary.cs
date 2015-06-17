

namespace DecimalToBinary
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

    class DecimalToBinary
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int num = n;
            int newnum = num;
            int divider = 2;

            Console.Write(num % divider);
            while (newnum != 1)
            {
                newnum = num / divider;
                num = newnum;
                int[] array = { newnum % divider };
                int length = array.Length;
                int[] reversed = new int[length];
                for (int index = 0; index < length; index++)
                {
                    reversed[length - index - 1] = array[index];
                }
                for (int index = 0; index < length; index++)
                {
                    Console.Write(array[index]);
                }
                //Console.Write(newnum % divider);



            }
        }
    }
}
