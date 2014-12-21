using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleRotation
{
    class TripleRotatiom
    {
        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());
           
            string midd;
            int result = 0;
            int finalResult;

            for (int i = 0; i < 3; i++)
            {
                if (k < 10)
                {
                    result = k;
                }
                else
                {
                    int j = (k % 10);
                    if (j == 0)
                    {
                        result = k / 10;
                        k = result;
                    }
                    else
                    {
                        midd = String.Format("{0}{1}", j, (k - j));
                        result = (int.Parse(midd)/10);
                        k = result;

                    }
                }
               
                
            }
            Console.WriteLine(result);

           


        }
    }
}
