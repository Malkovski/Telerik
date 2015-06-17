using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cube
{
    class Cube
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int count = 0;
            var ctr = 0;
            int h = n * 2 - 1;
            int w = n * 2 - 1;
            Console.WriteLine();

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    if (i < h/2)
                    {
                       

                        if (j < w/2 - ctr)
                        {
                            Console.Write(" ");
                        }
                        else
                        {
                            if (i == 0)
                            {
                                Console.Write(":"); 
                            }
                            else
                            {
                                if (j ==( w/2 - ctr) || j ==( w - (ctr + 1)) || j == (w - 1))
                                {
                                    Console.Write(":"); 
                                }
                                else
                                {
                                    if ((j > ( w/2 - ctr) && j < ( w - ctr)))
                                    {
                                        Console.Write("/");  
                                    }
                                    else
                                    {
                                       
                                            Console.Write("X");                                       
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                       
                        if (i == h/2)
                        {
                            ctr = 0;
                            if (j > w/2 && j < w -1 )
                            {
                                Console.Write("X");
                            }
                            else
                            {
                                Console.Write(":");
                            }
                        }
                        else if (i == h -1)
                        {
                            if (j > w/2)
                            {
                                Console.Write(" ");
                            }
                            else
                            {
                                Console.Write(":");
                            }
                        }
                        else
                        {
                            if (j == 0)
                            {
                                Console.Write(":");
                            }
                            else if (j == w / 2)
                            {
                                Console.Write(":");
                            }
                            else if (j > 0 && j < w/2)
                            {
                                Console.Write(" ");
                            }
                            else if (j > w/2 && j < ((w - 1) - ctr))
                            {
                                Console.Write("X");
                            }
                            else if (j == ((w - 1) - ctr))
                            {
                               Console.Write(":"); 
                            }
                            
                        }
                    }
                    
                }
                ctr++;
                
                Console.WriteLine();
            }
        }
    }
}
