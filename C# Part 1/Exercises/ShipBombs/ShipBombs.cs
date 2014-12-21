using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class ShipBombs
    {

        static void Main()
        {
            int damage = 0;
            int sX1 = int.Parse(Console.ReadLine());
            int sY1 = int.Parse(Console.ReadLine());
            int sX2 = int.Parse(Console.ReadLine());
            int sY2 = int.Parse(Console.ReadLine());

            int sX3 = sX2;
            int sY3 = sY1;
            int sX4 = sX1;
            int sY4 = sY2;


            int H = int.Parse(Console.ReadLine());

            for (int i = 0; i < 3; i++)
            {
                int cX1 = int.Parse(Console.ReadLine());
                int cY1 = int.Parse(Console.ReadLine());

                cY1 = 2 * H - cY1;

                int Left = Math.Min(sX1, sX2);
                int Right = Math.Max(sX1, sX2);
                int Top = Math.Max(sY1, sY2);
                int Bottom = Math.Min(sY1, sY2);


                if ((cY1 > Bottom) && (cY1 < Top))
                {
                    if ((cX1 > Left) && (cX1 < Right))
                    {
                        damage += 100;
                    }
                    else if ((cX1 == Left) || (cX1 == Right))
                    {
                        damage += 50;
                    }

                }
                else if ((cY1 == Bottom) || (cY1 == Top))
                {
                    if ((cX1 > Left) && (cX1 < Right))
                    {
                        damage += 50;
                    }
                    else if ((cX1 == Left) || (cX1 == Right))
                    {
                        damage += 25;
                    }
                }

            }

            Console.WriteLine(damage + "%");
        }
    }
}
