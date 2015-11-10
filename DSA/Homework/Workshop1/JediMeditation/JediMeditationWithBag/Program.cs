namespace JediMeditationWithBag
{
    using System;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            string[] jedis = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            var orderedByRank = new OrderedBag<string>(jedis, RankComparer);

            for (int i = 0; i < n; i++)
            {
                Console.Write(orderedByRank[i]);

                Console.Write(" ");
            }
        }

        private static int RankComparer(string firstRank, string secondRank)
        {
            int firstPriority = GetPriority(firstRank);
            int secondPriority = GetPriority(secondRank);

            return firstPriority.CompareTo(secondPriority);
        }

        private static int GetPriority(string element)
        {
            int priority = -1;

            switch (element[0].ToString().ToLower())
            {
                case "m":
                    priority = 0;
                    break;
                case "k":
                    priority = 1;
                    break;
                case "p":
                    priority = 2;
                    break;
            }

            return priority;
        }
    }
}
