namespace _5.RemoveAllNegativeNumbersFromSequence
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Write a program that removes from given sequence all negative numbers.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var numbers = new List<int>() { 1, 2, 5, 8, -2, 12, -8 };

            //I know this is sort of cheating, but it didnt say we can't use buint in methods :)
            numbers.RemoveAll(x => x < 0);

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
