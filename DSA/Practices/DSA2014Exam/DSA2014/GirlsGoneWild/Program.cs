namespace GirlsGoneWild
{
    using Facet.Combinatorics;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main()
        {
            var k = int.Parse(Console.ReadLine());
            List<int> shirts = new List<int>();

            for (int i = 0; i < k; i++)
            {
                shirts.Add(i);
            }

            var skirts = Console.ReadLine().ToList();
            skirts.Sort();
            var girls = int.Parse(Console.ReadLine());

            Combinations<char> skirtComb = new Combinations<char>(skirts, 2, GenerateOption.WithoutRepetition);
            Combinations<int> shirtComb = new Combinations<int>(shirts, 2);

            var a = skirtComb.ToList();
            var b = shirtComb.ToList();

            for (int i = 0; i < b.Count ; i++)
            {
                for (int j = 0; j < a.Count ; j++)
                {
                    Console.WriteLine(string.Format("{0}{1}-{2}{3}",b[i][0], a[j][0], b[i][1], a[j][1]));
                }
            }
            
            Console.WriteLine();
        }
    }
}
