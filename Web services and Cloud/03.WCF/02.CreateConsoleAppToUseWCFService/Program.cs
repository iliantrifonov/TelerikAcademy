namespace _02.CreateConsoleAppToUseWCFService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using DayOfWeekServiceReference;

    /// <summary>
    /// Create a console-based client for the WCF service above. Use the "Add Service Reference" in Visual Studio.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new DayOfWeekServiceClient();

            var day = client.GetDayOfWeekInBulgarian(DateTime.Now);

            Console.WriteLine(day);
        }
    }
}
