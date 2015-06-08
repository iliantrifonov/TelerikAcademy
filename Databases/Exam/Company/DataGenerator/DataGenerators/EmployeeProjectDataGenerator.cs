namespace DataGenerator.DataGenerators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Model;

    public class EmployeeProjectDataGenerator : DataGenerator
    {
        public EmployeeProjectDataGenerator(CompanyDbContext context, int avarage)
            : base(context, avarage)
        {
        }

        protected override void AddData()
        {
            var projectIds = this.DatabaseContext.Projects.Select(p => p.Id).ToList();
            var employeeIds = this.DatabaseContext.Employees.Select(p => p.Id).ToList();
            int average = this.Count;
            int currentAverage = 0;
            int minEmployees = 2;
            int maxEmployees = 20;
            var amountsPerEntry = new List<int>(300);
            amountsPerEntry.Add(this.Count);

            for (int projectIndex = 0; projectIndex < projectIds.Count; projectIndex++)
            {
                currentAverage = (int)amountsPerEntry.Average();
                int amount = 0;

                if (currentAverage > average)
                {
                    amount = this.RandomGenerator.GetRandomNumber(minEmployees, average);
                }
                else
                {
                    amount = this.RandomGenerator.GetRandomNumber(average, maxEmployees);
                }

                amountsPerEntry.Add(amount);
                var uniqueEmployees = new HashSet<int>();
                for (int i = 0; i < amount; i++)
                {
                    var date = new DateTime(this.RandomGenerator.GetRandomNumber(2000, 2014), this.RandomGenerator.GetRandomNumber(1, 12), this.RandomGenerator.GetRandomNumber(1, 27));
                    var employeeProject = new EmployeesProject()
                    {
                        StartDate = date,
                        EndDate = date.AddDays(this.RandomGenerator.GetRandomDoubleNumber(1, 500)),
                    };

                    var employeeId = employeeIds[this.RandomGenerator.GetRandomNumber(0, employeeIds.Count - 1)];

                    while (uniqueEmployees.Contains(employeeId))
                    {
                        employeeId = employeeIds[this.RandomGenerator.GetRandomNumber(0, employeeIds.Count - 1)];
                    }
                    
                    uniqueEmployees.Add(employeeId);
                    employeeProject.EmployeeId = employeeId;

                    employeeProject.ProjectId = projectIds[projectIndex];

                    this.DatabaseContext.EmployeesProjects.Add(employeeProject);

                    this.DatabaseContext.SaveChanges();
                }

                if (projectIndex % 50 == 0)
                {
                    this.Logger.Write(" . ");
                }
            }
        }
    }
}
