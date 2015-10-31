namespace RemoveOddCountOccurances
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main()
        {
            var integerSequence = GetIntegerSequence();
            var processedSequence = ClearOddCountOccurances(integerSequence);

            PrintResult(processedSequence);
        }

        private static void PrintResult(List<int> processedSequence)
        {
            Console.WriteLine(string.Join(", ", processedSequence));
        }

        private static List<int> ClearOddCountOccurances(List<int> integerSequence)
        {
            for (int j = 0; j < integerSequence.Count; j++)
            {
                int current = integerSequence[j];
                int count = 0;

                for (int i = 0; i < integerSequence.Count; i++)
                {
                    if (integerSequence[i] == current)
                    {
                        count++;
                    }
                }

                if (count % 2 != 0)
                {
                    List<int> newSequence = new List<int>();

                    foreach (var item in integerSequence)
                    {
                        if (item != current)
                        {
                            newSequence.Add(item);
                        }
                    }

                    integerSequence = ClearOddCountOccurances(newSequence);
                }
            }

            return integerSequence;
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
    }
}
