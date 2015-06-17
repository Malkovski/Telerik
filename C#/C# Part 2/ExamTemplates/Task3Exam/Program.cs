namespace Task3Exam
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;

   public class Program
    {
       public static void Main(string[] args)
        {
            int r = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

           BigInteger[,] grid = FillMatrix(r, c);

            int moves = int.Parse(Console.ReadLine());
            string[] movesAsStrings = Console.ReadLine().Split(' ');

            int coef = 0;

            if (r > c)
            {
                coef = r;
            }
            else
	        {
                coef = c;
	        }

            List<int> rows = new List<int>();
            List<int> cols = new List<int>();

            for (int i = 0; i < movesAsStrings.Length; i++)
            {
                decimal row = decimal.Parse(movesAsStrings[i]) / coef;
                rows.Add((int)row);
                decimal col = decimal.Parse(movesAsStrings[i]) % coef;
                cols.Add((int)col);
            }

            BigInteger count = CountingValues(grid, rows, cols);
            Console.WriteLine(count);
        }

       private static BigInteger CountingValues(BigInteger[,] grid, List<int> rows, List<int> cols)
       {
           BigInteger count = 0;
           int r = grid.GetLength(0);
           int c = grid.GetLength(1);
           int row = r - 1;
           int col = 0;
           count += grid[row, col];
           grid[r - 1, 0] = 0;

           for (int i = 0; i < rows.Count; i++)
           {
               int colNew = cols[i];
               if (colNew > col)
               {
                   while (colNew > col)
                   {
                       col++;
                       count += grid[row, col];
                       grid[row, col] = 0;
                   }
               }
               else
               {
                   while (colNew < col)
                   {
                       col--;
                       count += grid[row, col];
                       grid[row, col] = 0;
                   }
               }
              
               col = colNew;

               int rowNew = rows[i];

               if (rowNew > row)
               {
                   while (rowNew > row)
                   {
                       row++;
                       count += grid[row, col];
                       grid[row, col] = 0;
                   }
               }
               else
               {
                   while (rowNew < row)
                   {
                       row--;
                       count += grid[row, col];
                       grid[row, col] = 0;
                   }
               }
               
               row = rowNew;
           }

           return count;
       }

       private static BigInteger[,] FillMatrix(int r, int c)
       {
           BigInteger[,] grid = new BigInteger[r, c];
           
           for (int i = r - 1; i >= 0; i--)
           {             
               for (int j = 0; j < c; j++)
               {
                   if (j == 0 && i == r - 1)
                   {
                       grid[i, j] = 1;
                   }
                   else if (j == 0)
                   {
                       
                       grid[i, j] = grid[i + 1, j] * 2;
                   }
                   else
                   {
                       grid[i, j] = grid[i, j - 1] * 2;                    
                   }    
               }
           }

           return grid;
       }

      
    }
}
