namespace StudentSystem.Data
{
    using System;

    using StudentSystem.Data.Repositories;
    using StudentSystem.Model;

    public interface IStudentSystemData
    {
        IGenericRepository<Course> Courses { get; }

        IGenericRepository<Student> Students { get; }
    }
}
