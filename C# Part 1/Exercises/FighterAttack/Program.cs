

namespace FighterAttack
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
            int px1 = int.Parse(Console.ReadLine());
            int py1 = int.Parse(Console.ReadLine()); 
            int px2 = int.Parse(Console.ReadLine());
            int py2 = int.Parse(Console.ReadLine());
            int biggerX;
            int biggerY;
            int smallerX;
            int smallerY;
            int fx = int.Parse(Console.ReadLine());
            int fy = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());
            int damage = 0;
            int dif;

            //real distance difference
           
            dif = d + fx;
            //bigger coordinates
            if (px1 > px2)
            {
                biggerX = px1;
                smallerX = px2;
            }
            else
            {
                biggerX = px2;
                smallerX = px1;
            }
            if (py1 > py2)
            {
                biggerY = py1;
                smallerY = py2;
            }
            else
            {
                biggerY = py2;
                smallerY = py1;
            }
            //range check
            if (dif >= smallerX)
            {
                if (dif <= biggerX)
                {
                    if (fy <= biggerY)
                    {
                        if (fy >= smallerY)
                        {
                            damage += 100;
                        }
                    }
                }
            }
            if (dif+1 >= smallerX)
            {
                if (dif+1 <= biggerX)
                {
                    if (fy <= biggerY)
                    {
                        if (fy >= smallerY)
                        {
                            damage += 75;
                        }
                    }
                }
            }
            if (dif >= smallerX)
            {
                if (dif <= biggerX)
                {
                    if (fy+1 <= biggerY)
                    {
                        if (fy+1 >= smallerY)
                        {
                            damage += 50;
                        }
                    }
                }
            }
            if (dif >= smallerX)
            {
                if (dif <= biggerX)
                {
                    if (fy-1 <= biggerY)
                    {
                        if (fy-1 >= smallerY)
                        {
                            damage += 50;
                        }
                    }
                }
            }

            Console.WriteLine("{0}%", damage);

        }
    }
}
