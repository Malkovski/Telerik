namespace RelevanceIndex
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class RelevanceIndex
    {
       public static void Main(string[] args)
        {
            string key = Console.ReadLine();
            int lines = int.Parse(Console.ReadLine());
            List<string> pargr = new List<string>(lines);
            List<int> place = new List<int>(lines);
           // Dictionary<int, string> pargr = new Dictionary<int, string>();
            char[] div = {',', '.', '-', '?', '!', ';','(', ')', ' '};
            int count = 0;
            int tempCount = -1;

            for (int i = 0; i < lines; i++)
            {            
                string row = Console.ReadLine();
                string[] words = row.Split(div, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < words.Length; j++)
                {
                    if (words[j].ToUpper() == key.ToUpper())
                    {
                        words[j] = words[j].ToUpper();
                        count++; 
                    }
                }
          
                pargr.Add(string.Join(" ", words));
                place.Add(count);
                count = 0;
            }

           string[] ddd = pargr.ToArray();
           
           var pos = -1;

           while (pargr.Count > 0)
           {
               for (int i = 0; i < place.Count; i++)
               {
                   if (place[i] > tempCount)
                   {
                       tempCount = place[i];
                       pos = i;
                   }
               }
               Console.WriteLine(pargr[pos]);
               pargr.RemoveAt(pos);
               place.RemoveAt(pos);
               tempCount = -1;
               pos = -1;
           }         
        }
    }
}
