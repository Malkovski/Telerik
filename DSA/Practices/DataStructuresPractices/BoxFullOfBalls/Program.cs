namespace BoxFullOfBalls
{
   // using Facet.Combinatorics;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        private static int[] balls;
        static void Main()
        {
            var count = 0;
            balls = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            var games = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();
            var low = games[0];
            var high = games[1];
            var combos = GetCombination(balls);

            for (int i = low; i <= high; i++)
            {
                CheckMod(i);
            }

            Console.WriteLine(count);
        }

        private static void CheckMod(int val)
        {
            var current = 0;
            var counter = 0;
            for (int i = 0; i < balls.Length; i++)
            {
                current += i;
                if (val == current)
                {
                    counter++;
                }
                else if (current < val)
                {
                    
                }
                else
                {
                    continue;
                }
            }
        }




        //---http://stackoverflow.com/questions/7802822/all-possible-combinations-of-a-list-of-values-in-c-sharp---//

        static List<int> GetCombination(int[] list)
        {
            var sum = 0;
            var result = new List<int>(); ;

            double count = Math.Pow(2, list.Length);
            for (int i = 1; i <= count - 1; i++)
            {
                bool[] mask = Dec2Bin(i, list.Length);
                for (int j = 0; j < mask.Length; j++)
                {
                    if (mask[j] == true)
                    {
                        sum += list[j];
                    }
                }

                result.Add(sum);
                sum = 0;
            }

            return result;
        }

        static bool[] Dec2Bin(int value, int len)
        {
            if (value == 0) return new[] { false };
            var n = (int)(Math.Log(value) / Math.Log(2));
            var a = new bool[len];
            for (var i = n; i >= 0; i--)
            {
                n = (int)Math.Pow(2, i);
                if (n > value) continue;
                a[i] = true;
                value -= n;
            }
            Array.Reverse(a);
            return a;
        }
    }
}
