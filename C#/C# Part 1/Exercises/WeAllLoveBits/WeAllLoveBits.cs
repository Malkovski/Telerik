

namespace WeAllLoveBits
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class WeAllLoveBits
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                long number = long.Parse(Console.ReadLine());
                string binary = Convert.ToString(number, 2);
                string binarz = binary.TrimStart('0');
                string mirr = binarz.Replace("0", "5");
                string mirrNext = mirr.Replace("1", "0");
                string mirror = mirrNext.Replace("5", "1");
                string mirrorz = mirror.TrimStart('0');
                 char[] inputarray = binary.ToCharArray();
                 Array.Reverse(inputarray);
                 string rever = new string(inputarray);
                 string reverz = rever.TrimStart('0');
                        
                 byte pOne = (byte)int.Parse(binary);
                 byte pTwo = (byte)int.Parse(mirror);
                 byte pThree = (byte)int.Parse(reverz);

                 int result = (byte)((pOne ^ pTwo) & pThree);
                 Console.WriteLine(result);
            }
        }
    }
}

