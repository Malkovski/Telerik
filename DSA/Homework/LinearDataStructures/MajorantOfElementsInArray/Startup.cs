namespace MajorantOfElementsInArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main()
        {
            var sequence = GetIntegerSequence();
            var majorant = FindMajorant(sequence);
            var placeholder = majorant == null ? "Not existing majorant!" : "The majorant is {0}";
            Console.WriteLine(placeholder, majorant);
        }

        private static int? FindMajorant(List<int> sequence)
        {
            int majorantMin = (sequence.Count / 2) + 1;
            HashSet<int> checkedIntegers = new HashSet<int>();
            int result;

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
                    if (count >= majorantMin)
                    {
                        result = current;
                        return result;
                    }
                }

                checkedIntegers.Add(current);
            }

            return null;
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
