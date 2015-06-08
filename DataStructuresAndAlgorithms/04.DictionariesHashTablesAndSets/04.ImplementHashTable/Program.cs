namespace _04.ImplementHashTable
{
    using System;

    /// <summary>
    /// Implement the data structure "hash table" in a class HashTable<K,T>. 
    /// Keep the data in array of lists of key-value pairs (LinkedList<KeyValuePair<K,T>>[])
    /// with initial capacity of 16. When the hash table load runs over 75%, perform resizing
    /// to 2 times larger capacity. Implement the following methods and properties: Add(key, value),
    /// Find(key)value, Remove( key), Count, Clear(), this[], Keys. Try to make the hash table to
    /// support iterating over its elements with foreach.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var testTable = new HashTable<string, string>();

            testTable.Add("Hello", "Peter");
            testTable.Add("soo", "other");
            testTable.Add("moo", "Pe3ter");
            testTable.Add("mooz", "4");
            testTable.Add("opefw", "2");
            testTable.Add("dd", "22");

            testTable.Remove("opefw");

            foreach (var item in testTable)
            {
                Console.WriteLine(item.Value); 
            }

            Console.WriteLine(testTable.Find("dd"));
        }
    }
}
