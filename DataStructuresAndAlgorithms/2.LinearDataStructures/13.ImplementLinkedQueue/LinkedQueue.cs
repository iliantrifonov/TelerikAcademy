﻿namespace _13.ImplementLinkedQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class LinkedQueue<T>
    {
        QueueItem<T> firstItem;
        QueueItem<T> lastItem;

        int count;

        public void Enqueue(T value)
        {
            if (firstItem == null)
            {
                lastItem = new QueueItem<T>(value);
                firstItem = lastItem;
            }
            else
            {
                lastItem.PreviousItem = new QueueItem<T>(value);
                lastItem = lastItem.PreviousItem;
            }

            count++;
        }

        public T Peek()
        {
            return firstItem.Value;
        }

        public T Dequeue()
        {
            if (firstItem == null)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            T valueToReturn = firstItem.Value;
            firstItem = firstItem.PreviousItem;
            count--;

            return valueToReturn;
        }

        public int Count
        {
            get
            {
                return count;
            }
        }
    }
}
