namespace _01.PriorityQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryHeap<T>
    {
        const int InitialCapacity = 16;
        private int index;
        private readonly Comparer<T> compararer;
        private T[] data;

        public BinaryHeap() : this(InitialCapacity, null) 
        { 
        }

        public BinaryHeap(int initialSize) : this(initialSize, null) 
        {
        }

        public BinaryHeap(Comparer<T> compararer) : this(InitialCapacity, compararer) 
        {
        }

        public BinaryHeap(int initialSize, Comparer<T> compararer)
        {
            this.data = new T[initialSize];
            this.index = 0;
            this.compararer = compararer;

            if (compararer == null)
            {
                this.compararer = Comparer<T>.Default;
            }
        }

        public int Count
        {
            get
            {
                return this.index;
            }
        }

        public void Add(T element)
        {
            if (this.index == this.data.Length)
            {
                this.IncreaseSize();
            }
            this.data[index] = element;
            this.HeapUp(this.index);
            this.index++;
        }

        public void RemoveTop()
        {
            if (index == 0)
            {
                throw new InvalidOperationException("Cannot remove elements from a collection that is empty.");
            }

            this.data[0] = this.data[this.index - 1];
            this.index--;
            this.HeapDown();
        }

        public T GetTopElement()
        {
            return this.data[0];
        }

        public void Clear()
        {
            this.data = new T[this.data.Length];
            this.index = 0;
        }
        private void HeapUp(int newElementIndex)
        {
            int parentIndex = this.GetParentIndex(newElementIndex);

            //compararer if default keeps a MAX HEAP by default
            //<0 means that the order is reversed
            while (parentIndex >= 0 && this.compararer.Compare(this.data[parentIndex], this.data[newElementIndex]) < 0)
            {
                T helper = this.data[parentIndex];
                this.data[parentIndex] = this.data[newElementIndex];

                this.data[newElementIndex] = helper;

                newElementIndex = parentIndex;
                parentIndex = this.GetParentIndex(newElementIndex);
            }
        }
        private void HeapDown()
        {
            int parentIndex = 0;
            int indexOfChildToUse = 0;

            while (true)
            {
                int childIndex1 = this.GetChildLeftIndex(parentIndex);
                int childIndex2 = this.GetChildRightIndex(parentIndex);

                if (childIndex1 >= this.index)
                {
                    break;
                }

                if (childIndex2 >= this.index)
                {
                    indexOfChildToUse = childIndex1;
                }
                else
                {
                    indexOfChildToUse = this.compararer.Compare(this.data[childIndex1], this.data[childIndex2]) < 0 ?
                    childIndex2 : childIndex1;
                }

                if (this.compararer.Compare(this.data[parentIndex], this.data[indexOfChildToUse]) < 0)
                {
                    T helper = this.data[parentIndex];
                    this.data[parentIndex] = this.data[indexOfChildToUse];
                    this.data[indexOfChildToUse] = helper;
                    parentIndex = indexOfChildToUse;
                }
                else
                {
                    break;
                }
            }
        }

        private void IncreaseSize()
        {
            var newData = new T[this.data.Length * 2];
            Array.Copy(this.data, newData, this.data.Length);
            this.data = newData;
        }

        private int GetChildLeftIndex(int parentPosition)
        {
            return (parentPosition << 1) + 1;
        }

        private int GetChildRightIndex(int parentPosition)
        {
            return (parentPosition << 1) + 2;
        }
        private int GetParentIndex(int childPosition)
        {
            return (childPosition - 1) >> 1;
        }
    }
}
