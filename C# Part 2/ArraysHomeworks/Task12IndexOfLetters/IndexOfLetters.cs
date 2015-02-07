namespace Task12IndexOfLetters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class IndexOfLetters
    {
       public static void Main(string[] args)
        {
            char[] alphabet = new char[26];

            for (int i = 0; i < alphabet.Length; i++)
            {
                alphabet[i] = (char)(i + 'a');
            }

            string givenWord = Console.ReadLine();
            string pos = string.Empty;

            for (int i = 0; i < givenWord.Length; i++)
            {       
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (char.ToLower(givenWord[i]) == char.ToLower(alphabet[j]))
                    {
                        pos += j + ", ";
                    }
                }
            }

            pos = pos.TrimEnd(new char[] { ',', ' ' });
            Console.WriteLine("Indexes of the letters in the given word are: {0}", pos);
        }
    }
}
