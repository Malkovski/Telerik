namespace Task3EnglishWord
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class EnglishWord
    {
       public static void Main(string[] args)
        {
            int givenInt = int.Parse(Console.ReadLine());

            int lastDigit = givenInt % 10;

            string word = MakeItWord(lastDigit);

            Console.WriteLine(word);
        }

       private static string MakeItWord(int lastDigit)
       {
           string word = string.Empty;

           switch (lastDigit)
           {
               case 0: word = "zero";
                   break;
               case 1: word = "one";
                   break;
               case 2: word = "two";
                   break;
               case 3: word = "three";
                   break;
               case 4: word = "four";
                   break;
               case 5: word = "five";
                   break;
               case 6: word = "six";
                   break;
               case 7: word = "seven";
                   break;
               case 8: word = "eight";
                   break;
               case 9: word = "nine";
                   break;
               default:
                   break;
           }

           return word;
       }
    }
}
