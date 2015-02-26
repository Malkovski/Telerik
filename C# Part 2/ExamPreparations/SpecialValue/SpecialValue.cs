namespace SpecialValue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class SpecialValue
    {
       public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] mtx = new int[n][];
            bool[][] visit = new bool[n][];
            mtx.Initialize();
            for (int i = 0; i < n; i++)
            {
               StringBuilder line = new StringBuilder(Console.ReadLine());
               line.Append(",");
               StringBuilder word = new StringBuilder();
               List<int> lst = new List<int>();
               int posCounter = 0;

               for (int p = 0; p < line.Length; p++)
               {
                   if (line[p] != ',')
                   {
                       word.Append(line[p]);
                   }
                   else
                   {
                       string num = word.ToString();
                       
                       lst.Add(int.Parse(num));
                   
                       word.Clear();
                       posCounter++;
                       p++;
                   }
               }

               int[] prt = lst.ToArray();
               mtx[i] = prt;
               line.Clear();
               lst.Clear();
               visit[i] = new bool[mtx[i].Length];
            }

            int specialValue = 0;
            int winner = -2;

            for (int i = 0; i < mtx[0].Length; i++)
            {
                for (int j = 0; j < visit.GetLength(0); j++)
                {
                    for (int k = 0; k < visit[j].Length; k++)
                    {
                        visit[j][k] = false; 
                    }  
                }

                specialValue = FindSpecialValue(mtx, visit, 0, i, 1);               

                if (specialValue > winner)
                {
                    winner = specialValue;
                }
            }

            if (winner > 0)
            {
                Console.WriteLine(winner);
            }
        }

       private static int FindSpecialValue(int[][] mtx, bool[][] visit, int p, int i, int special)
       {
           visit[p][i] = true;
           int pos = mtx[p][i];

           if (pos >= 0)
           {
               if (p + 1 <= mtx.GetLength(0) - 1)
               {
                   p++;
               }
               else
               {
                   p = 0;
               }

               if (!visit[p][pos])
               {               
                    special++;
                    special = FindSpecialValue(mtx, visit, p, pos, special);         
               }
               else
               {
                   special = -1;
               }
           }
           else
           {
               special += pos * -1;
           }

           

           return special;
       }
    }
}
