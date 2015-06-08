namespace _05.Define64BitArr
{
    using System.Collections;
    using System.Collections.Generic;

    //Define a class BitArray64 to hold 64 bit values inside an ulong value. Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.

    public class BitArray64 : IEnumerable<int>
    {
        private ulong[] arr;

        public BitArray64(int size)
        {
            this.arr = new ulong[size];
            this.Length = size;
        }

        public BitArray64(ulong[] array)
        {
            this.arr = new ulong[array.Length];
            for (int i = 0; i < this.arr.Length; i++)
            {
                this.arr[i] = array[i];
            }
            this.Length = array.Length;
        }

        public int Length { get; private set; }

        public ulong this[int index]
        {
            get
            {
                return this.arr[index];
            }
            set
            {
                this.arr[index] = value;
            }
        }

        public static bool operator !=(BitArray64 first, BitArray64 second)
        {
            return !first.Equals(second);
        }

        public static bool operator ==(BitArray64 first, BitArray64 second)
        {
            return first.Equals(second);
        }

        public override bool Equals(object obj)
        {
            BitArray64 eqArr = obj as BitArray64;
            if (eqArr == null)
            {
                return false;
            }
            if (this.arr.Length != eqArr.Length)
            {
                return false;
            }
            for (int i = 0; i < this.arr.Length; i++)
            {
                if (this.arr[i] != eqArr[i])
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            return this.arr.GetHashCode() ^ this.Length;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<int>)this.GetEnumerator();
        }

        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            return (IEnumerator<int>)GetEnumerator();
        }

        private BitArray64Enum GetEnumerator()
        {
            return new BitArray64Enum(this.arr);
        }
    }
}