namespace StudentSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using StudentSystem.Model;
    using StudentSystem.Data.Migrations;

    public class StudentSystemContext : DbContext, IStudentSystemContext
    {
        // Your context has been configured to use a 'StudentSystemContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'StudentSystem.Data.StudentSystemContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'StudentSystemContext' 
        // connection string in the application configuration file.
        public StudentSystemContext()
            : base("name=StudentSystemSQLContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual IDbSet<Student> Students { get; set; }

        public virtual IDbSet<Course> Courses { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}