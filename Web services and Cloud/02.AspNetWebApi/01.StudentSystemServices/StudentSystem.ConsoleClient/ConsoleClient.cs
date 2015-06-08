namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Linq;
    using StudentSystem.Data;
    using StudentSystem.Models;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Data;
    using System.Collections.Generic;

    public class ConsoleClient
    {
        public static void PrintStudents(IEnumerable<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine(student.FirstName);
            }
        }

        public static void Main()
        {
            var data = new StudentsSystemData();

            var courses = data.Courses.All();

            data.Courses.Add(new Course()
            {
                Name = "Stuff",
                Description = "Smtn"
            });

            data.SaveChanges();

            foreach (var course in courses)
            {
                Console.WriteLine(course.Name);
            }
            var students = data.Students.All();

            Console.WriteLine(students.Count());
        }
    }
}
