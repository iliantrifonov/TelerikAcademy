namespace _05.ImplementHashedSet
{
    using System.Collections.Generic;
    using System.Linq;
    using _04.ImplementHashTable;

    public class HashedSet<T>
    {
        private HashTable<T, string> hashedTable;

        public HashedSet()
        {
            this.hashedTable = new HashTable<T, string>();
        }

        public int Count
        {
            get
            {
                return this.hashedTable.Count;
            }
        }

        /// <summary>
        /// Modifies the current collection to contain all elements that are present in one collection, the other or both collections.
        /// </summary>
        /// <param name="collection">Collection to union the current one with.</param>
        public void UnionWith(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                this.hashedTable[item] = null;
            }
        }

        /// <summary>
        /// Modifies the current collection to contain all elements that are present in both collections.
        /// </summary>
        /// <param name="collection">Collection to intersect the current one with.</param>
        public void IntersectWith(IEnumerable<T> collection)
        {
            var keys = this.hashedTable.Keys();
            var intersectionOfKeys = keys.Intersect(collection);
            this.hashedTable.Clear();

            foreach (var item in intersectionOfKeys)
            {
                this.Add(item);
            }
        }

        public void Add(T item)
        {
            this.hashedTable.Add(item, null);
        }

        public void Clear()
        {
            this.hashedTable.Clear();
        }

        public T Find(T item)
        {
            if (this.hashedTable.ContainsKey(item))
            {
                return item;
            }

            throw new KeyNotFoundException();
        }

        public void Remove(T item)
        {
            this.hashedTable.Remove(item);
        }
    }
}
