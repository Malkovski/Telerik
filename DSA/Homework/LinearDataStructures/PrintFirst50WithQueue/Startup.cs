namespace PrintFirst50WithQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main()
        {
            int startingNumber = int.Parse(Console.ReadLine());
            Queue<int> myQueue = new Queue<int>();

            myQueue.Enqueue(startingNumber);
            

            for (int i = 0; i < 50; i++)
            {
                var peeked = myQueue.Peek();
                Console.WriteLine(peeked);
                myQueue.Enqueue(peeked + 1);
                myQueue.Enqueue(2 * peeked + 1);
                myQueue.Enqueue(peeked + 2);

                myQueue.Dequeue();
            }
        }
    }
}
