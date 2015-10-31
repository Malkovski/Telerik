namespace ImplementationOfLinkedList
{
    using System;
    using System.Linq;

    public class Startup
    {
        static void Main()
        {
            var linkedList = new LinkedList<int>();

            linkedList.AddLast(5);
            linkedList.AddLast(4);
            linkedList.AddLast(3);

            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
