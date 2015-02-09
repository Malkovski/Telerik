namespace Task14IntegerCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;

   public class InategerCalculator
    {
       public static void Main(string[] args)
        {
            MinimalInt(1, 2, 3, 4, 5, 6, 7, 8, 9, 55);
            MaximalInt(1, 2, 3, 4, 5, 6, 7, 8, 9, 55);
            AverageInt(1, 2, 3, 4, 5, 6, 7, 8, 9, 55);
            SummOfInts(1, 2, 3, 4, 5, 6, 7, 8, 9, 55);
            ProductInt(1, 2, 3, 4, 5, 6, 7, 8, 9, 55);
        }

       private static void ProductInt(params int[] elements)
       {
           BigInteger product = 1;

           for (int i = 0; i < elements.Length; i++)
           {
               product = product * elements[i];
           }

           Console.WriteLine("The product is: {0}", product);
       }

       private static void MinimalInt(params int[] elements)
       {
           int min = int.MaxValue; 

           for (int i = 0; i < elements.Length; i++)
           {
               if (elements[i] < min)
               {
                   min = elements[i];
               }
           }

           Console.WriteLine("The smallest is: {0}", min);
       }

       private static void MaximalInt(params int[] elements)
       {
           int max = 0;

           for (int i = 0; i < elements.Length; i++)
           {
               if (elements[i] > max)
               {
                   max = elements[i];  
               }
           }

           Console.WriteLine("The biggest is: {0}", max);
       }

       private static void AverageInt(params int[] elements)
       {
           decimal averageNum = 0;

           foreach (var item in elements)
           {
               averageNum += item;
           }

           averageNum = averageNum / elements.Length;

           Console.WriteLine("The average is: {0}", averageNum);
       }

       private static void SummOfInts(params int[] elements)
       {
           int sum = 0;
           foreach (var item in elements)
           {
               sum += item;
           }

           Console.WriteLine("The sum is: {0}", sum);
       }
    }
}
