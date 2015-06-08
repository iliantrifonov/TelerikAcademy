namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;

    public class CoursesExamples
    {
        public static void Main()
        {
            string courseName = "Databases";
            string lab = "Enterprise";
            string teacher = "Ivo";
            var students = new List<string>() { "Peter", "Maria" };
            LocalCourse localCourse = new LocalCourse(courseName, teacher, students, lab);
            Console.WriteLine(localCourse);

            localCourse.Lab = "Some other lab";
            Console.WriteLine(localCourse);

            localCourse.TeacherName = "Svetlin Nakov";
            localCourse.AddStudent("Milena");
            localCourse.AddStudent("Todor");
            Console.WriteLine(localCourse);

            string town = "Sofia";
            OffsiteCourse offsiteCourse = new OffsiteCourse(courseName, teacher, students, town);
            Console.WriteLine(offsiteCourse);
        }
    }
}