namespace BunnyFactory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;

   public class BunnyFactory
	{
	   public static void Main(string[] args)
		{
			bool endInput = false;
			List<string> cages = new List<string>();

			for (int i = 0; ; i++)
			{
                string input = Console.ReadLine();

			   if (input != "END")
				{
					cages.Add(input); 
				}
				else
				{
					break;
				}
			}

			int cageCounter = 0;
			int steps = 0;

			while (!endInput)
			{
                if (cageCounter < cages.Count)
                {
                    for (int i = 0; i <= cageCounter; i++)
                    {
                        steps += int.Parse(cages[i]);
                    }

                    if (steps <= cages.Count - (cageCounter + 1))
                    {
                        int sum = 0;
                        BigInteger product = 1;

                        for (int j = cageCounter + 1; j <= steps + cageCounter; j++)
                        {
                            sum += int.Parse(cages[j]);
                            product *= BigInteger.Parse(cages[j]);
                        }

                        cages.RemoveRange(0, steps + (cageCounter + 1));                   
                        StringBuilder sumProduct = new StringBuilder(sum.ToString() + product.ToString());

                        for (int i = 0; i < cages.Count; i++)
                        {
                            sumProduct.Append(cages[i]);
                        }

                        sumProduct.Replace("0", "");
                        sumProduct.Replace("1", "");
                        cages.Clear();

                        for (int i = 0; i  < sumProduct.Length; i++)
                        {
                            if (sumProduct[i] != '0' && sumProduct[i] != '1')
                            {
                                cages.Add(sumProduct[i].ToString());
                            }
                        }
                    }
                    else
                    {
                        endInput = true;
                    }
                }
                else
                {
                    endInput = true;
                }
			
				cageCounter++;
                steps = 0;
			}

           string[] result = new string[cages.Count];
           cages.CopyTo(result);

           for (int i = 0; i < result.Length; i++)
           {
               if (i < result.Length - 1)
               {
                    Console.Write(result[i] + " ");
               }
               else
               {
                   Console.Write(result[i]);
               }
           }
		  
			
		}
	}
}
