namespace DataGenerator.DataGenerators
{
    using System;
    using System.Linq;

    using Model;

    public class EmployeeDataGenerator : DataGenerator
    {
        public EmployeeDataGenerator(CompanyDbContext context, int count)
            : base(context, count)
        {
        }

        protected override void AddData()
        {
            var departmentIds = this.DatabaseContext.Departments.Select(d => d.Id).ToList();

            for (int i = 0; i < this.Count; i++)
            {
                var currentEmployee = new Employee()
                {
                    FirstName = this.RandomGenerator.GetRandomStringWithRandomLength(5, 20),
                    LastName = this.RandomGenerator.GetRandomStringWithRandomLength(5, 20),
                    YearSalary = (decimal)this.RandomGenerator.GetRandomDoubleNumber(50000.0, 200000.0),
                    DepartmentId = departmentIds[this.RandomGenerator.GetRandomNumber(0, departmentIds.Count - 1)]
                };

                if (this.RandomGenerator.GetRandomNumber(0, 100) >= 95)
                {
                    currentEmployee.Employee1 = this.GetManager(i);
                }

                this.DatabaseContext.Employees.Add(currentEmployee);

                if (i % 200 == 0)
                {
                    this.Logger.Write(" . ");
                    this.DatabaseContext.SaveChanges();
                }
            }
        }

        private Employee GetManager(int currentlyEnteredAmount)
        {
            // by selecting from existing employees, we do not risk getting a loop, also first 2 will not have manager
            if (currentlyEnteredAmount < 2)
            {
                return null;
            }

            var employees = this.DatabaseContext.Employees.OrderBy(e => e.FirstName).Skip(this.RandomGenerator.GetRandomNumber(0, currentlyEnteredAmount - 1)).Take(1);

            return employees.FirstOrDefault();
        }
    }
}
