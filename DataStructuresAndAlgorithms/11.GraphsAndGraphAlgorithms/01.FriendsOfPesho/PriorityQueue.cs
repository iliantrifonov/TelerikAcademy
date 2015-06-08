namespace _01.FriendsOfPesho
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PriorityQueue<T>
    {
        private SortedSet<T> items;

        public PriorityQueue()
        {
            this.items = new SortedSet<T>();
        }

        public int Count
        {
            get
            {
                return items.Count;
            }
        }

        public void Enqueue(T element)
        {
            this.items.Add(element);
        }

        public T Dequeue()
        {
            var minNode = this.items.Min;
            this.items.Remove(minNode);
            return minNode;
        }

        public void Remove(T element)
        {
            this.items.Remove(element);
        }
    }
}
