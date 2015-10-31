namespace SumAndAvgWithList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main()
        {
            List<int> myList = new List<int>();

            while (true)
            {
                var input = Console.ReadLine();
                int sum = 0;

                if (input != "")
                {
                    myList.Add(int.Parse(input));
                }
                else
                {
                    foreach (var item in myList)
                    {
                        sum += item;
                    }

                    Console.WriteLine("The sum of elements is: {0}", sum);
                    Console.WriteLine("The avg of elements is: {0}", sum / myList.Count);
                    break;
                }
            }
        }
    }
}
