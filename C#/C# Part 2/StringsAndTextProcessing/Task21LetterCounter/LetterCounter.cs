namespace Task21LetterCounter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class LetterCounter
    {
       public static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string textOne = text.Replace(" ", "");
            char[] textArray = textOne.ToCharArray();
            Array.Sort(textArray);
            string letter = textArray[0].ToString();
            int count = 1;

                     
                for (int i = 1; i < textArray.Length; i++)
                {
                    if (textArray[i] == textArray[i - 1])
                    {
                        count++;
                        letter = textArray[i - 1].ToString();
                    }
                    else
                    {                   
                        Console.WriteLine("Letter {0} - {1} times", letter, count);
                        count = 1;
                        letter = textArray[i].ToString();
                    }
                }

                Console.WriteLine("Letter {0} - {1} times", letter, count);         
        }
    }
}
