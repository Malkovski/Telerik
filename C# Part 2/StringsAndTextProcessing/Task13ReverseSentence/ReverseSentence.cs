namespace Task13ReverseSentence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class ReverseSentence
    {
       public static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder(Console.ReadLine());     
            string newText = text.ToString();
            int cnt = 0;
            string[] words = newText.Split(new string[] { " " }, StringSplitOptions.None);
            string[] newWords = new string[words.Length];

            for (int i = words.Length - 1; i >= 0; i--)
            {         
                string tempWord = words[i];
                tempWord = tempWord.TrimEnd(',');
                tempWord = tempWord.TrimEnd('!');
                newWords[cnt] = tempWord;
                cnt++;       
            }

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i][words[i].Length - 1] == ',')
                {
                    newWords[i] = newWords[i] + ',';
                }
                else if (words[i][words[i].Length - 1] == '!')
                {
                     newWords[i] = newWords[i] + '!';
                }
            }

            for (int i = 0; i < newWords.Length; i++)
            {
                if (i < newWords.Length - 1)
                {
                    Console.Write(newWords[i] + " ");
                }
                else
                {
                    Console.Write(newWords[i]);
                }
            }

            Console.WriteLine();          
        }
    }
}
