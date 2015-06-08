namespace _01.CreateContextForNorthwind
{
    using System;
    using System.Linq;

    /// <summary>
    /// Using the Visual Studio Entity Framework designer create a DbContext for the Northwind database.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var northwindEntities = new NorthwindEntities())
            {
                Console.WriteLine(northwindEntities.Employees.First().FirstName);
            }
        }
    }
}
