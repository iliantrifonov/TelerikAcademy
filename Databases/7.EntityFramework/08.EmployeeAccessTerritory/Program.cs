namespace _08.EmployeeAccessTerritory
{
    using _01.CreateContextForNorthwind;
    using System;

    /// <summary>
    /// By inheriting the Employee entity class create a class which 
    /// allows employees to access their corresponding territories as 
    /// property of type EntitySet<T>.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// This is implemented in EmployeePartial.cs ( project 01.CreateContextForNorthwind ) as a partial class.
        /// </summary>
        public static void Main(string[] args)
        {
            var extended = new Employee();
            var context = new NorthwindEntities();
            extended = context.Employees.Find(1);

            foreach (var territory in extended.EntityTerritories)
            {
                Console.WriteLine("Teritory description - {0}", territory.TerritoryDescription);
            }
        }
    }
}
