namespace Task7LargestArea
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class LargestArea
    {
       public static void Main(string[] args)
       {
           DfsRecursive(0, 0);
         
       }

        static int[,] givenMatrix = 
        {
            { 1, 3,	2, 2, 2, 4 },
            { 3, 3,	3, 2, 4, 4 },
            { 4, 3,	1, 2, 3, 3 },
            { 4, 3,	1, 3, 3, 1 },
            { 4, 3,	3, 3, 1, 1 },                         
        };

       static bool[,] visited = new bool[givenMatrix.GetLength(0), givenMatrix.GetLength(1)];
       static int count = 0;


       static void DfsRecursive(int row, int col)
       {
           visited[row, col] = true;

           if (givenMatrix[row, col] == givenMatrix[row, col +1])
           {
               col++;
               count++;
           }
           else
           {
               if (givenMatrix[row, col] == givenMatrix[row + 1, col])
               {
                   row++;
                   count++;
               }
               else
               {
                   if (col == givenMatrix.GetLength(1) - 1 && row < givenMatrix.GetLength(0) - 1)
                   {
                       col = 0;                    
                       row++;
                   }
                   else if (row == givenMatrix.GetLength(0) - 1 && col < givenMatrix.GetLength(1))
                   {
                       row = 0;
                       col++;
                   }
               }
           }



           while (col < givenMatrix.GetLength(1) && row < givenMatrix.GetLength(0))
           {
              
               DfsRecursive(row, col);
            
           }

           Console.WriteLine(count);
       }

    }
}
