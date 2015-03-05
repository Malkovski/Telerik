namespace DynamicOptimizing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class DynamicOptimizingSolution
    {
       public static void Main(string[] args)
        {
            int maxWeight = int.Parse(Console.ReadLine());

            List<int> weight = new List<int>();
            List<int> value = new List<int>();

            string line = Console.ReadLine();
            while (line != "END")
            {
                string[] split = line.Split(' ');
                value.Add(int.Parse(split[1]));
                weight.Add(int.Parse(split[2]));

                line = Console.ReadLine();
            }

            int n = weight.Count;

            int[,] mat = new int[n + 1, maxWeight];
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < maxWeight; j++)
                {
                    if (weight[i - 1] <= j && j - weight[i - 1] >= 0)
                    {
                        mat[i, j] = Math.Max(mat[i - 1, j], mat[i - 1, j - weight[i - 1]] + value[i - 1]);
                    }
                    else
                    {
                        mat[i, j] = mat[i - 1, j];
                    }
                }
            }

            Console.WriteLine(mat[n, maxWeight - 1]);
        }
    }
}
