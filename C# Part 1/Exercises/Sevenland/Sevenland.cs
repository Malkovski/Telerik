

namespace Sevenland
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Sevenland
    {
        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());
            int dif = k - 6;
            int j = (dif % 10);
            int kNew = 0;


            switch (k)
            {
                case 66: 
                case 166:
                case 266:
                case 366:
                case 466:
                case 566:
                         kNew = k + 34;
                         Console.WriteLine(kNew);
                         break;
                default:
                         break;

            }

            if (k < 666)
            {
                if ((k != 666) & (k != 66) & (k != 166) & (k != 266) & (k != 366) & (k != 466) & (k != 566))
                {
                    if (j == 0)
                    {
                        kNew = k + 4;
                    }
                    else
                    {
                        kNew = k + 1;
                    }
                    Console.WriteLine(kNew);
                }  
            }             
            else
            {

                kNew = 1000;
                Console.WriteLine(kNew);
                  
            }  
           
         
           
           
        }
    }
}
