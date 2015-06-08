namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Linq;

    using Data;

    public class Program
    {
        public static void Main(string[] args)
        {
            var context = new StudentSystemContext();

            var student = context.Students.FirstOrDefault();

            Console.WriteLine("The first student is in course: " + student.Courses.FirstOrDefault().Name);
        }
    }
}
