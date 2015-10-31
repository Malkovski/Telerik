namespace ReverseIntegersWithStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main()
        {
            Stack<int> myStack = new Stack<int>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input != "")
                {
                    myStack.Push(int.Parse(input));
                }
                else
                {
                    foreach (var item in myStack)
                    {
                        Console.WriteLine(item);
                    }

                    break;
                }
            }
        }
    }
}
