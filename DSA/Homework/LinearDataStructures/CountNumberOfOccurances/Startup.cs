namespace CountNumberOfOccurances
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main()
        {
            var sequence = GetIntegerSequence();
            var countedOccurances = CountOccurances(sequence);
            PrintResult(countedOccurances);
        }

        private static List<string> CountOccurances(List<int> sequence)
        {
            HashSet<int> checkedIntegers = new HashSet<int>();
            List<string> result = new List<string>();

            for (int i = 0; i < sequence.Count; i++)
            {
                int current = sequence[i];
                int count = 0;
                
                for (int j = 0; j < sequence.Count; j++)
                {
                    if (sequence[j] == current)
                    {
                        count++;
                    }
                }

                if (!checkedIntegers.Contains(current))
                {
                    var holder = count > 1 ? "{0} -> {1} times" : "{0} -> {1} time";
                    result.Add(string.Format(holder, current, count));
                }

                checkedIntegers.Add(current);
            }

            return result;
        }

        private static List<int> GetIntegerSequence()
        {
            List<int> myList = new List<int>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input != String.Empty)
                {
                    myList.Add(int.Parse(input));
                }
                else
                {
                    break;
                }
            }

            return myList;
        }

        private static void PrintResult(List<string> processedSequence)
        {
            foreach (var item in processedSequence)
            {
                Console.WriteLine(item);
            }
        }
            
    }
}
