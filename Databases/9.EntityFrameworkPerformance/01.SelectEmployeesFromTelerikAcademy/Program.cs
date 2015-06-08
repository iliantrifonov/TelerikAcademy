namespace _01.SelectEmployeesFromTelerikAcademy
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    /// <summary>
    /// Using Entity Framework write a SQL query to select all employees from the 
    /// Telerik Academy database and later print their name, department and town. 
    /// Try the both variants: with and without .Include(…). Compare the number of 
    /// executed SQL statements and the performance
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var context = new TelerikAcademyEntities();
            var sw = new Stopwatch();
            sw.Start();
            var employees = context.Employees;

            foreach (var employee in employees)
            {
                //Console.WriteLine("{0} in department: {1} in town: {2}", employee.FirstName, employee.Department.Name, employee.Address.Town.Name);
            }

            sw.Stop();
            var withoutInclude = sw.Elapsed;
            sw.Reset();
            sw.Start();
            var employeesWithInclude = context.Employees.Include("Department").Include("Address");

            foreach (var employee in employeesWithInclude)
            {
                //Console.WriteLine("{0} in department: {1} in town: {2}", employee.FirstName, employee.Department.Name, employee.Address.Town.Name);
            }

            sw.Stop();

            Console.WriteLine("Without include: {0}, with include: {1}", withoutInclude, sw.Elapsed);

            Console.WriteLine("The number of executed sql statements can be seen in the SQL profiler.");
        }
    }
}
