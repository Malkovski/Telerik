namespace Task7EncodeDecode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class EncodDecode
    {
      public static void Main(string[] args)
        {
            Console.WriteLine("Enter cypher!");
            string cypher = Console.ReadLine();
            Console.WriteLine("Enter your text!");
            string text = Console.ReadLine();
            StringBuilder encoded = new StringBuilder();

            if (text.Length >= cypher.Length)
            {
                int lenCyp = 0;

                for (int i = 0; i < text.Length; i++)
                {
                    if (lenCyp >= cypher.Length)
                    {
                        lenCyp = 0;  
                    }
                    else
                    {
                        encoded.Append((char)(text[i] ^ cypher[lenCyp]));
                        lenCyp++;
                    }                  
                }
            }
            else
            {
                int lenTxt = 0;

                for (int i = 0; i < cypher.Length; i++)
                {
                    if (lenTxt >= text.Length)
                    {                    
                        text = encoded.ToString();
                        encoded.Clear();
                        lenTxt = 0;
                        encoded.Append((char)(text[lenTxt] ^ cypher[i]));
                        lenTxt++;
                        text = encoded.ToString() + text.Substring(lenTxt);
                    }
                    else
                    {
                        encoded.Append((char)(text[lenTxt] ^ cypher[i]));                      
                        lenTxt++;
                        text = encoded.ToString() + text.Substring(lenTxt);
                    }
                }
            }

            Console.WriteLine("Coded text is: ---{0}---", text);          
        }
    }
}
