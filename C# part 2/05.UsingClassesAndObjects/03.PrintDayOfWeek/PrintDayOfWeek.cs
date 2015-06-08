using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.PrintDayOfWeek
{
    //Write a program that prints to the console which day of the week is today. Use System.DateTime.

    class PrintDayOfWeek
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now.DayOfWeek);
        }
    }
}
