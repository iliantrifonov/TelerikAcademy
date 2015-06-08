using System;

namespace _01.CheckLeapYear
{
    //Write a program that reads a year from the console and checks whether it is a leap. Use DateTime.

    class CheckLeapYear
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter year: ");
            bool isLeap = DateTime.IsLeapYear(int.Parse(Console.ReadLine()));
            Console.WriteLine("Is the year a leap year ? {0}", isLeap);
        }
    }
}
