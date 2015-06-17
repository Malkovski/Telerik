namespace Task9FrequentNumber
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class FrequentNumber
    {
       public static void Main(string[] args)
        {
            string[] givenArr = Console.ReadLine().Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            int count = 1;
            int maxCount = 0;
            string result = string.Empty;

            for (int i = 0; i < givenArr.Length - 1; i++)
            {
                for (int j = i; j < givenArr.Length - 1; j++)
                {
                    if (givenArr[i] == givenArr[j + 1])
                    {
                        count++;
                    }
                }
                if (count > maxCount)
                {
                    maxCount = count;
                    result = givenArr[i];
                }
                count = 1;
            }
            Console.WriteLine("Most frequent element is {0} found {1} times!",result, maxCount);
        }
    }
}
