namespace Task5SortByStrLength
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class SortByStrLentgh
    {
       public static void Main(string[] args)
        {
            string[] givenArr = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            int[] itemLen = new int[givenArr.Length];
            string[] sorted = new string[givenArr.Length];

            for (int i = 0; i < givenArr.Length; i++)
            {
                itemLen[i] = givenArr[i].Length;
            }

            int size = 1;
            int cnt = 0;
            int elements = sorted.Length;

            while (elements > 0)
            {
                int myIndex = FindTheIndex(itemLen, size);

                if (myIndex >= 0)
                {
                    sorted[cnt] = givenArr[myIndex];
                    itemLen[myIndex] = Int32.MaxValue;
                    cnt++;
                    elements--;
                }
                else
                {
                    size++;
                }
            }

            foreach (var item in sorted)
            {
                Console.Write(item);
                Console.Write(" ");
            }

            Console.WriteLine();
        }

       private static int FindTheIndex(int[] itemLen, int size)
       {
           int myIndex = -1;

           for (int i = 0; i < itemLen.Length; i++)
           {
               if (itemLen[i] == size)
               {
                   myIndex = i;
               }           
           }

           return myIndex;
       }
    }
}
