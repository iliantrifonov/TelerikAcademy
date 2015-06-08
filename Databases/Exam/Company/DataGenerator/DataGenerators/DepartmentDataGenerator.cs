namespace DataGenerator.DataGenerators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Model;

    public class DepartmentDataGenerator : DataGenerator
    {
        public DepartmentDataGenerator(CompanyDbContext context, int count)
            : base(context, count)
        {
        }

        protected override void AddData()
        {
            var uniqueNames = new HashSet<string>();

            for (int i = 0; i < this.Count; i++)
            {
                var name = this.RandomGenerator.GetRandomStringWithRandomLength(10, 50);

                while (uniqueNames.Contains(name))
                {
                    name = this.RandomGenerator.GetRandomStringWithRandomLength(10, 50);
                }

                uniqueNames.Add(name);

                var currentDepartment = new Department()
                {
                    Name = name
                };

                this.DatabaseContext.Departments.Add(currentDepartment);

                if (i % 200 == 0)
                {
                    DatabaseContext.SaveChanges();
                    Logger.Write(" . ");
                }
            }
        }
    }
}
