namespace SortIncreasingWithList
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

                if (input != "")
                {
                    myList.Add(int.Parse(input));
                }
                else
                {
                    myList.Sort();

                    foreach (var item in myList)
                    {
                        Console.WriteLine(item);
                    }

                    break;
                }
            }
        }
    }
}
