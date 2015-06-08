namespace DataGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DataGenerator.DataGenerators;
    using Model;

    public class EntryPoint
    {
        public static void Main()
        {
            Console.WriteLine("USING .");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            var context = new CompanyDbContext();
            var generators = new List<IDataGenerator>();
            generators.Add(new DepartmentDataGenerator(context, 100));
            generators.Add(new EmployeeDataGenerator(context, 5000));
            generators.Add(new ProjectDataGenerator(context, 1000));
            
            generators.Add(new EmployeeProjectDataGenerator(context, 5)); // this takes avarage.
            generators.Add(new ReportsGenerator(context, 250000));

            foreach (var generator in generators)
            {
                generator.Generate();
                context.SaveChanges();
            }
        }
    }
}
