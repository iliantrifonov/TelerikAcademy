namespace _03.ImplementBiDictionary
{
    using System;
    using System.Linq;

    /// <summary>
    /// Implement a class BiDictionary<K1,K2,T> that allows adding triples {key1, key2, value}
    /// and fast search by key1, key2 or by both key1 and key2. Note: multiple values can be 
    /// stored for given key.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            BiDictionary<string, int, string> biDictionary = new BiDictionary<string, int, string>(true);
            biDictionary.Add("asdf", 2, "abasab");
            biDictionary.Add("ac", "adsacac");
            biDictionary.Add("ac", 2, "adsadasdasdasadsc");
            biDictionary.Add(2, "ac");
            Console.WriteLine("Items with key 2: ");
            foreach (var item in biDictionary.FindByKey2(2))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine("Elements with keys 'ac' and 2: ");
            foreach (var item in biDictionary.FindByKeys("ac", 2))
            {
                Console.WriteLine(item);
            }
        }
    }
}
