namespace Task4BinSearch
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class BinSearch
    {
       public static void Main(string[] args)
        {
            int[] givenArr = { 3, 4, 66, 23, 14, 43, 8, 9, 5, 67, 45, 68, 1, 2, 5, 10 };
            Array.Sort(givenArr);
            int number = int.Parse(Console.ReadLine());

            int myIndex = Array.BinarySearch(givenArr, number);

            if (myIndex < 0)
            {
                while (myIndex < 0)
                {
                    number--;
                    myIndex = FindTheIndex(givenArr, number);
                }
            }
            
            Console.WriteLine("Result: {0}", givenArr[myIndex]);
        }

       private static int FindTheIndex(int[] givenArr, int number)
       {
           int myIndex = Array.BinarySearch(givenArr, number);
           return myIndex;
       }
    }
}
