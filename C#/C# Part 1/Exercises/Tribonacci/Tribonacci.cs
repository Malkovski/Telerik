

namespace Tribonacci
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Numerics;

    class Tribonacci
    {
        static void Main(string[] args)
        {
            int t1 = int.Parse(Console.ReadLine());
            int t2 = int.Parse(Console.ReadLine());
            int t3 = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            BigInteger[] trib = new BigInteger[n];
            trib[0] = t1;
            trib[1] = t2;
            trib[2] = t3;
            

            for (int i = 3; i < n; i++)
            {
                trib[i] += trib[i - 1] + trib[i- 2] + trib[i- 3];
                
            }
            Console.WriteLine(trib[n - 1]);
        }
    }
}
