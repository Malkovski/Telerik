using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextToNumber
{
    class TextToNumber
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string txt = Console.ReadLine();

            int result = 0;

            for (int i = 0; i < txt.Length; i++)
            {
                if (txt[i] == '@')
                {
                    Console.WriteLine(result);
                    break;
                }
                else if (Char.IsNumber(txt[i]))
                {
                    int val = (int)Char.GetNumericValue(txt[i]);
                    result = result * val;
                }
                else if (Char.IsLetter(txt[i]))
                {
                    if (Char.IsUpper(txt[i]))
                    {
                        result = result + (txt[i] - 'A');
                    }
                    else
                    {
                        result = result + (txt[i] - 'a');
                    }                  
                }
                else
                {
                    result = result % number;
                }                                
            }
        }
    }
}
