namespace _2.ReverseIntegers
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Write a program that reads N integers from the console and reverses them using a stack. Use the Stack<int> class.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var numbers = new Stack<int>();

            string line = null;
            while (true)
            {
                line = Console.ReadLine();

                if (line == string.Empty)
                {
                    break;
                }


                numbers.Push(int.Parse(line));
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
