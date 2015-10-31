namespace LongestSubsequenceOfEqualInList
{
    using System;
    using System.Collections.Generic;

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

            List<int> longestSequenceOfEquals = FindLongestSequenceOfEquals(myList);

            Console.WriteLine(string.Join(", ", longestSequenceOfEquals));
        }

        private static List<int> FindLongestSequenceOfEquals(List<int> myList)
        {
            List<int> longest = new List<int>();

            int counter = 1;
            int topCounter = 1;
            int current = myList[0];
            int mostEqual = myList[0];

            for (int i = 1; i < myList.Count; i++)
            {
                if (myList[i] == current)
                {
                    counter++;

                    if (counter > topCounter)
                    {
                        topCounter = counter;
                        mostEqual = current;
                    }
                }
                else
                {
                    current = myList[i];
                    counter = 1;
                }
            }

            for (int j = 0; j < topCounter; j++)
            {
                longest.Add(mostEqual);
            }

            return longest;
        }
    }
}
