namespace _05.CreateConsoleAppToConsumeService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using StringCounterServiceReference;

    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new StringCounterServiceClient();
            int count = client.CountTimesFirstContainedInSecondString("sa", "sasa");
            Console.WriteLine(count);
        }
    }
}
