namespace SimpleJediMeditation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main()
        {
            var masters = new List<string>();
            var knights = new List<string>();
            var padwans = new List<string>();

            var n = int.Parse(Console.ReadLine());

            var jedis = Console.ReadLine().Split(' ');

            for (int i = 0; i < n; i++)
            {
                if (jedis[i].StartsWith("m"))
                {
                    masters.Add(jedis[i]);
                }

                if (jedis[i].StartsWith("k"))
                {
                    knights.Add(jedis[i]);
                }

                if (jedis[i].StartsWith("p"))
                {
                    padwans.Add(jedis[i]);
                }
            }

            foreach (var item in masters)
            {
                Console.Write(item);
                Console.Write(" ");
            }

            foreach (var item in knights)
            {
                Console.Write(item);
                Console.Write(" ");
            }

            foreach (var item in padwans)
            {
                Console.Write(item);
                Console.Write(" ");
            }
        }
    }
}
