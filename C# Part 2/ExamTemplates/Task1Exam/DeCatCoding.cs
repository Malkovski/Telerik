namespace Task1Exam
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;

    public class DeCatCoding
    {
        public static void Main(string[] args)
        {
            string line = Console.ReadLine();
            List<string> inDecimal = new List<string>();
            BigInteger result = new BigInteger();
            StringBuilder transformedWord = new StringBuilder();
            bool isEnd = false;

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] != ' ')
                {
                    int letter = line[i] - 'a';
                    inDecimal.Add(letter.ToString());                                  
                }
                else 
                {                   
                    result = TransformFromBaseToDecimal(inDecimal, 21, result);
                    Console.Write(DecimalToSomeBase(result, 26));
                    Console.Write(" ");
                    inDecimal.Clear();
                }                                           
            }
            if (inDecimal.Count > 0)
            {
                result = TransformFromBaseToDecimal(inDecimal, 21, result);
                Console.Write(DecimalToSomeBase(result, 26));
            }
  
        }

        private static string DecimalToSomeBase(BigInteger result, int toBase)
        {
            string answer = string.Empty;
            BigInteger dev = 0;

            while (result > 0)
            {
                dev = result % toBase;
                result /= toBase;
                char temp = (char)(dev + 'a');
                answer = temp + answer;
            }

            return answer;
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

        private static BigInteger TransformFromBaseToDecimal(List<string> input, int fromBase, BigInteger result)
        {
            result = BigInteger.Parse(input[input.Count - 1].ToString());
            BigInteger pow = 1;

            for (int i = input.Count - 2; i >= 0; i--)
            {
                pow *= fromBase;
                result += pow * BigInteger.Parse(input[i].ToString());
            }

            return result;
        }
    }
}
