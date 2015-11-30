namespace AlgorithmTasks
{
    using System;
    using System.Linq;

    public class Program
    {
        static void Main()
        {
            string line = Console.ReadLine();
            string[] tasks = line.Split(new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);
            
            int num = int.Parse(Console.ReadLine());
            int max = int.Parse(tasks[0]);
            int min = int.Parse(tasks[0]);
            int count = 0;
            int result = 0;

            for (int i = 1; i < tasks.Length; i++)
            {
                if (int.Parse(tasks[i]) < min)
                {
                    min = int.Parse(tasks[i]);
                }

                if (int.Parse(tasks[i]) > max)
                {
                    max = int.Parse(tasks[i]);
                }

                if (max - min >= num)
                {
                    result = i;
                    break;
                }
            }

            if (result == 0)
            {
                Console.WriteLine(tasks.Length);
            }
            else
            {
                if (result % 2 == 0)
                {
                    if (result == 2)
                    {
                        count = 2;

                    }
                    else
                    {
                        count = (result / 2) + 1;
                    }

                }
                else
                {
                    var a = result / 2;
                    count = a + 2;
                }

                Console.WriteLine(count);
            }

        }
    }
}
