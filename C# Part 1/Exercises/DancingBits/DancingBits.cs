namespace DancingBits
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System;
    class DancingBits
    {
        static void Main()
        {
            int k = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            string conc = null;
            string baza = null;
            int counter = 1;
            int ctr = 0;
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                long num = long.Parse(Console.ReadLine());
                string binary = Convert.ToString(num, 2);

                conc = string.Concat(baza, binary);
                baza = conc;
            }
            //Console.WriteLine(conc);
            if (k > 1)
            {
                for (int i = 1; i < conc.Length; i++)
                {
                    if (conc[i] == conc[i - 1])
                    {
                        counter++;
                        if (i == conc.Length - 1)
                        {
                            if (counter == k)
                            {
                                ctr++;
                            }
                        }

                    }
                    else
                    {
                        if ((counter > 1) & (counter == k))
                        {
                            ctr++;
                        }
                        counter = 1;
                    }
                }
                if (ctr != 0)
                {
                    Console.WriteLine(ctr);
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
            else
            {
                for (int i = 0; i < conc.Length; i++)
                {
                    if (i == 0)
                    {
                        if (conc[i] != conc[i + 1])
                        {
                            count++;
                        }
                    }
                    else if (i == conc.Length - 1)
                    {
                        if (conc[i] != conc[i - 1])
                        {
                            count++;
                        }
                    }
                    else
                    {
                        if ((conc[i] != conc[i - 1]) & (conc[i] != conc[i + 1]))
                        {
                            count++;
                        }
                    }
                }
                if (count != 0)
                {
                    Console.WriteLine(count);
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}