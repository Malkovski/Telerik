

namespace MissCat3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            int[] cats = new int[10];
            int n = int.Parse(Console.ReadLine());
            int winner = 0;
            for (int i = 0; i < n; i++)
            {
                int vote = int.Parse(Console.ReadLine());
                cats[vote - 1]++;

                int maxcount = 0;
                

                for (int j = 0; j < 10; j++)
                {
                    if (cats[j] > maxcount)
                    {
                        winner = j + 1;
                        maxcount = cats[j];
                    }
                }
                
            }
            Console.WriteLine(winner);
        }
    }
}
