namespace Digits
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class Digits
    {
       public static void Main(string[] args)
        {
            int len = int.Parse(Console.ReadLine());
            int[,] matrix = new int[len, len];
            int sum = 0;

            for (int i = 0; i < len; i++)
            {
                StringBuilder line = new StringBuilder(Console.ReadLine());
                line = line.Replace(" ", "");

                for (int j = 0; j < len; j++)
                {
                    matrix[i, j] = int.Parse(line[j].ToString());
                }
                line.Clear();
            }

            for (int row = len - 1; row >= len - (len - 4); row--)
            {
                for (int col = len - 1; col >= 1; col--)
                {
                    sum += FindDigit(matrix, row, col);
                }
            }

            Console.WriteLine(sum);
        }

       private static int FindDigit(int[,] p, int r , int c)
       {
           int sum = 0;

           if (c > 1)
           {
               if (p[r, c] == 8)
               {
                   if (p[r, c - 1] == 8 && p[r, c - 2] == 8)
                       if (p[r - 4, c] == 8 && p[r - 4, c - 1] == 8 && p[r - 4, c - 2] == 8)
                           if (p[r - 1, c] == 8 && p[r - 1, c - 2] == 8)
                               if (p[r - 2, c - 1] == 8)
                                   if (p[r - 3, c] == 8 && p[r - 3, c - 2] == 8)
                                   {
                                       sum = 8;
                                   }
               }
               else if (p[r, c] == 9)
               {
                   if (p[r, c - 1] == 9 && p[r, c - 2] == 9)
                       if (p[r - 4, c] == 9 && p[r - 4, c - 1] == 9 && p[r - 4, c - 2] == 9)
                           if (p[r - 1, c] == 9 && p[r - 2, c] == 9 && p[r - 2, c - 1] == 9)
                               if (p[r - 3, c] == 9 && p[r - 3, c - 2] == 9)
                               {
                                   sum = 9;
                               }
               }
               else if (p[r, c] == 6)
               {
                   if (p[r, c - 1] == 6 && p[r, c - 2] == 6)
                       if (p[r - 4, c] == 6 && p[r - 4, c - 1] == 6 && p[r - 4, c - 2] == 6)
                           if (p[r - 1, c] == 6 && p[r - 1, c - 2] == 6)
                               if (p[r - 2, c] == 6 && p[r - 2, c - 1] == 6 && p[r - 2, c - 2] == 6)
                                   if (p[r - 3, c - 2] == 6)
                                   {
                                       sum = 6;
                                   }
               }
               else if (p[r, c] == 5)
               {
                   if (p[r, c - 1] == 5 && p[r, c - 2] == 5)
                       if (p[r - 4, c] == 5 && p[r - 4, c - 1] == 5 && p[r - 4, c - 2] == 5)
                           if (p[r - 1, c] == 5)
                               if (p[r - 2, c] == 5 && p[r - 2, c - 1] == 5 && p[r - 2, c - 2] == 5)
                                   if (p[r - 3, c - 2] == 5)
                                   {
                                       sum = 5;
                                   }
               }
               else if (p[r, c] == 3)
               {
                   if (p[r, c - 1] == 3 && p[r, c - 2] == 3)
                       if (p[r - 4, c] == 3 && p[r - 4, c - 1] == 3 && p[r - 4, c - 2] == 3)
                           if (p[r - 1, c] == 3 && p[r - 2, c] == 3 && p[r - 2, c - 1] == 3)
                               if (p[r - 3, c] == 3)
                               {
                                   sum = 3;
                               }
               }
               else if (p[r, c] == 2)
               {
                   if (p[r, c - 1] == 2 && p[r, c - 2] == 2)
                       if (p[r - 4, c - 1] == 2)
                           if (p[r - 1, c - 1] == 2)
                               if (p[r - 2, c] == 2)
                                   if (p[r - 3, c] == 2 && p[r - 3, c - 2] == 2)
                                   {
                                       sum = 2;
                                   }
               }
               else if (p[r, c] == 4)
               {
                   if (p[r - 4, c] == 4 && p[r - 4, c - 2] == 4)
                       if (p[r - 1, c] == 4)
                           if (p[r - 2, c] == 4 && p[r - 2, c - 1] == 4 && p[r - 2, c - 2] == 4)
                               if (p[r - 3, c] == 4 && p[r - 3, c - 2] == 4)
                               {
                                   sum = 4;
                               }
               }
               else if (p[r, c] == 1)
               {
                   if (p[r - 1, c] == 1)
                       if (p[r - 4, c] == 1)
                           if (p[r - 2, c] == 1 && p[r - 2, c - 2] == 1)
                               if (p[r - 3, c] == 1 && p[r - 3, c - 1] == 1)
                               {
                                   sum = 1;
                               }
               }
               else if (p[r, c] == 7)
               {
                   if (c < p.GetLength(0) - 1)
                   {
                       if (p[r - 1, c] == 7)
                           if (p[r - 2, c] == 7)
                               if (p[r - 3, c + 1] == 7)
                                   if (p[r - 4, c + 1] == 7 && p[r - 4, c] == 7 && p[r - 4, c - 1] == 7)
                                   {
                                       sum = 7;
                                   }
                   }

               } 
           }
           else
           {
               if (p[r, c] == 7)
               {
                    if (p[r - 1, c] == 7)
                           if (p[r - 2, c] == 7)
                               if (p[r - 3, c + 1] == 7)
                                   if (p[r - 4, c + 1] == 7 && p[r - 4, c] == 7 && p[r - 4, c - 1] == 7)
                                   {
                                       sum = 7;
                                   }
               }
           }     

           return sum; 
       }
    }
}
