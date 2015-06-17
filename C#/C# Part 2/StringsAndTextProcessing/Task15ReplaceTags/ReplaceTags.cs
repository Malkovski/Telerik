namespace Task15ReplaceTags
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class ReplaceTags
    {
       public static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string textOne = text.Replace("<a href=", "[URL=");
            string textTwo = textOne.Replace("</a>", "[/URL]");
            string finalText = textTwo.Replace("\">", "\"]");
            Console.WriteLine(finalText);
        }
    }
}
