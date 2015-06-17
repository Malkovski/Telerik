namespace Task8MaximalSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class MaximalSum
    {
       public static void Main(string[] args)
        {       
           string[] givenArr = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
           int sum = 0;
           int maxSum = 0;
           string result = string.Empty;

           for (int i = 0; i < givenArr.Length; i++)
           {
               int counter = givenArr.Length - 1;
               sum = int.Parse(givenArr[i]);
               while (counter > i)
               {
                   for (int j = counter; j > i; j--)
                   {
                       sum += int.Parse(givenArr[j]);
                   } 
                                  
                   if (sum > maxSum)
                   {
                       maxSum = sum;
                       result = string.Empty;

                       for (int h = i + 1; h < counter + 1; h++)
                       {
                           result += givenArr[h] + ", ";                           
                       }

                       result = result.TrimEnd(new char[] { ',', ' ' });
                   }

                   counter--;
                   sum = 0;
               }                            
           }       
   
           Console.WriteLine("The sequence with maximal sum is {0} and it's sum is {1}", result, maxSum);
        }
    }
}
