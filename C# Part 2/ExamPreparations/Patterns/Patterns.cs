namespace Patterns
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;

   public class Patterns
    {
       public static void Main(string[] args)
        {
            int len = int.Parse(Console.ReadLine());
            BigInteger[,] matrix = new BigInteger[len, len];

            for (int i = 0; i < len; i++)
            {
                string line = Console.ReadLine();
                string[] lines = line.Split(' ');

                for (int j = 0; j < lines.Length; j++)
                {
                    matrix[i, j] = BigInteger.Parse(lines[j]);
                }
            }

            BigInteger sum = 0;
            BigInteger maxSum = 0;
            bool isPattern = false;

            for (int row = 0; row < len - 2; row++)
            {
                for (int col = 0; col < len - 4; col++)
                {
                    sum = FindPattern(matrix, row, col);

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        sum = 0;
                        isPattern = true;
                    }
                }
            }

            if (isPattern)
            {
                Console.WriteLine("YES {0}", maxSum);
            }
            else
            {
                BigInteger diagonal = 0;
                diagonal = CalculateDiagonal(matrix);
                Console.WriteLine("NO {0}", diagonal);
            }
        }

       private static BigInteger CalculateDiagonal(BigInteger[,] matrix)
       {
           BigInteger diagonal = 0;

           for (int row = 0; row < matrix.GetLength(0); row++)
           {
               diagonal += matrix[row, row];
           }

           return diagonal;
       }

       private static BigInteger FindPattern(BigInteger[,] mtx, int r, int c)
       {
           BigInteger b = mtx[r, c];
           BigInteger sum = 0;

           if (mtx[r, c + 1] == b + 1)
           {
               sum = mtx[r, c];
               b = mtx[r, c + 1];
               sum += b;
               if (mtx[r, c + 2] == b + 1)
               {
                   b = mtx[r, c + 2];
                   sum += b;
                   if (mtx[r + 1, c + 2] == b + 1)
                   {
                       b = mtx[r + 1, c + 2];
                       sum += b;
                       if (mtx[r + 2, c + 2] == b + 1)
                       {
                           b = mtx[r + 2, c + 2];
                           sum += b;
                           if (mtx[r + 2, c + 3] == b + 1)
                           {
                               b = mtx[r + 2, c + 3];
                               sum += b;
                               if (mtx[r + 2, c + 4] == b + 1)
                               {
                                   sum += mtx[r + 2, c + 4];
                               }
                               else
                               {
                                   sum = 0;
                               }
                           }
                           else
                           {
                               sum = 0;
                           }
                       }
                       else
                       {
                           sum = 0;
                       }
                   }
                   else
                   {
                       sum = 0;
                   }
               }
               else
               {
                   sum = 0;
               }
           }

           return sum;
       }
    }
}
