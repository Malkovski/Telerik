namespace Task6FirstLarger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class FirstLarger
    {
       public static void Main(string[] args)
        {
            int[] givenArr = { 3, 5, 2, 5, 6, 4, 1, 4, 7, 8, 9, 6, 5, 4, 3, 2, 3, 4, 5 };
            
            int myIndex = FirstLargerNeighbour(givenArr);

            Console.WriteLine(myIndex);
        }

       private static int FirstLargerNeighbour(int[] givenArr)
       {
           int myIndex = -1;

           for (int pos = 0; pos < givenArr.Length; pos++)
           {
               if (pos > 0 && pos < givenArr.Length - 1)
               {
                   if (givenArr[pos] > givenArr[pos + 1] && givenArr[pos] > givenArr[pos - 1])
                   {
                       myIndex = pos;
                       break;
                   }
               }
               else if (pos == 0)
               {
                   if (givenArr[pos] > givenArr[pos + 1])
                   {
                       myIndex = pos;
                       break;
                   }
               }
               else
               {
                   if (givenArr[pos] > givenArr[pos - 1])
                   {
                       myIndex = pos;
                       break;
                   }
               }
           }

           return myIndex;
       }
    }
}
