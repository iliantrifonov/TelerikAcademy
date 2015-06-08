using System;
using System.Text;

namespace _17.ReadDateTimePrintDayOfWeekAndDate
{
    //Write a program that reads a date and time given in the format: day.month.year hour:minute:second and prints the date and time after 6 hours and 30 minutes (in the same format) along with the day of week in Bulgarian.

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; // you also need to change your font on the option of the console for it to support cirillic
            Console.WriteLine("Enter date as day.month.year hour:minute:second : ");
            string[] dayWeekYear = Console.ReadLine().Split('.', ':');//"27.02.2006 12:10:31".Split('.', ':',' '); 
            DateTime firstDate = new DateTime(int.Parse(dayWeekYear[2]), int.Parse(dayWeekYear[1]), int.Parse(dayWeekYear[0]),int.Parse(dayWeekYear[3]),int.Parse(dayWeekYear[4]),int.Parse(dayWeekYear[5]));
            firstDate = firstDate.AddHours(6);
            firstDate = firstDate.AddMinutes(30);
            Console.WriteLine("The date:time is: {0}, the day of the week is :{1}", firstDate.ToString("dd.MM.yyyy HH:mm:ss"), firstDate.ToString("dddd",new System.Globalization.CultureInfo("bg-BG"))); //IMPORTANT this will show ????? if your console cannot read cirilic. It does work normaly and everywhere with all latin based languages
        }
    }
}
