namespace _05.ImplementHashedSet
{
    using System;

    /// <summary>
    /// Implement the data structure "set" in a class HashedSet<T> using your 
    /// class HashTable<K,T> to hold the elements. Implement all standard set 
    /// operations like Add(T), Find(T), Remove(T), Count, Clear(), union and 
    /// intersect.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var testSet = new HashedSet<string>();

            testSet.Add("Hello");
            testSet.Add("soo");
            testSet.Add("moo");
            testSet.Add("mooz");
            testSet.Add("opefw");
            testSet.Add("dd");

            testSet.Remove("opefw");
            
            Console.WriteLine(testSet.Find("dd"));
            Console.WriteLine(testSet.Find("moo"));
        }
    }
}
