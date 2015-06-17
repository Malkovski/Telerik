namespace GoikoTower
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class GoikoTower
    {
        public static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            int width = height * 2;
            int ctr = 0;
            int counter = 0;
            int count = 2;
            int bar = 1;
            bool barNeeded = false;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {                   
                    if (j < width / 2)
                    {                                               
                            if (j == (width / 2) - 1 - ctr)
                            {
                                Console.Write("/");
                                ctr++;
                            }
                            else if (j < (width / 2) - 1 - ctr)
                            {
                                Console.Write(".");                               
                            }
                            else if ((j > (width / 2) - 1 - ctr) & (i == bar))
                            {
                                Console.Write("-"); 
                            }
                            else
                            {
                                Console.Write(".");
                            }
                    }
                    else
                    {                                               
                            if (j == (width / 2) + counter)
                            {
                                Console.Write("\\");                              
                            }
                            else if (j > (width / 2) + counter)
                            {
                                Console.Write(".");
                            }           
                            else if ((j < (width / 2) + counter) & (i == bar))
                            {
                                Console.Write("-");
                                barNeeded = true;
                            }
                            else
                            {
                                Console.Write(".");
                            }                                      
                    }                  
                }

                if (barNeeded)
                {
                    bar = bar + count;
                    barNeeded = false;
                    count++;
                }
            
                counter++;
                Console.WriteLine();                  
            }               
        }       
    }
}
