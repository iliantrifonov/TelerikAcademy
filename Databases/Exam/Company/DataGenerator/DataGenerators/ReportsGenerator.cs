namespace DataGenerator.DataGenerators
{
    using System;
    using System.Linq;

    using Model;

    public class ReportsGenerator : DataGenerator
    {
        public ReportsGenerator(CompanyDbContext context, int count)
            : base(context, count)
        {
        }

        protected override void AddData()
        {
            int employeeCount = this.DatabaseContext.Employees.Count();
            int countPerEmployee = this.Count / employeeCount;
            int currentlyGeneratedReports = 0;

            var employeeIds = this.DatabaseContext.Employees.Select(e => e.Id).ToList();

            for (int empCount = 0; empCount < employeeIds.Count; empCount++)
            {
                for (int reportCount = 0; reportCount < countPerEmployee; reportCount++)
                {
                    var currentReport = this.GetRandomReportWithoutEmployee();

                    currentReport.EmployeeId = employeeIds[empCount];
                    this.DatabaseContext.Reports.Add(currentReport);
                    currentlyGeneratedReports++;

                    if (currentlyGeneratedReports % 200 == 0)
                    {
                        this.DatabaseContext.SaveChanges();
                        this.Logger.Write(" . ");
                    }

                    this.DatabaseContext.SaveChanges();
                }
            }

            while (this.Count > currentlyGeneratedReports)
            {
                var currentReport = this.GetRandomReportWithoutEmployee();
                currentReport.EmployeeId = employeeIds[this.RandomGenerator.GetRandomNumber(0, employeeIds.Count - 1)];
                this.DatabaseContext.Reports.Add(currentReport);

                currentlyGeneratedReports++;
                if (currentlyGeneratedReports % 200 == 0)
                {
                    this.DatabaseContext.SaveChanges();
                    this.Logger.Write(" . ");
                }
            }
        }

        private Report GetRandomReportWithoutEmployee()
        {
            var year = this.RandomGenerator.GetRandomNumber(1990, 2014);
            var month = this.RandomGenerator.GetRandomNumber(1, 12);
            var day = this.RandomGenerator.GetRandomNumber(1, 28); // I wont check for years or months... its overkill trainer said its ok
            var hour = this.RandomGenerator.GetRandomNumber(0, 23);
            var minute = this.RandomGenerator.GetRandomNumber(0, 59);
            var reportDate = new DateTime(year, month, day, hour, minute, 1);

            var currentReport = new Report()
            {
                TimeOfReporting = reportDate
            };

            return currentReport;
        }
    }
}
