

namespace DrunkenNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class DrunkenNumbers
    {
        static void Main(string[] args)
        {
            int rounds = int.Parse(Console.ReadLine());
            int[] beers = new int[rounds];
            int sum = 0;
            int vladko = 0;
            int mitko = 0;
            int sharedBeer = 0;
            for (int i = 0; i < beers.Length; i++)
            {
                string enter = Console.ReadLine();
                string newEnter = enter.Replace("-","");
                newEnter = newEnter.TrimStart('0');
                beers[i] = int.Parse(newEnter);
                
            }
            for (int i = 0; i < rounds; i++)
            {
                int len = beers[i].ToString().Length;
                int[] bottles = new int[len];
                
                for (int j = 0; j < bottles.Length; j++)
                {
                    bottles[j] = (beers[i] % 10);
                    beers[i] = (beers[i] - bottles[j]) / 10;
                    sum += bottles[j];
                    if ((len % 2) == 1)
                    {
                        if (j < bottles.Length / 2)
                        {
                            vladko += bottles[j];
                        }
                        else if (j > bottles.Length / 2)
                        {
                            mitko += bottles[j];
                        }
                        sharedBeer = sum - (mitko + vladko);
                        mitko += (sharedBeer / 2);
                        vladko += (sharedBeer / 2);  
                    }
                    else
                    {
                        if (j < bottles.Length / 2)
                        {
                            vladko += bottles[j];
                        }
                        mitko = sum - vladko;
                    }
                   
                }
                
              
            }
            if (vladko > mitko)
            {
                Console.WriteLine("V " + (vladko - mitko));
            }
            else if (mitko > vladko)
            {
                Console.WriteLine("M " + (mitko - vladko));
            }
            else
            {
                Console.WriteLine("No " + sum);
            }
        }
    }
}
