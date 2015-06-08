using System;

namespace _05.HowManyWorkDays
{
    //Write a method that calculates the number of workdays between today and given date, passed as parameter. Consider that workdays are all days from Monday to Friday except a fixed list of public holidays specified preliminary as array.

    class HowManyWorkDays
    {
        static void Main(string[] args)
        {
            DateTime currentDate = DateTime.Today; //new DateTime(2013, 1, 20);
            Console.WriteLine("Enter date AFTER today:" );
            Console.WriteLine("Enter day: ");
            int day = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter month: ");
            int month = int.Parse(Console.ReadLine());
            DateTime futureDate = new DateTime(DateTime.Now.Year, month, day);

            Console.WriteLine("The working days between these dates are {0}", CalculateWorkdays(currentDate,futureDate));
        }

        private static int CalculateWorkdays(DateTime startDate, DateTime endDate)
        {
            int currentYear = DateTime.Now.Year;
            DateTime[] holidayArray = new[] // this can also be done as a static field for this class
            {
               new DateTime(currentYear, 1, 1),
               new DateTime(currentYear, 3, 3),
               new DateTime(currentYear, 5, 1),
               new DateTime(currentYear, 5, 2),
               new DateTime(currentYear, 5, 6),
               new DateTime(currentYear, 5, 24),
               new DateTime(currentYear, 9, 22),
               new DateTime(currentYear, 12, 24),
               new DateTime(currentYear, 12, 25),
               new DateTime(currentYear, 12, 26),
               new DateTime(currentYear, 12, 31),
            };

            int totalDays = Math.Abs((startDate - endDate).Days);
            bool isHoliday = false;
            int workingDays = 0;
            for (int days = 0; days < totalDays; days++)
            {
                startDate = startDate.AddDays(1);
                if (startDate.DayOfWeek != DayOfWeek.Saturday && startDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    for (int i = 0; i < holidayArray.Length; i++)
                    {
                        if (startDate == holidayArray[i])
                        {
                            isHoliday = true;
                            break;
                        }
                    }
                    if (isHoliday == false)
                    {
                        workingDays++;
                    }
                }
                isHoliday = false;
            }
            return workingDays;
        }
    }
}
