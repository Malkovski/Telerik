namespace Task6StringLength
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class StringLength
    {
       public static void Main(string[] args)
        {
            StringBuilder word = new StringBuilder();
            ConsoleKeyInfo stop;

            for (int i = 0; i < 20; i++)
            {
                stop = Console.ReadKey();
                
                if (stop.Key != ConsoleKey.Enter)
                {                  
                    word.Append(stop.KeyChar);
                }
                else
                {
                    break;
                }       
            }

            Console.WriteLine();
                    
            if (word.Length < 20)
            {
                while (word.Length < 20)
                {
                    word.Append("*");
                }
            }

            Console.WriteLine(word);
        }
    }
}
