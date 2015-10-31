namespace QueueAsDynamicLinkedList
{
    using System;

    public class Startup
    {
        static void Main(string[] args)
        {
            var myQueue = new Queue<int>();

            myQueue.Enqueue(2);
            myQueue.Enqueue(3);
            myQueue.Enqueue(5);

            Print(myQueue);

            myQueue.Dequeue();

            Print(myQueue);

            myQueue.Enqueue(1000);
            myQueue.Enqueue(1005);
            myQueue.Enqueue(1111);

            myQueue.Dequeue();
            myQueue.Dequeue();

            Print(myQueue);
        }

        public static void Print(Queue<int> queue)
        {
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-----------------------------------");
        }
    }
}
