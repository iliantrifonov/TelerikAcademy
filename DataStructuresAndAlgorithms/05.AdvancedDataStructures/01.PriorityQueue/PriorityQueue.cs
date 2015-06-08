namespace _01.PriorityQueue
{
    using System;
    using System.Collections.Generic;
    
    public class PriorityQueue<T>
    {
        private BinaryHeap<T> queue;
        
        public PriorityQueue()
            : this(null) 
        {
        }
       
        public PriorityQueue(Comparer<T> compararer)
        {
            this.queue = new BinaryHeap<T>(compararer);
        }

        public int Count
        {
            get
            {
                return this.queue.Count;
            }
        }
       
        public void Enqueue(T element)
        {
            this.queue.Add(element);
        }
        
        public T Peek()
        {
            return this.queue.GetTopElement();
        }
        
        public T Dequeue()
        {
            T elementToReturn = this.queue.GetTopElement();
            this.queue.RemoveTop();
            return elementToReturn;
        }
        
        public void Clear()
        {
            this.queue.Clear();
        }
    }
}
