namespace _2.LinearDataStructures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Write a program that reads from the console a sequence of positive integer numbers. The sequence ends when empty line is entered. Calculate and print the sum and average of the elements of the sequence. Keep the sequence in List<int>.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var numbers = new List<double>();
            string line = null;

            while (true)
            {
                line = Console.ReadLine();

                if (line == string.Empty)
                {
                    break;
                }


                numbers.Add(double.Parse(line));
            }

            double sum = numbers.Sum();
            double average = sum / numbers.Count;
            Console.WriteLine("{0} {1}", sum, average);
        }
    }
}
