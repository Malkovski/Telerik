namespace Task1FillTheMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class FillTheMatrix
    {
       public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int count = 1;

            int[,] matrix = new int[size, size];

            for (int col = 0; col < size; col++)
            {
                for (int row = 0; row < size; row++)
                {
                    matrix[row, col] = count;
                    count++;
                }
            }

            PrintMatrix(matrix);
            count = 1;
            Array.Clear(matrix, 0, matrix.Length);

            for (int col = 0; col < size; col++)
            {
                if ((col % 2) == 0)
                {
                    for (int row = 0; row < size; row++)
                    {
                        matrix[row, col] = count;
                        count++;
                    }
                }
                else
                {
                    for (int row = size - 1; row >= 0; row--)
                    {
                        matrix[row, col] = count;
                        count++;
                    }
                }              
            }

            PrintMatrix(matrix);
            count = 1;
            Array.Clear(matrix, 0, matrix.Length);

            for (int i = 0; i < size; i++)
            {
                int temp = 0;

                for (int j = size - i - 1; j < size; j++)
                {
                    matrix[j, temp] = count;
                    count++;
                    temp++;
                }
            }

            for (int i = 0; i < size; i++)
            {
                int temp = 0;

                for (int j = i + 1; j < size; j++)
                {
                    matrix[temp, j] = count;
                    count++;
                    temp++;
                }
            }

            PrintMatrix(matrix);
            count = 1;
            Array.Clear(matrix, 0, matrix.Length);

            int val = size;

            do
            {
                for (int i = size - val; i < val; i++)
                {
                    matrix[i, size - val] = count;
                    count++;
                }

                for (int i = size - val + 1; i < val; i++)
                {
                    matrix[val - 1, i] = count;
                    count++;
                }

                for (int i = val - 2; i >= size - val; i--)
                {
                    matrix[i, val - 1] = count;
                    count++;
                }

                for (int i = val - 2; i > size - val; i--)
                {
                    matrix[size - val, i] = count;
                    count++;
                }

                val--;
            }
            while (count <= matrix.Length);
            
            PrintMatrix(matrix);
        }

       private static void PrintMatrix(int[,] matrix)
       {
           int len = matrix.GetLength(0);
           for (int row = 0; row < len; row++)
           {
               for (int col = 0; col < len; col++)
               {
                   if (matrix[row, col] < 10)
                   {
                       Console.Write(" " + matrix[row, col] + " ");
                   }
                   else
                   {
                       Console.Write(matrix[row, col] + " ");
                   }                   
               }

               Console.WriteLine();
           }

           Console.WriteLine();
       }
    }
}
