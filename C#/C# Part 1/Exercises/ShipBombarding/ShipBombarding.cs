

namespace ShipBombarding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class ShipBombarding
    {
        static void Main(string[] args)
        {
            int s1x = int.Parse(Console.ReadLine());
            int s1y = int.Parse(Console.ReadLine());
            int s2x = int.Parse(Console.ReadLine());
            int s2y = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());
            int c1x = int.Parse(Console.ReadLine());
            int c1y = int.Parse(Console.ReadLine()); 
            int c2x = int.Parse(Console.ReadLine());
            int c2y = int.Parse(Console.ReadLine());
            int c3x = int.Parse(Console.ReadLine());
            int c3y = int.Parse(Console.ReadLine());
            int damage = 0;
            int totalDamage = 0;

            for (int i = 0; i < 3; i++)
            {
                if (i == 1)
                {
                    c1x = c2x;
                    c1y = c2y;
                }
                else
                {
                    if (i == 2)
                    {
                        c1x = c3x;
                        c1y = c3y;
                    }
                }
                int newC1y = 2*h - c1y;
                int newS1y = (s1y - h)*-1;
                int newS2y = (s2y - h)* -1;

                if (((c1x > s1x) & (c1x < s2x)) & ((newC1y < newS1y) & (newC1y > newS2y)))
                {
                    damage += 100;
                }
                    else
                    {
                         if ((((c1x > s1x) & (c1x < s2x)) & ((newC1y == newS1y) | (newC1y == newS2y))) & (((newC1y < newS1y) & (newC1y > newS2y)) & ((c1x == s1x) | (c1x == s2x))))
                        {
                            damage += 50;
                        }
                        else
                        {
                            if (((c1x == s1x) & (newC1y == newS1y)) | ((c1x == s2x) & (newC1y == newS2y)) | ((c1x == (s1x - (s1x - s2x))) & (newC1y == (newS1y - (newS1y - newS2y)))))
                            {
                                damage += 25;
                            }
                        }
                    }
                   
           
                totalDamage += damage;
            }
            Console.WriteLine("{0}%", totalDamage);
            
        }
    }
}
