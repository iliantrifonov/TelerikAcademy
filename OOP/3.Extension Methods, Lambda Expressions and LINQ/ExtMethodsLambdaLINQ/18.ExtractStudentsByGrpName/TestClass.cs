namespace _18.ExtractStudentsByGrpName
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    //18.Create a program that extracts all students grouped by GroupName and then prints them to the console. Use LINQ.
    //19.Rewrite the previous using extension methods.

    public class TestClass
    {
        public static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            students.Add(new Student("Ivan", "Ivanov", "BETA"));
            students.Add(new Student("Petyr", "Petrov", "GAMMA"));
            students.Add(new Student("Niki", "Bicikitov", "DELTA"));
            students.Add(new Student("Niki", "Nikitov", "DELTA"));
            students.Add(new Student("Niki", "Shmatkov", "DELTA"));
            students.Add(new Student("Eli", "Elhova", "OMEGA"));
            students.Add(new Student("Milka", "Milkova", "ALPHA"));
            Console.WriteLine("With LINQ");
            var grouped =
                from st in students
                group st by st.GroupName into grp
                orderby grp.Key
                select grp;
            foreach (var grp in grouped)
            {
                Console.WriteLine("The members of group {0} are:", grp.Key);
                foreach (var st in grp)
                {
                    Console.WriteLine(st);
                }
                Console.WriteLine();
            }

            Console.WriteLine("With extention methods");
            var groupedExtention = students.GroupBy(st => st.GroupName).OrderBy(st => st.Key);
            foreach (var grp in groupedExtention)
            {
                Console.WriteLine("The members of group {0} are:", grp.Key);
                foreach (var st in grp)
                {
                    Console.WriteLine(st);
                }
                Console.WriteLine();
            }
        }
    }
}