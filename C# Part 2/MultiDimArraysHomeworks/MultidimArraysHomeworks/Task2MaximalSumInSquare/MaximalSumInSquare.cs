namespace Task2MaximalSumInSquare
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class MaximalSumInSquare
    {
       public static void Main(string[] args)
        {
           bool isOk = true;
           while (isOk)
	       {
               Console.Write("Enter matrix rows: ");
               int n = int.Parse(Console.ReadLine());
               Console.Write("Enter matrix columns: ");
               int m = int.Parse(Console.ReadLine());
               if ((n < 3) || (m < 3))
               {
                   Console.WriteLine("Impossible!!! The matrix is smaller than 3x3!!!");
                   Console.WriteLine("Try Again!!!");
                   isOk = false;
                   break;
               }

               Console.WriteLine();
               int[,] givenMatrix = new int[n, m];
               Console.WriteLine("Enter {0} integer numbers! Every number on a new line!", n * m);
               for (int i = 0; i < n; i++)
               {
                   for (int j = 0; j < m; j++)
                   {
                       givenMatrix[i, j] = int.Parse(Console.ReadLine());
                   }
               }

               int sum = 0;
               int maxSum = 0;

               for (int row = 1; row < n - 1; row++)
               {
                   for (int col = 1; col < m - 1; col++)
                   {
                       for (int i = row - 1; i <= row + 1; i++)
                       {
                           for (int j = col - 1; j <= col + 1; j++)
                           {
                               sum += givenMatrix[i, j];
                           }

                           if (sum > maxSum)
                           {
                               maxSum = sum;
                               sum = 0;
                           }
                       }
                   }
               }

               Console.WriteLine("The maximal sum in 3x3 square is: {0}", maxSum);   
	       }                                        
        }
    }
}
