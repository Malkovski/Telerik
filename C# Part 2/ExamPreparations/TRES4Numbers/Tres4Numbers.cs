namespace TRES4Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;

   public class Tres4Numbers
    {
       public static void Main(string[] args)
        {
            BigInteger msg = BigInteger.Parse(Console.ReadLine());
            string result = string.Empty;
            BigInteger dev = 0;

            if (msg > 0)
            {
                while (msg > 0)
                {
                    dev = msg % 9;
                    msg = msg / 9;
                    result = result + dev;
                }
            }
            else
            {
                result += 0;
            }
            
            string answer = string.Empty;

            for (int i = 0; i < result.Length; i++)
            {
                switch (result[i])
                {
                    case '0': answer = "LON+" + answer;
                        break;
                    case '1': answer = "VK-" + answer;
                        break;
                    case '2': answer = "*ACAD" + answer;
                        break;
                    case '3': answer = "^MIM" + answer;
                        break;
                    case '4': answer = "ERIK|" + answer;
                        break;
                    case '5': answer = "SEY&" + answer;
                        break;
                    case '6': answer = "EMY>>" + answer;
                        break;
                    case '7': answer = "/TEL" + answer;
                        break;
                    case '8': answer = "<<DON" + answer;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(answer);
        }		
    }
}
