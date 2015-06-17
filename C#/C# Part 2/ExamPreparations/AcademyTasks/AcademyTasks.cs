namespace AcademyTasks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class AcademyTasks
    {
       public static void Main(string[] args)
        {
            string inputData = Console.ReadLine();
            
           int variety = int.Parse(Console.ReadLine());
            string[] pleasent = inputData.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            int solve = 1;
            int smallest = int.Parse(pleasent[0]);
            int biggest = int.Parse(pleasent[0]);
            int indexSmall = 0;
            int indexBig = 0;
            bool noMatch = true;

            for (int i = 0; i < pleasent.Length; i++)
            {
                if (int.Parse(pleasent[i]) <= smallest)
                {
                    smallest = int.Parse(pleasent[i]);
                    indexSmall = i;                
                }
                else
                {
                    if (int.Parse(pleasent[i]) >= biggest)     
                    {
                        biggest = int.Parse(pleasent[i]);
                        indexBig = i;
                    }
                }

                if (biggest - smallest >= variety)
                {
                    noMatch = false;
                    break; 
                }
            }

            if (noMatch)
            {
                solve = pleasent.Length;
            }
            else
            {
                if (indexSmall < indexBig)
                {
                    solve = HopsCounter(indexSmall, indexBig);                  
                }
                else
                {
                   solve = HopsCounter(indexBig, indexSmall);                 
                }
            }

            Console.WriteLine(solve);
        }

       public static int HopsCounter(int first, int second)
       {
           int solve = 1;

           if (first % 2 == 1)
           {
               int bigHops = first / 2;
               solve += bigHops + 1;
           }
           else
           {
               int bigHops = first / 2;
               solve += bigHops;
           }

           int distance = second - first;

           if (distance % 2 == 1)
           {
               int bigHops = distance / 2;
               solve += bigHops + 1;
           }
           else
           {
               int bigHops = distance / 2;
               solve += bigHops;
           }

           return solve;
       }
    }
}
