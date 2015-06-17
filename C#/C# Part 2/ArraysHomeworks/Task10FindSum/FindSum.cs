namespace Task10FindSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class FindSum
    {
       public static void Main(string[] args)
        {
            string[] givenArr = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            int sum = int.Parse(Console.ReadLine());
            int val = 0;
            string result = string.Empty;


            for (int i = 0; i < givenArr.Length; i++)
            {
                for (int j = i; j < givenArr.Length; j++)
                {
                    val += int.Parse(givenArr[j]);
                    if (val < sum)
                    {
                        continue;
                    }
                    else if (val > sum)
                    {
                        val = 0;
                        break;
                    }
                    else
                    {
                        for (int h = i; h <= j; h++)
                        {
                            result += givenArr[h] + ", ";                                                
                        }
                    }
                }
            }
            result = result.TrimEnd(new char[] { ',', ' ' });
            Console.WriteLine("Elements with sum {0} are {1}", sum, result);
        }
    }
}
