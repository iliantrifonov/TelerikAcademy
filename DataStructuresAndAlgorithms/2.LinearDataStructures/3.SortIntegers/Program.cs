namespace _3.SortIntegers
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Write a program that reads a sequence of integers (List<int>) ending with an empty line and sorts them in an increasing order.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var numbers = new List<int>();

            string line = null;
            while (true)
            {
                line = Console.ReadLine();

                if (line == string.Empty)
                {
                    break;
                }


                numbers.Add(int.Parse(line));
            }

            numbers.Sort();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
