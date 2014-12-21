namespace BatGoikoTower
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class BatGoikoTower
    {
      public static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            int width = height * 2;
            int ctr = 0;
            int counter = 0;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (j < (width / 2) - ctr)
                    {
                        Console.Write(".");
                    }
                    else
                    {
                        Console.Write("/");
                        ctr++;
                    }

                    if (j > (width / 2) + counter)
                    {
                        Console.Write(".");
                    }
                    else
                    {
                        Console.Write("\\");
                        counter++;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
