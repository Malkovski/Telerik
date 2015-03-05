namespace DynamicOpt_Subsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class Subsequence
    {
       public static void Main(string[] args)
        {
            
           int m = int.Parse(Console.ReadLine());
           int n = int.Parse(Console.ReadLine());
           string[] firstLine = new string[m];
           string[] secondLine = new string[n];
           firstLine = Console.ReadLine().Split(' ');
           secondLine = Console.ReadLine().Split(' ');

           string result = FindSubsequence(firstLine, secondLine, m , n);
           Console.WriteLine(result);

        }

       private static string FindSubsequence(string[] firstLine, string[] secondLine, int m, int n)
       {
          int[,] grid = new int[m + 1, n + 1];

           for (int i = 0; i < m + 1; i++)
           {
               for (int j = 0; j < n + 1; j++)
               {
                   if (i == 0 || j == 0)
                   {
                       grid[i, j] = 0;
                   }
                   else
                   {
                       if (firstLine[i - 1] == secondLine[j - 1])
                       {
                           grid[i, j] = grid[i - 1, j - 1] + 1;
                       }
                       else
                       {
                           grid[i, j] = Math.Max(grid[i - 1, j], grid[i, j - 1]);
                       }
                   }   
               }
           }

           return grid[m, n].ToString();
       }
    }
}
