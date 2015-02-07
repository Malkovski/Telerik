namespace Task13MergeSort
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
   public class MergeSort
    {
       public static void Main(string[] args)
        {
            int[] unsorted = new int[] { 1, 3, 2, 6, 4, 7, 10, 8, 9, 5 };
            Sorting(unsorted, 0, unsorted.Length - 1);

            foreach (var item in unsorted)
            {
                Console.Write(item);
            }
            Console.Read();

        }

       private static void Sorting(int[] unsorted, int leftIndex, int rightIndex)
       {
           if (leftIndex < rightIndex)
           {
               int middleIndex = (leftIndex + rightIndex) / 2;
               Sorting(unsorted, leftIndex, middleIndex);
               Sorting(unsorted, middleIndex + 1, rightIndex);
               Mergeing(unsorted, leftIndex, middleIndex, rightIndex);
           }
          
       }

       private static void Mergeing(int[] unsorted, int leftIndex, int middleIndex, int rightIndex)
       {
           int lenLeft = middleIndex - leftIndex + 1;
           int lenRight = rightIndex - middleIndex;
           int[] leftArr = new int[lenLeft + 1];
           int[] rightArr = new int[lenRight + 1];

           for (int i = 0; i < lenLeft; i++)
           {
               leftArr[i] = unsorted[leftIndex + i];
           }
           for (int j = 0; j < lenRight; j++)
           {
               rightArr[j] = unsorted[middleIndex + j + 1];
           }
           leftArr[lenLeft] = Int32.MaxValue;
           rightArr[lenRight] = Int32.MaxValue;
           int iIndex = 0;
           int jIndex = 0;

           for (int k = leftIndex; k <= rightIndex; k++)
           {
               if (leftArr[iIndex] <= rightArr[jIndex])
               {
                   unsorted[k] = leftArr[iIndex];
                   iIndex++;
               }
               else
               {
                   unsorted[k] = rightArr[jIndex];
                   jIndex++;
               }
           }
       }
    }
}
