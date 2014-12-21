

namespace SecretAlpha
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            int special = 0;
            string input = Console.ReadLine();
            input = input.TrimStart('-');
            char[] inputarray = input.ToCharArray();
            Array.Reverse(inputarray);
            string output = new string(inputarray);

            for (int i = 0; i < output.Length; i++)
            {
              
                if ((i % 2) == 0)
                {
                    special += ((output[i] -48) * ((i + 1) * (i + 1)));
                }
                else
                {
                    special += (((output[i] - 48) * (output[i] - 48)) * (i + 1));
                }
            }
            int R = (special % 26);
            string letters = " ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int count = (special % 10);
            if (count == 0)
            {
                Console.WriteLine(special);
                Console.WriteLine("{0} has no secret alpha-sequence", input);
            }
            else
            {
                Console.WriteLine(special);
                for (int j = 0; j < count; j++)
                {
                    if ((R + 1) > 26)
                    {
                        R = 0;
                        Console.Write(letters[R + 1]);
                        R++;
                    }
                    else
                    {
                        Console.Write(letters[R + 1]);
                        R++;
                    }

                }
            }
           
        }
    }
}
