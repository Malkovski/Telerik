using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
    class Program
    {
        static string letters = "LSR";
        static string input = Console.ReadLine();
        static int  n = input.Length;

        static void Main(string[] args)
        {

            var parts = input.Split('*');
            

            // S * L * R * S

            Build(0);
        }

        public static void Build(int index)
        {
            for (int i = 0; i < n; i++)
            {
                foreach (var item in letters)
                {
                    if (input[i] != '*')
                    {
                        Console.Write(input[i]);
                    }
                    else
                    {
                        for (int j = i; j < n; j++)
                        {
                            foreach (var el in letters)
                            {
                                if (input[j] != '*')
                                {
                                    Console.Write(input[j]);
                                }
                                else
                                {
                                    for (int k = j; k < n; k++)
                                    {
                                        foreach (var tt in letters)
                                        {
                                            if (input[k] != '*')
                                            {
                                                Console.Write(input[k]);
                                            }
                                            else
                                            {
                                                Console.Write(tt);
                                            }
                                        }
                                    }
                                }
                                Console.Write(el);
                            }

                            
                        }

                        
                    }
                    Console.Write(item);
                }
            }
        }
    }
}
