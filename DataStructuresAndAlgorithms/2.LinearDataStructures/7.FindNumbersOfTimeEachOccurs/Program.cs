namespace _7.FindNumbersOfTimeEachOccurs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Write a program that finds in given array of integers (all belonging to the range [0..1000]) how many times each of them occurs.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
           
            Dictionary<int, int> occuranceOfNumbers = new Dictionary<int, int>();
            foreach (var number in numbers)
            {
                if (occuranceOfNumbers.ContainsKey(number))
                {
                    occuranceOfNumbers[number] += 1;
                }
                else
                {
                    occuranceOfNumbers.Add(number, 1);
                }
            }

            foreach (var item in occuranceOfNumbers)
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }
        }
    }
}
