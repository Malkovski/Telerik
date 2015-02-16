namespace Task8ExtractSentences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class ExtractSentences
    {
       public static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine();
            string[] seperated = text.Split(new string[] { ". " }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine();

            for (int i = 0; i < seperated.Length; i++)
            {
                string[] words = seperated[i].Split(' ');

                foreach (string part in words)
                {
                    if (part == word)
                    {
                        Console.Write(seperated[i]);
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
