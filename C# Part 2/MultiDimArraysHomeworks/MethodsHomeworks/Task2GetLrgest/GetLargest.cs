namespace Task2GetLrgest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class GetLargest
    {
      public static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            int biggest = GetMax(first, second);
            biggest = GetMax(biggest, third);

            Console.WriteLine(biggest);
        }

      private static int GetMax(int first, int second)
      {
          int biggest = 0;
          if (first > second)
          {
              biggest = first;
          }
          else
          {
              biggest = second;
          }

          return biggest;
      }
    }
}
