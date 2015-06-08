using System;

namespace _16.ReadDatesCalculateDays
{
    //Write a program that reads two dates in the format: day.month.year and calculates the number of days between them. Example:
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first date: ");
            string[] dayWeekYear = Console.ReadLine().Split('.');
            DateTime firstDate = new DateTime(int.Parse(dayWeekYear[2]), int.Parse(dayWeekYear[1]), int.Parse(dayWeekYear[0]));
            Console.WriteLine("Enter second date: ");
            string[] secondDayWeekYear = Console.ReadLine().Split('.');
            DateTime secondDate = new DateTime(int.Parse(secondDayWeekYear[2]), int.Parse(secondDayWeekYear[1]), int.Parse(secondDayWeekYear[0]));
            TimeSpan distance = new TimeSpan();
            distance = secondDate - firstDate;
            Console.WriteLine("Distance: {0} days", distance.Days);
        }
    }
}
