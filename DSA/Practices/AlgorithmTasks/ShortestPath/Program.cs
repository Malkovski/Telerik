namespace ShortestPath
{
    using Facet.Combinatorics;
    using System;
    using System.Linq;

    public class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var parts = input.Split(new char[] {'*'}, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == "*")
                {
                }
            }

            var letters = new string[] { "L", "S", "R" };

            var a = new Combinations<string>(letters, input.Length, GenerateOption.WithoutRepetition);

            Console.WriteLine(Math.Pow(3, parts.Length - 1));

            foreach (var item in a)
            {
                foreach (var ss in item)
                {
                    Console.Write(string.Format("{0}", ss));
                }
                Console.WriteLine();
            }
        }
    }
}
