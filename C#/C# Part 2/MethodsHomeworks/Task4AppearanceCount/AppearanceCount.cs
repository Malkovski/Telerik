namespace Task4AppearanceCount
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class AppearanceCount
    {
       public static void Main(string[] args)
        {
            int[] givenArr = { 3, 5, 2, 5, 6, 4, 1, 4, 7, 8, 9, 6, 5, 4, 3, 2, 3, 4, 5 };
            int number = int.Parse(Console.ReadLine());

            int count = SameElement(givenArr, number);

            Console.WriteLine("The searched number is foung {0} times", count);
        }

       private static int SameElement(int[] givenArr, int number)
       {
           int count = 0;
           for (int i = 0; i < givenArr.Length; i++)
           {
               if (givenArr[i] == number)
               {
                   count++;
               }
           }

           return count;
       }
    }
}
