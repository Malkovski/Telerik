namespace Enigmation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class Enigmation
    {
        public static void Main(string[] args)
        {
            string input = System.IO.File.ReadAllText(@"C:\test.txt");

            // string input = Console.ReadLine();
            input = input.TrimEnd('=');
            string sub = string.Empty;
            bool inParens = false;
            string output = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                if (inParens)
                {
                    if (input[i] == ')')
                    {
                        inParens = false;
                        output += Calculate(sub);
                        sub = string.Empty;
                    }
                    else
                    {
                        sub += input[i];
                    }
                }
                else
                {
                    if (input[i] == '(')
                    {
                        inParens = true;
                    }
                    else
                    {
                        output += input[i];
                    }
                }
            }

            var result = Calculate(output);
            Console.WriteLine("{0}.000", result);
        }

        private static string Calculate(string input)
        {
            string operand = string.Empty;
            decimal current = 0;
            decimal num = 0;
            string numberAsStr = string.Empty;
            string secondNumberAsString = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                if (decimal.TryParse(input[i].ToString(), out current))
                {
                    if (operand != string.Empty)
                    {
                        numberAsStr = string.Empty;
                        secondNumberAsString += input[i];
                    }
                    else
                    {
                        numberAsStr += current;
                        num = long.Parse(numberAsStr);
                    }
                }
                else
                {
                    if (operand != string.Empty)
                    {
                        current = decimal.Parse(secondNumberAsString);
                        secondNumberAsString = string.Empty;
                        switch (operand)
                        {
                            case "+":
                                num = num + current;
                                operand = string.Empty;
                                break;
                            case "-":
                                num = num - current;
                                operand = string.Empty;
                                break;
                            case "*":
                                num = num * current;
                                operand = string.Empty;
                                break;
                            case "%":
                                num = num % current;
                                operand = string.Empty;
                                break;
                            default:
                                break;
                        }
                    }

                    operand = input[i].ToString();
                }
            }

            return num.ToString();
        }
    }
}
