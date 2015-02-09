namespace Task5LargerThanNeighbours
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class LargerThanNeighbours
    {
      public static void Main(string[] args)
        {
            int[] givenArr = { 3, 5, 2, 5, 6, 4, 1, 4, 7, 8, 9, 6, 5, 4, 3, 2, 3, 4, 5 };
            int pos = int.Parse(Console.ReadLine());

            bool isLarger = SmallerNeighbours(givenArr, pos);

            Console.WriteLine(isLarger);
        }

      private static bool SmallerNeighbours(int[] givenArr, int pos)
      {
          bool isLarger = false;

          if (pos > 0 && pos < givenArr.Length - 1)
          {
              if (givenArr[pos] > givenArr[pos + 1] && givenArr[pos] > givenArr[pos - 1])
              {
                  isLarger = true;
              }
          }
          else if (pos == 0)
          {
              if (givenArr[pos] > givenArr[pos + 1])
              {
                  isLarger = true;
              }
          }
          else
          {
              if (givenArr[pos] > givenArr[pos - 1])
              {
                  isLarger = true;
              }
          }
          
          return isLarger;
      }    
    }
}
