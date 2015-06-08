namespace _03.FirstBeforeLast
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    //3.Write a method that from a given array of students finds all students whose first name is before its last name alphabetically. Use LINQ query operators.
    public class TestClass
    {
        public static IEnumerable<Student> FirstBefLast(Student[] students)
        {
            //Stundent[] result = students.Where( st => st.firstName.CompareTo(st.lastName) < 0).ToArray();
            var result =
                from st in students
                where st.FirstName.CompareTo(st.LastName) < 0
                select st;
            return result;
        }

        public static void Main(string[] args)
        {
            Student[] arrOfStundents = new Student[5];
            arrOfStundents[0] = new Student("Ivan", "Andonov");
            arrOfStundents[1] = new Student("Andon", "Zafirov");
            arrOfStundents[2] = new Student("Andon", "Bonev");
            arrOfStundents[3] = new Student("Kaloqn", "Andonov");
            arrOfStundents[4] = new Student("Boris", "Zafirov");
            var result = FirstBefLast(arrOfStundents);
            foreach (var student in result)
            {
                Console.WriteLine(student);
            }
        }
    }
}