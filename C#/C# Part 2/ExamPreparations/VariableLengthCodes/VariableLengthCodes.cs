namespace VariableLengthCodes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class VariableLengthCodes
    {
       public static void Main(string[] args)
        {
            string line = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            string[] keyCodes = new string[rows];

            for (int i = 0; i < rows; i++)
            {
                keyCodes[i] = Console.ReadLine();
            }

            string[] num = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder binar = new StringBuilder();
            int rem = 0;
            string result = string.Empty;

            for (int i = 0; i < num.Length; i++)
            {
                int loc = int.Parse(num[i]);

                while (loc > 0)
                {
                    rem = loc % 2;
                    loc = loc / 2;
                    result = rem.ToString() + result;
                }

                if (result.Length < 8)
                {
                    binar.Append(0);
                }

                binar.Append(result);
                result = string.Empty;      
            }

            StringBuilder text = new StringBuilder();
            int count = 0;

            for (int i = 0; i < binar.Length; i++)
            {           
                if (binar[i] == '1')
                {
                    count++;
                }
                else
                {
                    if (count > 0)
                    {
                        for (int j = 0; j < keyCodes.Length; j++)
                        {
                            if (int.Parse(keyCodes[j].Substring(1)) == count)
                            {
                                text.Append(keyCodes[j].Substring(0, 1));
                                break;
                            }
                        }
                    }

                    count = 0;
                }
            }

            Console.WriteLine(text.ToString());
        }
    }
}
