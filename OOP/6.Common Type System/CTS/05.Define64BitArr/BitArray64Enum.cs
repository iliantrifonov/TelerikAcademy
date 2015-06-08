namespace _05.Define64BitArr
{
    using System;
    using System.Collections;

    public class BitArray64Enum : IEnumerator
    {
        private ulong[] array;
        private int position = -1;

        public BitArray64Enum(ulong[] arr)
        {
            this.array = arr;
        }

        public object Current
        {
            get
            {
                try
                {
                    return this.array[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public bool MoveNext()
        {
            this.position++;
            if (position < this.array.Length)
            {
                return true;
            }
            return false;
        }

        public void Reset()
        {
            this.position = -1;
        }
    }
}