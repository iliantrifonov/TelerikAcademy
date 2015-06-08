namespace _01.CreateSimpleWCFService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using System.Text;

    /// <summary>
    /// Create a simple WCF service. It should have a method that accepts a DateTime parameter 
    /// and returns the day of week (in Bulgarian) as string. Test it with the integrated WCF client.
    /// </summary>
    public class DayOfWeekService : IDayOfWeekService
    {
        public string GetDayOfWeekInBulgarian(DateTime date)
        {
            var day = date.DayOfWeek;

            switch (day)
            {
                case DayOfWeek.Friday:
                    return "Петък";
                case DayOfWeek.Monday:
                    return "Понеделник";
                case DayOfWeek.Saturday:
                    return "Събота";
                case DayOfWeek.Sunday:
                    return "Неделя";
                case DayOfWeek.Thursday:
                    return "Четвъртък";
                case DayOfWeek.Tuesday:
                    return "Вторник";
                case DayOfWeek.Wednesday:
                    return "Сряда";
                default:
                    return "Invalid date";
            }
        }
    }
}
