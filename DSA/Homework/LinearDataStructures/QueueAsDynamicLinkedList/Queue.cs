namespace QueueAsDynamicLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Queue<T> : IEnumerable<T>
    {
        private readonly LinkedList<T> items = new LinkedList<T>();

        public void Enqueue(T element)
        {
            this.items.AddLast(element);
        }

        public void Dequeue()
        {
            this.items.RemoveFirst();
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.items.First;

            for (int i = 0; i < this.items.Count; i++)
            {

                if (!EqualityComparer<T>.Default.Equals(node.Value, default(T)))
                {
                    yield return node.Value;
                }

                var newNode = node.Next;
                node = newNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
