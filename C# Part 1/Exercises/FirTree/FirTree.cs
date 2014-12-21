namespace FirTree
{
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class FirTree
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int w = ((n - 1)*2) - 1;
            int counter = 0;
              for (int i = 0; i < n; i++)
			{
                if (i != n-1)
                {
                    for (int j = 0; j < w; j++)
                    {
                        if (j == (w / 2))
                        {
                            Console.Write("*");
                        }
                        else if (j < w / 2)
                        {
                            if (j >= (w / 2) - counter)
                            {
                                Console.Write("*");
                            }
                            else
                            {
                                Console.Write(".");
                            }
                        }
                        else if (j > w / 2)
                        {
                            if (j <= (w / 2) + counter)
                            {
                                Console.Write("*");
                            }
                            else
                            {
                                Console.Write(".");
                            }
                        }
                        else
                        {
                            Console.Write(".");
                        }
                    }              
                }
                else
                {
                    for (int j = 0; j < w; j++)
                    {
                        if (j == (w / 2))
                        {
                            Console.Write("*");
                        }
                        else
                        {
                            Console.Write(".");
                        }
                    }
                }
		                  
                counter++;
                Console.WriteLine();
			}
        }
    }
}