namespace StudentSystem.Data.Migrations
{
    using StudentSystem.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;

            //This is for testing purposes!
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "StudentSystem.Data.StudentSystemContext";
        }

        protected override void Seed(StudentSystemContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            if (context.Students.Count() > 0)
            {
                return;
            }

            var ivancho = new Student { Name = "Ivancho" };
            ivancho.Courses.Add(new Course() { Name = "JS" });


            var doncho = new Student { Name = "Doncho" };
            doncho.Courses.Add(new Course() { Name = "Databases" });

            context.Students.Add(ivancho);
            context.Students.Add(new Student { Name = "Pesho" });
            context.Students.Add(new Student { Name = "Niki" });
            context.Students.Add(doncho);
            context.Students.Add(new Student { Name = "Joreto" });
            context.Students.Add(new Student { Name = "Viki" });
            context.Students.Add(new Student { Name = "Evlogi" });

            context.SaveChanges();
        }
    }
}
