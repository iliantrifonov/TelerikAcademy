namespace _05.To07.ListImplimentation
{
    using System;
    using System.Text;

    //5.Write a generic class GenericList<T> that keeps a list of elements of some parametric type T. Keep the elements of the list in an array with fixed capacity which is given as parameter in the class constructor. Implement methods for adding element, accessing element by index, removing element by index, inserting element at given position, clearing the list, finding element by its value and ToString(). Check all input parameters to avoid accessing elements at invalid positions.
    //6.Implement auto-grow functionality: when the internal array is full, create a new array of double size and move all elements to it.
    //7.Create generic methods Min<T>() and Max<T>() for finding the minimal and maximal element in the  GenericList<T>. You may need to add a generic constraints for the type T.

    public class GenericList<T> where T : IComparable<T>
    {
        private const int initialLenght = 128;
        private T[] array;
        private int length;
        private int capacity;

        public GenericList()
        {
            this.array = new T[initialLenght];
            this.length = 0;
            this.capacity = initialLenght;
        }

        public void Add(T item)
        {
            if (this.array.Length <= length)
            {
                this.IncreaseCapacity();
            }
            this.array[length] = item;
            this.length++;
        }

        private void IncreaseCapacity()
        {
            T[] arr = new T[this.capacity * 2];
            for (int i = 0; i < this.array.Length; i++)
            {
                arr[i] = this.array[i];
            }
            this.array = arr;
            this.capacity = this.array.Length;
        }

        public T this[int index]
        {
            get
            {
                if (index >= this.length)
                {
                    throw new IndexOutOfRangeException(String.Format("Invalid index: {0}.", index));
                }
                T result = this.array[index];
                return result;
            }
        }

        public void RemoveAt(int index)
        {
            if (index >= this.length)
            {
                throw new IndexOutOfRangeException(String.Format("Invalid index: {0}.", index));
            }
            if (this.array.Length <= length)
            {
                this.IncreaseCapacity();
            }
            for (int i = index; i < this.length; i++)
            {
                this.array[i] = this.array[i + 1];
            }
            this.length--;
        }

        public void InsertAt(int index, T element)
        {
            if (index >= this.length)
            {
                throw new IndexOutOfRangeException(String.Format("Invalid index: {0}.", index));
            }
            if (this.array.Length <= length)
            {
                this.IncreaseCapacity();
            }
            for (int i = this.length; i > index; i--)
            {
                this.array[i] = this.array[i - 1];
            }
            this.array[index] = element;
            this.length++;
        }

        public void Clear()
        {
            this.array = new T[initialLenght];
            this.length = 0;
            this.capacity = initialLenght;
        }

        public int FindElement(T element)
        {
            if (this.array.Length <= length)
            {
                this.IncreaseCapacity();
            }
            for (int i = 0; i < length; i++)
            {
                if (this.array[i].CompareTo(element) == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (this.array.Length <= length)
            {
                this.IncreaseCapacity();
            }
            sb.Append("{ ");
            for (int i = 0; i < this.length; i++)
            {
                sb.Append(array[i].ToString());
                sb.Append(" ");
            }
            sb.Append("}");
            return sb.ToString();
        }

        public T Min()
        {
            if (this.length == 0)
            {
                throw new ArgumentNullException("The list is empty, there is no min element");
            }
            if (this.array.Length <= length)
            {
                this.IncreaseCapacity();
            }
            T min = this.array[0];
            for (int i = 0; i < this.length; i++)
            {
                if (min.CompareTo(array[i]) == 1)
                {
                    min = array[i];
                }
            }
            return min;
        }

        public T Max()
        {
            if (this.length == 0)
            {
                throw new ArgumentNullException("The list is empty, there is no max element");
            }
            if (this.array.Length <= length)
            {
                this.IncreaseCapacity();
            }
            T max = this.array[0];
            for (int i = 0; i < this.length; i++)
            {
                if (max.CompareTo(array[i]) == -1)
                {
                    max = array[i];
                }
            }
            return max;
        }
    }
}
