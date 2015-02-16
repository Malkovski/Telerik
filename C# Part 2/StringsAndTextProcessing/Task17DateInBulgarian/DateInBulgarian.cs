namespace Task17DateInBulgarian
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class DateInBulgarian
    {
       public static void Main(string[] args)
        {
            Console.WriteLine("Enter date and time ");
            string text = Console.ReadLine();
            string[] parts = text.Split(' ');
            string[] givenDate = parts[0].Split('.');
            string[] givenTime = parts[1].Split(':');
            int year = int.Parse(givenDate[2]);
            int month = int.Parse(givenDate[1]);
            int day = int.Parse(givenDate[0]);
            int hour = int.Parse(givenTime[0]);
            int minute = int.Parse(givenTime[1]);
            int seconds = int.Parse(givenTime[2]);

            DateTime realDateTime = new DateTime(year, month, day, hour, minute, seconds);
            realDateTime = realDateTime.Add(new TimeSpan(6, 30, 0));
            Console.Write("{0}.{1}.{2} {3}:{4}:{5}", realDateTime.Day,  realDateTime.Month,  realDateTime.Year,  realDateTime.Hour, realDateTime.Minute, realDateTime.Second);
            Console.WriteLine();
            string dayofWeek = realDateTime.DayOfWeek.ToString();

            switch (dayofWeek)
            {
                case "Monday": Console.WriteLine("Понеделник");
                    break;
                case "Tuesday": Console.WriteLine("Вторник");
                    break;
                case "Wednesday": Console.WriteLine("Сряда");
                    break;
                case "Thursday": Console.WriteLine("Четвъртък");
                    break;
                case "Friday": Console.WriteLine("Петък");
                    break;
                case "Saturday": Console.WriteLine("Събота");
                    break;
                case "Sunday": Console.WriteLine("Неделя");
                    break;

                default:
                    break;
            }
        }
    }
}
