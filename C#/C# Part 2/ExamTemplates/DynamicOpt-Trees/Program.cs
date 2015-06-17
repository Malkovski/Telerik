namespace DynamicOpt_Trees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class Program
    {
       public static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());         
            int start = -1;
            int[] num = new int[] { a, b, c, d, start };
            int count = 0;
            int[] numList = new int[a + b + c + d];
            List<int> list = new List<int>();

                for (int i = 0; i < num.Length; i++)
                {
                    for (int j = 0; j < num[i]; j++)
                    {
                        list.Add(i);
                    }
                }
                numList = list.ToArray();
                Array.Sort(numList);

            do
	        {
                if (IsValid(numList))
                {
                    ++count;
                }
	        } 
            while (NextPermutation(numList));
 
            Console.WriteLine(count);
        }

       static bool IsValid(int[] numList)
       {
           for (int i = 1; i < numList.Length; i++)
           {
               if (numList[i - 1] == numList[i])
               {
                   return false;
               }
           }

           return true;
       }

       /// Thanks by: http://stackoverflow.com/questions/11208446/generating-permutations-of-a-set-most-efficiently ////
       
       private static bool NextPermutation(int[] numList)
       {
           /*
            Knuths
            1. Find the largest index j such that a[j] < a[j + 1]. If no such index exists, the permutation is the last permutation.
            2. Find the largest index l such that a[j] < a[l]. Since j + 1 is such an index, l is well defined and satisfies j < l.
            3. Swap a[j] with a[l].
            4. Reverse the sequence from a[j + 1] up to and including the final element a[n].

            */
           var largestIndex = -1;
           for (var i = numList.Length - 2; i >= 0; i--)
           {
               if (numList[i] < numList[i + 1])
               {
                   largestIndex = i;
                   break;
               }
           }

           if (largestIndex < 0) return false;

           var largestIndex2 = -1;
           for (var i = numList.Length - 1; i >= 0; i--)
           {
               if (numList[largestIndex] < numList[i])
               {
                   largestIndex2 = i;
                   break;
               }
           }

           var tmp = numList[largestIndex];
           numList[largestIndex] = numList[largestIndex2];
           numList[largestIndex2] = tmp;

           for (int i = largestIndex + 1, j = numList.Length - 1; i < j; i++, j--)
           {
               tmp = numList[i];
               numList[i] = numList[j];
               numList[j] = tmp;
           }

           return true;
       }
    }
}
