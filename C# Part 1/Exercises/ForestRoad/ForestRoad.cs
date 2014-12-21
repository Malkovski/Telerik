namespace ForestRoad
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class ForestRoad
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int height = (width * 2) - 1;
            int path = 0;
            int trees = 0;
            int counter = 2;
            for (int i = 0; i < height; i++)
            {
                if (i < (height/2) + 1)
                {
                   
                    for (int j = 0; j < width; j++)
                    {
                       
                        if (path == j)
                        {
                            Console.Write("*");
                           
                        }
                        else
                        {
                            Console.Write(".");
                        }
                    }
                }
                else
                {
                   
                   
                    for (int k = 0; k < width; k++)
                    {
                       
                       
                        if (k == width - counter)
                        {
                            Console.Write("*");
                            counter++;
                        }
                        else
                        {
                            Console.Write(".");
                        }
                        
                    }
                }
                path++;
                Console.WriteLine();
               
            }
        }
    }
}
