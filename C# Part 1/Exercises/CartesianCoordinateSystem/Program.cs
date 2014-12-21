

namespace CartesianCoordinateSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            long x = long.Parse(Console.ReadLine());
            long y = long.Parse(Console.ReadLine());

            if (x > 0)
            {
                if (y > 0)
                {
                    Console.WriteLine("1");
                }
                else
                {
                    if (y < 0)
                    {
                        Console.WriteLine("4");
                    }
                    else
                    {
                        Console.WriteLine("6");
                    }
                }
            }
            else
            {
                if (x < 0)
                {
                    if (y > 0)
                    {
                        Console.WriteLine("2");
                    }
                    else
                    {
                        if (y < 0)
                        {
                            Console.WriteLine("3");
                        }
                        else
                        {
                            Console.WriteLine("6");
                        }
                    }
                }
                else
                {
                    if (y != 0)
                    {
                        Console.WriteLine("5");
                    }
                    else
                    {
                        Console.WriteLine("0");
                    }
                }
            }
        }
    }
}
