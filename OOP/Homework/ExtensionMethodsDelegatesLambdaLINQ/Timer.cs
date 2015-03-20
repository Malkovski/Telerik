namespace ExtensionMethodsDelegatesLambdaLINQ
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public delegate void MyDelegate(string message, int seconds);
    public class Timer
    {
        public static void MessageRepeat(string message, int seconds)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            while (seconds >= 0)
            {
                if (stopWatch.ElapsedMilliseconds == 1000)
                {
                    if (seconds > 0)
                    {
                        Console.WriteLine(seconds);
                        seconds--;
                    }
                    else
                    {
                        Console.WriteLine(message);
                        seconds--;
                    }
                    
                    stopWatch.Restart();
                }
            }    
        }
    }
}
