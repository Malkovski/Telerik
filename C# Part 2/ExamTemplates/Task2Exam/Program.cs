namespace Task2Exam
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;

   public class Program
    {
       public static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
           
            for (int i = 0; i < lines; i++)
            {
                string row = Console.ReadLine();
                string[] nums = row.Split(' ');

                List<string> result = FindAbsoluteDiff(nums);
                bool answer = IsTrueOrFalse(result);

                if (answer)
                {
                    Console.WriteLine("True");
                }
                else
                {
                    Console.WriteLine("False");
                }

                result.Clear();
            }
        }

       private static bool IsTrueOrFalse(List<string> result)
       {
            
           bool isTrue = false;

           if (result.Count == 1)
           {
               isTrue = true;
           }
           else
           {
                for (int i = 1; i < result.Count; i++)
           {
               BigInteger firstEl = BigInteger.Parse(result[i - 1].ToString());
               BigInteger secondEl = BigInteger.Parse(result[i].ToString());

               if (secondEl >= firstEl)
               {
                   if ((secondEl - firstEl) == 1 || (secondEl - firstEl) == 0)
                   {
                       isTrue = true;
                   }
                   else
                   {
                       isTrue = false;
                       break;
                   }
               }
               else
               {
                   isTrue = false;
                   break;
               }    
           }
           }
          

           if (isTrue)
           {
               return true;
           }
           else
           {
               return false;
           }
       }

       private static List<string> FindAbsoluteDiff(string[] nums)
       {
           List<string> result = new List<string>();

           for (int i = 1; i < nums.Length; i++)
           {
              BigInteger first = BigInteger.Parse(nums[i - 1]);
              BigInteger second = BigInteger.Parse(nums[i]);

             BigInteger tempNum = second - first;

             if (tempNum < 0)
             {
                 tempNum *= -1;
             }
             
             result.Add(tempNum.ToString());
           }

           return result;
       }
    }
}
