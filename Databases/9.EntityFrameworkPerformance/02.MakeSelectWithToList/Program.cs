namespace _02.MakeSelectWithToList
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    using _01.SelectEmployeesFromTelerikAcademy;

    public class Program
    {
        public static void Main(string[] args)
        {
            var context = new TelerikAcademyEntities();
            var sw = new Stopwatch();
            sw.Start();

            var employeesInSofiaWithList = context.Employees
                                    .ToList()
                                    .Select(e => e.Address)
                                    .ToList()
                                    .Select(a => a.Town)
                                    .ToList()
                                    .Where(t => t.Name == "Sofia").Count();
            Console.WriteLine(employeesInSofiaWithList);
            sw.Stop();
            Console.WriteLine(sw.Elapsed);

            sw.Reset();
            sw.Start();

            //This makes a single query with joins.
            var fasterEmployeesInSofia = context.Employees.Where(e => e.Address.Town.Name == "Sofia").Count();

            Console.WriteLine(fasterEmployeesInSofia);
            sw.Stop();
            Console.WriteLine(sw.Elapsed);

        }
    }
}
