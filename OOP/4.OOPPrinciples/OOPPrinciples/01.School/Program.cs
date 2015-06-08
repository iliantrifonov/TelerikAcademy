namespace _01.School
{
    //We are given a school. In the school there are classes of students. Each class has a set of teachers. Each teacher teaches a set of disciplines. Students have name and unique class number. Classes have unique text identifier. Teachers have name. Disciplines have name, number of lectures and number of exercises. Both teachers and students are people. Students, classes, teachers and disciplines could have optional comments (free text block).
    //Your task is to identify the classes (in terms of  OOP) and their attributes and operations, encapsulate their fields, define the class hierarchy and create a class diagram with Visual Studio.
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            School school = new School(new List<Class> { new Class(new HashSet<Student> { new Student("Ivan Ivanov", 1234), new Student("Ivan Petrov", 222) }, new HashSet<Teacher> { new Teacher("Ivo Andonov", new HashSet<Discipline> { new Discipline("Biology", 5, 3) }) }, "132b") });

            var namesOfStudents = school.Classes.SelectMany(c => c.Students).Select(b => b.FullName);
            foreach (var name in namesOfStudents)
            {
                Console.WriteLine(name);
            }
        }
    }
}