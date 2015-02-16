namespace Task18ExtractEmails
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ExtractEmails
    {
       public static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string[] parts = text.Split(' ');
            int counter = 0;
            bool foundEt = false;

            for (int i = 0; i < parts.Length; i++)
            {
                string temp = parts[i];

                for (int j = 0; j < temp.Length; j++)
                {
                    if (temp[j] == '@' && j > 0 && j <= temp.Length - 4)
                    {
                        string tempRight = temp.Substring(j + 1);

                        if (tempRight[0] != '.' && tempRight[tempRight.Length - 1] != '.' && tempRight[tempRight.Length - 2] != '.')
                        {
                            for (int k = 1; k < tempRight.Length - 2; k++)
                            {
                                if (tempRight[k] == '.')
                                {
                                    Console.WriteLine(parts[i]);
                                    counter++;
                                    foundEt = true;
                                }
                            }
                        }
                    }

                    if (foundEt)
                    {
                        break;
                    }                
                }
            }

            if (counter == 0)
            {
                Console.WriteLine("No match found!");
            }
        }
    }
}
