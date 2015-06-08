namespace DataGenerator.DataGenerators
{
    using System;
    using System.Linq;

    using Model;

    public class ProjectDataGenerator : DataGenerator
    {
        public ProjectDataGenerator(CompanyDbContext context, int count)
            : base(context, count)
        {
        }

        protected override void AddData()
        {
            for (int i = 0; i < this.Count; i++)
            {
                var currentProject = new Project()
                {
                    Name = this.RandomGenerator.GetRandomStringWithRandomLength(5, 50)
                };

                this.DatabaseContext.Projects.Add(currentProject);

                if (i % 200 == 0)
                {
                    this.DatabaseContext.SaveChanges();

                    this.Logger.Write(" . ");
                }
            }
        }
    }
}
