namespace DogeCoins
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

   public class DogeCoinsSolution
	{
	   public static void Main(string[] args)
		{
			string size = Console.ReadLine();
			string[] dims = size.Split(' ');
            int row = int.Parse(dims[0]);
            int col = int.Parse(dims[1]);
			int[,] grid = new int[row, col];
			int k = int.Parse(Console.ReadLine());       
			StringBuilder coordinates = new StringBuilder();

            if (k == 0)
            {
                grid[row - 1, col - 1] = 0;
            }
            else
            {
                for (int i = 0; i < k; i++)
                {
                    coordinates.Append(Console.ReadLine());

                    if (i < k - 1)
                    {
                        coordinates.Append(" ");
                    }
                }

                string line = coordinates.ToString();
                string[] coord = line.Split(' ');

                for (int i = 0; i < coord.Length; i += 2)
                {
                    int r = int.Parse(coord[i]);
                    int c = int.Parse(coord[i + 1]);
                    grid[r, c]++;
                }

                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        if (i == 0)
                        {
                            if (j > 0)
                            {
                                grid[i, j] += grid[i, j - 1];
                            }
                        }

                        if (j == 0)
                        {
                            if (i > 0)
                            {
                                grid[i, j] += grid[i - 1, j];
                            }
                        }

                        if (i > 0 && j > 0)
                        {
                            if (grid[i - 1, j] < grid[i, j - 1])
                            {
                                grid[i, j] += grid[i, j - 1];
                            }
                            else if (grid[i - 1, j] > grid[i, j - 1])
                            {
                                grid[i, j] += grid[i - 1, j];
                            }
                            else
                            {
                                grid[i, j] += grid[i - 1, j];
                            }
                        }
                    }
                }
            }
	
           Console.WriteLine(grid[row - 1, col - 1]);
		}
	}
}
