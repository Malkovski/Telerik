namespace RemoveNegativeNumbers
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
                    break;
                }
            }

            List<int> positives = RemoveNegatives(myList);

            Console.WriteLine(string.Join(", ", positives));
        }

        private static List<int> RemoveNegatives(List<int> myList)
        {
            return myList.Where(i => i > 0).ToList();
        }
    }
}
