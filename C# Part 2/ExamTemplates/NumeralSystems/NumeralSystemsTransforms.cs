namespace NumeralSystems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;

   public class NumeralSystemsTransforms
    {
        public static void Main(string[] args)
        {
            string line = "805";
            BigInteger result = new BigInteger();
            int fromBase = 9;
            int toBase = 9;
            int len = 4;

            // In case equal length of the words with given length( 4 in this case)
            string input = TextToNumbers(line, len);

            // Converting from any numeral sys to decimal
            result = TransformFromBaseToDecimal(input, fromBase, result);
            Console.WriteLine(result.ToString());

            // Convert from decimal to any numeral sys
            string answer = DecimalToSomeBase(result, toBase);
            Console.WriteLine(answer);
        }

        private static string TextToNumbers(string line, int len)
        {
            StringBuilder word = new StringBuilder();
            string input = string.Empty;

            for (int i = 0; i < line.Length; i += len)
            {
                word.Append(line.Substring(i, len));

                switch (word.ToString())
                {
                    case "": input = ""; 
                        break;

                    default:
                        break;
                }

                word.Clear();
            }

            return input;
        }

        private static string DecimalToSomeBase(BigInteger result, int toBase)
        {
            string answer = string.Empty;
            BigInteger dev = 0;

            while (result > 0)
            {
                dev = result % toBase;
                result /= toBase;

                answer = dev + answer;
            }

            return answer;
        }

        private static BigInteger TransformFromBaseToDecimal(string input, int fromBase, BigInteger result)
        {
            result = BigInteger.Parse(input[input.Length - 1].ToString());
            BigInteger pow = 1;

            for (int i = input.Length - 2; i >= 0; i--)
            {
                pow *= fromBase;
                result += pow * BigInteger.Parse(input[i].ToString());
            }

            return result;
        }
    }
}
