namespace Portals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static SortedSet<int> results = new SortedSet<int>();
        private static string[,] matrix;
        private static int top;

        static void Main()
        {
            var startPos = Console.ReadLine().Split(' ');
            var row = int.Parse(startPos[0]);
            var col = int.Parse(startPos[1]);

            var size = Console.ReadLine().Split(' ');
            var rows = int.Parse(size[0]);
            var cols = int.Parse(size[1]);

            matrix = new string[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var data = Console.ReadLine().Split(' ');

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = data[j];
                }
            }

            Teleport(row, col);
            Console.WriteLine(results.LastOrDefault());
        }

        public static void Teleport(int row, int col)
        {
            var current = int.Parse(matrix[row, col]);
            matrix[row, col] = "#";

            top += current;
            results.Add(top);

            if (row - current >= 0 && matrix[row - current, col] != "#")
            {
                Teleport(row - current, col);
            }

            if (row + current <= matrix.GetLength(0) - 1 && matrix[row + current, col] != "#")
            {
                Teleport(row + current, col);
            }

            if (col + current <= matrix.GetLength(1) - 1 && matrix[row, col + current] != "#")
            {
                Teleport(row, + col + current);
            }

            if (col - current >= 0 && matrix[row, col - current] != "#")
            {
                Teleport(row, + col - current);
            }

            top -= current;
        }
    }
}
