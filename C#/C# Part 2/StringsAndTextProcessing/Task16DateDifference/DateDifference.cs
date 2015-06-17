namespace Task16DateDifference
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
   public class DateDifference
    {
       public static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            DateTime first = DateTime.Parse(firstDate);
            DateTime second = DateTime.Parse(secondDate);

            TimeSpan result = second.Subtract(first);

            Console.WriteLine(result.TotalDays + " days");
        }
    }
}
