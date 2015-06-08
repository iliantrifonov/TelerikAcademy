namespace _04.ImplementHashTable
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class HashTable<K, V> : IEnumerable<KeyValuePair<K, V>>
    {
        private LinkedList<KeyValuePair<K, V>>[] array;
        private int elementCount;

        public HashTable()
        {
            this.array = new LinkedList<KeyValuePair<K, V>>[16];
            this.elementCount = 0;
        }

        public int Count
        {
            get 
            {
                return this.elementCount;
            }
        }

        public V this[K key]
        {
            get
            {
                return this.Find(key);
            }
            set
            {
                if (this.ContainsKey(key))
                {
                    this.Remove(key);
                }

                this.Add(key, value);
            }
        }

        public IEnumerable<K> Keys()
        {
            var result = new List<K>();
            for (int i = 0; i < this.array.Length; i++)
            {
                if (this.array[i] == null)
                {
                    continue;
                }

                foreach (var pair in this.array[i])
                {
                    result.Add(pair.Key);
                }
            } 

            return result;
        }
        public V Find(K key)
        {
            if (!this.ContainsKey(key))
            {
                throw new KeyNotFoundException();
            }

            var position = this.GetPositionInArray(key, this.array);

            foreach (var pair in this.array[position])
            {
                if (pair.Key.Equals(key))
                {
                    return pair.Value;
                }
            }

            throw new KeyNotFoundException();
        }

        public bool ContainsKey(K key)
        {
            var position = this.GetPositionInArray(key, this.array);
            if (this.array[position] == null)
            {
                return false;
            }

            foreach (var pair in this.array[position])
            {
                if (pair.Key.Equals(key))
                {
                    return true;
                }
            }

            return false;
        }

        public void Add(K key, V value)
        {
            if (this.ContainsKey(key))
            {
                throw new ArgumentException("Key already exists");
            }

            if (array.Length <= 0.75 * elementCount)
            {
                IncreaseArraySize();
            }

            var pair = new KeyValuePair<K, V>(key, value);

            this.AddToArray(pair, this.array);

            this.elementCount++;
        }

        public void Remove(K key) 
        {
            if (!this.ContainsKey(key))
            {
                return;
            }

            var position = this.GetPositionInArray(key, this.array);
            KeyValuePair<K, V> pair = new KeyValuePair<K,V>();

            foreach (var item in this.array[position])
            {
                if (item.Key.Equals(key))
                {
                    pair = item;
                    break;
                }
            }

            this.array[position].Remove(pair);
            this.elementCount--;
        }

        public void Clear()
        {
            this.elementCount = 0;
            this.array = new LinkedList<KeyValuePair<K, V>>[16];
        }

        private void AddToArray(KeyValuePair<K, V> pair, LinkedList<KeyValuePair<K, V>>[] arr)
        {
            var position = this.GetPositionInArray(pair.Key, arr);

            if (arr[position] == null)
            {
                var list = new LinkedList<KeyValuePair<K, V>>();
                list.AddLast(pair);
                arr[position] = list;
            }
            else
            {
                arr[position].AddLast(pair);
            }
        }

        private void IncreaseArraySize()
        {
            var newArray = new LinkedList<KeyValuePair<K, V>>[this.array.Length * 2];

            foreach (var list in this.array)
            {
                if (list == null)
                {
                    continue;
                }

                foreach (var item in list)
                {
                    this.AddToArray(item, newArray);
                }
            }

            this.array = newArray;
        }

        private int GetPositionInArray(K key, LinkedList<KeyValuePair<K, V>>[] arr)
        {
            return Math.Abs(key.GetHashCode() % (arr.Length - 1));
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            for (int i = 0; i < this.array.Length; i++)
            {
                if (this.array[i] == null)
                {
                    continue;
                }

                foreach (var pair in this.array[i])
                {
                    yield return pair;
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
