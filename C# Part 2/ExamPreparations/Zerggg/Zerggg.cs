namespace Zerggg
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class Zerggg
    {
       public static void Main(string[] args)
        {
            string zergMsg = Console.ReadLine();
            string zergNumberMsg = string.Empty;

            for (int i = zergMsg.Length - 1; i >= 0; i = i - 4)
            {
                string word = string.Empty;

                for (int j = 0; j < 4; j++)
                {
                    word = zergMsg[i - j] + word;
                }

                zergNumberMsg = ZergTranslator(word) + zergNumberMsg; 
            }

            int tempPower = 0;
            double result = 0;
            for (int i = zergNumberMsg.Length - 1; i >= 0; i--)
            {
                int realNum = 0;
                bool isNumber = int.TryParse(zergNumberMsg[i].ToString(), out realNum);
                if (!isNumber)
                {
                    switch (zergNumberMsg[i])
                    {
                        case 'A': realNum = 10;
                            break;
                        case 'B': realNum = 11;
                            break;
                        case 'C': realNum = 12;
                            break;
                        case 'D': realNum = 13;
                            break;
                        case 'E': realNum = 14;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    realNum = int.Parse(zergNumberMsg[i].ToString());
                }

                result += realNum * Math.Pow(15, tempPower);
                tempPower++;
            }
      
            Console.WriteLine(result);
        }

       private static string ZergTranslator(string word)
       {
           string zergMsg = string.Empty;

           switch (word)
           {
               case "Rawr": zergMsg = "0";
                   break;
               case "Rrrr": zergMsg = "1";
                   break;
               case "Hsst": zergMsg = "2";
                   break;
               case "Ssst": zergMsg = "3";
                   break;
               case "Grrr": zergMsg = "4";
                   break;
               case "Rarr": zergMsg = "5";
                   break;
               case "Mrrr": zergMsg = "6";
                   break;
               case "Psst": zergMsg = "7";
                   break;
               case "Uaah": zergMsg = "8";
                   break;
               case "Uaha": zergMsg = "9";
                   break;
               case "Zzzz": zergMsg = "A";
                   break;
               case "Bauu": zergMsg = "B";
                   break;
               case "Djav": zergMsg = "C";
                   break;
               case "Myau": zergMsg = "D";
                   break;
               case "Gruh": zergMsg = "E";
                   break;
               default: 
                   break;
           }

           return zergMsg;
       }
    }
}
