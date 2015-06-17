namespace Task12ParseURl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class ParseUrl
    {
       public static void Main(string[] args)
        {
            string url = Console.ReadLine();
            int protEnd = url.IndexOf(':');
            Console.WriteLine("[protocol]= " + url.Substring(0, protEnd));
            url = url.Substring(protEnd + 3);
            int servStart = url.IndexOf('/');
            Console.WriteLine("[server]= " + url.Substring(0, servStart));
            Console.WriteLine("[resource]= " + url.Substring(servStart));            
        }
    }
}
